using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
using System.Threading.Tasks;

namespace libreriaApp.Web.ApiServices.Interfaces
{
    public interface IPublisherApiService
    {
        Task<PublisherListResponse> GetPublisher();
        Task<PublisherResponse> GetPublisher(string Id);
        Task<BaseResponse> Update(PublisherUpdateRequest publisherModel);
        Task<BaseResponse> Save(PubisherCreateRequest publisherModel);
        Task<PublisherResponse> Edit(string id);
    }
}
