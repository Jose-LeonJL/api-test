using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_model
{
    public class Clientes
    {
        public Guid cliente_id { get; set; }
        public string cliente_nombre { get; set; }
        public DateTime create_at { get; set; }
        public DateTime modify_at { get; set; }
    }
}
