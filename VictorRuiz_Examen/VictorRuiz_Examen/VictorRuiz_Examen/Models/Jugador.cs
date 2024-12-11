using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VictorRuiz_Examen.Models
{
    [Table("Jugadores")]
    public class Jugador
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nomJugador")]
        [Required]
        [StringLength(50)]
        public string NomJugador { get; set; }

        [Column("foto")]
        [StringLength(50)]
        public string Foto { get; set; }

        [Column("numGoles")]
        public int NumGoles { get; set; }

        [Column("equipoId")]
        public int EquipoId { get; set; }

        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }
    }
}
