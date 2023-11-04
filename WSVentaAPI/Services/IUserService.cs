using WSVentaAPI.Models.Request;
using WSVentaAPI.Models.Response;

namespace WSVentaAPI.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
