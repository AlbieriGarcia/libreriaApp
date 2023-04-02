using libreriaApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using libreriaApp.Web.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using libreriaApp.Web.Models.Response;
using Microsoft.Extensions.Logging;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using libreriaApp.Web.Models.Request;
using System.Text;

namespace libreriaApp.Web.Controllers
{

    public class TitleController : Controller
    {

        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<TitleController> logger;
        private readonly IConfiguration configuration;

        // GET: TitleController
        public TitleController(ILogger<TitleController> logger,
                                 IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            TitleListResponse titleListResponse = new TitleListResponse();
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var response = await httpClient.GetAsync("http://localhost:19474/api/Title");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        titleListResponse = JsonConvert.DeserializeObject<TitleListResponse>(apiResponse);
                    }
                    else
                    {
                        
                    }
                                
                }
                return View(titleListResponse.data);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los titulos", ex.ToString());
            }
            return View();
        }

        // GET: TitleController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            TitleResponse titleResponse = new TitleResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"http://localhost:19474/api/Title/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    titleResponse = JsonConvert.DeserializeObject<TitleResponse>(apiResponse);
                }
                else
                {

                }
           
            }
            return View(titleResponse.data);

        }

        // GET: TitleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TitleCreateRequest titleCreateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                titleCreateRequest.CreateDate = DateTime.Now;
                titleCreateRequest.CreationUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(titleCreateRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:19474/api/Title/SaveTitle", content);

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

        // GET: TitleController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            TitleResponse titleResponse = new TitleResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"http://localhost:19474/api/Title/"+ id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    titleResponse = JsonConvert.DeserializeObject<TitleResponse>(apiResponse);

                }
                else
                {

                }

                return View(titleResponse.data);
            }
            
        }

        // POST: TitleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TitleUpdateRequest titleUpdateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                titleUpdateRequest.ModifyDate = DateTime.Now;
                titleUpdateRequest.UserMod = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(titleUpdateRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:19474/api/Title/UpdateTitle", content);

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
