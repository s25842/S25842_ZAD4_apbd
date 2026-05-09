using S25842_ZAD4.Models;

namespace S25842_ZAD4.Validator;
using FluentValidation;
public class RoomValidator : AbstractValidator<Room>
{
    public RoomValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x=>x.BuildingCode).NotEmpty();
        RuleFor(x => x.Capacity).NotEmpty().GreaterThan(0);

    }
}