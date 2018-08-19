namespace CustomPresentationControls.Authentication
{
    public class UserAuthenticatedEventArgs
    {
        public string Username { get; set; }
        public UserAuthenticatedEventArgs(string username)
        {
            Username = username;
        }
    }
}
