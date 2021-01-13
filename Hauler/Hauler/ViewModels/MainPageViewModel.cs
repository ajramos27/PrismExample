using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauler.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand _resetCommand;
        public DelegateCommand ResetCommand => _resetCommand ?? (_resetCommand = new DelegateCommand(Reset));

        private DelegateCommand _signInCommand;
        public DelegateCommand SignInCommand => _signInCommand ?? (_signInCommand = new DelegateCommand(SignIn));

        

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private async void SignIn()
        {
            await NavigationService.NavigateAsync("MenuPage");
        }

        private async void Reset()
        {
            await NavigationService.NavigateAsync("ResetPassword");
        }
    }
}
