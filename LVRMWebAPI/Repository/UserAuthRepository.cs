namespace LVRMWebAPI.Repository
{
    public class UserAuthRepository: IUserAuthRepository
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("dealercarsearch") && password.Equals("repmanapi1!");
        }
    }
}
