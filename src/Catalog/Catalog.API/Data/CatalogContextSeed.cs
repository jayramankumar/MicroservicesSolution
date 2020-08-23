using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> products)
        {
            bool existProduct = products.Find(r => true).Any();
            if (!existProduct)
            {
                products.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Samsung 12",
                    Summary = "the best",
                    Description = "description",
                    Price = 423,
                    Category = "Phone"
                },
                new Product()
                {
                    Name = "Asus Laptop",
                    Category = "Computers",
                    Summary = "Summary",
                    Description = "Description",
                    ImageFile ="ImageFile",
                    Price = 543
                }
            };
        }
    }
}
