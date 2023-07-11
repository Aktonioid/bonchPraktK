using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_6_01.API.DTO;
using WebAPI_6_01.Domain;
using WebAPI_6_01.Domain.Model;
using WebAPI_6_01.Infrastructure;

namespace WebAPI01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoObjectTypeController : ControllerBase
    {
        private readonly Context _context;
        private readonly GeoObjectTypeRepository _geoObjectTypeRepository;
        public GeoObjectTypeController(Context context)
        {
            _context = context;
            _geoObjectTypeRepository = new GeoObjectTypeRepository(_context);
        }

        // GET: api/GeoObjectType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeoObjectTypeDto>>> GetAll()
        {
            var geoObjectTypes = await _geoObjectTypeRepository.GetAllAsync();
            var dtos = GeoObjectTypeDtoMapper.ToDto(geoObjectTypes);
            return dtos;
        }

        // GET: api/GeoObjectType/5
        [HttpGet("{code}")]
        public async Task<ActionResult<GeoObjectTypeDto>> GetGeoObjectType(string code)
        {
            var geoObjectType = await _geoObjectTypeRepository.GetByCodeAsync(code);
            var geoObjectTypeDto = GeoObjectTypeDtoMapper.ToDto(geoObjectType);
            if (geoObjectType == null)
            {
                return NotFound();
            }
            return geoObjectTypeDto;
        }

        // GET: api/GeoObjectType/BySection/5
        [HttpGet("cection/{sectionCode}")]
        public async Task<ActionResult<List<GeoObjectTypeDto>>> GetGeoObjectTypeBySectionCode(string sectionCode)
        {
            var geoObjectTypes = await _geoObjectTypeRepository.GetByTypeSectionCodeAsync(sectionCode);
            if (geoObjectTypes == null || geoObjectTypes.Count == 0)
            {
                return NotFound();
            }
            var geoObjectTypeDtos = GeoObjectTypeDtoMapper.ToDto(geoObjectTypes);
            return geoObjectTypeDtos;
        }

        // PUT: api/GeoObjectType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{code}")]
        public async Task<IActionResult> PutGeoObjectTypen(string code, GeoObjectTypeDto geoObjectTypeDto)
        {
            if (code != geoObjectTypeDto.Code)
            {
                return BadRequest();
            }

            var geoObjectType = GeoObjectTypeDtoMapper.ToEntity(geoObjectTypeDto);
            await _geoObjectTypeRepository.UpdateAsync(geoObjectType);

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeoObjectTypeDto>> PostGeoObjectType([FromBody]GeoObjectTypeDto geoObjectTypeDto)
        {
            geoObjectTypeDto.Id = Guid.NewGuid().ToString();
            var geoObjectType = GeoObjectTypeDtoMapper.ToEntity(geoObjectTypeDto);
            await _geoObjectTypeRepository.AddAsync(geoObjectType);
            return CreatedAtAction("GetGeoObjectType", new { code = geoObjectTypeDto.Code }, geoObjectTypeDto);
        }

        // DELETE: api/GeoObjectType/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteGeoObjectType(string code)
        {
            var geoObjectType = await _geoObjectTypeRepository.GetByCodeAsync(code);
            if (geoObjectType == null)
            {
                return NotFound();
            }
            await _geoObjectTypeRepository.DeleteAsync(code);

            return NoContent();
        }

        private bool GeoObjectTypeExists(string code)
        {
            return _context.GeoObjectTypes.Any(e => e.Code == code);
        }
    }
}
