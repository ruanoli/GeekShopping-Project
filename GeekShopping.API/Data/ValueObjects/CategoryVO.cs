using GeekShopping.API.Model;

namespace GeekShopping.API.Data.ValueObjects
{
    public class CategoryVO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsAtivo { get; set; }
        public IList<string>? Products { get; set; }
    }
}
