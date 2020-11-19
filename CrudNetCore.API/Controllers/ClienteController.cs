using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Crud.NetCore.Domain.Interface.Services;
using Model.Crud.NetCore.Domain.Model;

namespace Model.Crud.NetCore.API.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ClienteController : BaseController
    {

        public readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService, ILogger<ClienteController> logger) : base(logger)
        {
            _clienteService = clienteService;
        }
         

        /// <summary>
        /// Obtém cliente pelo Id.
        /// </summary>  
        /// <response code="200">Dados do Cliente.</response>
        /// <response code="400">Erros de validações.</response> 
        [HttpGet("Get/{clienteId}")]
        [ProducesResponseType(typeof(BaseResponseSwagger<ResponseCliente>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid clienteId) =>
            await TratarResultadoAsync(async () =>
            {
                var resultado = await _clienteService.Get(clienteId);
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            });


        /// <summary>
        /// Obtém lista de clientes.
        /// </summary>  
        /// <response code="200">Retorna lista de Cliente</response>
        /// <response code="400">Erros de validações.</response> 
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(BaseResponseSwagger<IEnumerable<ResponseCliente>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll() =>
            await TratarResultadoAsync(async () =>
            {
                var resultado = await _clienteService.GetAll();
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            });


        /// <summary>
        /// Cadastra o Cliente.
        /// </summary>  
        /// <response code="200">Cadastro do Cliente.</response>
        /// <response code="400">Erros de validações.</response> 
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseSwagger<ResponseCliente>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(RequestCliente cliente) =>
            await TratarResultadoAsync(async () =>
            {
                var resultado = await _clienteService.Post(cliente);
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            });

        /// <summary>
        /// Atualiza dados do Cliente
        /// </summary>  
        /// <response code="200">Atualiza Cliente.</response>
        /// <response code="400">Erros de validações.</response> 
        [HttpPut]
        [ProducesResponseType(typeof(BaseResponseSwagger<ResponseCliente>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(RequestCliente cliente) =>
            await TratarResultadoAsync(async () =>
            {
                var resultado = await _clienteService.Put(cliente);
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            });

        /// <summary>
        /// Exclui o Cliente.
        /// </summary>  
        /// <response code="200">Exclui Cliente.</response>
        /// <response code="400">Erros de validações.</response> 
        [HttpDelete]
        [ProducesResponseType(typeof(BaseResponseSwagger<ResponseCliente>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid clienteId) =>
            await TratarResultadoAsync(async () =>
            {
                var resultado = await _clienteService.Delete(clienteId);
                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            });

    }
}
