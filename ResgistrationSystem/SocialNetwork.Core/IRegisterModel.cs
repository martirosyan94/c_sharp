namespace SocialNetwork.Core
{
    public interface IRegisterModel
    {
        int Age { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Surname { get; set; }
        AccountType Type { get; set; }
    }
}