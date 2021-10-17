using System.ComponentModel.DataAnnotations;

namespace newPrideMore.Models
{
    public class Professional : User
    {
        [Required(ErrorMessage = "É necessário informar o registro do profissional")]
        public string Register { get; set; }
        [Required(ErrorMessage = "É necessário selecionar a especialidade do profissional")]
        public ProfessionalType ProfessionalType { get; set; }
        public int ProfessionalTypeId { get; set; }

        [Required(ErrorMessage = "É necessário informar um endereço de atendimento")]
        public string Address { get; set; }
        public string HealthInsurance { get; set; }

        public Professional()
        {

        }

        public Professional(string register, ProfessionalType professionalType, string address, string healthInsurance)
        {
            Register = register;
            ProfessionalType = professionalType;
            Address = address;
            HealthInsurance = healthInsurance;
        }
    }
}
