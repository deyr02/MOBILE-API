using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mobile_api.Model;

namespace mobile_api.Data
{
    public class Seed
    {
        public static async Task SeedData (DataContext context){

            if(!context.ProductCategories.Any()){
                var categories = new List<ProductCategory>{
                    new ProductCategory {Name= "Fruit"},
                    new ProductCategory{Name = "Vege"}
                };

                foreach(ProductCategory  item in  categories){
                    context.ProductCategories.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if(!context.products.Any()){
                 var products  = new  List<Product>{
                new Product {
                    Name = "Apple",
                    Price = 1.50,
                    ProductCategoryID = 1
                    
                },
                 new Product {
                    Name = "Bannna",
                    Price = 2.50,
                    ProductCategoryID = 1

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