using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entities;

namespace Store.Service.Services.ProductService.Dto
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDetailsDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDetailsDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["BaseUrl"]}/{source.PictureUrl}";
            return null;
            
        }
    }
}
