﻿using Application.Features.Auths.Commands.EnableEmailAuthenticator;
using Application.Features.Auths.Commands.EnableOtpAuthenticator;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.RefreshToken;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Commands.RevokeToken;
using Application.Features.Auths.Commands.VerifyEmailAuthenticator;
using Application.Features.Auths.Commands.VerifyOtpAuthenticator;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public async Task<IActionResult> Login([FromBody] Core.Security.Dtos.UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = GetIpAddress() };
            LoggedResponse result = await Mediator.Send(loginCommand);

            if (result.RefreshToken is not null)
                setRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.ToHttpResponse());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Core.Security.Dtos.UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand=new() { UserForRegisterDto=userForRegisterDto, IpAddress = GetIpAddress() };
            RegisteredResponse result=await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(result.RefreshToken);
            return Created(uri: "", result.AccessToken);
        }

        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            RefreshTokenCommand refreshTokenCommand = new() { RefreshToken = getRefreshTokenFromCookies(), IpAddress = GetIpAddress() };

            RefreshedTokensResponse result = await Mediator.Send(refreshTokenCommand);
            setRefreshTokenToCookie(result.RefreshToken);
            return Created(uri: "", result.AccessToken);
        }

        [HttpPut("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior =EmptyBodyBehavior.Allow)] string? refreshToken)
        {
            RevokeTokenCommand revokeTokenCommand=new() { Token=refreshToken ?? getRefreshTokenFromCookies(),IpAddress=GetIpAddress() };

            RevokedTokenResponse result=await Mediator.Send(revokeTokenCommand);

            return Ok(result);
        }

        [HttpGet("EnableEmailAuthenticator")]
        public async Task<IActionResult> EnableEmailAuthenticator()
        {
            EnableEmailAuthenticatorCommand enableEmailAuthenticatorCommand = new() { UserId = getUserIdFromRequest(), VerifyEmailUrlPrefix = $"{_configuration.ApiDomain}/Auth/VerifyEmailAuthenticator" };

            await Mediator.Send(enableEmailAuthenticatorCommand);

            return Ok();
        }

        [HttpGet("EnableOtpAuthenticator")]
        public async Task<IActionResult> EnableOtpAuthenticator()
        {
            EnableOtpAuthenticatorCommand enableOtpAuthenticatorCommand = new() { UserId = getUserIdFromRequest() };
            EnabledOtpAuthenticatorResponse result=await Mediator.Send(enableOtpAuthenticatorCommand); 
            return Ok(result);
        }

        [HttpGet("VerifyEmailAuthenticator")]
        public async Task<IActionResult> VerifyEmailAuthenticator([FromQuery] VerifyEmailAuthenticatorCommand verifyEmailAuthenticatorCommand)
        {
            await Mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }

        [HttpPost("VerifyOtpAuthenticator")]
        public async Task<IActionResult> VerifyOtpAuthenticator([FromBody] string authenticatorCode)
        {
            VerifyOtpAuthenticatorCommand verifyEmailAuthenticatorCommand =
                new() { UserId = getUserIdFromRequest(), ActivationCode = authenticatorCode };

            await Mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }

        private string getRefreshTokenFromCookies() =>
            Request.Cookies["refreshToken"] ?? throw new ArgumentException("Refresh token is not found in request cookies.");


        private void setRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
        }
    }

}
