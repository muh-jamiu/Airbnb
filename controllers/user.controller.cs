namespace bnb.controllers
{

    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Driver;
    using Users.models;
    using Users.service;

    [Route("[controller]")]
    [ApiController]
    public class BnbController : ControllerBase
    {
        private MongoDBService _mongodbService;
        public BnbController(MongoDBService mongodbService)
        {
            _mongodbService = mongodbService;
        }
        
        [HttpGet]
        public async Task<List<UsersModel>> GetUser()
        {            
            return await _mongodbService.GetTaskAsync();
        }

        [HttpPost("user/register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UsersModel user)
        {
            await _mongodbService.RegisteUserAsync(user);
            return Ok("user is creaeted");
        }

        [HttpGet("user/{id}")]
        public async Task<List<UsersModel>> GetUserByID(string id)
        {            
            var user = await _mongodbService.GetUserByIdAsync(id);
            return user;
        }

         [HttpDelete("user/{id}")]
        public async Task<string> DeleteUser(string id)
        {            
            return await _mongodbService.DeleteUserAsync(id);
        }

        [HttpPut("user/{id}")]
        public async Task<string> UpdateUser([FromBody] UsersModel user,string id)
        {            
            UsersModel updateUser = new UsersModel{
                name = user.name,
                email = user.email,
                phone = user.phone,
                password = user.password,
            };

            return await _mongodbService.UpdateUserAsync(id, updateUser);
        }
    }
}