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

        // GET: api/EmpService/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmpService
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EmpService/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            context.Remove(employee);
            await context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
