using CustomPresentationControls.Authentication;
using CustomPresentationControls.Utilities;
using System;
using System.Collections.Generic;

namespace CustomPresentationControls
{
    public class AuthenticationViewModel : ViewModel
    {
        #region Fields
        private IAuthentication _authenticationService;
        private EditableUser _user;
        private bool _createMode = false;
        private bool _userExists = false;
        private bool _unrecognizedUser = false;
        private List<EditableUser> _users = new List<EditableUser>();
        #endregion
        #region Properties
        public EditableUser User
        {
            get { return _user; }
            set { OnPropertyChanged(ref _user, value); }
        }
        public bool CreateMode
        {
            get { return _createMode; }
            set { OnPropertyChanged(ref _createMode, value); }
        }
        public bool UserExists
        {
            get { return _userExists; }
            set { OnPropertyChanged(ref _userExists, value); }
        }
        public bool UnrecognizedUser
        {
            get { return _unrecognizedUser; }
            set { OnPropertyChanged(ref _unrecognizedUser, value); }
        }
        #endregion
        #region Commands
        public RelayCommand LoginCommand { get; }
        public RelayCommand<string> CreateModeCommand { get; }
        public RelayCommand SaveAccountCommand { get; }
        #endregion
        #region Events
        public event EventHandler<UserAuthenticatedEventArgs> UserAuthenticated = delegate { };
        #endregion
        public AuthenticationViewModel()
        {
            _authenticationService = new AuthenticationService();
            LoginCommand = new RelayCommand(CheckCredentials, CanAct);
            CreateModeCommand = new RelayCommand<string>(SetCreateMode);
            SaveAccountCommand = new RelayCommand(SaveAccount, CanAct);
            User = new EditableUser();
            User.ErrorsChanged += RaiseCanExecuteChanged;
        }
        #region Private Methods
        private bool CanAct()
        {
            return !User.HasErrors && User.Username != null && User.Password != null && User.Password.Length > 0;
        }
        private void CheckCredentials()
        {
            if (_authenticationService.AuthenticateUser(User.Username, User.Password))
            {
                UserAuthenticated(this, new UserAuthenticatedEventArgs(User.Username));
            }
            else
            {
                UnrecognizedUser = true;
            }
        }
        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            LoginCommand.RaiseCanExecuteChanged();
            SaveAccountCommand.RaiseCanExecuteChanged();
        }
        private void SaveAccount()
        {
            if (_authenticationService.CreateUser(User.Username, User.Password))
            {
                UserAuthenticated(this, new UserAuthenticatedEventArgs(User.Username));
            }
            else
            {
                UserExists = true;
            }
        }
        private void SetCreateMode(object mode)
        {
            CreateMode = Convert.ToBoolean(mode);
            if (CreateMode)
            {
                UnrecognizedUser = false;
            }
            UserExists = false;
            //NOTE: PasswordBox is cleared via PasswordBoxBindingBehavior
            User.Username = null;
            User.Password = null;
        }
        #endregion
    }
}
