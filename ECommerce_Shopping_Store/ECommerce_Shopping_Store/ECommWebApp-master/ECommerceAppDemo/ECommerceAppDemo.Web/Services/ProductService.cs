using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ECommerceAppDemo.API.DTOs;

using Newtonsoft.Json;

namespace ECommerceAppDemo.Web.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"])
            };
        }

        public async Task<List<TelevisionProduct>> GetTelevisionsAsync()
        {
            
            var response = await _httpClient.GetStringAsync("products/bycategory?categoryName=Television");

            return JsonConvert.DeserializeObject<List<TelevisionProduct>>(response);
        }

       
    }
}