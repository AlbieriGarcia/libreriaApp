using libreriaApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using libreriaApp.DAL.Entities;
using libreriaApp.API.Requests;
using libreriaApp.BLL.Contract;

namespace libreriaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService) 
        {        
            this.publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.publisherService.GetAll();

            if (!result.Success)
                return BadRequest(result);
            


            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = this.publisherService.GetById(id);
            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] PublisherAddRequest publisherAdd)
        {

            Publisher publisher = new Publisher
            {
                pub_id = publisherAdd.pub_id,
                pub_name = publisherAdd.pub_name,
                city = publisherAdd.city,
                state = publisherAdd.state,
                country = publisherAdd.country,

            };

  //          this.publisherRepository.Save(publisher);
  //          this.publisherRepository.SaveChanges();
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Put([FromBody] Publisher publisher)
        {
   //         this.publisherRepository.Update(publisher);
   //         this.publisherRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Remove([FromBody] Publisher publisher)
        {
  //          this.publisherRepository.Remove(publisher);
 //           this.publisherRepository.SaveChanges();
            return Ok();
        }
    }
}
