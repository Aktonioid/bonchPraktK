using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_6_01.API.DTO;
using WebAPI_6_01.Domain;
using WebAPI_6_01.Domain.Model;
using WebAPI_6_01.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_6_01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeSectionController : ControllerBase
    {
        private readonly Context _context;
        private readonly GeoObjectTypeRepository _geoObjectTypeRepository;
        public TypeSectionController(Context context)
        {
            _context = context;
            _geoObjectTypeRepository = new GeoObjectTypeRepository(_context);
        }

        // GET: api/TypeSection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeSectionDto>>> GetAll()
        {
            var typeSections = await _geoObjectTypeRepository.GetAllTypeSectionsAsync();
            var dtos = TypeSectionDtoMapper.ToDto(typeSections);
            
            foreach (var item in dtos)
            {
                var code = item.Code;
                var list = await _geoObjectTypeRepository.GetByTypeSectionCodeAsync(code);
                item.GeoObjectTypes = list.Select(GeoObject => GeoObjectTypeDtoMapper.ToDto(GeoObject)).ToList();
            }
            

            return dtos;
        }

        // GET api/<TypeSectionController>/5
        [HttpGet("{code}")]
        public async Task<TypeSectionDto> Get(string code)
        {
            var typeSection = await _geoObjectTypeRepository.GetTypeSectionByCodeAsync(code);
            typeSection.GeoObjectTypes = await _geoObjectTypeRepository.GetByTypeSectionCodeAsync(code);
            return TypeSectionDtoMapper.ToDto(typeSection);
        }

        // POST api/<TypeSectionController>
        [HttpPost]
        public async Task Post([FromBody] TypeSectionDto typeSectionDto)
        {
            var typeSection = TypeSectionDtoMapper.ToEntity(typeSectionDto);
            await _geoObjectTypeRepository.AddTypeSectionAsync(typeSection);
        }

        // PUT api/<TypeSectionController>/5
        [HttpPut("{code}")]
        public async Task Put(string code, [FromBody] TypeSectionDto typeSectionDto)
        {
            var typeSection = TypeSectionDtoMapper.ToEntity(typeSectionDto);
            await _geoObjectTypeRepository.UpdateTypeSectionAsync(typeSection);
        }

        // DELETE api/<TypeSectionController>/5
        [HttpDelete("{code}")]
        public async Task Delete(string code)
        {
            await _geoObjectTypeRepository.DeleteTypeSectionByCodeAsync(code);
        }
    }
}
