using DevExpress.XtraBars;
using System.Linq;
using System.Windows.Forms;
using VocabLearningApp.BUS;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FrmMain() {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, System.EventArgs e) {
            clsGlobalVariables.SelectedTermType = EnumTermType.FE;
        }

        private void ribbon_SelectedPageChanged(object sender, System.EventArgs e) {
            if (ribbon.SelectedPage == ribbonPageFE) clsGlobalVariables.SelectedTermType = EnumTermType.FE;
            else if (ribbon.SelectedPage == ribbonPageAP) clsGlobalVariables.SelectedTermType = EnumTermType.AP;
        }

        private void OpenMdiForm<T>() where T : Form, new() {
            var existingForm = this.MdiChildren.OfType<T>().FirstOrDefault();
            if (existingForm != null) {
                existingForm.Activate();
                return;
            }
            var frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnFE_Category_ItemClick(object sender, ItemClickEventArgs e) {
            OpenMdiForm<FrmCategory>();
        }

        private void btnFE_Chapter_ItemClick(object sender, ItemClickEventArgs e) {
            OpenMdiForm<FrmChapter>();
        }

        private void btnFE_Lesson_ItemClick(object sender, ItemClickEventArgs e) {
            OpenMdiForm<FrmLesson>();
        }

        private void btnFE_Term_ItemClick(object sender, ItemClickEventArgs e) {
            OpenMdiForm<FrmTerm>();
        }

        private void btnFE_Dictionary_ItemClick(object sender, ItemClickEventArgs e) {
            OpenMdiForm<FrmDictionary>();
        }

        private void btnFE_VocabBook_ItemClick(object sender, ItemClickEventArgs e) {
            OpenMdiForm<FrmVocabBook>();
        }

        private void btnFE_Practice_ItemClick(object sender, ItemClickEventArgs e) {
            OpenMdiForm<FrmPractice>();
        }
    }
}