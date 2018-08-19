using CustomPresentationControls.Attributes;
using CustomPresentationControls.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace CustomPresentationControls.Authentication
{
    public class EditableUser : ValidatableObservableObject
    {
        private string _username;
        private string _password;
        [Required]
        public string Username
        {
            get { return _username; }
            set { OnPropertyChanged(ref _username, value); }
        }
        [Required, Password]
        public string Password
        {
            get { return _password; }
            set { OnPropertyChanged(ref _password, value); }
        }
    }
}
