using DemoNP.API.Models.DTO;
using FluentValidation;

namespace DemoNP.API.Validators
{
    public class AddWalkRequestValidator : AbstractValidator<AddWalkRequest>
    {
        public AddWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
