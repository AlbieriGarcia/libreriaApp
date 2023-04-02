using libreriaApp.BLL.Dtos.Title;
using libreriaApp.DAL.Entities;

namespace libreriaApp.BLL.Extentions
{
    public static class TitleExtention
    {
        public static Title GetTitleEntityFromDtoSave(this TitleAddDto titleAdd)
        {
            Title title = new Title()
            {
                title_id = titleAdd.title_id,
                title = titleAdd.title,
                type = titleAdd.type,
                price = titleAdd.price,
                advance = titleAdd.advance,
                royalty = titleAdd.royalty,
                ytd_sales = titleAdd.ytd_sales,
                notes = titleAdd.notes,
                pubdate = titleAdd.pubdate,
                CreationDate = titleAdd.CreationDate,
                CreationUser = titleAdd.CreationUser,
            };

            return title;
        }
    }
}
