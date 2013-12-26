using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Automation_v2.Models;

namespace Automation_v2.ServiceModels
{
    internal static class TestSuiteExtensions
    {
        public static TestSuiteResponse ToResponse(this TestSuite testsuite)
        {
            return new TestSuiteResponse { 
                TestSuites = new List<TestSuite>( new[] { testsuite })
            };
        }
    }
}