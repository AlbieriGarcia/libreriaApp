using libreriaApp.DAL.Entities;
using libreriaApp.BLL.Dtos.Authors;

namespace libreriaApp.BLL.Extentions
{
    public static class AuthorsExtention
    {
        public static Authors GetAuthorsEntityFromDtoSave(this AuthorsAddDto saveDto) 
        {
            Authors authors = new Authors()
            {
                au_id = saveDto.au_id,
                au_lname = saveDto.au_lname,
                au_fname = saveDto.au_fname,
                phone = saveDto.phone,
                address = saveDto.address,
                city = saveDto.city,
                state = saveDto.state,
                zip = saveDto.zip,
                contract = saveDto.contract,
                StartDate = saveDto.StartDate,
                CreationDate = saveDto.CreationDate,
                CreationUser = saveDto.CreationUser
            };
            return authors;
        }
    }
}
