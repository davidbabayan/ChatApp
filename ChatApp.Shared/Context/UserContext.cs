using System.Collections.Generic;
using Newtonsoft.Json;
using ChatApp.Shared.Models;

namespace ChatApp.Shared.Context
{
    public class UserContext
    {
        public List<User> Users { get; set; }
        public UserContext()
        {
            FileReader f = new FileReader(@"~/Data/Users.json");
            if (f.ReadData() != "")
                Users = JsonConvert.DeserializeObject<List<User>>(f.ReadData());
        }
    }
}