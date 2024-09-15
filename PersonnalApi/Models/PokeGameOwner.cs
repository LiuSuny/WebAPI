namespace PersonnalApi.Models
{
    public class PokeGameOwner
    {
        public  int PokeGameId { get; set; }
        public int OwnerId { get; set; }
        public PokeGame PokeGame { get; set; }
        public Owner Owner { get; set; }       

    }
}
