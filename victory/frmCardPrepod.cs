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
    public partial class frmCardPrepod : DevExpress.XtraEditors.XtraForm
    {
        public frmCardPrepod()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
        }

        private void lookUpTeachers_EditValueChanged(object sender, EventArgs e)
        {
            lblId.Text = lookUpTeachers.Properties.GetDataSourceValue("id", lookUpTeachers.ItemIndex).ToString().Trim();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "select code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                        + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,salary,stavka,bonus,ifnull(mail,' ') as mail from teacher"
                        + " where id=" + lookUpTeachers.Properties.GetDataSourceValue("id", lookUpTeachers.ItemIndex).ToString().Trim();
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtFName.Text = reader.GetString(2);
                        txtLName.Text = reader.GetString(3);
                        txtSName.Text = reader.GetString(4);
                        txtCode.Text = reader.GetString(0);
                        txtDateBirth.Text = reader.GetString(5); //date_format
                        txtTel.Text = reader.GetString(6);
                        txtMail.Text = reader.GetString(12);
                        txtAdres.Text = reader.GetString(7);
                        txtDescr.Text = reader.GetString(8);
                        txtSalHour2.Text = txtSalHour.Text = reader.GetDecimal(9).ToString();
                        txtSal2.Text = txtSal.Text = reader.GetDecimal(10).ToString();
                        txtSalBonus2.Text = txtSalBonus.Text = reader.GetDecimal(11).ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void lookUpCityF_EditValueChanged(object sender, EventArgs e)
        {
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "customQuery1";
            if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00")
            {
                query.Sql = "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                        + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail,city_id from teacher order by city,fname,lname";
            }
            else
            {
                query.Sql = "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                        + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail,city_id from teacher"
                        + " where city='" + lookUpCityF.Properties.GetDataSourceValue("city_name", lookUpCityF.ItemIndex).ToString().Trim() + "' order by fname,lname";
            }
            sqlDataTeacher.Queries.Clear();
            sqlDataTeacher.Queries.Add(query);
            sqlDataTeacher.Fill();
            bindTeacher.DataSource = sqlDataTeacher;
            bindTeacher.DataMember = "customQuery1";
            lookUpTeachers.Properties.DataSource = bindTeacher;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lookUpTeachers.ItemIndex > -1)
            {
                DialogResult SaveData = DevExpress.XtraEditors.XtraMessageBox.Show("Сохранить данные по преподавателю " + txtFName.Text + " ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (SaveData == System.Windows.Forms.DialogResult.Yes)
                {
                    var dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "victory_app";
                    if (dbCon.IsConnect())
                    {
                        try
                        {
                            string query = "update teacher set stavka=" + Convert.ToDouble(txtSal.Text.ToString().Trim()) + ", salary=" + Convert.ToDouble(txtSalHour.Text.ToString().Trim()) + ","
                                            + " bonus=" + Convert.ToDouble(txtSalBonus.Text.ToString().Trim()) + " where id=" + Convert.ToInt32(lblId.Text.Trim());
                            var cmd = new MySqlCommand(query, dbCon.Connection);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Проверьте цифровые значение(разделитель дроби) или " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btpPayPeriod_Click(object sender, EventArgs e)
        {
            int k1=0,k2=0,k3=0;
            if (chkStavka.Checked)
            {
                k1 = 1;
            }
            if (chkSalHour.Checked)
            {
                k2 = 1;
            }
            if (chkBonus.Checked)
            {
                k3 = 1;
            }
            var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query;
                        query = "select c.city_name as city,gj.teacher_code as teacher_code,"
                                    + " t.fname as teacher,ifnull(sum(gj.hour),0) as cnt_hour,t.stavka,t.salary,t.bonus"
                                    + " from group_journal gj, city c, group_list gl, teacher t where gj.city_code=c.city_id and gj.code_group=gl.code_group"
                                    + " and gj.teacher_code=t.code and (date_lesson between str_to_date('" + dateStart.DateTime.ToShortDateString() + "','%d.%m.%Y') and"
                                    + " str_to_date('" + dateEnd.DateTime.ToShortDateString() + "','%d.%m.%Y'))"
                                    + " and gj.city_code=" + lookUpTeachers.Properties.GetDataSourceValue("city_id", lookUpTeachers.ItemIndex).ToString().Trim()
                                    + " and gj.teacher_code='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'" 
                                    + " group by c.city_name,gl.subj_name,gj.teacher_code,t.fname,t.stavka,t.salary,t.bonus order by 1,2,4,3";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            double sal = 0;
                            int i = 0;
                            while (reader.Read())
                            {
                                txtCntHour.Text = (string)reader.GetString(3);
                                sal = Convert.ToDouble(txtCntHour.Text) * Convert.ToDouble(txtSalHour2.Text)*k2 + Convert.ToDouble(txtSal2.Text)*k1 + Convert.ToDouble(txtSalBonus2.Text)*k3;
                                txtSalary.Text = sal.ToString();
                            }
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
        }

        private void frmCardPrepod_Load(object sender, EventArgs e)
        {
            dateStart.Text = DateTime.Now.ToString("dd.MM.yyyy");
            dateEnd.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }
    }
}