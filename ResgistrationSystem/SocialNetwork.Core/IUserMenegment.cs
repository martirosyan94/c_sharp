using System;

namespace SocialNetwork.Core
{
    public interface IUserMenegment
    {
        
        User CurrentUser { get; }
        bool IsLogined { get; }

        event EventHandler AutorizationFailed;
        event EventHandler LoggedIn;
        event EventHandler RegisteredEmployee;
        
        void LoginToSystem(IRegisterModel registerModel);
        void RegisterUser(IRegisterModel registerModel);
    }
}