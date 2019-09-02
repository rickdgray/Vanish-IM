using System;
using System.Threading.Tasks;
using Prism;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace VanishIM.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware, IInitialize, IInitializeAsync, IDestructible, IConfirmNavigation, IConfirmNavigationAsync, IPageLifecycleAware, IActiveAware
    {
        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        public event EventHandler IsActiveChanged;

        public bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }

        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return Task.FromResult(true);
        }

        public void Destroy()
        {
            //destroy
        }

        public void Initialize(INavigationParameters parameters)
        {
            //init
        }

        public Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public void OnAppearing()
        {
            //appear
        }

        public void OnDisappearing()
        {
            //disappear
        }

        public abstract void OnNavigatedFrom(INavigationParameters parameters);

        public abstract void OnNavigatedTo(INavigationParameters parameters);
    }
}
