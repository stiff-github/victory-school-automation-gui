namespace victory
{
    partial class frmJournal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournal));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.txtGroupDescr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSchedule = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.bindGroup = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataGroup = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridGroup = new System.Windows.Forms.DataGridView();
            this.lookUpTeachers = new DevExpress.XtraEditors.LookUpEdit();
            this.bindTeacher = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataTeacher = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpCityScholarF = new DevExpress.XtraEditors.LookUpEdit();
            this.bindCityF = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataCityF = new DevExpress.DataAccess.Sql.SqlDataSource();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.dateLesson = new DevExpress.XtraEditors.DateEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lblUpdateLesson = new DevExpress.XtraEditors.LabelControl();
            this.lblNew = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupDescr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityScholarF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLesson.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLesson.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGroupDescr
            // 
            this.txtGroupDescr.EditValue = "";
            this.txtGroupDescr.Location = new System.Drawing.Point(142, 497);
            this.txtGroupDescr.Name = "txtGroupDescr";
            this.txtGroupDescr.Properties.AutoHeight = false;
            this.txtGroupDescr.Properties.ReadOnly = true;
            this.txtGroupDescr.Size = new System.Drawing.Size(419, 23);
            this.txtGroupDescr.TabIndex = 219;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.Location = new System.Drawing.Point(12, 497);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl4.Size = new System.Drawing.Size(124, 23);
            this.labelControl4.TabIndex = 218;
            this.labelControl4.Text = "Примечание:";
            // 
            // txtSchedule
            // 
            this.txtSchedule.EditValue = "";
            this.txtSchedule.Location = new System.Drawing.Point(142, 468);
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Properties.AutoHeight = false;
            this.txtSchedule.Properties.ReadOnly = true;
            this.txtSchedule.Size = new System.Drawing.Size(419, 23);
            this.txtSchedule.TabIndex = 217;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.Location = new System.Drawing.Point(12, 468);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl3.Size = new System.Drawing.Size(124, 23);
            this.labelControl3.TabIndex = 216;
            this.labelControl3.Text = "Расписание:";
            // 
            // lookUpGroup
            // 
            this.lookUpGroup.Location = new System.Drawing.Point(142, 41);
            this.lookUpGroup.Name = "lookUpGroup";
            this.lookUpGroup.Properties.AutoHeight = false;
            this.lookUpGroup.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 31, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city", "city", 27, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_teacher", "code_teacher", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("subj_name", "subj_name", 62, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_group", "Номер группы", 67, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("schedule", "Расписание", 52, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("state", "Состояние", 35, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("descr", "Описание", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpGroup.Properties.DataSource = this.bindGroup;
            this.lookUpGroup.Properties.DisplayMember = "code_group";
            this.lookUpGroup.Properties.ValueMember = "id";
            this.lookUpGroup.Size = new System.Drawing.Size(138, 23);
            this.lookUpGroup.TabIndex = 215;
            this.lookUpGroup.EditValueChanged += new System.EventHandler(this.lookUpGroup_EditValueChanged);
            // 
            // bindGroup
            // 
            this.bindGroup.DataMember = "group";
            this.bindGroup.DataSource = this.sqlDataGroup;
            // 
            // sqlDataGroup
            // 
            this.sqlDataGroup.ConnectionName = "victory_appConnection";
            this.sqlDataGroup.Name = "sqlDataGroup";
            customSqlQuery1.Name = "group";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataGroup.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataGroup.ResultSchemaSerializable = resources.GetString("sqlDataGroup.ResultSchemaSerializable");
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.Location = new System.Drawing.Point(12, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(124, 23);
            this.labelControl1.TabIndex = 214;
            this.labelControl1.Text = "Список групп";
            // 
            // gridGroup
            // 
            this.gridGroup.AllowUserToAddRows = false;
            this.gridGroup.AllowUserToDeleteRows = false;
            this.gridGroup.AllowUserToOrderColumns = true;
            this.gridGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroup.Location = new System.Drawing.Point(12, 95);
            this.gridGroup.MultiSelect = false;
            this.gridGroup.Name = "gridGroup";
            this.gridGroup.RowHeadersVisible = false;
            this.gridGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroup.Size = new System.Drawing.Size(549, 366);
            this.gridGroup.TabIndex = 213;
            // 
            // lookUpTeachers
            // 
            this.lookUpTeachers.Location = new System.Drawing.Point(416, 11);
            this.lookUpTeachers.Name = "lookUpTeachers";
            this.lookUpTeachers.Properties.AutoHeight = false;
            this.lookUpTeachers.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpTeachers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpTeachers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 31, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city", "Город", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "Код", 33, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("fname", "Фамилия", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("lname", "Имя", 38, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sname", "Отчество", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("phone", "Телефон", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpTeachers.Properties.DataSource = this.bindTeacher;
            this.lookUpTeachers.Properties.DisplayMember = "fname";
            this.lookUpTeachers.Properties.ValueMember = "id";
            this.lookUpTeachers.Size = new System.Drawing.Size(145, 23);
            this.lookUpTeachers.TabIndex = 211;
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
            customSqlQuery2.Name = "teacher";
            customSqlQuery2.Sql = null;
            this.sqlDataTeacher.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.sqlDataTeacher.ResultSchemaSerializable = resources.GetString("sqlDataTeacher.ResultSchemaSerializable");
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl6.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl6.Location = new System.Drawing.Point(286, 11);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl6.Size = new System.Drawing.Size(124, 23);
            this.labelControl6.TabIndex = 210;
            this.labelControl6.Text = "Преподаватель";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(567, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 35);
            this.btnSave.TabIndex = 208;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lookUpCityScholarF
            // 
            this.lookUpCityScholarF.Location = new System.Drawing.Point(142, 12);
            this.lookUpCityScholarF.Name = "lookUpCityScholarF";
            this.lookUpCityScholarF.Properties.AutoHeight = false;
            this.lookUpCityScholarF.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpCityScholarF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCityScholarF.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_id", "Код", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_name", "Город", 72, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_descr", "Примечание", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpCityScholarF.Properties.DataSource = this.bindCityF;
            this.lookUpCityScholarF.Properties.DisplayMember = "city_name";
            this.lookUpCityScholarF.Properties.ValueMember = "city_id";
            this.lookUpCityScholarF.Size = new System.Drawing.Size(138, 23);
            this.lookUpCityScholarF.TabIndex = 207;
            this.lookUpCityScholarF.EditValueChanged += new System.EventHandler(this.lookUpCityScholarF_EditValueChanged);
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
            customSqlQuery3.Name = "cityF";
            customSqlQuery3.Sql = "select ifnull (`city`.`city_name`, \' \') as `city_name`,\r\n       ifnull (`city`.`c" +
    "ity_descr`, \' \') as `city_descr`,\r\n       ifnull (`city`.`city_id`, \' \') as `cit" +
    "y_id`\r\n  from `city` `city`";
            this.sqlDataCityF.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery3});
            this.sqlDataCityF.ResultSchemaSerializable = resources.GetString("sqlDataCityF.ResultSchemaSerializable");
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl23.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl23.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl23.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl23.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl23.Location = new System.Drawing.Point(12, 12);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl23.Size = new System.Drawing.Size(124, 23);
            this.labelControl23.TabIndex = 206;
            this.labelControl23.Text = "Город (фильтр)";
            // 
            // dateLesson
            // 
            this.dateLesson.EditValue = new System.DateTime(2017, 2, 2, 0, 0, 0, 0);
            this.dateLesson.Location = new System.Drawing.Point(416, 42);
            this.dateLesson.Name = "dateLesson";
            this.dateLesson.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLesson.Properties.Appearance.Options.UseFont = true;
            this.dateLesson.Properties.AutoHeight = false;
            this.dateLesson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateLesson.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateLesson.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd.mm.yyyy";
            this.dateLesson.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateLesson.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd.mm.yyyy";
            this.dateLesson.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateLesson.Properties.CalendarTimeProperties.Mask.EditMask = "dd.mm.yyyy";
            this.dateLesson.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this.dateLesson.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateLesson.Size = new System.Drawing.Size(145, 35);
            this.dateLesson.TabIndex = 220;
            this.dateLesson.EditValueChanged += new System.EventHandler(this.lookUpGroup_EditValueChanged);
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl15.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl15.Location = new System.Drawing.Point(286, 41);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelControl15.Size = new System.Drawing.Size(124, 23);
            this.labelControl15.TabIndex = 221;
            this.labelControl15.Text = "Дата занятия:";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(567, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 35);
            this.btnDelete.TabIndex = 222;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblUpdateLesson
            // 
            this.lblUpdateLesson.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUpdateLesson.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblUpdateLesson.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUpdateLesson.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUpdateLesson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblUpdateLesson.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblUpdateLesson.Location = new System.Drawing.Point(12, 70);
            this.lblUpdateLesson.Name = "lblUpdateLesson";
            this.lblUpdateLesson.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblUpdateLesson.Size = new System.Drawing.Size(398, 23);
            this.lblUpdateLesson.TabIndex = 223;
            this.lblUpdateLesson.Text = "На эту дату журнал ещё не заводился";
            this.lblUpdateLesson.Visible = false;
            // 
            // lblNew
            // 
            this.lblNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNew.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNew.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNew.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblNew.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblNew.Location = new System.Drawing.Point(567, 157);
            this.lblNew.Name = "lblNew";
            this.lblNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblNew.Size = new System.Drawing.Size(28, 23);
            this.lblNew.TabIndex = 224;
            this.lblNew.Text = "1";
            this.lblNew.Visible = false;
            // 
            // frmJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 530);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lblUpdateLesson);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.dateLesson);
            this.Controls.Add(this.txtGroupDescr);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lookUpGroup);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridGroup);
            this.Controls.Add(this.lookUpTeachers);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lookUpCityScholarF);
            this.Controls.Add(this.labelControl23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmJournal";
            this.Text = "Журнал посещений";
            this.Load += new System.EventHandler(this.frmJournal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupDescr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTeachers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCityScholarF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCityF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLesson.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLesson.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtGroupDescr;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSchedule;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpGroup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DataGridView gridGroup;
        private DevExpress.XtraEditors.LookUpEdit lookUpTeachers;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit lookUpCityScholarF;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private System.Windows.Forms.BindingSource bindGroup;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataGroup;
        private System.Windows.Forms.BindingSource bindTeacher;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataTeacher;
        private System.Windows.Forms.BindingSource bindCityF;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataCityF;
        private DevExpress.XtraEditors.DateEdit dateLesson;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.LabelControl lblUpdateLesson;
        private DevExpress.XtraEditors.LabelControl lblNew;
    }
}