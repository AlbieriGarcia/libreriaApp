using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Title;
using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaApp.BLL.Validations
{
    public static class TitleValidation
    {
        public static ServiceResult IsValidTitleAdd(TitleAddDto addDto)
        {
            ServiceResult result = new ServiceResult();


            if (string.IsNullOrEmpty(addDto.title))
            {
                result.Success = false;
                result.Message = "El nombre del título es requerido";
                return result;
            }

            if (addDto.title.Length > 80)
            {
                result.Success = false;
                result.Message = "La logitud del nombre es inválida";
                return result;
            }

            if (string.IsNullOrEmpty(addDto.type))
            {
                result.Success = false;
                result.Message = "El tipo es requerido";
                return result;
            }
            if (addDto.type.Length > 30)
            {
                result.Success = false;
                result.Message = "La logintud del tipo es inválida";
                return result;
            }

            if (addDto.notes.Length > 250)
            {
                result.Success = false;
                result.Message = "La logintud de la descripción es inválida";
                return result;
            }

            return result;
        }
        public static ServiceResult IsValidTitleUpd(TitleUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(updateDto.title))
            {
                result.Success = false;
                result.Message = "El nombre del título es requerido";
                return result;
            }

            if (updateDto.title.Length > 80)
            {
                result.Success = false;
                result.Message = "La logitud del nombre es inválida";
                return result;
            }

            if (string.IsNullOrEmpty(updateDto.type))
            {
                result.Success = false;
                result.Message = "El tipo es requerido";
                return result;
            }
            if (updateDto.type.Length > 30)
            {
                result.Success = false;
                result.Message = "La logintud del tipo es inválida";
                return result;
            }

            if (updateDto.notes.Length > 250)
            {
                result.Success = false;
                result.Message = "La logintud de la descripción es inválida";
                return result;
            }

            return result;
        }
    }
}
