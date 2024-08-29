using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp_Maui.Models;
using Newtonsoft.Json;

namespace LibraryApp_Maui.Services
{
    public class CategoryServices
    {
        private string baseUrl { get; set; }
        public CategoryServices()
        {
            this.baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5176/api/Category/" : "http://localhost:5176/api/Category/";
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                List<Category> categoryList = new List<Category>();
                string fullUrl = this.baseUrl + "GetCategories";
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(fullUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentRespone = await httpResponseMessage.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<Category>>(contentRespone);
                }
                return await Task.FromResult(categoryList.ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
