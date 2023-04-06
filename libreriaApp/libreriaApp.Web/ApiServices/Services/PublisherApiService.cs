using libreriaApp.Web.ApiServices.Interfaces;
using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libreriaApp.Web.ApiServices.Services
{
    public class PublisherApiService : IPublisherApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<PublisherApiService> logger;
        private readonly string baseUrl;
        public PublisherApiService(IHttpClientFactory httpClientFactory,
                                 IConfiguration configuration,
                                 ILogger<PublisherApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }

        public async Task<PublisherResponse> GetPublisher(string Id)
        {
            PublisherResponse publisherResponse = new PublisherResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Publisher/" + Id))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            publisherResponse = JsonConvert.DeserializeObject<PublisherResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //       
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                publisherResponse.message = "Error obteniendo las editoras";
                publisherResponse.success = false;
                this.logger.LogError(publisherResponse.message, ex.ToString());
            }

            return publisherResponse;
        }

        public async Task<PublisherListResponse> GetPublisher()
        {
            PublisherListResponse publisherListResponse = new PublisherListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Publisher"))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            publisherListResponse = JsonConvert.DeserializeObject<PublisherListResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //       
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                publisherListResponse.message = "Error obteniendo las editoras";
                publisherListResponse.success = false;
                this.logger.LogError(publisherListResponse.message, ex.ToString());
            }

            return publisherListResponse;
        }

        public async Task<PublisherResponse> Edit(string id)
        {
            PublisherResponse publisherResponse = new PublisherResponse();

            using (var httpClient = this.httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync($"{this.baseUrl}/Publisher/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    publisherResponse = JsonConvert.DeserializeObject<PublisherResponse>(apiResponse);
                }
                else
                {
                    // realizar x logica
                }
            }
            return publisherResponse;
        }

        public async Task<BaseResponse> Save(PubisherCreateRequest pubisherCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                pubisherCreate.creationDate = DateTime.Now;
                pubisherCreate.creationUser = 1;
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(pubisherCreate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.baseUrl}/Publisher/Save", content);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return baseResponse;
                    }

                }
            }
            catch
            {
            }
            return baseResponse;
            }

        public async Task<BaseResponse> Update(PublisherUpdateRequest publisherUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                publisherUpdate.modifyDate = DateTime.Now;
                publisherUpdate.userMod = 1;
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(publisherUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.baseUrl}/Publisher/Update", content);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return baseResponse;
                    }
                }
            }
            catch
            {

            }
            return baseResponse;
        }
    }
}
    

    