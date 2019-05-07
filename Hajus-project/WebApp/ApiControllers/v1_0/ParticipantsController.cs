using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public ParticipantsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        
        /// <summary>
        /// Get Participants objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.ParticipantNames>>> GetParticipants()
        {
            return (await _bll.Participant.GetAllParticipantAsync())
                .Select(e => PublicApi.v1.Mappers.ParticipantMapper.MapFromInternal(e)).ToList();
        }

        /// <summary>
        /// Get participants object by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Participant>> GetParticipant(int id)
        {
            var participant = PublicApi.v1.Mappers.ParticipantMapper.MapFromInternal(
                await _bll.Participant.FindAsync(id));

            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        
        /// <summary>
        /// Put Participants by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="participant"></param>
        /// <returns></returns>
        // PUT: api/Participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(int id, PublicApi.v1.DTO.Participant participant)
        {
            if (id != participant.Id)
            {
                return BadRequest();
            }

            _bll.Participant.Update(PublicApi.v1.Mappers.ParticipantMapper.MapFromExternal(participant));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        
        /// <summary>
        /// Post parcitipants
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        // POST: api/Participants
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Participant>> PostParticipant(
            PublicApi.v1.DTO.Participant participant)
        {
            await _bll.Participant.AddAsync(PublicApi.v1.Mappers.ParticipantMapper.MapFromExternal(participant));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticipant), new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = participant.Id
            }, participant);
        }
        
        
        /// <summary>
        /// Delete participants by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Participant>> DeleteParticipant(int id)
        {
            var participant = await _bll.Participant.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            _bll.Participant.Remove(participant);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
