using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event_Management_Api
{
    public class JWTController : Controller
    {
       
        public static String CreateToken(String firstname,String username)
        {
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
                issuer: "http://Juniper.net",
                audience: "http://Juniper.net",
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
