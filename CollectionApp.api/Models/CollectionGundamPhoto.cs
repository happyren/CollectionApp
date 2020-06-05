using System;

namespace CollectionApp.api.Models
{
    public class CollectionGundamPhoto : Photo
    {
        public CollectionGundam collectionGundam { get; set; }

        public int collectionGundamId { get; set; }
    }
}