using EventPlus_.Domains;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

    [Table("Presenca")]
    public class Presenca
{
    [Key]
    public Guid PresencaID { get; set; }

    public Guid EventoID { get; set; }
    [ForeignKey("EventoID")]
    public Eventos Evento { get; set; }

    public Guid UsuarioID { get; set; }
    [ForeignKey("UsuarioID")]
    public Usuario Usuario { get; set; }

    [Column(TypeName = "BIT")]
    public bool? Situacao { get; set; }
}
    