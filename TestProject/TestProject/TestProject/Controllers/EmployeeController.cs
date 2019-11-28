using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployee()
        {
            var list = EmployeeDb.List;
            return Json(list);
        }
        public IActionResult AddEditPopup()
        {
            //var model = new EmployeeViewModel();
            return PartialView("_AddEdit");
        }
        public IActionResult Add()
        {
            var model = new EmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.ErrorMessage = "Enter all the required fields data.";
                return View(model);
            }

          
            model.SuccessMessage = "All valid.";
            var emp = new Employee();
            emp.Id = new Random().Next(1, 100000);
            emp.Name = model.Name;
            emp.Address = model.Address;
            emp.Phone = model.Phone;
            EmployeeDb.List.Add(emp);

            return Ok();
        }
        public IActionResult Edit(int id )
        {
            var empid = EmployeeDb.List.SingleOrDefault(s => s.Id == id);
            return View(empid);
        }

        [HttpPost]
        public IActionResult Edit( EmployeeEditViewModel model)
        {            
            
            var m = EmployeeDb.List.SingleOrDefault(s => s.Id == model.Id);
            m.Name = model.Name;
            m.Phone = model.Phone;
            m.Address = model.Address;
            return Ok();
        }

       [HttpPost]
        public JsonResult Delete(int id)
        {

           var m = EmployeeDb.List.SingleOrDefault(s => s.Id == id);
            EmployeeDb.List.Remove(m);
            return Json(EmployeeDb.List);

        }
    }
}
