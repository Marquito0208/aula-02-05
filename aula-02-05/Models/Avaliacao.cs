using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_02_05.Models
{
    [Table("Tabela_Avaliacao")]
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set;}

        [Required]
        public int JogoId { get; set; }

  
        [ForeignKey("JogoId")]
        public Jogo? jogo { get; set;}

        [Required]
        [Column("Classificacao_Do_Jogo")]
        [Range(1,10)]
        public string Classification { get; set;}

        [Required]
        [Column("Conteudo_Da_Avaliacao")]
        public string TxtAvaliation { get; set;}

        [Required]
        [Column("Data_De_Postagem")]
        public DateTime? Date { get; set; }
    }
}
