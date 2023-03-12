using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Authors;

namespace libreriaApp.BLL.Contract
{
    public interface IAuthorsService : IBaseService
    {
        ServiceResult SaveAuthors(AuthorsAddDto authorsAdd);
        ServiceResult UpdateAuthors(AuthorsUpdateDto authorsUpdate);
        ServiceResult RemoveAuthors(AuthorsRemoveDto authorsRemove);
    }
}
