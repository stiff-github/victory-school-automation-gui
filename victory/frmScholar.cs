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
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;

namespace victory
{
    public partial class frmScholar : DevExpress.XtraEditors.XtraForm
    {
        public frmScholar()
        {
            InitializeComponent();
            sqlDataCityF.Fill();
            sqlDataCity.Fill();
        }

        private void lookUpCityMasterF_EditValueChanged(object sender, EventArgs e)
        {
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "customQuery1";
            if (lookUpCityMasterF.Properties.GetDataSourceValue("city_id", lookUpCityMasterF.ItemIndex).ToString().Trim() == "00")
            {
                query.Sql = "select '00' as id, ' ' as city, '_все_' as fname, ' ' as lname, ' ' as sname, ' ' as mobile, ' ' as num_private" 
                    + " union all select id,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(mobile,' ') as mobile,"
                    + " ifnull(num_private,' ') as num_private from master"
                    + " order by fname,lname,sname";
            }
            else
            {
                query.Sql = "select '00' as id, ' ' as city, '_все_' as fname, ' ' as lname, ' ' as sname, ' ' as mobile, ' ' as num_private"
                    + " union all select id,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(mobile,' ') as mobile,"
                    + " ifnull(num_private,' ') as num_private from master"
                    + " where city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by fname,lname,sname";
            }
            sqlDataMaster.Queries.Clear();
            sqlDataMaster.Queries.Add(query);
            sqlDataMaster.Fill();
            bindMaster.DataSource = sqlDataMaster;
            bindMaster.DataMember = "customQuery1";
            lookUpMasters.Properties.DataSource = bindMaster;
            //lookUpMasters.ItemIndex = 0;
            if (lookUpMasters.ItemIndex>-1)
            {
                CustomSqlQuery query2 = new CustomSqlQuery();
                query2.Name = "customQuery1";
                if (lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim() != "00")
                {
                    if (lookUpCityMasterF.Properties.GetDataSourceValue("city_id", lookUpCityMasterF.ItemIndex).ToString().Trim() == "00")
                    {
                        query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                        + " ifnull(num_school,' ') as num_school, id_master from scholar where"
                        + " id_master=" + Convert.ToInt32(lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim()) + " order by code,fname,lname,sname";
                    }
                    else
                    {
                        query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                        + " ifnull(num_school,' ') as num_school, id_master from scholar where"
                        + " id_master=" + Convert.ToInt32(lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim()) + ""
                        + " and city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by code,fname,lname,sname";
                    }
                }
                else
                {
                    if (lookUpCityMasterF.Properties.GetDataSourceValue("city_id", lookUpCityMasterF.ItemIndex).ToString().Trim() == "00")
                    {
                        query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                        + " ifnull(num_school,' ') as num_school, id_master from scholar order by code,fname,lname,sname";
                    }
                    else
                    {
                        query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                        + " ifnull(num_school,' ') as num_school, id_master from scholar where"
                        + " city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by code,fname,lname,sname";
                    }
                }
                sqlDataScholar.Queries.Clear();
                sqlDataScholar.Queries.Add(query2);
                sqlDataScholar.Fill();
                bindScholar.DataSource = sqlDataScholar;
                bindScholar.DataMember = "customQuery1";
                lookUpScholars.Properties.DataSource = bindScholar;
            }
            else
            {
                bindScholar.DataSource = null;
                lookUpScholars.Properties.DataSource = bindScholar;
            }
        }

