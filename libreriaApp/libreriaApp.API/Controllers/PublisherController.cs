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

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = this.publisherService.GetById(id);

            if (result.Success)

                 return Ok(result);

            else

                return BadRequest(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] PublisherAddDto publisherAdd)
        {
            var result = this.publisherService.SavePublisher(publisherAdd);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Put([FromBody] PublisherUpdateDto publisherUpdate)
        {
           var result = this.publisherService.UpdatePublisher(publisherUpdate);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove([FromBody] PublisherRemoveDto publisherRemove)
        {
           var result = this.publisherService.RemoverPublisher(publisherRemove);  

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
