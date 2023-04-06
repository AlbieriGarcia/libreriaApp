using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaApp.BLL.Validations
{
    public static class ValidationAuthors
    {
        public static ServiceResult IsValidAuthorsAdd(AuthorsAddDto authorsAddDto)
        {
            ServiceResult result = new ServiceResult();


            if (string.IsNullOrEmpty(authorsAddDto.au_id))
            {
                result.Success = false;
                result.Message = "El id del autor es requerido";
                return result;
            }

            if (string.IsNullOrEmpty(authorsAddDto.au_fname))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }

            if (authorsAddDto.au_fname.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es inválida";
                return result;
            }

            if (string.IsNullOrEmpty(authorsAddDto.au_lname))
            {
                result.Success = false;
                result.Message = "El apellido es requerido";
                return result;
            }

            if (authorsAddDto.au_lname.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud del apellido es invalido";
                return result;
            }

            if (string.IsNullOrEmpty(authorsAddDto.phone))
            {
                result.Success = false;
                result.Message = "El telefono es requerido";
                return result;
            }

            if (authorsAddDto.address.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud de la direccion es invalida";
                return result;
            }

            if (authorsAddDto.city.Length > 20)
            {
                result.Success = false;
                result.Message = "La longitud de la ciudad es invalida";
                return result;
            }

            if (authorsAddDto.state.Length > 2)
            {
                result.Success = false;
                result.Message = "La longitud de la state es invalida";
                return result;
            }
            return result;
        }

        public static ServiceResult IsValidAuthorsUpd(AuthorsUpdateDto authorsUpdateDto)
        {
            ServiceResult result = new ServiceResult();


            if (string.IsNullOrEmpty(authorsUpdateDto.au_id))
            {
                result.Success = false;
                result.Message = "El id del autor es requerido";
                return result;
            }

            if (string.IsNullOrEmpty(authorsUpdateDto.au_fname))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }

            if (authorsUpdateDto.au_fname.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es inválida";
                return result;
            }

            if (string.IsNullOrEmpty(authorsUpdateDto.au_lname))
            {
                result.Success = false;
                result.Message = "El apellido es requerido";
                return result;
            }

            if (authorsUpdateDto.au_lname.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud del apellido es invalido";
                return result;
            }

            if (string.IsNullOrEmpty(authorsUpdateDto.phone))
            {
                result.Success = false;
                result.Message = "El telefono es requerido";
                return result;
            }

            if (authorsUpdateDto.address.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud de la direccion es invalida";
                return result;
            }

            if (authorsUpdateDto.city.Length > 20)
            {
                result.Success = false;
                result.Message = "La longitud de la ciudad es invalida";
                return result;
            }

            if (authorsUpdateDto.state.Length > 2)
            {
                result.Success = false;
                result.Message = "La longitud de la state es invalida";
                return result;
            }
            return result;
        }
    }
}
