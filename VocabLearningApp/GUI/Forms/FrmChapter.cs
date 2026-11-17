using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Validators;
using static VocabLearningApp.GUI.Common.clsCommon;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmChapter : DevExpress.XtraEditors.XtraForm {
        ChapterBus _busChapter = new();
        CategoryBus _busCategory = new();

        private EnumMainStatusForm _mainStatus;
        private int _curIdMain = 0;
        private int _tempNewIdMain = 0;
        private BindingList<Chapter> _bindingListMain = new();
        private const string _fieldNameId = nameof(Chapter.ChapterId);

        public FrmChapter() {
            InitializeComponent();
        }

        private async void FrmChapter_Load(object sender, EventArgs e) {
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.WAIT);
            CommonConfig();
            await LoadDataRepo();
            await LoadDataMainGrid();
        }

        private void CommonConfig() {
            CommonHandler.ConfigBarButtonFormat(btnCreate, btnEdit, btnDelete, btnSubmit, btnCancel, btnRefresh, btnClose);
            CommonHandler.PreventMouseWheelForDropdown(this);
            CommonHandler.ConfigForGridViewHeader(this, layoutControlGroupMainData, gridViewMain);
            ConfigShorthandEvent();

            gridViewMain.OptionsBehavior.Editable = false;
            gridViewMain.OptionsFind.AlwaysVisible = true;
        }
        private void ConfigShorthandEvent() {
            gridViewMain.MouseDown += (s, e) => {
                if (_mainStatus == EnumMainStatusForm.CREATE || _mainStatus == EnumMainStatusForm.EDIT) {
                    GridView view = s as GridView;
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                    DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            };
            gridViewMain.RowStyle += (s, e) => {
                if (e.RowHandle < 0) return;
                if (e.RowHandle == gridViewMain.FocusedRowHandle) {
                    e.Appearance.BackColor = Color.Khaki;
                    e.HighPriority = true;
                }
            };
        }
        private void ConfigControlStatus(EnumMainStatusForm status) {
            gridViewMain.OptionsBehavior.Editable = false;
            CommonHandler.SetReadOnlyControlData(layoutControlGroupEditControl, true);
            CommonHandler.ConfigBarButtonEnable(true, btnCreate, btnEdit, btnDelete, btnSubmit, btnCancel, btnRefresh, btnClose);
            switch (status) {
                case EnumMainStatusForm.WAIT:
                    CommonHandler.ConfigBarButtonEnable(false, btnCreate, btnEdit, btnDelete, btnSubmit, btnCancel, btnRefresh, btnClose);
                    break;
                case EnumMainStatusForm.CREATE:
                    CommonHandler.ConfigBarButtonEnable(false, btnCreate, btnEdit, btnDelete, btnRefresh, btnClose);
                    CommonHandler.SetReadOnlyControlData(layoutControlGroupEditControl, false);
                    break;
                case EnumMainStatusForm.EDIT:
                    CommonHandler.ConfigBarButtonEnable(false, btnCreate, btnEdit, btnDelete, btnRefresh, btnClose);
                    CommonHandler.SetReadOnlyControlData(layoutControlGroupEditControl, false);
                    break;
                default: // MainStatusForm.VIEW
                    CommonHandler.ClearEditControlErrorText(layoutControlGroupEditControl);
                    CommonHandler.ConfigBarButtonEnable(false, btnSubmit, btnCancel);
                    gridViewMain.Focus();
                    break;
            }
        }
        private async Task LoadDataRepo() {
            try {
                var dataCategory = (await _busCategory.GetAllAsync()).Select(x => new OptionDTO {
                    OptionId = x.CategoryId,
                    OptionName = x.CategoryName
                }).ToList();
                var viewColumns = new List<Tuple<string, string>> {
                    new(nameof(OptionDTO.OptionName), "Category"),
                };
                CommonHandler.LoadFromObject(fCategoryId, dataCategory, nameof(OptionDTO.OptionId), nameof(OptionDTO.OptionName), viewColumns);
                CommonHandler.LoadFromObject(repoCategory, dataCategory, nameof(OptionDTO.OptionId), nameof(OptionDTO.OptionName), viewColumns);
            }
            catch {
                throw;
            }
        }
        private async Task LoadDataMainGrid() {
            try {
                ConfigControlStatus(_mainStatus = EnumMainStatusForm.WAIT);
                CommonHandler.ClearControlData(layoutControlGroupEditControl);
                _bindingListMain = new();

                var res = await _busChapter.GetAllAsync();
                _bindingListMain = new BindingList<Chapter>(res);

                gridControlMain.DataSource = null;
                gridControlMain.DataSource = _bindingListMain;
                CommonHandler.GridViewMain_CheckThenFocusAndSelectZeroIndexRow(gridViewMain);
                ConfigControlStatus(_mainStatus = EnumMainStatusForm.VIEW);
            }
            catch {
                throw;
            }
        }

        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.CREATE);
            CommonHandler.ClearControlData(layoutControlGroupEditControl);
            _tempNewIdMain = 0;
            fCategoryId.Focus();
        }
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (_curIdMain == 0) {
                CommonHandler.ShowXtraMessageBox_NeedToSelectRecord();
                return;
            }
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.EDIT);
            fCategoryId.Focus();
        }
        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                var lstObjId = CommonHandler.GridView_GetSelectedRowOid_RemovedIntEmptyItems(gridViewMain, _fieldNameId);
                if (lstObjId.Count == 0) {
                    CommonHandler.ShowXtraMessageBox_NeedToSelectRecord();
                    return;
                }
                if (await _busChapter.IsExistRefAsync(lstObjId.First())) {
                    CommonHandler.ShowXtraMessageBox_CannotDeleteBecauseOfExistReference();
                    return;
                }
                if (CommonHandler.ShowXtraMessageBox_SubmitToDelete() == DialogResult.Yes) {
                    var res = await _busChapter.DeleteAsync(lstObjId.First());
                    if (res) {
                        CommonHandler.ShowNotificationForm_DeletedSuccessfully();
                        foreach (var id in lstObjId) {
                            var objToDelete = _bindingListMain.First(x => x.ChapterId == id);
                            _bindingListMain.Remove(objToDelete);
                        }
                        _curIdMain = CommonHandler.ConvertToInt(gridViewMain.GetFocusedRowCellValue(_fieldNameId));
                        if (_curIdMain == 0) {
                            // nothing
                        }
                        else {
                            gridViewMain.SelectRow(gridViewMain.FocusedRowHandle);
                        }
                    }
                    gridViewMain.RefreshData();
                }
            }
            catch {
                throw;
            }
        }
        private async void btnSubmit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                gridViewMain.Focus();
                if (_mainStatus == EnumMainStatusForm.CREATE) _curIdMain = _tempNewIdMain;
                var obj = new Chapter {
                    ChapterId = (_mainStatus == EnumMainStatusForm.CREATE) ? _tempNewIdMain : _curIdMain,
                    CategoryId = CommonHandler.ConvertToNullableInt(fCategoryId.EditValue),
                    SortOrder = CommonHandler.ConvertToNullableInt(fSortOrder.EditValue),
                    ChapterName = CommonHandler.SafeToString(fChapterName.EditValue)
                };

                // Validate
                CommonHandler.ClearEditControlErrorText(layoutControlGroupEditControl);
                var validator = new ChapterValidator();
                var validateResult = await validator.ValidateAsync(obj);
                if (!validateResult.IsValid) {
                    var fieldWithMessage = validateResult.Errors.Select(x => new Tuple<string, string>(x.PropertyName, x.ErrorMessage)).ToArray();
                    CommonHandler.SetEditControlErrorText_ValidateResult(this, fieldWithMessage);
                    return;
                }

                // Submit
                if (_mainStatus == EnumMainStatusForm.CREATE) {
                    var res = await _busChapter.InsertAsync(obj);
                    if (res) CommonHandler.ShowNotificationForm_CreatedSuccessfully();
                    _bindingListMain.Add(obj);
                    gridViewMain.RefreshData();
                    gridViewMain.FocusedRowHandle = gridViewMain.LocateByValue(_fieldNameId, obj.ChapterId);
                }
                else if (_mainStatus == EnumMainStatusForm.EDIT) {
                    var res = await _busChapter.UpdateAsync(obj.ChapterId, obj);
                    if (res) CommonHandler.ShowNotificationForm_UpdatedSuccessfully();
                    var objToEdit = (Chapter)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
                    CommonHandler.MemberwiseClone(obj, ref objToEdit);
                    gridViewMain.RefreshData();
                }
                ConfigControlStatus(_mainStatus = EnumMainStatusForm.VIEW);
            }
            catch {
                throw;
            }
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            CommonHandler.ClearControlData(layoutControlGroupEditControl);
            if (gridViewMain.RowCount > 0) {
                var objMain = (Chapter)gridViewMain.GetFocusedRow();
                CommonHandler.SetValueToControl(objMain, this);
            }
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.VIEW);
        }
        private async void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            await LoadDataRepo();
            await LoadDataMainGrid();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.Close();
        }
        private void gridViewMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (gridViewMain.RowCount > 0) {
                _curIdMain = CommonHandler.ConvertToInt(gridViewMain.GetFocusedRowCellValue(_fieldNameId));
                var objMain = (Chapter)gridViewMain.GetFocusedRow();
                CommonHandler.SetValueToControl(objMain, this);
            }
        }
        private void gridViewMain_RowCountChanged(object sender, EventArgs e) {
            if (gridViewMain.RowCount == 0) {
                btnDelete.Enabled = false;
                CommonHandler.ClearControlData(layoutControlGroupEditControl);
            }
            else { // nothing
            }
        }
    }
}