using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Employee.Models;
using System.Data;

namespace Demo_Employee.Controllers
{
    public class HomeController : Controller
    {
        dbcs dbop = new dbcs();

        string msg;
        public ActionResult Index()
        {
            Employee em = new Employee();
            em.flag = "get";
            DataSet ds = dbop.Empget(em, out msg);
            List<Employee> list = new List<Employee>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Em_name = dr["Emp_name"].ToString(),
                    City=dr["City"].ToString(),
                    STATE=dr["State"].ToString(),
                    Country=dr["cCountry"].ToString(),
                    Department=dr["Department"].ToString()
                });

            }

            return View(list);
        }

        
        [HttpPost]

        public IActionResult Create([Bind] Employee em)
        {
            try
            {
                em.flag = "insert";
                dbop.Empdml(em, out msg);
                TempData["msg"] = msg;
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return (IActionResult)RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Employee em = new Employee();
            em.Sr_no = id;
            em.flag = "getid";
            DataSet ds = dbop.Empget(em, out msg);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                em.Sr_no = Convert.ToInt32(dr["Sr_no"]);
                em.Em_name = dr["Em_name"].ToString();
                em.City = dr["City"].ToString();
                em.STATE = dr["Country"].ToString();
                em.Department = dr["Department"].ToString();
            }
            return (IActionResult)View(em);
        }

        [HttpPost]

        public IActionResult Edit(int id,[Bind] Employee em)
        {
            try
            {
                em.Sr_no = id;
                em.flag = "update";
                dbop.Empdml(em, out msg);
                TempData["msg"] = msg;
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return (IActionResult)RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id,[Bind] Employee em)
        {
            try
            {
                em.Sr_no = id;
                em.flag = "Update";
                dbop.Empdml(em, out msg);
                TempData["msg"] = msg;

            }catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return (IActionResult)RedirectToAction("Index");
        }
        
    }

    
}
