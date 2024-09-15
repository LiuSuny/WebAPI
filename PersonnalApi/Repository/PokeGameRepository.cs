using PersonnalApi.Data;
using PersonnalApi.Interfaces;
using PersonnalApi.Models;

namespace PersonnalApi.Repository
{
    public class PokeGameRepository :IPokeGameRepository
    {
        private readonly DataContext _context;

        public PokeGameRepository(DataContext context)
        {
            _context = context;
        }
       
        public PokeGame GetPokeGame(int id)
        {
            return _context.PokeGames.Where(p => p.Id == id).FirstOrDefault();
        }

        public PokeGame GetPokeGame(string name)
        {
            return _context.PokeGames.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokeGameRating(int pokeId)
        {
            var review= _context.Reviews.Where(p => p.PokeGame.Id == pokeId);
            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }
        public ICollection<PokeGame> GetPokeGames()
        {
            return _context.PokeGames.OrderBy(p => p.Id).ToList();
        }

        public bool PokeGameExists(int pokeId)
        {
            return _context.PokeGames.Any(p => p.Id == pokeId);
        }
    }
}
