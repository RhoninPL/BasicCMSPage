namespace BasicCMSPage.Interfaces
{
    public interface IAuthentication
    {
        bool Authenticate(string userName, string password);
        bool LogOut();
    }
}