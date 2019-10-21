using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DevNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DevNet.Controllers
{
    public class EmployeeController : Controller
    {

        readonly EmployeeContext context;
        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public IActionResult GetJson()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetempJson(Employee employee)
        {
            var result = JsonConvert.SerializeObject(employee);
            return Json(result);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployeeList(Employee employee)
        {
            if(employee == null)
            {
                return NotFound();
            }
            return View(context.Employees.ToList());
        }


        #region --DETAILS   
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Employee employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        #endregion


        #region --CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (employee.Id == 0)
            {
                await context.AddAsync(employee);
                await context.SaveChangesAsync();

                return RedirectToAction("GetEmployeeList", "Employee");
            }
            else
            {
                return View(employee);
            }
        }
        #endregion


        #region --EDIIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await context.Employees.SingleOrDefaultAsync(x => x.Id == id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            if (!context.Employees.Any(x => x.Id == employee.Id))
            {
                return NotFound();
            }

            context.Update(employee);
            await context.SaveChangesAsync();
            return  RedirectToAction("GetEmployeeList", "Employee");
        }
        #endregion


        #region --DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            if (!context.Employees.Any(x => x.Id == employee.Id))
            {
                return NotFound();
            }
            employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            context.Remove(employee);
            await context.SaveChangesAsync();
            return RedirectToAction("GetEmployeeList", "Employee");
        }
        #endregion
    }
}