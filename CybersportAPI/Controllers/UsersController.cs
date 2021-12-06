using CybersportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CybersportAPI.Controllers
{
    public class UsersController : Controller
    {
        db_a7d4d8_cybersportContext db;
        public UsersController(db_a7d4d8_cybersportContext context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Login = "Ilya", Password = "1234" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            return NotFound(id);
            return new ObjectResult(user);
        }

        [HttpGet("{login}/{password}")]
        public async Task<ActionResult<User>> Get(string login, string password)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<User>>> Search([FromQuery] string login)
        {
            List<User> users = await db.Users.Where(x => x.Login == login).ToListAsync();
            if (users == null)
                return NotFound();
            return new ObjectResult(users);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            db.Users.Add(new User { Login = user.Login, Password = user.Password, IsActive = user.IsActive, RoleId = user.RoleId });
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
