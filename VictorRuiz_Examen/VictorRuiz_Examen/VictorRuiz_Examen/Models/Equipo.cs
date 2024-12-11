using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VictorRuiz_Examen.Models
{
    [Table("Equipos")]
    public class Equipo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nomEquipo")]
        [Required]
        [StringLength(50)]
        public string NomEquipo { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
    }
}
