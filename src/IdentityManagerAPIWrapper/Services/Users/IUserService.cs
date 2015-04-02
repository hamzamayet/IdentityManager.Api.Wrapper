using System.Threading.Tasks;
using IdentityManagerAPIWrapper.Model;
using IdentityManagerAPIWrapper.Model.Users;
using Refit;

namespace IdentityManagerAPIWrapper.Services.Users
{
    public interface IUserService
    {
        [Get("/api/users")]
        Task<UserQueryResultResponse> GetAll(string filter = null, int start = 0, int count = 100);

        [Get("/api/users/{subject}")]
        Task<UserDetailResponse> Get(string subject);

        [Post("/api/users")]
        Task<CreateUserResponse> Create([Body] PropertyValue[] properties);

        [Delete("/api/users/{subject}")]
        Task Delete(string subject);

        [Put("/api/users/{subject}/properties/{type}")]
        Task SetProperty(string subject, string type, [Body]object value);

        [Post("/api/users/{subject}/claims")]
        Task AddClaim(string subject, [Body] ClaimValue model);

        [Delete("/api/users/{subject}/claims/{type}/{value}")]
        Task RemoveClaim(string subject, string type, string value);

        [Post("/api/users/{subject}/roles/{role}")]
        Task AddRole(string subject, string role);

        [Delete("/api/users/{subject}/roles/{role}")]
        Task RemoveRole(string subject, string role);

    }
}