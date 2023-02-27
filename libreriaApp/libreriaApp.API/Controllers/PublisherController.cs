using libreriaApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using libreriaApp.DAL.Entities;
using libreriaApp.API.Requests;


namespace libreriaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository publisherRepository;
        public PublisherController(IPublisherRepository PublisherRepository) 
        {
            this.publisherRepository = PublisherRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var publishers = this.publisherRepository.GetAll();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var publisher = this.publisherRepository.GetById(id);
            return Ok(publisher);
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

            this.publisherRepository.Save(publisher);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Put([FromBody] Publisher publisher)
        {
            this.publisherRepository.Update(publisher);
            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Remove([FromBody] Publisher publisher)
        {
            this.publisherRepository.Remove(publisher);
            return Ok();
        }
    }
}
