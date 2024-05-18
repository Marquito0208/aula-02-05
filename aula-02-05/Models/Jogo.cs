using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_02_05.Models
{
    [Table("Tabela_Jogo")]
    public class Jogo
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Titulo_Do_Jogo")]
        public string Title { get; set; }

        [Required]
        [Column("Desenvolvedor_Do_Jogo")]
        public string Developer { get; set; }

        [Required]
        [Column("Data_De_Publicacao")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Column("Genero_Do_Jogo")]
        public string Gender { get; set; }

        [Required]
        [Column("Plataforma_Do_Jogo")]
        public DateTime Platform { get; set;}

        public ICollection<Avaliacao> Avaliations {  get; set; }

        public ICollection<Comentario> Comentario { get; set; }

    }
}
