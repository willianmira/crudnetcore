using FluentValidation;
using Model.Crud.NetCore.Domain.Model;

namespace Model.Crud.NetCore.Application.Validators
{
    public class ClienteValidator : AbstractValidator<RequestCliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                    .WithMessage($"{nameof(RequestCliente.Nome)} precisa ser preenchido.");
             
            RuleFor(x => x.Idade)
                .ExclusiveBetween(0, int.MaxValue) 
                    .WithMessage($"{nameof(RequestCliente.Idade)}  deve ser maior que zero.");
        }
    }
}
