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
    public class SchoolingsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public SchoolingsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        
        /// <summary>
        /// Get Schooling objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Schoolings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Schooling>>> GetSchoolings()
        {
            return (await _bll.Schooling.AllAsync())
                .Select(e => PublicApi.v1.Mappers.SchoolingMapper.MapFromInternal(e)).ToList();
        }

        
        /// <summary>
        /// Get Schooling objects by id.
        /// </summary>
        /// <returns></returns>
        // GET: api/Schoolings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Schooling>> GetSchooling(int id)
        {
            var schooling = PublicApi.v1.Mappers.SchoolingMapper.MapFromInternal(
                await _bll.Schooling.FindAsync(id));

            if (schooling == null)
            {
                return NotFound();
            }

            return schooling;
        }

        
        /// <summary>
        /// Put Schooling objects.
        /// </summary>
        /// <returns></returns>
        // PUT: api/Schoolings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchooling(int id, PublicApi.v1.DTO.Schooling schooling)
        {
            if (id != schooling.Id)
            {
                return BadRequest();
            }

            _bll.Schooling.Update(PublicApi.v1.Mappers.SchoolingMapper.MapFromExternal(schooling));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        
        /// <summary>
        /// Post Schooling objects.
        /// </summary>
        /// <returns></returns>
        // POST: api/Schoolings
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Schooling>> PostSchooling(PublicApi.v1.DTO.Schooling schooling)
        {
            await _bll.Schooling.AddAsync(PublicApi.v1.Mappers.SchoolingMapper.MapFromExternal(schooling));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSchooling", new { id = schooling.Id }, schooling);
        }

        
        /// <summary>
        /// Delete Schooling objects by id.
        /// </summary>
        /// <returns></returns>
        // DELETE: api/Schoolings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Schooling>> DeleteSchooling(int id)
        {
            var schooling = await _bll.Schooling.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }

            _bll.Schooling.Remove(schooling);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
