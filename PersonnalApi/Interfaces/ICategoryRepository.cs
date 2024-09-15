using PersonnalApi.Models;

namespace PersonnalApi.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<PokeGame> GetPokeGameByCategory(int CategoryId);
        bool CategoryExist(int id);

    }
}
