using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Family { get; set; }
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
        [EmailAddress]
        [StringLength(250)]
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
