using GeekShopping.API.Data.ValueObjects;

namespace GeekShopping.Web.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(long id);
        Task<ProductModel> CreateProduct(ProductModel productModel);
        Task<ProductModel> UpdateProduct(ProductModel productModel);
        Task<bool> DeleteProductById(long id);
    }
}
