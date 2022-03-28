namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {       
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (Configuration.ConfigurationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                .HasKey(p => p.PatientId);

                entity
                .Property(f => f.FirstName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode();

                entity
                .Property(l => l.LastName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode();

                entity
                .Property(a => a.Address)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode();

                entity
                .Property(e => e.Email)
                .HasMaxLength(80);

                entity
                .Property(i => i.HasInsurance)
                .IsRequired(true);

                entity
                .HasMany(p => p.Prescriptions)
                .WithOne(pt => pt.Patient)
                .HasForeignKey(pt => pt.PatientId);

            });

            modelBuilder
                .Entity<Visitation>(entity =>
                {
                    entity.HasKey(v => v.VisitationId);

                    entity
                    .Property(d => d.Date)
                    .IsRequired();

                    entity
                    .Property(c => c.Comments)
                    .HasMaxLength(250)
                    .IsUnicode();

                    entity
                    .HasOne(p => p.Patient)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(p => p.PatientId);
                });

            modelBuilder
                .Entity<Diagnose>(entity =>
                {
                    entity
                    .HasKey(d => d.DiagnoseId);

                    entity
                    .Property(n => n.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode();

                    entity
                    .Property(c => c.Comments)
                    .HasMaxLength(250)
                    .IsRequired(true)
                    .IsUnicode();

                    entity
                    .HasOne(p => p.Patient)
                    .WithMany(d => d.Diagnoses)
                    .HasForeignKey(p => p.PatientId);
                });

            modelBuilder
                .Entity<Medicament>(entity =>
                {
                    entity
                    .HasKey(m => m.MedicamentId);

                    entity
                    .Property(n => n.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode();

                    entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(m => m.Medicament)
                    .HasForeignKey(m => m.MedicamentId);
                });

            modelBuilder
                .Entity<PatientMedicament>(entity =>
                {
                    entity.HasKey(sc => new
                    {
                        sc.PatientId,
                        sc.MedicamentId
                    });
                });

            modelBuilder
                .Entity<Doctor>(entity =>
                {
                    entity.HasKey(d => d.DoctorId);

                    entity
                    .Property(n => n.Name)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode();

                    entity
                    .Property(s => s.Specialty)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode();

                    entity
                    .HasMany(v => v.Visitations)
                    .WithOne(d => d.Doctor)
                    .HasForeignKey(d => d.DoctorId);
                });
        }
    }
}
