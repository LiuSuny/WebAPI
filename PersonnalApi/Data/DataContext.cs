using Microsoft.EntityFrameworkCore;
using PersonnalApi.Models;

namespace PersonnalApi.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<PokeGame> PokeGames { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokeGameOwner> PokaGameOwners { get; set; }
        public DbSet<PokeGameCategory> PokaGameCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Link PokeGameCategory to Category
            modelBuilder.Entity<PokeGameCategory>().HasKey(pc => new
            {
                pc.PokeGameId,
                pc.CategoryId
            });
            modelBuilder.Entity<PokeGameCategory>().HasOne(pc =>
                pc.PokeGame).WithMany(pc => pc.pokeGameCategories)
                .HasForeignKey(c => c.PokeGameId);

            modelBuilder.Entity<PokeGameCategory>().HasOne(pc =>
                pc.Category).WithMany(pc => pc.pokeGameCategories)
                .HasForeignKey(c => c.CategoryId);

            //Many to many for pokagameOwner to owner model
            modelBuilder.Entity<PokeGameOwner>().HasKey(po => new
            {
                po.PokeGameId,
                po.OwnerId
            });
            modelBuilder.Entity<PokeGameOwner>().HasOne(po =>
                po.PokeGame).WithMany(pc => pc.pokeGameOwners)
                .HasForeignKey(c => c.PokeGameId);
            modelBuilder.Entity<PokeGameOwner>().HasOne(po =>
                po.Owner).WithMany(po => po.pokeGameOwners)
                .HasForeignKey(o => o.OwnerId);
        }


    }
}
