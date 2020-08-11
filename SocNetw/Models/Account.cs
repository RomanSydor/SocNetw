using System;

namespace SocNetw
{
    public class Account
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Email {get; set; }
        public string PhoneNubmer { get; set; }
        public string TitleDescrioption { get; set; }
        public string Descrioption { get; set; }
    }
}
