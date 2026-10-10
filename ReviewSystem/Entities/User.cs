public class User
{
    public Guid UserId {get; set;}
    public string Name {get; set;}

    public User(string name)
    {
        UserId = Guid.NewGuid();
        Name = name;
    }
}