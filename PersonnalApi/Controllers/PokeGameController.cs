using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonnalApi.Dto;
using PersonnalApi.Interfaces;
using PersonnalApi.Models;

namespace PersonnalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeGameController : Controller
    {
        private readonly IPokeGameRepository _pokeGameRepository;
        private readonly IMapper _mapper;
        public PokeGameController(IPokeGameRepository pokeGameRepository, IMapper mapper)
        {
            _pokeGameRepository = pokeGameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokeGame>))]
        public IActionResult GetPokeGames()
        {
            var pokegame = _mapper.Map<List<PokeGameDto>>(_pokeGameRepository.GetPokeGames());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokegame);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(PokeGame))]
        [ProducesResponseType(400)]
        public IActionResult GetPokeGame(int pokeId)
        {
            if (!_pokeGameRepository.PokeGameExists(pokeId))
                return NotFound();

            var pokeGame = _mapper.Map<List<PokeGameDto>>(_pokeGameRepository.GetPokeGame(pokeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokeGame);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokeGameRating(int pokeId)
        {
            if (!_pokeGameRepository.PokeGameExists(pokeId))
                return NotFound();
            var rating = _pokeGameRepository.GetPokeGameRating(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(rating);
        }
    }
}
