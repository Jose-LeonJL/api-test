using api_test.Database;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using test_model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        

        // POST api/<VentasController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Ventas value)
        {
            var db = new DatabaseMysql();
            return Ok(db.CreateVentas(value));
        }

        // PUT api/<VentasController>/5
        [HttpGet]
        public ActionResult<IEnumerable<Tuple<Productos, Inventarios>>> get()
        {
            var db = new DatabaseMysql();
            return Ok(db.GetVentasProductos());
        }

       
    }
}
