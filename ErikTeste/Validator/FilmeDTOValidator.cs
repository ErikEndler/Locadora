using ErikTeste.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErikTeste.Validator
{
    public class FilmeDTOValidator : AbstractValidator<FilmeDTO>
    {
        public FilmeDTOValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
