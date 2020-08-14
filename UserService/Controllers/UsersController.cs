using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public static List<User> users = new List<User>();
      

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET api/Users/Guid
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {

            var user = users.FirstOrDefault(t => t.Id == id);

            if (user == null)

            {
                return NotFound();

            }
            return new OkObjectResult(user);
        }

        // POST api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.Id = Guid.NewGuid();
            value.CreatedDate = DateTime.Now;
            users.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);// first 2 parameters is the location of the newly created object
            

        }

        // PUT api/Users/Guid
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User value)
        {
            var user = users.FirstOrDefault(t => t.Id == id);

            if (user == null)

            {
                return NotFound();

            }

            user.Id = id;
            user.Email = value.Email;
            user.Password = value.Password;

            return Ok(user);

        }


        // DELETE api/ApiWithActions/Guid
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            var usersRemoved = users.RemoveAll(t => t.Id == id);

            if (usersRemoved == 0)
            {
                return NotFound();//404

            }

            return Ok();//200

        }
    }
}
