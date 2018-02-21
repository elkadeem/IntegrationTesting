using IntegrationTestingDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationTestingDemo.WebApi
{
    public class Logger : ILogger
    {
        public Logger()
        {
           
        }

        public void Log(Exception ex)
        {
            
            System.Diagnostics.EventLog.WriteEntry("IntegrationTestDemo", ex.ToString());
        }

        public void Log(string message)
        {
            System.Diagnostics.EventLog.WriteEntry("IntegrationTestDemo", message);
        }
    }
}