using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using VanishIM.Models;

namespace VanishIM.Services
{
    public sealed class ChatService : IChatService, IDisposable
    {
        private HubConnection _connection;
        private IHubProxy _chat;

        private readonly List<IDisposable> chatHandlers;

        public ChatService()
        {
            chatHandlers = new List<IDisposable>();
        }

        public async Task Connect()
        {
            _connection = new HubConnection("http://192.168.1.250:54960")
            {
                TraceLevel = TraceLevels.All,
                TraceWriter = Console.Out
            };

            _chat = _connection.CreateHubProxy("chat");

            chatHandlers.Add(_chat.On<Message>("ReceiveMessage", m =>
            {
                Console.WriteLine(m.MessageText);
            }));

            await _connection.Start().ContinueWith(t =>
            {
                Console.WriteLine(t.Exception.Message);
            }, TaskContinuationOptions.OnlyOnFaulted).ConfigureAwait(false);
        }

        public void Disconnect()
        {
            _connection.Stop();

            foreach (var handler in chatHandlers)
                handler.Dispose();
        }

        public async Task<IList<Message>> GetMessages()
        {
            return await _chat.Invoke<IList<Message>>("GetMessages").ConfigureAwait(false);
        }

        public async void SendMessage(Message message)
        {
            await _chat.Invoke("SendMessage", message).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        //TODO: handle connection issues with signalr lifecycle
        //ConnectionSlow
        //Reconnecting
        //etc
    }
}