using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreApiSample.DataContext;
using NetCoreApiSample.Dtos;
using NetCoreApiSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using var context = new NetCoreApiSampleDataContext();

            var products = context.Products.ToList();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            using var context = new NetCoreApiSampleDataContext();

            context.Products.Add(product);
            context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductDto productModel)
        {
            using var context = new NetCoreApiSampleDataContext();

            if (id != productModel.Id)
                return BadRequest("Geçersiz Id");

            var product = context.Products.Find(productModel.Id);

            if (product == null)
                return BadRequest("Böyle bir ürün bilgisi bulunamadı!");

            product.Name = productModel.Name;
            product.Price = productModel.Price;

            context.SaveChanges();

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var context = new NetCoreApiSampleDataContext();

            var product = context.Products.Find(id);
            
            if (product == null)
                return NotFound();

            context.Products.Remove(product);

            context.SaveChanges();

            return NoContent();
        }


    }
}
