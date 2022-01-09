using Microsoft.AspNetCore.Mvc;
using NetCoreApiSample.DataContext;
using NetCoreApiSample.Dtos;
using NetCoreApiSample.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using var context = new NetCoreApiSampleDataContext();

            var categories = context.Categories.ToList();

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            using var context = new NetCoreApiSampleDataContext();

            context.Categories.Add(category);
            context.SaveChanges();

            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryDto categoryDto)
        {
            using var context = new NetCoreApiSampleDataContext();

            if (id != categoryDto.Id)
                return BadRequest("Geçersiz Id");

            var category = context.Categories.Find(categoryDto.Id);

            if (category == null)
                return BadRequest("Böyle bir ürün bilgisi bulunamadı!");

            category.Name = categoryDto.Name;

            context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var context = new NetCoreApiSampleDataContext();

            var category = context.Categories.Find(id);

            if (category == null)
                return NotFound();

            context.Categories.Remove(category);

            context.SaveChanges();

            return NoContent();
        }


    }
}

