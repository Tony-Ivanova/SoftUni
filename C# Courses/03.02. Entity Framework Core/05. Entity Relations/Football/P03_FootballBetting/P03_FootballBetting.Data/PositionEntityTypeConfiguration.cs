using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class PositionEntityTypeConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasKey(po => po.PositionId);

            builder
            .Property(po => po.Name)
            .HasMaxLength(20)
            .IsRequired(true)
            .IsUnicode(true);
        }
    }
}
