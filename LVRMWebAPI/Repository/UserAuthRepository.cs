namespace LVRMWebAPI.Repository
{
    public class UserAuthRepository: IUserAuthRepository
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("admin") && password.Equals("Pa$$WoRd");
        }
    }
}
