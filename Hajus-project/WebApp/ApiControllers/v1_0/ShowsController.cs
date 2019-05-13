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
    public class ShowsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public ShowsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get Show objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Shows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Show>>> GetShows()
        {
            return (await _bll.Show.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.ShowMapper.MapFromInternal(e)).ToList();
        }
        
        
        /// <summary>
        /// Get Show objects by id.
        /// </summary>
        /// <returns></returns>
        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Show>> GetShow(int id)
        {
            var show = PublicApi.v1.Mappers.ShowMapper.MapFromInternal(
                await _bll.Show.FindAsync(id));

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        
        /// <summary>
        /// Put Show objects.
        /// </summary>
        /// <returns></returns>
        // PUT: api/Shows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, PublicApi.v1.DTO.Show show)
        {
            if (id != show.Id)
            {
                return BadRequest();
            }

            _bll.Show.Update(PublicApi.v1.Mappers.ShowMapper.MapFromExternal(show));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        
        /// <summary>
        /// Post Show objects.
        /// </summary>
        /// <returns></returns>
        // POST: api/Shows
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Show>> PostShow(PublicApi.v1.DTO.Show show)
        {
            await _bll.Show.AddAsync(PublicApi.v1.Mappers.ShowMapper.MapFromExternal(show));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.Id }, show);
        }

        
        /// <summary>
        /// Delete Show objects by id..
        /// </summary>
        /// <returns></returns>
        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Show>> DeleteShow(int id)
        {
            var show = await _bll.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _bll.Show.Remove(show);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
