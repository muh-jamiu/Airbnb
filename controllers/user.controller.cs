namespace bnb.controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class BnbController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            return Ok("wow");
        }
    }
}