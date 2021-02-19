namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    public class FootballBettingContext : DbContext
    {
        DbSet<Team> Teams { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Town> Towns { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Bet> Bets { get; set; }
        DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-2RO7KG1\SQLEXPRESS;Database=FootballBettingSystem;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FootballBettingContext).Assembly);
    }
}