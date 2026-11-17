using FluentValidation;
using VocabLearningApp.DAL.EntityModels;

namespace VocabLearningApp.GUI.Validators {
    public class VocabBookValidator : BaseValidator<VocabBook> {
        public VocabBookValidator() {
            RuleFor(x => x.VocabBookName).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(VocabBook.VocabBookName)));
        }
    }
}
