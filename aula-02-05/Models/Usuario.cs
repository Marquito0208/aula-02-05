using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_02_05.Models
{
    [Table("Tabela_usuario")]
    public class Usuario
    {
        [Key]
         public int Id { get; set; }

        [Required]
        [Column("Nome_De_Usuario")]
        public string UserName { get; set; }


        [Required]
        [Column("Nick")]
        public string Nickname{ get; set; }

        [Required]
        [Column("Foto_De_Perfil")]
        public string FotoUrl { get; set; }


        [Required]
        [Column("Hash_da_senha")]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email")]
        public string UserEmail { get; set;}

        [Required]
        [Column("Data_Do_Registro")]
        public DateTime DateRegister { get; set; }



        public ICollection<Avaliacao> Avaliations { get; set; }

        public ICollection<Comentario> Comentario { get; set; }

        [Required]
        [Column("Usuario_Ativo")]
        public bool IsActive { get; set; } = true;
    }
}
