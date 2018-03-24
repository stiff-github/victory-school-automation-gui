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
    public partial class frmRptGroup1 : DevExpress.XtraEditors.XtraForm
    {
        public frmRptGroup1()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
            //sqlDataTeacher.Fill();
        }

        private void lookUpCityF_EditValueChanged(object sender, EventArgs e)
        {
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "customQuery1";
            if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00")
            {
                query.Sql = "select 0 as `id`, '00' as `code`, '' as `city`, '_все преподаватели_' as `fname`, '' as `lname`, '' as `sname`, '' as `date_birth`,"
                        +" '' as `phone`, '' as `adres`, '' as `descr`, '' as `salary`, '' as `mail` from dual union all "
                        + " select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                        + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail from teacher order by city,fname,lname";
            }
            else
            {
                query.Sql = "select 0 as `id`, '00' as `code`, '' as `city`, '_все преподаватели_' as `fname`, '' as `lname`, '' as `sname`, '' as `date_birth`,"
                        + " '' as `phone`, '' as `adres`, '' as `descr`, '' as `salary`, '' as `mail` from dual union all "
                        + "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                        + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail from teacher"
                        + " where city='" + lookUpCityF.Properties.GetDataSourceValue("city_name", lookUpCityF.ItemIndex).ToString().Trim() + "' order by fname,lname";
            }
            sqlDataTeacher.Queries.Clear();
            sqlDataTeacher.Queries.Add(query);
            sqlDataTeacher.Fill();
            bindTeacher.DataSource = sqlDataTeacher;
            bindTeacher.DataMember = "customQuery1";
            lookUpTeachers.Properties.DataSource = bindTeacher;
        }

        private void lookUpTeachers_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpTeachers.ItemIndex > -1)
            {
                this.gridGroupScholar.Rows.Clear();
                int state;
                if (chkWorkEnd.Checked)
                {
                    state = 2;
                }
                else
                {
                    state = 1;
                }

                this.gridGroup.Rows.Clear();
                this.gridGroup.Columns.Clear();
                gridGroup.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                col0.HeaderText = "Код группы";
                col0.Name = "group";
                col0.ReadOnly = true;
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "Город";
                col1.Name = "city";
                col1.ReadOnly = true;
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Предмет";
                col2.Name = "subject";
                col2.ReadOnly = true;
                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Преподаватель";
                col3.Name = "teacher";
                col3.ReadOnly = true;
                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "Кол-во учеников";
                col4.Name = "cnt";
                col4.ReadOnly = true;
                DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                col5.HeaderText = "Расписание";
                col5.Name = "schedule";
                col5.ReadOnly = true;
                DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
                col6.HeaderText = "Примечание";
                col6.Name = "descr";
                col6.ReadOnly = true;
                DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
                col7.HeaderText = "id";
                col7.Name = "id";
                col7.ReadOnly = true;
                col7.Visible = false;

                this.gridGroup.Columns.Add(col0);
                this.gridGroup.Columns.Add(col1);
                this.gridGroup.Columns.Add(col2);
                this.gridGroup.Columns.Add(col3);
                this.gridGroup.Columns.Add(col4);
                this.gridGroup.Columns.Add(col5);
                this.gridGroup.Columns.Add(col6);
                this.gridGroup.Columns.Add(col7);

                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query;
                        if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() == "00")
                        {
                            query = "select gl.code_group,gl.city,gl.subj_name,gl.code_teacher,gs.cnt,ifnull(gl.schedule,' ') as schedule,ifnull(gl.descr,' ') as descr,gl.id from group_list gl"
                                    + ",(select code_group,count(scholar_id) as cnt from group_scholar group by code_group) gs"
                                    + " where gl.code_group=gs.code_group and gl.state=" + state + " order by gl.code_group";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() != "00")
                        {
                            query = "select gl.code_group,gl.city,gl.subj_name,gl.code_teacher,gs.cnt,ifnull(gl.schedule,' ') as schedule,ifnull(gl.descr,' ') as descr,gl.id from group_list gl"
                                    + ",(select code_group,count(scholar_id) as cnt from group_scholar group by code_group) gs where gl.code_group=gs.code_group and gl.state=" + state + ""
                                    + " and gl.code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "' order by gl.code_group";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() == "00")
                        {
                            query = "select gl.code_group,gl.city,gl.subj_name,gl.code_teacher,gs.cnt,ifnull(gl.schedule,' ') as schedule,ifnull(gl.descr,' ') as descr,gl.id from group_list gl"
                                    + ",(select code_group,count(scholar_id) as cnt from group_scholar group by code_group) gs"
                                    + " where gl.code_group=gs.code_group and gl.city='" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() + "' and gl.state=" + state + ""
                                    + " order by gl.code_group";
                        }
                        else
                        {
                            query = "select gl.code_group,gl.city,gl.subj_name,gl.code_teacher,gs.cnt,ifnull(gl.schedule,' ') as schedule,ifnull(gl.descr,' ') as descr,gl.id from group_list gl"
                                    + ",(select code_group,count(scholar_id) as cnt from group_scholar group by code_group) gs"
                                    + " where gl.code_group=gs.code_group and gl.city='" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() + "' and gl.state=" + state + ""
                                    + " and gl.code_teacher='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "' order by gl.code_group";
                        }
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
                            DataGridViewCell cel7 = new DataGridViewTextBoxCell();
                            DataGridViewRow row = new DataGridViewRow();
                            cel0.Value = (string)reader.GetString(0);
                            cel1.Value = (string)reader.GetString(1);
                            cel2.Value = (string)reader.GetString(2);
                            cel3.Value = (string)reader.GetString(3);
                            cel4.Value = (int)reader.GetDecimal(4);
                            cel5.Value = (string)reader.GetString(5);
                            cel6.Value = (string)reader.GetString(6);
                            cel7.Value = (int)reader.GetDecimal(7);
                            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6, cel7);
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
        }

        private void gridGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.gridGroupScholar.Rows.Clear();
                this.gridGroupScholar.Columns.Clear();
                gridGroupScholar.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
                col3.HeaderText = "Дата рождения";
                col3.Name = "scholar_datebirth";
                col3.ReadOnly = true;

                this.gridGroupScholar.Columns.Add(col0);
                this.gridGroupScholar.Columns.Add(col1);
                this.gridGroupScholar.Columns.Add(col2);
                this.gridGroupScholar.Columns.Add(col3);

                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query;
                        query = "select scholar_code,scholar_fname,ifnull(scholar_lname,' ') as scholar_lname,ifnull(DATE_FORMAT(scholar_datebirth,'%d.%m.%Y'),' ') as scholar_datebirth"
                                    + " from group_scholar where "
                                    + " code_group='" + gridGroup[0, e.RowIndex].Value.ToString() + "'"
                                    + " order by scholar_fname,scholar_lname";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                            DataGridViewRow row = new DataGridViewRow();
                            cel0.Value = (string)reader.GetString(0);
                            cel1.Value = (string)reader.GetString(1);
                            cel2.Value = (string)reader.GetString(2);
                            cel3.Value = (string)reader.GetString(3);
                            //cel4.Value = (int)reader.GetDecimal(4);
                            row.Cells.AddRange(cel0, cel1, cel2, cel3);
                            this.gridGroupScholar.Rows.Add(row);
                        }
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
}