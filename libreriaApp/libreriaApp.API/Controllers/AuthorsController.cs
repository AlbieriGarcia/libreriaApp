using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using libreriaApp.API.Requests;
using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Dtos.Authors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libreriaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService authorService;

        public AuthorsController(IAuthorsService authorService) 
        {
            this.authorService = authorService;
        }
        // GET: api/<AuthorsController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.authorService.GetAll();

            if(!result.Success)
            
                return BadRequest(result);
            

            return Ok(result);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = this.authorService.GetById(id);
            return Ok(result);
        }

        // POST api/<AuthorsController>
        [HttpPost("SaveAuthors")]
       public IActionResult Post([FromBody] AuthorsAddDto authorsAddDto)
        {
            var result = this.authorService.SaveAuthors(authorsAddDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("UpdateAuthros")]
        public IActionResult Put([FromBody]AuthorsUpdateDto authorsUpdateDto)
        {
            var result = this.authorService.UpdateAuthors(authorsUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("DeleteAuthors")]
        public IActionResult Delete([FromBody]AuthorsRemoveDto authorsRemoveDto)
        {
            var result = this.authorService.RemoveAuthors(authorsRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
