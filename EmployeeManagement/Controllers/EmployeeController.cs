using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Helper;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic.CompilerServices;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeHelper employeeHelper = new EmployeeHelper();
        EmployeeModel employeeModel;
        DataSet dataSet;
        List<EmployeeModel> employeeList;

        string message;

        // GET: EmployeeController
        public ActionResult Index()
        {
            employeeModel = new EmployeeModel();
            dataSet = new DataSet();
            employeeModel.flag = "GetAllData_EmployeeInfo";
            dataSet = employeeHelper.Select_Update_Delete_EmployeeDetails(employeeModel,out message);
            employeeList = new List<EmployeeModel>();

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                employeeList.Add(new EmployeeModel
                {
                    EmployeeID = Convert.ToInt32(dataRow["EmployeeID"]),
                    Name = dataRow["Name"].ToString(),
                    Surname = dataRow["Surname"].ToString(),
                    Contact = dataRow["Contact"].ToString(),
                    Qualification = dataRow["Qualification"].ToString(),
                    Department = dataRow["Name1"].ToString(),
                    Address = dataRow["Address"].ToString()
                });
            }
            return View(employeeList);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            GetDataByEmployeeID(id);
            return View(employeeModel);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            GetDepartmentName();            
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( [Bind] EmployeeModel employee)
        {
            try
            {
                employee.Department = Request.Form["DepartmentName"];
                employee.flag = "Insert_EmployeeInfo";
                employeeHelper.Create_EmployeeDetails(employee, out message);
                TempData["message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception en)
            {
                TempData["message"] = en.Message;
            }
            return View();
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            GetDataByEmployeeID(id);
            GetDepartmentName();
            return View(employeeModel);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind] EmployeeModel employee)
        {
            try
            {
                employee.Department = Request.Form["DepartmentName"];
                employee.EmployeeID = id;
                employee.flag = "Update_EmployeeInfo";
                employeeHelper.Select_Update_Delete_EmployeeDetails(employee, out message);
                TempData["message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception en)
            {
                TempData["message"] = en.Message;
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            GetDataByEmployeeID(id);
            return View(employeeModel);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                employeeModel = new EmployeeModel();
                employeeModel.EmployeeID = id;
                employeeModel.flag = "Delete_EmployeeInfo";
                employeeHelper.Select_Update_Delete_EmployeeDetails(employeeModel, out message);
                TempData["message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception en)
            {
                TempData["message"] = en.Message;
            }
            return View();
        }
        public void GetDataByEmployeeID(int id)
        {
            employeeModel = new EmployeeModel();
            employeeModel.EmployeeID = id;
            employeeModel.flag = "GetDataByEmployeeID_EmployeeInfo";
            dataSet = employeeHelper.Select_Update_Delete_EmployeeDetails(employeeModel, out message);

            employeeModel.EmployeeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EmployeeID"]);
            employeeModel.Name = dataSet.Tables[0].Rows[0]["Name"].ToString();
            employeeModel.Surname = dataSet.Tables[0].Rows[0]["Surname"].ToString();
            employeeModel.Contact = dataSet.Tables[0].Rows[0]["Contact"].ToString();
            employeeModel.Qualification = dataSet.Tables[0].Rows[0]["Qualification"].ToString();
            employeeModel.Department = dataSet.Tables[0].Rows[0]["Department"].ToString();
            employeeModel.Address = dataSet.Tables[0].Rows[0]["Address"].ToString();

        }
        public void GetDepartmentName()
        {
            List<SelectListItem> departmentNameList = new List<SelectListItem>();
            dataSet = employeeHelper.Select_DepartmentName();

            foreach(DataRow dataRow in dataSet.Tables[0].Rows)
            {
                departmentNameList.Add(new SelectListItem { Text = dataRow["Name"].ToString(), Value = dataRow["DepartmentID"].ToString() });
            }
            ViewBag.DepartmentName = departmentNameList;

        }
    }
}
