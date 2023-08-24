using Application.Features.Auths.Commands.Login;
using Core.Application.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly WebApiConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            const string configurationSection = "WebAPIConfiguration";
            _configuration =
                configuration.GetSection(configurationSection).Get<WebApiConfiguration>()
                ?? throw new NullReferenceException($"\"{configurationSection}\" section cannot found in configuration.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = GetIpAddress() };
            LoggedResponse result = await Mediator.Send(loginCommand);

            if (result.RefreshToken is not null)
                setRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.ToHttpResponse());
        }

        private void setRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
        }
    }

}
