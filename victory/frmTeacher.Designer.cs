namespace victory
{
    partial class frmTeacher
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery7 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeacher));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery8 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery9 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.dateBirth = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtTel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtSName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtLName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtFName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpTeachers = new DevExpress.XtraEditors.LookUpEdit();
            this.bindTeacher = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataTeacher = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.lookUpCityF = new DevExpress.XtraEditors.LookUpEdit();
            this.bindCityF = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataCityF = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.lblCityF = new DevExpress.XtraEditors.LabelControl();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAdres = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescr = new DevExpress.XtraEditors.TextEdit();
            this.txtSal1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.listLesson = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.txtTimeSubject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.lookUpCity = new DevExpress.XtraEditors.LookUpEdit();
            this.bindCity = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataCity = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtMail = new DevExpress.XtraEditors.TextEdit();
            this.lblCity = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveTime = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaska = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSal1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listLesson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaska.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateBirth
            // 
            this.dateBirth.EditValue = new System.DateTime(2017, 2, 2, 0, 0, 0, 0);
            this.dateBirth.Location = new System.Drawing.Point(142, 208);
            this.dateBirth.Name = "dateBirth";
            this.dateBirth.Properties.AutoHeight = false;
            this.dateBirth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd.mm.yyyy";
            this.dateBirth.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBirth.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd.mm.yyyy";
            this.dateBirth.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBirth.Properties.CalendarTimeProperties.Mask.EditMask = "dd.mm.yyyy";
            this.dateBirth.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this.dateBirth.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateBirth.Size = new System.Drawing.Size(83, 23);
            this.dateBirth.TabIndex = 62;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl9.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl9.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl9.Location = new System.Drawing.Point(12, 265);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl9.Size = new System.Drawing.Size(124, 23);
            this.labelControl9.TabIndex = 60;
            this.labelControl9.Text = "Телефон";
            // 
            // txtTel
            // 
            this.txtTel.EditValue = "";
            this.txtTel.Location = new System.Drawing.Point(142, 265);
            this.txtTel.Name = "txtTel";
            this.txtTel.Properties.AutoHeight = false;
            this.txtTel.Size = new System.Drawing.Size(172, 23);
            this.txtTel.TabIndex = 9;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl15.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl15.Location = new System.Drawing.Point(12, 207);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl15.Size = new System.Drawing.Size(124, 23);
            this.labelControl15.TabIndex = 59;
            this.labelControl15.Text = "Дата рождения";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl16.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl16.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl16.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl16.Location = new System.Drawing.Point(12, 149);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl16.Size = new System.Drawing.Size(124, 23);
            this.labelControl16.TabIndex = 57;
            this.labelControl16.Text = "Отчество";
            // 
            // txtSName
            // 
            this.txtSName.EditValue = "";
            this.txtSName.Location = new System.Drawing.Point(142, 149);
            this.txtSName.Name = "txtSName";
            this.txtSName.Properties.AutoHeight = false;
            this.txtSName.Size = new System.Drawing.Size(138, 23);
            this.txtSName.TabIndex = 7;
            this.txtSName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSName_KeyPress);
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl17.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl17.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl17.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl17.Location = new System.Drawing.Point(12, 120);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl17.Size = new System.Drawing.Size(124, 23);
            this.labelControl17.TabIndex = 55;
            this.labelControl17.Text = "Имя";
            // 
            // txtLName
            // 
            this.txtLName.EditValue = "";
            this.txtLName.Location = new System.Drawing.Point(142, 119);
            this.txtLName.Name = "txtLName";
            this.txtLName.Properties.AutoHeight = false;
            this.txtLName.Size = new System.Drawing.Size(138, 23);
            this.txtLName.TabIndex = 6;
            this.txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLName_KeyPress);
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl18.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl18.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl18.Location = new System.Drawing.Point(12, 91);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl18.Size = new System.Drawing.Size(124, 23);
            this.labelControl18.TabIndex = 53;
            this.labelControl18.Text = "Фамилия";
            // 
            // txtFName
            // 
            this.txtFName.EditValue = "";
            this.txtFName.Location = new System.Drawing.Point(142, 91);
            this.txtFName.Name = "txtFName";
            this.txtFName.Properties.AutoHeight = false;
            this.txtFName.Size = new System.Drawing.Size(138, 23);
            this.txtFName.TabIndex = 5;
            this.txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFName_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.Location = new System.Drawing.Point(12, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(608, 31);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "Карточка преподавателя";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.Location = new System.Drawing.Point(12, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(124, 23);
            this.labelControl1.TabIndex = 63;
            this.labelControl1.Text = "Город (фильтр)";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.Location = new System.Drawing.Point(12, 62);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl3.Size = new System.Drawing.Size(124, 23);
            this.labelControl3.TabIndex = 64;
            this.labelControl3.Text = "Список";
            // 
            // lookUpTeachers
            // 
            this.lookUpTeachers.Location = new System.Drawing.Point(142, 62);
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
            this.lookUpTeachers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpTeachers.Properties.ValueMember = "id";
            this.lookUpTeachers.Size = new System.Drawing.Size(138, 23);
            this.lookUpTeachers.TabIndex = 65;
            this.lookUpTeachers.EditValueChanged += new System.EventHandler(this.lookUpTeachers_EditValueChanged);
            // 
            // bindTeacher
            // 
            this.bindTeacher.DataSource = this.sqlDataTeacher;
            this.bindTeacher.Position = 0;
            // 
            // sqlDataTeacher
            // 
            this.sqlDataTeacher.ConnectionName = "victory_appConnection";
            this.sqlDataTeacher.Name = "sqlDataTeacher";
            customSqlQuery7.Name = "teacher";
            customSqlQuery7.Sql = resources.GetString("customSqlQuery7.Sql");
            this.sqlDataTeacher.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery7});
            this.sqlDataTeacher.ResultSchemaSerializable = resources.GetString("sqlDataTeacher.ResultSchemaSerializable");
            // 
            // lookUpCityF
            // 
            this.lookUpCityF.Location = new System.Drawing.Point(142, 33);
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
            this.lookUpCityF.TabIndex = 66;
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
            customSqlQuery8.Name = "cityF";
            customSqlQuery8.Sql = resources.GetString("customSqlQuery8.Sql");
            this.sqlDataCityF.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery8});
            this.sqlDataCityF.ResultSchemaSerializable = resources.GetString("sqlDataCityF.ResultSchemaSerializable");
            // 
            // lblCityF
            // 
            this.lblCityF.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCityF.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCityF.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblCityF.Location = new System.Drawing.Point(287, 33);
            this.lblCityF.Name = "lblCityF";
            this.lblCityF.Size = new System.Drawing.Size(21, 23);
            this.lblCityF.TabIndex = 67;
            this.lblCityF.Text = "00";
            this.lblCityF.Visible = false;
            // 
            // lblId
            // 
            this.lblId.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblId.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblId.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblId.Location = new System.Drawing.Point(287, 61);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 23);
            this.lblId.TabIndex = 68;
            this.lblId.Text = "00";
            this.lblId.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.Location = new System.Drawing.Point(12, 323);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl4.Size = new System.Drawing.Size(124, 23);
            this.labelControl4.TabIndex = 69;
            this.labelControl4.Text = "Адрес";
            // 
            // txtAdres
            // 
            this.txtAdres.EditValue = "";
            this.txtAdres.Location = new System.Drawing.Point(142, 323);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Properties.AutoHeight = false;
            this.txtAdres.Size = new System.Drawing.Size(481, 23);
            this.txtAdres.TabIndex = 11;
            this.txtAdres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdres_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl5.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl5.Location = new System.Drawing.Point(12, 352);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl5.Size = new System.Drawing.Size(124, 23);
            this.labelControl5.TabIndex = 71;
            this.labelControl5.Text = "Примечание";
            // 
            // txtDescr
            // 
            this.txtDescr.EditValue = "";
            this.txtDescr.Location = new System.Drawing.Point(142, 352);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Properties.AutoHeight = false;
            this.txtDescr.Size = new System.Drawing.Size(481, 23);
            this.txtDescr.TabIndex = 12;
            // 
            // txtSal1
            // 
            this.txtSal1.EditValue = "0";
            this.txtSal1.Enabled = false;
            this.txtSal1.Location = new System.Drawing.Point(580, 382);
            this.txtSal1.Name = "txtSal1";
            this.txtSal1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSal1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSal1.Properties.AutoHeight = false;
            this.txtSal1.Size = new System.Drawing.Size(43, 23);
            this.txtSal1.TabIndex = 74;
            this.txtSal1.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl6.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl6.Location = new System.Drawing.Point(320, 33);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl6.Size = new System.Drawing.Size(138, 23);
            this.labelControl6.TabIndex = 75;
            this.labelControl6.Text = "Список предметов:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl7.Enabled = false;
            this.labelControl7.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl7.Location = new System.Drawing.Point(450, 382);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl7.Size = new System.Drawing.Size(124, 23);
            this.labelControl7.TabIndex = 82;
            this.labelControl7.Text = "Оплата";
            this.labelControl7.Visible = false;
            // 
            // listLesson
            // 
            this.listLesson.Location = new System.Drawing.Point(320, 62);
            this.listLesson.Name = "listLesson";
            this.listLesson.Size = new System.Drawing.Size(303, 196);
            this.listLesson.TabIndex = 83;
            this.listLesson.Click += new System.EventHandler(this.listLesson_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(12, 426);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 35);
            this.btnDelete.TabIndex = 85;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(512, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 35);
            this.btnSave.TabIndex = 84;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(512, 21);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(111, 35);
            this.btnNew.TabIndex = 86;
            this.btnNew.Text = "Создать";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtTimeSubject
            // 
            this.txtTimeSubject.EditValue = "";
            this.txtTimeSubject.Location = new System.Drawing.Point(320, 293);
            this.txtTimeSubject.Name = "txtTimeSubject";
            this.txtTimeSubject.Properties.AutoHeight = false;
            this.txtTimeSubject.Size = new System.Drawing.Size(303, 23);
            this.txtTimeSubject.TabIndex = 87;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl8.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl8.Location = new System.Drawing.Point(320, 264);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl8.Size = new System.Drawing.Size(200, 23);
            this.labelControl8.TabIndex = 88;
            this.labelControl8.Text = "Возможное время:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl10.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl10.Location = new System.Drawing.Point(12, 178);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl10.Size = new System.Drawing.Size(124, 23);
            this.labelControl10.TabIndex = 117;
            this.labelControl10.Text = "Код";
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "0";
            this.txtCode.Location = new System.Drawing.Point(142, 178);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCode.Properties.AutoHeight = false;
            this.txtCode.Size = new System.Drawing.Size(36, 23);
            this.txtCode.TabIndex = 8;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // lookUpCity
            // 
            this.lookUpCity.Location = new System.Drawing.Point(142, 236);
            this.lookUpCity.Name = "lookUpCity";
            this.lookUpCity.Properties.AutoHeight = false;
            this.lookUpCity.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCity.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_id", "Код", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_name", "Город", 72, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_descr", "Примечание", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpCity.Properties.DataSource = this.bindCity;
            this.lookUpCity.Properties.DisplayMember = "city_name";
            this.lookUpCity.Properties.ValueMember = "city_id";
            this.lookUpCity.Size = new System.Drawing.Size(138, 23);
            this.lookUpCity.TabIndex = 119;
            this.lookUpCity.EditValueChanged += new System.EventHandler(this.lookUpCity_EditValueChanged);
            // 
            // bindCity
            // 
            this.bindCity.DataMember = "city";
            this.bindCity.DataSource = this.sqlDataCity;
            // 
            // sqlDataCity
            // 
            this.sqlDataCity.ConnectionName = "victory_appConnection";
            this.sqlDataCity.Name = "sqlDataCity";
            customSqlQuery9.Name = "city";
            customSqlQuery9.Sql = "select ifnull (`city`.`city_name`, \' \') as `city_name`,\r\n       ifnull (`city`.`c" +
    "ity_descr`, \' \') as `city_descr`,\r\n       ifnull (`city`.`city_id`, \' \') as `cit" +
    "y_id`\r\n  from `city` `city`";
            this.sqlDataCity.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery9});
            this.sqlDataCity.ResultSchemaSerializable = resources.GetString("sqlDataCity.ResultSchemaSerializable");
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl11.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl11.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl11.Location = new System.Drawing.Point(12, 236);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl11.Size = new System.Drawing.Size(124, 23);
            this.labelControl11.TabIndex = 118;
            this.labelControl11.Text = "Город";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl12.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl12.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl12.Location = new System.Drawing.Point(12, 294);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl12.Size = new System.Drawing.Size(124, 23);
            this.labelControl12.TabIndex = 120;
            this.labelControl12.Text = "e-mail";
            // 
            // txtMail
            // 
            this.txtMail.EditValue = "";
            this.txtMail.Location = new System.Drawing.Point(142, 294);
            this.txtMail.Name = "txtMail";
            this.txtMail.Properties.AutoHeight = false;
            this.txtMail.Size = new System.Drawing.Size(172, 23);
            this.txtMail.TabIndex = 10;
            this.txtMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMail_KeyPress);
            // 
            // lblCity
            // 
            this.lblCity.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCity.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCity.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblCity.Location = new System.Drawing.Point(286, 236);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(21, 23);
            this.lblCity.TabIndex = 122;
            this.lblCity.Text = "00";
            this.lblCity.Visible = false;
            // 
            // btnSaveTime
            // 
            this.btnSaveTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveTime.Appearance.Options.UseFont = true;
            this.btnSaveTime.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSaveTime.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveTime.Image")));
            this.btnSaveTime.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSaveTime.Location = new System.Drawing.Point(526, 264);
            this.btnSaveTime.Name = "btnSaveTime";
            this.btnSaveTime.Size = new System.Drawing.Size(97, 24);
            this.btnSaveTime.TabIndex = 124;
            this.btnSaveTime.Text = "установить";
            this.btnSaveTime.Click += new System.EventHandler(this.btnSaveTime_Click);
            // 
            // txtMaska
            // 
            this.txtMaska.EditValue = "";
            this.txtMaska.Location = new System.Drawing.Point(142, 381);
            this.txtMaska.Name = "txtMaska";
            this.txtMaska.Properties.AutoHeight = false;
            this.txtMaska.Size = new System.Drawing.Size(172, 23);
            this.txtMaska.TabIndex = 125;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl13.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl13.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl13.Location = new System.Drawing.Point(12, 382);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl13.Size = new System.Drawing.Size(124, 23);
            this.labelControl13.TabIndex = 126;
            this.labelControl13.Text = "Пароль журнала";
            // 
            // frmTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 469);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.txtMaska);
            this.Controls.Add(this.btnSaveTime);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lookUpCity);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtTimeSubject);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listLesson);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtSal1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblCityF);
            this.Controls.Add(this.lookUpCityF);
            this.Controls.Add(this.lookUpTeachers);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateBirth);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.txtSName);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.labelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Учебные данные преподавателя";
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSal1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listLesson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaska.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateBirth;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtTel;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit txtSName;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit txtLName;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtFName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpTeachers;
        private DevExpress.XtraEditors.LookUpEdit lookUpCityF;
        private DevExpress.XtraEditors.LabelControl lblCityF;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtAdres;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtDescr;
        private DevExpress.XtraEditors.TextEdit txtSal1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CheckedListBoxControl listLesson;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.TextEdit txtTimeSubject;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpCity;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtMail;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataCityF;
        private System.Windows.Forms.BindingSource bindCityF;
        private System.Windows.Forms.BindingSource bindCity;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataCity;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataTeacher;
        private System.Windows.Forms.BindingSource bindTeacher;
        private DevExpress.XtraEditors.LabelControl lblCity;
        private DevExpress.XtraEditors.SimpleButton btnSaveTime;
        private DevExpress.XtraEditors.TextEdit txtMaska;
        private DevExpress.XtraEditors.LabelControl labelControl13;
    }
}