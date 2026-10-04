public class User {
    public string Name {get; }
    public string Email {get; }
    public Guid Id {get;}
    public string PhoneNumber {get;}

    public User (string name, string email, string phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Id = Guid.NewGuid();
    }
}