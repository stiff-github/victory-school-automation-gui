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
    public partial class frmTeacher : DevExpress.XtraEditors.XtraForm
    {
        public frmTeacher()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
            sqlDataCity.Fill();
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
                        string query = "SELECT count(*) FROM teacher where maska=upper('" + txtMaska.Text.Trim() + "') and id not in (" + Convert.ToInt32(lblId.Text) + ")";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            if (Convert.ToInt32(result) == 0)
                            {
                                try
                                {
                                    query = "update teacher set code='" + txtCode.Text.Trim() + "',city='" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "',"
                                        + "fname='" + txtFName.Text.Trim() + "',lname='" + txtLName.Text.Trim() + "',sname='" + txtSName.Text.Trim() + "',date_birth=str_to_date('" + dateBirth.DateTime.ToShortDateString() + "','%d.%m.%Y'),"
                                        + "phone='" + txtTel.Text.Trim() + "',adres='" + txtAdres.Text.Trim() + "',descr='" + txtDescr.Text.Trim() + "',maska='" + txtMaska.Text.Trim() + "',"
                                        + "mail='" + txtMail.Text.Trim() + "',city_id='" + lblCity.Text.ToString().Trim() + "' where id=" + Convert.ToInt32(lblId.Text.Trim());
                                    cmd = new MySqlCommand(query, dbCon.Connection);
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                }
                                for (int i = 0; i < listLesson.ItemCount; i++)
                                {
                                    if (Convert.ToBoolean(listLesson.Items[i].CheckState))
                                    {
                                        try
                                        {
                                            query = "INSERT INTO teacher_subj(city,code,subj_name) VALUES ('" + lblCity.Text + "','" + txtCode.Text + "','" + listLesson.Items[i].Value + "')";
                                            cmd = new MySqlCommand(query, dbCon.Connection);
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch (Exception ex)
                                        {
                                            ; //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            query = "delete from teacher_subj where city='" + lblCity.Text + "' and code='" + txtCode.Text + "' and subj_name='" + listLesson.Items[i].Value + "'";
                                            cmd = new MySqlCommand(query, dbCon.Connection);
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch (Exception ex)
                                        {
                                            ; //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Преподаватель НЕ СОХРАНЕН! Код для входа в журнал уже существует, поменяйте на уникальный, например кодгорода+кодучителя.");
                            }
                        }
                    }
                    /*if (dbCon.IsConnect())
                    {
                        for (int i = 0; i < listLesson.ItemCount; i++)
                        {
                            if (Convert.ToBoolean(listLesson.Items[i].CheckState))
                            {
                                try
                                {
                                    string query = "INSERT INTO teacher_subj(city,code,subj_name) VALUES ('" + lblCity.Text + "','" + txtCode.Text + "','" + listLesson.Items[i].Value + "')";
                                    var cmd = new MySqlCommand(query, dbCon.Connection);
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    ; //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    string query = "delete from teacher_subj where city='" + lblCity.Text + "' and code='" + txtCode.Text + "' and subj_name='" + listLesson.Items[i].Value + "'";
                                    var cmd = new MySqlCommand(query, dbCon.Connection);
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    ; //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }*/
                    this.sqlDataTeacher.Fill();
                    lookUpTeachers.EditValue = txtCode.Text;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Преподаватель в этом городе с таким кодом уже существует..");
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "SELECT count(*) FROM teacher where upper(city)=upper('" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "') and upper(code)=upper('" + txtCode.Text.Trim() + "')";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) == 0)
                        {
                            query = "SELECT count(*) FROM teacher where maska=upper('" + txtMaska.Text.Trim() + "')";
                            cmd = new MySqlCommand(query, dbCon.Connection);
                            result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                if (Convert.ToInt32(result) == 0)
                                {
                                    try
                                    {
                                        query = "insert into teacher (code,city,fname,lname,sname,date_birth,phone,adres,descr,mail,city_id,maska) values ('" + txtCode.Text.Trim() + "','" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "','" + txtFName.Text.Trim() + "','" + txtLName.Text.Trim() + "','" + txtSName.Text.Trim() + "',str_to_date('" + dateBirth.DateTime.ToShortDateString() + "','%d.%m.%Y'),'" + txtTel.Text.Trim() + "','" + txtAdres.Text.Trim() + "','" + txtDescr.Text.Trim() + "','" + txtMail.Text.Trim() + "','" + lblCity.Text.ToString().Trim() + "','" + txtMaska.Text.Trim() + "');";
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                    }
                                    CustomSqlQuery query2 = new CustomSqlQuery();
                                    query2.Name = "customQuery1";
                                    if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00")
                                    {
                                        query2.Sql = "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                                                + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail from teacher order by city,fname,lname";
                                    }
                                    else
                                    {
                                        query2.Sql = "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                                                + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail from teacher"
                                                + " where city='" + lookUpCityF.Properties.GetDataSourceValue("city_name", lookUpCityF.ItemIndex).ToString().Trim() + "' order by fname,lname";
                                    }
                                    sqlDataTeacher.Queries.Clear();
                                    sqlDataTeacher.Queries.Add(query2);
                                    sqlDataTeacher.Fill();
                                    bindTeacher.DataSource = sqlDataTeacher;
                                    bindTeacher.DataMember = "customQuery1";
                                    lookUpTeachers.Properties.DataSource = bindTeacher;

                                    try
                                    {
                                        query = "SELECT id FROM teacher where upper(city)=upper('" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "') and upper(code)=upper('" + txtCode.Text.Trim() + "')";
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        var reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            lblId.Text = reader.GetDecimal(0).ToString();
                                        }
                                        reader.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                    }
                                    lookUpTeachers.EditValue = Convert.ToInt32(lblId.Text);

                                    listLesson.Items.Clear();
                                    try
                                    {
                                        query = "SELECT subj_name,1 as `check` FROM `teacher_subj`"
                                            + " WHERE city='" + lblCity.Text + "' and code='" + txtCode.Text + "'"
                                            + " union all SELECT subj_name,0 as `check` FROM `subject` WHERE subj_name not in"
                                            + " (SELECT subj_name FROM `teacher_subj` WHERE city='" + lblCity.Text + "' and code='" + txtCode.Text + "') order by subj_name";
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        var reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            listLesson.Items.Add(reader.GetString(0), Convert.ToBoolean((int)reader.GetDecimal(1)));
                                        }
                                        reader.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("Преподаватель НЕ СОЗДАН! Код для входа в журнал уже существует, поменяйте на уникальный, например кодгорода+кодучителя.");
                                }
                            }
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Преподаватель в этом городе с таким кодом уже существует..");
                        }
                    }

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
                        + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail from teacher order by city,fname,lname";
            }
            else
            {
                query.Sql = "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
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
            lblId.Text = lookUpTeachers.Properties.GetDataSourceValue("id", lookUpTeachers.ItemIndex).ToString().Trim();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "select code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                        + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail,ifnull(maska,' ') as maska from teacher"
                        + " where id=" + lookUpTeachers.Properties.GetDataSourceValue("id", lookUpTeachers.ItemIndex).ToString().Trim();
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtFName.Text = reader.GetString(2);
                        txtLName.Text = reader.GetString(3);
                        txtSName.Text = reader.GetString(4);
                        txtCode.Text = reader.GetString(0);
                        dateBirth.Text = reader.GetString(5); //date_format
                        lookUpCity.EditValue = lookUpCity.Properties.GetKeyValueByDisplayText((string)reader.GetString(1));
                        lblCity.Text = lookUpCity.Properties.GetDataSourceValue("city_id", lookUpCity.ItemIndex).ToString().Trim();
                        txtTel.Text = reader.GetString(6);
                        txtAdres.Text = reader.GetString(7);
                        txtDescr.Text = reader.GetString(8);
                        txtSal1.Text = reader.GetString(9);
                        txtMail.Text = reader.GetString(10);
                        txtMaska.Text = reader.GetString(11);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }

                listLesson.Items.Clear();
                try
                {
                    string query = "SELECT subj_name,1 as `check` FROM `teacher_subj`"
                        + " WHERE city='" + lblCity.Text + "' and code='" + txtCode.Text + "'"
                        + " union all SELECT subj_name,0 as `check` FROM `subject` WHERE subj_name not in"
                        + " (SELECT subj_name FROM `teacher_subj` WHERE city='" + lblCity.Text + "' and code='" + txtCode.Text + "') order by subj_name";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listLesson.Items.Add(reader.GetString(0), Convert.ToBoolean((int)reader.GetDecimal(1)));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void lookUpCity_EditValueChanged(object sender, EventArgs e)
        {
            lblCity.Text = lookUpCity.Properties.GetDataSourceValue("city_id", lookUpCity.ItemIndex).ToString().Trim();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult DelClient = DevExpress.XtraEditors.XtraMessageBox.Show("Вы уверены, что хотите удалить данные по преподавателю " + txtFName.Text.Trim() + " ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DelClient == System.Windows.Forms.DialogResult.Yes)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "delete from teacher_subj where city='" + lblCity.Text + "' and code='" + txtCode.Text + "'";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                    try
                    {
                        string query = "delete from teacher where id=" + Convert.ToInt32(lblId.Text.Trim());
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                    CustomSqlQuery query2 = new CustomSqlQuery();
                    query2.Name = "customQuery1";
                    if (lookUpCityF.Properties.GetDataSourceValue("city_id", lookUpCityF.ItemIndex).ToString().Trim() == "00")
                    {
                        query2.Sql = "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                                + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail from teacher order by city,fname,lname";
                    }
                    else
                    {
                        query2.Sql = "select id,code,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,ifnull(phone,' ') as phone,"
                                + " ifnull(adres,' ') as adres,ifnull(descr,' ') as descr,ifnull(salary,' ') as salary,ifnull(mail,' ') as mail from teacher"
                                + " where city='" + lookUpCityF.Properties.GetDataSourceValue("city_name", lookUpCityF.ItemIndex).ToString().Trim() + "' order by fname,lname";
                    }
                    sqlDataTeacher.Queries.Clear();
                    sqlDataTeacher.Queries.Add(query2);
                    sqlDataTeacher.Fill();
                    bindTeacher.DataSource = sqlDataTeacher;
                    bindTeacher.DataMember = "customQuery1";
                    lookUpTeachers.Properties.DataSource = bindTeacher;
                    lookUpTeachers.ItemIndex = 0;

                    listLesson.Items.Clear();
                    try
                    {
                        string query = "SELECT subj_name,1 as `check` FROM `teacher_subj`"
                            + " WHERE city='" + lblCity.Text + "' and code='" + txtCode.Text + "'"
                            + " union all SELECT subj_name,0 as `check` FROM `subject` WHERE subj_name not in"
                            + " (SELECT subj_name FROM `teacher_subj` WHERE city='" + lblCity.Text + "' and code='" + txtCode.Text + "') order by subj_name";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            listLesson.Items.Add(reader.GetString(0), Convert.ToBoolean((int)reader.GetDecimal(1)));
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

        private void btnSaveTime_Click(object sender, EventArgs e)
        {
            if (listLesson.SelectedIndex > -1)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "update teacher_subj set time='" + txtTimeSubject.Text.Trim() + "'"
                                    + " where city='" + lblCity.Text.Trim() + "' and code='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'"
                                    + " and subj_name='" + listLesson.Items[listLesson.SelectedIndex].Value + "'";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void listLesson_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "select ifnull(time,' ') as time from teacher_subj"
                        + " where city='" + lblCity.Text.Trim() + "' and code='" + lookUpTeachers.Properties.GetDataSourceValue("code", lookUpTeachers.ItemIndex).ToString().Trim() + "'"
                        + " and subj_name='" + listLesson.Items[listLesson.SelectedIndex].Value + "'";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtTimeSubject.Text = reader.GetString(0);
                        }
                    }
                    else
                    {
                        txtTimeSubject.Text = "";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtSName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
    }
}