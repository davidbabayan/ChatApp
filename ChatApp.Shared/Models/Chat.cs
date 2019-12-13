using System;
using System.Collections.Generic;

namespace ChatApp.Shared.Models
{
    public class Chat
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public User Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public List<Message> Messages { get; set; }
    }
}