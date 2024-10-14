using Microsoft.Extensions.Logging;
using Store.Data.Contexts;
using Store.Data.Entities;
using System.Text.Json;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context,ILoggerFactory loggerFactory)
        {
            try 
            {
                if (context.ProductBrands!=null &&!context.ProductBrands.Any()) 
                {
                    var brandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json");
                    var brands =JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if (brands is not null)
                        await context.ProductBrands.AddRangeAsync(brands);


                }
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Store.Repository/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if (types is not null)
                        await context.ProductTypes.AddRangeAsync(types);


                }
                if (context.products != null && !context.products.Any())
                {
                    var productsData = File.ReadAllText("../Store.Repository/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products is not null)
                        await context.products.AddRangeAsync(products);


                }
                if (context.DeliveryMethod != null && !context.DeliveryMethod.Any())
                {
                    var deliveryMethodData = File.ReadAllText("../Store.Repository/SeedData/delivery.json");
                    var deliveryMethod = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodData);
                    if (deliveryMethod is not null)
                        await context.DeliveryMethod.AddRangeAsync(deliveryMethod);


                }
                await context.SaveChangesAsync();

            }
            catch (Exception ex) 
            {
                var logger =loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
