using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DTOs.DTOs;

namespace StellarMindsWebApi.JWTHandler
{
    public class JWTHandler
    {
        public static string GenerarToken(UsuarioDTO usuarioDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //clave secreta, generalmente se incluye en el archivo de configuración
            //Debe ser un vector de bytes 

            var clave = Encoding.ASCII.GetBytes("ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=");

            //Se incluye un claim para el rol

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioDto.Username),
                    new Claim(ClaimTypes.Role, usuarioDto.Rol)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
