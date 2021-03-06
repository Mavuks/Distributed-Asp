using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using ee.itcollege.mavuks.Identity;

using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
       
        
        private readonly IAppBLL _bll;
        

        public CompetitionsController(  IAppBLL bll)
        {
            
            _bll = bll;
        }

        /// <summary>
        /// Get all Competition objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Competitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Competition>>> GetCompetitions()
        {
            return (await _bll.Competition.AllAsync())
                .Select(e => PublicApi.v1.Mappers.CompetitionMapper.MapFromInternal(e)).ToList();
        }
        /// <summary>
        /// Get all Competition objects by id.
        /// </summary>
        /// <returns></returns>

        // GET: api/Competitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Competition>> GetCompetition(int id)
        {
            var competition = PublicApi.v1.Mappers.CompetitionMapper.MapFromInternal(
                await _bll.Competition.FindAsync(id, User.GetUserId()));

            if (competition == null)
            {
                return NotFound();
            }

            return competition;
        }

        
        /// <summary>
        /// Put all Competition objects.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="competition"></param>
        /// <returns></returns>
        // PUT: api/Competitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(int id, PublicApi.v1.DTO.Competition competition)
        {
            if (id != competition.Id)
            {
                return BadRequest();
            }

            _bll.Competition.Update(PublicApi.v1.Mappers.CompetitionMapper.MapFromExternal(competition));
            await _bll.SaveChangesAsync();
            

            return NoContent();
        }

        
        /// <summary>
        /// Post All competitions
        /// </summary>
        /// <param name="competition"></param>
        /// <returns></returns>
        // POST: api/Competitions
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Competition>> PostCompetition(PublicApi.v1.DTO.Competition competition)
        {
            await _bll.Competition.AddAsync(PublicApi.v1.Mappers.CompetitionMapper.MapFromExternal(competition));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCompetition", new { id = competition.Id }, competition);
        }

        
        
        /// <summary>
        /// Delete  Competitions objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Competitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Competition>> DeleteCompetition(int id)
        {
            var competition = await _bll.Competition.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            _bll.Competition.Remove(competition);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
