using System;
using System.Collections.Generic;

namespace CollectionApp.api.Models
{
    
    public class CollectionGundam
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public DateTime LaunchDate { get; set; }

        public string Brand { get; set; }

        public string Grade { get; set; }

        public string Series { get; set; }

        public ICollection<Like> Likers { get; set; }
        public ICollection<CollectionGundamPhoto> Photos { get; set; }
    }
}