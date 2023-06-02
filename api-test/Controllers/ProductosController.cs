using Microsoft.AspNetCore.Mvc;
using test_model;
using api_test.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // GET: api/<ProductosController>
        [HttpGet]
        public ActionResult< IEnumerable<Productos>> Get()
        {
            var db = new DatabaseMysql();
            return Ok(db.GetProductos());
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public ActionResult<Productos?> Get(Guid id)
        {
            var db = new DatabaseMysql();
            return Ok( db.GetProducto(id));
        }

        // POST api/<ProductosController>
        [HttpPost]
        public ActionResult< Productos> Post([FromBody] Productos value)
        {
            var db = new DatabaseMysql();
            return Ok(db.CreateProducto(value));
        }

        // PUT api/<ProductosController>/5
        [HttpPut]
        public ActionResult<Productos> Put([FromBody] Productos value)
        {
            var db = new DatabaseMysql();
            return Ok(db.UpdateProducto(value));
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(Guid id)
        {
            var db = new DatabaseMysql();
            return Ok(db.DeleteProducto(id));
        }
    }
}
