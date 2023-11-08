using WSVentaAPI.Models;
using WSVentaAPI.Models.Request;

namespace WSVentaAPI.Services
{
    public class ClientService : IClientService
    {
        public object Get()
        {
            using(VentaRealContext db = new VentaRealContext())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _list = db.Clients.OrderByDescending(d => d.Id).ToList();
                        return _list;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }


        public void Add(ClientRequest oModel)
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Client _oCliente = new Client();
                        _oCliente.Name = oModel.Name;

                        db.Clients.Add(_oCliente);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public void Update(ClientRequest oModel)
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Client oCliente = db.Clients.Find(oModel.Id);

                        oCliente.Name = oModel.Name;
                        db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();

                        transaction.Commit();
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public void Delete(Client oModel)
        {
            using(VentaRealContext db = new VentaRealContext())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Client _oCliente = db.Clients.Find(oModel.Id);
                        db.Remove(_oCliente);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        
        public void DeleteById(int Id)
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Client oCliente = db.Clients.Find(Id);
                        db.Remove(oCliente);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }

            }
        }
    }
}
