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
    public class StudentQuizController : ControllerBase
    {

          private readonly Context _db;

        public StudentQuizController(Context context)
        {
            _db = context;
        }

        // GET api/StudentQuiz
        [HttpGet]
         public async Task<ActionResult<IEnumerable<StudentQuiz>>> GetAll()
        {
            return await _db.StudentQuizs.ToListAsync();
           // return await _db.StudentQuizs.ToListAsync();
        }

        // GET api/StudentQuiz/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentQuiz>> GetSingle(long id)
        {
            var StudentQuiz = await _db.StudentQuizs.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (StudentQuiz == null)
                return NotFound();

            return StudentQuiz;
        }   

        // POST api/StudentQuiz
       [HttpPost]
        public async Task<ActionResult<StudentQuiz>> Post(StudentQuiz StudentQuiz)
        {
            _db.StudentQuizs.Update(StudentQuiz);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingle), new { id = StudentQuiz.Id }, StudentQuiz);
        }

        // PUT api/StudentQuiz/5
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, StudentQuiz StudentQuiz)
        {
            if (id != StudentQuiz.Id)
                return BadRequest();

            _db.Entry(StudentQuiz).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/StudentQuiz/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var StudentQuiz = await _db.StudentQuizs.FindAsync(id);

            if (StudentQuiz == null)
                return NotFound();

            _db.StudentQuizs.Remove(StudentQuiz);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
