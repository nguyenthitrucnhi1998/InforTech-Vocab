using FluentValidation;
using VocabLearningApp.DAL.EntityModels;

namespace VocabLearningApp.GUI.Validators {
    public class LessonValidator : BaseValidator<Lesson> {
        public LessonValidator() {
            RuleFor(x => x.ChapterId).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Lesson.Chapter)));
            RuleFor(x => x.SortOrder).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Lesson.SortOrder)));
            RuleFor(x => x.LessonName).NotEmpty().WithMessage(string.Format(strMess_MissingRequirements, nameof(Lesson.LessonName)));
        }
    }
}
