using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

          private readonly Context _db;

        public UserController(Context context)
        {
            _db = context;
        }

        // GET api/User
        [HttpGet]
         public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _db.Users.ToListAsync();
           // return await _db.Users.ToListAsync();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingle(long id)
        {
            var User = await _db.Users.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (User == null)
                return NotFound();

            return User;
        }

        

        // POST api/User
       [HttpPost]
        public async Task<ActionResult<User>> Post(User User)
        {
            _db.Users.Update(User);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingle), new { id = User.Id }, User);
        }

        // PUT api/User/5
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, User User)
        {
            if (id != User.Id)
                return BadRequest();

            _db.Entry(User).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }
       
        //Login api/user
         [HttpPost("login")]
        public async Task<ActionResult<User>> login(User PostedUser)
        {
        
                
                    var dbUser = _db.Users.FirstOrDefault(x => 
                                                                x.Email == PostedUser.Email && 
                                                                x.Password == PostedUser.Password );
                    if (dbUser == null)
                       return NotFound();
                    else
                     return  dbUser;      
        }



        // DELETE api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var User = await _db.Users.FindAsync(id);

            if (User == null)
                return NotFound();

            _db.Users.Remove(User);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
