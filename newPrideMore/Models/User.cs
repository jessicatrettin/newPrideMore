using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newPrideMore.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Instagram { get; set; }
        [Required]
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
