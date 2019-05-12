using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> CategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
    }
}
