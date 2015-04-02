using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagerAPIWrapper.Model.Roles
{
    
    public class RoleDetailResponse
    {
        public RoleDetailData RoleDetailData { get; set; }
        public RoleDetailLinks RoleDetailLinks { get; set; }
    }

    public class RoleDetailData
    {
        public string Name { get; set; }
        public string Subject { get; set; }
    }

    public class RoleDetailLinks
    {
        public string Delete { get; set; }
    }
}
