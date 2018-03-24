namespace victory
{
    partial class frmRptSubjHour
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery10 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSubjHour));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery11 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery12 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.chkWorkEnd = new DevExpress.XtraEditors.CheckEdit();
            this.gridGroup = new System.Windows.Forms.DataGridView();
            this.lookUpTeachers = new DevExpress.XtraEditors.LookUpEdit();
            this.bindTeacher = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataTeacher = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCityF = new DevExpress.XtraEditors.LookUpEdit();
            this.bindCityF = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataCityF = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkWork = new DevExpress.XtraEditors.CheckEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpSubject = new DevExpress.XtraEditors.LookUpEdit();
            this.bindSubject = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSubject = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkWorkEnd
            // 
            this.chkWorkEnd.EditValue = true;
            this.chkWorkEnd.Location = new System.Drawing.Point(416, 42);
            this.chkWorkEnd.Name = "chkWorkEnd";
            this.chkWorkEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkWorkEnd.Properties.Appearance.Options.UseFont = true;
            this.chkWorkEnd.Properties.Caption = "закрытые группы";
            this.chkWorkEnd.Size = new System.Drawing.Size(170, 22);
            this.chkWorkEnd.TabIndex = 234;
            this.chkWorkEnd.Visible = false;
            // 
            // gridGroup
            // 
            this.gridGroup.AllowUserToAddRows = false;
            this.gridGroup.AllowUserToDeleteRows = false;
            this.gridGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroup.Location = new System.Drawing.Point(12, 78);
            this.gridGroup.MultiSelect = false;
            this.gridGroup.Name = "gridGroup";
            this.gridGroup.ReadOnly = true;
            this.gridGroup.RowHeadersVisible = false;
            this.gridGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroup.Size = new System.Drawing.Size(816, 420);
            this.gridGroup.TabIndex = 233;
            // 
            // lookUpTeachers
            // 
            this.lookUpTeachers.Location = new System.Drawing.Point(690, 8);
            this.lookUpTeachers.Name = "lookUpTeachers";
            this.lookUpTeachers.Properties.AutoHeight = false;
            this.lookUpTeachers.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpTeachers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpTeachers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 31, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "Код", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city", "Город", 45, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("fname", "Фамилия", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("lname", "Имя", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sname", "Отчество", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("phone", "Телефон", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpTeachers.Properties.DataSource = this.bindTeacher;
            this.lookUpTeachers.Properties.DisplayMember = "fname";
            this.lookUpTeachers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpTeachers.Properties.ValueMember = "id";
            this.lookUpTeachers.Size = new System.Drawing.Size(138, 23);
            this.lookUpTeachers.TabIndex = 232;
            // 
            // bindTeacher
            // 
            this.bindTeacher.DataMember = "teacher";
            this.bindTeacher.DataSource = this.sqlDataTeacher;
            // 
            // sqlDataTeacher
            // 
            this.sqlDataTeacher.ConnectionName = "victory_appConnection";
            this.sqlDataTeacher.Name = "sqlDataTeacher";
            customSqlQuery10.Name = "teacher";
            customSqlQuery10.Sql = resources.GetString("customSqlQuery10.Sql");
            this.sqlDataTeacher.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery10});
            this.sqlDataTeacher.ResultSchemaSerializable = resources.GetString("sqlDataTeacher.ResultSchemaSerializable");
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.Location = new System.Drawing.Point(560, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl3.Size = new System.Drawing.Size(124, 23);
            this.labelControl3.TabIndex = 231;
            this.labelControl3.Text = "Преподаватели";
            // 
            // lookUpCityF
            // 
            this.lookUpCityF.Location = new System.Drawing.Point(142, 8);
            this.lookUpCityF.Name = "lookUpCityF";
            this.lookUpCityF.Properties.AutoHeight = false;
            this.lookUpCityF.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpCityF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCityF.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_id", "Код", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_name", "Город", 72, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_descr", "Примечание", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpCityF.Properties.DataSource = this.bindCityF;
            this.lookUpCityF.Properties.DisplayMember = "city_name";
            this.lookUpCityF.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpCityF.Properties.ValueMember = "city_id";
            this.lookUpCityF.Size = new System.Drawing.Size(138, 23);
            this.lookUpCityF.TabIndex = 230;
            this.lookUpCityF.EditValueChanged += new System.EventHandler(this.lookUpCityF_EditValueChanged);
            // 
            // bindCityF
            // 
            this.bindCityF.DataMember = "cityF";
            this.bindCityF.DataSource = this.sqlDataCityF;
            // 
            // sqlDataCityF
            // 
            this.sqlDataCityF.ConnectionName = "victory_appConnection";
            this.sqlDataCityF.Name = "sqlDataCityF";
            customSqlQuery11.Name = "cityF";
            customSqlQuery11.Sql = resources.GetString("customSqlQuery11.Sql");
            this.sqlDataCityF.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery11});
            this.sqlDataCityF.ResultSchemaSerializable = resources.GetString("sqlDataCityF.ResultSchemaSerializable");
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.Location = new System.Drawing.Point(12, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(124, 23);
            this.labelControl1.TabIndex = 229;
            this.labelControl1.Text = "Город (фильтр)";
            // 
            // chkWork
            // 
            this.chkWork.EditValue = true;
            this.chkWork.Location = new System.Drawing.Point(240, 42);
            this.chkWork.Name = "chkWork";
            this.chkWork.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkWork.Properties.Appearance.Options.UseFont = true;
            this.chkWork.Properties.Caption = "действующие группы";
            this.chkWork.Size = new System.Drawing.Size(170, 22);
            this.chkWork.TabIndex = 235;
            this.chkWork.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(722, 37);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 35);
            this.btnRefresh.TabIndex = 236;
            this.btnRefresh.Text = "Загрузить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 243;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 242;
            this.label1.Text = "с";
            // 
            // lookUpSubject
            // 
            this.lookUpSubject.Location = new System.Drawing.Point(416, 8);
            this.lookUpSubject.Name = "lookUpSubject";
            this.lookUpSubject.Properties.AutoHeight = false;
            this.lookUpSubject.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpSubject.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 31, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("subj_id", "Код", 44, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("subj_name", "Предмет", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("subj_descr", "Примечение", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True)});
            this.lookUpSubject.Properties.DataSource = this.bindSubject;
            this.lookUpSubject.Properties.DisplayMember = "subj_name";
            this.lookUpSubject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpSubject.Properties.ValueMember = "id";
            this.lookUpSubject.Size = new System.Drawing.Size(138, 23);
            this.lookUpSubject.TabIndex = 245;
            this.lookUpSubject.EditValueChanged += new System.EventHandler(this.lookUpSubject_EditValueChanged);
            // 
            // bindSubject
            // 
            this.bindSubject.DataMember = "subject";
            this.bindSubject.DataSource = this.sqlDataSubject;
            // 
            // sqlDataSubject
            // 
            this.sqlDataSubject.ConnectionName = "victory_appConnection";
            this.sqlDataSubject.Name = "sqlDataSubject";
            customSqlQuery12.Name = "subject";
            customSqlQuery12.Sql = resources.GetString("customSqlQuery12.Sql");
            this.sqlDataSubject.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery12});
            this.sqlDataSubject.ResultSchemaSerializable = resources.GetString("sqlDataSubject.ResultSchemaSerializable");
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl22.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl22.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl22.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl22.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl22.Location = new System.Drawing.Point(286, 8);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl22.Size = new System.Drawing.Size(124, 23);
            this.labelControl22.TabIndex = 244;
            this.labelControl22.Text = "Предмет";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = new System.DateTime(2016, 12, 20, 0, 0, 0, 0);
            this.dateEnd.Location = new System.Drawing.Point(141, 40);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.AutoHeight = false;
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this.dateEnd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEnd.Size = new System.Drawing.Size(80, 23);
            this.dateEnd.TabIndex = 265;
            // 
            // dateStart
            // 
            this.dateStart.EditValue = new System.DateTime(2016, 12, 20, 0, 0, 0, 0);
            this.dateStart.Location = new System.Drawing.Point(30, 40);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.AutoHeight = false;
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this.dateStart.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateStart.Size = new System.Drawing.Size(80, 23);
            this.dateStart.TabIndex = 264;
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(560, 37);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 35);
            this.btnPrint.TabIndex = 266;
            this.btnPrint.Text = "Распечатать";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmRptSubjHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 506);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.lookUpSubject);
            this.Controls.Add(this.labelControl22);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chkWork);
            this.Controls.Add(this.chkWorkEnd);
            this.Controls.Add(this.gridGroup);
            this.Controls.Add(this.lookUpTeachers);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lookUpCityF);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmRptSubjHour";
            this.Text = "Отчет по предметам и часам занятий";
            this.Load += new System.EventHandler(this.frmRptSubjHour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkWorkEnd;
        private System.Windows.Forms.DataGridView gridGroup;
        private DevExpress.XtraEditors.LookUpEdit lookUpTeachers;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpCityF;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkWork;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpSubject;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSubject;
        private System.Windows.Forms.BindingSource bindSubject;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataCityF;
        private System.Windows.Forms.BindingSource bindCityF;
        private System.Windows.Forms.BindingSource bindTeacher;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataTeacher;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}