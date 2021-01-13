using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hauler.ViewModels
{
    public class ResetPasswordViewModel : ViewModelBase
    {
        private DelegateCommand _resetCommand;
        private IPageDialogService _dialogService;

        public DelegateCommand ResetCommand => _resetCommand ?? (_resetCommand = new DelegateCommand(Reset));

        private async void Reset()
        {
            await _dialogService.DisplayAlertAsync("Password Reset", "Email sent", "Ok");
            await NavigationService.GoBackAsync();
        }

        public ResetPasswordViewModel(INavigationService navigationService, IPageDialogService dialogService) 
            : base(navigationService)
        {
            Title = "Reset Password";
            _dialogService = dialogService;
        }
    }
}
