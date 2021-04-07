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
    public class TeachersController : ControllerBase
    {

          private readonly Context _db;

        public TeachersController(Context context)
        {
            _db = context;
        }

        // GET api/Teacher
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            return await _db.Teachers.ToListAsync();
           // return await _db.Teacher.ToListAsync();
        }

        // GET api/Teacher
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetSingle(long id)
        {
            var Teacher = await _db.Teachers.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (Teacher == null)
                return NotFound();

            return Teacher;
        }

           //Login api/Teacher
         [HttpPost("login")]
        public async Task<ActionResult<Teacher>> login(Teacher PostedUser)
        {
        
                
                    var dbUser = _db.Teachers.FirstOrDefault(x => 
                                                                x.Email == PostedUser.Email && 
                                                                x.Password == PostedUser.Password );
                    if (dbUser == null)
                       return NotFound();
                    else
                     return  dbUser;      
        }
        // POST api/Teacher
       [HttpPost]
        public async Task<ActionResult<Teacher>> Post(Teacher Teacher)
        {
            _db.Teachers.Update(Teacher);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingle), new { id = Teacher.Id }, Teacher);
        }

        // PUT api/Teacher/5
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Teacher Teacher)
        {
            if (id != Teacher.Id)
                return BadRequest();

            _db.Entry(Teacher).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Teacher = await _db.Teachers.FindAsync(id);

            if (Teacher == null)
                return NotFound("Not Found");

            _db.Teachers.Remove(Teacher);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
