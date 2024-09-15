using PersonnalApi.Models;

namespace PersonnalApi.Interfaces
{
    public interface IPokeGameRepository
    {
        ICollection<PokeGame> GetPokeGames();
        PokeGame GetPokeGame(int id);
        PokeGame GetPokeGame(string name);
        decimal GetPokeGameRating(int pokeId);
        bool PokeGameExists(int pokeId);
    }
}
