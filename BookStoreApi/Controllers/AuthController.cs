﻿using BookStoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreApi.Helpers;
using BookStoreApi.Entities;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthUtils _authUtils;

        public AuthController(AuthUtils authUtils)
        {
            _authUtils = authUtils ?? throw new ArgumentNullException(nameof(authUtils));
        }

        [HttpPost(Name = "register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {

            User user = ObjectMapperExtension.FromUserDto(userDto, _authUtils);

            //_authUtils.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            //User user = new User()
            //{
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt,
            //    Username = userDto.Username
            //};

            return Ok();
        }


        //[HttpPost(Name = "signon")]
        //public async Task<IActionResult> SignOn([FromBody] UserDto userDto)
        //{
        //    return Ok();
            /*
                if (user.UserName=="admin@mohamadlawand.com" && user.Password=="P@ssword")
                {
                    var issuer = builder.Configuration["Jwt:Issuer"];
                    var audience = builder.Configuration["Jwt:Audience"];
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    // Now its ime to define the jwt token which will be responsible of creating our tokens
                    var jwtTokenHandler = new JwtSecurityTokenHandler();

                    // We get our secret from the appsettings
                    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

                    // we define our token descriptor
                        // We need to utilise claims which are properties in our token which gives information about the token
                        // which belong to the specific user who it belongs to
                        // so it could contain their id, name, email the good part is that these information
                        // are generated by our server and identity framework which is valid and trusted
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new []
                        {
                            new Claim("Id", "1"),
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                            // the JTI is used for our refresh token which we will be convering in the next video
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        }),
                        // the life span of the token needs to be shorter and utilise refresh token to keep the user signedin
                        // but since this is a demo app we can extend it to fit our current need
                        Expires = DateTime.UtcNow.AddHours(6),
                        Audience = audience,
                        Issuer = issuer,
                        // here we are adding the encryption alogorithim information which will be used to decrypt our token
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                    };

                    var token = jwtTokenHandler.CreateToken(tokenDescriptor);

                    var jwtToken = jwtTokenHandler.WriteToken(token);

                    return Results.Ok(jwtToken);
                }
                else
                {
                    return Results.Unauthorized();
                }

            */
        //}
    }
}
