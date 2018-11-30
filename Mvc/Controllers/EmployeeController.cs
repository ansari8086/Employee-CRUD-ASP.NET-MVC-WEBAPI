using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;
using System.Net.Http;


namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(MvcApplication));
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            IEnumerable<MvcEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiCleint.GetAsync("employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployeeModel>>().Result;
            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new MvcEmployeeModel());
            else
            {
                Log.Info("Employee edit request for employee id: " + id);
                HttpResponseMessage response = GlobalVariables.webApiCleint.GetAsync("employee/" + id).Result;
                return View(response.Content.ReadAsAsync<MvcEmployeeModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcEmployeeModel emp)
        {
            var response = new HttpResponseMessage();
            if (emp.Id == 0)
            {
                response = GlobalVariables.webApiCleint.PostAsJsonAsync("employee", emp).Result;
                TempData["successmessage"] = "Employee Created";
                Log.Info("Add new employee " + new DateTime());
            }
            else
            {
                response = GlobalVariables.webApiCleint.PutAsJsonAsync("employee/" + emp.Id, emp).Result;
                TempData["successmessage"] = "Employee updated";
                Log.Info("Upldate employee id: " + emp.Id + " time: " + new DateTime());
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiCleint.DeleteAsync("employee/" + id.ToString()).Result;
            TempData["successmessage"] = "Employee deleted";
            Log.Info("Delete employee id: " + id + " time: " + new DateTime());
            return RedirectToAction("Index");
        }
    }
}