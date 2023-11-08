using System.ComponentModel.DataAnnotations;

namespace WSVentaAPI.Models.Request
{
    public class ClientRequest
    {

       
        public int Id { get; set; }

        [ClientAlreadyExist(ErrorMessage = "Client Already Exist")]
        public string Name { get; set; }
    }

    public class ClientAlreadyExistAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string nameClient = (string)value;

            using (var db = new Models.VentaRealContext())
            {
                if (db.Clients.FirstOrDefault(d => d.Name == nameClient) == null) return true;
            }

            return false;
        }
    }
}
