using System;

namespace CollectionApp.api.Dtos
{

    public class UserForListDto
    {
        public int Id { get; set; }

        public string Username { get; set; }
        
        public string KnownAs { get; set; }

        public string PhotoUrl { get; set; }
    }    
}