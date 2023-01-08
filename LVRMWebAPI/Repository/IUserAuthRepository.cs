namespace LVRMWebAPI.Repository
{
    public interface IUserAuthRepository
    {
        bool ValidateCredentials(string username, string password);
    }
}
