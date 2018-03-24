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
    public partial class frmPayment : DevExpress.XtraEditors.XtraForm
    {
        public frmPayment()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
        }

        private void lookUpCityF_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpTeachers.EditValue = null;
                CustomSqlQuery query = new CustomSqlQuery();
                query.Name = "customQuery1";
                if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00")
                {
                    query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t"
                                + " where t.city_id='" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() + "' order by 3,4"; //fname,lname
                }
                else
                {
                    query.Sql = "select 0 as id, '00' as code, '' as city, '_все преподаватели_' as fname, '' as lname, '' as sname, '' as date_birth,"
                                + " '' as phone, '' as adres, '' as descr, '' as salary, '' as mail from dual union all "
                                + "select t.id,t.code,t.city,t.fname,ifnull(t.lname,' ') as lname,ifnull(t.sname,' ') as sname,ifnull(DATE_FORMAT(t.date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(t.phone,' ') as phone,"
                                + " ifnull(t.adres,' ') as adres,ifnull(t.descr,' ') as descr,ifnull(t.salary,' ') as salary,ifnull(t.mail,' ') as mail from teacher t"
                                + " order by 3,4";
                }
                sqlDataTeacher.Queries.Clear();
                sqlDataTeacher.Queries.Add(query);
                sqlDataTeacher.Fill();
                bindTeacher.DataSource = sqlDataTeacher;
                bindTeacher.DataMember = "customQuery1";
                lookUpTeachers.Properties.DataSource = bindTeacher;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            dateStart.Text = DateTime.Now.ToString("dd.MM.yyyy");
            dateEnd.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (lookUpCityF.ItemIndex > -1 && lookUpTeachers.ItemIndex > -1)
            {
                this.gridGroup.Rows.Clear();
                this.gridGroup.Columns.Clear();
                gridGroup.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                col0.HeaderText = "Город";
                col0.Name = "city";
                col0.ReadOnly = true;
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "Преподаватель";
                col1.Name = "teacher";
                col1.ReadOnly = true;
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Кол-во часов";
                col2.Name = "hour_cnt";
                col2.ReadOnly = true;
                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Ставка";
                col3.Name = "stavka";
                col3.ReadOnly = true;
                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "Оплата часа";
                col4.Name = "sal_hour";
                col4.ReadOnly = true;
                DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                col5.HeaderText = "Бонус";
                col5.Name = "bonus";
                col5.ReadOnly = true;
                DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
                col6.HeaderText = "Оплата";
                col6.Name = "payment";
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
                        string query;
                        if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() == "00")
                        {
                            query = "select c.city_name as city,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,sum(gj.hour) as cnt_hour,t.stavka,t.salary,t.bonus"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " group by c.city_name,gj.teacher_code,t.fname,t.stavka,t.salary,t.bonus order by 1,2,4,3";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() != "00")
                        {
                            query = "select c.city_name as city,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,sum(gj.hour) as cnt_hour,t.stavka,t.salary,t.bonus"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " and gj.teacher_code='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'"
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname,t.stavka,t.salary,t.bonus order by 1,2,4,3";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() == "00")
                        {
                            query = "select c.city_name as city,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,sum(gj.hour) as cnt_hour,t.stavka,t.salary,t.bonus"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " and gj.city_code=" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim()
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname,t.stavka,t.salary,t.bonus order by 1,2,4,3";
                        }
                        else if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() != "00" && lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() != "00")
                        {
                            query = "select c.city_name as city,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,sum(gj.hour) as cnt_hour,t.stavka,t.salary,t.bonus"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " and gj.city_code=" + lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim()
                                    + " and gj.teacher_code='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'"
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname,t.stavka,t.salary,t.bonus order by 1,2,4,3";
                        }
                        else
                        {
                            query = "";
                        }
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            double sal=0;
                            int i = 0;
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
                                cel1.Value = (string)reader.GetString(2) + " (" + (string)reader.GetString(1) + ")";
                                cel2.Value = (string)reader.GetString(3);
                                cel3.Value = (string)reader.GetString(4);
                                cel4.Value = (string)reader.GetString(5);
                                cel5.Value = (string)reader.GetString(6);
                                cel6.Value = "0";
                                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                                this.gridGroup.Rows.Add(row);
                                sal = Convert.ToDouble(gridGroup[2, i].Value) * Convert.ToDouble(gridGroup[4, i].Value) + Convert.ToDouble(gridGroup[3, i].Value) + Convert.ToDouble(gridGroup[5, i].Value); //3+2*4+5
                                gridGroup[6, i].Value = sal.ToString();
                                ++i;
                            }
                        }
                        reader.Close();
                        try
                        {
                            double sum_hour = 0, sum_pay = 0;
                            for (int i = 0; i < gridGroup.RowCount; i++)
                            {
                                sum_hour += Convert.ToDouble(gridGroup[2, i].Value);
                                sum_pay += Convert.ToDouble(gridGroup[6, i].Value);
                            }
                            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                            DataGridViewCell cel6 = new DataGridViewTextBoxCell();
                            DataGridViewRow row = new DataGridViewRow();
                            cel0.Value = "Итого";
                            cel1.Value = "";
                            cel2.Value = sum_hour.ToString().Trim();
                            cel3.Value = "";
                            cel4.Value = "";
                            cel5.Value = "";
                            cel6.Value = sum_pay.ToString().Trim();
                            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                            this.gridGroup.Rows.Add(row);
                            gridGroup.Rows[gridGroup.RowCount - 1].Cells[0].Style.Font = new Font(gridGroup.DefaultCellStyle.Font, FontStyle.Bold);
                            gridGroup.Rows[gridGroup.RowCount - 1].Cells[2].Style.Font = new Font(gridGroup.DefaultCellStyle.Font, FontStyle.Bold);
                            gridGroup.Rows[gridGroup.RowCount - 1].Cells[6].Style.Font = new Font(gridGroup.DefaultCellStyle.Font, FontStyle.Bold);
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
    }
}