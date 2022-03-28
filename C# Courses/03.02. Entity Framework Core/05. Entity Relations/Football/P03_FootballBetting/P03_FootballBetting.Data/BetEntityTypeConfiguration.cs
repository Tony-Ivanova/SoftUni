namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetEntityTypeConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(b => b.BetId);

            builder
            .Property(b => b.Amount)
            .IsRequired(true);

            builder
           .Property(b => b.Prediction)
           .IsRequired(true);

            builder
           .Property(b => b.DateTime)
           .IsRequired(true);

            builder
            .HasOne(b => b.User)
            .WithMany(u => u.Bets)
            .HasForeignKey(b => b.UserId);

            builder
            .HasOne(b => b.Game)
            .WithMany(g => g.Bets)
            .HasForeignKey(b => b.GameId);
        }
    }
}
