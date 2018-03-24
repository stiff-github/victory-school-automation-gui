using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data;
using MySql.Data.MySqlClient;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace victory
{
    public partial class frmGroup : DevExpress.XtraEditors.XtraForm
    {
        public frmGroup()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
            sqlDataSubject.Fill();
        }
        private void grid_scholar_load()
        {
            //-----grid scholar
            this.gridScholar.Rows.Clear();
            this.gridScholar.Columns.Clear();
            gridScholar.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "Код";
            col0.Name = "code";
            col0.ReadOnly = true;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Фамилия";
            col1.Name = "fname";
            col1.ReadOnly = true;
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Имя";
            col2.Name = "lname";
            col2.ReadOnly = true;
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "ДР";
            col3.Name = "date_birth";
            col3.ReadOnly = true;
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Время";
            col4.Name = "time";
            col4.ReadOnly = true;
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "id";
            col5.Name = "id";
            col5.ReadOnly = true;
            col5.Visible = false;
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Примечание";
            col6.Name = "descr";
            col6.ReadOnly = true;

            this.gridScholar.Columns.Add(col0);
            this.gridScholar.Columns.Add(col1);
            this.gridScholar.Columns.Add(col2);
            this.gridScholar.Columns.Add(col3);
            this.gridScholar.Columns.Add(col4);
            this.gridScholar.Columns.Add(col5);
            this.gridScholar.Columns.Add(col6);

            int type_sh;
            if (radioRezerv.Checked)
            {
                type_sh = 0;
            }
            else
            {
                type_sh = 1;
            }
            string schedule;
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "select s.code,s.fname,ifnull(s.lname,' ') as lname,ifnull(DATE_FORMAT(s.date_birth,'%d.%m.%Y'),' ') as date_birth"
                                    + ", s.id, ss.time_work_week,ss.time_saturday,ss.time_sunday,ss.time_0812,ss.time_1215"
                                    + ",ss.time_1517,ss.time_1721,ifnull(s.descr,' ') as descr"
                                    + " from scholar s, scholar_subj ss where s.id_master=ss.id_master and s.code=ss.code and ss.status=0 and"
                                    + " ss.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                    + " and ss.type=" + type_sh + " and s.city_id='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "' order by s.code";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //lstScholarNeed.Items.Add(reader.GetString(0));
                        DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel6 = new DataGridViewTextBoxCell();

                        DataGridViewRow row = new DataGridViewRow();
                        //cel0.Style.BackColor = Color.LightGray;
                        cel0.Value = (string)reader.GetString(0);
                        cel1.Value = (string)reader.GetString(1);
                        cel2.Value = (string)reader.GetString(2);
                        cel3.Value = (string)reader.GetString(3);
                        cel5.Value = (int)reader.GetDecimal(4);
                        schedule = "";
                        if (reader.GetDecimal(5) == 1)
                        {
                            schedule = "раб. нед.";
                        }
                        if (reader.GetDecimal(6) == 1)
                        {
                            schedule = schedule + " суб.";
                        }
                        if (reader.GetDecimal(7) == 1)
                        {
                            schedule = schedule + " воскр.";
                        }
                        if (reader.GetDecimal(8) == 1)
                        {
                            schedule = schedule + " 08-12";
                        }
                        if (reader.GetDecimal(9) == 1)
                        {
                            schedule = schedule + " 12-15";
                        }
                        if (reader.GetDecimal(10) == 1)
                        {
                            schedule = schedule + " 15-17";
                        }
                        if (reader.GetDecimal(11) == 1)
                        {
                            schedule = schedule + " 17-21";
                        }
                        cel4.Value = schedule;
                        cel6.Value = (string)reader.GetString(12);
                        row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                        this.gridScholar.Rows.Add(row);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }
        private void grid_group_load()
        {
            this.gridGroup.Rows.Clear();
            this.gridGroup.Columns.Clear();
            gridGroup.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "Код";
            col0.Name = "scholar_code";
            col0.ReadOnly = true;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Фамилия";
            col1.Name = "scholar_fname";
            col1.ReadOnly = true;
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Имя";
            col2.Name = "scholar_lname";
            col2.ReadOnly = true;
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "ДР";
            col3.Name = "scholar_datebirth";
            col3.ReadOnly = true;
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "scholar_id";
            col4.Name = "scholar_id";
            col4.ReadOnly = true;
            col4.Visible = false;
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "id";
            col5.Name = "id";
            col5.ReadOnly = true;
            col5.Visible = false;
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Примечание";
            col6.Name = "descr";
            col6.ReadOnly = true;

            this.gridGroup.Columns.Add(col0);
            this.gridGroup.Columns.Add(col1);
            this.gridGroup.Columns.Add(col2);
            this.gridGroup.Columns.Add(col3);
            this.gridGroup.Columns.Add(col4);
            this.gridGroup.Columns.Add(col5);
            this.gridGroup.Columns.Add(col6);

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "select s.code,s.fname,ifnull(s.lname,' ') as lname,ifnull(DATE_FORMAT(s.date_birth,'%d.%m.%Y'),' ') as date_birth"
                                    + ",gs.scholar_id,gs.id,ifnull(s.descr,' ') as descr from group_scholar gs, scholar s where gs.scholar_id=s.id and"
                                    + " gs.code_group='" + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "'"
                                    + " order by s.fname,s.lname";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel6 = new DataGridViewTextBoxCell();
                        DataGridViewRow row = new DataGridViewRow();
                        cel0.Value = (string)reader.GetString(0);
                        cel1.Value = (string)reader.GetString(1);
                        cel2.Value = (string)reader.GetString(2);
                        cel3.Value = (string)reader.GetString(3);
                        cel4.Value = (int)reader.GetDecimal(4);
                        cel5.Value = (int)reader.GetDecimal(5);
                        cel6.Value = (string)reader.GetString(6);
                        row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                        this.gridGroup.Rows.Add(row);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }
        private void lookUpCityScholarF_EditValueChanged(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (lookUpSubject.ItemIndex > -1)
            {
                CustomSqlQuery query2 = new CustomSqlQuery();
                query2.Name = "customQuery1";
                query2.Sql = "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                            + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t, teacher_subj ts"
                            + " where t.city_id=ts.city and t.code=ts.code and ts.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                            + " and t.city_id='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "' order by fname,lname";
                sqlDataTeacher.Queries.Clear();
                sqlDataTeacher.Queries.Add(query2);
                sqlDataTeacher.Fill();
                bindTeacher.DataSource = sqlDataTeacher;
                bindTeacher.DataMember = "customQuery1";
                lookUpTeachers.Properties.DataSource = bindTeacher;
                //lookUpTeachers.ItemIndex = 0;
            }
            if ((lookUpTeachers.ItemIndex > -1) && (lookUpSubject.ItemIndex > -1) && (lookUpCityScholarF.ItemIndex > -1))
            {
                txtCreateGroup.Text = lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim();
                btnCreateGroup.Enabled = true;
            }
        }

        private void lookUpSubject_EditValueChanged(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            lookUpTeachers.EditValue = null;
            lookUpGroup.EditValue = null;
            lookUpGroup.Properties.DataSource = null; 
            this.gridGroup.Rows.Clear();
            txtCreateGroup.Text = "";
            txtTeacherSchedule.Text = "";
            txtSchedule.Text = "";
            txtGroupDescr.Text = "";
            chkWork.Checked = false;
            chkWorkEnd.Checked = false;

            //for change teacher
            lookUpTeachersChange.EditValue = null;
            lookUpGroupChange.EditValue = null;
            lookUpGroupChange.Properties.DataSource = null;
            txtCreateGroupChange.Text = "";

            if (lookUpCityScholarF.ItemIndex > -1)
            {
                CustomSqlQuery query2 = new CustomSqlQuery();
                query2.Name = "customQuery2";
                query2.Sql = "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                            + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t, teacher_subj ts"
                            + " where t.city_id=ts.city and t.code=ts.code and ts.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                            + " and t.city_id='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "' order by fname,lname";
                sqlDataTeacher.Queries.Clear();
                sqlDataTeacher.Queries.Add(query2);
                sqlDataTeacher.Fill();
                bindTeacher.DataSource = sqlDataTeacher;
                bindTeacher.DataMember = "customQuery2";
                lookUpTeachers.Properties.DataSource = bindTeacher;
                lookUpTeachersChange.Properties.DataSource = bindTeacher;

                grid_scholar_load();
            }
            if ((lookUpTeachers.ItemIndex > -1) && (lookUpSubject.ItemIndex > -1) && (lookUpCityScholarF.ItemIndex > -1))
            {
                txtCreateGroup.Text = lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim();
                btnCreateGroup.Enabled = true;
            }
        }

        private void lookUpTeachers_EditValueChanged(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (lookUpTeachers.ItemIndex > -1)
            {
                CustomSqlQuery query3 = new CustomSqlQuery();
                query3.Name = "customQuery1";
                query3.Sql = "select id,city,code_teacher,subj_name,code_group,ifnull(descr,' ') as descr,ifnull(schedule,' ') as schedule,state from group_list"
                            + " where subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                            + " and city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "'"
                            + " and code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "' order by code_group";
                sqlDataGroup.Queries.Clear();
                sqlDataGroup.Queries.Add(query3);
                sqlDataGroup.Fill();
                bindGroup.DataSource = sqlDataGroup;
                bindGroup.DataMember = "customQuery1";
                lookUpGroup.Properties.DataSource = bindGroup;
                //lookUpTeachers.ItemIndex = 0;

                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "select ifnull(time,' ') as time from teacher_subj"
                            + " where city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "'"
                            + " and code='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'"
                            + " and subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtTeacherSchedule.Text = reader.GetString(0);
                            }
                        }
                        else
                        {
                            txtTeacherSchedule.Text = "";
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
            if ((lookUpTeachers.ItemIndex > -1)&&(lookUpSubject.ItemIndex > -1)&&(lookUpCityScholarF.ItemIndex > -1))
            {
                txtCreateGroup.Text = lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim();
                btnCreateGroup.Enabled = true;
            }
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (txtCreateGroup.Text.Trim().Length > 7)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "SELECT count(*) FROM group_list where code_group='" + txtCreateGroup.Text.Trim() + "'";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            if (Convert.ToInt32(result) == 0)
                            {
                                try
                                {
                                    query = "insert into group_list (city,code_teacher,subj_name,code_group,descr,schedule,state) values ('"
                                            + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "','"
                                            + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "','"
                                            + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "','" + txtCreateGroup.Text.Trim()
                                            + "','" + txtGroupDescr.Text.Trim() + "','" + txtSchedule.Text.Trim() + "',0)";
                                    cmd = new MySqlCommand(query, dbCon.Connection);
                                    cmd.ExecuteNonQuery();
                                    chkWork.Checked = false;
                                }
                                catch (Exception ex)
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                }
                                CustomSqlQuery query3 = new CustomSqlQuery();
                                query3.Name = "customQuery1";
                                query3.Sql = "select id,city,code_teacher,subj_name,code_group,ifnull(descr,' ') as descr,ifnull(schedule,' ') as schedule,state from group_list"
                                            + " where subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                            + " and city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "'"
                                            + " and code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "' order by code_group";
                                sqlDataGroup.Queries.Clear();
                                sqlDataGroup.Queries.Add(query3);
                                sqlDataGroup.Fill();
                                bindGroup.DataSource = sqlDataGroup;
                                bindGroup.DataMember = "customQuery1";
                                lookUpGroup.Properties.DataSource = bindGroup;
                                //lookUpGroup.EditValue = txtCreateGroup.Text;
                                txtCreateGroup.Text = txtCreateGroup.Text.Substring(0,6);
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Группа с таким кодом уже существует..");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Код группы не корректен..");
            }
        }

        private void lookUpGroup_EditValueChanged(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (lookUpGroup.ItemIndex > -1)
            {
                txtSchedule.Text = lookUpGroup.Properties.GetDataSourceValue("schedule", lookUpGroup.ItemIndex).ToString().Trim();
                txtGroupDescr.Text = lookUpGroup.Properties.GetDataSourceValue("descr", lookUpGroup.ItemIndex).ToString().Trim();
                switch (Convert.ToInt32(lookUpGroup.Properties.GetDataSourceValue("state", lookUpGroup.ItemIndex)))
                {
                    case 0: 
                        {
                            chkWork.Checked = false;
                            chkWorkEnd.Checked = false;
                            break;
                        }
                    case 1:
                        {
                            chkWork.Checked = true;
                            chkWorkEnd.Checked = false;
                            break;
                        }
                    case 2:
                        {
                            chkWork.Checked = false;
                            chkWorkEnd.Checked = true;
                            break;
                        }
                }
                //chkWork.Checked = Convert.ToBoolean(lookUpGroup.Properties.GetDataSourceValue("state", lookUpGroup.ItemIndex));
                grid_group_load();

                /*this.gridGroup.Rows.Clear();
                this.gridGroup.Columns.Clear();
                gridGroup.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                col0.HeaderText = "Код";
                col0.Name = "scholar_code";
                col0.ReadOnly = true;
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "Фамилия";
                col1.Name = "scholar_fname";
                col1.ReadOnly = true;
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Имя";
                col2.Name = "scholar_lname";
                col2.ReadOnly = true;
                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "ДР";
                col3.Name = "scholar_datebirth";
                col3.ReadOnly = true;
                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "scholar_id";
                col4.Name = "scholar_id";
                col4.ReadOnly = true;
                col4.Visible = false;
                DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                col5.HeaderText = "id";
                col5.Name = "id";
                col5.ReadOnly = true;
                col5.Visible = false;
                DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
                col6.HeaderText = "Примечание";
                col6.Name = "descr";
                col6.ReadOnly = true;

                this.gridGroup.Columns.Add(col0);
                this.gridGroup.Columns.Add(col1);
                this.gridGroup.Columns.Add(col2);
                this.gridGroup.Columns.Add(col3);
                this.gridGroup.Columns.Add(col4);
                this.gridGroup.Columns.Add(col5);
                this.gridGroup.Columns.Add(col6);

                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "select gs.scholar_code,gs.scholar_fname,ifnull(gs.scholar_lname,' ') as scholar_lname,ifnull(DATE_FORMAT(gs.scholar_datebirth,'%d.%m.%Y'),' ') as scholar_datebirth"
                                        + ",gs.scholar_id,gs.id,ifnull(s.descr,' ') as descr from group_scholar gs, scholar s where gs.scholar_id=s.id and"
                                        + " gs.code_group='" + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "'"
                                        + " order by gs.scholar_fname,gs.scholar_lname";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel6 = new DataGridViewTextBoxCell();
                            DataGridViewRow row = new DataGridViewRow();
                            cel0.Value = (string)reader.GetString(0);
                            cel1.Value = (string)reader.GetString(1);
                            cel2.Value = (string)reader.GetString(2);
                            cel3.Value = (string)reader.GetString(3);
                            cel4.Value = (int)reader.GetDecimal(4);
                            cel5.Value = (int)reader.GetDecimal(5);
                            cel6.Value = (string)reader.GetString(6);
                            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                            this.gridGroup.Rows.Add(row);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }*/
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (lookUpGroup.ItemIndex > -1)
            {
                DialogResult SaveData = DevExpress.XtraEditors.XtraMessageBox.Show("Сохранить данные по группе " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + " ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (SaveData == System.Windows.Forms.DialogResult.Yes)
                {
                    var dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "victory_app";
                    if (dbCon.IsConnect())
                    {
                        try
                        {
                            int id, state;
                            id = Convert.ToInt32(lookUpGroup.Properties.GetDataSourceValue("id", lookUpGroup.ItemIndex).ToString().Trim());
                            if (chkWorkEnd.Checked)
                            {
                                state = 2;
                            }
                            else if (chkWork.Checked) {
                                state = 1;
                            }
                            else 
                            {
                                state = 0;
                            }
                            string query = "update group_list set schedule='" + txtSchedule.Text.Trim() + "',descr='" + txtGroupDescr.Text.Trim() + "',state=" + state + ",solo_registr=" + Convert.ToInt32(chkSoloRegistr.CheckState) + ""
                                            + " where id=" + id; //,code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'
                            var cmd = new MySqlCommand(query, dbCon.Connection);
                            cmd.ExecuteNonQuery();
                            CustomSqlQuery query3 = new CustomSqlQuery();
                            query3.Name = "customQuery1";
                            query3.Sql = "select id,city,code_teacher,subj_name,code_group,ifnull(descr,' ') as descr,ifnull(schedule,' ') as schedule,state from group_list"
                                        + " where subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                        + " and city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "'"
                                        + " and code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "' order by code_group";
                            sqlDataGroup.Queries.Clear();
                            sqlDataGroup.Queries.Add(query3);
                            sqlDataGroup.Fill();
                            bindGroup.DataSource = sqlDataGroup;
                            bindGroup.DataMember = "customQuery1";
                            lookUpGroup.Properties.DataSource = bindGroup;
                            lookUpGroup.EditValue = id;
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (lookUpGroup.ItemIndex > -1)
            {
                DialogResult SaveData = DevExpress.XtraEditors.XtraMessageBox.Show("Удалить группу " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + " ? Предварительно очистите от учеников!", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (SaveData == System.Windows.Forms.DialogResult.Yes)
                {
                    var dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "victory_app";
                    if (dbCon.IsConnect())
                    {
                        try
                        {
                            string query = "SELECT count(scholar_id) FROM group_scholar where code_group='" + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "'";
                            var cmd = new MySqlCommand(query, dbCon.Connection);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                if (Convert.ToInt32(result) == 0)
                                {
                                    try
                                    {
                                        string query2 = "delete from group_list where id=" + lookUpGroup.Properties.GetDataSourceValue("id", lookUpGroup.ItemIndex).ToString().Trim();
                                        var cmd2 = new MySqlCommand(query2, dbCon.Connection);
                                        cmd2.ExecuteNonQuery();

                                        CustomSqlQuery query3 = new CustomSqlQuery();
                                        query3.Name = "customQuery1";
                                        query3.Sql = "select id,city,code_teacher,subj_name,code_group,ifnull(descr,' ') as descr,ifnull(schedule,' ') as schedule,state from group_list"
                                                    + " where subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                                    + " and city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "'"
                                                    + " and code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "' order by code_group";
                                        sqlDataGroup.Queries.Clear();
                                        sqlDataGroup.Queries.Add(query3);
                                        sqlDataGroup.Fill();
                                        bindGroup.DataSource = sqlDataGroup;
                                        bindGroup.DataMember = "customQuery1";
                                        lookUpGroup.Properties.DataSource = bindGroup;
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("Группа не удалена, очистите от учеников..");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if ((lookUpSubject.ItemIndex > -1) && (lookUpGroup.ItemIndex > -1) && (gridScholar.SelectedRows.Count > 0))
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "insert into group_scholar (code_group,scholar_id,scholar_fname,scholar_lname,scholar_datebirth,scholar_code) values ('"
                                + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "',"
                                + gridScholar[5, gridScholar.CurrentRow.Index].Value + ",'" + gridScholar[1, gridScholar.CurrentRow.Index].Value + "','"
                                + gridScholar[2, gridScholar.CurrentRow.Index].Value + "','" + gridScholar[3, gridScholar.CurrentRow.Index].Value + "','"
                                + gridScholar[0, gridScholar.CurrentRow.Index].Value + "')";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        query = "update scholar_subj ss, scholar s set ss.status=1 where ss.id_master=s.id_master and"
                                + " ss.code=s.code and s.id=" + gridScholar[5, gridScholar.CurrentRow.Index].Value + " and"
                                + " ss.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'";
                        cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        grid_scholar_load();
                        grid_group_load();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if ((lookUpGroup.ItemIndex > -1) && (gridGroup.SelectedRows.Count > 0))
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "delete from group_scholar where id=" + gridGroup[5, gridGroup.CurrentRow.Index].Value;
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        query = "update scholar_subj ss, scholar s set ss.status=0, ss.type=0 where ss.id_master=s.id_master and"
                                + " ss.code=s.code and s.id=" + gridGroup[4, gridGroup.CurrentRow.Index].Value + " and"
                                + " ss.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'";
                        cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        grid_scholar_load();
                        grid_group_load();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnVibil_Click(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if ((lookUpGroup.ItemIndex > -1) && (gridGroup.SelectedRows.Count > 0))
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "delete from group_scholar where id=" + gridGroup[5, gridGroup.CurrentRow.Index].Value;
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        query = "update scholar_subj ss, scholar s set ss.status=0, ss.type=1 where ss.id_master=s.id_master and"
                                + " ss.code=s.code and s.id=" + gridGroup[4, gridGroup.CurrentRow.Index].Value + " and"
                                + " ss.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'";
                        cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        grid_scholar_load();
                        grid_group_load();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void radioRezerv_CheckedChanged(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (lookUpCityScholarF.ItemIndex > -1)
            {
                grid_scholar_load();
            }
        }

        private void radioVibil_CheckedChanged(object sender, EventArgs e)
        {
            groupChangeTeacher.Visible = false;
            if (lookUpCityScholarF.ItemIndex > -1)
            {
                grid_scholar_load();
            }
        }

        private void btnChangeTeacher_Click(object sender, EventArgs e)
        {
            if ((lookUpTeachers.ItemIndex > -1) && (lookUpGroup.ItemIndex > -1))
            {
                if (groupChangeTeacher.Visible)
                {
                    groupChangeTeacher.Visible = false;
                }
                else
                {
                    groupChangeTeacher.Visible = true;
                }
            }
        }

        private void lookUpTeachersChange_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpTeachersChange.ItemIndex > -1)
            {
                CustomSqlQuery query3 = new CustomSqlQuery();
                query3.Name = "customQuery1";
                query3.Sql = "select id,city,code_teacher,subj_name,code_group,ifnull(descr,' ') as descr,ifnull(schedule,' ') as schedule,state from group_list"
                            + " where subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                            + " and city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "'"
                            + " and code_teacher='" + lookUpTeachersChange.Properties.GetDataSourceValue("code", lookUpTeachersChange.ItemIndex).ToString().Trim() + "' order by code_group";
                sqlDataGroupChange.Queries.Clear();
                sqlDataGroupChange.Queries.Add(query3);
                sqlDataGroupChange.Fill();
                bindGroupChange.DataSource = sqlDataGroupChange;
                bindGroupChange.DataMember = "customQuery1";
                lookUpGroupChange.Properties.DataSource = bindGroupChange;
            }
            if ((lookUpTeachersChange.ItemIndex > -1) && (lookUpSubject.ItemIndex > -1) && (lookUpCityScholarF.ItemIndex > -1))
            {
                txtCreateGroupChange.Text = lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() + lookUpTeachersChange.Properties.GetDataSourceValue("code", lookUpTeachersChange.ItemIndex).ToString().Trim();
                btnChangeApply.Enabled = true;
            }
        }

        private void btnChangeApply_Click(object sender, EventArgs e)
        {
            if (txtCreateGroupChange.Text.Trim().Length > 7)
            {
                DialogResult ChangeTeacher = DevExpress.XtraEditors.XtraMessageBox.Show("Вы уверены, что хотите сменить преподавателя группе " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + " ? Это приведет к изменению номера группы !!", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ChangeTeacher == System.Windows.Forms.DialogResult.Yes)
                {
                    var dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "victory_app";
                    if (dbCon.IsConnect())
                    {
                        try
                        {
                            string query = "SELECT count(*) FROM group_list where code_group='" + txtCreateGroupChange.Text.Trim() + "'";
                            var cmd = new MySqlCommand(query, dbCon.Connection);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                if (Convert.ToInt32(result) == 0)
                                {
                                    try
                                    {
                                        query = "update group_list set code_group='" + txtCreateGroupChange.Text.Trim() + "', code_teacher='"
                                                + lookUpTeachersChange.Properties.GetDataSourceValue("code", lookUpTeachersChange.ItemIndex).ToString().Trim() + "' where code_group='"
                                                + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "'";
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();
                                        query = "update group_scholar set code_group='" + txtCreateGroupChange.Text.Trim() + "' where code_group='"
                                                + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "'";
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                    }
                                    CustomSqlQuery query3 = new CustomSqlQuery();
                                    query3.Name = "customQuery1";
                                    query3.Sql = "select id,city,code_teacher,subj_name,code_group,ifnull(descr,' ') as descr,ifnull(schedule,' ') as schedule,state from group_list"
                                                + " where subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                                + " and city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "'"
                                                + " and code_teacher='" + lookUpTeachersChange.Properties.GetDataSourceValue("code", lookUpTeachersChange.ItemIndex).ToString().Trim() + "' order by code_group";
                                    sqlDataGroupChange.Queries.Clear();
                                    sqlDataGroupChange.Queries.Add(query3);
                                    sqlDataGroupChange.Fill();
                                    bindGroupChange.DataSource = sqlDataGroupChange;
                                    bindGroupChange.DataMember = "customQuery1";
                                    lookUpGroupChange.Properties.DataSource = bindGroupChange;
                                    txtCreateGroupChange.Text = txtCreateGroupChange.Text.Substring(0, 6);
                                }
                                else
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("Группа с таким кодом уже существует..");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Код группы не корректен..");
            }
        }
    }
}