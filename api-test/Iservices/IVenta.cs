using test_model;

namespace api_test.Iservices
{
    public interface IVenta
    {
        public bool CreateVentas(Ventas venta);
        public IEnumerable<Tuple<Productos, Inventarios>> GetVentasProductos();
    }
}
