using Prism;
using Prism.Ioc;
using Prism.Unity;
using VanishIM.Views;

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
            NavigationService.NavigateAsync($"ChatView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ChatView>();
        }
    }
}
