using FluentValidation;
using VocabLearningApp.DAL.EntityModels;

namespace VocabLearningApp.GUI.Validators {
    public class TermValidator : BaseValidator<Term> {
        public TermValidator() {
            RuleFor(x => x.LessonId).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Term.Lesson)));
            RuleFor(x => x.TermName).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Term.TermName)));
            RuleFor(x => x.Pronounce).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Term.Pronounce)));
            RuleFor(x => x.Meaning).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Term.Meaning)));
        }
    }
}
