namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasKey(t => t.TeamId);

            builder
            .Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired(true)
            .IsUnicode(true);

            builder
            .Property(t => t.LogoUrl)
            .HasMaxLength(250)
            .IsRequired(false)
            .IsUnicode(false);

            builder
            .Property(t => t.Initials)
            .HasMaxLength(3)
            .IsRequired(true)
            .IsUnicode(true);

            builder
            .Property(t => t.Budget)
            .IsRequired(true);

            builder
            .HasOne(t => t.PrimaryKitColor)
            .WithMany(c => c.PrimaryKitTeams)
            .HasForeignKey(t => t.PrimaryKitColorId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(t => t.SecondaryKitColor)
            .WithMany(c => c.SecondaryKitTeams)
            .HasForeignKey(t => t.SecondaryKitColorId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
