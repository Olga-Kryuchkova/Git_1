using JoyLand.Domain.Abstract;
using JoyLand.Domain.Concrete;
using JoyLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyLand.Domain.Concrete
{

    public class EFCategoryRepository : ICategoryRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Category> Categorys
        {
            get { return context.Categorys; }
        }

        public void SaveCategory(Category category)
        {
            if (category.Id == 0)
                context.Categorys.Add(category);
            else
            {
                Category dbEntry = context.Categorys.Find(category.Id);
                if (dbEntry != null)
                {
                    dbEntry.CategoryName = category.CategoryName;
                }
            }
            context.SaveChanges();
        }

        public Category DeleteCategory(int Id)
        {
            Category dbEntry = context.Categorys.Find(Id);
            if (dbEntry != null)
            {
                context.Categorys.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

