﻿using CHI.Infrastructure;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;

namespace CHI.ViewModels
{
    class NotificationDialogViewModel : DomainObject, IDialogAware
    {
        private string title;
        private string message;

        public string Title { get => title; set => SetProperty(ref title, value); }
        public string Message { get => message; set => SetProperty(ref message, value); }

        public event Action<IDialogResult> RequestClose;
        public DelegateCommand<ButtonResult?> CloseDialogCommand { get; }


        public NotificationDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<ButtonResult?>(CloseDialogExecute);
        }


        public void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("title");
            Message = parameters.GetValue<string>("message");
        }

        protected void CloseDialogExecute(ButtonResult? buttonResult)
        {
            RaiseRequestClose(new DialogResult(buttonResult.Value));
        }
    }
}
