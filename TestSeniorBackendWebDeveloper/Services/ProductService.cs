using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSeniorBackendWebDeveloper.Database;
using TestSeniorBackendWebDeveloper.Models;

namespace TestSeniorBackendWebDeveloper.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IProductStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public async Task<List<ProductViewModel>> Get()
        {
            var products = await _products.Find(Product => true).ToListAsync().ConfigureAwait(false);

            return (from x in products
                    select new ProductViewModel
                    {
                        Id = x.Id,
                        ProductBrand = x.ProductBrand,
                        ProductCategory = x.ProductCategory,
                        ProductDescription = x.ProductDescription,
                        ProductName = x.ProductName,
                        ProductPrice = x.ProductPrice,
                        ProductTag = x.ProductTag,
                        ProductType = x.ProductType,
                        ProductWeight = x.ProductWeight
                    }).ToList();
        }

        public async Task<ProductViewModel> Get(Guid id)
        {
            var product = await _products.Find(Product => true).FirstOrDefaultAsync().ConfigureAwait(false);

            return new ProductViewModel()
            {
                Id = product.Id,
                ProductBrand = product.ProductBrand,
                ProductCategory = product.ProductCategory,
                ProductDescription = product.ProductDescription,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductTag = product.ProductTag,
                ProductType = product.ProductType,
                ProductWeight = product.ProductWeight
            };
        }

        public async Task<Guid> Create(ProductAddUpdateModel model)
        {
            Guid productId = Guid.NewGuid();

            var product = new Product()
            {
                Id = productId,
                ProductBrand = model.ProductBrand,
                ProductCategory = model.ProductCategory,
                ProductDescription = model.ProductDescription,
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                ProductTag = model.ProductTag,
                ProductType = model.ProductType,
                ProductWeight = model.ProductWeight
            };

            await _products.InsertOneAsync(product);

            return productId;
        }

        public async Task Update(Guid id, ProductAddUpdateModel model)
        {
            var product = new Product()
            {
                Id = id,
                ProductBrand = model.ProductBrand,
                ProductCategory = model.ProductCategory,
                ProductDescription = model.ProductDescription,
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                ProductTag = model.ProductTag,
                ProductType = model.ProductType,
                ProductWeight = model.ProductWeight
            };

            await _products.ReplaceOneAsync(x => x.Id == id, product);
        }


        public async Task Remove(Guid id) =>
            await _products.DeleteOneAsync(x => x.Id == id);
    }
}
