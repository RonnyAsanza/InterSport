using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterSport.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RestorePassword { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
