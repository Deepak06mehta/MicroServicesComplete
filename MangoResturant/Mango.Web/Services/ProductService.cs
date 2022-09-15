using System;
using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService: BaseService,IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        } 

        public async Task<T> CreateProductAsync<T>(ProductDTO productDTO)
        {
            return await this.SendAsync<T>(new ApiRequest() {
                APIType = SD.APIType.POST,
                Data = productDTO,
                Url = SD.ProductAPIBase + "api/ProductAPI",
                AccessToken = ""
            }) ;
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                APIType = SD.APIType.DELETE,
                Url = SD.ProductAPIBase + "api/ProductAPI" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                APIType = SD.APIType.GET,
                Url = SD.ProductAPIBase + "api/ProductAPI",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIDAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                APIType = SD.APIType.GET,
                Url = SD.ProductAPIBase + "api/ProductAPI" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDTO productDTO)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                APIType = SD.APIType.PUT,
                Data = productDTO,
                Url = SD.ProductAPIBase + "api/ProductAPI",
                AccessToken = ""
            });
        }
    }
}

