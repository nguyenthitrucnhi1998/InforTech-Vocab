using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;
using static VocabLearningApp.GUI.Common.clsCommon;

namespace VocabLearningApp.GUI.Forms
{
    public partial class FrmDictionary : DevExpress.XtraEditors.XtraForm
    {
        DictionaryBus _busDictionary = new();
        CategoryBus _busCategory = new();
        ChapterBus _busChapter = new();
        LessonBus _busLesson = new();

        private BindingList<FlatTermDTO> _bindingListMain = new();
        private int? _selectedCategoryId = null;
        private int? _selectedChapterId = null;
        private int? _selectedLessonId = null;
        private bool _isInternalChanging;

        public FrmDictionary()
        {
            InitializeComponent();
        }

        private async void FrmDictionary_Load(object sender, EventArgs e)
        {
            CommonConfig();
            await LoadDataRepo();
            await LoadDataMainGrid();
            InitLookupState();
        }

        private void CommonConfig()
        {
            CommonHandler.PreventMouseWheelForDropdown(this);
            CommonHandler.ConfigForGridViewHeader(this, layoutControlGroupMainData, gridViewMain);
            ConfigShorthandEvent();

            //gridViewMain.OptionsBehavior.Editable = false;
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
            fChapterId.Enabled = false;
            fLessonId.Enabled = false;
        }
        private void UpdateLookupState()
        {
            fChapterId.Enabled = _selectedCategoryId.HasValue;
            fLessonId.Enabled = _selectedChapterId.HasValue;
        }
        private void ConfigShorthandEvent()
        {
            gridViewMain.RowStyle += (s, e) => {
                if (e.RowHandle < 0) return;
                if (e.RowHandle == gridViewMain.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.Khaki;
                    e.HighPriority = true;
                }
            };

            fCategoryId.EditValueChanged += async (s, e) => {
                if (_isInternalChanging) return;
                _isInternalChanging = true;

                try
                {
                    var lookup = (SearchLookUpEdit)s;
                    _selectedCategoryId = CommonHandler.ConvertToNullableInt(lookup.EditValue);

                    // Filter Chapter by Category
                    var chapterView = GetView(fChapterId);
                    if (chapterView != null)
                    {
                        if (_selectedCategoryId.HasValue)
                            chapterView.ActiveFilterString = $"[CategoryId] = {_selectedCategoryId.Value}";
                        else
                            chapterView.ActiveFilter.Clear();
                    }

                    // Reset Chapter + Lesson
                    fChapterId.EditValue = null;
                    fLessonId.EditValue = null;

                    _selectedChapterId = null;
                    _selectedLessonId = null;

                    UpdateLookupState();

                    await LoadDataMainGrid();
                }
                finally
                {
                    _isInternalChanging = false;
                }
            };

            fChapterId.EditValueChanged += async (s, e) => {
                if (_isInternalChanging) return;
                _isInternalChanging = true;

                try
                {
                    var lookup = (SearchLookUpEdit)s;
                    _selectedChapterId = CommonHandler.ConvertToNullableInt(lookup.EditValue);

                    // Filter Lesson by Chapter
                    var lessonView = GetView(fLessonId);
                    if (lessonView != null)
                    {
                        if (_selectedChapterId.HasValue)
                            lessonView.ActiveFilterString = $"[ChapterId] = {_selectedChapterId.Value}";
                        else
                            lessonView.ActiveFilter.Clear();
                    }

                    // Reset Lesson
                    fLessonId.EditValue = null;
                    _selectedLessonId = null;

                    UpdateLookupState();

                    await LoadDataMainGrid();
                }
                finally
                {
                    _isInternalChanging = false;
                }
            };

            fLessonId.EditValueChanged += async (s, e) => {
                if (_isInternalChanging) return;

                var lookup = (SearchLookUpEdit)s;
                _selectedLessonId = CommonHandler.ConvertToNullableInt(lookup.EditValue);

                await LoadDataMainGrid();
            };
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
                _bindingListMain = new();

                var res = await _busDictionary.GetAllAsync(_selectedCategoryId, _selectedChapterId, _selectedLessonId);
                if (clsGlobalVariables.SelectedTermType == EnumTermType.FE)
                {
                    res = res.Where(x => x.TermTypeId == Convert.ToInt32(EnumTermType.FE)).ToList();
                }
                _bindingListMain = new BindingList<FlatTermDTO>(res);

                gridControlMain.DataSource = null;
                gridControlMain.DataSource = _bindingListMain;
                CommonHandler.GridViewMain_CheckThenFocusAndSelectZeroIndexRow(gridViewMain);
            }
            catch
            {
                throw;
            }
        }

        private async void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fCategoryId.EditValue = null;
            fChapterId.EditValue = null;
            fLessonId.EditValue = null;

            _selectedCategoryId = null;
            _selectedChapterId = null;
            _selectedLessonId = null;

            await LoadDataRepo();
            await LoadDataMainGrid();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void repoBtnActions_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridControlMain.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle < 0) return;

            var rowData = view.GetRow(rowHandle);
            var termId = ((FlatTermDTO)rowData).TermId;

            if (e.Button.Index == 0)
            {
                var frm = new FrmTermDetail(termId);
                frm.ShowDialog();
            }
            else if (e.Button.Index == 1)
            {
                var frm = new FrmEnrichVocabBook(termId);
                frm.ShowDialog();
            }
        }
    }
}