using Prism;
using Prism.Ioc;
using Prism.Unity;
using VanishIM.Services;
using VanishIM.ViewModels;
using VanishIM.Views;
using Xamarin.Forms;

namespace VanishIM
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : this(initializer, true) { }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver) : base(initializer, setFormsDependencyResolver) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("NavigationPage/ChatView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ChatView, ChatViewModel>();

            containerRegistry.Register<IChatService, ChatService>();
        }
    }
}
