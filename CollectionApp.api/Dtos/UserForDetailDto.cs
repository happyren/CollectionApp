using System;
using System.Collections.Generic;
using CollectionApp.api.Models;

namespace CollectionApp.api.Dtos
{
    
    public class UserForDetailDto
    {
        
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime Created { get; set; }

        public string KnownAs { get; set; }

        public string Introduction { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<PhotoForDetailDto> Photos { get; set; }
    }
}