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
    public partial class frmJournal : DevExpress.XtraEditors.XtraForm
    {
        public frmJournal()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
        }

        private void frmJournal_Load(object sender, EventArgs e)
        {
            dateLesson.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void lookUpCityScholarF_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpCityScholarF.ItemIndex > -1)
            {
                CustomSqlQuery query2 = new CustomSqlQuery();
                query2.Name = "customQuery1";
                query2.Sql = "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                            + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t"
                            + " where t.city_id='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "' order by fname,lname";
                sqlDataTeacher.Queries.Clear();
                sqlDataTeacher.Queries.Add(query2);
                sqlDataTeacher.Fill();
                bindTeacher.DataSource = sqlDataTeacher;
                bindTeacher.DataMember = "customQuery1";
                lookUpTeachers.Properties.DataSource = bindTeacher;
                this.gridGroup.Rows.Clear();
                this.gridGroup.Columns.Clear();
                //bindGroup.DataSource = null;
                lookUpGroup.EditValue = null;
                lookUpTeachers.EditValue = null;
            }
        }

        private void lookUpTeachers_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpTeachers.ItemIndex > -1)
            {
                bindGroup.DataSource = null;
                CustomSqlQuery query3 = new CustomSqlQuery();
                query3.Name = "customQuery1";
                query3.Sql = "select id,city,code_teacher,subj_name,code_group,ifnull(descr,' ') as descr,ifnull(schedule,' ') as schedule,IF(state=1,'в процессе','') as state from group_list"
                            + " where city='" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "' and state=1"
                            + " and code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "' order by code_group";
                sqlDataGroup.Queries.Clear();
                sqlDataGroup.Queries.Add(query3);
                sqlDataGroup.Fill();
                bindGroup.DataSource = sqlDataGroup;
                bindGroup.DataMember = "customQuery1";
                lookUpGroup.Properties.DataSource = bindGroup;
                this.gridGroup.Rows.Clear();
                this.gridGroup.Columns.Clear();
                lookUpGroup.EditValue = null;
            }
        }

        private void lookUpGroup_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpGroup.ItemIndex > -1)
            {
                txtSchedule.Text = lookUpGroup.Properties.GetDataSourceValue("schedule", lookUpGroup.ItemIndex).ToString().Trim();
                txtGroupDescr.Text = lookUpGroup.Properties.GetDataSourceValue("descr", lookUpGroup.ItemIndex).ToString().Trim();

                this.gridGroup.Rows.Clear();
                this.gridGroup.Columns.Clear();
                gridGroup.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                col0.HeaderText = "Код ученика";
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
                DataGridViewCheckBoxColumn col6 = new DataGridViewCheckBoxColumn();
                col6.HeaderText = "Присутствие";
                col6.Name = "presence";
                DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
                col7.HeaderText = "Часы";
                col7.Name = "hour";
                DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
                col8.HeaderText = "Payment";
                col8.Name = "Payment";
                col8.ReadOnly = true;
                //col8.Visible = false;

                this.gridGroup.Columns.Add(col0);
                this.gridGroup.Columns.Add(col1);
                this.gridGroup.Columns.Add(col2);
                this.gridGroup.Columns.Add(col3);
                this.gridGroup.Columns.Add(col4);
                this.gridGroup.Columns.Add(col5);
                this.gridGroup.Columns.Add(col6);
                this.gridGroup.Columns.Add(col7);
                this.gridGroup.Columns.Add(col8);

                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    int fill = 0;
                    try
                    {
                        string query = "select scholar_code,scholar_fname,ifnull(scholar_lname,' ') as scholar_lname,ifnull(DATE_FORMAT(scholar_datebirth,'%d.%m.%Y'),' ') as scholar_datebirth"
                                        + ",scholar_id,id,presence,hour,payment from group_journal where code_group='" + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "'"
                                        + " and date_lesson=str_to_date('" + dateLesson.DateTime.ToShortDateString() + "','%d.%m.%Y') order by scholar_fname,scholar_lname";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            fill = 1;
                            lblUpdateLesson.Text = "Редактирование уже введенного урока от " + dateLesson.Text + ".";
                            lblUpdateLesson.ForeColor = Color.Red;
                            lblUpdateLesson.Visible = true;
                            while (reader.Read())
                            {
                                DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel6 = new DataGridViewCheckBoxCell();
                                DataGridViewCell cel7 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel8 = new DataGridViewTextBoxCell();
                                DataGridViewRow row = new DataGridViewRow();
                                cel0.Value = (string)reader.GetString(0);
                                cel1.Value = (string)reader.GetString(1);
                                cel2.Value = (string)reader.GetString(2);
                                cel3.Value = (string)reader.GetString(3);
                                cel4.Value = (int)reader.GetDecimal(4);
                                cel5.Value = (int)reader.GetDecimal(5);
                                cel6.Value = Convert.ToBoolean((int)reader.GetDecimal(6));
                                cel7.Value = (string)reader.GetDecimal(7).ToString();
                                if (reader.GetDecimal(7) == 0 && reader.GetDecimal(6) == 1)
                                {
                                    cel7.Style.BackColor = System.Drawing.Color.Tomato;
                                }
                                cel8.Value = (double)reader.GetDecimal(8);
                                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6, cel7, cel8);
                                this.gridGroup.Rows.Add(row);
                            }
                            lblNew.Text = "0";
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }

                    if (fill == 0)
                    {
                        try
                        {
                            lblUpdateLesson.Text = "На дату " + dateLesson.Text + " журнал ещё не заводился.";
                            lblUpdateLesson.ForeColor = Color.DarkGreen;
                            lblUpdateLesson.Visible = true;
                            string query = "select gs.scholar_code,gs.scholar_fname,ifnull(gs.scholar_lname,' ') as scholar_lname,ifnull(DATE_FORMAT(gs.scholar_datebirth,'%d.%m.%Y'),' ') as scholar_datebirth"
                                            + ",gs.scholar_id,gs.id,ss.discount_type,ss.discount_val,ss.payment from group_scholar gs, scholar_subj ss, scholar s,group_list gl"
                                            + " where gs.scholar_id=s.id and ss.id_master=s.id_master and ss.code=s.code and gs.code_group=gl.code_group and gl.subj_name=ss.subj_name"
                                            + " and gs.code_group='" + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "'"
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
                                DataGridViewCell cel6 = new DataGridViewCheckBoxCell();
                                DataGridViewCell cel7 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel8 = new DataGridViewTextBoxCell();
                                DataGridViewRow row = new DataGridViewRow();
                                cel0.Value = (string)reader.GetString(0);
                                cel1.Value = (string)reader.GetString(1);
                                cel2.Value = (string)reader.GetString(2);
                                cel3.Value = (string)reader.GetString(3);
                                cel4.Value = (int)reader.GetDecimal(4);
                                cel5.Value = (int)reader.GetDecimal(5);
                                cel6.Value = false;
                                cel7.Value = "0";
                                double sum_pay = 0;
                                switch ((int)reader.GetDecimal(6))
                                {
                                    case 0:
                                        sum_pay = (double)reader.GetDecimal(8);
                                        break;
                                    case 1:
                                        sum_pay = (double)reader.GetDecimal(8) * ((100 - (int)reader.GetDecimal(7)) / 100);
                                        break;
                                    case 2:
                                        sum_pay = (double)reader.GetDecimal(8) - (int)reader.GetDecimal(7);
                                        break;
                                    case 3:
                                        sum_pay = (double)reader.GetDecimal(7);
                                        break;
                                }
                                cel8.Value = sum_pay.ToString();
                                //cel8.Value = (string)reader.GetDecimal(6).ToString();
                                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6, cel7, cel8);
                                this.gridGroup.Rows.Add(row);
                            }
                            lblNew.Text = "1";
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridGroup.RowCount > 0)
            {
                int err = 0;
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    if (lblNew.Text == "1")
                    {
                        try
                        {
                            for (int i = 0; i < gridGroup.RowCount; i++)
                            {
                                try
                                {
                                    if (Double.Parse(gridGroup[7, i].Value.ToString().Trim())>=0)
                                    {
                                        string query = "insert into group_journal(city_code,teacher_code,code_group,date_lesson,scholar_id,scholar_fname,scholar_lname,scholar_datebirth,scholar_code,presence,hour,payment)"
                                            + " values ('" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "','"
                                            + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "','"
                                            + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "',"
                                            + "str_to_date('" + dateLesson.DateTime.ToShortDateString() + "','%d.%m.%Y')," + gridGroup[4, i].Value + ",'" + gridGroup[1, i].Value + "','"
                                            + gridGroup[2, i].Value + "',str_to_date('" + gridGroup[3, i].Value + "','%d.%m.%Y'),'" + gridGroup[0, i].Value + "',"
                                            + Convert.ToInt32(gridGroup[6, i].Value) + "," + Convert.ToDouble(gridGroup[7, i].Value) + "," + Convert.ToDouble(gridGroup[8, i].Value) + ")";
                                        var cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();

                                        gridGroup[7, i].Style.BackColor = System.Drawing.Color.White;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string query = "insert into group_journal(city_code,teacher_code,code_group,date_lesson,scholar_id,scholar_fname,scholar_lname,scholar_datebirth,scholar_code,presence,hour,payment)"
                                            + " values ('" + lookUpCityScholarF.Properties.GetDataSourceValue("city_id", lookUpCityScholarF.ItemIndex).ToString().Trim() + "','"
                                            + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "','"
                                            + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + "',"
                                            + "str_to_date('" + dateLesson.DateTime.ToShortDateString() + "','%d.%m.%Y')," + gridGroup[4, i].Value + ",'" + gridGroup[1, i].Value + "','"
                                            + gridGroup[2, i].Value + "',str_to_date('" + gridGroup[3, i].Value + "','%d.%m.%Y'),'" + gridGroup[0, i].Value + "',"
                                            + Convert.ToInt32(gridGroup[6, i].Value) + ",0," + Convert.ToDouble(gridGroup[8, i].Value) + ")";
                                    var cmd = new MySqlCommand(query, dbCon.Connection);
                                    cmd.ExecuteNonQuery();

                                    gridGroup[7, i].Style.BackColor = System.Drawing.Color.Tomato;
                                    err = 1;
                                }
                            }
                            lookUpGroup_EditValueChanged(this, null);
                            gridGroup.ClearSelection();
                            if (err == 1)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("На дату " + dateLesson.Text + " заведен НЕ ПОЛНЫЙ журнал по группе " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + ".");
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("На дату " + dateLesson.Text + " заведен журнал по группе " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + ".");
                            }
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            for (int i = 0; i < gridGroup.RowCount; i++)
                            {
                                try
                                {
                                    if (Double.Parse(gridGroup[7, i].Value.ToString().Trim())>=0)
                                    {
                                        string query = "update group_journal set presence=" + Convert.ToInt32(gridGroup[6, i].Value) + ",hour=" + Convert.ToDouble(gridGroup[7, i].Value) + ""
                                                        + " where id=" + gridGroup[5, i].Value;
                                        var cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();

                                        gridGroup[7, i].Style.BackColor = System.Drawing.Color.White;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    gridGroup[7, i].Style.BackColor = System.Drawing.Color.Tomato;
                                    err = 1;
                                }
                            }
                            gridGroup.ClearSelection();
                            if (err == 1)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("На дату " + dateLesson.Text + " обновлен НЕ ПОЛНОСТЬЮ журнал по группе " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + ".");
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("На дату " + dateLesson.Text + " обновлен журнал по группе " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + ".");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((gridGroup.RowCount > 0) && (lblNew.Text == "0"))
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        for (int i = 0; i < gridGroup.RowCount; i++)
                        {
                            string query = "delete from group_journal where id=" + gridGroup[5, i].Value;
                            var cmd = new MySqlCommand(query, dbCon.Connection);
                            cmd.ExecuteNonQuery();
                        }
                        lookUpGroup_EditValueChanged(this,null);
                        DevExpress.XtraEditors.XtraMessageBox.Show("На дату " + dateLesson.Text + " УДАЛЕН журнал по группе " + lookUpGroup.Properties.GetDataSourceValue("code_group", lookUpGroup.ItemIndex).ToString().Trim() + ".");
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}