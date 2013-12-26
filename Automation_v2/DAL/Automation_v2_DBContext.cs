using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Automation_v2.Models;

namespace Automation_v2.DAL
{
    public class Automation_v2_DBContext : DbContext
    {
        public DbSet<TestSuite> TestSuites { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
    }
}