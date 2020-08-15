using System;
using Microsoft.AspNetCore.Mvc;
using SocNetw.Core.Models;
using Microsoft.AspNetCore.Authorization;
using SocNetw.JwtAuth;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SocNetw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        [AllowAnonymous]
        public ActionResult<string> Post(Credentials credentials, [FromServices] IJwtSigningEncodingKey signingEncodingKey)
        {
            // TODO check inputted credentials

            var claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, credentials.Login)
            };

            var token = new JwtSecurityToken(
                issuer: "DemoApp",
                audience: "DemoAppClient",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                        signingEncodingKey.GetKey(),
                        signingEncodingKey.SigningAlgorithm)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }

}
