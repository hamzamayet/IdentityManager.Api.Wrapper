using System.Collections.Generic;

namespace IdentityManagerAPIWrapper.Model.Roles
{
    
    public class RoleQueryResultResponse
    {
        public RoleQueryResultData Data { get; set; }
        public RoleQueryResultLinks Links { get; set; }
    }

    public class RoleQueryResultData
    {
        public List<RoleQueryResultDataItem> Items { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public object Filter { get; set; }
    }

    public class RoleQueryResultDataItem
    {
        public RoleQueryResultDataItemData Data { get; set; }
        public RoleQueryResultDataItemLinks Links { get; set; }
    }

    public class RoleQueryResultDataItemData
    {
        public string Subject { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }
    }

    public class RoleQueryResultDataItemLinks
    {
        public string Detail { get; set; }
        public string Delete { get; set; }
    }

    public class RoleQueryResultLinks
    {
        public RoleCreate Create { get; set; }
    }

    public class RoleCreate
    {
        public string Href { get; set; }
        public List<RoleCreateMeta> Meta { get; set; }
    }

    public class RoleCreateMeta
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public bool Required { get; set; }
    }
}
