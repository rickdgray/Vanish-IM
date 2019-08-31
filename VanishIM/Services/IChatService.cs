﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VanishIM.Models;

namespace VanishIM.Services
{
    public interface IChatService
    {
        void Connect();
        void Disconnect();
        Task<IList<Message>> GetMessages();
        void SendMessage(Message message);
    }
}