using pokeman.Models;

namespace pokeman.Interface
{
    public interface ICatagory
    {
        ICollection<Category> GetCatagory();
        Category GetCatagory(int id);
        ICollection<Pokemon> GetPokemons(int catogoryId);
        bool CatagoryExists(int id);

    }
}
