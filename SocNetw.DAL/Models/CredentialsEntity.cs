using SocNetw.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetw.DAL.Models
{
    [Table("CredentialsEntities")]
    public class CredentialsEntity : Credentials
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public override string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public override string Password { get; set; }

        [Required]
        public int AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public AccountEntity AccountEntity { get; set; }

        public static CredentialsEntity MapFromModel(Credentials credentials)
        {
            var result = new CredentialsEntity()
            {
                Login = credentials.Login,
                Password = credentials.Password
            };
            return result;
        }
    }
}
