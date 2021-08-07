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
                    CategoryId = model.Category,
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
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    Name = e.Name,
                                    Price = e.Price,
                                    CreatedUtc = e.CreatedUtc
                                });
                return query.ToList();
            }
        }

        //possible use for getting products without authorization
        /*public IEnumerable<ProductListItem> GetAllProducts()
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
        }*/
        
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

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == model.ProductId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Price = model.Price;                                             
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.OwnerId == _userId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
