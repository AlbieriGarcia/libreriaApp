namespace libreriaApp.BLL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();

        ServiceResult GetById(string id);
    }
}
