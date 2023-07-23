using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Repository;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonrepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonrepository, IMapper mapper)
        {
            _pokemonrepository = pokemonrepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemon()
        {
            var pokemon = _mapper.Map<List<PokemonDto>>(_pokemonrepository.GetPokemon());
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            else 
                return Ok(pokemon);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200,Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            //validation pokemon actually exists
            if(!_pokemonrepository.PokemonExists(pokeId))
                return NotFound();
            
            var pokemon = _mapper.Map<PokemonDto>(_pokemonrepository.GetPokemon(pokeId));
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            else 
                return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetRating(int pokeId)
        {
            if(!_pokemonrepository.PokemonExists(pokeId))
                return NotFound();
            
            decimal rating = _pokemonrepository.GetPokemonRating(pokeId);
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            else
                return Ok(rating);
        }

    }
}