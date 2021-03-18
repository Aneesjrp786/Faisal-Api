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
    public class SubjectController : ControllerBase
    {

          private readonly Context _db;

        public SubjectController(Context context)
        {
            _db = context;
        }

        // GET api/Subject
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Subject>>> GetAll()
        {
            return await _db.Subjects.ToListAsync();
           // return await _db.Subjects.ToListAsync();
        }

        // GET api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSingle(long id)
        {
            var Subject = await _db.Subjects.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (Subject == null)
                return NotFound();

            return Subject;
        }

         [HttpGet("byuser/{id}")]
        public async Task<ActionResult<IEnumerable<Subject>>> Getbyuser(long id)
        {
            var Subject = await _db.Subjects.Where(x=>x.UserId == id).ToListAsync();
            if (Subject == null)
                return NotFound();

            return Subject;
        }

      

        // POST api/Subject
       [HttpPost]
        public async Task<ActionResult<Subject>> Post(Subject Subject)
        {
            _db.Subjects.Update(Subject);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingle), new { id = Subject.Id }, Subject);
        }

        // PUT api/Subject/5
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Subject Subject)
        {
            if (id != Subject.Id)
                return BadRequest();

            _db.Entry(Subject).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Subject = await _db.Subjects.FindAsync(id);

            if (Subject == null)
                return NotFound();

            _db.Subjects.Remove(Subject);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
