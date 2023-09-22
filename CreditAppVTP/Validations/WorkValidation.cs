using CreditAppVTP.Models;
using FluentValidation;

namespace CreditAppVTP.Validations
{
    public class WorkValidation : AbstractValidator<Work>
    {
        public WorkValidation()
        {
            RuleFor(x => x.Adress).NotNull().NotEmpty();
            RuleFor(x => x.ExpMonth).NotNull().NotEmpty();
            RuleFor(x => x.Region).NotNull().NotEmpty();
            RuleFor(x => x.Salary).NotNull().NotEmpty();
            RuleFor(x => x.ExpYear).NotNull().NotEmpty();
            RuleFor(x => x.WorkName).NotNull().NotEmpty();
        }
    }
}
