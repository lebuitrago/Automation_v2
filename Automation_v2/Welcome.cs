using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Automation_v2.DAL;
using Automation_v2.Models;

namespace Automation_v2
{
    [Route("/welcome")]
    [Route("/welcome/{Name*}")]
    public class Welcome
    {
        public string Name { get; set; }
    }

    public class WelcomeResponse
    {
        public string Message { get; set; }
    }

    public class WelcomeService : Service
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public WelcomeResponse Any(Welcome request)
        {
            //return new WelcomeResponse { Message = string.Format("Hello {0}", request.Name.Replace("/", " ")) };

            var testcases = unitOfWork.GetRepository<TestCase>().Get(includeProperties: "TestSuite");

            return new WelcomeResponse { Message = string.Format("Hello {0}", request.Name) };
        }

    }
}