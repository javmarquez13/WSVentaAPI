using Microsoft.Identity.Client;
using WSVentaAPI.Models;
using WSVentaAPI.Models.Request;

namespace WSVentaAPI.Services
{
    public interface IClientService
    {
        public object Get();


        public void Add(ClientRequest oModel);

        public void Update(ClientRequest oModel);

        public void Delete(Client oModel);

        public void DeleteById(int  Id);
    }
}
