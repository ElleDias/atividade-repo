using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_.Domains
{
    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Key]
        public Guid TipoEventoID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O titulo do tipo evento é obrigatório!")]
        public string? TituloTipoEvento { get; set; }

    }
}
