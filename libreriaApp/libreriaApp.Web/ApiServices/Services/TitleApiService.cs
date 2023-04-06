using libreriaApp.Web.Models.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static libreriaApp.Web.ApiServices.Services.TitleApiService;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using libreriaApp.Web.ApiServices.Interfaces;
using libreriaApp.Web.Models.Request;
using Microsoft.Extensions.Logging;

namespace libreriaApp.Web.ApiServices.Services
{
    public class TitleApiService : ITitleApiService
    { 
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<TitleApiService> logger;
        private readonly string baseUrl;
        public TitleApiService(IHttpClientFactory httpClientFactory,
                                    IConfiguration configuration,
                                    ILogger<TitleApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }

        public async Task<TitleResponse> GetTitle(string Id)
        {
            TitleResponse titleResponse = new TitleResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Title/" + Id))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            titleResponse = JsonConvert.DeserializeObject<TitleResponse>(apiResponse);
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
                titleResponse.message = "Error obteniendo el titulo";
                titleResponse.success = false;
                this.logger.LogError(titleResponse.message, ex.ToString());
            }

            return titleResponse;
        }

        public async Task<TitleListResponse> GetTitle()
        {
            TitleListResponse titleListResponse = new TitleListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Title"))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            titleListResponse = JsonConvert.DeserializeObject<TitleListResponse>(apiResponse);
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
                titleListResponse.message = "Error obteniendo los titulos";
                titleListResponse.success = false;
                this.logger.LogError(titleListResponse.message, ex.ToString());
            }

            return titleListResponse;
        }

        public async Task<TitleResponse> Edit(string id)
        {
            TitleResponse titleResponse = new TitleResponse();

            using (var httpClient = this.httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync($"{this.baseUrl}/Title/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    titleResponse = JsonConvert.DeserializeObject<TitleResponse>(apiResponse);
                }
                else
                {
                    // realizar x logica
                }
            }
            return titleResponse;
        }

        public async Task<BaseResponse> Save(TitleCreateRequest titleCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                titleCreate.CreateDate = DateTime.Now;
                titleCreate.CreationUser = 1;
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(titleCreate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.baseUrl}/Title/Save", content);

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

        public async Task<BaseResponse> Update(TitleUpdateRequest titleUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                titleUpdate.ModifyDate = DateTime.Now;
                titleUpdate.UserMod = 1;
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(titleUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.baseUrl}/Title/Update", content);

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
