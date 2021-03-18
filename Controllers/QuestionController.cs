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
    public class QuestionController : ControllerBase
    {

          private readonly Context _db;

        public QuestionController(Context context)
        {
            _db = context;
        }

        // GET api/Question
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            return await _db.Questions.ToListAsync();
           // return await _db.Questions.ToListAsync();
        }

        // GET api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetSingle(long id)
        {
            var Question = await _db.Questions.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (Question == null)
                return NotFound();

            return Question;
        }

          [HttpGet("bysubject/{id}")]
        public async Task<ActionResult<IEnumerable<Question>>> Getbysubject(long id)
        {
            var Questions = await _db.Questions.Where(x=>x.SubjectId == id).ToListAsync();
            if (Questions == null)
                return NotFound();

            return Questions;
        }

        // POST api/Question
       [HttpPost]
        public async Task<ActionResult<Question>> Post(Question Question)
        {
            _db.Questions.Update(Question);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingle), new { id = Question.Id }, Question);
        }

        // PUT api/Question/5
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Question Question)
        {
            if (id != Question.Id)
                return BadRequest();

            _db.Entry(Question).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Question = await _db.Questions.FindAsync(id);

            if (Question == null)
                return NotFound();

            _db.Questions.Remove(Question);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
