using CreditAppVTP.Contexts;
using CreditAppVTP.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CreditAppVTP.Validations
{
    public class AppUserValidation : AbstractValidator<AppUser>
    {
        private readonly CreditDbContext _context;

        public AppUserValidation(CreditDbContext context)
        {
            _context = context;
        }

        public AppUserValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x => x.Fathername).NotNull().NotEmpty();
            RuleFor(x => x.RegisAdress).NotNull().NotEmpty();
            RuleFor(x => x.Location).NotNull().NotEmpty();
            RuleFor(x => x.Mobil).NotNull().NotEmpty();
            RuleFor(x => x.HomeNum).NotNull().NotEmpty();
            RuleFor(x => x.Date).NotNull().NotEmpty();
            RuleFor(x => x.FIN).NotNull().NotEmpty().Must(UniqueNameField).WithMessage("Bu FIN'de istifadeci artiq movcuddur.");
            RuleFor(x => x.Seria).NotNull().NotEmpty().Must(UniqueNameField).WithMessage("Bu Seria'da istifadeci artiq movcuddur.");
        }

        private bool UniqueNameField(string name)
        {
            var exist = _context.AppUsers.Where(x => x.FIN == name).FirstOrDefault();
            if (exist == null)
                return false;
            return true;
        }
    }
}
