using AutoMapper;
using LeaveManagementSystem.Application.Models.LeaveTypes;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Application.Services.LeaveTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeaveManagementSystem.Application.Services.LeaveTypes;

public class LeaveTypesService(
    ApplicationDbContext _context, 
    IMapper _mapper,
    ILogger<LeaveTypesService> _logger) : ILeaveTypesService
{

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllAsync()
    {
        var data = await _context.LeaveTypes.ToListAsync();

        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

        return viewData;
    }

    public async Task<T?> GetAsync<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(lt => lt.Id == id);

        if (data is null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);

        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(lt => lt.Id == id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        try
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        _logger.LogInformation("Creating leave type: {leaveTypeName} - {days}", 
            model.Name, model.NumberOfDays);

        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }


    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowercaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(lt => lt.Name.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowercaseName = leaveTypeEdit.Name.ToLower();

        return await _context.LeaveTypes.AnyAsync(lt => lt.Name.ToLower().Equals(lowercaseName)
        && lt.Id != leaveTypeEdit.Id);
    }

    public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);
        return leaveType.NumberOfDays < days;
    }
}
