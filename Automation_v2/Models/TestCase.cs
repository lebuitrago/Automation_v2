using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automation_v2.Models
{
    public class TestCase
    {
        public int TestCaseId { get; set; }
        public int TestSuiteId { get; set; }

        public string Name { get; set; }

        public virtual TestSuite TestSuite { get; set; }
    }
}