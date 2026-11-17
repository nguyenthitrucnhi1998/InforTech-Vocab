using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.GUI.Common;
using static VocabLearningApp.GUI.Common.clsCommon;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmVocabBookDetail : DevExpress.XtraEditors.XtraForm {
        VocabBookBus _busVocabBook = new();
        VocabBookDetailBus _busVocabBookDetail = new();
        TermBus _busTerm = new();
        int _vocabBookId = 0;

        private BindingList<FlatTermInVocabBookDetailDTO> _bindingListMain = new();

        public FrmVocabBookDetail(int vocabBookId) {
            InitializeComponent();
            _vocabBookId = vocabBookId;
        }

        private async void FrmVocabBookDetail_Load(object sender, EventArgs e) {
            CommonConfig();
            await LoadDataMain();
            await LoadDataMainGrid();
        }

        private void CommonConfig() {
            CommonHandler.PreventMouseWheelForDropdown(this);
            //CommonHandler.ConfigForGridViewHeader(this, layoutControlGroup1, gridViewMain);
            ConfigShorthandEvent();

            fVocabBookName.ReadOnly = true;
            fCreatedDate.ReadOnly = true;
            fTermPath.ReadOnly = true;

            CommonHandler.ConfigureDateEdits(fCreatedDate);
            gridViewMain.OptionsFind.AlwaysVisible = true;
        }
        private void ConfigShorthandEvent() {
            gridViewMain.RowStyle += (s, e) => {
                if (e.RowHandle < 0) return;
                if (e.RowHandle == gridViewMain.FocusedRowHandle) {
                    e.Appearance.BackColor = Color.Khaki;
                    e.HighPriority = true;
                }
            };
        }
        private async Task LoadDataMain() {
            try {
                var vocabBook = await _busVocabBook.GetByIdAsync(_vocabBookId);
                fVocabBookName.EditValue = vocabBook.VocabBookName;
                fCreatedDate.EditValue = vocabBook.CreatedDate;
            }
            catch {
                throw;
            }
        }
        private async Task LoadDataMainGrid() {
            try {
                _bindingListMain = new();

                var res = await _busVocabBookDetail.GetAllAsync(_vocabBookId);
                if (clsGlobalVariables.SelectedTermType == EnumTermType.FE) {
                    res = res.Where(x => x.TermTypeId == Convert.ToInt32(EnumTermType.FE)).ToList();
                }
                _bindingListMain = new BindingList<FlatTermInVocabBookDetailDTO>(res);

                gridControlMain.DataSource = null;
                gridControlMain.DataSource = _bindingListMain;
                CommonHandler.GridViewMain_CheckThenFocusAndSelectZeroIndexRow(gridViewMain);
            }
            catch {
                throw;
            }
        }

        private async void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            await LoadDataMainGrid();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.Close();
        }

        private async void gridViewMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (gridViewMain.RowCount > 0) {
                var objMain = (FlatTermInVocabBookDetailDTO)gridViewMain.GetFocusedRow();
                fTermPath.EditValue = await _busTerm.GetTermPathAsync(objMain.TermId);
            }
        }

        private async void repoBtnActions_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var view = gridControlMain.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle < 0) return;

            var rowData = view.GetRow(rowHandle);
            var termId = ((FlatTermInVocabBookDetailDTO)rowData).TermId;

            if (e.Button.Index == 0) {
                var frm = new FrmTermDetail(termId);
                frm.ShowDialog();
            }
            else if (e.Button.Index == 1) {
                if (XtraMessageBox.Show("用語集からこの用語を削除してもよろしいですか？", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    var res = await _busVocabBookDetail.DeleteAsync(_vocabBookId, termId);
                    if (res) {
                        CommonHandler.ShowNotificationForm("用語集からの削除に成功しました");
                        await LoadDataMainGrid();
                    }
                }
            }
        }
    }
}