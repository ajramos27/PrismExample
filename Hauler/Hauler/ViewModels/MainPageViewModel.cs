using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismExample.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauler.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }


        private DelegateCommand _resetCommand;
        public DelegateCommand ResetCommand => _resetCommand ?? (_resetCommand = new DelegateCommand(Reset));

        private DelegateCommand _signInCommand;
        public DelegateCommand SignInCommand => _signInCommand ?? (_signInCommand = new DelegateCommand(SignIn));

        

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _email = new ValidatableObject<string>();
            AddValidations();
            Title = "Main Page"; 
        }

        private void SignIn()
        {
            Validate();
            //await NavigationService.NavigateAsync("MenuPage");
        }

        private async void Reset()
        {
            await NavigationService.NavigateAsync("ResetPassword");
        }

        private void AddValidations()
        {
            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "An email is required." });

        }

        private bool Validate()
        {
            bool isValidEmail = _email.Validate();

            return isValidEmail;

        }
    }
}
