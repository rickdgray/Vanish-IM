using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using VanishIM.Models;

namespace VanishIM.Services
{
    public class ChatService : IChatService
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _chat;

        private List<IDisposable> chatHandlers;

        public ChatService()
        {
            _connection = new HubConnection("http://192.168.1.250:44330");
            _connection.TraceLevel = TraceLevels.All;
            _connection.TraceWriter = Console.Out;
            _chat = _connection.CreateHubProxy("chat");

            chatHandlers = new List<IDisposable>();
        }

        public async void Connect()
        {
            chatHandlers.Add(_chat.On<Message>("ReceiveMessage", m =>
            {
                Console.WriteLine(m.MessageText);
            }));

            await _connection.Start();
        }

        public void Disconnect()
        {
            _connection.Stop();

            foreach (var handler in chatHandlers)
                handler.Dispose();
        }

        public async Task<IList<Message>> GetMessages()
        {
            return await _chat.Invoke<IList<Message>>("GetMessages");
        }

        public async void SendMessage(Message message)
        {
            await _chat.Invoke("SendMessage", message);
        }

        //TODO: handle connection issues with signalr lifecycle
        //ConnectionSlow
        //Reconnecting
        //etc
    }
}