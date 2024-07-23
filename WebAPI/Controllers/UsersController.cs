using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //loosely coupled --> bir bağımlılık var ama soyuta bağımlı
        //IoC container -- inversion of controller(değişimin kontrolü)
        //
        IUserService _userService;//field oluşturduk
      
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            ////dependency chain --> bağımlılık zinciri
            //IUserService userService = new UserManager(new EfUserDal());
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
                
            }
            return BadRequest(result);
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById([FromQuery]int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                var user = result.Data; // Kullanıcının tüm bilgileri burada
                var userToUpdate = new UserToUpdate
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password // Güvenlik gereksinimlerine göre değerlendirilmeli
                };

                return Ok(userToUpdate);
            }
            return BadRequest(result);
        }

        [HttpGet("get-details")]
        public IActionResult GetDetails()
        {
            var result = _userService.GetUserDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("get-details-by-id")]
        public IActionResult GetDetailsById( int id)
        {
            var result = _userService.GetUserDetailsById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]//data ekleme
        public IActionResult Add(UserToAdd userToAdd)
        {
            
            var result = _userService.Add(userToAdd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            var result = _userService.Login(email, password);
            if (result.Success)
            {
                return Ok(result);
                
            }
            return BadRequest(result);


        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserToRegister userToRegister)
        {
            var result = _userService.Register(userToRegister);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]

        public IActionResult UpdateUser([FromBody] UserToUpdate userToUpdate)
        {
            var result = _userService.UpdateUser(userToUpdate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

     






    }
}
