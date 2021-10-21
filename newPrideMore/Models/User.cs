using System.ComponentModel.DataAnnotations;

namespace newPrideMore.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage ="É necessário informar um e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessário informar um Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "É necessário informar um CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Informe um CPF válido")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "É necessário informar um telefone de contato")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Informe um telefone válido")]
        public string Phone { get; set; }
        public string Instagram { get; set; }
        [Required(ErrorMessage = "É necessário informar uma senha")]
        [StringLength(8, MinimumLength =8, ErrorMessage ="Senha deve possuir 8 caracteres")]
        public string Password { get; set; }

        public User()
        {

        }

        public User(string email, string name, string cpf, string phone, string instagram, string password)
        {
            Email = email;
            Name = name;
            Cpf = cpf;
            Phone = phone;
            Instagram = instagram;
            Password = password;
        }
    }
}
