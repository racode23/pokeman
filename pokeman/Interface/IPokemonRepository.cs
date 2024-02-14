using pokeman.Models;

namespace pokeman.Interface
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);

        decimal GetPokemonReting(int pokemonId);

        bool PokemonExcist(int pokeId);
    }
}
