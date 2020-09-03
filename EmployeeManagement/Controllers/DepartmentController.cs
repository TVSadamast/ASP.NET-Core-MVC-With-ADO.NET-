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

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentHelper departmentHelper = new DepartmentHelper();
        DepartmentModel departmentModel;
        DataSet dataSet;
        List<DepartmentModel> departmentList;

        string message;

        // GET: DepartmentController
        public ActionResult Index()
        {
            departmentModel = new DepartmentModel();
            dataSet = new DataSet();
            departmentModel.flag = "GetAllData_DepartmentInfo";
            dataSet = departmentHelper.Select_Update_Delete_DepartmentDetails(departmentModel, out message);
            departmentList = new List<DepartmentModel>();

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                departmentList.Add(new DepartmentModel
                {
                    DepartmentID = Convert.ToInt32(dataRow["DepartmentID"]),
                    Name = dataRow["Name"].ToString(),
                    Description = dataRow["Description"].ToString()
                });
            }
            return View(departmentList);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            GetDataByDepartmentID(id);
            return View(departmentModel);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentModel department)
        {
            try
            {
                department.flag = "Insert_DepartmentInfo";
                departmentHelper.Create_DepartmentDetails(department, out message);
                TempData["message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception en)
            {
                TempData["message"] = en.Message;
            }
            return View();
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            GetDataByDepartmentID(id);
            return View(departmentModel);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentModel department)
        {
            try
            {
                department.DepartmentID = id;
                department.flag = "Update_DepartmentInfo";
                departmentHelper.Select_Update_Delete_DepartmentDetails(department, out message);
                TempData["message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception en)
            {
                TempData["message"] = en.Message;
            }
            return View();
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            GetDataByDepartmentID(id);
            return View(departmentModel);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                departmentModel = new DepartmentModel();
                departmentModel.DepartmentID = id;
                departmentModel.flag = "Delete_DepartmentInfo";
                departmentHelper.Select_Update_Delete_DepartmentDetails(departmentModel, out message);
                TempData["message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception en)
            {
                TempData["message"] = en.Message;
            }
            return View();
        }

        public void GetDataByDepartmentID(int id)
        {
            departmentModel = new DepartmentModel();
            departmentModel.DepartmentID = id;
            departmentModel.flag = "GetDataByDepartmentID_DepartmentInfo";
            dataSet = departmentHelper.Select_Update_Delete_DepartmentDetails(departmentModel, out message);

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                departmentModel.DepartmentID = Convert.ToInt32(dataRow["DepartmentID"]);
                departmentModel.Name = dataRow["Name"].ToString();
                departmentModel.Description = dataRow["Description"].ToString();
            }
        }        
    }
}
