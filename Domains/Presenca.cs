using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_.Domains
{
    [Table("Presenca")]
    public class Presenca
    {
        [Key]
        public Guid PresencaID { get; set; }

        [Column(TypeName = "BIT")]
        public bool? Situacao { get; set; }


        [Required(ErrorMessage = "O usuario é obrigatório")]
        public Guid UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuario? Usuario { get; set; }


        [Required(ErrorMessage = "O evento é obrigatório")]
        public Guid EventosID { get; set; }

        [ForeignKey("EventosID")]
        public Eventos? Eventos { get; set; }
    }
}
