using Microsoft.AspNetCore.Mvc;
using WSVentaAPI.Models.Request;
using WSVentaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using WSVentaAPI.Models.Response;
using WSVentaAPI.Services;

namespace WSVentaAPI.Controllers
{
    [ApiController]
    [Route("WSVenta/Clientes")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        IClientService _iClientService;

        public ClientController(IClientService iClientService) 
        {
            _iClientService = iClientService;
        }


        [HttpGet]
        [Route("List")]
        public IActionResult Get()
        {
            Response _oResponse = new Response();
            try
            {
                var _list = _iClientService.Get();
                _oResponse.Success = true;
                _oResponse.Message = "";
                _oResponse.Data = _list;
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
        public IActionResult Add([FromBody] ClientRequest oModel)
        {
            Response _oResponse = new Response();
            try
            {
                _iClientService.Add(oModel);
                _oResponse.Success = true;
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
        public IActionResult Update(ClientRequest oModel)
        {
            Response _oResponse = new Response();
            try
            {
                _iClientService.Update(oModel);
                _oResponse.Success = true;
            }
            catch (Exception ex)
            {
                _oResponse.Success = false;
                _oResponse.Message = ex.Message;
                _oResponse.Data = "";
            }


            return Ok(_oResponse);
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Client oModel)
        {
            Response _oResponse = new Response();
            try
            {
                _iClientService.Delete(oModel);
                _oResponse.Success = true;                
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
        public IActionResult DeleteById(int Id)
        {
            Response _oResponse = new Response();
            try
            {
               _iClientService.DeleteById(Id);
               _oResponse.Success = true;               
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
