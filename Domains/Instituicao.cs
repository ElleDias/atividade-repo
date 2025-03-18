using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Domains
{
    [Table("Instituicao")]
    [Index(nameof(Cnpj), IsUnique  = true)]
    public class Instituicao
    {
        [Key]
        public Guid InstituicaoID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome da fantasia é obrigatório")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "A Cnpj é obrigatória")]
        [StringLength(14)]
        public string? Cnpj { get; set; }

    }
}
