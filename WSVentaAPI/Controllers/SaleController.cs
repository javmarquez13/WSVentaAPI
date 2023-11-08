using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WSVentaAPI.Models;
using WSVentaAPI.Models.Request;
using WSVentaAPI.Services;
using Response = WSVentaAPI.Models.Response.Response;

namespace WSVentaAPI.Controllers
{
    [ApiController]
    [Route("WSVenta/Sales")]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private ISaleService _sale;

        public SaleController(ISaleService sale)
        {
            this._sale = sale;
        }


        [HttpPost]
        public IActionResult Add(SaleRequest oModel)
        {
            Response Response = new Response();
            try
            {
                _sale.Add(oModel);
                Response.Success = true;
                Response.Message = "";
                Response.Data = "";

            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = ex.Message;
                Response.Data = "";
            }

            return Ok(Response);
        }
    }
}
