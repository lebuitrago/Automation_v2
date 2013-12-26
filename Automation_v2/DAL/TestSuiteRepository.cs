using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Automation_v2.Models;
using Automation_v2.DAL;

/// <summary>
/// Extends the IGenericRepository<TestSuite>
/// </summary>

public static class TestSuiteRepository
{
    public static string ext_FullName(
        this IGenericRepository<TestSuite> testsuiteRepository,
        TestSuite testsuite)
    {
        return "Hello Luis!";
    }
}