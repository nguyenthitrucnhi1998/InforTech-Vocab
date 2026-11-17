namespace VocabLearningApp.GUI.Forms {
    partial class FrmTermDetail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTermDetail));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.fMeaning = new DevExpress.XtraEditors.MemoEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAddToVocabBook = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.fTermPath = new DevExpress.XtraEditors.TextEdit();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.fImageData = new DevExpress.XtraEditors.PictureEdit();
            this.fPronounce = new DevExpress.XtraEditors.TextEdit();
            this.fTermName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupEditControl = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem_MetaDataView = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fMeaning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTermPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fImageData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPronounce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTermName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEditControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_MetaDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.fMeaning);
            this.layoutControl1.Controls.Add(this.fTermPath);
            this.layoutControl1.Controls.Add(this.webBrowser1);
            this.layoutControl1.Controls.Add(this.fImageData);
            this.layoutControl1.Controls.Add(this.fPronounce);
            this.layoutControl1.Controls.Add(this.fTermName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 30);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1322, 737);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // fMeaning
            // 
            this.fMeaning.Location = new System.Drawing.Point(152, 148);
            this.fMeaning.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fMeaning.MenuManager = this.barManager1;
            this.fMeaning.Name = "fMeaning";
            this.fMeaning.Size = new System.Drawing.Size(1144, 118);
            this.fMeaning.StyleController = this.layoutControl1;
            this.fMeaning.TabIndex = 16;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnClose,
            this.btnAddToVocabBook});
            this.barManager1.MaxItemId = 8;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddToVocabBook),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar1.Text = "Tools";
            // 
            // btnAddToVocabBook
            // 
            this.btnAddToVocabBook.Caption = "保存リスト選択";
            this.btnAddToVocabBook.Id = 7;
            this.btnAddToVocabBook.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToVocabBook.ImageOptions.Image")));
            this.btnAddToVocabBook.Name = "btnAddToVocabBook";
            this.btnAddToVocabBook.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAddToVocabBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddToVocabBook_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "閉じる";
            this.btnClose.Id = 6;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1322, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 767);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1322, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 737);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1322, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 737);
            // 
            // fTermPath
            // 
            this.fTermPath.Location = new System.Drawing.Point(152, 58);
            this.fTermPath.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.fTermPath.MenuManager = this.barManager1;
            this.fTermPath.Name = "fTermPath";
            this.fTermPath.Size = new System.Drawing.Size(1144, 24);
            this.fTermPath.StyleController = this.layoutControl1;
            this.fTermPath.TabIndex = 15;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(39, 355);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(26, 28);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(715, 334);
            this.webBrowser1.TabIndex = 14;
            // 
            // fImageData
            // 
            this.fImageData.Location = new System.Drawing.Point(758, 355);
            this.fImageData.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.fImageData.MenuManager = this.barManager1;
            this.fImageData.Name = "fImageData";
            this.fImageData.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.fImageData.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.fImageData.Size = new System.Drawing.Size(525, 334);
            this.fImageData.StyleController = this.layoutControl1;
            this.fImageData.TabIndex = 11;
            // 
            // fPronounce
            // 
            this.fPronounce.Location = new System.Drawing.Point(152, 118);
            this.fPronounce.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.fPronounce.MenuManager = this.barManager1;
            this.fPronounce.Name = "fPronounce";
            this.fPronounce.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fPronounce.Properties.Appearance.Options.UseForeColor = true;
            this.fPronounce.Size = new System.Drawing.Size(1144, 24);
            this.fPronounce.StyleController = this.layoutControl1;
            this.fPronounce.TabIndex = 8;
            // 
            // fTermName
            // 
            this.fTermName.Location = new System.Drawing.Point(152, 88);
            this.fTermName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.fTermName.MenuManager = this.barManager1;
            this.fTermName.Name = "fTermName";
            this.fTermName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fTermName.Properties.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            this.fTermName.Properties.Appearance.Options.UseFont = true;
            this.fTermName.Properties.Appearance.Options.UseForeColor = true;
            this.fTermName.Size = new System.Drawing.Size(1144, 24);
            this.fTermName.StyleController = this.layoutControl1;
            this.fTermName.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupEditControl});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1322, 737);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroupEditControl
            // 
            this.layoutControlGroupEditControl.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroupEditControl.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroupEditControl.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlGroupEditControl.CaptionImageOptions.Image")));
            this.layoutControlGroupEditControl.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlGroup1,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.splitterItem1});
            this.layoutControlGroupEditControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupEditControl.Name = "layoutControlGroupEditControl";
            this.layoutControlGroupEditControl.Size = new System.Drawing.Size(1300, 711);
            this.layoutControlGroupEditControl.Text = "情報";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.fTermName;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1274, 30);
            this.layoutControlItem3.Text = "用語名";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(121, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.fPronounce;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1274, 30);
            this.layoutControlItem2.Text = "ふりがな";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(121, 18);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 221);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 14);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(14, 14);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1274, 14);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem_MetaDataView});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 235);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1274, 418);
            this.layoutControlGroup1.Text = "Additional Information";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.fImageData;
            this.layoutControlItem7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlItem7.ImageOptions.Image")));
            this.layoutControlItem7.Location = new System.Drawing.Point(719, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(529, 361);
            this.layoutControlItem7.Text = "画像";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(121, 18);
            // 
            // layoutControlItem_MetaDataView
            // 
            this.layoutControlItem_MetaDataView.Control = this.webBrowser1;
            this.layoutControlItem_MetaDataView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlItem_MetaDataView.ImageOptions.Image")));
            this.layoutControlItem_MetaDataView.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem_MetaDataView.Name = "layoutControlItem_MetaDataView";
            this.layoutControlItem_MetaDataView.Size = new System.Drawing.Size(719, 361);
            this.layoutControlItem_MetaDataView.Text = "メタデータ (View)";
            this.layoutControlItem_MetaDataView.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem_MetaDataView.TextSize = new System.Drawing.Size(121, 18);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.fTermPath;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1274, 30);
            this.layoutControlItem1.Text = "用語パス";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(121, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.fMeaning;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1274, 124);
            this.layoutControlItem4.Text = "意味";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(121, 18);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(0, 214);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(1274, 7);
            // 
            // FrmTermDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 789);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmTermDetail.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmTermDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用語詳細";
            this.Load += new System.EventHandler(this.FrmTermDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fMeaning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTermPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fImageData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPronounce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTermName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEditControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_MetaDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupEditControl;
        private DevExpress.XtraEditors.TextEdit fTermName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit fPronounce;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PictureEdit fImageData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem_MetaDataView;
        private DevExpress.XtraEditors.TextEdit fTermPath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem btnAddToVocabBook;
        private DevExpress.XtraEditors.MemoEdit fMeaning;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
    }
}