using System;
using System.Threading.Tasks;
using IdentityManagerAPIWrapper.Model;
using IdentityManagerAPIWrapper.Model.Roles;
using Refit;

namespace IdentityManagerAPIWrapper.Services.Roles
{
    public class RoleService
    {
        private static RoleService _service;
        private static readonly object SyncServiceObject = new object();
        private readonly string _serviceAddress;
        private IRoleService _role;
        private readonly object _syncObject = new object();

        private RoleService(string serviceAddress)
        {
            _serviceAddress = serviceAddress;
        }

        public async Task<RoleQueryResultResponse> GetAll(string filter = null, int start = 0, int count = 100)
        {
            var response = GetRestService().GetAll(filter, start, count);
            return await response;
        }

        public async Task<RoleDetailResponse> Get(string subject)
        {
            var response = GetRestService().Get(subject);
            return await response;
        }

        public async Task<CreateRoleResponse> Create(PropertyValue[] properties)
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

        private IRoleService GetRestService()
        {
            lock (_syncObject)
            {
                return _role ?? (_role = RestService.For<IRoleService>(_serviceAddress));
            }
        }

        public static RoleService GetService(string serviceAddress)
        {
            if (string.IsNullOrWhiteSpace(serviceAddress))
                throw new ArgumentException("Cannot be null or empty", "serviceAddress");

            lock (SyncServiceObject)
            {
                return _service ?? (_service = new RoleService(serviceAddress));
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