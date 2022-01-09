using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiSample.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
