using HomeExpenseControl.Api.DTO.Requests;
using HomeExpenseControl.Api.DTO.Responses;
using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeExpenseControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        {
            var userList = await _userService.GetAllUsers();
            var userResponse = userList.Select(user => new UserResponse(user.idUser, user.UserName, user.UserAge));

            return Ok(userResponse);
        }

        [HttpGet("{idUser}")]
        public async Task<ActionResult<UserResponse>> GetById(Guid idUser)
        {
            var user = await _userService.GetUserById(idUser);

            return Ok(new UserResponse(user.idUser, user.UserName, user.UserAge));
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserRequest userRequest)
        {
            try
            {
                var user = new User(userRequest.UserName, userRequest.UserAge);
                await _userService.CreateUser(user);

                return Ok(new UserResponse(user.idUser, user.UserName, user.UserAge));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }

        [HttpDelete("{idUser}")]
        public async Task<ActionResult> Delete(Guid idUser)
        {
            try
            {
                await _userService.DeleteUser(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NoContent();
        }
    }
}
