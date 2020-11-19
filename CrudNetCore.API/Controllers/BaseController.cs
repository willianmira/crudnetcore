using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Crud.NetCore.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Model.Crud.NetCore.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    { 
        protected readonly ILogger _logger; 
        private readonly string MensagemErroPadrao = "Ocorreu um erro ao processar a solicitação. Por favor, tente novamente mais tarde.";

        protected BaseController(ILogger logger )
        {
            _logger = logger; 
        }
         
        protected async Task<IActionResult> TratarResultadoAsync(Func<Task<IActionResult>> servico)
        {
            try
            {
                return await servico();
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Mensagem = MensagemErroPadrao });
            }
        }
    }
}