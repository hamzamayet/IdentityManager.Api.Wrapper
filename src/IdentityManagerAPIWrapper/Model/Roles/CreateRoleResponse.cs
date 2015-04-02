namespace IdentityManagerAPIWrapper.Model.Roles
{
    public class CreateRoleResponse
    {
        public CreateRoleData Data { get; set; }
        public CreateRoleLinks Links { get; set; }
    }
    public class CreateRoleData
    {
        public string Subject { get; set; }
    }

    public class CreateRoleLinks
    {
        public string Detail { get; set; }
    }
}
