using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Identity;
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

        // GET: api/Schoolings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Schooling>>> GetSchoolings()
        {
            return (await _bll.Schooling.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.SchoolingMapper.MapFromInternal(e)).ToList();
        }

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

        // POST: api/Schoolings
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Schooling>> PostSchooling(PublicApi.v1.DTO.Schooling schooling)
        {
            await _bll.Schooling.AddAsync(PublicApi.v1.Mappers.SchoolingMapper.MapFromExternal(schooling));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSchooling", new { id = schooling.Id }, schooling);
        }

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
