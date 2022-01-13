using NetCoreApiSample.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace NetCoreApiSample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetMethods();

            // PostMethods();

            // PutMethods();

            DeleteMethods();

            Console.Read();
        }


        private static void GetMethods()
        {
            GetProducts();

            Console.WriteLine("------------------------");

            GetCategories();
        }

        private static void PostMethods()
        {
            AddProduct();

            AddCategory();
        }

        private static void PutMethods()
        {
            UpdateProduct();

            UpdateCategory();
        }

        private static void DeleteMethods()
        {
            DeleteProduct();

            DeleteCategory();
        }

        private static void GetProducts()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            var result = httpClient.GetAsync("api/Products").Result;

            var jsonString = result.Content.ReadAsStringAsync().Result;

            var products = JsonSerializer.Deserialize<List<Product>>(jsonString);

            foreach (var product in products)
                Console.WriteLine($"Id: {product.Id} - Name: {product.Name}");
        }

        private static void GetCategories()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            var result = httpClient.GetAsync("api/Categories").Result;

            var jsonString = result.Content.ReadAsStringAsync().Result;

            var categories = JsonSerializer.Deserialize<List<Category>>(jsonString);

            foreach (var category in categories)
                Console.WriteLine($"Id: {category.Id} - Name: {category.Name}");
        }

        private static void AddProduct()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            ProductDto product = new ProductDto() 
            {
                Name = "Client Test Ürün",
                Description = "Client Test Ürün Açıklama",
                Price = 1500,
                CategoryId = 1
            };

            var serializeProduct = JsonSerializer.Serialize(product);

            StringContent stringContent = new StringContent(serializeProduct, Encoding.UTF8, "application/json");

            var result = httpClient.PostAsync("api/Products",stringContent).Result;

            if (result.IsSuccessStatusCode)
                Console.WriteLine("Ürün ekleme başarılı.");
            else
                Console.WriteLine($"Ürün eklenemedi. Hata Kodu: {result.StatusCode}");
        }

        private static void AddCategory()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            CategoryDto category = new CategoryDto()
            {
                Name = "Client Test Kategori"
            };

            var serializeCategory = JsonSerializer.Serialize(category);

            StringContent stringContent = new StringContent(serializeCategory, Encoding.UTF8, "application/json");

            var result = httpClient.PostAsync("api/Categories", stringContent).Result;

            if (result.IsSuccessStatusCode)
                Console.WriteLine("Kategori ekleme başarılı.");
            else
                Console.WriteLine($"Kategori eklenemedi. Hata Kodu: {result.StatusCode}");
        }

        private static void UpdateProduct()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            UpdateProductDto product = new UpdateProductDto()
            {
                Id = 1,
                Name = "Client Test Ürün Güncelleme",
                Price = 1500
            };

            var serializeProduct = JsonSerializer.Serialize(product);

            StringContent stringContent = new StringContent(serializeProduct, Encoding.UTF8, "application/json");

            var result = httpClient.PutAsync("api/Products/1", stringContent).Result;

            if (result.IsSuccessStatusCode)
                Console.WriteLine("Ürün güncelleme başarılı.");
            else
                Console.WriteLine($"Ürün güncelleme başarısız. Hata Kodu: {result.StatusCode}");
        }

        private static void UpdateCategory()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            Category product = new Category()
            {
                Id = 1,
                Name = "Client Test Kategori Güncelleme",
            };

            var serializeProduct = JsonSerializer.Serialize(product);

            StringContent stringContent = new StringContent(serializeProduct, Encoding.UTF8, "application/json");

            var result = httpClient.PutAsync("api/Categories/1", stringContent).Result;

            if (result.IsSuccessStatusCode)
                Console.WriteLine("Kategori güncelleme başarılı.");
            else
                Console.WriteLine($"Kategori güncelleme başarısız. Hata Kodu: {result.StatusCode}");
        }

        private static void DeleteProduct()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            int productId = 1;

            var result = httpClient.DeleteAsync($"api/Products/{productId}").Result;

            if (result.IsSuccessStatusCode)
                Console.WriteLine("Ürün silme başarılı.");
            else
                Console.WriteLine($"Ürün silme başarısız. Hata Kodu: {result.StatusCode}");
        }

        private static void DeleteCategory()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5000/");

            int categoryId = 1;

            var result = httpClient.DeleteAsync($"api/Categories/{categoryId}").Result;

            if (result.IsSuccessStatusCode)
                Console.WriteLine("Kategori silme başarılı.");
            else
                Console.WriteLine($"Kategori silme başarısız. Hata Kodu: {result.StatusCode}");
        }

    }
}
