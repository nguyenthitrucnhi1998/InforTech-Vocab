using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VocabLearningApp.BUS;
using VocabLearningApp.DAL.DTO;

namespace VocabLearningApp.GUI.Forms {
    public partial class FrmFlashCardOrQuiz : DevExpress.XtraEditors.XtraForm {
        DataSourceBus _busDataSource = new();
        EnumDataSourceType _dataSourceType;
        List<int> _lstIds = new();
        List<FlatTermDTO> _lstTerms = new();

        public FrmFlashCardOrQuiz(EnumDataSourceType dataSourceType, List<int> lstIds) {
            InitializeComponent();
            _dataSourceType = dataSourceType;
            _lstIds = lstIds;
        }

        private void FrmFlashCardOrQuiz_Load(object sender, EventArgs e) {
        
        }

        private async void btnFlashCard_Click(object sender, EventArgs e) {
            await LoadTermsData();
            var frm = new FrmFlashCard(_lstTerms);
            frm.ShowDialog();
        }

        private async void btnQuiz_Click(object sender, EventArgs e) {
            await LoadTermsData();
            var frm = new FrmQuiz(_lstTerms);
            frm.ShowDialog();
        }

        private async Task LoadTermsData() {
            if (_dataSourceType == EnumDataSourceType.FromLearningData) {
                _lstTerms = await _busDataSource.GetTermsBySelectedLessons(_lstIds);
            }
            else if (_dataSourceType == EnumDataSourceType.FromVocabBook) {
                _lstTerms = await _busDataSource.GetTermsBySelectedVocabBooks(_lstIds);
            }
        }
    }
}