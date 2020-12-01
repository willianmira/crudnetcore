using FluentValidation; 
using System;

namespace Model.Crud.NetCore.Application.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                     .WithMessage($"Id cliente inválido.");
        }
    }
}
