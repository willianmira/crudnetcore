using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Model.Crud.NetCore.Domain.Interface.Repository;
using Model.Crud.NetCore.Domain.Interface.Services;
using Model.Crud.NetCore.Domain.Model;
using System.Threading.Tasks;


namespace Model.Crud.NetCore.Application.Services
{
    public class BaseService
    { 
        protected readonly IMapper _mapper; 
        protected readonly ILogger _logger; 
        protected BaseResponse _baseResponse; 

        protected BaseService(IMapper mapper, ILogger logger)
        { 
            _mapper = mapper;
            _logger = logger; 
             
        } 

        protected async Task<BaseResponse> ValidarRequest<TValidator, TItem>(TValidator validator, TItem item) where TValidator : AbstractValidator<TItem>
        {
            var validacao = validator.Validate(item);
            if (!validacao.IsValid)
            {
                await ObterStatusCode(string.Join(" | ", validacao.Errors), StatusCodes.Status400BadRequest);

                return _baseResponse;
            }

            return default;
        }
         
        protected async Task ObterStatusCode(string mensagem, int statusCode, dynamic conteudo = null)
        {
            _baseResponse = new BaseResponse();
            _baseResponse.StatusCode = statusCode;
            _baseResponse.Mensagem = mensagem;
            _baseResponse.Conteudo = conteudo;

            if (statusCode >= 400)
                _logger.LogError(mensagem);
            else
                _logger.LogInformation(mensagem);
        } 
    }
}
