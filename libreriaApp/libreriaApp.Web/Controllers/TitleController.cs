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
using libreriaApp.Web.ApiServices.Interfaces;

namespace libreriaApp.Web.Controllers
{
    public class TitleController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<TitleController> logger;
        private readonly IConfiguration configuration;
        private readonly ITitleApiService titleApiService;

        public TitleController(ILogger<TitleController> logger,
                                                    IConfiguration configuration,
                                                    ITitleApiService titleApiService)
        {
            this.titleApiService = titleApiService;
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            TitleListResponse titleListResponse = new TitleListResponse();

            titleListResponse = await this.titleApiService.GetTitle();

            if (!titleListResponse.success)
            {
                return View();
            }

            return View(titleListResponse.data);

        }

        public async Task<ActionResult> Details(string id)
        {

            TitleResponse titleResponse = new TitleResponse();

            titleResponse = await this.titleApiService.GetTitle(id);

            return View(titleResponse.data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TitleCreateRequest titleCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            baseResponse = await this.titleApiService.Save(titleCreate);

            if (baseResponse.Success != true)
            {
                ViewBag.Message = baseResponse.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(string id)
        {
            TitleResponse publisherResponse = new TitleResponse();

            publisherResponse = await this.titleApiService.Edit(id);

            return View(publisherResponse.data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TitleUpdateRequest titleUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            baseResponse = await this.titleApiService.Update(titleUpdate);

            if (baseResponse.Success != true)
            {
                ViewBag.Message = baseResponse?.Message;
                return View();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
