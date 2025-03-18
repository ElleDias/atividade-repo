using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_.Domains
{
    [Table("Eventos")]
    public class Eventos
    {
        [Key]
        public Guid EventosID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome do evento é obrigatório!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do evento obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }


        [Required(ErrorMessage = "O evento é obrigatório")]
        public Guid TipoEventoID { get; set; }

        [ForeignKey("TipoEventoID")]
        public TipoEvento? TipoEvento { get; set; }


        [Required(ErrorMessage = "A instituição é obrigatório")]
        public Guid InstituicaoID { get; set; }

        [ForeignKey("InstituicaoID")]
        public Instituicao? Instituicao { get; set; }


        public Presenca? Presenca { get; set; }


    }
}
