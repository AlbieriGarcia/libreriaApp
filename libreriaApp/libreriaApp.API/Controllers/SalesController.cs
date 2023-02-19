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
        public IEnumerable<Sales> Get()
        {
            return this.SalesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Sales Get(string id)
        {
            return this.SalesRepository.GetById(id);
        }
        [HttpPost("Save")]
        public void Post([FromBody] Sales sales)
        {
            this.SalesRepository.Save(sales);
        }
        [HttpPut("Update")]
        public void Put(Sales sales)
        {
            this.SalesRepository.Update(sales);
        }
        [HttpDelete("Remove")]
        public void Delete(Sales sales)
        {
            this.SalesRepository.Remove(sales);
        }
    }
}
