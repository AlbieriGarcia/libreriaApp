using libreriaApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using libreriaApp.DAL.Entities;
using libreriaApp.API.Requests;
using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Dtos.Publisher;

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

            PublisherAddDto publisher = new PublisherAddDto()
            {
                CreationDate = publisherAdd.CreationDate,
                CreationUser = publisherAdd.CreationUser,
                pub_id = publisherAdd.pub_id,
                pub_name = publisherAdd.pub_name,
                country = publisherAdd.country,
                city = publisherAdd.city,
                state = publisherAdd.state,
                StartDate = publisherAdd.StartDate
            };

            var result = this.publisherService.SavePublisher(publisher);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Put([FromBody] PublisherUpdateDto publisher)
        {
           var result = this.publisherService.UpdatePublisher(publisher);
            return Ok(result);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove([FromBody] PublisherRemoveDto publisher)
        {
           var result = this.publisherService.RemoverPublisher(publisher);  
            return Ok(result);
        }
    }
}
