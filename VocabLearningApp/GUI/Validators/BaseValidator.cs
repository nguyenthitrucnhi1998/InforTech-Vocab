using FluentValidation;

namespace VocabLearningApp.GUI.Validators {
    public class BaseValidator<T> : AbstractValidator<T> {
        protected readonly string strMess_MissingRequirements = "\'{0}\' is required";
    }
}
