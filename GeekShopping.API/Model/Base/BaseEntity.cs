using System.ComponentModel.DataAnnotations;

namespace GeekShopping.API.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
