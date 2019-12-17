using System.Collections.Generic;
using System.Linq;
using ChatApp.Shared.Context;
using ChatApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class ChatsController : ControllerBase
    {
        private UserContext userContext;
        private ChatContext chatContext;

        public ChatsController()
        {
            userContext = new UserContext();
            chatContext = new ChatContext();
        }

        [HttpGet]
        public List<Chat> GetChats()
        {
            if(IsRealUser(Request) != null)
                return chatContext.Chats;

            return new List<Chat>();
        }

        [HttpGet]
        public Chat GetChat(string name)
        {
            if(IsRealUser(Request) != null)
                return chatContext.Chats.Where(c => c.Name == name).FirstOrDefault();
                
            return new Chat();
        }

        [HttpPost]
        public Chat CreateChat(Chat chat)
        {
            return chat;
        }

        [HttpPost]
        public Chat AddMessage(string chatname, Message message)
        {
            return new Chat();
        }

        private User IsRealUser(HttpRequest request)
        {
            string username = request.Headers
                .Where(k => k.Key.ToLower() == "username").FirstOrDefault().Value;
            string password = request.Headers
                .Where(k => k.Key.ToLower() == "password").FirstOrDefault().Value;
            return userContext.Users.Where(u => u.Username == username && u.Password == password).First();
        }
    }
}