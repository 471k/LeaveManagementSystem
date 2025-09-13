using LeaveManagementSystem.Application.Models.LeaveRequests;
using LeaveManagementSystem.Application.Services.LeaveRequests;
using LeaveManagementSystem.Application.Services.LeaveTypes;
using LeaveManagementSystem.Application.Services.LeaveRequests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Application.Controllers
{
    [Authorize]
    public class LeaveRequestsController(
        ILeaveTypesService _leaveTypesService, 
        ILeaveRequestsService _leaveRequestService) : Controller
    {
        // Employee View requests
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestService.GetEmployeeLeaveRequests();
            return View(model);
        }

        // Employee Create requests
        [HttpGet]
        public async Task<IActionResult> Create(int? leaveTypeId)
        {
            var leaveTypes = await _leaveTypesService.GetAllAsync();
            var leaveTypesList = new SelectList(leaveTypes, "Id", "Name", leaveTypeId);
            var model = new LeaveRequestCreateVM
            {
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                LeaveTypes = leaveTypesList
            };

            return View(model);
        }

        // Employee Create requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            if (await _leaveRequestService.RequestDatesExceedAllocation(model))
            {
                ModelState.AddModelError(string.Empty, "You have exceeded your allocation.");
                ModelState.AddModelError(nameof(model.EndDate), "The number of days requested is invalid.");
            }

            if(ModelState.IsValid)
            {
                await _leaveRequestService.CreateLeaveRequest(model);
                return RedirectToAction(nameof(Index));
            }

            var leaveTypes = await _leaveTypesService.GetAllAsync();
            model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");

            return View(model);
        }

        // Employee Cancel requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int leaveRequestId)
        {
            await _leaveRequestService.CancelLeaveRequest(leaveRequestId);
            return RedirectToAction(nameof(Index));
        }

        // Admin/Supe review requests
        //[Authorize(Roles = Roles.Administrator + ", " + Roles.Supervisor)]
        [Authorize(Policy = "AdminSupervisorOnly")]
        public async Task<IActionResult> ListRequests()
        {
            var model = await _leaveRequestService.AdminGetAllLeaveRequests();
            return View(model);
        }
        
        // Admin/Supe review requests
        [HttpGet]
        public async Task<IActionResult> Review(int id)
        {
            var model = await _leaveRequestService.GetLeaveRequestForReview(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int id, bool approved)
        { 
            await _leaveRequestService.ReviewLeaveRequest(id, approved);
            return RedirectToAction(nameof(ListRequests));
        }

    }
}
