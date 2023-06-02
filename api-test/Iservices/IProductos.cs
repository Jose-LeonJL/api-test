using test_model;

namespace api_test.Iservices
{
    public interface IProductos
    {
        public IEnumerable<Productos> GetProductos();
        public Productos? GetProducto(Guid producto_id);
        public Productos UpdateProducto(Productos producto);
        public Productos CreateProducto(Productos producto);
        public bool DeleteProducto(Guid producto_id);

    }
}
