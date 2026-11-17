using FluentValidation;
using VocabLearningApp.DAL.EntityModels;

namespace VocabLearningApp.GUI.Validators {
    public class ChapterValidator : BaseValidator<Chapter> {
        public ChapterValidator() {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Chapter.Category)));
            RuleFor(x => x.SortOrder).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Chapter.SortOrder)));
            RuleFor(x => x.ChapterName).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Chapter.ChapterName)));
        }
    }
}
