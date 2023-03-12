using libreriaApp.BLL.Dtos.Publisher;
using libreriaApp.DAL.Entities;

namespace libreriaApp.BLL.Extentions
{
    public static class PublisherExtention
    {
        public static Publisher GetPublisherEntityFromDtoSave(this PublisherAddDto saveDto)
        {
            Publisher publisher = new Publisher()
            {
                CreationDate = saveDto.CreationDate,
                CreationUser = saveDto.CreationUser,
                pub_id = saveDto.pub_id,
                pub_name = saveDto.pub_name,
                country = saveDto.country,
                city = saveDto.city,
                state = saveDto.state,
                StartDate = saveDto.StartDate

            };

            return publisher;
        }
    }
}
