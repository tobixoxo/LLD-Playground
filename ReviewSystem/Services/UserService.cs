using System.Security.Cryptography.X509Certificates;

public class UserService
{
    public List<User> Users {get;} = new();

    public UserService()
    {
        
    }

    public bool isUserIdValid(Guid userId)
    {
        return Users.Exists(u => u.UserId == userId);
    }

}