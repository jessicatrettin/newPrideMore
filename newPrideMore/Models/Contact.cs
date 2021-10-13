using newPrideMore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newPrideMore.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public ContactReason ContactReason{ get; set; }
        [Required]
        public string Message { get; set; }

        public Contact()
        {

        }

        public Contact(int id, string email, string name, ContactReason contactReason, string message)
        {
            Id = id;
            Email = email;
            Name = name;
            ContactReason = contactReason;
            Message = message;
        }
    }
}
