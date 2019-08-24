using System;
using System.ComponentModel.DataAnnotations;

namespace Yardy.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        

        public DateTime Dob { get; set; }
        
        public string Street { get; set; }
        
        public string City { get; set; }
        
        public string PostalCode { get; set; }

        public DateTime Created { get; set; }
    }
}