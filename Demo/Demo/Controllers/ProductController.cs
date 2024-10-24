using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Coffee", Category = "Beverage", Price = 3.5m },
            new Product { Id = 2, Name = "Tea", Category = "Beverage", Price = 2.5m },
            new Product { Id = 3, Name = "Juice", Category = "Beverage", Price = 4.0m }
        };


        // Route: POST api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with id {id} not found.");
            }
            return Ok(product);
        }
        // Route: POST api/products
        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product newProduct)
        {
            newProduct.Id = products.Count + 1; // Simple logic to generate an ID
            products.Add(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }
    }
}
