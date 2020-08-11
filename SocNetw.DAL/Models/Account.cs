using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetw.DAL.Models
{
    public enum GenderType
    {
        Male,
        Female,
        Custom
    }
    public class Account
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public byte[] Image { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email {get; set; }
        public string PhoneNubmer { get; set; }
        public string TitleDescription { get; set; }
        public string Description { get; set; }

        public Credentials Credentials { get; set; }
    }
}
