using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automation_v2.Models;
using Automation_v2.DAL;

namespace Automation_v2.Controllers
{   
    public class TestSuitesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /TestSuites/

        public ViewResult Index()
        {
            var testsuites = unitOfWork.GetRepository<TestSuite>().Get();
            return View(testsuites.ToList());
        }

        //
        // GET: /TestSuites/Details/5

        public ViewResult Details(int id)
        {
            TestSuite testsuite = unitOfWork.GetRepository<TestSuite>().GetById(id);

            ViewBag.TestCasesAssigned = unitOfWork.GetRepository<TestCase>().Get(
                filter: tc => tc.TestSuiteId == id);

            return View(testsuite);
        }

        //
        // GET: /TestSuites/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TestSuites/Create

        [HttpPost]
        public ActionResult Create(TestSuite testsuite)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<TestSuite>().Insert(testsuite);
                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /TestSuites/Edit/5

        public ActionResult Edit(int id)
        {
            TestSuite testsuite = unitOfWork.GetRepository<TestSuite>().GetById(id);
            return View(testsuite);
        }

        //
        // POST: /TestSuites/Edit/5

        [HttpPost]
        public ActionResult Edit(TestSuite testsuite)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<TestSuite>().Update(testsuite);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /TestSuites/Delete/5

        public ActionResult Delete(int id)
        {
            TestSuite testsuite = unitOfWork.GetRepository<TestSuite>().GetById(id);
            return View(testsuite);
        }

        //
        // POST: /TestSuites/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.GetRepository<TestSuite>().Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

