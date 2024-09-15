namespace PersonnalApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PokeGameCategory> pokeGameCategories { get; set; }
    }
}
