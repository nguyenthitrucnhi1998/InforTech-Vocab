namespace VocabLearningApp.GUI.Forms {
    partial class FrmMain {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAP_Category = new DevExpress.XtraBars.BarButtonItem();
            this.btnAP_Chapter = new DevExpress.XtraBars.BarButtonItem();
            this.btnAP_Lesson = new DevExpress.XtraBars.BarButtonItem();
            this.btnFE_Category = new DevExpress.XtraBars.BarButtonItem();
            this.btnFE_Chapter = new DevExpress.XtraBars.BarButtonItem();
            this.btnFE_Lesson = new DevExpress.XtraBars.BarButtonItem();
            this.btnFE_Dictionary = new DevExpress.XtraBars.BarButtonItem();
            this.btnFE_VocabBook = new DevExpress.XtraBars.BarButtonItem();
            this.btnAP_Dictionary = new DevExpress.XtraBars.BarButtonItem();
            this.btnAP_VocabBook = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFE_Term = new DevExpress.XtraBars.BarButtonItem();
            this.btnAP_Term = new DevExpress.XtraBars.BarButtonItem();
            this.btnFE_Practice = new DevExpress.XtraBars.BarButtonItem();
            this.btnAP_Practice = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageFE = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageAP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 41, 40, 41);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnAP_Category,
            this.btnAP_Chapter,
            this.btnAP_Lesson,
            this.btnFE_Category,
            this.btnFE_Chapter,
            this.btnFE_Lesson,
            this.btnFE_Dictionary,
            this.btnFE_VocabBook,
            this.btnAP_Dictionary,
            this.btnAP_VocabBook,
            this.barButtonItem15,
            this.barButtonItem16,
            this.btnFE_Term,
            this.btnAP_Term,
            this.btnFE_Practice,
            this.btnAP_Practice});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbon.MaxItemId = 21;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 440;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageFE,
            this.ribbonPageAP});
            this.ribbon.Size = new System.Drawing.Size(1932, 191);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.SelectedPageChanged += new System.EventHandler(this.ribbon_SelectedPageChanged);
            // 
            // btnAP_Category
            // 
            this.btnAP_Category.Caption = "カテゴリ";
            this.btnAP_Category.Id = 1;
            this.btnAP_Category.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAP_Category.ImageOptions.LargeImage")));
            this.btnAP_Category.LargeWidth = 60;
            this.btnAP_Category.Name = "btnAP_Category";
            this.btnAP_Category.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAP_Category.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Category_ItemClick);
            // 
            // btnAP_Chapter
            // 
            this.btnAP_Chapter.Caption = "カテゴリ一覧";
            this.btnAP_Chapter.Id = 2;
            this.btnAP_Chapter.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAP_Chapter.ImageOptions.LargeImage")));
            this.btnAP_Chapter.LargeWidth = 60;
            this.btnAP_Chapter.Name = "btnAP_Chapter";
            this.btnAP_Chapter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAP_Chapter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Chapter_ItemClick);
            // 
            // btnAP_Lesson
            // 
            this.btnAP_Lesson.Caption = "問題一覧";
            this.btnAP_Lesson.Id = 3;
            this.btnAP_Lesson.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAP_Lesson.ImageOptions.LargeImage")));
            this.btnAP_Lesson.LargeWidth = 60;
            this.btnAP_Lesson.Name = "btnAP_Lesson";
            this.btnAP_Lesson.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAP_Lesson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Lesson_ItemClick);
            // 
            // btnFE_Category
            // 
            this.btnFE_Category.Caption = "カテゴリ";
            this.btnFE_Category.Id = 4;
            this.btnFE_Category.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFE_Category.ImageOptions.LargeImage")));
            this.btnFE_Category.LargeWidth = 60;
            this.btnFE_Category.Name = "btnFE_Category";
            this.btnFE_Category.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFE_Category.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Category_ItemClick);
            // 
            // btnFE_Chapter
            // 
            this.btnFE_Chapter.Caption = "カテゴリ一覧";
            this.btnFE_Chapter.Id = 5;
            this.btnFE_Chapter.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFE_Chapter.ImageOptions.LargeImage")));
            this.btnFE_Chapter.LargeWidth = 60;
            this.btnFE_Chapter.Name = "btnFE_Chapter";
            this.btnFE_Chapter.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnFE_Chapter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Chapter_ItemClick);
            // 
            // btnFE_Lesson
            // 
            this.btnFE_Lesson.Caption = "問題一覧";
            this.btnFE_Lesson.Id = 6;
            this.btnFE_Lesson.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFE_Lesson.ImageOptions.LargeImage")));
            this.btnFE_Lesson.LargeWidth = 60;
            this.btnFE_Lesson.Name = "btnFE_Lesson";
            this.btnFE_Lesson.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFE_Lesson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Lesson_ItemClick);
            // 
            // btnFE_Dictionary
            // 
            this.btnFE_Dictionary.Caption = "辞書";
            this.btnFE_Dictionary.Id = 7;
            this.btnFE_Dictionary.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFE_Dictionary.ImageOptions.LargeImage")));
            this.btnFE_Dictionary.LargeWidth = 60;
            this.btnFE_Dictionary.Name = "btnFE_Dictionary";
            this.btnFE_Dictionary.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFE_Dictionary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Dictionary_ItemClick);
            // 
            // btnFE_VocabBook
            // 
            this.btnFE_VocabBook.Caption = "保存リスト";
            this.btnFE_VocabBook.Id = 8;
            this.btnFE_VocabBook.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFE_VocabBook.ImageOptions.LargeImage")));
            this.btnFE_VocabBook.LargeWidth = 60;
            this.btnFE_VocabBook.Name = "btnFE_VocabBook";
            this.btnFE_VocabBook.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFE_VocabBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_VocabBook_ItemClick);
            // 
            // btnAP_Dictionary
            // 
            this.btnAP_Dictionary.Caption = "辞書";
            this.btnAP_Dictionary.Id = 9;
            this.btnAP_Dictionary.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAP_Dictionary.ImageOptions.LargeImage")));
            this.btnAP_Dictionary.LargeWidth = 60;
            this.btnAP_Dictionary.Name = "btnAP_Dictionary";
            this.btnAP_Dictionary.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAP_Dictionary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Dictionary_ItemClick);
            // 
            // btnAP_VocabBook
            // 
            this.btnAP_VocabBook.Caption = "用語集";
            this.btnAP_VocabBook.Id = 10;
            this.btnAP_VocabBook.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAP_VocabBook.ImageOptions.LargeImage")));
            this.btnAP_VocabBook.LargeWidth = 60;
            this.btnAP_VocabBook.Name = "btnAP_VocabBook";
            this.btnAP_VocabBook.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAP_VocabBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_VocabBook_ItemClick);
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "barButtonItem15";
            this.barButtonItem15.Id = 15;
            this.barButtonItem15.Name = "barButtonItem15";
            // 
            // barButtonItem16
            // 
            this.barButtonItem16.Caption = "FE";
            this.barButtonItem16.Id = 16;
            this.barButtonItem16.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 20F);
            this.barButtonItem16.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem16.Name = "barButtonItem16";
            this.barButtonItem16.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnFE_Term
            // 
            this.btnFE_Term.Caption = "用語追加";
            this.btnFE_Term.Id = 17;
            this.btnFE_Term.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFE_Term.ImageOptions.LargeImage")));
            this.btnFE_Term.LargeWidth = 60;
            this.btnFE_Term.Name = "btnFE_Term";
            this.btnFE_Term.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFE_Term.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Term_ItemClick);
            // 
            // btnAP_Term
            // 
            this.btnAP_Term.Caption = "用語追加";
            this.btnAP_Term.Id = 18;
            this.btnAP_Term.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAP_Term.ImageOptions.LargeImage")));
            this.btnAP_Term.LargeWidth = 60;
            this.btnAP_Term.Name = "btnAP_Term";
            this.btnAP_Term.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAP_Term.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Term_ItemClick);
            // 
            // btnFE_Practice
            // 
            this.btnFE_Practice.Caption = "勉強";
            this.btnFE_Practice.Id = 19;
            this.btnFE_Practice.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFE_Practice.ImageOptions.LargeImage")));
            this.btnFE_Practice.LargeWidth = 60;
            this.btnFE_Practice.Name = "btnFE_Practice";
            this.btnFE_Practice.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFE_Practice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Practice_ItemClick);
            // 
            // btnAP_Practice
            // 
            this.btnAP_Practice.Caption = "勉強";
            this.btnAP_Practice.Id = 20;
            this.btnAP_Practice.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAP_Practice.ImageOptions.LargeImage")));
            this.btnAP_Practice.LargeWidth = 60;
            this.btnAP_Practice.Name = "btnAP_Practice";
            this.btnAP_Practice.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAP_Practice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFE_Practice_ItemClick);
            // 
            // ribbonPageFE
            // 
            this.ribbonPageFE.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.ribbonPageFE.Appearance.ForeColor = System.Drawing.Color.Green;
            this.ribbonPageFE.Appearance.Options.UseFont = true;
            this.ribbonPageFE.Appearance.Options.UseForeColor = true;
            this.ribbonPageFE.AppearanceSelected.ForeColor = System.Drawing.Color.Green;
            this.ribbonPageFE.AppearanceSelected.Options.UseForeColor = true;
            this.ribbonPageFE.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup5});
            this.ribbonPageFE.Name = "ribbonPageFE";
            this.ribbonPageFE.Text = "FE";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFE_Category);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFE_Chapter);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFE_Lesson);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFE_Term);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "編集";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFE_Dictionary);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFE_VocabBook);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "検索・保存";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnFE_Practice);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "復習";
            // 
            // ribbonPageAP
            // 
            this.ribbonPageAP.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.ribbonPageAP.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            this.ribbonPageAP.Appearance.Options.UseFont = true;
            this.ribbonPageAP.Appearance.Options.UseForeColor = true;
            this.ribbonPageAP.AppearanceSelected.ForeColor = System.Drawing.Color.Firebrick;
            this.ribbonPageAP.AppearanceSelected.Options.UseForeColor = true;
            this.ribbonPageAP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup6});
            this.ribbonPageAP.Name = "ribbonPageAP";
            this.ribbonPageAP.Text = "AP";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAP_Category);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAP_Chapter);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAP_Lesson);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAP_Term);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "編集";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnAP_Dictionary);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnAP_VocabBook);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "検索・保存";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnAP_Practice);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "復習";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 1071);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1932, 30);
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 1101);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "IT用語学習";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageFE;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageAP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnAP_Category;
        private DevExpress.XtraBars.BarButtonItem btnAP_Chapter;
        private DevExpress.XtraBars.BarButtonItem btnAP_Lesson;
        private DevExpress.XtraBars.BarButtonItem btnFE_Category;
        private DevExpress.XtraBars.BarButtonItem btnFE_Chapter;
        private DevExpress.XtraBars.BarButtonItem btnFE_Lesson;
        private DevExpress.XtraBars.BarButtonItem btnFE_Dictionary;
        private DevExpress.XtraBars.BarButtonItem btnFE_VocabBook;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnAP_Dictionary;
        private DevExpress.XtraBars.BarButtonItem btnAP_VocabBook;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnFE_Term;
        private DevExpress.XtraBars.BarButtonItem btnAP_Term;
        private DevExpress.XtraBars.BarButtonItem btnFE_Practice;
        private DevExpress.XtraBars.BarButtonItem btnAP_Practice;
    }
}