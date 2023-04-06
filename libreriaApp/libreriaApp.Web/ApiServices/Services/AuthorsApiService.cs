using libreriaApp.Web.ApiServices.Interfaces;
using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libreriaApp.Web.ApiServices.Services
{
    public class AuthorsApiService : Controller, IAuthorsApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly string baseUrl;
        private readonly ILogger<AuthorsApiService> logger;
        public AuthorsApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<AuthorsApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }



        public async Task<AuthorsListResponse> GetAuthors()
        {
            AuthorsListResponse authorsListResponse = new AuthorsListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Authors"))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            authorsListResponse = JsonConvert.DeserializeObject<AuthorsListResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                authorsListResponse.message = ("Error obteniendo los autores");
                authorsListResponse.success = false;
                this.logger.LogError(authorsListResponse.message, ex.ToString());
            }

            return authorsListResponse;
        }

        public async Task<AuthorsResponse> GetAuthors(string id)
        {
            AuthorsResponse authorsReponse = new AuthorsResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Authors/" + id))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            authorsReponse = JsonConvert.DeserializeObject<AuthorsResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                authorsReponse.message = "Error obteniendo los authores";
                authorsReponse.success = false;
                this.logger.LogError(authorsReponse.message, ex.ToString());
            }

            return authorsReponse;
        }

        public async Task<BaseResponse> Save(AuthorsCreateRequest authorsCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                authorsCreate.CreationDate = DateTime.Now;
                authorsCreate.CreationUser = 1;
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(authorsCreate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.baseUrl}/Authors/SaveAuthors", content);

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

        public async Task<AuthorsResponse> Edit(string id)
        {
            AuthorsResponse authorsReponse = new AuthorsResponse();

            using (var httpClient = this.httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync($"{this.baseUrl}/Authors/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    authorsReponse = JsonConvert.DeserializeObject<AuthorsResponse>(apiResponse);
                }
                else
                {
                    // realizar x logica
                }
            }
            return authorsReponse;
        }

        public async Task<BaseResponse> Update(AuthorsUpdateRequest authorsUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                authorsUpdate.ModifyDate = DateTime.Now;
                authorsUpdate.UserMod = 1;
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(authorsUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{this.baseUrl}/Authors/UpdateAuthros", content);

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

