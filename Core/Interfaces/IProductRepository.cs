using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsListAsync();   
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsListAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesListAsync();     
    }
}