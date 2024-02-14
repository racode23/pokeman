using pokeman.Data;
using pokeman.Interface;
using pokeman.Models;

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
            throw new NotImplementedException();
        }

        public decimal GetPokemonReting(int pokemonId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pokemon> GetPokemons() { 
        
           return context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExcist(int pokeId)
        {
            throw new NotImplementedException();
        }
    }
}
