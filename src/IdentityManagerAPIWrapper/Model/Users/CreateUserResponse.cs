namespace IdentityManagerAPIWrapper.Model.Users
{
    public class CreateUserResponse
    {
        public CreateUserData Data { get; set; }
        public CreateUserLinks Links { get; set; }
    }
    public class CreateUserData
    {
        public string Subject { get; set; }
    }

    public class CreateUserLinks
    {
        public string Detail { get; set; }
    }
}