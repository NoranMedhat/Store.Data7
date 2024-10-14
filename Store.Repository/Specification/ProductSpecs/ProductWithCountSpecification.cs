using Store.Data.Entities;

namespace Store.Repository.Specification.ProductSpecs
{
    public class ProductWithCountSpecification : BaseSpecification<Product>
    {
        public ProductWithCountSpecification(ProductSpecification specs)
           : base(product => 
           (!specs.BrandId.HasValue || product.BrandId == specs.BrandId.Value) &&
           (!specs.TypeId.HasValue || product.TypeId == specs.TypeId.Value)&&
            (string.IsNullOrEmpty(specs.search) || product.Name.Trim().ToLower().Contains(specs.search))

           )


        { }
           
    }
}
