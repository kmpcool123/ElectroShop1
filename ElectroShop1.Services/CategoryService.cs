using ElectroShop1.Data;
using ElectroShop1.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Services
{
    public class CategoryService
    {
        private Guid userId;

        public CategoryService(Guid userId)
        {
            this.userId = userId;
        }
        private ApplicationDbContext _db = new ApplicationDbContext();

        List<Category> _category = new List<Category>();

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                  new Category()
                  {
                      CategoryName = model.CategoryName,
                      Description = model.Description,                      
                  };

            using (var ctx = new ApplicationDbContext())
            {
                _category.Add(entity);

                ctx.Categories.Add(entity);


                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                      ctx

                      .Categories
                      .Select(e =>
                      new CategoryListItem
                      {
                          CategoryId = e.CategoryId,
                          CategoryName = e.CategoryName

                      });

                return query.ToArray();

            }
        }


        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx

                     .Categories

                     .Single(e => e.CategoryId == e.CategoryId);

                entity.CategoryName = model.CategoryName;
                entity.Description = model.Description;               
                entity.Modified = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public CategoryDetail GetCategoryById(int categoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx

                      .Categories

                      .Single(e => e.CategoryId == categoryID);
                return
                      new CategoryDetail
                      {
                          CategoryId = entity.CategoryId,
                          CategoryName = entity.CategoryName,
                          Description = entity.Description,                          
                          CreatedUtc = DateTimeOffset.UtcNow,
                          ModifiedUtc = DateTimeOffset.UtcNow

                      };
            }
        }


        public bool DeleteCategoryById(int categoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx

                      .Categories
                      .Single(e => e.CategoryId == categoryID);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
