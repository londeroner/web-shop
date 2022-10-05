using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                    await context.ProductBrands.AddRangeAsync(Deserialize<ProductBrand>("../Infrastructure/Data/SeedData/brands.json"));
                await context.SaveChangesAsync();
                
                if (!context.ProductTypes.Any())
                    await context.ProductTypes.AddRangeAsync(Deserialize<ProductType>("../Infrastructure/Data/SeedData/types.json"));
                await context.SaveChangesAsync();

                if (!context.Products.Any())
                {
                    foreach (var item in Deserialize<Product>("../Infrastructure/Data/SeedData/products.json"))
                    {
                        context.Products.Add(item);
                        context.SaveChanges();
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    foreach (var item in Deserialize<DeliveryMethod>("../Infrastructure/Data/SeedData/delivery.json"))
                    {
                        context.DeliveryMethods.Add(item);
                        context.SaveChanges();
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e.Message);
            }
        }

        private static List<T> Deserialize<T>(string jsonPath)
        {
            var data = File.ReadAllText(jsonPath);
            var entities = JsonSerializer.Deserialize<List<T>>(data);
            return entities;
        }
    }
}