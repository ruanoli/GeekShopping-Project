using GeekShopping.API.Model.Base;

namespace GeekShopping.API.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool IsAtivo { get; set; }
        public IList<Product> Products { get; set; }    
    }
}
