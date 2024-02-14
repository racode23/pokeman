using pokeman.Data;
using pokeman.Interface;
using pokeman.Models;
using System.Net.Mime;

namespace pokeman.Repository
{
    public class PokemonRepository: IPokemonRepository
    {
        private readonly DataContext context;
        public PokemonRepository(DataContext _context)
        {
            context = _context;
        }

        public Pokemon GetPokemon(int id)
        {
            return context.Pokemon.Where(p=>p.Id==id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return context.Pokemon.Where(c => c.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonReting(int pokemonId)
        {
           var review= context.Reviews.Where(c => c.Pokemon.Id == pokemonId);

            if (review.Count() <= 0) {

                return 0;
            }

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
             
        }

        public ICollection<Pokemon> GetPokemons() { 
        
           return context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExcist(int pokeId)
        {
            return context.Pokemon.Any(p => p.Id == pokeId);
        }
    }
}
