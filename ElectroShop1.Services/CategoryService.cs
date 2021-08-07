using ElectroShop1.Data;
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

                ctx.CarCategories.Add(entity);


                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CatListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                      ctx

                      .CarCategories
                      .Select(e =>
                      new CatListItem
                      {
                          CategoryID = e.CategoryID,
                          CategoryName = e.CategoryName

                      });

                return query.ToArray();

            }
        }


        public bool UpdateCategory(EditCategory model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx

                     .CarCategories

                     .Single(e => e.CategoryID == e.CategoryID);

                entity.CategoryName = model.CategoryName;
                entity.Description = model.Description;
                entity.AdminM = model.AdminM;
                entity.Modified = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public DetailCategory GetCategoryById(int categoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx

                      .CarCategories

                      .Single(e => e.CategoryID == categoryID);
                return
                      new DetailCategory
                      {
                          CategoryID = entity.CategoryID,
                          CategoryName = entity.CategoryName,
                          Description = entity.Description,
                          AdminC = entity.AdminC,
                          AdminM = entity.AdminM,
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

                      .CarCategories
                      .Single(e => e.CategoryID == categoryID);

                ctx.CarCategories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
