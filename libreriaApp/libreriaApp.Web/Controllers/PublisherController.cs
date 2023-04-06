using libreriaApp.Web.ApiServices.Interfaces;
using libreriaApp.Web.Models;
using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
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
        private readonly IPublisherApiService publisherApiService;

        public PublisherController(ILogger<PublisherController> logger, 
                                                    IConfiguration configuration,
                                                    IPublisherApiService publisherApiService)
        {
            this.publisherApiService = publisherApiService;
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            PublisherListResponse publisherListResponse = new PublisherListResponse();

            publisherListResponse = await this.publisherApiService.GetPublisher();

            if (!publisherListResponse.success)
            {
                return View();
            }

            return View(publisherListResponse.data);

        }

        public async Task<ActionResult> Details(string id)
        {

            PublisherResponse publisherResponse = new PublisherResponse();

            publisherResponse = await this.publisherApiService.GetPublisher(id);

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
            baseResponse = await this.publisherApiService.Save(pubisherCreate);

            if (baseResponse.Success != true)
            {
                ViewBag.Message = baseResponse.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(string id)
        {
            PublisherResponse publisherResponse= new PublisherResponse();

            publisherResponse = await this.publisherApiService.Edit(id);

            return View(publisherResponse.data);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PublisherUpdateRequest publisherUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            baseResponse = await this.publisherApiService.Update(publisherUpdate);

            if (baseResponse.Success != true) 
            {
                ViewBag.Message = baseResponse?.Message;
                return View();
            }

            return RedirectToAction(nameof(Index));

            }
        }
    }
