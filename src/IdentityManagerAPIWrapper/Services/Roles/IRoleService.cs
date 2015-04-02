using System.Threading.Tasks;
using IdentityManagerAPIWrapper.Model;
using IdentityManagerAPIWrapper.Model.Roles;
using Refit;

namespace IdentityManagerAPIWrapper.Services.Roles
{
    public interface IRoleService
    {
        [Get("/api/roles")]
        Task<RoleQueryResultResponse> GetAll(string filter = null, int start = 0, int count = 100);

        [Get("/api/roles/{subject}")]
        Task<RoleDetailResponse> Get(string subject);

        [Post("/api/roles")]
        Task<CreateRoleResponse> Create([Body] PropertyValue[] properties);

        [Delete("/api/roles/{subject}")]
        Task Delete(string subject);

        [Put("/api/roles/{subject}/properties/{type}")]
        Task SetProperty(string subject, string type, [Body]object value);
    }
}