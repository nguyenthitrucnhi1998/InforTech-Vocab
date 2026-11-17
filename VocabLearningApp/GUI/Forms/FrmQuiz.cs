using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmQuiz : DevExpress.XtraEditors.XtraForm {
        PracticeBus _busPractice = new();
        List<QuizQuestionDTO> _quizCollection = new List<QuizQuestionDTO>();

        int _index = 0;
        int _total = 0;

        bool _isReviewMode = false;
        QuizResultDTO _quizResult;

        public FrmQuiz(List<FlatTermDTO> lstTerms) {
            InitializeComponent();
            if (clsGlobalVariables.SelectedTermType == EnumTermType.FE) {
                lstTerms = lstTerms.Where(x => x.TermTypeId == Convert.ToInt32(EnumTermType.FE)).ToList();
            }
            _quizCollection = _busPractice.BuildQuizCollection(lstTerms, lstTerms.Count);
            _total = _quizCollection.Count;
        }
        private void FrmQuiz_Load(object sender, EventArgs e) {
            DisplayCurrentQuiz();
        }
        private void radioGroupAnswers_EditValueChanged(object sender, EventArgs e) {
            if (_index < 0 || _index >= _total) return;

            var quiz = _quizCollection[_index];
            quiz.SelectedAnswerIndex = radioGroupAnswers.EditValue as int?;
        }
        private void btnPrev_Click(object sender, EventArgs e) {
            if (_index > 0) {
                _index--;
            }
            else {
                return;
            }

            DisplayCurrentQuiz();
        }
        private void btnRetry_Click(object sender, EventArgs e) {
            RetryQuiz();
        }
        private void btnSubmit_Click(object sender, EventArgs e) {
            var numAnswered = _quizCollection.Count(x => x.SelectedAnswerIndex != null);
            var numNnanswered = _total - numAnswered;

            if (numNnanswered > 0) {
                if (XtraMessageBox.Show($"未回答の質問が {numNnanswered} 件あります。\nこのまま送信しますか？", "Confirm Submission",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }
            }
            else if (XtraMessageBox.Show($"送信してもよろしいですか？", "Confirm Submission",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                return;
            }

            SubmitQuiz();
        }
        private void btnNext_Click(object sender, EventArgs e) {
            if (_index < _total - 1) {
                _index++;
            }
            else {
                return;
            }

            DisplayCurrentQuiz();
        }

        private void DisplayCurrentQuiz() {
            var quiz = _quizCollection[_index];

            labelControlText.Text = _quizCollection[_index].QuestionText;
            labelControlIndex.Text = $"{_index + 1} / {_total}";

            radioGroupAnswers.Properties.Items.Clear();
            for (int i = 0; i < quiz.Answers.Count; i++) {
                string prefix = $"{(char)('A' + i)}. ";
                if (_isReviewMode) {
                    if (i == quiz.CorrectAnswerIndex) {
                        prefix = "[✔️] " + prefix;
                    }
                    else if (quiz.SelectedAnswerIndex == i && quiz.SelectedAnswerIndex != quiz.CorrectAnswerIndex) {
                        prefix = "[✘] " + prefix;
                    }
                }
                else {
                    labelControlScore.Text = "";
                    labelControlWrongAnswers.Text = "";
                }
                radioGroupAnswers.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(i, prefix + quiz.Answers[i].Text));
            }

            radioGroupAnswers.EditValue = quiz.SelectedAnswerIndex;
            UpdateNavigationState();
        }
        private void UpdateNavigationState() {
            btnPrev.Enabled = _index > 0;
            btnNext.Enabled = _index < _total - 1;
        }
        private void RetryQuiz() {
            _isReviewMode = false;
            _quizResult = null;
            _index = 0;

            foreach (var q in _quizCollection) {
                q.SelectedAnswerIndex = null;
            }

            radioGroupAnswers.ReadOnly = false;
            btnSubmit.Enabled = true;

            DisplayCurrentQuiz();
        }
        private void SubmitQuiz() {
            var userAnswers = _quizCollection.Select(q => q.SelectedAnswerIndex ?? -1).ToList();

            _quizResult = _busPractice.EvaluateQuiz(_quizCollection, userAnswers);
            _isReviewMode = true;

            radioGroupAnswers.ReadOnly = true;
            btnSubmit.Enabled = false;

            ShowQuizResult(_quizResult);
            DisplayCurrentQuiz();
        }
        private void ShowQuizResult(QuizResultDTO result) {
            var scoreText = $"Score: {result.CorrectAnswers} / {result.TotalQuestions}";
            var wrongCount = result.WrongQuestionIds.Count;

            labelControlScore.Text = scoreText;
            labelControlWrongAnswers.Text = $"Wrong answers: {wrongCount}";
        }
    }
}