using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
using System.Threading.Tasks;

namespace libreriaApp.Web.ApiServices.Interfaces
{
    public interface ITitleApiService
    {
        Task<TitleListResponse> GetTitle();
        Task<TitleResponse> GetTitle(string Id);
        Task<BaseResponse> Update(TitleUpdateRequest titleModel);
        Task<BaseResponse> Save(TitleCreateRequest titleModel);
        Task<TitleResponse> Edit(string id);
    }
}
