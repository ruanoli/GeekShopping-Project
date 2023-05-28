using GeekShopping.API.Model;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.API.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public Category? Category { get; set; }
    }
}
