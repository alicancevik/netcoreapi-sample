using NetCoreApiSample.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace NetCoreApiSample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetProducts();
            
            Console.WriteLine("------------------------");

            GetCategories();

            Console.Read();
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
    }
}
