using CreditAppVTP.Models;
using FluentValidation;

namespace CreditAppVTP.Validations
{
    public class CreditValidation : AbstractValidator<Credit>
    {
        public CreditValidation()
        {
            RuleFor(x => x.Valyuta).NotNull().NotEmpty();
            RuleFor(x => x.Interest).NotNull().NotEmpty();
            RuleFor(x => x.Month).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
            RuleFor(x => x.Purpose).NotNull().NotEmpty();
        }
    }
}
