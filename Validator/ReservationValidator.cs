
using S25842_ZAD4.Models;

namespace S25842_ZAD4.Validator;
using FluentValidation;

public class ReservationValidator : AbstractValidator<Reservation>
{
    public ReservationValidator()
    {
        RuleFor(x=>x.OrganizerName).NotEmpty();
        RuleFor(x=>x.Topic).NotEmpty();
        RuleFor(x=>x.EndTime).NotEmpty().GreaterThan(x=>x.StartTime);
    }
}