using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReporDemo.Models;

namespace ReporDemo.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {

        [HttpGet("/api/reports/GetEmployees/", Name = "GetEmployees")]
        public IActionResult GetEmployees()
        {
            DataViewModel[] dvm = new DataViewModel[]
            {
                 new DataViewModel { EmployeeiD = 1, FullName = "Ahmad", Department = "IT" },
                new DataViewModel { EmployeeiD = 2, FullName = "Ali", Department = "IT" },
                new DataViewModel { EmployeeiD = 3, FullName = "Jaber", Department = "Sales" },
                new DataViewModel { EmployeeiD = 4, FullName = "Mahdi", Department = "Support" },
                new DataViewModel { EmployeeiD = 5, FullName = "Sadeq", Department = "Operation" }
        };
           


            return Json(new { EmployeeProfile = dvm });
          




        }
    }
}