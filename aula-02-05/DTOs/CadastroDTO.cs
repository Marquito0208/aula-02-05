using System.ComponentModel.DataAnnotations.Schema;

namespace aula_02_05.DTOs
{
    public class CadastroDTO
    {

        [Required]

        public string UserName { get; set; }


        [Required]

        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)] 
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
   
        public string UserEmail { get; set; }

        [Required]

        public DateTime DateRegister { get; set; }

    }
}
