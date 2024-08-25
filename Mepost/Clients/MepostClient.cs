using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mepost.Configuration;
using Mepost.Helpers;
using Mepost.Models;
using Mepost.Models.Requests;
using Mepost.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Mepost.Clients
{
    public class MepostClient
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://api.mepost.io/v1";

        public MepostClient(string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", $"{apiKey}");
        }

        private async Task<T> SendRequestAsync<T>(HttpMethod method, string endpoint, object content = null)
        {
            var request = new HttpRequestMessage(method, $"{BaseUrl}{endpoint}");
            if (content != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(content, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver()
                        {
                            NamingStrategy = new SnakeCaseNamingStrategy()
                        }
                    }), Encoding.UTF8,
                    "application/json");
            }

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        // Company Endpoints
        public async Task<Response<AddDomainResponse>> AddDomainAsync(AddDomainRequest request)
        {
            return await SendRequestAsync<Response<AddDomainResponse>>
                (HttpMethod.Post, "/company/domain/add", request);
        }

        public async Task<Response<CompanyDomain>> GetDomainListAsync()
        {
            return await SendRequestAsync<Response<CompanyDomain>>(HttpMethod.Get, "/company/domain/list");
        }

        public async Task<Response<RemoveDomainResponse>> RemoveDomainAsync(AddDomainRequest request)
        {
            return await SendRequestAsync<Response<RemoveDomainResponse>>(HttpMethod.Delete, "/company/domain/remove",
                request);
        }

        // Groups Endpoints
        public async Task<Response<BaseResult<EmailGroup>>> ListGroupsAsync(int limit = 10, int page = 1)
        {
            return await SendRequestAsync<Response<BaseResult<EmailGroup>>>(HttpMethod.Get,
                $"/groups?limit={limit}&page={page}");
        }

        public async Task<Response<EmailGroup>> CreateGroupAsync(CreateNewGroupRequest request)
        {
            return await SendRequestAsync<Response<EmailGroup>>(HttpMethod.Post, "/groups", request);
        }

        public async Task<Response<bool>> DeleteGroupAsync(string groupId)
        {
            return await SendRequestAsync<Response<bool>>(HttpMethod.Delete, $"/groups/{groupId}");
        }

        public async Task<Response<EmailGroupWithCounts>> GetGroupByIdAsync(string groupId)
        {
            return await SendRequestAsync<Response<EmailGroupWithCounts>>(HttpMethod.Get, $"/groups/{groupId}");
        }

        public async Task<Response<bool>> UpdateGroupAsync(string groupId, RenameGroupRequest request)
        {
            return await SendRequestAsync<Response<bool>>(HttpMethod.Put, $"/groups/{groupId}", request);
        }

        // Subscribers Endpoints
        public async Task<Response<BaseResult<Subscriber>>> ListSubscribersAsync(string groupId, int limit = 10,
            int page = 1)
        {
            return await SendRequestAsync<Response<BaseResult<Subscriber>>>(HttpMethod.Get,
                $"/groups/{groupId}/subscribers?limit={limit}&page={page}");
        }

        public async Task<Response<bool>> AddSubscriberAsync(string groupId, CreateSubscriberRequest request)
        {
            return await SendRequestAsync<Response<bool>>(HttpMethod.Post, $"/groups/{groupId}/subscribers",
                request);
        }

        public async Task<Response<bool>> DeleteSubscriberAsync(string groupId, DeleteSubscriberRequest request)
        {
            return await SendRequestAsync<Response<bool>>(HttpMethod.Delete, $"/groups/{groupId}/subscribers/",
                request);
        }

        public async Task<Response<Subscriber>> GetSubscriberByEmailAsync(string groupId, string email)
        {
            return await SendRequestAsync<Response<Subscriber>>(HttpMethod.Get,
                $"/groups/{groupId}/subscribers/{email}");
        }

        // Messages Endpoints
        public async Task<Response<GetMessageInfoResponse>> GetMessageInfoAsync(string scheduleId, string email)
        {
            return await SendRequestAsync<Response<GetMessageInfoResponse>>(HttpMethod.Get,
                $"/messages/{scheduleId}/{email}");
        }

        public async Task<Response<bool>> CancelScheduledMessageAsync(CancelScheduledMessageRequest request)
        {
            return await SendRequestAsync<Response<bool>>(HttpMethod.Post, "/messages/cancel-scheduled", request);
        }

        public async Task<Response<Schedule>> SendMarketingAsync(SendMarketingRequest request)
        {
            return await SendRequestAsync<Response<Schedule>>(HttpMethod.Post, "/messages/marketing", request);
        }

        public async Task<Response<Schedule>> SendMessageByTemplateAsync(SendMessageByTemplateRequest request)
        {
            return await SendRequestAsync<Response<Schedule>>(HttpMethod.Post, "/messages/marketing-by-template",
                request);
        }

        public async Task<Response<GetScheduleInfoResponse>> GetScheduleInfoAsync(string scheduleId)
        {
            return await SendRequestAsync<Response<GetScheduleInfoResponse>>(HttpMethod.Get,
                $"/messages/schedule/{scheduleId}");
        }

        public async Task<Response<Schedule>> SendTransactionalAsync(SendTransactionalRequest request)
        {
            return await SendRequestAsync<Response<Schedule>>(HttpMethod.Post, "/messages/transactional", request);
        }

        public async Task<Response<Schedule>> SendTransactionalByTemplateAsync(SendMessageByTemplateRequest request)
        {
            return await SendRequestAsync<Response<Schedule>>(HttpMethod.Post, "/messages/transactional-by-template",
                request);
        }

        // Outbound IP Endpoints
        public async Task<Response<IPGroup>> CreateIpGroupAsync(CreateIpGroupRequest request)
        {
            return await SendRequestAsync<Response<IPGroup>>(HttpMethod.Post, "/outbound/ip-group/create", request);
        }

        public async Task<Response<IPGroup>> GetIpGroupInfoAsync(string name)
        {
            return await SendRequestAsync<Response<IPGroup>>(HttpMethod.Get, $"/outbound/ip-group/info/{name}");
        }

        public async Task<Response<List<IPGroup>>> ListIpGroupsAsync()
        {
            return await SendRequestAsync<Response<List<IPGroup>>>(HttpMethod.Get, "/outbound/ip-group/list");
        }

        public async Task<Response<CancelWarmUpResponse>> CancelWarmupAsync(CancelWarmUpRequest request)
        {
            return await SendRequestAsync<Response<CancelWarmUpResponse>>(HttpMethod.Post, "/outbound/ip/cancel-warmup",
                request);
        }

        public async Task<Response<IpAddress>> GetIpInfoAsync(string ip)
        {
            return await SendRequestAsync<Response<IpAddress>>(HttpMethod.Get, $"/outbound/ip/info/{ip}");
        }

        public async Task<Response<List<IpAddress>>> ListIpsAsync()
        {
            return await SendRequestAsync<Response<List<IpAddress>>>(HttpMethod.Get, "/outbound/ip/list");
        }

        public async Task<Response<SetIpGroupResponse>> SetIpGroupAsync(SetIpGroupRequest request)
        {
            return await SendRequestAsync<Response<SetIpGroupResponse>>(HttpMethod.Post, "/outbound/ip/set-ip-group",
                request);
        }

        public async Task<Response<StartWarmUpResponse>> StartWarmupAsync(StartWarmUpRequest request)
        {
            return await SendRequestAsync<Response<StartWarmUpResponse>>(HttpMethod.Post, "/outbound/ip/start-warmup",
                request);
        }
    }
}
