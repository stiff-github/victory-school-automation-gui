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
    public partial class frmTest : DevExpress.XtraEditors.XtraForm
    {
        public frmTest()
        {
            InitializeComponent();
        }
        private void btnClick_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "SELECT num,text FROM test where id=1";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    //cmd.ExecuteNonQuery();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lblTest.Text = reader.GetString(0) + " / " + reader.GetString(1);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
                /*finally
                {
                    dbCon.Close();
                }*/
            }
        }
    }
}