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
            return dtos;
        }

        // GET api/<TypeSectionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TypeSectionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TypeSectionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TypeSectionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
