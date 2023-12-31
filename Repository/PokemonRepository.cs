using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(PokemonAPI.Data.DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetPokemon()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if(review.Count() == 0)
                return 0;
            return ((decimal) review.Sum(p => p.Rating)/review.Count());
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Count() != 0;
        }
    }
}