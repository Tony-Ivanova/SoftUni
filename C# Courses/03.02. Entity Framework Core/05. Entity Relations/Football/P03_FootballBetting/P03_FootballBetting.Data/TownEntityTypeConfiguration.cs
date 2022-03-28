namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TownEntityTypeConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder
                .HasKey(t => t.TownId);

            builder
            .Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired(true)
            .IsUnicode(true);

            builder
            .HasOne(t => t.Country)
            .WithMany(c => c.Towns)
            .HasForeignKey(t => t.CountryId);
        }
    }
}
