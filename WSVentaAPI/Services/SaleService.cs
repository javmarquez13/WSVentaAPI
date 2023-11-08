using WSVentaAPI.Models;
using WSVentaAPI.Models.Request;
using WSVentaAPI.Models.Response;
using Concept = WSVentaAPI.Models.Concept;

namespace WSVentaAPI.Services
{
    public class SaleService : ISaleService
    {
        public void Add(SaleRequest oModel)
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var sale = new Sale();
                        sale.Date = DateTime.Now;
                        sale.IdClient = oModel.IdClient;
                        sale.Total = oModel.Concept.Sum(d => d.UnitPrice * d.Quantity);
                        db.Sales.Add(sale);
                        db.SaveChanges();

                        foreach (var modelConcept in oModel.Concept)
                        {
                            Concept concept = new Concept();

                            concept.Quantity = modelConcept.Quantity;
                            concept.IdProduct = modelConcept.IdProduct;
                            concept.Import = modelConcept.Import;
                            concept.UnitPrice = modelConcept.UnitPrice;
                            concept.IdSale = sale.Id;
                            db.Concepts.Add(concept);
                            db.SaveChanges();
                        }

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
    }
}
