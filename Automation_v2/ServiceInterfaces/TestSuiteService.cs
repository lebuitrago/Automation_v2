using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Automation_v2.DAL;
using Funq;
using Automation_v2.Models;
using Automation_v2.ServiceModels;


namespace Automation_v2.ServiceInterfaces
{
    public class TestSuiteService : Service
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET /api/listTestSuites
        public TestSuiteResponse Get(TestSuite testsuite)
        {
            if (testsuite.TestSuiteId != default(int))
            {
                var newTestSuite = unitOfWork.GetRepository<TestSuite>().GetById(testsuite.TestSuiteId);

                // .ToResponse() is a small helper/extension method to map a single message to a TestSuiteResponse
                return newTestSuite.ToResponse();
            }

            var testsuites = unitOfWork.GetRepository<TestSuite>().Get();

            return new TestSuiteResponse { TestSuites = new List<TestSuite>(testsuites) };
        }
    }
}