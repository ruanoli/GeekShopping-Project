using GeekShopping.API.Data.ValueObjects;
using GeekShopping.Web.Service.IService;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace GeekShopping.Web.Service
{
    public class ProductService : IProductService
    {
        public const string BasePath = "api/v1/product";
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }


        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel productModel)
        {
            var response = await _client.PostAsJson(BasePath, productModel);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Alguma coisa de errado aconteceu ao chamar a API.");

            return await response.ReadContentAs<ProductModel>();

        }

        public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        {
            var response = await _client.PutAsJson(BasePath, productModel);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Alguma coisa de errado aconteceu ao chamar a API.");

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<bool>();
        }

    }
}
