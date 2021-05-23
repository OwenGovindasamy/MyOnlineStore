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
                        Description = "Razor blade14",
                        Price = 5000,
                        ImageUrl = "https://assets.razerzone.com/eeimages/products/26727/rzrblade14-04__store_gallery.png"
                    },
                    new StoreItems
                    {
                        Description = "Razer ouroboros",
                        Price = 1000,
                        ImageUrl = "https://assets.razerzone.com/eeimages/products/752/razer-ouroboros-gallery-3__store_gallery.png"
                    },
                    new StoreItems
                    {
                        Description = "Razer blackshark",
                        Price = 1200,
                        ImageUrl = "https://assets.razerzone.com/eeimages/products/5890/razer-blackshark-gallery-4__store_gallery.png"
                    },
                };

                await context.StoreItems.AddRangeAsync(item);
                await context.SaveChangesAsync();
            }
        }

    }
}
