namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class ColorEntityTypeConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
               .HasKey(c => c.ColorId);

            builder
            .Property(c => c.Name)
            .HasMaxLength(30)
            .IsRequired(true)
            .IsUnicode(true);
        }
    }
}
