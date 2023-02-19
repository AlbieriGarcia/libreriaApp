using libreriaApp.API.Requests;
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

        private readonly ITitleRepository titleRepository;

        public TitleController(ITitleRepository TitleRepository)
        {
            this.titleRepository = TitleRepository;
        }
        // GET: api/<TitleController>
        [HttpGet]
        public IActionResult Get()
        {
            var titles = this.titleRepository.GetAll();
            return Ok(titles);
        }

        // GET api/<TitleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var title = this.titleRepository.GetById(id);

            return Ok(title);
        }

        // POST api/<TitleController>
        [HttpPost("SaveTitle")]
        public IActionResult Post([FromBody] TitleAddRequest titleAdd)
        {
            Title title = new Title
            {
                title_id = titleAdd.title_id, // Revisar El Id no se debe poner manual //
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
            this.titleRepository.Save(title);
            return Ok();
        }

        // POST api/<TitleController>
        [HttpPost("UpdateTitle")]
        public IActionResult Put([FromBody] Title title)
        {
            this.titleRepository.Update(title);
            return Ok();
        }


        [HttpPost("RemoveTitle")]
        public IActionResult Remove([FromBody] Title title)
        {
            this.titleRepository.Remove(title);
            return Ok();
        }
    }
}
