using libreriaApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using libreriaApp.DAL.Entities;
using libreriaApp.API.Requests;


namespace libreriaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository publisherRepository;
        public PublishersController(IPublisherRepository publisherRepository) 
        {
            this.publisherRepository = publisherRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var publishers = this.publisherRepository.GetAll();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = this.publisherRepository.GetById(id);
            return Ok(publisher);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] PublisherAddRequest publisherAdd)
        {

            publishers publishers = new publishers()
            {
                pub_id = publisherAdd.pub_id,
                pub_name = publisherAdd.pub_name,
                CreationDate = publisherAdd.CreationDate,
                CreationUser = publisherAdd.CreationUser,
                country = publisherAdd.country,

            };

            this.publisherRepository.Save(publishers);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Put(publishers publishers)
        {
            this.publisherRepository.Update(publishers);
            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Delete(publishers publishers)
        {
            this.publisherRepository.Remove(publishers);
            return Ok();
        }
    }
}
