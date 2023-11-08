using System.ComponentModel.DataAnnotations;

namespace WSVentaAPI.Models.Request
{
    public class SaleRequest
    {
        [Required]
        [Range(1, double.MaxValue)]
        [ClientExistAttribute(ErrorMessage = "Client does not exist")]
        public int IdClient { get; set; }

        [Required]
        [MinLength(1)]
        public List<Concept> Concept {get; set;}

        public SaleRequest()
        {
            this.Concept = new List<Concept>();
        }

     }
    

    public class Concept
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Import { get; set; }

        [Required]
        [ProductExistAttribute(ErrorMessage ="Product Id Does not Exist")]
        public int IdProduct { get; set; }
    }


    #region Validations

    public class ClientExistAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int idClient = (int)value;

            using(var db = new Models.VentaRealContext())
            {
                if (db.Clients.Find(idClient) == null) return false;
            }

            return true;
        }
    }


    public class ProductExistAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int IdProduct = (int)value;

            using (var db = new Models.VentaRealContext())
            {
                if (db.Products.Find(IdProduct) == null) return false;
            }

            return true;
        }
    }


    #endregion


}
