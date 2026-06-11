using DTOs.DTOs;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class LoginDTOMapper
    {
        public static LoginDTO ToDTO(Usuario usuario)
        {
            return new LoginDTO
            {
                Username = usuario.Username,
                Password = usuario.Password
            };
        }
    }
}
