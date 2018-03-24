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
    public partial class frmSubject : DevExpress.XtraEditors.XtraForm
    {
        public frmSubject()
        {
            InitializeComponent();
            sqlDataSource1.Fill();
        }
        private void txtSubject_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lookUpSubject_EditValueChanged(object sender, EventArgs e)
        {
            txtCode.Text = lookUpSubject.EditValue.ToString();
            txtSubject.Text = lookUpSubject.Properties.GetDataSourceValue("subj_name", lookUpSubject.ItemIndex).ToString().Trim();
            txtDescr.Text = lookUpSubject.Properties.GetDataSourceValue("subj_descr", lookUpSubject.ItemIndex).ToString().Trim();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "SELECT count(*) FROM subject where upper(subj_name)=upper('" + txtSubject.Text.Trim() + "') or upper(subj_id)=upper('" + txtCode.Text.Trim() + "')";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) == 0)
                        {
                            try
                            {
                                query = "insert into subject (subj_name,subj_id,subj_descr) values ('" + txtSubject.Text.Trim() + "','" + txtCode.Text.Trim() + "','" + txtDescr.Text.Trim() + "');";
                                cmd = new MySqlCommand(query, dbCon.Connection);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                            }
                            this.sqlDataSource1.Fill();
                            lookUpSubject.EditValue = txtCode.Text;
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Такой предмет или код уже существуют..");
                        }
                    }

                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult DelClient = DevExpress.XtraEditors.XtraMessageBox.Show("Вы уверены, что хотите удалить предмет ?", "Подтвержедние", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DelClient == System.Windows.Forms.DialogResult.Yes)
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "victory_app";
                if (dbCon.IsConnect())
                {
                    try
                    {
                        string query = "delete from subject where subj_name='" + txtSubject.Text.Trim() + "';";
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                    }
                    this.sqlDataSource1.Fill();
                    lookUpSubject.ItemIndex = 0;
                }
            }
        }
    }
}