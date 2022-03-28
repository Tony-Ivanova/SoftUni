namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
               .HasKey(p => p.PlayerId);

            builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(true)
            .IsUnicode(true);

            builder
            .Property(p => p.SquadNumber)
            .IsRequired(true)
            .IsUnicode(false);

            builder
            .Property(p => p.IsInjured)
            .IsRequired(true);

            builder
            .HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamId);

            builder
            .HasOne(p => p.Position)
            .WithMany(po => po.Players)
            .HasForeignKey(p => p.PositionId);
        }
    }
}
