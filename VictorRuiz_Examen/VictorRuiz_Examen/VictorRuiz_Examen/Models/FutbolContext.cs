using Microsoft.EntityFrameworkCore;

namespace VictorRuiz_Examen.Models
{
    public class FutbolContext : DbContext
    {
        public FutbolContext(DbContextOptions<FutbolContext> options)
            : base(options)
        {
        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipos");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NomEquipo)
                    .HasMaxLength(50)
                    .HasColumnName("nomEquipo");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.ToTable("Jugadores");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NomJugador)
                    .HasMaxLength(50)
                    .HasColumnName("nomJugador");
                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .HasColumnName("foto");
                entity.Property(e => e.NumGoles).HasColumnName("numGoles");
                entity.Property(e => e.EquipoId).HasColumnName("equipoId");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Jugadores)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jugadores_Equipos");
            });
        }
    }
}
