using System;
using System.Threading.Tasks;
using IdentityManagerAPIWrapper.Model;
using IdentityManagerAPIWrapper.Model.Users;
using Refit;

namespace IdentityManagerAPIWrapper.Services.Users
{
    public class UserService
    {
        private static UserService _service;
        private static readonly object SyncServiceObject = new object();
        private readonly string _serviceAddress;
        private IUserService _user;
        private readonly object _syncObject = new object();

        private UserService(string serviceAddress)
        {
            _serviceAddress = serviceAddress;
        }

        public async Task<UserQueryResultResponse> GetAll(string filter = null, int start = 0, int count = 100)
        {
            var response = GetRestService().GetAll(filter, start, count);
            return await response;
        }

        public async Task<UserDetailResponse> Get(string subject)
        {
            var response = GetRestService().Get(subject);
            return await response;
        }

        public async Task<CreateUserResponse> Create(PropertyValue[] properties)
        {
            var response = GetRestService().Create(properties);
            return await response;
        }

        public async void Delete(string subject)
        {
            await GetRestService().Delete(subject);
        }

        public async void SetProperty(string subject, string type, object body)
        {
            await GetRestService().SetProperty(subject, type, body);
        }

        public async void AddClaim(string subject, ClaimValue model)
        {
            await GetRestService().AddClaim(subject, model);
        }

        public async void RemoveClaim(string subject, string type, string value)
        {
            await GetRestService().RemoveClaim(subject, type, value);
        }

        public async void AddRole(string subject, string role)
        {
            await GetRestService().AddRole(subject, role);
        }

        public async void RemoveRole(string subject, string role)
        {
            await GetRestService().RemoveRole(subject, role);
        }
        
        private IUserService GetRestService()
        {
            lock (_syncObject)
            {
                return _user ?? (_user = RestService.For<IUserService>(_serviceAddress));
            }
        }

        public static UserService GetService(string serviceAddress)
        {
            if (string.IsNullOrWhiteSpace(serviceAddress))
                throw new ArgumentException("Cannot be null or empty", "serviceAddress");

            lock (SyncServiceObject)
            {
                return _service ?? (_service = new UserService(serviceAddress));
            }
        }

        public static void Cleanup()
        {
            lock (SyncServiceObject)
            {
                _service = null;
            }
        }

    }
}