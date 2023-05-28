using AutoMapper;
using GeekShopping.API.Data.ValueObjects;
using GeekShopping.API.Model;

namespace GeekShopping.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mapperConfig;
        }
    }
}
