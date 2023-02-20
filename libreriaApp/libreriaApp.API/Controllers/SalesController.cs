using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libreriaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository SalesRepository;

        public SalesController(ISalesRepository SalesRepository)
        {
            this.SalesRepository = SalesRepository;
        }    
        
        [HttpGet]
        public IActionResult Get()
        {
            var Sale = SalesRepository.GetAll();
            return Ok(Sale);
               
        }

        [HttpGet("{id}")]
        public Sales Get(string id)
        {
            return this.SalesRepository.GetById(id);
        }
        [HttpPost("Save")]
        public void Post([FromBody] Sales Sale)
        {
            this.SalesRepository.Save(Sale);
        }
        [HttpPut("Update")]
        public void Put(Sales Sale)
        {
            this.SalesRepository.Update(Sale);
        }
        [HttpDelete("Remove")]
        public void Delete(Sales Sale)
        {
            this.SalesRepository.Remove(Sale);
        }
        
    }
}
