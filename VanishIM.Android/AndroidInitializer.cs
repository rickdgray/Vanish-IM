using Prism;
using Prism.Ioc;

namespace VanishIM.Droid
{
    class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //example:
            //containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }
    }
}