using LeaveManagementSystem.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Application.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel 
            { 
                Name = "Test Name from TestController"       ,
                DateOfBirth = DateTime.Now.AddYears(-30)
            };
            return View(data);
        }
    }    
}
