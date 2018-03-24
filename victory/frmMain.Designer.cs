namespace victory
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mnuData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTeacher = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScholar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJournal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJournalGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGroup1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuhMain = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuhCardPrepod = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuhPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.timerPingDb = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.mnuSubjHour = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuData,
            this.mnuJournal,
            this.mnuReport,
            this.справочникToolStripMenuItem,
            this.mnuBuhMain});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1009, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // mnuData
            // 
            this.mnuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTest,
            this.mnuTeacher,
            this.mnuScholar,
            this.mnuGroup});
            this.mnuData.Name = "mnuData";
            this.mnuData.Size = new System.Drawing.Size(62, 20);
            this.mnuData.Text = "Данные";
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Size = new System.Drawing.Size(159, 22);
            this.mnuTest.Text = "тест";
            this.mnuTest.Visible = false;
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // mnuTeacher
            // 
            this.mnuTeacher.Name = "mnuTeacher";
            this.mnuTeacher.Size = new System.Drawing.Size(159, 22);
            this.mnuTeacher.Text = "Преподаватели";
            this.mnuTeacher.Click += new System.EventHandler(this.mnuTeacher_Click);
            // 
            // mnuScholar
            // 
            this.mnuScholar.Name = "mnuScholar";
            this.mnuScholar.Size = new System.Drawing.Size(159, 22);
            this.mnuScholar.Text = "Ученики";
            this.mnuScholar.Click += new System.EventHandler(this.mnuScholar_Click);
            // 
            // mnuGroup
            // 
            this.mnuGroup.Name = "mnuGroup";
            this.mnuGroup.Size = new System.Drawing.Size(159, 22);
            this.mnuGroup.Text = "Группы";
            this.mnuGroup.Click += new System.EventHandler(this.mnuGroup_Click);
            // 
            // mnuJournal
            // 
            this.mnuJournal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJournalGroup});
            this.mnuJournal.Name = "mnuJournal";
            this.mnuJournal.Size = new System.Drawing.Size(72, 20);
            this.mnuJournal.Text = "Журналы";
            // 
            // mnuJournalGroup
            // 
            this.mnuJournalGroup.Name = "mnuJournalGroup";
            this.mnuJournalGroup.Size = new System.Drawing.Size(185, 22);
            this.mnuJournalGroup.Text = "Журнал по группам";
            this.mnuJournalGroup.Click += new System.EventHandler(this.mnuJournalGroup_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGroup1,
            this.mnuSubjHour});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(60, 20);
            this.mnuReport.Text = "Отчёты";
            // 
            // mnuGroup1
            // 
            this.mnuGroup1.Name = "mnuGroup1";
            this.mnuGroup1.Size = new System.Drawing.Size(201, 22);
            this.mnuGroup1.Text = "Актуальные группы";
            this.mnuGroup1.Click += new System.EventHandler(this.mnuGroup1_Click);
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCity,
            this.mnuSubject});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // mnuCity
            // 
            this.mnuCity.Name = "mnuCity";
            this.mnuCity.Size = new System.Drawing.Size(131, 22);
            this.mnuCity.Text = "Города";
            this.mnuCity.Click += new System.EventHandler(this.mnuCity_Click);
            // 
            // mnuSubject
            // 
            this.mnuSubject.Name = "mnuSubject";
            this.mnuSubject.Size = new System.Drawing.Size(131, 22);
            this.mnuSubject.Text = "Предметы";
            this.mnuSubject.Click += new System.EventHandler(this.mnuSubject_Click);
            // 
            // mnuBuhMain
            // 
            this.mnuBuhMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBuhCardPrepod,
            this.mnuBuhPayment});
            this.mnuBuhMain.Name = "mnuBuhMain";
            this.mnuBuhMain.Size = new System.Drawing.Size(86, 20);
            this.mnuBuhMain.Text = "Бухгалтерия";
            // 
            // mnuBuhCardPrepod
            // 
            this.mnuBuhCardPrepod.Name = "mnuBuhCardPrepod";
            this.mnuBuhCardPrepod.Size = new System.Drawing.Size(210, 22);
            this.mnuBuhCardPrepod.Text = "Карточка преподавателя";
            this.mnuBuhCardPrepod.Click += new System.EventHandler(this.mnuBuhCardPrepod_Click);
            // 
            // mnuBuhPayment
            // 
            this.mnuBuhPayment.Name = "mnuBuhPayment";
            this.mnuBuhPayment.Size = new System.Drawing.Size(210, 22);
            this.mnuBuhPayment.Text = "Расчет оплаты труда";
            this.mnuBuhPayment.Click += new System.EventHandler(this.mnuBuhPayment_Click);
            // 
            // timerPingDb
            // 
            this.timerPingDb.Enabled = true;
            this.timerPingDb.Interval = 60000;
            this.timerPingDb.Tick += new System.EventHandler(this.timerPingDb_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.Location = new System.Drawing.Point(872, 2);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(132, 18);
            this.lblTimer.TabIndex = 3;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuSubjHour
            // 
            this.mnuSubjHour.Name = "mnuSubjHour";
            this.mnuSubjHour.Size = new System.Drawing.Size(201, 22);
            this.mnuSubjHour.Text = "По предметам и часам";
            this.mnuSubjHour.Click += new System.EventHandler(this.mnuSubjHour_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 567);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmMain";
            this.Text = "Сапфир";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuData;
        private System.Windows.Forms.ToolStripMenuItem mnuTest;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuScholar;
        private System.Windows.Forms.ToolStripMenuItem mnuTeacher;
        private System.Windows.Forms.ToolStripMenuItem mnuGroup;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCity;
        private System.Windows.Forms.ToolStripMenuItem mnuSubject;
        private System.Windows.Forms.ToolStripMenuItem mnuJournal;
        private System.Windows.Forms.ToolStripMenuItem mnuJournalGroup;
        private System.Windows.Forms.Timer timerPingDb;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ToolStripMenuItem mnuGroup1;
        private System.Windows.Forms.ToolStripMenuItem mnuBuhMain;
        private System.Windows.Forms.ToolStripMenuItem mnuBuhCardPrepod;
        private System.Windows.Forms.ToolStripMenuItem mnuBuhPayment;
        private System.Windows.Forms.ToolStripMenuItem mnuSubjHour;



    }
}

