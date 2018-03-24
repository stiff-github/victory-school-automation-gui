namespace victory
{
    partial class frmRptGroup1
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptGroup1));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.lookUpCityF = new DevExpress.XtraEditors.LookUpEdit();
            this.bindCityF = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataCityF = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpTeachers = new DevExpress.XtraEditors.LookUpEdit();
            this.bindTeacher = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataTeacher = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridGroup = new System.Windows.Forms.DataGridView();
            this.gridGroupScholar = new System.Windows.Forms.DataGridView();
            this.chkWorkEnd = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupScholar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpCityF
            // 
            this.lookUpCityF.Location = new System.Drawing.Point(142, 12);
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
            this.lookUpCityF.Properties.ValueMember = "city_id";
            this.lookUpCityF.Size = new System.Drawing.Size(138, 23);
            this.lookUpCityF.TabIndex = 68;
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
            customSqlQuery1.Name = "cityF";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataCityF.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataCityF.ResultSchemaSerializable = resources.GetString("sqlDataCityF.ResultSchemaSerializable");
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(124, 23);
            this.labelControl1.TabIndex = 67;
            this.labelControl1.Text = "Город (фильтр)";
            // 
            // lookUpTeachers
            // 
            this.lookUpTeachers.Location = new System.Drawing.Point(416, 12);
            this.lookUpTeachers.Name = "lookUpTeachers";
            this.lookUpTeachers.Properties.AutoHeight = false;
            this.lookUpTeachers.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpTeachers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpTeachers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 31, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city", "Город", 45, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "Код", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("fname", "Фамилия", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("lname", "Имя", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sname", "Отчество", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("phone", "Телефон", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpTeachers.Properties.DataSource = this.bindTeacher;
            this.lookUpTeachers.Properties.DisplayMember = "fname";
            this.lookUpTeachers.Properties.ValueMember = "id";
            this.lookUpTeachers.Size = new System.Drawing.Size(138, 23);
            this.lookUpTeachers.TabIndex = 70;
            this.lookUpTeachers.EditValueChanged += new System.EventHandler(this.lookUpTeachers_EditValueChanged);
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
            customSqlQuery2.Name = "teacher";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.sqlDataTeacher.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.sqlDataTeacher.ResultSchemaSerializable = resources.GetString("sqlDataTeacher.ResultSchemaSerializable");
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.Location = new System.Drawing.Point(286, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl3.Size = new System.Drawing.Size(124, 23);
            this.labelControl3.TabIndex = 69;
            this.labelControl3.Text = "Преподаватели";
            // 
            // gridGroup
            // 
            this.gridGroup.AllowUserToAddRows = false;
            this.gridGroup.AllowUserToDeleteRows = false;
            this.gridGroup.AllowUserToOrderColumns = true;
            this.gridGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroup.Location = new System.Drawing.Point(12, 41);
            this.gridGroup.MultiSelect = false;
            this.gridGroup.Name = "gridGroup";
            this.gridGroup.RowHeadersVisible = false;
            this.gridGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroup.Size = new System.Drawing.Size(692, 531);
            this.gridGroup.TabIndex = 214;
            this.gridGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGroup_CellClick);
            // 
            // gridGroupScholar
            // 
            this.gridGroupScholar.AllowUserToAddRows = false;
            this.gridGroupScholar.AllowUserToDeleteRows = false;
            this.gridGroupScholar.AllowUserToOrderColumns = true;
            this.gridGroupScholar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridGroupScholar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroupScholar.Location = new System.Drawing.Point(722, 41);
            this.gridGroupScholar.MultiSelect = false;
            this.gridGroupScholar.Name = "gridGroupScholar";
            this.gridGroupScholar.RowHeadersVisible = false;
            this.gridGroupScholar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroupScholar.Size = new System.Drawing.Size(355, 531);
            this.gridGroupScholar.TabIndex = 215;
            // 
            // chkWorkEnd
            // 
            this.chkWorkEnd.Location = new System.Drawing.Point(722, 10);
            this.chkWorkEnd.Name = "chkWorkEnd";
            this.chkWorkEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkWorkEnd.Properties.Appearance.Options.UseFont = true;
            this.chkWorkEnd.Properties.Caption = "закрытые группы";
            this.chkWorkEnd.Size = new System.Drawing.Size(170, 22);
            this.chkWorkEnd.TabIndex = 228;
            // 
            // frmRptGroup1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 586);
            this.Controls.Add(this.chkWorkEnd);
            this.Controls.Add(this.gridGroupScholar);
            this.Controls.Add(this.gridGroup);
            this.Controls.Add(this.lookUpTeachers);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lookUpCityF);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmRptGroup1";
            this.Text = "Актуальные группы";
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupScholar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpCityF;
        private System.Windows.Forms.BindingSource bindCityF;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataCityF;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpTeachers;
        private System.Windows.Forms.BindingSource bindTeacher;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataTeacher;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.DataGridView gridGroup;
        private System.Windows.Forms.DataGridView gridGroupScholar;
        private DevExpress.XtraEditors.CheckEdit chkWorkEnd;
    }
}