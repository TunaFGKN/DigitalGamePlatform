using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class GameValidator: AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(g => g.GameName).NotEmpty();
            RuleFor(g => g.GameName).MinimumLength(2);
            RuleFor(g => g.GamePrice).NotEmpty();
            RuleFor(g => g.GamePrice).GreaterThan(0);
        }
    }
}
