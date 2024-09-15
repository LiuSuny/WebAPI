
using System.Reflection;

namespace PersonnalApi.Models
{
    public class PokeGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
       public IEnumerable<Review> Reviews { get; set; }
     public IEnumerable<PokeGameCategory> pokeGameCategories { get; set; }
     public IEnumerable<PokeGameOwner> pokeGameOwners { get; set; }

    }
}
