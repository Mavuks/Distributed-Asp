using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public MaterialsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        
        /// <summary>
        /// Get Material objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.MaterialCounts>>> GetMaterials()
        {

            return (await _bll.Material.GetAllWithMaterialCountAsync())
                .Select(e => PublicApi.v1.Mappers.MaterialMapper.MapFromInternal(e)).ToList();
        }

        
        /// <summary>
        /// Get material objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Material>> GetMaterial(int id)
        {
            var material = PublicApi.v1.Mappers.MaterialMapper.MapFromInternal(
                await _bll.Material.FindAsync(id));

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        
        /// <summary>
        /// Put Materials objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        // PUT: api/Materials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, PublicApi.v1.DTO.Material material)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            _bll.Material.Update(PublicApi.v1.Mappers.MaterialMapper.MapFromExternal(material));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        
        /// <summary>
        /// Post Material objects.
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        // POST: api/Materials
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Material>> PostMaterial(PublicApi.v1.DTO.Material material)
        {
            await _bll.Material.AddAsync(PublicApi.v1.Mappers.MaterialMapper.MapFromExternal(material));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMaterial),
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = material.Id
                }, material);
        }

        
        /// <summary>
        /// Delete materials by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Material>> DeleteMaterial(int id)
        {
            var material = await _bll.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _bll.Material.Remove(material);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
