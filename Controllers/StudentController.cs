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
    public class StudentController : ControllerBase
    {

          private readonly Context _db;

        public StudentController(Context context)
        {
            _db = context;
        }

        // GET api/Student
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await _db.Students.ToListAsync();
           // return await _db.Students.ToListAsync();
        }

        // GET api/Student
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetSingle(long id)
        {
            var Student = await _db.Students.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (Student == null)
                return NotFound();

            return Student;
        }


          //Login api/Student
         [HttpPost("login")]
        public async Task<ActionResult<Student>> login(Student PostedUser)
        {
        
                
                    var dbUser = _db.Students.FirstOrDefault(x => 
                                                                x.Email == PostedUser.Email && 
                                                                x.Password == PostedUser.Password );
                    if (dbUser == null)
                       return NotFound();
                    else
                     return  dbUser;      
        }

        // POST api/Student
       [HttpPost]
        public async Task<ActionResult<Student>> Post(Student Student)
        {
            _db.Students.Update(Student);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingle), new { id = Student.Id }, Student);
        }

        // PUT api/Student/5
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Student Student)
        {
            if (id != Student.Id)
                return BadRequest();

            _db.Entry(Student).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Student = await _db.Students.FindAsync(id);

            if (Student == null)
                return NotFound();

            _db.Students.Remove(Student);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
