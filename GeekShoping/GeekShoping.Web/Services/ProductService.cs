using GeekShoping.Web.Models;
using GeekShoping.Web.Services.IServices;
using GeekShoping.Web.Utils;

namespace GeekShoping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var reposnse = await _client.GetAsync(BasePath);
            return await reposnse.ReadContentAs<List<ProductModel>>();
            
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var reposnse = await _client.GetAsync($"{BasePath}/{id}");
            return await reposnse.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var reposnse = await _client.PostAsJson(BasePath, model);
            if (reposnse.IsSuccessStatusCode)
                return await reposnse.ReadContentAs<ProductModel>();
            else throw new Exception("algo deu errado ao chamar api");
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var reposnse = await _client.PutAsJson(BasePath, model);
            if (reposnse.IsSuccessStatusCode)
                return await reposnse.ReadContentAs<ProductModel>();
            else throw new Exception("algo deu errado ao chamar api");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var reposnse = await _client.DeleteAsync($"{BasePath}/{id}");
            if (reposnse.IsSuccessStatusCode)
                return await reposnse.ReadContentAs<bool>();
            else throw new Exception("algo deu errado ao chamar api");
        }

       
    }
}
