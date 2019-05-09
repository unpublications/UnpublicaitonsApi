using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Event_Management_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {
        public static string GenerateToken(UserProfile value)
        {

            String username = value.UserName;
            String email = value.Email;
            String firstname = value.UserName;
            String lastname = value.UserName;
            var claims = new[]
               {
                        new Claim(JwtRegisteredClaimNames.NameId, firstname),
                        new Claim(JwtRegisteredClaimNames.Sub,  username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, username)
                    };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YouCannotAlterTokenIfYouCannotHoldThisVeryLongKey"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "https://unpublications.com",
                audience: "https://unpublications.com",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signingCredentials
                );

            string data = JsonConvert.SerializeObject(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expiration = jwtSecurityToken.ValidTo,
                Claims = jwtSecurityToken.Claims
            });

            return data;
        }
    }
}