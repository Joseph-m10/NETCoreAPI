using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpPost("auth")]
        public IActionResult GetToken([FromBody] userCred uc)
        {
            string val = BAL.BAL.GetToken(uc.uname,uc.password);
            if(val == "" || val == null)
            {
                return BadRequest();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, uc.uname)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            if (tokenHandler.WriteToken(token) == null || tokenHandler.WriteToken(token) == "")
                return Unauthorized();
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}
