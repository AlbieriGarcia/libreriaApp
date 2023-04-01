using libreriaApp.Web.Models;
using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libreriaApp.Web.Controllers
{
    public class PublisherController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<PublisherController> logger;
        private readonly IConfiguration configuration;

        public PublisherController(ILogger<PublisherController> logger, 
                                                    IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            PublisherListResponse publisherListResponse = new PublisherListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))

                {
                  var response = await httpClient.GetAsync("http://localhost:5000/api/Publisher");

                    if(response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        publisherListResponse = JsonConvert.DeserializeObject<PublisherListResponse>(apiResponse);

                    }
                    else
                    {
                        // x logica
                    }

                }
                return View(publisherListResponse.data);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo la auditora", ex.ToString());
            }

            return View();

        }

        public async Task<ActionResult> Details(string id)
        {
            PublisherResponse publisherResponse = new PublisherResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))

            {
                var response = await httpClient.GetAsync($"http://localhost:5000/api/Publisher/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                     publisherResponse = JsonConvert.DeserializeObject<PublisherResponse>(apiResponse);

                }
                else
                {
                    // x logica
                }
            }

                return View(publisherResponse.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PubisherCreateRequest pubisherCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                pubisherCreate.creationDate = DateTime.Now;
                pubisherCreate.creationUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler)) 
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(pubisherCreate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:5000/api/Publisher/Save", content);

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

        public async Task<ActionResult> Edit(string id)
        {
            PublisherResponse publisherResponse= new PublisherResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))

            {
                var response = await httpClient.GetAsync($"http://localhost:5000/api/Publisher/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    publisherResponse = JsonConvert.DeserializeObject<PublisherResponse>(apiResponse);

                }
                else
                {
                    // x logica
                }

            }

            return View(publisherResponse.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PublisherUpdateRequest publisherUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                publisherUpdate.modifyDate = DateTime.Now;
                publisherUpdate.userMod = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(publisherUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync("http://localhost:5000/api/Publisher/Update", content);

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
