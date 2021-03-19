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
    public class McqsController : ControllerBase
    {

          private readonly Context _db;

        public McqsController(Context context)
        {
            _db = context;
        }

        // GET api/Mcqs
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Mcqs>>> GetAll()
        {
            return await _db.Mcqss.ToListAsync();
           // return await _db.Mcqss.ToListAsync();
        }

        // GET api/Mcqss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mcqs>> GetSingle(long id)
        {
            var Mcqs = await _db.Mcqss.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (Mcqs == null)
                return NotFound();

            return Mcqs;
        }

          [HttpGet("bysubject/{id}")]
        public async Task<ActionResult<IEnumerable<Mcqs>>> Getbysubject(long id)
        {
            var Mcqss = await _db.Mcqss.Where(x=>x.SubjectId == id).ToListAsync();
            if (Mcqss == null)
                return NotFound();

            return Mcqss;
        }

        // POST api/Mcqs
       [HttpPost]
        public async Task<ActionResult<Mcqs>> Post(Mcqs Mcqs)
        {
            _db.Mcqss.Update(Mcqs);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingle), new { id = Mcqs.Id }, Mcqs);
        }

        // PUT api/Mcqs/5
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Mcqs Mcqs)
        {
            if (id != Mcqs.Id)
                return BadRequest();

            _db.Entry(Mcqs).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Mcqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Mcqs = await _db.Mcqss.FindAsync(id);

            if (Mcqs == null)
                return NotFound();

            _db.Mcqss.Remove(Mcqs);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
