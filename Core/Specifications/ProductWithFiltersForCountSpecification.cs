using Core.Models;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductsSpecParams productsParams)
            : base(x => 
                (!productsParams.BrandId.HasValue || x.ProductBrandId == productsParams.BrandId) && (!productsParams.TypeId.HasValue || x.ProductTypeId == productsParams.TypeId)
            )
        {
        }
    }
}