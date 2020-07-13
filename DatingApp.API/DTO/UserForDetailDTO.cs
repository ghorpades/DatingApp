using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.DTO
{   
    // Details for the list of specific user
    public class UserForDetailDTO
    {
         public int Id { get; set; }

        public string Username { get; set; }


        public string  Gender { get; set; }

        public int Age { get; set; }

        public string KnownAs { get; set; }

        public string Introduction { get; set; }

        public string Interests { get; set; }

        public string City{ get; set; }

        public string Country { get; set; }

        public DateTime CreateDate  { get; set; }

        public DateTime LastActive { get; set; }

        public string PhotoURL { get; set; }

        public ICollection<PhotosForDetailedDTO> Photos { get; set; }
    }
}