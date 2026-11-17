using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;
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
using VocabLearningApp.GUI.Common;
using VocabLearningApp.GUI.Validators;
using static VocabLearningApp.GUI.Common.clsCommon;

namespace VocabLearningApp.GUI.Forms
{
    public partial class FrmTerm : DevExpress.XtraEditors.XtraForm
    {
        CategoryBus _busCategory = new();
        ChapterBus _busChapter = new();
        LessonBus _busLesson = new();
        TermBus _busTerm = new();

        private EnumMainStatusForm _mainStatus;
        private int _curIdMain = 0;
        private int _tempNewIdMain = 0;
        private BindingList<Term> _bindingListMain = new();
        private const string _fieldNameId = nameof(Term.TermId);

        private bool _isInternalChanging;

        public FrmTerm()
        {
            InitializeComponent();
        }

        private async void FrmTerm_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new CustomGridLocalizer();
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.WAIT);
            CommonConfig();
            await LoadDataRepo();
            await LoadDataMainGrid();
        }

        private void CommonConfig()
        {
            CommonHandler.ConfigBarButtonFormat(btnCreate, btnEdit, btnDelete, btnSubmit, btnCancel, btnRefresh, btnClose);
            CommonHandler.PreventMouseWheelForDropdown(this);
            CommonHandler.ConfigForGridViewHeader(this, layoutControlGroupMainData, gridViewMain);
            ConfigShorthandEvent();

            gridViewMain.OptionsBehavior.Editable = false;
            gridViewMain.OptionsFind.AlwaysVisible = true;
            fCategoryId.Properties.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            fChapterId.Properties.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            fLessonId.Properties.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
        }

        private GridView GetView(SearchLookUpEdit edit)
        {
            return edit?.Properties?.View;
        }
        private void InitLookupState()
        {
            fCategoryId.Enabled = true;
            fChapterId.Enabled = false;
            fLessonId.Enabled = false;
        }
        private void UpdateLookupState()
        {
            fChapterId.Enabled = fCategoryId.EditValue != null;
            fLessonId.Enabled = fChapterId.EditValue != null;
        }
        private void ConfigShorthandEvent()
        {
            gridViewMain.MouseDown += (s, e) =>
            {
                if (_mainStatus == EnumMainStatusForm.CREATE || _mainStatus == EnumMainStatusForm.EDIT)
                {
                    GridView view = s as GridView;
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                    DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            };
            gridViewMain.RowStyle += (s, e) =>
            {
                if (e.RowHandle < 0) return;
                if (e.RowHandle == gridViewMain.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.Khaki;
                    e.HighPriority = true;
                }
            };



            fCategoryId.EditValueChanged += async (s, e) =>
            {
                if (_isInternalChanging) return;
                _isInternalChanging = true;

                try
                {
                    var lookup = (SearchLookUpEdit)s;
                    var value = CommonHandler.ConvertToNullableInt(lookup.EditValue);

                    // Filter Chapter by Category
                    var chapterView = GetView(fChapterId);
                    if (chapterView != null)
                    {
                        if (value.HasValue)
                            chapterView.ActiveFilterString = $"[CategoryId] = {value.Value}";
                        else
                            chapterView.ActiveFilter.Clear();
                    }

                    // Reset Chapter + Lesson
                    fChapterId.EditValue = null;
                    fLessonId.EditValue = null;

                    UpdateLookupState();
                }
                finally
                {
                    _isInternalChanging = false;
                }
            };

            fChapterId.EditValueChanged += async (s, e) =>
            {
                if (_isInternalChanging) return;
                _isInternalChanging = true;

                try
                {
                    var lookup = (SearchLookUpEdit)s;
                    var value = CommonHandler.ConvertToNullableInt(lookup.EditValue);

                    // Filter Lesson by Chapter
                    var lessonView = GetView(fLessonId);
                    if (lessonView != null)
                    {
                        if (value.HasValue)
                            lessonView.ActiveFilterString = $"[ChapterId] = {value.Value}";
                        else
                            lessonView.ActiveFilter.Clear();
                    }

                    // Reset Lesson
                    fLessonId.EditValue = null;

                    UpdateLookupState();
                }
                finally
                {
                    _isInternalChanging = false;
                }
            };
        }
        private void ConfigControlStatus(EnumMainStatusForm status)
        {
            gridViewMain.OptionsBehavior.Editable = false;
            CommonHandler.SetReadOnlyControlData(layoutControlGroupEditControl, true);
            CommonHandler.ConfigBarButtonEnable(true, btnCreate, btnEdit, btnDelete, btnSubmit, btnCancel, btnRefresh, btnClose);

            layoutControlItem_MetaDataHTML.Visibility = LayoutVisibility.Never;
            layoutControlItem_MetaDataView.Visibility = LayoutVisibility.Never;
            btnUploadImage.Enabled = false;
            btnRemovImage.Enabled = false;

            switch (status)
            {
                case EnumMainStatusForm.WAIT:
                    CommonHandler.ConfigBarButtonEnable(false, btnCreate, btnEdit, btnDelete, btnSubmit, btnCancel, btnRefresh, btnClose);
                    layoutControlItem_MetaDataView.Visibility = LayoutVisibility.Always;
                    break;
                case EnumMainStatusForm.CREATE:
                    CommonHandler.ConfigBarButtonEnable(false, btnCreate, btnEdit, btnDelete, btnRefresh, btnClose);
                    CommonHandler.SetReadOnlyControlData(layoutControlGroupEditControl, false);
                    layoutControlItem_MetaDataHTML.Visibility = LayoutVisibility.Always;
                    btnUploadImage.Enabled = true;
                    btnRemovImage.Enabled = true;
                    break;
                case EnumMainStatusForm.EDIT:
                    CommonHandler.ConfigBarButtonEnable(false, btnCreate, btnEdit, btnDelete, btnRefresh, btnClose);
                    CommonHandler.SetReadOnlyControlData(layoutControlGroupEditControl, false);
                    layoutControlItem_MetaDataHTML.Visibility = LayoutVisibility.Always;
                    btnUploadImage.Enabled = true;
                    btnRemovImage.Enabled = true;
                    break;
                default: // MainStatusForm.VIEW
                    CommonHandler.ClearEditControlErrorText(layoutControlGroupEditControl);
                    CommonHandler.ConfigBarButtonEnable(false, btnSubmit, btnCancel);
                    layoutControlItem_MetaDataView.Visibility = LayoutVisibility.Always;
                    gridViewMain.Focus();
                    break;
            }
        }
        private async Task LoadDataRepo()
        {
            try
            {
                var dataCategory = (await _busCategory.GetAllAsync()).Select(x => new CategoryOptionDTO
                {
                    CategoryId = x.CategoryId,
                    CategorySortOrder = (int)x.SortOrder,
                    CategoryName = x.CategoryName
                }).ToList();
                var viewColsCategory = new List<Tuple<string, string>> {
                    new(nameof(CategoryOptionDTO.CategorySortOrder), "CategorySortOrder"),
                    new(nameof(CategoryOptionDTO.CategoryName), "CategoryName"),
                };
                CommonHandler.LoadFromObject(fCategoryId, dataCategory, nameof(CategoryOptionDTO.CategoryId), nameof(CategoryOptionDTO.CategoryName), viewColsCategory);

                var dataChapter = (await _busChapter.GetAllAsync()).Select(x => new ChapterOptionDTO
                {
                    ChapterId = x.ChapterId,
                    CategoryId = (int)x.CategoryId,
                    CategoryName = x.Category.CategoryName,
                    ChapterSortOrder = (int)x.SortOrder,
                    ChapterName = x.ChapterName,
                    ChapterPath = $"{x.Category.CategoryName} / {x.ChapterName}"
                }).ToList();
                var viewColsChapter = new List<Tuple<string, string>> {
                    new(nameof(ChapterOptionDTO.ChapterSortOrder), "SortOrder"),
                    new(nameof(ChapterOptionDTO.ChapterName), "ChapterName"),
                };
                CommonHandler.LoadFromObject(fChapterId, dataChapter, nameof(ChapterOptionDTO.ChapterId), nameof(ChapterOptionDTO.ChapterName), viewColsChapter);

                var dataLesson = (await _busLesson.GetAllAsync()).Select(x => new LessonOptionDTO
                {
                    LessonId = x.LessonId,
                    ChapterId = (int)x.ChapterId,
                    CategoryName = x.Chapter.Category.CategoryName,
                    ChapterName = x.Chapter.ChapterName,
                    LessonSortOrder = (int)x.SortOrder,
                    LessonName = x.LessonName,
                    LessonPath = $"{x.Chapter.Category.CategoryName} / {x.Chapter.ChapterName} / {x.LessonName}"
                }).ToList();
                var viewColsLesson = new List<Tuple<string, string>> {
                    new(nameof(LessonOptionDTO.LessonSortOrder), "SortOrder"),
                    new(nameof(LessonOptionDTO.LessonName), "LessonName"),
                };
                CommonHandler.LoadFromObject(fLessonId, dataLesson, nameof(LessonOptionDTO.LessonId), nameof(LessonOptionDTO.LessonName), viewColsLesson);
                CommonHandler.LoadFromObject(repoLesson, dataLesson, nameof(LessonOptionDTO.LessonId), nameof(LessonOptionDTO.LessonName), viewColsLesson);


                //var dataLesson = (await _busLesson.GetAllAsync()).Select(x => new LessonOptionDTO {
                //    LessonId = x.LessonId,
                //    CategoryName = x.Chapter.Category.CategoryName,
                //    ChapterName = x.Chapter.ChapterName,
                //    LessonName = x.LessonName,
                //    LessonPath = $"{x.Chapter.Category.CategoryName} / {x.Chapter.ChapterName} / {x.LessonName}"
                //}).ToList();
                //var viewColumns = new List<Tuple<string, string>> {
                //        new(nameof(Category.CategoryName), "Category"),
                //        new(nameof(Chapter.ChapterName), "Chapter"),
                //        new(nameof(Lesson.LessonName), "Lesson"),
                //    };
                //CommonHandler.LoadFromObject(fLessonId, dataLesson, nameof(LessonOptionDTO.LessonId), nameof(LessonOptionDTO.LessonPath), viewColumns);
                //CommonHandler.LoadFromObject(repoLesson, dataLesson, nameof(LessonOptionDTO.LessonId), nameof(LessonOptionDTO.LessonName), viewColumns);
            }
            catch
            {
                throw;
            }
        }
        private async Task LoadDataMainGrid()
        {
            try
            {
                ConfigControlStatus(_mainStatus = EnumMainStatusForm.WAIT);
                CommonHandler.ClearControlData(layoutControlGroupEditControl);
                _bindingListMain = new();

                var res = await _busTerm.GetAllAsync();
                if (clsGlobalVariables.SelectedTermType == EnumTermType.FE)
                {
                    res = res.Where(x => x.TermTypeId == Convert.ToInt32(EnumTermType.FE)).ToList();
                }

                res.ForEach(x =>
                {
                    x.ImageData = x.ImageData?.DecompressBytes();
                });
                _bindingListMain = new BindingList<Term>(res);

                gridControlMain.DataSource = null;
                gridControlMain.DataSource = _bindingListMain;
                CommonHandler.GridViewMain_CheckThenFocusAndSelectZeroIndexRow(gridViewMain);
                ConfigControlStatus(_mainStatus = EnumMainStatusForm.VIEW);
            }
            catch
            {
                throw;
            }
        }

        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.CREATE);
            CommonHandler.ClearControlData(layoutControlGroupEditControl);
            _tempNewIdMain = 0;
            fLessonId.Focus();
            InitLookupState();
        }
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_curIdMain == 0)
            {
                CommonHandler.ShowXtraMessageBox_NeedToSelectRecord();
                return;
            }
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.EDIT);
            fLessonId.Focus();
        }
        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var lstObjId = CommonHandler.GridView_GetSelectedRowOid_RemovedIntEmptyItems(gridViewMain, _fieldNameId);
                if (lstObjId.Count == 0)
                {
                    CommonHandler.ShowXtraMessageBox_NeedToSelectRecord();
                    return;
                }
                if (await _busTerm.IsExistRefAsync(lstObjId.First()))
                {
                    CommonHandler.ShowXtraMessageBox_CannotDeleteBecauseOfExistReference();
                    return;
                }
                if (CommonHandler.ShowXtraMessageBox_SubmitToDelete() == DialogResult.Yes)
                {
                    var res = await _busTerm.DeleteAsync(lstObjId.First());
                    if (res)
                    {
                        CommonHandler.ShowNotificationForm_DeletedSuccessfully();
                        foreach (var id in lstObjId)
                        {
                            var objToDelete = _bindingListMain.First(x => x.TermId == id);
                            _bindingListMain.Remove(objToDelete);
                        }
                        _curIdMain = CommonHandler.ConvertToInt(gridViewMain.GetFocusedRowCellValue(_fieldNameId));
                        if (_curIdMain == 0)
                        {
                            // nothing
                        }
                        else
                        {
                            gridViewMain.SelectRow(gridViewMain.FocusedRowHandle);
                        }
                    }
                    gridViewMain.RefreshData();
                }
            }
            catch
            {
                throw;
            }
        }
        private async void btnSubmit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridViewMain.Focus();
                if (_mainStatus == EnumMainStatusForm.CREATE) _curIdMain = _tempNewIdMain;
                var obj = new Term
                {
                    TermId = (_mainStatus == EnumMainStatusForm.CREATE) ? _tempNewIdMain : _curIdMain,
                    TermTypeId = Convert.ToInt32(clsGlobalVariables.SelectedTermType),
                    LessonId = CommonHandler.ConvertToNullableInt(fLessonId.EditValue),
                    TermName = CommonHandler.SafeToString(fTermName.EditValue),
                    Pronounce = CommonHandler.SafeToString(fPronounce.EditValue),
                    Meaning = CommonHandler.SafeToString(fMeaning.EditValue),
                    MetaData = CommonHandler.SafeToString(fMetaData.EditValue),
                    ImageData = fImageData?.Image?.ToByteArray()?.CompressBytes()
                };

                // Validate
                CommonHandler.ClearEditControlErrorText(layoutControlGroupEditControl);
                var validator = new TermValidator();
                var validateResult = await validator.ValidateAsync(obj);
                if (!validateResult.IsValid)
                {
                    var fieldWithMessage = validateResult.Errors.Select(x => new Tuple<string, string>(x.PropertyName, x.ErrorMessage)).ToArray();
                    CommonHandler.SetEditControlErrorText_ValidateResult(this, fieldWithMessage);
                    return;
                }

                // Submit
                if (_mainStatus == EnumMainStatusForm.CREATE)
                {
                    var res = await _busTerm.InsertAsync(obj);
                    if (res) CommonHandler.ShowNotificationForm_CreatedSuccessfully();
                    _bindingListMain.Add(obj);
                    gridViewMain.RefreshData();
                    gridViewMain.FocusedRowHandle = gridViewMain.LocateByValue(_fieldNameId, obj.TermId);
                }
                else if (_mainStatus == EnumMainStatusForm.EDIT)
                {
                    var res = await _busTerm.UpdateAsync(obj.TermId, obj);
                    if (res) CommonHandler.ShowNotificationForm_UpdatedSuccessfully();
                    var objToEdit = (Term)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
                    CommonHandler.MemberwiseClone(obj, ref objToEdit);
                    gridViewMain.RefreshData();
                }
                ConfigControlStatus(_mainStatus = EnumMainStatusForm.VIEW);
            }
            catch
            {
                throw;
            }
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonHandler.ClearControlData(layoutControlGroupEditControl);
            if (gridViewMain.RowCount > 0)
            {
                var objMain = (Term)gridViewMain.GetFocusedRow();
                CommonHandler.SetValueToControl(objMain, this);
                fImageData.EditValue = objMain.ImageData;
            }
            ConfigControlStatus(_mainStatus = EnumMainStatusForm.VIEW);
        }
        private async void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await LoadDataRepo();
            await LoadDataMainGrid();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gridViewMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewMain.RowCount > 0)
            {
                _curIdMain = CommonHandler.ConvertToInt(gridViewMain.GetFocusedRowCellValue(_fieldNameId));
                var objMain = (Term)gridViewMain.GetFocusedRow();
                CommonHandler.SetValueToControl(objMain, this);
                webBrowser1.DocumentText = CommonHandler.SafeToString(fMetaData.EditValue);
                fImageData.EditValue = objMain.ImageData;
                fCategoryId.EditValue = objMain?.Lesson?.Chapter?.CategoryId;
                fChapterId.EditValue = objMain?.Lesson?.Chapter?.ChapterId;
                fLessonId.EditValue = objMain?.LessonId;
            }
        }
        private void gridViewMain_RowCountChanged(object sender, EventArgs e)
        {
            if (gridViewMain.RowCount == 0)
            {
                btnDelete.Enabled = false;
                CommonHandler.ClearControlData(layoutControlGroupEditControl);
            }
            else
            { // nothing
            }
        }
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Choose Image",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*",
                    RestoreDirectory = true,
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fImageData.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch
            {
                throw;
            }
        }
        private void btnRemovImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (fImageData.Image == null)
                {
                    XtraMessageBox.Show("No picture yet", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Are you sure you want to remove the image?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fImageData.Image = null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}