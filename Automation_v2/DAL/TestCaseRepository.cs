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
/// Extends the IGenericRepository<TestCase>
/// </summary>

public static class TestCaseRepository
{
    public static string FullName(
        this IGenericRepository<TestCase> testcaseRepository,
        TestCase testcase)
    {
        return "Hello Luis!";
    }
}