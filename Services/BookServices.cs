using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp_Maui.Models;
using Newtonsoft.Json;

namespace LibraryApp_Maui.Services
{
    public class BookServices
    {
        private string baseUrl { get; set; }

        public BookServices()
        {
            this.baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5176/api/Book/" : "http://localhost:5176/api/Book/";
        }

        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                List<Book> booksList = new List<Book>();
                string fullUrl = this.baseUrl + "GetBooks";
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(fullUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentRespone = await httpResponseMessage.Content.ReadAsStringAsync();
                    booksList = JsonConvert.DeserializeObject<List<Book>>(contentRespone);
                }
                return await Task.FromResult(booksList.ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book> GetBookById(int bookId)
        {
            try
            {
                Book currentBook = new Book();
                string fullUrl = this.baseUrl + $"GetBooks/{bookId}";
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(fullUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentRespone = await httpResponseMessage.Content.ReadAsStringAsync();
                    currentBook = JsonConvert.DeserializeObject<Book>(contentRespone);
                }
                return await Task.FromResult(currentBook);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book> AddNewBook(Book bookInfo)
        {
            try
            {
                string fullUrl = this.baseUrl + $"InsertBook";
                string bookInfoAsJson = JsonConvert.SerializeObject(bookInfo);
                StringContent bookStringContent = new StringContent(bookInfoAsJson, Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(fullUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("", bookStringContent);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await Task.FromResult(bookInfo);
                }
                return await Task.FromResult(new Book());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book> EditBook(Book bookInfo)
        {
            try
            {
                string fullUrl = this.baseUrl + $"UpdateBook/{bookInfo.BookId}";
                string bookInfoAsJson = JsonConvert.SerializeObject(bookInfo);
                StringContent bookStringContent = new StringContent(bookInfoAsJson, Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(fullUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage httpResponseMessage = await httpClient.PutAsync("", bookStringContent);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await Task.FromResult(bookInfo);
                }
                return await Task.FromResult(new Book());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteBook(Book bookInfo)
        {
            try
            {
                string fullUrl = this.baseUrl + $"DeleteBooks/{bookInfo.BookId}";
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(fullUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync("");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
