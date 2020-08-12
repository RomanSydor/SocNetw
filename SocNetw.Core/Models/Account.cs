using System;
using System.Collections.Generic;
using System.Text;

namespace SocNetw.Core.Models
{
    public enum GenderType
    {
        Male,
        Female,
        Custom
    }
    public class Account
    {
        public virtual Guid UniqueID { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual GenderType Gender { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNubmer { get; set; }
        public virtual string TitleDescription { get; set; }
        public virtual string Description { get; set; }
    }
}
