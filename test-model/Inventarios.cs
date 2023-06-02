using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_model
{
    public class Inventarios
    {
        public Guid inventario_id { get;set; }
        public Guid producto_id { get;set; }
        public int inventario_stock { get;set; }
        public DateTime create_at { get; set; }
        public DateTime modify_at { get; set; }
    }
}
