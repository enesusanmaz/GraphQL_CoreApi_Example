using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId);
        Task<Product> GetProductAsync(int id);
    }
}
