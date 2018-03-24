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
    public partial class frmRptSubjHour : DevExpress.XtraEditors.XtraForm
    {
        public frmRptSubjHour()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
            sqlDataSubject.Fill();
            //sqlDataTeacher.Fill();
        }

        private void frmRptSubjHour_Load(object sender, EventArgs e)
        {
            /*dateViewZakaz.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lblTest.Text = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString();
            dateEnd.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            dateStart.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            dateEnd.Properties.Mask.EditMask = "dd.MM.yyyy";
            dateStart.Properties.Mask.EditMask = "dd.MM.yyyy";
            dateEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEnd.Text = DateTime.Now.ToString("dd.MM.yyyy");
            dateStart.Text = "01." + DateTime.Now.ToString("MM.yyyy");*/
            dateStart.Text = DateTime.Now.ToString("dd.MM.yyyy");
            dateEnd.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (lookUpCityF.ItemIndex > -1 && lookUpSubject.ItemIndex > -1 && lookUpTeachers.ItemIndex > -1 /*&& (chkWorkEnd.Checked == true || chkWork.Checked == true)*/)
            {               
                this.gridGroup.Rows.Clear();
                this.gridGroup.Columns.Clear();
                gridGroup.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                col0.HeaderText = "Город";
                col0.Name = "city";
                col0.ReadOnly = true;
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "Предмет";
                col1.Name = "subject";
                col1.ReadOnly = true;
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Преподаватель";
                col2.Name = "teacher";
                col2.ReadOnly = true;
                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Кол-во занятий";
                col3.Name = "lesson_cnt";
                col3.ReadOnly = true;
                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "Кол-во часов";
                col4.Name = "hour_cnt";
                col4.ReadOnly = true;
                DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                col5.HeaderText = "Оплата";
                col5.Name = "payment";
                col5.ReadOnly = true;

                this.gridGroup.Columns.Add(col0);
                this.gridGroup.Columns.Add(col1);
                this.gridGroup.Columns.Add(col2);
                this.gridGroup.Columns.Add(col3);
                this.gridGroup.Columns.Add(col4);
                this.gridGroup.Columns.Add(col5);

                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query;
                        if ((lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() == "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() == "00"))
                        {
                            query = "select c.city_name as city,gl.subj_name as subject,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,count(gj.date_lesson) as cnt_lessons,sum(gj.hour) as cnt_hour,sum(gj.hour*gj.payment) as cnt_pay"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname order by 1,2,4,3";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() == "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() == "00")
                        {
                            query = "select c.city_name as city,gl.subj_name as subject,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,count(gj.date_lesson) as cnt_lessons,sum(gj.hour) as cnt_hour,sum(gj.hour*gj.payment) as cnt_pay"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " and gj.city_code=" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim()
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname order by 1,2,4,3";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() == "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() != "00")
                        {
                            query = "select c.city_name as city,gl.subj_name as subject,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,count(gj.date_lesson) as cnt_lessons,sum(gj.hour) as cnt_hour,sum(gj.hour*gj.payment) as cnt_pay"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " and gj.city_code=" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim()
                                    + " and gl.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname order by 1,2,4,3";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() != "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() != "00")
                        {
                            query = "select c.city_name as city,gl.subj_name as subject,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,count(gj.date_lesson) as cnt_lessons,sum(gj.hour) as cnt_hour,sum(gj.hour*gj.payment) as cnt_pay"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " and gj.city_code=" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim()
                                    + " and gl.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                    + " and gj.teacher_code='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'"
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname order by 1,2,4,3";
                        }
                        else
                        {
                            query = "";
                        }
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                                DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                                DataGridViewRow row = new DataGridViewRow();
                                cel0.Value = (string)reader.GetString(0);
                                cel1.Value = (string)reader.GetString(1);
                                cel2.Value = (string)reader.GetString(3) + " (" + (string)reader.GetString(2) + ")";
                                cel3.Value = (string)reader.GetString(4);
                                cel4.Value = (string)reader.GetString(5);
                                cel5.Value = (string)reader.GetString(6);
                                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
                                this.gridGroup.Rows.Add(row);
                            }
                        }
                        reader.Close();
                        try
                        {
                            int cnt_les=0;
                            double sum_hour=0, sum_pay=0;
                            for (int i = 0; i < gridGroup.RowCount; i++)
                            {
                                cnt_les += Convert.ToInt32(gridGroup[3, i].Value);
                                sum_hour += Convert.ToDouble(gridGroup[4, i].Value);
                                sum_pay += Convert.ToDouble(gridGroup[5, i].Value);
                            }
                            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                            DataGridViewRow row = new DataGridViewRow();
                            cel0.Value = "Итого";
                            cel1.Value = "";
                            cel2.Value = "";
                            cel3.Value = cnt_les.ToString().Trim();
                            cel4.Value = sum_hour.ToString().Trim();
                            cel5.Value = sum_pay.ToString().Trim();
                            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
                            this.gridGroup.Rows.Add(row);
                            gridGroup.Rows[gridGroup.RowCount-1].Cells[0].Style.Font = new Font(gridGroup.DefaultCellStyle.Font, FontStyle.Bold);
                            gridGroup.Rows[gridGroup.RowCount - 1].Cells[3].Style.Font = new Font(gridGroup.DefaultCellStyle.Font, FontStyle.Bold);
                            gridGroup.Rows[gridGroup.RowCount - 1].Cells[4].Style.Font = new Font(gridGroup.DefaultCellStyle.Font, FontStyle.Bold);
                            gridGroup.Rows[gridGroup.RowCount - 1].Cells[5].Style.Font = new Font(gridGroup.DefaultCellStyle.Font, FontStyle.Bold);
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
                gridGroup.ClearSelection();
            }
        }

        private void lookUpSubject_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpCityF.ItemIndex > -1)
                {
                    lookUpTeachers.EditValue = null;
                    CustomSqlQuery query = new CustomSqlQuery();
                    query.Name = "customQuery1";
                    if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() != "00")
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t, teacher_subj ts"
                                    + " where t.city_id=ts.city and t.code=ts.code and ts.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                    + " and t.city_id='" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() + "' order by 3,4";
                    }
                    else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() != "00")
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t, teacher_subj ts"
                                    + " where t.city_id=ts.city and t.code=ts.code and ts.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                    + " order by 3,4";
                    }
                    else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() == "00")
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t"
                                    + " where t.city_id='" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() + "' order by 3,4";
                    }
                    else
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t order by 3,4";
                    }
                    sqlDataTeacher.Queries.Clear();
                    sqlDataTeacher.Queries.Add(query);
                    sqlDataTeacher.Fill();
                    bindTeacher.DataSource = sqlDataTeacher;
                    bindTeacher.DataMember = "customQuery1";
                    lookUpTeachers.Properties.DataSource = bindTeacher;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void lookUpCityF_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpSubject.ItemIndex > -1)
                {
                    lookUpTeachers.EditValue = null;
                    CustomSqlQuery query = new CustomSqlQuery();
                    query.Name = "customQuery1";
                    if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() != "00")
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t, teacher_subj ts"
                                    + " where t.city_id=ts.city and t.code=ts.code and ts.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                    + " and t.city_id='" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() + "' order by 3,4"; //fname,lname
                    }
                    else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() != "00")
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t, teacher_subj ts"
                                    + " where t.city_id=ts.city and t.code=ts.code and ts.subj_name='" + lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim() + "'"
                                    + " order by 3,4";
                    }
                    else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpSubject.Properties.GetDataSourceValue("subj_id", lookUpSubject.ItemIndex).ToString().Trim() == "00")
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t"
                                    + " where t.city_id='" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() + "' order by 3,4";
                    }
                    else
                    {
                        query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                    + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                    + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                    + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t order by 3,4";
                    }
                    sqlDataTeacher.Queries.Clear();
                    sqlDataTeacher.Queries.Add(query);
                    sqlDataTeacher.Fill();
                    bindTeacher.DataSource = sqlDataTeacher;
                    bindTeacher.DataMember = "customQuery1";
                    lookUpTeachers.Properties.DataSource = bindTeacher;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}