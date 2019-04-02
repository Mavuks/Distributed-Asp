using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolingsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SchoolingsController( IAppUnitOfWork uow)
        {
            _uow = uow;
            
        }

        // GET: api/Schoolings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schooling>>> GetSchoolings()
        {
            var schoolings = await _uow.Schooling.AllAsync();
            return new ActionResult<IEnumerable<Schooling>>(schoolings);
        }

        // GET: api/Schoolings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schooling>> GetSchooling(int id)
        {
            var schooling = await _uow.Schooling.FindAsync(id);

            if (schooling == null)
            {
                return NotFound();
            }

            return schooling;
        }

        // PUT: api/Schoolings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchooling(int id, Schooling schooling)
        {
            if (id != schooling.Id)
            {
                return BadRequest();
            }

            _uow.Schooling.Update(schooling);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Schoolings
        [HttpPost]
        public async Task<ActionResult<Schooling>> PostSchooling(Schooling schooling)
        {
            await _uow.Schooling.AddAsync(schooling);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSchooling", new { id = schooling.Id }, schooling);
        }

        // DELETE: api/Schoolings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Schooling>> DeleteSchooling(int id)
        {
            var schooling = await _uow.Schooling.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }

            _uow.Schooling.Remove(schooling);
            await _uow.SaveChangesAsync();

            return schooling;
        }

    }
}
