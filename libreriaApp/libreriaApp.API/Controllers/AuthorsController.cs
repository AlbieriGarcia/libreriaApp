using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using libreriaApp.API.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libreriaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository authorsRepository;
        public AuthorsController(IAuthorsRepository authorsRepository) 
        {
            this.authorsRepository = authorsRepository;
        }
        // GET: api/<AuthorsController>
        [HttpGet]
        public IActionResult Get()
        {
            var authors = this.authorsRepository.GetAll();
            return Ok(authors);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var authors = this.authorsRepository.GetById(id);
            return Ok(authors);
        }

        // POST api/<AuthorsController>
        [HttpPost("Save Authors")]
        public IActionResult Post([FromBody] AuthorsAddRequest authorsAdd)
        {
            Authors authors = new Authors()
            {
                au_id = authorsAdd.au_id,
                au_lname = authorsAdd.au_lname,
                au_fname = authorsAdd.au_fname,
                phone = authorsAdd.phone,
                address = authorsAdd.address,
                city = authorsAdd.city,
                state = authorsAdd.state,
                zip = authorsAdd.zip,
                contract = authorsAdd.contract,
            };

            this.authorsRepository.Save(authors);
            return Ok();
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("Update Authros")]
        public IActionResult Put([FromBody]Authors authors)
        {
            this.authorsRepository.Update(authors);
            return Ok();
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("Delete Authors")]
        public IActionResult Delete([FromBody]Authors authors)
        {
            this.authorsRepository.Remove(authors);
            return Ok();
        }
    }
}
