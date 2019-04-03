using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMvc.Models;

namespace CrudMvc.Controllers
{
    public class HomeController : Controller
    {
        DataAccessLayer.SQLDB dbl = new DataAccessLayer.SQLDB();

        public ActionResult ShowData()
        {
            DataSet ds = dbl.SelectAllRecord();
            ViewBag.emp= ds.Tables[0];
            return View();
        }

        public ActionResult AddRecord()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult AddRecord(FormCollection fc)
        {
            Employee emp = new Employee();
            emp.Name = fc["Name"];
            emp.Address = fc["Address"];
            emp.City = fc["City"];
            emp.PinCode = fc["PinCode"];
            emp.Designation = fc["Designation"];
            dbl.AddRecord(emp);
            TempData["msg"] = "Data inserted !";
            return View();
        }

        public ActionResult UpdateRecord(int Id)
        {
            DataSet ds = dbl.SelectRecordById(Id);
            ViewBag.tdfxgfdcg = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult UpdateRecord(int Id,FormCollection fc)
        {
            Employee emp = new Employee();
            emp.EmpId = Id;
            emp.Name = fc["Name"];
            emp.Address = fc["Address"];
            emp.City = fc["City"];
            emp.PinCode = fc["PinCode"];
            emp.Designation = fc["Designation"];
            dbl.UpdateRecord(emp);
            TempData["msg"] = "Data Updated !";
            
            return RedirectToAction("ShowData");
        }

        public ActionResult DeleteRecord(int Id)
        {
            dbl.DeleteRecord(Id);
            TempData["msg"] = "Data Deleted";
            return RedirectToAction("ShowData");
        }


    }
}