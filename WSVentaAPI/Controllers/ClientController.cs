using Microsoft.AspNetCore.Mvc;
using WSVentaAPI.Models.Request;
using WSVentaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using WSVentaAPI.Models.Response;

namespace WSVentaAPI.Controllers
{
    [ApiController]
    [Route("WSVenta/Clientes")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("List")]
        public IActionResult Get()
        {
            Response _oResponse = new Response();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var _list = db.Clientes.OrderByDescending(d => d.Id).ToList();
                    _oResponse.Success = true;
                    _oResponse.Message = "";
                    _oResponse.Data = _list;
                }
            }
            catch (Exception ex)
            {
                _oResponse.Success = false;
                _oResponse.Message = ex.Message;
                _oResponse.Data = "";
            }


            return Ok(_oResponse);
        }


        [HttpPost]
        [Route("Add")]
        [Produces("application/json")]
        public IActionResult Add([FromBody] ClientRequest _oModel)
        {
            Response _oResponse = new Response();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente _oCliente = new Cliente();
                    _oCliente.Name = _oModel.Name;

                    db.Clientes.Add(_oCliente);
                    db.SaveChanges();

                    _oResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                _oResponse.Success = false;
                _oResponse.Message = ex.Message;
                _oResponse.Data = "";
            }

            return Ok(_oResponse);
        }


        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(ClientRequest _oModel)
        {
            Response _oResponse = new Response();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente _oCliente = db.Clientes.Find(_oModel.Id);

                    _oCliente.Name = _oModel.Name;
                    db.Entry(_oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    _oResponse.Success = true;
                }


            }
            catch (Exception ex)
            {
                _oResponse.Success = false;
                _oResponse.Message = ex.Message;
                _oResponse.Data = "";
            }


            return Ok(_oResponse);
        }


        /// <summary>
        /// By ID
        /// </summary>
        /// <param name="_oModel"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Cliente _oModel)
        {
            Response _oResponse = new Response();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente _oCliente = db.Clientes.Find(_oModel.Id);
                    db.Remove(_oCliente);
                    db.SaveChanges();

                    _oResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                _oResponse.Success = false;
                _oResponse.Message = ex.Message;
                _oResponse.Data = "";
            }


            return Ok(_oResponse);
        }


        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete2(int Id)
        {
            Response _oResponse = new Response();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente _oCliente = db.Clientes.Find(Id);
                    db.Remove(_oCliente);
                    db.SaveChanges();
                    _oResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                _oResponse.Success = false;
                _oResponse.Message = ex.Message;
                _oResponse.Data = "";
            }


            return Ok(_oResponse);
        }
    }
}
