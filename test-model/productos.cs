using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_model
{
    public class Productos
    {
        public Guid producto_id {  get; set; }
        public string producto_nombre { get; set; }
        public string producto_descripcion { get; set; }
        public DateTime create_at { get; set; }
        public DateTime modify_at { get; set; }
    }
}
