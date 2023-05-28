using GeekShopping.API.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.API.Model
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string? Name { get; set; }
        public bool IsAtivo { get; set; }
        public IList<Product>? Products { get; set; }    
    }
}
