namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class GameConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> bet)
        {
            bet
                .HasOne(g => g.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}