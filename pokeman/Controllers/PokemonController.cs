using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokeman.Dto;
using pokeman.Interface;
using pokeman.Models;

namespace pokeman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository,IMapper mapper)
        {
            this._pokemonRepository = pokemonRepository;
            this. _mapper=mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokeMons() {

            var pokemon = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid) { 
               return BadRequest(ModelState);
            }

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}")]
        public IActionResult GetPokemon(int pokeId) {

            if (!_pokemonRepository.PokemonExcist(pokeId))
            {
                return NotFound();


            }
            var pokemons = _pokemonRepository.GetPokemon(pokeId);
            if (!ModelState.IsValid) {

                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }

        [HttpGet("{pokeId}/rating")]
        public IActionResult getPokemonRating(int pokeId) {

            if (!_pokemonRepository.PokemonExcist(pokeId)) {

                return NotFound();
            }

            var rating = _pokemonRepository.GetPokemonReting(pokeId);
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            return Ok(rating);
        }
         
    }
}
