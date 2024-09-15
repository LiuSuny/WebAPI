using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnalApi.Dto;
using PersonnalApi.Interfaces;
using PersonnalApi.Models;
using PersonnalApi.Repository;

namespace PersonnalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository categoryRepository, IMapper mapper)
        {
            _countryRepository = categoryRepository;
           _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var country = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            // var country = countryRepository.GetCountries();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

             var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

            //var country = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryOfOwner(int ownerId)
        {
       
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));

            //var country = _countryRepository.GetCountryByOwner(countryId);

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(ownerId);
        }
        
    }
}
