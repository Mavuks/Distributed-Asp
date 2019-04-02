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
    public class ShowsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ShowsController(IAppUnitOfWork uow)
        {
            _uow = uow;
            
        }

        // GET: api/Shows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetShows()
        {
            var shows = await _uow.Show.AllAsync();
            return new ActionResult<IEnumerable<Show>>(shows);
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var show = await _uow.Show.FindAsync(id);

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

            _uow.Show.Update(show);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Shows
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            await _uow.Show.AddAsync(show);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.Id }, show);
        }

        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Show>> DeleteShow(int id)
        {
            var show = await _uow.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _uow.Show.Remove(show);
            await _uow.SaveChangesAsync();

            return show;
        }

    }
}
