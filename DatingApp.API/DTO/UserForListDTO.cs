using System;

namespace DatingApp.API.DTO
{   
    // This will help us the return only the properties which we want user to return in the list
    public class UserForListDTO
    {
         public int Id { get; set; }

        public string Username { get; set; }

        public string  Gender { get; set; }

        public int Age { get; set; }

        public string KnownAs { get; set; }

        public string Interests { get; set; }

        public string City{ get; set; }

        public string Country { get; set; }

        public DateTime CreateDate  { get; set; }

        public DateTime LastActive { get; set; }

        public string PhotoURL { get; set; }
    }
}