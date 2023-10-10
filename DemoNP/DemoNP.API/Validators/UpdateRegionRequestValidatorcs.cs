using DemoNP.API.Models.DTO;
using FluentValidation;

namespace DemoNP.API.Validators
{
    public class UpdateRegionRequestValidatorcs : AbstractValidator<UpdateRegionRequest>
    {
        public UpdateRegionRequestValidatorcs()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
