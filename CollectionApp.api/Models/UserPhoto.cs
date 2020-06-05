using System;

namespace CollectionApp.api.Models
{
    public class UserPhoto : Photo
    {
        public User user { get; set; }

        public int UserId { get; set; }
    }
}