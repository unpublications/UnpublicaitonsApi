using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Event_Management_Api.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Event_Management_Api.Controllers
{
    [Route("api/login")]
    public class LoginController : BaseController
    {
        // GET: api/login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get([FromRoute]int id)
        {
            return "value";
        }
        
        // POST: api/login
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserProfile value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            value = await LoginRepo.LoginAsyc(value);

            return Ok(GenerateToken(value));

        }
        
        // PUT: api/login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
