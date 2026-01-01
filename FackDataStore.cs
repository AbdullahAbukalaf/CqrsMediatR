namespace CqrsMediatR
{
    public class FackDataStore
    {
        private static List<Product> _products;

        public FackDataStore()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" },
                new Product { Id = 3, Name = "Product 3" },
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }



        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);


        public async Task<Product> GetProductById(int id) =>
            await Task.FromResult(_products.Single(p => p.Id == id));

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = _products.Single(p => p.Id == product.Id);
            existingProduct.Name = product.Name;
            await Task.CompletedTask;
        }

        public async Task DeleteProduct(int id)
        {
            var product = _products.Single(p => p.Id == id);
            _products.Remove(product);
            await Task.CompletedTask;
        }


        public async Task EventOccured(Product product, string evt)
        {
            // this is just a simple example, but the key take away here is that we can fire an event 
            // and have it handled many times
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
