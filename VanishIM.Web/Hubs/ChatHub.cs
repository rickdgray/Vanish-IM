using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using VanishIM.Models;

namespace VanishIM.Web.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task<IList<Message>> GetMessages()
        {
            await Task.Delay(100);

            return new List<Message>
            {
                new Message
                {
                    color = Color.Black,
                    message = "test previous message"
                },
                new Message
                {
                    color = Color.DarkBlue,
                    message = "another test"
                }
            };
        }
    }
}
