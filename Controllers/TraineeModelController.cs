using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainee.Models;

namespace trainee.Controllers
{
    
    [Route("api/[controller]")]
       [ApiController]
       public class TraineeController : ControllerBase
       {
           private readonly TraineeContext _context;

           public TraineeController(TraineeContext context)
           {
               _context = context;
           }

           // GET: api/trainee
           [HttpGet]
           public async Task<ActionResult<IEnumerable<TraineeModel>>> Gettrainee()
           {
               return await _context.trainee.ToListAsync();
           }

           // GET: api/trainee/5
           [HttpGet("{id}")]
           public async Task<ActionResult<TraineeModel>> Gettrainee(string id)
           {
               var trainee = await _context.trainee.FindAsync(id);

               if (trainee == null)
               {
                   return NotFound();
               }

               return trainee;
           }

           // PUT: api/trainee/5
           [HttpPut("{id}")]
           public async Task<IActionResult> Puttrainee(string id, TraineeModel trainee)
           {
               if (id != trainee.Employeeid)
               {
                   return BadRequest();
               }

               _context.Entry(trainee).State = EntityState.Modified;

               try
               {
                   await _context.SaveChangesAsync();
               }
               catch (DbUpdateConcurrencyException)
               {
                   if (!traineeExists(id))
                   {
                       return NotFound();
                   }
                   else
                   {
                       throw;
                   }
               }

               return NoContent();
           }

           // POST: api/trainee
           [HttpPost]
           public async Task<ActionResult<TraineeModel>> Posttrainee(TraineeModel trainee)
           {
               _context.trainee.Add(trainee);
               await _context.SaveChangesAsync();

               return CreatedAtAction(nameof(Gettrainee), new { id = trainee.Employeeid }, trainee);
           }

           // DELETE: api/trainee/5
           [HttpDelete("{id}")]
           public async Task<IActionResult> Deletetrainee(string id)
           {
               var trainee = await _context.trainee.FindAsync(id);
               if (trainee == null)
               {
                   return NotFound();
               }

               _context.trainee.Remove(trainee);
               await _context.SaveChangesAsync();

               return NoContent();
           }

           private bool traineeExists(string id)
           {
               return _context.trainee.Any(e => e.Employeeid==id);
           }
       }
    }
    

  
