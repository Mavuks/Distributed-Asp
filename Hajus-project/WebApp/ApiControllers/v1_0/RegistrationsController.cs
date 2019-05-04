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
    public class RegistrationsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public RegistrationsController( IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: api/Registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Registration>>> GetRegistrations()
        {
            return (await _bll.Registration.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.RegistrationMapper.MapFromInternal(e)).ToList();
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Registration>> GetRegistration(int id)
        {
            var registration = PublicApi.v1.Mappers.RegistrationMapper.MapFromInternal(
                await _bll.Registration.FindAsync(id));

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        // PUT: api/Registrations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, PublicApi.v1.DTO.Registration registration)
        {
            if (id != registration.Id)
            {
                return BadRequest();
            }

            _bll.Registration.Update(PublicApi.v1.Mappers.RegistrationMapper.MapFromExternal(registration));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Registrations
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Registration>> PostRegistration(PublicApi.v1.DTO.Registration registration)
        {
            await _bll.Registration.AddAsync(PublicApi.v1.Mappers.RegistrationMapper.MapFromExternal(registration));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetRegistration", new { id = registration.Id }, registration);
        }

        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            var registration = await _bll.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _bll.Registration.Remove(registration);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
