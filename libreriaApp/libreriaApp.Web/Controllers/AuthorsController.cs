using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libreriaApp.Web.Controllers
{
    public class AuthorsController : Controller
    {

        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<AuthorsController> logger;
        private readonly IConfiguration configuration;

        public AuthorsController(ILogger<AuthorsController> logger,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            AuthorsListResponse authorsListResponse = new AuthorsListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var response = await httpClient.GetAsync($"http://localhost:19474/api/Authors");

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
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los autores", ex.ToString());
            }

            return View(authorsListResponse.data);
        }

        // GET: AuthorsController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            AuthorsResponse authorsReponse = new AuthorsResponse();
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"http://localhost:19474/api/Authors/" + id);

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
            return View(authorsReponse.data);
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AuthorsCreateRequest authorsCreateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                authorsCreateRequest.CreationDate = DateTime.Now;
                authorsCreateRequest.CreationUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(authorsCreateRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:19474/api/Authors/SaveAuthors", content);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = baseResponse.Message;
                        return View();
                    }
                }
            
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            AuthorsResponse authorsReponse = new AuthorsResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"http://localhost:19474/api/Authors/" + id);

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
            return View(authorsReponse.data);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Edit(AuthorsUpdateRequest authorsUpdateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                authorsUpdateRequest.ModifyDate = DateTime.Now;
                authorsUpdateRequest.UserMod = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(authorsUpdateRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync("http://localhost:19474/api/Authors/UpdateAuthros", content);
                    
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = baseResponse.Message;
                        return View();
                    }
                }
               
            }
            catch
            {
                return View();
            }
        }

    }
}
