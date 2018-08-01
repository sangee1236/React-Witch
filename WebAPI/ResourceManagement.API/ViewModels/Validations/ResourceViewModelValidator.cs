using FluentValidation;

namespace ResourceManagement.API.ViewModels.Validations
{
    public class ResourceViewModelValidator : AbstractValidator<ResourceViewModel>
    {
        public ResourceViewModelValidator()
        {
            RuleFor(resource => resource.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
