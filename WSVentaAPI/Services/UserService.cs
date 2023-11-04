using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WSVentaAPI.Models;
using WSVentaAPI.Models.Common;
using WSVentaAPI.Models.Request;
using WSVentaAPI.Models.Response;
using WSVentaAPI.Tools;
using System.Security.Claims;

namespace WSVentaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;


        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();

            using(var db = new VentaRealContext())
            {
                string spassword = Encrypt.GetSHA256(model.Password);

                var user = db.Users.Where(d => d.Email == model.Email &&
                                             d.Password == spassword).FirstOrDefault();

                if (user == null) return null;

                userResponse.Email = user.Email;
                userResponse.Token = GetToken(user);
            }
         
            return userResponse;
        }



        public string Auth2(string name)
        {
            return "";
        }


        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }          
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
