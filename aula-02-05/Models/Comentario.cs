using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_02_05.Models
{
    [Table("Tabela_De_Comentario")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string useId { get; set; }


        [ForeignKey("UseId")]
        public Usuario? usuario { get; set; }


        [Required]
        public int AvaliationId { get; set; }


        [ForeignKey("AvaliationId")]
        public Avaliacao? Avaliacao { get; set; }


        [Required]
        public int JogoId { get; set; }

        [ForeignKey("JogoId")]
        public string Jogo { get; set;}

        [Required]
        [Column("Texto_Do_Comentario")]
        public string TxtAvaliation { get; set; }

        [Required]
        [Column("Data_De_Postagem")]
        public DateTime DtPostagem { get; set; }

        [Required]
        public DateTime DtComentario { get; set; }  


    }
}
