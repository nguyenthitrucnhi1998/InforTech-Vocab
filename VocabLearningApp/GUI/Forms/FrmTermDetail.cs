using System;
using System.Threading.Tasks;
using VocabLearningApp.BUS;
using VocabLearningApp.GUI.Common;
using static VocabLearningApp.GUI.Common.clsCommon;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmTermDetail : DevExpress.XtraEditors.XtraForm {
        TermBus _busTerm = new();
        int _termId = 0;

        public FrmTermDetail(int termId) {
            InitializeComponent();
            _termId = termId;
        }

        private async void FrmTermDetail_Load(object sender, EventArgs e) {
            CommonConfig();
            await LoadDataMain();
        }
        private void CommonConfig() {
            fTermPath.ReadOnly = true;
            fTermName.ReadOnly = true;
            fPronounce.ReadOnly = true;
            fMeaning.ReadOnly = true;
        }
        private async Task LoadDataMain() {
            try {
                CommonHandler.ClearControlData(layoutControlGroupEditControl);
                var term = await _busTerm.GetByIdAsync(_termId);
                fTermPath.EditValue = await _busTerm.GetTermPathAsync(_termId);
                fTermName.EditValue = term.TermName;
                fPronounce.EditValue = term.Pronounce;
                fMeaning.EditValue = term.Meaning;
                webBrowser1.DocumentText = term.MetaData;
                fImageData.EditValue = term.ImageData?.DecompressBytes();
            }
            catch {
                throw;
            }
        }

        private void btnAddToVocabBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var frm = new FrmEnrichVocabBook(_termId);
            frm.ShowDialog();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.Close();
        }
    }
}