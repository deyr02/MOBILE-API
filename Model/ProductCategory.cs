using System.Collections.Generic;

namespace mobile_api.Model
{
    public class ProductCategory
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public ICollection<Product> Products {get; set;}
    }
}