using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Identity;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public ShowsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: api/Shows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetShows()
        {
            return await _bll.Show.AllForUserAsync(User.GetUserId());
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var show = await _bll.Show.FindAsync(id);

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        // PUT: api/Shows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (id != show.Id)
            {
                return BadRequest();
            }

            _bll.Show.Update(show);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Shows
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            await _bll.Show.AddAsync(show);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.Id }, show);
        }

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

            return show;
        }

    }
}
