using System.Collections.Generic;

namespace IdentityManagerAPIWrapper.Model.Users
{
    public class UserQueryResultResponse
    {
        public UserQueryData Data { get; set; }
        public UserQueryLinks Links { get; set; }
    }

    public class UserQueryData
    {
        public List<UserQueryDataItem> Items { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public object Filter { get; set; }
    }

    public class UserQueryDataItem
    {
        public UserQueryDataItemData Data { get; set; }
        public UserQueryDataItemLinks Links { get; set; }
    }
    public class UserQueryDataItemData
    {
        public string Subject { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
    }
    public class UserQueryDataItemLinks
    {
        public string Detail { get; set; }
        public string Delete { get; set; }
    }


    public class UserQueryLinks
    {
        public UserQueryLinksCreate Create { get; set; }
    }
    public class UserQueryLinksCreate
    {
        public string Href { get; set; }
        public List<UserQueryLinksCreateMeta> Meta { get; set; }
    }
    public class UserQueryLinksCreateMeta
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public bool Required { get; set; }
    }
}