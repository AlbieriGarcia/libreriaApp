using libreriaApp.Web.ApiServices.Interfaces;
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
        private readonly IAuthorsApiService authorsApiService;

        public AuthorsController(ILogger<AuthorsController> logger,
            IConfiguration configuration, IAuthorsApiService authorsApiService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.authorsApiService = authorsApiService;
        }
        public async Task<ActionResult> Index()
        {
            AuthorsListResponse authorsListResponse = new AuthorsListResponse();

            authorsListResponse = await this.authorsApiService.GetAuthors();

            if(!authorsListResponse.success)
            {
                return View();
            }
            return View(authorsListResponse.data);
        }

        // GET: AuthorsController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            AuthorsResponse authorsReponse = new AuthorsResponse();

            authorsReponse = await this.authorsApiService.GetAuthors(id);

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
            baseResponse = await this.authorsApiService.Save(authorsCreateRequest);

            if (baseResponse.Success != true)
            {
                ViewBag.Message = baseResponse.Message;
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: AuthorsController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            AuthorsResponse authorsReponse = new AuthorsResponse();

            authorsReponse = await this.authorsApiService.Edit(id);

            return View(authorsReponse.data);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AuthorsUpdateRequest authorsUpdateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            baseResponse = await this.authorsApiService.Update(authorsUpdateRequest);

            if (baseResponse.Success != true)
            {
                ViewBag.Message = baseResponse.Message;
                return View();
            }
        
            return RedirectToAction(nameof(Index));
        }
    }
}
