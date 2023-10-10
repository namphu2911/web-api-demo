using DemoNP.API.Models.DTO;
using FluentValidation;

namespace DemoNP.API.Validators
{
    public class AddWalkDifficultyRequestValidator : AbstractValidator<AddWalkDifficultyRequest>
    {
        public AddWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
