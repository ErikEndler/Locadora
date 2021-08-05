using ErikTeste.DTO;
using FluentValidation;

namespace ErikTeste.Validator
{
    public class ClienteDTOValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteDTOValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty();
            RuleFor(x => x.Cpf).NotNull().NotEmpty().Length(11);
        }
    }
}
