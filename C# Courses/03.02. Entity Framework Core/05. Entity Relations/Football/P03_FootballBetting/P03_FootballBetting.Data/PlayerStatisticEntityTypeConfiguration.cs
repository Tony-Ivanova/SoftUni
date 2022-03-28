namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticEntityTypeConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder
                .HasKey(ps => new { ps.GameId, ps.PlayerId });

            builder
            .Property(ps => ps.ScoredGoals)
            .IsRequired(true);

            builder
            .Property(ps => ps.Assists)
            .IsRequired(true);

            builder
            .Property(ps => ps.MinutesPlayed)
            .IsRequired(true);

            builder
            .HasOne(ps => ps.Game)
            .WithMany(g => g.PlayerStatistics)
            .HasForeignKey(ps => ps.GameId);

            builder
            .HasOne(ps => ps.Player)
            .WithMany(p => p.PlayerStatistics)
            .HasForeignKey(ps => ps.PlayerId);
        }
    }
}
