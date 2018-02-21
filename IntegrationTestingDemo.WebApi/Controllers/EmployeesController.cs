using IntegrationTestingDemo.App;
using IntegrationTestingDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntegrationTestingDemo.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly ILogger _logger;
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService, ILogger logger)
        {
            if (employeeService == null)
                throw new ArgumentNullException(nameof(employeeService));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
            _employeeService = employeeService;
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var result = _employeeService.GetEmployees();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
