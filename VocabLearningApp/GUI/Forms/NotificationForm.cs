using System;
using System.Drawing;
using System.Windows.Forms;

namespace VocabLearningApp.GUI.Forms {
    public partial class NotificationForm : DevExpress.XtraEditors.XtraForm {
        private Timer timer;
        private double Speed = 0.5;
        int? LabelImg;

        public NotificationForm(string content, int? labelImg = 1) {
            InitializeComponent();
            label.Text = content;
            timer = new Timer();
            timer.Interval = 2;
            timer.Tick += Timer_Tick;
            timer.Start();
            LabelImg = labelImg;
        }
        private void Timer_Tick(object sender, EventArgs e) {
            progressBarControl1.EditValue = Speed;
            if (Convert.ToInt32(progressBarControl1.EditValue) == 100) {
                this.Close();
            }
            else {
                Speed += 0.4;
            }
        }
        private void NotificationForm_Load(object sender, EventArgs e) {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Width = labelControl1.Width + label.Width + 40;
            if (LabelImg == 1) {
                labelControl1.ImageOptions.ImageUri.Uri = "Apply";
            }
            else {
                labelControl1.ImageOptions.ImageUri.Uri = "Cancel";
            }
            progressBarControl1.Width = this.Width;
            progressBarControl1.EditValue = 100;
            progressBarControl1.ForeColor = Color.Red;
            this.Location = new Point(screenWidth - this.Width + 20, 0);
        }
    }
}