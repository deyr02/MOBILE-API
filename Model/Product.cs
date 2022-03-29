namespace mobile_api.Model
{
    public class Product
    {
        public int ID{get; set;}
        public string Name {get; set;}
        public double Price {get; set;}
        public int ProductCategoryID{get; set;}
        public ProductCategory ProductCategory {get; set;}
    }
}