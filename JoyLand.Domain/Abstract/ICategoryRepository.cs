using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyLand.Domain.Entities;

namespace JoyLand.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categorys { get; }
        void SaveCategory(Category category);
        Category DeleteCategory(int Id);
    }
}
