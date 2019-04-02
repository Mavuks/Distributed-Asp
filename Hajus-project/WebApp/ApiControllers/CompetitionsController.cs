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
    public class CompetitionsController : ControllerBase
    {
        

        private readonly IAppUnitOfWork _uow;
        

        public CompetitionsController( IAppUnitOfWork uow)
        {
            
            _uow = uow;
        }

        // GET: api/Competitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
        {
            var competitions = await _uow.Competition.AllAsync();
            
            return new ActionResult<IEnumerable<Competition>>(competitions);
        }

        // GET: api/Competitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(int id)
        {
            var competition = await _uow.Competition.FindAsync(id);

            if (competition == null)
            {
                return NotFound();
            }

            return competition;
        }

        // PUT: api/Competitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(int id, Competition competition)
        {
            if (id != competition.Id)
            {
                return BadRequest();
            }

            _uow.Competition.Update(competition);
            await _uow.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/Competitions
        [HttpPost]
        public async Task<ActionResult<Competition>> PostCompetition(Competition competition)
        {
            await _uow.Competition.AddAsync(competition);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCompetition", new { id = competition.Id }, competition);
        }

        // DELETE: api/Competitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Competition>> DeleteCompetition(int id)
        {
            var competition = await _uow.Competition.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            _uow.Competition.Remove(competition);
            await _uow.SaveChangesAsync();

            return competition;
        }

       
    }
}
