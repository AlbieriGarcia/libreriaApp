using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Title;

namespace libreriaApp.BLL.Contracts
{
    public interface ITitleService : IBaseService
    {
        ServiceResult SaveTitle(TitleAddDto titleAdd);
        ServiceResult UpdateTitle(TitleUpdateDto titleUpdate);
        ServiceResult RemoveTitle(TitleRemoveDto titleRemove);
    }
}
