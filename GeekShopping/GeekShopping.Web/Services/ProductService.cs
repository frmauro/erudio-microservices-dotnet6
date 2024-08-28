using GeekShopping.Web.DTO;
using GeekShopping.Web.Pages;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public const string BasePath = "api/v1/product";
    public async Task<IEnumerable<ProductDto>> FindAllProducts()
    {
        var response = await _client.GetAsync(BasePath);
        return await response.ReadContentAs<List<ProductDto>>();
    }

    public ProductService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<ProductDto> FindProductById(long id)
    {
        var response = await _client.GetAsync($"{BasePath}/{id}");
        return await response.ReadContentAs<ProductDto>();
    }

    public async Task<ProductDto> CreateProduct(ProductDto model)
    {
        var response = await _client.PostAsJson(BasePath, model);
        if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductDto>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<ProductDto> UpdateProduct(ProductDto model)
    {
        var response = await _client.PutAsJson(BasePath, model);
        if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductDto>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> DeleteProductById(long id)
    {
        var response = await _client.DeleteAsync($"{BasePath}/{id}");
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");
    }

}
