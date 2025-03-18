using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid TipoUsuarioID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O Titulo do tipo do usuario é obrigatório!")]
        public string? TituloTipoUsuario { get; set; }
    }
}
