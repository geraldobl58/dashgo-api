using AutoMapper;
using dashgo_api.Models.Domain;
using dashgo_api.Models.Dtos;
using dashgo_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dashgo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPropertyRepository propertyRepository;

        public PropertiesController(IMapper mapper, IPropertyRepository propertyRepository)
        {
            this.mapper = mapper;
            this.propertyRepository = propertyRepository;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] AddPropertyRequestDto addPropertyRequestDto)
        {
            if (ModelState.IsValid)
            {
                var property = mapper.Map<Property>(addPropertyRequestDto);

                await propertyRepository.CreateAsync(property);

                return Ok(mapper.Map<PropertyDto>(property));
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Property>))]
        public async Task<IActionResult> GetAll([FromQuery] string? title = null, string? category = null, int? bathroom = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var property = await propertyRepository.GetAllAsync(title, category, bathroom, pageNumber, pageSize);

            return Ok(mapper.Map<List<PropertyDto>>(property));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var property = await propertyRepository.GetByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PropertyDto>(property));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdatePropertyRequestDto updatePropertyRequestDto)
        {
            if (ModelState.IsValid)
            {
                var property = mapper.Map<Property>(updatePropertyRequestDto);

                property = await propertyRepository.UpdateAsync(id, property);

                if (property == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<PropertyDto>(property));
            }
            else 
            { 
                return BadRequest(ModelState);
            }
            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var property = await propertyRepository.DeleteAsync(id);

            if (property == null) 
            {
                return NotFound();
            }

            return Ok(mapper.Map<PropertyDto>(property));
        }

    }
}
