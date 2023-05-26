using GeekShopping.API.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.API.Model
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(200, ErrorMessage = "Tamanho máximo de 200 caracteres")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres")]
        public string? Description { get; set; }
        public string? ImageURL { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }

       
    }
}
