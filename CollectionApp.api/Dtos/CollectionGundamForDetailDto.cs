using System;
using System.Collections.Generic;

namespace CollectionApp.api.Dtos
{
    
    public class CollectionGundamForDetailDto
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public DateTime LaunchDate { get; set; }

        public string Brand { get; set; }

        public string Grade { get; set; }

        public string Series { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<PhotoForDetailDto> Photos { get; set; }        
    }
}