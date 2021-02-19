namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    using System;
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> team)
        { 
            team
            .HasOne(t => t.PrimaryKitColor)
            .WithMany(c => c.PrimaryKitTeams)
            .HasForeignKey(t => t.PrimaryKitColorId)
               .OnDelete(DeleteBehavior.Restrict);

            team
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            team
                .HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            team
                .HasMany(t => t.HomeGames)
                .WithOne(t => t.HomeTeam)
                .HasForeignKey(t => t.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            team
                .HasMany(t => t.AwayGames)
                .WithOne(t => t.AwayTeam)
                .HasForeignKey(t => t.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            team
                .HasMany(t => t.Players)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}