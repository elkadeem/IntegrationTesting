using IntegrationTestingDemo.App;
using IntegrationTestingDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegrationTestingDemo.MVCWebApp.Controllers
{
    public class EmploeesController : Controller
    {
        private readonly ILogger _logger;
        private readonly EmployeeService _employeeService;
        public EmploeesController(EmployeeService employeeService, ILogger logger)
        {
            if (employeeService == null)
                throw new ArgumentNullException(nameof(employeeService));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            _logger = logger;
            _employeeService = employeeService;
        }
        
        public ActionResult Index()
        {
            var employees = _employeeService.GetEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.AddEmployee(employeeModel);
                    TempData["Message"] = $"Employee {employeeModel.EmployeeName} is added" ;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                ViewBag.ErrorMessage = "An Error Occured."; 
            }

            return View(employeeModel);
        }

    }
}