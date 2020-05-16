using Alten.Jama.Models;
using RestSharp;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    public sealed class RestSharpUserService : IUserService
    {
        private static readonly ValidationAttribute EmailAddress = new EmailAddressAttribute();

        private readonly IRestClient _client;

        public RestSharpUserService(IRestClient client) => _client = client;

        public Task<DataResponse<User>> GetAsync(int userId)
        {
            var request = new RestRequest($"/users/{userId}");
            return _client.GetAsync<DataResponse<User>>(request);
        }

        public Task<DataListResponse<User>> GetListAsync(
            string username = null,
            string email = null,
            string firstName = null,
            string lastName = null,
            LicenseType? licenseType = null,
            bool includeInactive = false,
            int startAt = 0,
            int maxResults = JamaOptions.MaxResultsMax)
        {
            IRestRequest request = RestRequestFactory.Create("/users", startAt, maxResults);

            if (!string.IsNullOrWhiteSpace(username))
            {
                request.AddParameter(nameof(username), username);
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                request.AddParameter(nameof(email), email);
            }

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                request.AddParameter(nameof(firstName), firstName);
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                request.AddParameter(nameof(lastName), lastName);
            }

            if (licenseType.HasValue)
            {
                request.AddParameter(nameof(licenseType), licenseType);
            }

            if (includeInactive)
            {
                request.AddParameter(nameof(includeInactive), true);
            }

            return _client.GetAsync<DataListResponse<User>>(request);
        }

        public Task<DataResponse<User>> GetCurrentAsync()
        {
            IRestRequest request = RestRequestFactory.Create("/users/current");
            return _client.GetAsync<DataResponse<User>>(request);
        }

        public Task<DataListResponse<Filter>> GetCurrentFilterListAsync(int startAt, int maxResults)
        {
            throw new NotImplementedException();
        }

        public Task<MetaResponse> PostAsync(UserRequest body)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(body.Username));
            Debug.Assert(body.Password.Length >= JamaOptions.MinPasswordLength);
            Debug.Assert(!string.IsNullOrWhiteSpace(body.FirstName));
            Debug.Assert(!string.IsNullOrWhiteSpace(body.LastName));
            Debug.Assert(EmailAddress.IsValid(body.Email));

            IRestRequest request = RestRequestFactory.Create("/users");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> PutActiveAsync(int userId, ActiveStatusRequest body)
        {
            IRestRequest request = RestRequestFactory.Create($"/users/{userId}/active");
            request.AddJsonBody(body);
            return _client.PutAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> PutAsync(int userId, UserRequest body)
        {
            if (body.Username != null)
            {
                Debug.Assert(!body.Username.IsEmptyOrWhiteSpace());
            }

            if (body.Password != null)
            {
                // Blank (whitespace-only) passwords are allowed.
                Debug.Assert(body.Password.Length >= JamaOptions.MinPasswordLength);
            }

            if (body.FirstName != null)
            {
                Debug.Assert(!body.FirstName.IsEmptyOrWhiteSpace());
            }

            if (body.LastName != null)
            {
                Debug.Assert(!body.LastName.IsEmptyOrWhiteSpace());
            }

            if (body.Email != null)
            {
                Debug.Assert(EmailAddress.IsValid(body.Email));
            }

            IRestRequest request = RestRequestFactory.Create($"/users/{userId}");
            request.AddJsonBody(body);
            return  _client.PutAsync<MetaResponse>(request);
        }
    }
}
