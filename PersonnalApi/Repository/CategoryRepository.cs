using AutoMapper;
using PersonnalApi.Data;
using PersonnalApi.Interfaces;
using PersonnalApi.Models;

namespace PersonnalApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<PokeGame> GetPokeGameByCategory(int CategoryId)
        {
            return _context.PokaGameCategories.Where(p => p.CategoryId
            == CategoryId).Select(s => s.PokeGame).ToList();
        }
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }
    }
}
