using api_test.Database;
using Microsoft.AspNetCore.Mvc;
using test_model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        // GET: api/<EmpleadoController>
        [HttpGet]
        public ActionResult< IEnumerable<Empleados>> Get()
        {
            var db = new DatabaseMysql();
            return Ok(db.GetEmpleados());
        }

    }
}
