using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Publisher;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Exceptions;
using System;

namespace libreriaApp.BLL.Validations
{
    public static class PublisherValidation
    {
        public static ServiceResult IsValidPublisherAdd(PublisherAddDto publisherAdd)
        {
            ServiceResult result = new ServiceResult();


            if (string.IsNullOrEmpty(publisherAdd.pub_id))
            {
                result.Success = false;
                result.Message = "El id es requerido";
                return result;
            }
            if (publisherAdd.pub_id.Length > 4) 
            {
                result.Success = false;
                result.Message = "La del id es invalida(max4)";
                return result;

            }
            if (string.IsNullOrEmpty(publisherAdd.pub_name))
            {
                result.Success = false;
                result.Message = "El pub_name es requerido";
            }
            if (publisherAdd.pub_name.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es invalida(max40)";
                return result;
            }
            if (string.IsNullOrEmpty(publisherAdd.city))
            {
                result.Success = false;
                result.Message = "La ciudad es requerida";
                return result;
            }
            if (publisherAdd.city.Length > 20)
            {
                result.Success = false;
                result.Message = "La longitud de la ciudad es invalidad(max20)";
                return result;
            }
            if (publisherAdd.state?.Length > 2)
            {
                result.Success = false;
                result.Message = "La longitud de state es invalidad(max2)";
                return result;
            }

            return result;
        }
        public static ServiceResult IsValidPublisherUpd(PublisherUpdateDto publisherUpdate)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(publisherUpdate.pub_id))
            {
                result.Success = false;
                result.Message = "El id es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(publisherUpdate.pub_name))
            {
                result.Success = false;
                result.Message = "El pub_name es requerido";
            }
            if (publisherUpdate.pub_name.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es invalida(max40)";
                return result;
            }
            if (string.IsNullOrEmpty(publisherUpdate.city))
            {
                result.Success = false;
                result.Message = "La ciudad es requerida";
                return result;
            }
            if (publisherUpdate.city.Length > 20)
            {
                result.Success = false;
                result.Message = "La longitud de la ciudad es invalidad(max20)";
                return result;
            }
            if (publisherUpdate.state?.Length > 2)
            {
                result.Success = false;
                result.Message = "La longitud de state es invalidad(max2)";
                return result;
            }
            return result;
        }
    }
}