using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newPrideMore.Models
{
    public class Professional : User
    {
        [Required]
        public string Register { get; set; }
        [Required]
        public ProfessionalType ProfessionalType { get; set; }
        [Required]
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
