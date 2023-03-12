using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos;
using libreriaApp.BLL.Dtos.Publisher;

namespace libreriaApp.BLL.Contract
{
    public interface IPublisherService : IBaseService
    {
        ServiceResult SavePublisher(PublisherAddDto publisherAdd);
        ServiceResult UpdatePublisher(PublisherUpdateDto publisherUpdate);
        ServiceResult RemoverPublisher(PublisherRemoveDto publisherRemove);

    }
}
