using SocNetw.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetw.DAL.Models
{
    [Table("AccountEntities")]
    public class AccountEntity : Account
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public byte[] Image { get; set; }

        [Required]
        public override Guid UniqueID { get; set; }

        [Required]
        public override string FirstName { get; set; }

        [Required]
        public override string LastName { get; set; }

        public override GenderType Gender { get; set; }
        public override DateTime DateOfBirth { get; set; }
        public override string Email {get; set; }
        public override string PhoneNubmer { get; set; }
        public override string TitleDescription { get; set; }
        public override string Description { get; set; }

        public CredentialsEntity CredentialsEntity { get; set; }

        internal static Account MapToModel(AccountEntity account)
        {
            var result = new Account()
            {
                UniqueID = account.UniqueID,
                FirstName = account.FirstName,
                DateOfBirth = account.DateOfBirth,
                Description = account.Description,
                Email = account.Email,
                Gender = account.Gender,
                LastName = account.LastName,
                PhoneNubmer = account.PhoneNubmer,
                TitleDescription = account.TitleDescription
            };
            return result;
        }

        internal static AccountEntity MapFromModel(Account account)
        {
            var result = new AccountEntity()
            {
                UniqueID = account.UniqueID,
                FirstName = account.FirstName,
                DateOfBirth = account.DateOfBirth,
                Description = account.Description,
                Email = account.Email,
                Gender = account.Gender,
                LastName = account.LastName,
                PhoneNubmer = account.PhoneNubmer,
                TitleDescription = account.TitleDescription
            };
            return result;
        }
    }
}
