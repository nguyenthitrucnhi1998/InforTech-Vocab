using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VocabLearningApp.DAL.DTO;

namespace VocabLearningApp.BUS {
    public enum EnumQuizType {
        TermToMeaning,
        MeaningToTerm
    }

    public class PracticeBus {
        private static void Shuffle<T>(IList<T> list) {
            var rng = new Random();
            for (int i = list.Count - 1; i > 0; i--) {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        public List<FlashCardItemDTO> BuildFlashCards(List<FlatTermDTO> terms) {
            Shuffle(terms);
            return terms.Select(t => new FlashCardItemDTO {
                TermId = t.TermId,
                FrontText = t.TermName,
                BackText = t.Meaning,
                Pronounce = t.Pronounce
            }).ToList();
        }

        public QuizQuestionDTO BuildQuizQuestion(FlatTermDTO correctTerm, List<FlatTermDTO> allTerms, EnumQuizType type) {
            var random = new Random();

            // get 3 wrong answers
            var wrongAnswers = allTerms
                .Where(x => x.TermId != correctTerm.TermId)
                .OrderBy(_ => random.Next())
                .Take(3)
                .ToList();

            var answers = new List<QuizAnswerDTO>();

            if (type == EnumQuizType.TermToMeaning) {
                answers.Add(new QuizAnswerDTO { Text = correctTerm.Meaning });
                answers.AddRange(wrongAnswers.Select(x => new QuizAnswerDTO { Text = x.Meaning }));

                Shuffle(answers);

                return new QuizQuestionDTO {
                    QuestionText = correctTerm.TermName,
                    Answers = answers,
                    CorrectAnswerIndex = answers.FindIndex(a => a.Text == correctTerm.Meaning)
                };
            }
            else {
                answers.Add(new QuizAnswerDTO { Text = correctTerm.TermName });
                answers.AddRange(wrongAnswers.Select(x => new QuizAnswerDTO { Text = x.TermName }));

                Shuffle(answers);

                return new QuizQuestionDTO {
                    QuestionText = correctTerm.Meaning,
                    Answers = answers,
                    CorrectAnswerIndex = answers.FindIndex(a => a.Text == correctTerm.TermName)
                };
            }
        }

        public List<QuizQuestionDTO> BuildQuizCollection(List<FlatTermDTO> terms, int numberOfQuestions) {
            Shuffle(terms);

            var quizList = new List<QuizQuestionDTO>();
            var quizTypes = new[] { EnumQuizType.TermToMeaning, EnumQuizType.MeaningToTerm };

            for (int i = 0; i < numberOfQuestions && i < terms.Count; i++) {
                var type = quizTypes[i % 2];
                var question = BuildQuizQuestion(terms[i], terms, type);
                question.QuestionId = i + 1;

                quizList.Add(question);
            }

            return quizList;
        }

        public QuizResultDTO EvaluateQuiz(List<QuizQuestionDTO> questions, List<int> userAnswers) {
            var result = new QuizResultDTO {
                TotalQuestions = questions.Count
            };

            for (int i = 0; i < questions.Count; i++) {
                if (questions[i].CorrectAnswerIndex == userAnswers[i])
                    result.CorrectAnswers++;
                else
                    result.WrongQuestionIds.Add(questions[i].QuestionId);
            }

            return result;
        }
    }
}
