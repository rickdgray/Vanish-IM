using Prism.Commands;
using Prism.Navigation;
using System.Drawing;
using VanishIM.Models;
using VanishIM.Services;

namespace VanishIM.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        readonly IChatService _chatService;

        string _title = "Chat";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        string _text = "";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public DelegateCommand SendCommand { get; set; }

        public ChatViewModel(IChatService chatService)
        {
            _chatService = chatService;

            SendCommand = new DelegateCommand(Send);
        }

        async void Send()
        {
            await _chatService.Connect().ConfigureAwait(false);

            var test = await _chatService.GetMessages().ConfigureAwait(false);

            _chatService.SendMessage(new Message
            {
                Color = Color.Red,
                MessageText = Text
            });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}
