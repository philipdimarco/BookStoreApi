using BookStoreApi.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreApi.Helpers;
using BookStoreApi.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreApi.Repositories.UnitOfWork;
using BookStoreApi.Services;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthUtils _authUtils;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(AuthUtils authUtils, IUnitOfWork unitOfWork)
        {
            _authUtils = authUtils ?? throw new ArgumentNullException(nameof(authUtils));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user registration.");
            }
            User user = EntDtoMapper.FromUserDto(userDto, _authUtils);
            await _unitOfWork.AppUsersRepository.AddSingleAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("signon")]
        public async Task<IActionResult> SignOn([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user.");
            }

            var userEntity = await _unitOfWork.AppUsersRepository.GetByUserNameAsync(userDto.Username);
            if (userEntity == null)
            {
                return NotFound("User not registered.");
            }

            if (!_authUtils.VerifyPasswordHash(userDto.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                return BadRequest("Invalid credentials.");
            }

            string token = _authUtils.CreateToken(userEntity);
            return Ok(new AccessTokenDto(token));
        }
    }
}
