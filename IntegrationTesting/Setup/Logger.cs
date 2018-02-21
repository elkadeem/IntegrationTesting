using IntegrationTestingDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting
{
    public class Logger : ILogger
    {
        public void Log(Exception ex)
        {
            NUnit.Framework.TestContext.WriteLine(ex.ToString());
        }

        public void Log(string message)
        {
            NUnit.Framework.TestContext.WriteLine(message);
        }
    }
}
