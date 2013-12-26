using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automation_v2.Models
{
    [Route("/listTestSuites", "GET")]
    [Route("/listTestSuites/{TestSuiteId}", "GET")]
    public class TestSuite
    {
        public int TestSuiteId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<TestCase> TestCases { get; set; }
    }
}