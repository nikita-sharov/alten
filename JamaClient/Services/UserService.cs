using JamaClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public class UserService : IUserService
    {
        private const int MaxResultsDefault = 20;
        private const int MaxResultsMax = 50;
        private const int MinPasswordLength = 6;

        private readonly RestClient _client = RestClientFactory.Create("users");

        private static bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async Task<DataResponse<User>> GetAsync(int id, List<string> include = null)
        {
            var request = new RestRequest($"/{id}");
            include?.ForEach(value => request.AddParameter(nameof(include), value));
            return await _client.GetAsync<DataResponse<User>>(request);
        }

        public async Task<DataListResponse<User>> GetAsync(
            string username = null,
            string email = null,
            string firstName = null,
            string lastName = null,
            LicenseType? licenseType = null,
            bool? includeInactive = null,
            int? startAt = null,
            int? maxResults = null,
            List<string> include = null)
        {
            var request = new RestRequest();

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

            if (includeInactive == true)
            {
                request.AddParameter(nameof(includeInactive), includeInactive);
            }

            if (startAt.HasValue)
            {
                Debug.Assert((startAt >= 0) && (startAt < int.MaxValue));
                request.AddParameter(nameof(startAt), startAt);
            }

            if (maxResults.HasValue)
            {
                Debug.Assert((maxResults > 0) && (maxResults <= MaxResultsMax));
                if (maxResults != MaxResultsDefault)
                {
                    request.AddParameter(nameof(maxResults), maxResults);
                }
            }

            include?.ForEach(value => request.AddParameter(nameof(include), value));
            return await _client.GetAsync<DataListResponse<User>>(request);
        }

        public async Task<DataResponse<User>> GetCurrentAsync(List<string> include = null)
        {
            var request = new RestRequest("/current");
            include?.ForEach(value => request.AddParameter(nameof(include), value));
            return await _client.GetAsync<DataResponse<User>>(request);
        }

        public Task<FilterDataListWrapper> GetCurrentFavoriteFiltersAsync(
            int? startAt = null, int? maxResults = null, List<string> include = null)
        {
            throw new NotImplementedException();
        }

        public async Task<MetaResponse> CreateAsync(UserRequest body)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(body.Username));
            Debug.Assert(body.Password.Length >= MinPasswordLength);
            Debug.Assert(!string.IsNullOrWhiteSpace(body.FirstName));
            Debug.Assert(!string.IsNullOrWhiteSpace(body.LastName));
            Debug.Assert(IsValid(body.Email));

            var request = new RestRequest();
            request.AddJsonBody(body);
            return await _client.PostAsync<MetaResponse>(request);
        }

        public async Task<MetaResponse> UpdateAsync(int id, UserRequest body)
        {            
            if (body.Username != null)
            {
                Debug.Assert(!body.Username.IsEmptyOrWhiteSpace());
            }
            
            if (body.Password != null)
            {
                // Blank (whitespace-only) passwords are allowed.
                Debug.Assert(body.Password.Length >= MinPasswordLength);
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
                Debug.Assert(IsValid(body.Email));
            }

            var request = new RestRequest($"/{id}");
            request.AddJsonBody(body);
            return await _client.PutAsync<MetaResponse>(request);
        }

        public async Task<MetaResponse> SetActiveStatusAsync(int userId, ActiveStatusRequest body)
        {
            var request = new RestRequest($"/{userId}/active");
            request.AddJsonBody(body);
            return await _client.PutAsync<MetaResponse>(request);
        }     
    }
}
