using libreriaApp.BLL.Dtos.Title;
using libreriaApp.DAL.Entities;
using System;

namespace libreriaApp.BLL.Extentions
{
    public static class TitleExtention
    {
        public static Title GetTitleEntityFromDtoSave(this TitleAddDto addDto)
        {
            Title title = new Title()
            {
                title_id = addDto.title_id,
                title = addDto.title,
                type = addDto.type,
                price = addDto.price,
                advance = addDto.advance,
                royalty = addDto.royalty,
                ytd_sales = addDto.ytd_sales,
                notes = addDto.notes,
                pubdate = addDto.pubdate,
                CreationDate = addDto.CreationDate,
                CreationUser = addDto.CreationUser,
                StartDate = addDto.StartDate,
            };

            return title;
        }
    }
}
