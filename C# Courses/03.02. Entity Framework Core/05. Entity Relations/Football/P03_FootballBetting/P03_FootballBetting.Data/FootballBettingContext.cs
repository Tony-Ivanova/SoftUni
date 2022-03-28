namespace P03_FootballBetting.Data
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationString.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TeamEntityTypeConfiguration());

            builder.ApplyConfiguration(new ColorEntityTypeConfiguration());

            builder.ApplyConfiguration(new TownEntityTypeConfiguration());

            builder.ApplyConfiguration(new CountryEntityTypeConfiguration());

            builder.ApplyConfiguration(new PlayerEntityTypeConfiguration());

            builder.ApplyConfiguration(new PositionEntityTypeConfiguration());

            builder.ApplyConfiguration(new PlayerStatisticEntityTypeConfiguration());

            builder.ApplyConfiguration(new GameEntityTypeConfiguration());

            builder.ApplyConfiguration(new BetEntityTypeConfiguration());

            builder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }
    }
}
