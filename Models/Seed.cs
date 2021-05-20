using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineStore.Models
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (!context.StoreItems.Any())
            {
                var item = new List<StoreItems>
                {
                    new StoreItems
                    {
                        Description = "Alienware Laptop",
                        Price = 5000
                    },
                };

                await context.StoreItems.AddRangeAsync(item);
                await context.SaveChangesAsync();
            }
        }

    }
}
