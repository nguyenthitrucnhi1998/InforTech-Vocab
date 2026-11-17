using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.DAL.EntityModels;
using static VocabLearningApp.GUI.Common.clsCommon;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmEnrichVocabBook : DevExpress.XtraEditors.XtraForm {
        VocabBookBus _busVocabBook = new();
        VocabBookDetailBus _busVocabBookDetail = new();
        TermBus _busTerm = new();
        int _termId = 0;

        public FrmEnrichVocabBook(int termId) {
            InitializeComponent();
            _termId = termId;
        }

        private async void FrmSelectVocabBook_Load(object sender, EventArgs e) {
            await LoadDataRepo();
        }

        private async Task LoadDataRepo() {
            try {
                var term = await _busTerm.GetByIdAsync(_termId);
                labelControlInfo.Text = $"Select a VocabBook to add term \'{term.TermName}\'";

                var dataLesson = (await _busVocabBook.GetAllAsync()).Select(x => new OptionDTO {
                    OptionId = x.VocabBookId,
                    OptionName = x.VocabBookName
                }).ToList();
                var viewColumns = new List<Tuple<string, string>> {
                    new(nameof(OptionDTO.OptionName), "VocabBook Name"),
                };
                CommonHandler.LoadFromObject(fVocabBookId, dataLesson, nameof(OptionDTO.OptionId), nameof(OptionDTO.OptionName), viewColumns);
            }
            catch {
                throw;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e) {
            try {
                var obj = new VocabBookDetail {
                    VocabBookId = CommonHandler.ConvertToNullableInt(fVocabBookId.EditValue),
                    TermId = _termId,
                };
                if (obj.VocabBookId == null) {
                    XtraMessageBox.Show("用語集を選択してください", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var isExisted = await _busVocabBookDetail.IsTermAleardyExistedInVocabBook((int)obj.VocabBookId, (int)obj.TermId);
                if (isExisted) {
                    XtraMessageBox.Show("この用語は選択された用語集に既に存在します", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var res = await _busVocabBookDetail.InsertAsync(obj);
                if (res) {
                    CommonHandler.ShowNotificationForm("用語集への追加に成功しました");
                    this.Close();
                }
            }
            catch {
                throw;
            }
        }
    }
}