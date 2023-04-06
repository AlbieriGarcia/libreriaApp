using libreriaApp.Web.Models.Request;
using libreriaApp.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace libreriaApp.Web.ApiServices.Interfaces
{
    public interface IAuthorsApiService
    {
        Task<AuthorsListResponse> GetAuthors();
        Task<AuthorsResponse> GetAuthors(string id);
        Task<BaseResponse> Update(AuthorsUpdateRequest authorsUpdate);
        Task<BaseResponse> Save(AuthorsCreateRequest authorsCreate);
        Task<AuthorsResponse> Edit(string id);

    }
}
