using api_test.Iservices;
using MySql.Data.MySqlClient;
using Dapper;
using test_model;

namespace api_test.Database
{
    public class DatabaseMysql : IProductos, IVenta
    {
        private MySqlConnection connection;
        public DatabaseMysql()
        {
            connection = new MySqlConnection(
                $"server={Environment.GetEnvironmentVariable("database_host")};" +
                $"database={Environment.GetEnvironmentVariable("database_name")};" +
                $"uid={Environment.GetEnvironmentVariable("database_user")};" +
                $"pwd={Environment.GetEnvironmentVariable("database_password")};" +
                $"port={Environment.GetEnvironmentVariable("database_port")}"
                );
        }

        
        

        public Productos CreateProducto(Productos producto)
        {
            using (var cn = connection)
            {
                var sql = "insert into productos(producto_id, producto_nombre, producto_descripcion, create_at, modify_at) VALUES ( @producto_id, @producto_nombre, @producto_descripcion, @create_at, @modify_at);";
                cn.Execute(sql, param: new { producto_id= producto.producto_id, producto_nombre = producto.producto_nombre, producto_descripcion= producto.producto_descripcion, create_at=producto.create_at, modify_at= producto.modify_at });
                return producto;
            }
        }

        public IEnumerable<Tuple<Productos, Inventarios>> GetVentasProductos()
        {
            using (var cn = connection)
            {
                var sqls = "select p.*,i.*\r\nfrom ventas as vn\r\njoin productos p on p.producto_id = vn.producto_id\r\njoin inventarios i on p.producto_id = i.producto_id;";
                var result=  cn.Query<Productos,Inventarios, Tuple<Productos, Inventarios>>(sqls,Tuple.Create,splitOn: "inventario_id");
                return result;
            }
        }

        //to-do agregar funcionalidad para rebajar stock inventario
        public bool CreateVentas(Ventas venta)
        {
            using (var cn = connection)
            {
                var sqls = "insert into ventas(venta_id, cliente_id, empleado_id, producto_id, cantidad, create_at, modify_at) values (@venta_id, @cliente_id, @empleado_id, @producto_id, @cantidad, @create_at, @modify_at);";
                var result =cn.Execute(sqls, param: new { venta.producto_id,venta.venta_id,venta.cliente_id, venta.cantidad, venta.create_at, venta.empleado_id,venta.modify_at});
                return (result>0);
            }
        }

        public bool DeleteProducto(Guid producto_id)
        {
            using (var cn = connection)
            {
                var sql = "delete from productos where producto_id= @producto_id;";
                var result = cn.Execute(sql, param: new { producto_id });
                return (result> 0);
            }
        }

        public Productos? GetProducto(Guid producto_id)
        {
            using (var cn = connection)
            {
                var sql = "select * from productos where producto_id =@producto_id;";
                var result = cn.QueryFirstOrDefault<Productos>(sql, param: new { producto_id });
                return result;
            }
        }

        public IEnumerable<Productos> GetProductos()
        {
            using (var cn = connection)
            {
                var sql = "select * from productos;";
                var result = cn.Query<Productos>(sql);
                return result;
            }
        }

        public Productos UpdateProducto(Productos producto)
        {
            using (var cn = connection)
            {
                var sql = "update productos set modify_at=@modify_at, producto_descripcion =@producto_descripcion, producto_nombre=@producto_nombre where producto_id = @producto_id;";
                var result = cn.Execute(sql, param:new {producto.modify_at, producto.producto_descripcion, producto.producto_nombre, producto.producto_id});
                return producto;
            }
        }
        public IEnumerable<Clientes> GetClientes()
        {
            using (var cn = connection)
            {
                var sql = "select * from clientes;";
                var result = cn.Query<Clientes>(sql);
                return result;
            }
        }
        public IEnumerable<Empleados> GetEmpleados()
        {
            using (var cn = connection)
            {
                var sql = "select * from empleados;";
                var result = cn.Query<Empleados>(sql);
                return result;
            }
        }
    }
}
