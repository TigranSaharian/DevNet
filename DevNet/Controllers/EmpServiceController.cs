using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpServiceController : ControllerBase
    {
        readonly EmployeeContext context;
        public EmpServiceController(EmployeeContext context)
        {
            this.context = context;
        }

        // GET: api/EmpService
        [Route("resource")]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return  context.Employees.ToList();
        }

    }
}