        private void lookUpMasters_EditValueChanged(object sender, EventArgs e)
        {
            txtCodeWeb.Enabled = false;
            txtDescrM.Text = lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim();
            lblMasterId.Text = lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    if (lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim() != "00")
                    {
                        string query = "select id,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname, ifnull(pasport_num,' ') as pasport_num, ifnull(num_private,' ') as num_private,"
                        + " ifnull(pasport_vidan,' ') as pasport_vidan, ifnull(propiska,' ') as propiska,"
                        + " ifnull(adres,' ') as adres,ifnull(mail,' ') as mail, ifnull(mobile,' ') as mobile, ifnull(phone,' ') as phone,ifnull(descr,' ') as descr from master"
                        + " where id=" + lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim();
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lookUpCity.EditValue = lookUpCity.Properties.GetKeyValueByDisplayText((string)reader.GetString(1));
                            lblCity.Text = lookUpCity.Properties.GetDataSourceValue("city_id", lookUpCity.ItemIndex).ToString().Trim();
                            txtFNameM.Text = reader.GetString(2);
                            txtLNameM.Text = reader.GetString(3);
                            txtSNameM.Text = reader.GetString(4);
                            txtPassportNum.Text = reader.GetString(5);
                            txtPrivateNum.Text = reader.GetString(6);
                            txtPassportOut.Text = reader.GetString(7);
                            txtRegistr.Text = reader.GetString(8);
                            txtAdres.Text = reader.GetString(9);
                            txtMail.Text = reader.GetString(10);
                            txtMobile.Text = reader.GetString(11);
                            txtPhone.Text = reader.GetString(12);
                            txtDescrM.Text = reader.GetString(13);
                        }
                        reader.Close();
                    }
                    else
                    {
                        txtFNameM.Text = "";
                        txtLNameM.Text = "";
                        txtSNameM.Text = "";
                        txtPassportNum.Text = "";
                        txtPrivateNum.Text = "";
                        txtPassportOut.Text = "";
                        txtRegistr.Text = "";
                        txtAdres.Text = "";
                        txtMail.Text = "";
                        txtMobile.Text = "";
                        txtPhone.Text = "";
                        txtDescrM.Text = "";
                    }
                    CustomSqlQuery query2 = new CustomSqlQuery();
                    query2.Name = "customQuery1";
                    if (lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim() != "00")
                    {
                        if (lookUpCityMasterF.Properties.GetDataSourceValue("city_id", lookUpCityMasterF.ItemIndex).ToString().Trim() == "00")
                        {
                            query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                            + " ifnull(num_school,' ') as num_school, id_master from scholar where"
                            + " id_master=" + Convert.ToInt32(lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim()) + " order by code,fname,lname,sname";
                        }
                        else
                        {
                            query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                            + " ifnull(num_school,' ') as num_school, id_master from scholar where"
                            + " id_master=" + Convert.ToInt32(lookUpMasters.Properties.GetDataSourceValue("id", lookUpMasters.ItemIndex).ToString().Trim()) + ""
                            + " and city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by code,fname,lname,sname";
                        }
                    }
                    else
                    {
                        if (lookUpCityMasterF.Properties.GetDataSourceValue("city_id", lookUpCityMasterF.ItemIndex).ToString().Trim() == "00")
                        {
                            query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                            + " ifnull(num_school,' ') as num_school, id_master from scholar order by code,fname,lname,sname";
                        }
                        else
                        {
                            query2.Sql = "select id, city, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                            + " ifnull(num_school,' ') as num_school, id_master from scholar where"
                            + " city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by code,fname,lname,sname";
                        }
                    }
                    sqlDataScholar.Queries.Clear();
                    sqlDataScholar.Queries.Add(query2);
                    sqlDataScholar.Fill();
                    bindScholar.DataSource = sqlDataScholar;
                    bindScholar.DataMember = "customQuery1";
                    lookUpScholars.Properties.DataSource = bindScholar;
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void btnNewMaster_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "SELECT count(*) FROM master where upper(city)=upper('" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "') and upper(num_private)=upper('" + txtPrivateNum.Text.Trim() + "')";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) == 0)
                        {
                            try
                            {
                                query = "insert into master (city_id,city,fname,lname,sname,pasport_num,num_private,pasport_vidan,propiska,adres,mail,mobile,phone,descr) values"
                                    + " ('" + lblCity.Text.Trim() + "','" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "','"
                                    + txtFNameM.Text.Trim() + "','" + txtLNameM.Text.Trim() + "','" + txtSNameM.Text.Trim() + "','" + txtPassportNum.Text.Trim() + "','" + txtPrivateNum.Text.Trim() + "','"
                                    + txtPassportOut.Text.Trim() + "','" + txtRegistr.Text.Trim() + "','" + txtAdres.Text.Trim() + "','" + txtMail.Text.Trim() + "','" + txtMobile.Text.Trim() + "','"
                                    + txtPhone.Text.Trim() + "','" + txtDescrM.Text.Trim() + "');";
                                cmd = new MySqlCommand(query, dbCon.Connection);
                                cmd.ExecuteNonQuery();
                                query = "SELECT last_insert_id()";
                                    cmd = new MySqlCommand(query, dbCon.Connection);
                                    result = cmd.ExecuteScalar();
                                    if (result != null)
                                    {
                                        lblMasterId.Text = result.ToString();
                                    }
                                    else
                                    {
                                        lblMasterId.Text = "00";
                                    }
                            }
                            catch (Exception ex)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                            }
                            CustomSqlQuery query2 = new CustomSqlQuery();
                            query2.Name = "customQuery1";
                            query2.Sql = "select id,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(mobile,' ') as mobile,"
                                + " ifnull(num_private,' ') as num_private from master"
                                + " where city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by fname,lname,sname";
                            sqlDataMaster.Queries.Clear();
                            sqlDataMaster.Queries.Add(query2);
                            sqlDataMaster.Fill();
                            bindMaster.DataSource = sqlDataMaster;
                            bindMaster.DataMember = "customQuery1";
                            lookUpMasters.Properties.DataSource = bindMaster;
                            lookUpMasters.EditValue = Convert.ToInt32(lblMasterId.Text);

                            CustomSqlQuery query3 = new CustomSqlQuery();
                            query3.Name = "customQuery2";
                            query3.Sql = "select id, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(date_birth,' ') as date_birth,"
                                    + " ifnull(num_school,' ') as num_school from scholar where id_master=" + Convert.ToInt32(lblMasterId.Text) + " order by code,fname,lname,sname";
                            sqlDataScholar.Queries.Clear();
                            sqlDataScholar.Queries.Add(query3);
                            sqlDataScholar.Fill();
                            bindScholar.DataSource = sqlDataScholar;
                            bindScholar.DataMember = "customQuery2";
                            lookUpScholars.Properties.DataSource = bindScholar;
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Такой заказчик в этом городе уже существует..");
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSaveMaster_Click(object sender, EventArgs e)
        {
            if (lookUpMasters.ItemIndex > -1)
            {
                DialogResult SaveData = DevExpress.XtraEditors.XtraMessageBox.Show("Сохранить данные по заказчику " + txtFNameM.Text + " ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (SaveData == System.Windows.Forms.DialogResult.Yes)
                {
                    var dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "victory_app";
                    if (dbCon.IsConnect())
                    {
                        try
                        {
                            string query = "SELECT count(*) FROM master where upper(city)=upper('" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "') and upper(num_private)=upper('" + txtPrivateNum.Text.Trim() + "')";
                            var cmd = new MySqlCommand(query, dbCon.Connection);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                if (Convert.ToInt32(result) == 0)
                                {
                                    try
                                    {
                                        query = "update master set city_id='" + lblCity.Text.Trim() + "',city='" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "',"
                                            + "fname='" + txtFNameM.Text.Trim() + "',lname='" + txtLNameM.Text.Trim() + "',sname='" + txtSNameM.Text.Trim() + "',pasport_num='" + txtPassportNum.Text.Trim() + "',"
                                            + "num_private='" + txtPrivateNum.Text.Trim() + "',pasport_vidan='" + txtPassportOut.Text.Trim() + "',propiska='" + txtRegistr.Text.Trim() + "',adres='" + txtAdres.Text.Trim() + "',"
                                            + "mail='" + txtMail.Text.Trim() + "',mobile='" + txtMobile.Text.Trim() + "',phone='" + txtPhone.Text.Trim() + "',descr='" + txtDescrM.Text.Trim() + "'"
                                            + " where id=" + Convert.ToInt32(lblMasterId.Text.Trim());
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                    }
                                }
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Такой заказчик в этом городе уже существует..");
                            }
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }
                    CustomSqlQuery query2 = new CustomSqlQuery();
                    query2.Name = "customQuery1";
                    query2.Sql = "select id,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(mobile,' ') as mobile,"
                        + " ifnull(num_private,' ') as num_private from master"
                        + " where city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by fname,lname,sname";
                    sqlDataMaster.Queries.Clear();
                    sqlDataMaster.Queries.Add(query2);
                    sqlDataMaster.Fill();
                    bindMaster.DataSource = sqlDataMaster;
                    bindMaster.DataMember = "customQuery1";
                    lookUpMasters.Properties.DataSource = bindMaster;
                    lookUpMasters.EditValue = Convert.ToInt32(lblMasterId.Text);
                }
            }
        }

        private void btnNewScholar_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "SELECT count(*) FROM scholar where upper(code)=upper('" + txtCodeS.Text.Trim() + "') and id_master=" + Convert.ToInt32(lblMasterId.Text.Trim());
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) == 0)
                        {
                            try
                            {
                                query = "insert into scholar (id_master,code,city,fname,lname,sname,date_birth,num_school,city_id,descr) values"
                                    + " (" + Convert.ToInt32(lblMasterId.Text) + ",'" + txtCodeS.Text.Trim() + "','" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "',"
                                    + "'" + txtFNameS.Text.Trim() + "','" + txtLNameS.Text.Trim() + "','" + txtSNameS.Text.Trim() + "',str_to_date('" + dateBirth.DateTime.ToShortDateString() + "','%d.%m.%Y'),'"
                                    + txtSchool.Text.Trim() + "','" + lblCity.Text.Trim() + "','" + txtDescrS.Text.Trim() + "')";
                                cmd = new MySqlCommand(query, dbCon.Connection);
                                cmd.ExecuteNonQuery();
                                query = "SELECT last_insert_id()";
                                cmd = new MySqlCommand(query, dbCon.Connection);
                                result = cmd.ExecuteScalar();
                                if (result != null)
                                {
                                    lblScholarId.Text = result.ToString();
                                    txtCodeWeb.Text = txtFNameS.Text.Trim() + result.ToString();
                                    txtCodeWeb.Enabled = true;
                                    try
                                    {
                                        query = "update scholar set maska_scholar=lower('" + txtCodeWeb.Text.Trim() + "') where id=" + Convert.ToInt32(lblScholarId.Text);
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show("Код для входа в WEB журнал НЕ СОХРАНЕН!.");
                                    }
                                }
                                else
                                {
                                    lblScholarId.Text = "00";
                                }
                            }
                            catch (Exception ex)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                            }
                            CustomSqlQuery query3 = new CustomSqlQuery();
                            query3.Name = "customQuery1";
                            query3.Sql = "select id, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(date_birth,' ') as date_birth,"
                                    + " ifnull(num_school,' ') as num_school, city, id_master from scholar where id_master=" + Convert.ToInt32(lblMasterId.Text) + " order by code,fname,lname,sname";
                            sqlDataScholar.Queries.Clear();
                            sqlDataScholar.Queries.Add(query3);
                            sqlDataScholar.Fill();
                            bindScholar.DataSource = sqlDataScholar;
                            bindScholar.DataMember = "customQuery1";
                            lookUpScholars.Properties.DataSource = bindScholar;
                            lookUpScholars.EditValue = Convert.ToInt32(lblScholarId.Text);
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ученик у этого заказчика с таким кодом уже существует..");
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDeleteMaster_Click(object sender, EventArgs e)
        {
            DialogResult DelClient = DevExpress.XtraEditors.XtraMessageBox.Show("Вы уверены, что хотите удалить данные по заказчику " + txtFNameM.Text.Trim() + " ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DelClient == System.Windows.Forms.DialogResult.Yes)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "select count(*) from scholar where id_master=" + Convert.ToInt32(lblMasterId.Text);
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                if (Convert.ToInt32(result) == 0)
                                {
                                    try
                                    {
                                        query = "delete from master where id=" + Convert.ToInt32(lblMasterId.Text);
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                    }
                                    CustomSqlQuery query2 = new CustomSqlQuery();
                                    query2.Name = "customQuery1";
                                    query2.Sql = "select id,city,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(mobile,' ') as mobile,"
                                        + " ifnull(num_private,' ') as num_private from master"
                                        + " where city='" + lookUpCityMasterF.Properties.GetDataSourceValue("city_name", lookUpCityMasterF.ItemIndex).ToString().Trim() + "' order by fname,lname,sname";
                                    sqlDataMaster.Queries.Clear();
                                    sqlDataMaster.Queries.Add(query2);
                                    sqlDataMaster.Fill();
                                    bindMaster.DataSource = sqlDataMaster;
                                    bindMaster.DataMember = "customQuery1";
                                    lookUpMasters.Properties.DataSource = bindMaster;
                                    //lookUpMasters.EditValue = Convert.ToInt32(lblMasterId.Text);
                                    lookUpMasters.ItemIndex = -1;
                                }
                                else
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("Удаление невозможно, т.к. у заказчика существуют ученики..");
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

        private void btnSaveScholar_Click(object sender, EventArgs e)
        {
            if (lookUpScholars.ItemIndex > -1)
            {
                DialogResult SaveData = DevExpress.XtraEditors.XtraMessageBox.Show("Сохранить данные по ученику " + txtFNameS.Text + " ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (SaveData == System.Windows.Forms.DialogResult.Yes)
                {
                    var dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "victory_app";
                    if (dbCon.IsConnect())
                    {
                        string query = "SELECT count(*) FROM scholar where maska_scholar=lower('" + txtCodeWeb.Text.Trim() + "')";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            if (Convert.ToInt32(result) == 0 && txtCodeWeb.Text.Trim().Length>0)
                            {
                                try
                                {
                                    query = "update scholar set id_master=" + Convert.ToInt32(lblMasterId.Text) + ",code='" + txtCodeS.Text.Trim() + "',"
                                        + " city='" + lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim() + "',"
                                        + " fname='" + txtFNameS.Text.Trim() + "',lname='" + txtLNameS.Text.Trim() + "',sname='" + txtSNameS.Text.Trim() + "',"
                                        + " date_birth=str_to_date('" + dateBirth.DateTime.ToShortDateString() + "','%d.%m.%Y'),num_school='" + txtSchool.Text.Trim() + "',"
                                        + " city_id='" + lblCity.Text.Trim() + "',descr='" + txtDescrS.Text.Trim() + "',maska_scholar=lower('" + txtCodeWeb.Text.Trim() + "') where id=" + Convert.ToInt32(lblScholarId.Text);
                                    cmd = new MySqlCommand(query, dbCon.Connection);
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                }
                                for (int i = 0; i < listLessonNeed.ItemCount; i++)
                                {
                                    if (Convert.ToBoolean(listLessonNeed.Items[i].CheckState))
                                    {
                                        try
                                        {
                                            string query2 = "INSERT INTO scholar_subj(id_master,code,subj_name) VALUES (" + Convert.ToInt32(lblMasterId.Text) + ",'" + txtCodeS.Text + "','" + listLessonNeed.Items[i].Value + "')";
                                            var cmd2 = new MySqlCommand(query2, dbCon.Connection);
                                            cmd2.ExecuteNonQuery();
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
                                            string query2 = "delete from scholar_subj where status=0 and id_master=" + Convert.ToInt32(lblMasterId.Text) + " and code='" + txtCodeS.Text + "' and subj_name='" + listLessonNeed.Items[i].Value + "'";
                                            var cmd2 = new MySqlCommand(query2, dbCon.Connection);
                                            cmd2.ExecuteNonQuery();
                                        }
                                        catch (Exception ex)
                                        {
                                            ; //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                        }
                                    }
                                }
                                if (listLessonNeed.SelectedIndex > -1)
                                {
                                    try
                                    {
                                        int disc_type;
                                        if (chkPercent.Checked)
                                        {
                                            disc_type = 1;
                                        }
                                        else if (chkDiscont.Checked)
                                        {
                                            disc_type = 2;
                                        }
                                        else if (chkSpecPrice.Checked)
                                        {
                                            disc_type = 3;
                                        }
                                        else
                                        {
                                            disc_type = 0;
                                        }
                                        query = "update scholar_subj set contract='" + txtContract.Text.Trim() + "',time_work_week=" + Convert.ToInt32(chkWorkWeek.CheckState) + ","
                                                    + "time_saturday=" + Convert.ToInt32(chkSaturday.CheckState) + ",time_sunday=" + Convert.ToInt32(chkSunday.CheckState) + ","
                                                    + "time_0812=" + Convert.ToInt32(chk0812.CheckState) + ",time_1215=" + Convert.ToInt32(chk1215.CheckState) + ","
                                                    + "time_1517=" + Convert.ToInt32(chk1517.CheckState) + ",time_1721=" + Convert.ToInt32(chk1721.CheckState) + ","
                                                    + "discount_type=" + disc_type + ",discount_val=ifnull(" + Convert.ToDouble(txtDiscontVal.Text.Trim()) + ",0),"
                                                    + "payment=ifnull(" + Convert.ToDouble(txtPayment.Text.Trim()) + ",0),mark=ifnull(" + Convert.ToInt32(txtMark.Text.Trim()) + ",0)"
                                                    + " where id_master=" + Convert.ToInt32(lblMasterId.Text) + " and code='" + txtCodeS.Text.Trim() + "'"
                                                    + " and subj_name='" + listLessonNeed.Items[listLessonNeed.SelectedIndex].Value + "'";
                                        cmd = new MySqlCommand(query, dbCon.Connection);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                        DevExpress.XtraEditors.XtraMessageBox.Show("Данные по выделенному предмету не сохранены, не все поля числовые..");
                                    }
                                }
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Ученик НЕ СОХРАНЕН! Код для входа в WEB журнал уже существует, поменяйте на уникальный.");
                            }
                        }
                        CustomSqlQuery query3 = new CustomSqlQuery();
                        query3.Name = "customQuery1";
                        query3.Sql = "select id, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(date_birth,' ') as date_birth,"
                                + " ifnull(num_school,' ') as num_school from scholar where id_master=" + Convert.ToInt32(lblMasterId.Text) + " order by code,fname,lname,sname";
                        sqlDataScholar.Queries.Clear();
                        sqlDataScholar.Queries.Add(query3);
                        sqlDataScholar.Fill();
                        bindScholar.DataSource = sqlDataScholar;
                        bindScholar.DataMember = "customQuery1";
                        lookUpScholars.Properties.DataSource = bindScholar;
                        lookUpScholars.EditValue = Convert.ToInt32(lblScholarId.Text);
                    }
                }
            }
        }

        private void btnDeleteScholar_Click(object sender, EventArgs e)
        {
            DialogResult DelClient = DevExpress.XtraEditors.XtraMessageBox.Show("Вы уверены, что хотите удалить данные по ученику " + txtFNameS.Text.Trim() + " ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DelClient == System.Windows.Forms.DialogResult.Yes)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "delete from scholar_subj where id_master=" + Convert.ToInt32(lblMasterId.Text) + " and id=" + Convert.ToInt32(lblScholarId.Text.Trim());
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                    try
                    {
                        string query = "delete from scholar where id_master=" + Convert.ToInt32(lblMasterId.Text) + " and id=" + Convert.ToInt32(lblScholarId.Text.Trim());
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                    CustomSqlQuery query3 = new CustomSqlQuery();
                    query3.Name = "customQuery1";
                    query3.Sql = "select id, fname, ifnull(lname,' ') as lname, ifnull(sname,' ') as sname, code, ifnull(date_birth,' ') as date_birth,"
                            + " ifnull(num_school,' ') as num_school, city, id_master from scholar where id_master=" + Convert.ToInt32(lblMasterId.Text) + " order by code,fname,lname,sname";
                    sqlDataScholar.Queries.Clear();
                    sqlDataScholar.Queries.Add(query3);
                    sqlDataScholar.Fill();
                    bindScholar.DataSource = sqlDataScholar;
                    bindScholar.DataMember = "customQuery1";
                    lookUpScholars.Properties.DataSource = bindScholar;
                    lookUpScholars.EditValue = Convert.ToInt32(lblScholarId.Text);
                    lookUpScholars.ItemIndex = -1;
                }
            }
        }

        private void lookUpScholars_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblScholarId.Text = lookUpScholars.Properties.GetDataSourceValue("id", lookUpScholars.ItemIndex).ToString().Trim();
                if (lblMasterId.Text != lookUpScholars.Properties.GetDataSourceValue("id_master", lookUpScholars.ItemIndex).ToString().Trim())
                {
                    lookUpMasters.EditValue = lookUpScholars.Properties.GetDataSourceValue("id_master", lookUpScholars.ItemIndex).ToString().Trim();
                    lblScholarId.Text = lookUpScholars.Properties.GetDataSourceValue("id", lookUpScholars.ItemIndex).ToString().Trim();
                }
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "select code,fname,ifnull(lname,' ') as lname,ifnull(sname,' ') as sname,ifnull(DATE_FORMAT(date_birth,'%d.%m.%Y'),' ') as date_birth,"
                            + " ifnull(num_school,' ') as num_school, ifnull(descr,' ') as descr, maska_scholar from scholar"
                            + " where id=" + lookUpScholars.Properties.GetDataSourceValue("id", lookUpScholars.ItemIndex).ToString().Trim();
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            txtFNameS.Text = reader.GetString(1);
                            txtLNameS.Text = reader.GetString(2);
                            txtSNameS.Text = reader.GetString(3);
                            dateBirth.Text = reader.GetString(4);
                            txtSchool.Text = reader.GetString(5);
                            txtCodeS.Text = reader.GetString(0);
                            txtDescrS.Text = reader.GetString(6);
                            txtCodeWeb.Text = reader.GetString(7);
                            txtCodeWeb.Enabled = true;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }

                    listLessonNeed.Items.Clear();
                    try
                    {
                        string query = "SELECT subj_name,1 as `check` FROM `scholar_subj`"
                            + " WHERE id_master=" + Convert.ToInt32(lookUpScholars.Properties.GetDataSourceValue("id_master", lookUpScholars.ItemIndex).ToString().Trim()) + " and code='" + txtCodeS.Text + "' and status=0" //Convert.ToInt32(lblMasterId.Text)
                            + " union all SELECT subj_name,0 as `check` FROM `subject` WHERE subj_name not in"
                            + " (SELECT subj_name FROM `scholar_subj` WHERE id_master=" + Convert.ToInt32(lblMasterId.Text) + " and code='" + txtCodeS.Text + "' and status=0) order by subj_name";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            listLessonNeed.Items.Add(reader.GetString(0), Convert.ToBoolean((int)reader.GetDecimal(1)));
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                    if (listLessonNeed.ItemCount > 0)
                    {
                        try
                        {
                            string query = "select time_work_week,time_saturday,time_sunday,time_0812,time_1215,time_1517,time_1721,discount_type,discount_val"
                                + ",payment,mark,ifnull(contract,' ') as contract from scholar_subj"
                                + " where id_master=" + Convert.ToInt32(lookUpScholars.Properties.GetDataSourceValue("id_master", lookUpScholars.ItemIndex).ToString().Trim()) + " and code='" + txtCodeS.Text.Trim() + "'"
                                + " and subj_name='" + listLessonNeed.Items[listLessonNeed.SelectedIndex].Value + "'";
                            var cmd = new MySqlCommand(query, dbCon.Connection);
                            var reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    chkWorkWeek.Checked = Convert.ToBoolean((int)reader.GetDecimal(0));
                                    chkSaturday.Checked = Convert.ToBoolean((int)reader.GetDecimal(1));
                                    chkSunday.Checked = Convert.ToBoolean((int)reader.GetDecimal(2));
                                    chk0812.Checked = Convert.ToBoolean((int)reader.GetDecimal(3));
                                    chk1215.Checked = Convert.ToBoolean((int)reader.GetDecimal(4));
                                    chk1517.Checked = Convert.ToBoolean((int)reader.GetDecimal(5));
                                    chk1721.Checked = Convert.ToBoolean((int)reader.GetDecimal(6));
                                    if ((int)reader.GetDecimal(7) == 1)
                                    {
                                        chkPercent.Checked = true;
                                        chkDiscont.Checked = false;
                                        chkSpecPrice.Checked = false;
                                    }
                                    else if ((int)reader.GetDecimal(7) == 2)
                                    {
                                        chkPercent.Checked = false;
                                        chkDiscont.Checked = true;
                                        chkSpecPrice.Checked = false;
                                    }
                                    else if ((int)reader.GetDecimal(7) == 3)
                                    {
                                        chkPercent.Checked = false;
                                        chkDiscont.Checked = false;
                                        chkSpecPrice.Checked = true;
                                    }
                                    else
                                    {
                                        chkPercent.Checked = false;
                                        chkDiscont.Checked = false;
                                        chkSpecPrice.Checked = false;
                                    }
                                    txtDiscontVal.Text = reader.GetDecimal(8).ToString();
                                    txtPayment.Text = reader.GetDecimal(9).ToString();
                                    txtMark.Text = reader.GetDecimal(10).ToString();
                                    txtContract.Text = reader.GetString(11);
                                }
                            }
                            else
                            {
                                chkWorkWeek.Checked = false;
                                chkSaturday.Checked = false;
                                chkSunday.Checked = false;
                                chk0812.Checked = false;
                                chk1215.Checked = false;
                                chk1517.Checked = false;
                                chk1721.Checked = false;
                                chkPercent.Checked = false;
                                chkDiscont.Checked = false;
                                chkSpecPrice.Checked = false;
                                txtDiscontVal.Text = "";
                                txtPayment.Text = "";
                                txtMark.Text = "";
                                txtContract.Text = "";
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                        }
                    }

                    listNow.Items.Clear();
                    try
                    {
                        string query = "SELECT subj_name FROM `scholar_subj`"
                            + " WHERE id_master=" + Convert.ToInt32(lookUpScholars.Properties.GetDataSourceValue("id_master", lookUpScholars.ItemIndex).ToString().Trim()) + " and code='" + txtCodeS.Text + "' and status=1"
                            + " order by subj_name";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            listNow.Items.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }

                    listHistory.Items.Clear();
                    try
                    {
                        string query = "SELECT subj_name FROM scholar_subj"
                            + " WHERE id_master=" + Convert.ToInt32(lookUpScholars.Properties.GetDataSourceValue("id_master", lookUpScholars.ItemIndex).ToString().Trim()) + " and code='" + txtCodeS.Text + "' and status=2"
                            + " order by subj_name";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            listHistory.Items.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void frmScholar_Load(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query12 = "select var_value from var where var_name='folder_contract'";
                    var cmd12 = new MySqlCommand(query12, dbCon.Connection);
                    var readerF2 = cmd12.ExecuteReader();
                    while (readerF2.Read())
                    {
                        txtFolderContract.Text = (string)readerF2.GetString(0).Replace("^","\\");
                        if (System.IO.Directory.Exists(txtFolderContract.Text + @"\\shablon\\"))
                        {
                            txtFolderContract.BackColor = Color.White;
                        }
                        else
                        {
                            txtFolderContract.BackColor = Color.Red;
                        }
                    }
                    readerF2.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void chkPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPercent.Checked)
            {
                chkDiscont.Checked = false;
                chkSpecPrice.Checked=false;
                txtDiscontVal.Enabled = true;
            }
            else
            {
                txtDiscontVal.Text = "0";
                txtDiscontVal.Enabled = false;
            }
        }

        private void chkDiscont_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscont.Checked)
            {
                chkPercent.Checked = false;
                chkSpecPrice.Checked = false;
                txtDiscontVal.Enabled = true;
            }
            else
            {
                txtDiscontVal.Text = "0";
                txtDiscontVal.Enabled = false;
            }
        }

        private void chkSpecPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecPrice.Checked)
            {
                chkPercent.Checked = false;
                chkDiscont.Checked = false;
                txtDiscontVal.Enabled = true;
            }
            else
            {
                txtDiscontVal.Text = "0";
                txtDiscontVal.Enabled = false;
            }
        }

        private void listLessonNeed_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "select time_work_week,time_saturday,time_sunday,time_0812,time_1215,time_1517,time_1721,discount_type,discount_val"
                        + ",payment,mark,ifnull(contract,' ') as contract from scholar_subj"
                        + " where id_master=" + Convert.ToInt32(lblMasterId.Text) + " and code='" + txtCodeS.Text.Trim() + "'"
                        + " and subj_name='" + listLessonNeed.Items[listLessonNeed.SelectedIndex].Value + "'";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            chkWorkWeek.Checked = Convert.ToBoolean((int)reader.GetDecimal(0));
                            chkSaturday.Checked = Convert.ToBoolean((int)reader.GetDecimal(1));
                            chkSunday.Checked = Convert.ToBoolean((int)reader.GetDecimal(2));
                            chk0812.Checked = Convert.ToBoolean((int)reader.GetDecimal(3));
                            chk1215.Checked = Convert.ToBoolean((int)reader.GetDecimal(4));
                            chk1517.Checked = Convert.ToBoolean((int)reader.GetDecimal(5));
                            chk1721.Checked = Convert.ToBoolean((int)reader.GetDecimal(6));
                            if ((int)reader.GetDecimal(7) == 1)
                            {
                                chkPercent.Checked = true;
                                chkDiscont.Checked = false;
                                chkSpecPrice.Checked = false;
                            }
                            else if ((int)reader.GetDecimal(7) == 2)
                            {
                                chkPercent.Checked = false;
                                chkDiscont.Checked = true;
                                chkSpecPrice.Checked = false;
                            }
                            else if ((int)reader.GetDecimal(7) == 3)
                            {
                                chkPercent.Checked = false;
                                chkDiscont.Checked = false;
                                chkSpecPrice.Checked = true;
                            }
                            else
                            {
                                chkPercent.Checked = false;
                                chkDiscont.Checked = false;
                                chkSpecPrice.Checked = false;
                            }
                            txtDiscontVal.Text = reader.GetDecimal(8).ToString();
                            txtPayment.Text = reader.GetDecimal(9).ToString();
                            txtMark.Text = reader.GetDecimal(10).ToString();
                            txtContract.Text = reader.GetString(11);
                        }
                    }
                    else
                    {
                        chkWorkWeek.Checked = false;
                        chkSaturday.Checked = false;
                        chkSunday.Checked = false;
                        chk0812.Checked = false;
                        chk1215.Checked = false;
                        chk1517.Checked = false;
                        chk1721.Checked = false;
                        chkPercent.Checked = false;
                        chkDiscont.Checked = false;
                        chkSpecPrice.Checked = false;
                        txtDiscontVal.Text = "0";
                        txtPayment.Text = "0";
                        txtMark.Text = "0";
                        txtContract.Text = "";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void listNow_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "select ss.payment,ss.mark,ifnull(ss.contract,' ') as contract,gs.code_group,gl.schedule"
                        + " from scholar_subj ss, group_scholar gs, group_list gl, scholar s"
                        + " where s.id=gs.scholar_id and gs.code_group=gl.code_group and gs.scholar_id='" + lblScholarId.Text.Trim() + "'"
                        + " and gl.subj_name='" + listNow.SelectedValue.ToString() + "'  and ss.id_master='" + lblMasterId.Text.Trim() + "'"
                        + " and ss.id_master=s.id_master and s.code=ss.code";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtPayNow.Text = reader.GetDecimal(0).ToString();
                            txtMarkNow.Text = reader.GetDecimal(1).ToString();
                            txtContractNow.Text = reader.GetString(2);
                            txtContract.Text = reader.GetString(2);
                            txtGroupN.Text = reader.GetString(3);
                            txtSchedule.Text = reader.GetString(4);
                        }
                    }
                    else
                    {
                        txtPayNow.Text = "";
                        txtMarkNow.Text = "";
                        txtContractNow.Text = "";
                        txtGroupN.Text = "";
                        txtSchedule.Text = "";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void txtFNameM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtLNameM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtSNameM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtPassportNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtPrivateNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtPassportOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtRegistr_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtDescrM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtFNameS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtLNameS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtSNameS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtSchool_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtCodeS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            if (txtContract.Text.Trim().Length > 0)
            {
                try
                {
                    string[] FoundFiles = Directory.GetFiles(txtFolderContract.Text, txtContract.Text.Trim().Replace("/", "-") + ".*", SearchOption.AllDirectories);
                    string[] FoundFiles2 = Directory.GetFiles(txtFolderContract.Text, txtContract.Text.Trim().Replace("/", "^") + ".*", SearchOption.AllDirectories);
                    if (FoundFiles.Length > 0)
                    {
                        Process.Start(FoundFiles[0].ToString());
                    }
                    else if (FoundFiles2.Length > 0)
                    {
                        Process.Start(FoundFiles2[0].ToString());
                    }
                    else
                    {
                        Microsoft.Office.Interop.Excel.Application Exl = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook wb;
                        frmOptionContract OptionContract = new frmOptionContract();
                        OptionContract.Owner = this;
                        OptionContract.ShowDialog();
                        if (DialogResult.OK == OptionContract.DialogResult)
                        {
                            Exl.Visible = true;
                            String TemplatePath = txtFolderContract.Text + @"\shablon\" + lblNewContract.Text + ".xlsx";
                            try 
                            {
                                wb = Exl.Workbooks.Add(TemplatePath);
                                Excel._Worksheet sheet;
                                sheet = (Excel.Worksheet)wb.Worksheets.get_Item(1); //ссылка на лист excel

                                sheet.Cells[1, 1] = "ДОГОВОР № " + txtContract.Text.Trim(); //1035/6-7лет/ Иванов";
                                sheet.Cells[6, 1] = "«01» сентября 2017 г.";
                                sheet.Cells[6, 8] = "г. Жлобин";
                                sheet.Cells[10, 1] = txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim() + " " + txtSNameM.Text.Trim(); //"Иванова Иванка Ивановна";
                                sheet.Cells[17, 1] = txtFNameS.Text.Trim() + " " + txtLNameS.Text.Trim(); //"Иванов Иван";
                                sheet.Cells[20, 6] = listLessonNeed.Items[listLessonNeed.SelectedIndex].Value; //"Немецкий";

                                switch (lblNewContract.Text)
                                {
                                    case "АКЦИЯ процент":
                                        sheet.Cells[118, 6] = txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim() + " " + txtSNameM.Text.Trim();
                                        sheet.Cells[118, 6].Font.Underline = true;
                                        sheet.Cells[120, 6] = txtPassportNum.Text.Trim() + ", и/н " + txtPrivateNum.Text.Trim();
                                        sheet.Cells[120, 6].Font.Underline = true;
                                        sheet.Cells[122, 6] = txtPassportOut.Text.Trim();
                                        sheet.Cells[122, 6].Font.Underline = true;
                                        sheet.Cells[124, 6] = txtRegistr.Text.Trim();
                                        sheet.Cells[124, 6].Font.Underline = true;
                                        sheet.Cells[128, 6] = "_______________________ /" + txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim().Remove(1) + "." + txtSNameM.Text.Trim().Remove(1) + "./";
                                        break;
                                    case "ИЗО":
                                        sheet.Cells[118, 6] = txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim() + " " + txtSNameM.Text.Trim();
                                        sheet.Cells[118, 6].Font.Underline = true;
                                        sheet.Cells[120, 6] = txtPassportNum.Text.Trim() + ", и/н " + txtPrivateNum.Text.Trim();
                                        sheet.Cells[120, 6].Font.Underline = true;
                                        sheet.Cells[122, 6] = txtPassportOut.Text.Trim();
                                        sheet.Cells[122, 6].Font.Underline = true;
                                        sheet.Cells[124, 6] = txtRegistr.Text.Trim();
                                        sheet.Cells[124, 6].Font.Underline = true;
                                        sheet.Cells[128, 6] = "_______________________ /" + txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim().Remove(1) + "." + txtSNameM.Text.Trim().Remove(1) + "./";
                                        break;
                                    case "ИНД":
                                        sheet.Cells[113, 6] = txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim() + " " + txtSNameM.Text.Trim();
                                        sheet.Cells[113, 6].Font.Underline = true;
                                        sheet.Cells[115, 6] = txtPassportNum.Text.Trim() + ", и/н " + txtPrivateNum.Text.Trim();
                                        sheet.Cells[115, 6].Font.Underline = true;
                                        sheet.Cells[117, 6] = txtPassportOut.Text.Trim();
                                        sheet.Cells[117, 6].Font.Underline = true;
                                        sheet.Cells[119, 6] = txtRegistr.Text.Trim();
                                        sheet.Cells[119, 6].Font.Underline = true;
                                        sheet.Cells[123, 6] = "_______________________ /" + txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim().Remove(1) + "." + txtSNameM.Text.Trim().Remove(1) + "./";
                                        break;
                                    case "Светлогорск":
                                        sheet.Cells[127, 6] = txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim() + " " + txtSNameM.Text.Trim();
                                        sheet.Cells[127, 6].Font.Underline = true;
                                        sheet.Cells[129, 6] = txtPassportNum.Text.Trim() + ", и/н " + txtPrivateNum.Text.Trim();
                                        sheet.Cells[129, 6].Font.Underline = true;
                                        sheet.Cells[131, 6] = txtPassportOut.Text.Trim();
                                        sheet.Cells[131, 6].Font.Underline = true;
                                        sheet.Cells[133, 6] = txtRegistr.Text.Trim();
                                        sheet.Cells[133, 6].Font.Underline = true;
                                        sheet.Cells[137, 6] = "_______________________ /" + txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim().Remove(1) + "." + txtSNameM.Text.Trim().Remove(1) + "./";
                                        break;
                                    case "светлогорск 29р":
                                        sheet.Cells[107, 6] = txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim() + " " + txtSNameM.Text.Trim();
                                        sheet.Cells[107, 6].Font.Underline = true;
                                        sheet.Cells[109, 6] = txtPassportNum.Text.Trim() + ", и/н " + txtPrivateNum.Text.Trim();
                                        sheet.Cells[109, 6].Font.Underline = true;
                                        sheet.Cells[111, 6] = txtPassportOut.Text.Trim();
                                        sheet.Cells[111, 6].Font.Underline = true;
                                        sheet.Cells[113, 6] = txtRegistr.Text.Trim();
                                        sheet.Cells[113, 6].Font.Underline = true;
                                        sheet.Cells[117, 6] = "_______________________ /" + txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim().Remove(1) + "." + txtSNameM.Text.Trim().Remove(1) + "./";
                                        break;
                                    case "стандарт":
                                        sheet.Cells[125, 6] = txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim() + " " + txtSNameM.Text.Trim(); //"Иванова Иванка Ивановна";
                                        sheet.Cells[125, 6].Font.Underline = true;
                                        sheet.Cells[127, 6] = txtPassportNum.Text.Trim() + ", и/н " + txtPrivateNum.Text.Trim(); //"НВ 2555551, выдан 11.02.2515.";
                                        sheet.Cells[127, 6].Font.Underline = true;
                                        sheet.Cells[129, 6] = txtPassportOut.Text.Trim(); //"Жлобинским РОВД, и/н 4250381Н025РВ5";
                                        sheet.Cells[129, 6].Font.Underline = true;
                                        sheet.Cells[131, 6] = txtRegistr.Text.Trim(); //"г.Варшава, м-н Ромашка д. 7 кв. 77";
                                        sheet.Cells[131, 6].Font.Underline = true;
                                        sheet.Cells[135, 6] = "_______________________ /" + txtFNameM.Text.Trim() + " " + txtLNameM.Text.Trim().Remove(1) + "." + txtSNameM.Text.Trim().Remove(1) + "./";
                                        break;
                                }
                            }
                            catch (Exception ex2)
                            {
                                throw new Exception("Не удалось загрузить шаблон " + TemplatePath + "\n" + ex2.Message);
                            }
                            wb.Application.ActiveWorkbook.SaveAs(txtFolderContract.Text + @"\" + txtContract.Text.Trim().Replace("/", "^") + ".xlsx", Type.Missing,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtFolderContract.Text);
            }
            catch (Exception ex2)
            {
                throw new Exception("Не удалось открыть папку." + "\n" + ex2.Message);
            }
        }

        private void btnFolderSave_Click(object sender, EventArgs e)
        {
            DialogResult SaveFolder = DevExpress.XtraEditors.XtraMessageBox.Show("Сохранить путь к папке ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (SaveFolder == System.Windows.Forms.DialogResult.Yes)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query1 = "select var_value from var where var_name='folder_contract'";
                        var cmd1 = new MySqlCommand(query1, dbCon.Connection);
                        var readerF = cmd1.ExecuteReader();
                        if (readerF.HasRows)
                        {
                            readerF.Close();
                            /*string ololo;
                            ololo = @txtFolderContract.Text.Trim();*/
                            string query3 = "update var set var_value='" + txtFolderContract.Text.Trim().Replace("\\","^") + "' where var_name='folder_contract'";
                            var cmd3 = new MySqlCommand(query3, dbCon.Connection);
                            cmd3.ExecuteNonQuery();
                        }
                        else
                        {
                            readerF.Close();
                            string query2 = "insert into var(var_name,var_value) values ('folder_contract','" + txtFolderContract.Text.Trim() + "')";
                            var cmd2 = new MySqlCommand(query2, dbCon.Connection);
                            cmd2.ExecuteNonQuery();
                        }
                        if (System.IO.Directory.Exists(txtFolderContract.Text + @"\\shablon\\"))
                        {
                            txtFolderContract.BackColor = Color.White;
                        }
                        else
                        {
                            txtFolderContract.BackColor = Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnFolderLoad_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор папки хранения договоров";
            DirDialog.SelectedPath = @"D:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                txtFolderContract.Text = DirDialog.SelectedPath;
            }
        }
    }
}