using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using VocabLearningApp.GUI.Forms;

namespace VocabLearningApp.GUI.Common {
    public class clsCommon {
        public enum EnumMainStatusForm {
            WAIT = 0,
            VIEW = 1,
            CREATE = 2,
            EDIT = 3
        }

        public partial class CommonHandler {
            public static void ConfigBarButtonFormat(BarItem btnCreate = null, BarItem btnEdit = null, BarItem btnDelete = null, BarItem btnSubmit = null, BarItem btnCancel = null, BarItem btnRefresh = null, BarItem btnClose = null, BarItem btnSearch = null, BarItem btnPrint = null, BarItem btnGetOrRestoreData = null, BarItem btnSendOrRecallData = null, BarItem btnUpdateDataReport = null) {
                if (btnCreate != null) {
                    btnCreate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    btnCreate.ItemShortcut = new BarShortcut((Keys.Control | Keys.N));
                    btnCreate.Hint = "Ctrl + N";
                    btnCreate.Caption = "作成";
                }
                if (btnEdit != null) {
                    btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    btnEdit.ItemShortcut = new BarShortcut((Keys.Control | Keys.E));
                    btnEdit.Hint = "Ctrl + E";
                    btnEdit.Caption = "編集";
                }
                if (btnDelete != null) {
                    btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    btnDelete.ItemShortcut = new BarShortcut((Keys.Control | Keys.Delete));
                    btnDelete.Hint = "Ctrl + Delete";
                    btnDelete.Caption = "削除";
                }
                if (btnSubmit != null) {
                    btnSubmit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    btnSubmit.ItemShortcut = new BarShortcut((Keys.Control | Keys.S));
                    btnSubmit.Hint = "Ctrl + S";
                    btnSubmit.Caption = "登録";
                }
                if (btnCancel != null) {
                    btnCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    btnCancel.ItemShortcut = new BarShortcut((Keys.Control | Keys.Z));
                    btnCancel.Hint = "Ctrl + Z";
                    btnCancel.Caption = "キャンセル";
                }
                if (btnRefresh != null) {
                    btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    btnRefresh.ItemShortcut = new BarShortcut((Keys.Control | Keys.F5));
                    btnRefresh.Hint = "Ctrl + F5";
                    btnRefresh.Caption = "更新";
                }
                if (btnClose != null) {
                    btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    btnClose.ItemShortcut = new BarShortcut((Keys.Control | Keys.Q));
                    btnClose.Hint = "Ctrl + Q";
                    btnClose.Caption = "閉じる";
                }
            }
            public static void ConfigBarButtonEnable(bool isEnable, params BarButtonItem[] btns) {
                foreach (var btn in btns) {
                    btn.Enabled = isEnable;
                }
            }
            public static void ConfigBarSubItemEnable(bool isEnable, params BarSubItem[] subItems) {
                foreach (var item in subItems) {
                    item.Enabled = isEnable;
                }
            }
            public static void ConfigForGridViewHeader(XtraForm thisForm, LayoutControlGroup layoutControlGroupMainData, params GridView[] grids) {
                if (thisForm != null) {
                    thisForm.Size = new Size(1400, 800);
                    thisForm.StartPosition = FormStartPosition.CenterScreen;
                    //thisForm.WindowState = FormWindowState.Maximized;
                }

                if (layoutControlGroupMainData != null) {
                    layoutControlGroupMainData.Width = 300;
                }

                foreach (var grid in grids) {
                    if (grid is BandedGridView bandedGrid) {
                        foreach (var band in bandedGrid.Bands.ToList()) {
                            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            band.AppearanceHeader.BackColor = Color.White;
                        }
                    }
                    else if (grid is GridView) {
                        foreach (var band in grid.Columns.ToList()) {
                            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            band.AppearanceHeader.BackColor = Color.White;
                        }
                    }
                }
            }
            public static void ConfigForGridViewHeader(XtraForm thisForm, LayoutControlGroup layoutControlGroupMainData, LayoutControlItem layoutControlItemNotification, params GridView[] grids) {
                if (thisForm != null) {
                    thisForm.Size = new Size(1400, 800);
                    thisForm.StartPosition = FormStartPosition.CenterScreen;
                    //thisForm.WindowState = FormWindowState.Maximized;
                }

                if (layoutControlGroupMainData != null) {
                    layoutControlGroupMainData.Width = 300;
                }

                if (layoutControlItemNotification != null) {
                    layoutControlItemNotification.Height = 300;
                }

                foreach (var grid in grids) {
                    if (grid is BandedGridView bandedGrid) {
                        foreach (var band in bandedGrid.Bands.ToList()) {
                            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            band.AppearanceHeader.BackColor = Color.White;
                        }
                    }
                    else if (grid is GridView) {
                        foreach (var band in grid.Columns.ToList()) {
                            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            band.AppearanceHeader.BackColor = Color.White;
                        }
                    }
                }
            }
            public static void ConfigMemoEditNotification(MemoEdit memoEditNotification) {
                memoEditNotification.ReadOnly = true;
                memoEditNotification.Properties.Appearance.BackColor = Color.White;
            }
            public static void MemberwiseClone<T>(T objSource, ref T objDest, IList<string> lstInclude = null, IList<string> lstExclude = null) where T : new() {
                try {
                    var props = typeof(T).GetProperties().Select(x => x.Name);

                    if (lstInclude != null) {
                        props = props.Where(x => lstInclude.Contains(x));
                    }
                    if (lstExclude != null) {
                        var include = props.Where(x => !lstExclude.Contains(x));
                        props = props.Where(x => include.Contains(x));
                    }

                    foreach (var item in props) {
                        var propInfo = objSource.GetType().GetProperty(item);
                        var value = objSource.GetType().GetProperty(item).GetValue(objSource, null);
                        propInfo.SetValue(objDest, value, null);
                    }
                }
                catch (Exception ex) {
                    throw new ApplicationException(ex.Message);
                }
            }
            public static void ShowNotificationForm(string content) {
                var timer = new Timer();
                var formThongBao = new NotificationForm(content);
                formThongBao.Show();
            }
            public static void ShowNotificationForm_CustomMessage_Successfully(string message) => ShowNotificationForm(message);
            public static void ShowNotificationForm_CreatedSuccessfully() => ShowNotificationForm("データの登録に成功しました");
            public static void ShowNotificationForm_UpdatedSuccessfully() => ShowNotificationForm("データの更新に成功しました");
            public static void ShowNotificationForm_DeletedSuccessfully() => ShowNotificationForm("データの削除に成功しました");
            public static DialogResult ShowXtraMessageBox_CannotDeleteBecauseOfExistReference() => XtraMessageBox.Show("関連データが存在するため、このデータを削除することはできません", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            public static DialogResult ShowXtraMessageBox_NeedToSelectRecord() => XtraMessageBox.Show("操作を行う前に、データを選択してください", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            public static DialogResult ShowXtraMessageBox_CannotDeleteMainRecord_BecauseOfDetailData() => XtraMessageBox.Show("詳細データが存在するため、選択したデータを削除できません", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            public static DialogResult ShowXtraMessageBox_SubmitToDelete() => XtraMessageBox.Show("データを削除してもよろしいですか？", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            public static DialogResult ShowXtraMessageBox_SubmitToDeleteAll() => XtraMessageBox.Show("すべてのデータを削除してもよろしいですか？", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            public static void SetGroupingGridView(GridView view, string groupColFieldName) {
                view.Columns[groupColFieldName].Group();
                GridGroupSummaryItem item = new GridGroupSummaryItem();
                item.FieldName = groupColFieldName;
                item.SummaryType = DevExpress.Data.SummaryItemType.Count;
                view.GroupSummary.Add(item);
                view.CustomDrawGroupRow += (s, e) => {
                    var info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
                    info.GroupText = info.GroupText.Replace("Count=", string.Empty);
                };
                view.ExpandAllGroups();
            }
            public static void SetReadOnlyControlData(LayoutControlGroup layoutControlGroup, bool isReadOnly) {
                foreach (var li in layoutControlGroup.Items) {
                    if (li is LayoutControlItem li2) {
                        if (li2.Control == null) continue;
                        Type type = li2.Control.GetType();
                        if (type == typeof(TextEdit)) {
                            TextEdit txtEdit = li2.Control as TextEdit;
                            txtEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(DateEdit)) {
                            DateEdit dEdit = li2.Control as DateEdit;
                            dEdit.ReadOnly = isReadOnly;
                            dEdit.QueryPopUp += (s, e) => e.Cancel = isReadOnly;
                        }
                        else if (type == typeof(MemoEdit)) {
                            MemoEdit mEdit = li2.Control as MemoEdit;
                            mEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(SpinEdit)) {
                            SpinEdit sEdit = li2.Control as SpinEdit;
                            sEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(CheckEdit)) {
                            CheckEdit cEdit = li2.Control as CheckEdit;
                            cEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(LookUpEdit)) {
                            LookUpEdit lEdit = li2.Control as LookUpEdit;
                            lEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(SearchLookUpEdit)) {
                            SearchLookUpEdit slEdit = li2.Control as SearchLookUpEdit;
                            slEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(ButtonEdit)) {
                            ButtonEdit btEdit = li2.Control as ButtonEdit;
                            btEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(PictureEdit)) {
                            PictureEdit picEdit = li2.Control as PictureEdit;
                            picEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(ComboBoxEdit)) {
                            ComboBoxEdit cbbEdit = li2.Control as ComboBoxEdit;
                            cbbEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(CheckedComboBoxEdit)) {
                            CheckedComboBoxEdit ccbbEdit = li2.Control as CheckedComboBoxEdit;
                            ccbbEdit.ReadOnly = isReadOnly;
                        }
                        else if (type == typeof(GridLookUpEdit)) {
                            GridLookUpEdit glEdit = li2.Control as GridLookUpEdit;
                            glEdit.ReadOnly = isReadOnly;
                        }
                    }
                    else {
                        if (li is LayoutControlGroup li3) {
                            SetReadOnlyControlData(li3, isReadOnly);
                        }
                    }
                }
            }
            public static void GridViewMain_CheckThenFocusAndSelectZeroIndexRow(GridView view) {
                if (view.RowCount > 0) {
                    view.FocusedRowHandle = 0;
                    view.ClearSelection();
                    view.SelectRow(0);
                }
            }
            public static List<Guid> GridView_GetSelectedRowOid_RemovedGuidEmptyItems(GridView view) {
                var lstObjId = view.GetSelectedRows().Select(rowId => (Guid)(view.GetRowCellValue(rowId, "Oid"))).ToList();
                lstObjId.RemoveAll(item => item == Guid.Empty);
                return lstObjId;
            }
            public static List<int> GridView_GetSelectedRowOid_RemovedIntEmptyItems(GridView view, string fieldNameId) {
                var lstObjId = view.GetSelectedRows().Select(rowId => (int)(view.GetRowCellValue(rowId, fieldNameId))).ToList();
                lstObjId.RemoveAll(item => item == 0);
                return lstObjId;
            }
            public static void ClearControlData(LayoutControlGroup layoutControlGroup) {
                foreach (var li in layoutControlGroup.Items) {
                    if (li is LayoutControlItem li2) {
                        if (li2.Control == null) continue;
                        Type type = li2.Control.GetType();
                        if (type == typeof(TextEdit)) {
                            TextEdit txtEdit = li2.Control as TextEdit;
                            txtEdit.Text = null;
                        }
                        else if (type == typeof(DateEdit)) {
                            DateEdit dEdit = li2.Control as DateEdit;
                            dEdit.Text = null;
                        }
                        else if (type == typeof(MemoEdit)) {
                            MemoEdit mEdit = li2.Control as MemoEdit;
                            mEdit.Text = null;
                        }
                        else if (type == typeof(SpinEdit)) {
                            SpinEdit sEdit = li2.Control as SpinEdit;
                            sEdit.Text = null;
                        }
                        else if (type == typeof(CheckEdit)) {
                            CheckEdit cEdit = li2.Control as CheckEdit;
                            cEdit.Checked = false;
                        }
                        else if (type == typeof(LookUpEdit)) {
                            LookUpEdit lEdit = li2.Control as LookUpEdit;
                            lEdit.EditValue = null;
                        }
                        else if (type == typeof(SearchLookUpEdit)) {
                            SearchLookUpEdit slEdit = li2.Control as SearchLookUpEdit;
                            slEdit.EditValue = null;
                        }
                        else if (type == typeof(ButtonEdit)) {
                            ButtonEdit btEdit = li2.Control as ButtonEdit;
                            btEdit.Text = null;
                        }
                        else if (type == typeof(PictureEdit)) {
                            PictureEdit picEdit = li2.Control as PictureEdit;
                            picEdit.Image = null;
                        }
                        else if (type == typeof(ComboBoxEdit)) {
                            ComboBoxEdit cbbEdit = li2.Control as ComboBoxEdit;
                            cbbEdit.Text = null;
                        }
                        else if (type == typeof(CheckedComboBoxEdit)) {
                            CheckedComboBoxEdit ccbbEdit = li2.Control as CheckedComboBoxEdit;
                            ccbbEdit.Text = null;
                        }
                        else if (type == typeof(GridLookUpEdit)) {
                            GridLookUpEdit glEdit = li2.Control as GridLookUpEdit;
                            glEdit.Text = null;
                        }
                    }
                    else {
                        if (li is LayoutControlGroup li3) {
                            ClearControlData(li3);
                        }
                    }
                }
            }
            public static void SetValueToControl<T>(T TObject, XtraForm f) {
                if (TObject == null) return;
                foreach (var property in TObject.GetType().GetProperties()) {
                    string sName = "f" + property.Name;
                    Control[] control = f.Controls.Find(sName, true);
                    if (control.Length > 0) {
                        Type type = control[0].GetType();
                        if (type == typeof(TextEdit)) {
                            if (control[0] is TextEdit txtEdit) {
                                txtEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(DateEdit)) {
                            if (control[0] is DateEdit dateEdit) {
                                dateEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(ComboBoxEdit)) {
                            if (control[0] is ComboBoxEdit comboBoxEdit) {
                                comboBoxEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(CheckedComboBoxEdit)) {
                            if (control[0] is CheckedComboBoxEdit checkedComboBoxEdit) {
                                checkedComboBoxEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(MemoEdit)) {
                            if (control[0] is MemoEdit memoEdit) {
                                memoEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(SpinEdit)) {
                            if (control[0] is SpinEdit spinEdit) {
                                spinEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(CalcEdit)) {
                            if (control[0] is CalcEdit calcEdit) {
                                calcEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(CheckEdit)) {
                            if (control[0] is CheckEdit checkEdit) {
                                checkEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(LookUpEdit)) {
                            if (control[0] is LookUpEdit lookUpEdit) {
                                //lookUpEdit.EditValue = property.GetValue(TObject, null);
                                Object objValue = property.GetValue(TObject, null);
                                if (objValue != null) {
                                    Type TypeofData = objValue.GetType();
                                    AssignValue(objValue, TypeofData, lookUpEdit);
                                }
                            }
                        }
                        else if (type == typeof(SearchLookUpEdit)) {
                            if (control[0] is SearchLookUpEdit searchLookUpEdit) {
                                searchLookUpEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(GridLookUpEdit)) {
                            if (control[0] is GridLookUpEdit gridLookUpEdit) {
                                gridLookUpEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(ButtonEdit)) {
                            if (control[0] is ButtonEdit buttonEdit) {
                                buttonEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                        else if (type == typeof(HyperLinkEdit)) {
                            if (control[0] is HyperLinkEdit hyperLinkEdit) {
                                hyperLinkEdit.EditValue = property.GetValue(TObject, null);
                            }
                        }
                    }
                }
            }
            private static void AssignValue(object ObjValue, Type TypeofData, LookUpEdit ObjToAssign) {
                if (ObjValue == null) {
                    return;
                }
                if (TypeofData == typeof(Int16) || TypeofData == typeof(Int32) || TypeofData == typeof(Int64) || TypeofData == typeof(UInt16) || TypeofData == typeof(UInt32) || TypeofData == typeof(UInt64) || TypeofData == typeof(IntPtr) || TypeofData == typeof(UIntPtr) || TypeofData == typeof(Byte) || TypeofData == typeof(SByte)) {
                    ObjToAssign.EditValue = ConvertToInt(ObjValue);
                }
                else if (TypeofData == typeof(Double) || TypeofData == typeof(Decimal) || TypeofData == typeof(Single)) {
                    ObjToAssign.EditValue = ConvertToDouble(ObjValue);
                }
                else if (TypeofData == typeof(Char) || TypeofData == typeof(String)) {
                    ObjToAssign.EditValue = SafeToString(ObjValue);
                }
                else if (TypeofData == typeof(Boolean)) {
                    ObjToAssign.EditValue = ConvertToBool(ObjValue);
                }
                else if (TypeofData == typeof(DateTime) || TypeofData == typeof(DateTimeOffset)) {
                    ObjToAssign.EditValue = ConvertToDateTime(ObjValue);
                }
                else if (TypeofData == typeof(Guid)) {
                    ObjToAssign.EditValue = ConvertToGuid(ObjValue);
                }
            }
            public static void ClearEditControlErrorText(LayoutControlGroup layoutControlGroup) {
                foreach (var li in layoutControlGroup.Items) {
                    if (li is LayoutControlItem li2) {
                        if (li2.Control == null) continue;
                        Type type = li2.Control.GetType();
                        if (type == typeof(TextEdit)) {
                            TextEdit txtEdit = li2.Control as TextEdit;
                            txtEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(DateEdit)) {
                            DateEdit dEdit = li2.Control as DateEdit;
                            dEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(MemoEdit)) {
                            MemoEdit mEdit = li2.Control as MemoEdit;
                            mEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(SpinEdit)) {
                            SpinEdit sEdit = li2.Control as SpinEdit;
                            sEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(CheckEdit)) {
                            CheckEdit cEdit = li2.Control as CheckEdit;
                            cEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(LookUpEdit)) {
                            LookUpEdit lEdit = li2.Control as LookUpEdit;
                            lEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(SearchLookUpEdit)) {
                            SearchLookUpEdit slEdit = li2.Control as SearchLookUpEdit;
                            slEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(ButtonEdit)) {
                            ButtonEdit btEdit = li2.Control as ButtonEdit;
                            btEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(PictureEdit)) {
                            PictureEdit picEdit = li2.Control as PictureEdit;
                            picEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(ComboBoxEdit)) {
                            ComboBoxEdit cbbEdit = li2.Control as ComboBoxEdit;
                            cbbEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(CheckedComboBoxEdit)) {
                            CheckedComboBoxEdit ccbbEdit = li2.Control as CheckedComboBoxEdit;
                            ccbbEdit.ErrorText = string.Empty;
                        }
                        else if (type == typeof(GridLookUpEdit)) {
                            GridLookUpEdit glEdit = li2.Control as GridLookUpEdit;
                            glEdit.ErrorText = string.Empty;
                        }
                    }
                    else {
                        if (li is LayoutControlGroup li3) {
                            ClearEditControlErrorText(li3);
                        }
                    }
                }
            }
            public static void SetEditControlErrorText_ValidateResult(XtraForm f, params Tuple<string, string>[] lstFieldWithMessage) {
                foreach (var item in lstFieldWithMessage) {
                    string sName = "f" + item.Item1;
                    var control = f.Controls.Find(sName, true).FirstOrDefault();
                    if (control != null && control is BaseEdit baseEdit) {
                        baseEdit.ErrorText = item.Item2;
                    }
                }
            }
            public static void PreventMouseWheelForDropdown(XtraForm form) {
                if (form == null || form.Controls == null || form.Controls.Count == 0) return;
                var list = new List<PopupBaseAutoSearchEdit>();
                var layouts = new List<LayoutControl>();
                foreach (var control in form.Controls) {
                    if (control != null && control is LayoutControl) {
                        layouts.Add((LayoutControl)control);
                    }
                }
                foreach (var layout in layouts) {
                    if (layout.Controls != null && layout.Controls.Count > 0) {
                        foreach (var control in layout.Controls) {
                            if (control != null && control is PopupBaseAutoSearchEdit) {
                                list.Add((PopupBaseAutoSearchEdit)control);
                            }
                        }
                    }
                }
                PreventMouseWheelForDropdown(list.ToArray());
            }
            public static void PreventMouseWheelForDropdown(params PopupBaseAutoSearchEdit[] lookups) {
                foreach (var lookup in lookups) {
                    lookup.Properties.AllowMouseWheel = false;
                }
            }
            public static void ConfigureDateEdits(params DateEdit[] dateEdits) {
                foreach (var dateEdit in dateEdits) {
                    dateEdit.Properties.Mask.EditMask = "dd/MM/yyyy";
                    dateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
                    dateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    dateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                    dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    dateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
                    dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    dateEdit.KeyPress += (sender, e) => {
                        if (char.IsDigit(e.KeyChar)) {
                            string text = dateEdit.Text;
                            int cursorPosition = dateEdit.SelectionStart;
                            if (cursorPosition == 2 && text.Length == 2) {
                                dateEdit.Focus();
                                SendKeys.Send("{RIGHT}"); // Di chuyển con trỏ sang phần tháng (MM)
                            }
                        }
                    };
                }
            }
            public static void LoadFromObject(object lookUp, IEnumerable<object> dataSource, string valueMember, string displayMember, List<Tuple<string, string>> viewColumns = null) {
                if (lookUp is LookUpEdit lookUpEdit) {
                    lookUpEdit.Properties.DataSource = dataSource;
                    lookUpEdit.Properties.ValueMember = valueMember;
                    lookUpEdit.Properties.DisplayMember = displayMember;
                }
                if (lookUp is RepositoryItemLookUpEdit repoLookUpEdit) {
                    repoLookUpEdit.DataSource = dataSource;
                    repoLookUpEdit.ValueMember = valueMember;
                    repoLookUpEdit.DisplayMember = displayMember;
                }
                if (lookUp is SearchLookUpEdit searchLookUpEdit) {
                    searchLookUpEdit.Properties.DataSource = dataSource;
                    searchLookUpEdit.Properties.ValueMember = valueMember;
                    searchLookUpEdit.Properties.DisplayMember = displayMember;
                    if (viewColumns != null) CreateColumns(searchLookUpEdit.Properties.View, viewColumns);
                }
                else if (lookUp is RepositoryItemSearchLookUpEdit repoSearchLookUpEdit) {
                    repoSearchLookUpEdit.DataSource = dataSource;
                    repoSearchLookUpEdit.ValueMember = valueMember;
                    repoSearchLookUpEdit.DisplayMember = displayMember;
                    if (viewColumns != null) CreateColumns(repoSearchLookUpEdit.View, viewColumns);
                }
            }
            private static void CreateColumns(DevExpress.XtraGrid.Views.Grid.GridView gridView, List<Tuple<string, string>> columnsToDisplay) {
                foreach (var columnInfo in columnsToDisplay) {
                    var column = gridView.Columns.AddField(columnInfo.Item1);
                    column.VisibleIndex = gridView.Columns.Count - 1; // Đặt chỉ số cho cột
                    column.Caption = columnInfo.Item2;  // Đặt tên cột
                    column.Visible = true;
                }
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns) {
                    if (!columnsToDisplay.Any(c => c.Item1 == column.FieldName)) {
                        column.Visible = false;
                    }
                }
            }
            public static string SafeToString(object obj) {
                if (obj == null || obj == DBNull.Value) return "";
                return obj.ToString();
            }
            public static int ConvertToInt(object obj) {
                if (obj == null || obj == DBNull.Value) return 0;
                return Convert.ToInt32(obj);
            }
            public static int? ConvertToNullableInt(object obj) {
                if (obj == null || obj == DBNull.Value) return null;
                return Convert.ToInt32(obj);
            }
            public static double ConvertToDouble(object obj) {
                if (obj == null || obj == DBNull.Value) return 0;
                return Convert.ToDouble(obj);
            }
            public static double? ConvertToNullableDouble(object obj) {
                if (obj == null || obj == DBNull.Value) return null;
                return Convert.ToDouble(obj);
            }
            public static decimal ConvertToDecimal(object obj) {
                if (obj == null || obj == DBNull.Value) return 0;
                return Convert.ToDecimal(obj);
            }
            public static decimal? ConvertToNullableDecimal(object obj) {
                if (obj == null || obj == DBNull.Value) return null;
                return Convert.ToDecimal(obj);
            }
            public static bool ConvertToBool(object obj) {
                if (obj == null || obj == DBNull.Value) return false;
                return Convert.ToBoolean(obj);
            }
            public static bool? ConvertToNullableBool(object obj) {
                if (obj == null || obj == DBNull.Value) return null;
                return Convert.ToBoolean(obj);
            }
            public static DateTime ConvertToDateTime(object obj) {
                if (obj == null || obj == DBNull.Value) return default;
                return Convert.ToDateTime(obj);
            }
            public static DateTime? ConvertToNullableDateTime(object obj) {
                if (obj == null || obj == DBNull.Value) return null;
                return Convert.ToDateTime(obj);
            }
            public static Guid ConvertToGuid(object obj) {
                if (obj == null || obj == DBNull.Value) return default;
                return Guid.Parse(obj.ToString());
            }
            public static Guid? ConvertToNullableGuid(object obj) {
                if (obj == null || obj == DBNull.Value) return null;
                return Guid.Parse(obj.ToString());
            }
        }
    }
    public static class ImageExtensions {
        public static byte[] ToByteArray(this Image image) {
            if (image == null) return null;
            using (var memoryStream = new MemoryStream()) {
                image.Save(memoryStream, image.RawFormat);
                return memoryStream.ToArray();
            }
        }
    }

    public static class ByteExtensions {
        public static byte[] CompressBytes(this byte[] data) {
            if (data == null || data.Length == 0) return data;

            using (var outputStream = new MemoryStream()) {
                using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress)) {
                    gzipStream.Write(data, 0, data.Length);
                }
                return outputStream.ToArray();
            }
        }
    }
    public static class ByteArrayExtensions {
        public static byte[] DecompressBytes(this byte[] compressedData) {
            if (compressedData == null || compressedData.Length == 0)
                return null;

            using (var outputMemoryStream = new MemoryStream())
            using (var inputMemoryStream = new MemoryStream(compressedData))
            using (var decompressStream = new GZipStream(inputMemoryStream, CompressionMode.Decompress)) {
                decompressStream.CopyTo(outputMemoryStream);
                return outputMemoryStream.ToArray();
            }
        }
    }

    public class CustomGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.FindControlFindButton:
                    return "検索🔍";

                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
