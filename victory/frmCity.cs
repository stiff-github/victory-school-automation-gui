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

namespace victory
{
    public partial class frmCity : DevExpress.XtraEditors.XtraForm
    {
        public frmCity()
        {
            InitializeComponent();
            sqlDataSource1.Fill();
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "SELECT count(*) FROM city where upper(city_name)=upper('" + txtCity.Text.Trim() + "') or upper(city_id)=upper('" + txtCode.Text.Trim() + "')";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) == 0)
                        {
                            try
                            {
                                query = "insert into city (city_name,city_id,city_descr) values ('" + txtCity.Text.Trim() + "','" + txtCode.Text.Trim() + "','" + txtDescr.Text.Trim() + "');";
                                cmd = new MySqlCommand(query, dbCon.Connection);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                            }
                            this.sqlDataSource1.Fill();
                            lookUpCity.EditValue = txtCode.Text;
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Такой город или код уже существуют..");
                        }
                    }

                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void lookUpCity_EditValueChanged(object sender, EventArgs e)
        {
            txtCode.Text = lookUpCity.EditValue.ToString();
            txtCity.Text = lookUpCity.Properties.GetDataSourceValue("city_name", lookUpCity.ItemIndex).ToString().Trim();
            txtDescr.Text = lookUpCity.Properties.GetDataSourceValue("city_descr", lookUpCity.ItemIndex).ToString().Trim();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult DelClient = DevExpress.XtraEditors.XtraMessageBox.Show("Вы уверены, что хотите удалить город ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DelClient == System.Windows.Forms.DialogResult.Yes)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "delete from city where city_name='" + txtCity.Text.Trim() + "';";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                    this.sqlDataSource1.Fill();
                    lookUpCity.ItemIndex = 0;
                }
            }
        }
    }
}