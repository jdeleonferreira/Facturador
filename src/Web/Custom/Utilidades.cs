using Facturador.Web.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Facturador.Web.Custom
{
    public class Utilidades
    {
        //Inyeccion de dependecia
        private IConfiguration _configuration;
        public Utilidades(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Encriptara literal que pasemos.
        public string EncriptationSHA256(string cadena)
        {
            //Instaciamos clase sha256hash para acceder a sus metodos
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //Calculamos hash en un ARREGLO < -importante - standar internacional
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(cadena));

                //Convertimos el array en bytes a string
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();

            }

        }

        public string GenerarJWT(Customer modelo)
        {
            //Creamo el usuario para el customer
            var customerClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.Id.ToString()),
                new Claim(ClaimTypes.Email, modelo.Email!)
            };

            //Tomando la key asignada del appsetting 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Crear configuracion del token
            var JwtConfig = new JwtSecurityToken(
                claims: customerClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken( JwtConfig );

        }




    }
}










