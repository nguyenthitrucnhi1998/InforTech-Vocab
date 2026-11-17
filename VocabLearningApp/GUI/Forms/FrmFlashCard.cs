using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmFlashCard : DevExpress.XtraEditors.XtraForm {
        PracticeBus _busPractice = new();
        List<FlashCardItemDTO> _flashCardCollection = new();

        bool _isFrontSide = true;
        int _index = 0;
        int _total = 0;

        public FrmFlashCard(List<FlatTermDTO> lstTerms) {
            InitializeComponent();
            if (clsGlobalVariables.SelectedTermType == EnumTermType.FE) {
                lstTerms = lstTerms.Where(x => x.TermTypeId == Convert.ToInt32(EnumTermType.FE)).ToList();
            }
            _flashCardCollection = _busPractice.BuildFlashCards(lstTerms);
            _total = _flashCardCollection.Count;
        }
        private void FrmFlashCard_Load(object sender, EventArgs e) {
            DisplayCurrentCard();
        }
        private void btnPrev_Click(object sender, EventArgs e) {
            if (_index > 0) {
                _index--;
            }
            else {
                return;
            }

            _isFrontSide = true;
            DisplayCurrentCard();
        }
        private void btnView_Click(object sender, EventArgs e) {
            var frm = new FrmTermDetail(_flashCardCollection[_index].TermId);
            frm.ShowDialog();
        }
        private void btnFlip_Click(object sender, EventArgs e) {
            _isFrontSide = !_isFrontSide;
            DisplayCurrentCard();
        }
        private void btnNext_Click(object sender, EventArgs e) {
            if (_index < _total - 1) {
                _index++;
            }
            else {
                return;
            }

            _isFrontSide = true;
            DisplayCurrentCard();
        }

        private void DisplayCurrentCard() {
            if (_isFrontSide) {
                labelControlText.ForeColor = Color.Firebrick;
                labelControlText.Text = _flashCardCollection[_index].FrontText;
                labelControlPronounce.Text = _flashCardCollection[_index].Pronounce;
            }
            else {
                labelControlText.ForeColor = Color.Black;
                labelControlText.Text = _flashCardCollection[_index].BackText;
                labelControlPronounce.Text = "";
            }
            labelControlIndex.Text = $"{_index + 1} / {_total}";
            UpdateNavigationState();
        }
        private void UpdateNavigationState() {
            btnPrev.Enabled = _index > 0;
            btnNext.Enabled = _index < _total - 1;
        }
    }
}