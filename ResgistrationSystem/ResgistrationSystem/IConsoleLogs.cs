using System;

namespace SocialNetwork
{
    public interface IConsoleLogs
    {
        void OnAutorizationFailed(object source, EventArgs args);
        void OnLoggedIn(object source, EventArgs args);
        void OnRegisteredEmployee(object source, EventArgs args);
    }
}