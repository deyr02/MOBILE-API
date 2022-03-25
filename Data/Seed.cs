using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mobile_api.Model;

namespace mobile_api.Data
{
    public class Seed
    {
        public static async Task SeedData (DataContext context){

            if(!context.products.Any()){
                 var products  = new  List<Product>{
                new Product {
                    Name = "Apple",
                    Price = 1.50
                },
                 new Product {
                    Name = "Bannna",
                    Price = 2.50
                }
            };

            foreach (Product item in products){
                context.products.Add(item);
            }

            await context.SaveChangesAsync();

            }
           
        }
    }
}