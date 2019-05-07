using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public LocationsController(IAppBLL bll)
        {
            _bll = bll;
           
        }

        /// <summary>
        /// Get all Locations objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Location>>> GetLocations()
        {
            return (await _bll.Location.AllAsync())
                .Select(e => PublicApi.v1.Mappers.LocationMapper.MapFromInternal(e)).ToList();
        }

        /// <summary>
        /// Get Locations objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Location>> GetLocation(int id)
        {
            var location = PublicApi.v1.Mappers.LocationMapper.MapFromInternal(
                await _bll.Location.FindAsync(id));

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }
        
        
        /// <summary>
        /// Put Locations objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, PublicApi.v1.DTO.Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _bll.Location.Update(PublicApi.v1.Mappers.LocationMapper.MapFromExternal(location));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        
        /// <summary>
        /// Post Locations objects .
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Location>> PostLocation(PublicApi.v1.DTO.Location location)
        {
            await _bll.Location.AddAsync(PublicApi.v1.Mappers.LocationMapper.MapFromExternal(location));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        
        /// <summary>
        /// delete locations by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocation(int id)
        {
            var location = await _bll.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _bll.Location.Remove(location);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
