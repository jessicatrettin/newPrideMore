using System.ComponentModel.DataAnnotations;

namespace newPrideMore.Models
{
    public class EmailModel
    {
        public string Nome { get; set; }
        [Required, Display(Name = "Nome")]
        public string Email { get; set; }
        [Required, Display(Name = "Email")]
        public string Destino { get; set; }
        [Required, Display(Name = "Assunto")]

        public string Assunto { get; set; }
        [Required, Display(Name = "Mensagem")]
        public string Mensagem { get; set; }
    }
}
