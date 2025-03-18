using test2.Model;

namespace test2.Data
{
    class Context
    {
        private static List<Product> _product = new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 999.99, InStock = true },
                new Product { Id = 2, Name = "Chair", Category = "Furniture", Price = 49.99, InStock = false },
                new Product { Id = 3, Name = "Notebook", Category = "Stationery", Price = 2.50, InStock = true },
            };

        public List<Product> Products { set { _product = value; } get { return _product; } }
    }
}
