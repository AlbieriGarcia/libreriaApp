﻿using libreriaApp.API.Requests;
using libreriaApp.BLL.Contracts;
using libreriaApp.BLL.Dtos.Title;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libreriaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {

        private readonly ITitleService titleService;

        public TitleController(ITitleService titleService)
        {
            this.titleService = titleService;

        }
        // GET: api/<TitleController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.titleService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            
            return Ok(result);
        }

        // GET api/<TitleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = this.titleService.GetById(id);

            return Ok(result);
        }

        // POST api/<TitleController>
        [HttpPost("SaveTitle")]
        public IActionResult Post([FromBody] TitleAddRequest titleAdd)
        {
            TitleAddDto title = new TitleAddDto()
            {
                title_id = titleAdd.title_id, 
                title = titleAdd.title,
                type = titleAdd.type,
                price = titleAdd.price,
                advance = titleAdd.advance,
                royalty = titleAdd.royalty,
                ytd_sales = titleAdd.ytd_sales,
                notes = titleAdd.notes,
                pubdate = titleAdd.pubdate,
                CreationDate = titleAdd.CreateDate,
                CreationUser = titleAdd.CreationUser,
            };
            var resuls = this.titleService.SaveTitle(title);
            return Ok(resuls);
        }

        // POST api/<TitleController>
        [HttpPost("UpdateTitle")]
        public IActionResult Put([FromBody] TitleUpdateDto title)
        {
            var result = this.titleService.UpdateTitle(title);
            return Ok(result);
        }


        [HttpPost("RemoveTitle")]
        public IActionResult Remove([FromBody] TitleRemoveDto title)
        {
            var resuls = this.titleService.RemoveTitle(title);
            return Ok(resuls);
        }
    }
}
