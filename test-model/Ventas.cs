using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_model
{
    public class Ventas
    {
        public Guid venta_id { get; set; }
        public Guid cliente_id { get; set; }
        public Guid empleado_id { get; set; }
        public Guid producto_id { get; set; }
        public int cantidad { get; set; }
        public DateTime create_at { get; set; }
        public DateTime modify_at { get; set; }
    }
}
