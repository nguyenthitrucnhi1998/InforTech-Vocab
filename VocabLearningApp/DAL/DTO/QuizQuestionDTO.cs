using System.Collections.Generic;

namespace VocabLearningApp.DAL.DTO {
    public class QuizQuestionDTO {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public List<QuizAnswerDTO> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public int? SelectedAnswerIndex { get; set; } // 0.A, 1.B, 2.C, 3.D
    }

    public class QuizAnswerDTO {
        public string Text { get; set; }
    }

    public class QuizResultDTO {
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public List<int> WrongQuestionIds { get; set; } = new();
    }
}
