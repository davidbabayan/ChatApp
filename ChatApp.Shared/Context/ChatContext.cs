using System.Collections.Generic;
using Newtonsoft.Json;
using ChatApp.Shared.Models;

namespace ChatApp.Shared.Context
{
    public class ChatContext
    {
        public List<Chat> Chats { get; set; }

        public ChatContext()
        {
            FileReader f = new FileReader(@"~/Data/Chat.json");
            if(f.ReadData() != "")
                Chats = JsonConvert.DeserializeObject<List<Chat>>(f.ReadData());
        }

        public void SaveChanges()
        {
            FileReader f = new FileReader(@"~/Data/Chat.json");
            f.WriteData(JsonConvert.SerializeObject(Chats));
        }
    }
}