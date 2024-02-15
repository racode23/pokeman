using pokeman.Data;
using pokeman.Interface;
using pokeman.Models;
using System.Reflection.Metadata.Ecma335;

namespace pokeman.Repository
{
    public class CategoryRepository : ICatagory
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public bool CatagoryExists(int id)
        {
            return _dataContext.Categories.any(c => c.Id == id);
        }

        public ICollection<Category> GetCatagory()
        {
            return _dataContext.Categories.ToList();
        }

        public Category GetCatagory(int Id)
        {
            return _dataContext.Categories.Where(c=>c.Id==Id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemons(int catogoryId)
        {
            return _dataContext.PokemonCategories.Where(c => c.CategoryId == catogoryId).Select(c => c.Pokemon).ToList();
        }
    }
}
