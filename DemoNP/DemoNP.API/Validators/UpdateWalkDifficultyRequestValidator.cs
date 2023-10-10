using DemoNP.API.Models.DTO;
using FluentValidation;

namespace DemoNP.API.Validators
{
    public class UpdateWalkDifficultyRequestValidator : AbstractValidator<UpdateWalkDifficultyRequest>
    {
        public UpdateWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}