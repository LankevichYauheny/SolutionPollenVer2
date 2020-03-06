﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;
using System.Security;
using Pollen.Dialogs.DelExistingItem;
using Pollen.Infrastructure;
using Pollen.Interfaces;
using Pollen.ViewModels;
using Pollen.Views;

namespace Pollen
{
    public class AuthenticationViewModel : ViewModelBase, IViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly RelayCommand _loginCommand;
        private readonly RelayCommand _logoutCommand;
        private readonly RelayCommand _showViewCommand;
        private string _username;
        private string _status;

        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _loginCommand = new RelayCommand(Login, CanLogin);
            _logoutCommand = new RelayCommand(Logout, CanLogout);
            _showViewCommand = new RelayCommand(ShowView, null);
        }

        #region Properties
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole("Administrators") ? "You are an administrator!"
                              : "You are NOT a member of the administrators group.");

                return "Not authenticated!";
            }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }
        #endregion

        #region Commands
        public RelayCommand LoginCommand { get { return _loginCommand; } }

        public RelayCommand LogoutCommand { get { return _logoutCommand; } }

        public RelayCommand ShowViewCommand { get { return _showViewCommand; } }
        #endregion

        private void Login(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            try
            {
                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);

                //Get the current principal object
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //Authenticate the user
                customPrincipal.Identity = new CustomIdentity(user.Username, user.Email, user.Roles);

                //Update UI
                OnPropertyChanged("AuthenticatedUser");
                OnPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                Username = string.Empty; //reset
                passwordBox.Password = string.Empty; //reset
                Status = string.Empty;
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
        }

        private bool CanLogin(object parameter)
        {
            return !IsAuthenticated;
        }

        private void Logout(object parameter)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new AnonymousIdentity();
                OnPropertyChanged("AuthenticatedUser");
                OnPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                Status = string.Empty;
            }
        }

        private bool CanLogout(object parameter)
        {
            return IsAuthenticated;
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        private void ShowView(object parameter)
        {
            try
            {
                Status = string.Empty;
                IView view;
                view = new MainWindow();

                view.Show();
            }
            catch (SecurityException)
            {
                Status = "You are not authorized!";
            }
        }
    }
}