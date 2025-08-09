using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
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
