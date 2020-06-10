using System;
using System.Collections.Generic;

namespace CollectionApp.api.Models
{
    public class User {
        
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime Created { get; set; }

        public string KnownAs { get; set; }

        public string Introduction { get; set; }

        public string Gender { get; set; } = "others";
        
        public DateTime LastActive { get; set; }

        public ICollection<UserPhoto> Photos { get; set; }

        public ICollection<Like> Likees { get; set; }
    }
}