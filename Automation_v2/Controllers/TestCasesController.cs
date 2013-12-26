using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automation_v2.Models;
using Automation_v2.DAL;
using System.Data;

namespace Automation_v2.Controllers
{   
    public class TestCasesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ViewResult Index()
        {
            var testcases = unitOfWork.GetRepository<TestCase>().Get(includeProperties: "TestSuite");
            return View(testcases.ToList());
        }

        //
        // GET: /TestCases/Details/5

        public ViewResult Details(int id)
        {
            TestCase testcase = unitOfWork.GetRepository<TestCase>().GetById(id);
            return View(testcase);
        }

        //
        // GET: /TestCases/Create

        public ActionResult Create()
        {
            PopulateTestSuitesDropDownList();

            return View();
        }

        //
        // POST: /TestCases/Create

        [HttpPost]
        public ActionResult Create(TestCase testcase)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<TestCase>().Insert(testcase);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateTestSuitesDropDownList(testcase.TestSuiteId);
            return View(testcase);
        }

        //
        // GET: /TestCases/Edit/5

        public ActionResult Edit(int id)
        {
            TestCase testcase = unitOfWork.GetRepository<TestCase>().GetById(id);
            PopulateTestSuitesDropDownList(testcase.TestSuiteId);

            return View(testcase);
        }

        //
        // POST: /TestCases/Edit/5

        [HttpPost]
        public ActionResult Edit(TestCase testcase)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<TestCase>().Update(testcase);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateTestSuitesDropDownList(testcase.TestSuiteId);
            return View(testcase);
        }

        //
        // GET: /TestCases/Delete/5

        public ActionResult Delete(int id)
        {
            TestCase testcase = unitOfWork.GetRepository<TestCase>().GetById(id);
            return View(testcase);
        }

        //
        // POST: /TestCases/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TestCase testcase = unitOfWork.GetRepository<TestCase>().GetById(id);
            unitOfWork.GetRepository<TestCase>().Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        private void PopulateTestSuitesDropDownList(object selectedTestSuite = null)
        {
            var testSuitesQuery = unitOfWork.GetRepository<TestSuite>().Get(
                orderBy: q => q.OrderBy(ts => ts.Name));

            ViewBag.TestSuiteId = new SelectList(testSuitesQuery, "TestSuiteId", "Name", selectedTestSuite);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}