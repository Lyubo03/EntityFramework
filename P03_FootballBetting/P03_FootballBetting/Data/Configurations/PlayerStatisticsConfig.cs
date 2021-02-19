namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PlayerStatisticsConfig : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(b => new { b.PlayerId, b.GameId });

            builder
                .HasOne(b => b.Player)
                .WithMany(b => b.PlayerStatistics)
                .HasForeignKey(b => b.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Game)
                .WithMany(b => b.PlayerStatistics)
                .HasForeignKey(b => b.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}