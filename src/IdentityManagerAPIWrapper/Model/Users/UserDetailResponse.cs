using System.Collections.Generic;

namespace IdentityManagerAPIWrapper.Model.Users
{
    public class UserDetailResponse
    {
        public UserDetailUserData Data { get; set; }
        public UserDeleteLinks Links { get; set; }
    }

    public class UserDetailUserData
    {
        public string Username { get; set; }
        public object Name { get; set; }
        public string Subject { get; set; }
        public List<UserProperty> Properties { get; set; }
        public List<Role> Roles { get; set; }
        public Claims Claims { get; set; }
    }

    public class UserProperty
    {
        public object Data { get; set; }
        public UserPropertyMeta Meta { get; set; }
        public UserUpdateLinks Links { get; set; }
    }

    public class UserPropertyMeta
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public bool Required { get; set; }
    }

    public class Role
    {
        public bool Data { get; set; }
        public RoleMeta Meta { get; set; }
        public RoleAddRemoveLinks Links { get; set; }
    }

    public class RoleMeta
    {
        public string Type { get; set; }
        public object Description { get; set; }
    }

    public class Claims
    {
        public List<object> Data { get; set; }
        public ClaimsCreateLinks Links { get; set; }
    }

    public class RoleAddRemoveLinks
    {
        public string Add { get; set; }
        public string Remove { get; set; }
    }

    public class ClaimsCreateLinks
    {
        public string Create { get; set; }
    }

    public class UserDeleteLinks
    {
        public string Delete { get; set; }
    }

    public class UserUpdateLinks
    {
        public string Update { get; set; }
    }
}
