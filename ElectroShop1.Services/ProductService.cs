using ElectroShop1.Data;
using ElectroShop1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userID)
        {
            _userId = userID;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Desctription,
                    Manufacturer = model.Manufacturer,
                    Price = model.Price,
                    ModelNumber = model.ModelNumber,
                    Msrp = model.Msrp,                  
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Specific user
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    Name = e.Name,
                                    Price = e.Price,
                                    CreatedUtc = e.CreatedUtc
                                });
                return query.ToArray();
            }
        }

        /* public IEnumerable<ProductListItem> GetAllProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products                        
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    Name = e.Name,
                                    Price = e.Price,
                                    CreatedUtc = e.CreatedUtc
                                });
                return query.ToArray();
            }
        }
        */
        //Get product by Id
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == id && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Name = entity.Name,
                        Description = entity.Description,                         
                        CreatedUtc = entity.CreatedUtc,
                        Manufacturer = entity.Manufacturer,
                        ModelNumber = entity.ModelNumber,
                        Msrp = entity.Msrp,
                        Price = entity.Price,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}
