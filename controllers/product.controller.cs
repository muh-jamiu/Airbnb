namespace bnb.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Users.models;
    using Users.service;

    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private MongoDBService _mongodbService;
        public ProductController(MongoDBService mongodbService )
        {
            _mongodbService = mongodbService;
        }

        [HttpGet]
        public async Task<List<Product>> GetProductsAsync()
        {            
            return await _mongodbService.GetProductAsync();
        }

        [HttpPost]
        public async Task<IActionResult> UploadProductAsync([FromBody] Product product)
        {            
            await _mongodbService.UploadProductAsync(product);
            return Ok("Product is uploaded successfully");
        }
        
    }
}