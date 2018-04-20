using EmployeeDAL;
using EmployeeDAL.Models;
using EmployeeDAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace MVCTestingApp.Controllers
{
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class EmployeeController : Controller
    {

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception exception = filterContext.Exception;
        //    //Logging the Exception
        //    filterContext.ExceptionHandled = true;


        //    var Result = this.View("Error", new HandleErrorInfo(exception,
        //        filterContext.RouteData.Values["controller"].ToString(),
        //        filterContext.RouteData.Values["action"].ToString()));

        //    filterContext.Result = Result;
        //}

        // GET: Employee
        public IEmployeeDAL _dal;
        public EmployeeController(IEmployeeDAL dal)
        {
            _dal = dal;
        }
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee mdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _dal.AddEmployee(mdl);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("","Employee Model is not valid");
                    return View();
                }

            }
            catch (Exception e)
            {
                //Content(HttpStatusCode.BadRequest, e.ToString());
                return View("Error", new HandleErrorInfo(e, "Employee", "Add"));
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee mdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _dal.EditEmployee(mdl);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Employee Model is not valid");
                    return View();
                }

            }
            catch (Exception e)
            {
                //Content(HttpStatusCode.BadRequest, e.ToString());
                return View("Error", new HandleErrorInfo(e, "Employee", "Edit"));
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    var result = _dal.DeleteEmployee(id);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Employee Model does not exist");
                    return View();
                }

            }
            catch (Exception e)
            {
                //Content(HttpStatusCode.BadRequest, e.ToString());
                return View("Error", new HandleErrorInfo(e, "Employee", "Delete"));
            }
        }

        [HttpPost]
        public ActionResult GetEmployees()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _dal.GetEmployees();
                    return View("Index", result);
                }
                else
                {
                    ModelState.AddModelError("", "Employee Model is not valid");
                    return View();
                }

            }
            catch (Exception e)
            {
                //Content(HttpStatusCode.BadRequest, e.ToString());
                return View("Error", new HandleErrorInfo(e, "Employee", "Delete"));
            }
        }
    }
}