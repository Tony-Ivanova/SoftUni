namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(c => c.CountryId);

            builder
            .Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired(true)
            .IsUnicode(true);
        }
    }
}
