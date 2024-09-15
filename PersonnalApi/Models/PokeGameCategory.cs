namespace PersonnalApi.Models
{
    public class PokeGameCategory
    {
        public  int PokeGameId { get; set; }
        public int CategoryId { get; set; }
        public PokeGame PokeGame { get; set; }
        public Category Category { get; set; }


    }
}
