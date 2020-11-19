using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Model.Crud.NetCore.Application.Validators;
using Model.Crud.NetCore.Domain.Interface.Repository;
using Model.Crud.NetCore.Domain.Interface.Services;
using Model.Crud.NetCore.Domain.Model;
using System;
using System.Threading.Tasks;


namespace Model.Crud.NetCore.Application.Services
{
    public class ClienteService : BaseService, IClienteService
    { 
        protected readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper, ILogger<ClienteService> logger) : base (mapper, logger)
        { 
            _clienteRepository = clienteRepository;
        }

        public async Task<BaseResponse> GetAll()
        { 
            try 
            {
                _logger.LogInformation("Inicio busca lista de clientes");

                await ObterStatusCode(
                        "Lista de cliente carregada com sucesso.", 
                        StatusCodes.Status200OK,
                        await _clienteRepository.GetAll());
            }
            catch(Exception e) {
                await ObterStatusCode( 
                        "Erro ao retornar lista de clientes: " + e, 
                        StatusCodes.Status400BadRequest); 
            }

            return _baseResponse;
        }

        public async Task<BaseResponse> Get(Guid Id)
        {
            try
            {
                _logger.LogInformation("Inicio busca do cliente pelo Guid Id");

                if ((await ValidarRequest(new GuidValidator(), Id)) != null)
                      return _baseResponse;

                    await ObterStatusCode(
                        "Cliente carregado com sucesso.",
                        StatusCodes.Status200OK,
                        await _clienteRepository.Get(Id));
            }
            catch (Exception e)
            {
                await ObterStatusCode( 
                        "Erro ao retornar o cliente: " + e,
                        StatusCodes.Status400BadRequest);
            }

            return _baseResponse;
        }

        public async Task<BaseResponse> Post(RequestCliente request)
        {
            try
            {
                _logger.LogInformation("Iniciando cadastro do cliente.");

                if ((await ValidarRequest(new ClienteValidator(), request)) != null)
                    return _baseResponse;

                var entity = _mapper.Map<Domain.Entity.Cliente>(request);

                await ObterStatusCode(
                    "Cliente carregado com sucesso.",
                    StatusCodes.Status201Created,
                    await _clienteRepository.Post(entity));
            }
            catch (Exception e)
            {
                await ObterStatusCode( 
                        "Erro ao cadastrar o cliente: " + e,
                        StatusCodes.Status400BadRequest);
            }

            return _baseResponse;
        }

        public async Task<BaseResponse> Put(RequestCliente request)
        {
            try
            {
                _logger.LogInformation("Iniciando cadastro do cliente.");

                if ((await ValidarRequest(new GuidValidator(), request.Id)) != null)
                    return _baseResponse;

                if ((await ValidarRequest(new ClienteValidator(), request)) != null)
                    return _baseResponse;
                 
                var entity = await _clienteRepository.Get(request.Id);

                if(entity != null)
                {
                    entity.Idade = request.Idade;
                    entity.Nome = request.Nome;

                    await ObterStatusCode(
                         "Cliente atualizado com sucesso.",
                         StatusCodes.Status200OK,
                         await _clienteRepository.Put(entity));
                }
                else
                {
                    await ObterStatusCode( 
                        "Cliente informado não localizado.",
                        StatusCodes.Status400BadRequest);
                }
             
            }
            catch (Exception e)
            {
                await ObterStatusCode( 
                        "Erro ao atualizar o cliente: " + e,
                        StatusCodes.Status400BadRequest);
            }

            return _baseResponse;
        }


        public async Task<BaseResponse> Delete(Guid Id)
        {
            try
            {
                _logger.LogInformation("Iniciando cadastro do cliente.");

                if ((await ValidarRequest(new GuidValidator(), Id)) != null)
                    return _baseResponse;
                 

                var entity = await _clienteRepository.Get(Id);

                if (entity != null)
                    await ObterStatusCode( 
                         "Cliente atualizado com sucesso.",
                         StatusCodes.Status200OK,
                         await _clienteRepository.Delete(entity)); 
                else
                    await ObterStatusCode( 
                        "Cliente informado não localizado.",
                        StatusCodes.Status400BadRequest);
                

            }
            catch (Exception e)
            {
                await ObterStatusCode( 
                        "Erro ao atualizar o cliente: " + e,
                        StatusCodes.Status400BadRequest);
            }

            return _baseResponse;
        }


    }
}
