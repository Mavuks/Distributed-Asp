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
    public class AwardsController : ControllerBase
    {
        
        private readonly IAppUnitOfWork _uow;

        public AwardsController(IAppUnitOfWork uow)
        {
           
            _uow = uow;
        }

        // GET: api/Awards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Award>>> GetAwards()
        {
            var awards = await _uow.Award.AllAsync();
            return new ActionResult<IEnumerable<Award>>(awards);
        }

        // GET: api/Awards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetAward(int id)
        {
            var award = await _uow.Award.FindAsync(id);

            if (award == null)
            {
                return NotFound();
            }

            return award;
        }

        // PUT: api/Awards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAward(int id, Award award)
        {
            if (id != award.Id)
            {
                return BadRequest();
            }

            _uow.Award.Update(award);
            await _uow.SaveChangesAsync();

            
            

            return NoContent();
        }

        // POST: api/Awards
        [HttpPost]
        public async Task<ActionResult<Award>> PostAward(Award award)
        {
            await _uow.Award.AddAsync(award);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetAward", new { id = award.Id }, award);
        }

        // DELETE: api/Awards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Award>> DeleteAward(int id)
        {
            var award = await _uow.Award.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            _uow.Award.Remove(award);
            await _uow.SaveChangesAsync();

            return award;
        }

     
    }
}
