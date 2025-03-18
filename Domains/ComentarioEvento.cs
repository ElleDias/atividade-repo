using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid ComentarioEventoID { get; set; }

        [Column(TypeName = "BIT")]
        public bool? Exibe { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do evento obrigatória!")]
        public string? Descricao { get; set; }


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
