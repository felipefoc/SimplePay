using Microsoft.AspNetCore.Mvc;
using SimplePay.DTOs;
using SimplePay.Mappings;
using SimplePay.Models;
using SimplePay.Service;

namespace SimplePay.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await userService.GetUserAsync(id);
            if (user == null) return NotFound();
            return Ok(user.ToUserDetailResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAllUserAsync();
            var userDtos = await users.ToUserResponseDtoListAsync();
            return Ok(userDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await userService.CreateUserAsync(userDto);
            return CreatedAtAction(
                nameof(GetUser),
                new { id = createdUser.Id },
                createdUser.ToUserResponseDto()
            );
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateUser(Guid id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await userService.PartiallyUpdateUserAsync(id, userUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}