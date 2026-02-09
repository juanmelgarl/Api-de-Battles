using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using WebApplication16.Core.Command;

namespace WebApplication16.Core.Validator
{
    public class CreateBattleValidator : AbstractValidator<CreateBattleCommmand>
    {
       public CreateBattleValidator() 
        {
            RuleFor(X => X.battle.Name).NotEmpty().NotNull().NotEqual("string").WithMessage("El nombre no puede estar vacio ni nulo ni llamarse string");
            RuleFor(x => x.battle.Description).MinimumLength(20).MaximumLength(400).WithMessage("Debe estar entre 20 y 400 caracteres");
            RuleFor(x => x.battle.BattleType).NotNull().NotEmpty().WithMessage("No puede ser nulo");
        } 
    }
}
