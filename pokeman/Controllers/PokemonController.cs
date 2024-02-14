using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokeman.Interface;
using pokeman.Models;

namespace pokeman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this._pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokeMons() {

            var pokemon = _pokemonRepository.GetPokemons();

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
