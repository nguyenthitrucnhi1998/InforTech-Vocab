using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;
using static VocabLearningApp.GUI.Common.clsCommon;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmPractice : DevExpress.XtraEditors.XtraForm {
        DataSourceBus _busDataSource = new();

        public FrmPractice() {
            InitializeComponent();
        }

        private void FrmPractice_Load(object sender, EventArgs e) {
            CommonConfig();
            LoadDataRepo();
        }

        private void CommonConfig() {
            ConfigShorthandEvent();

            treeListData.KeyFieldName = nameof(TreeNodeDTO.Id);
            treeListData.ParentFieldName = nameof(TreeNodeDTO.ParentId);
            treeListData.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            treeListData.Appearance.FocusedCell.BackColor = SystemColors.Highlight;
            treeListData.Appearance.FocusedCell.ForeColor = SystemColors.HighlightText;
            treeListData.OptionsView.ShowCheckBoxes = true;
        }
        private void LoadDataRepo() {
            try {
                var dataSource = new List<OptionDTO>() {
                    new() { OptionId = (int)EnumDataSourceType.FromLearningData, OptionName = "From LearningData" },
                    new() { OptionId = (int)EnumDataSourceType.FromVocabBook, OptionName = "From VocabBook" }
                };
                var viewColumns = new List<Tuple<string, string>> {
                    new(nameof(OptionDTO.OptionName), "DataSource")
                };
                CommonHandler.LoadFromObject(fPracticeDataSource, dataSource, nameof(OptionDTO.OptionId), nameof(OptionDTO.OptionName), viewColumns);
            }
            catch {
                throw;
            }
        }
        private async Task LoadTreeDataAndCommonConfig(EnumDataSourceType dataSourceType) {
            List<TreeNodeDTO> treeData = new List<TreeNodeDTO>();
            if (dataSourceType == EnumDataSourceType.FromLearningData) treeData = await _busDataSource.GetTreeDataToLessons();
            else if (dataSourceType == EnumDataSourceType.FromVocabBook) treeData = await _busDataSource.GetTreeDataToVocabBooks();

            treeListData.DataSource = treeData;
            treeListData.ExpandToLevel(0);
        }
        private void ConfigShorthandEvent() {
            treeListData.AfterCheckNode += (s, e) => {
                SetChildNodesCheckedState(e.Node, e.Node.CheckState);
            };

            fPracticeDataSource.EditValueChanged += async (s, e) => {
                var lookup = s as SearchLookUpEdit;
                var dataSourceType = (EnumDataSourceType)(Convert.ToInt32(lookup.EditValue));
                await LoadTreeDataAndCommonConfig(dataSourceType);
            };
        }
        private void SetChildNodesCheckedState(TreeListNode parentNode, CheckState checkedState) {
            foreach (TreeListNode childNode in parentNode.Nodes) {
                childNode.Checked = checkedState == CheckState.Checked;

                if (childNode.HasChildren) {
                    SetChildNodesCheckedState(childNode, checkedState);
                }
            }
        }
        private List<TreeListNode> GetCheckedLeafNodes(TreeList treeList) {
            var result = new List<TreeListNode>();
            foreach (TreeListNode node in treeList.GetAllCheckedNodes()) {
                if (!node.HasChildren) {
                    result.Add(node);
                }
            }
            return result;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            treeListData.UncheckAll();
            treeListData.CollapseAll();
            treeListData.ExpandToLevel(0);
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.Close();
        }
        private void btnStartPractice_Click(object sender, EventArgs e) {
            var dsTypeValue = fPracticeDataSource.EditValue;
            if (dsTypeValue == null) {
                XtraMessageBox.Show("復習するデータソースを選択してください", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            var lstSelectedLeafNodes = GetCheckedLeafNodes(treeListData);
            if (!lstSelectedLeafNodes.Any()) {
                XtraMessageBox.Show("ツリーから少なくとも1つの項目を選択してください", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var lstData = lstSelectedLeafNodes.Select(x => x.GetValue(nameof(TreeNodeDTO.Id))).ToList();
            var lstIds = lstData.Select(x => x.ToString().Split('.').Last()).Select(x => Convert.ToInt32(x)).ToList();

            var frm = new FrmFlashCardOrQuiz((EnumDataSourceType)dsTypeValue, lstIds);
            frm.ShowDialog();
        }
    }
}