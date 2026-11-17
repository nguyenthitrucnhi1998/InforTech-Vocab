using FluentValidation;
using VocabLearningApp.DAL.EntityModels;

namespace VocabLearningApp.GUI.Validators {
    public class CategoryValidator : BaseValidator<Category> {
        public CategoryValidator() {
            RuleFor(x => x.SortOrder).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Category.SortOrder)));
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Category.CategoryName)));
        }
    }
}
