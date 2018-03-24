using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace victory
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        frmTest frmTestF;
        frmScholar frmScholarF;
        frmTeacher frmTeacherF;
        frmCity frmCityF;
        frmSubject frmSubjectF;
        frmGroup frmGroupF;
        frmJournal frmJournalF;
        frmRptGroup1 frmRptGroup1F;
        frmCardPrepod frmCardPrepodF;
        frmPayment frmPaymentF;
        frmRptSubjHour frmRptSubjHourF;
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuTest_Click(object sender, EventArgs e)
        {
            if (frmTestF == null || frmTestF.IsDisposed)
            {
                frmTestF = new frmTest();
                frmTestF.MdiParent = this;
                frmTestF.Show();
            }
            else
            {
                frmTestF.Activate();
            }
        }

        private void mnuScholar_Click(object sender, EventArgs e)
        {
            if (frmScholarF == null || frmScholarF.IsDisposed)
            {
                frmScholarF = new frmScholar();
                frmScholarF.MdiParent = this;
                frmScholarF.Show();
            }
            else
            {
                frmScholarF.Activate();
            }
        }

        private void mnuTeacher_Click(object sender, EventArgs e)
        {
            if (frmTeacherF == null || frmTeacherF.IsDisposed)
            {
                frmTeacherF = new frmTeacher();
                frmTeacherF.MdiParent = this;
                frmTeacherF.Show();
            }
            else
            {
                frmTeacherF.Activate();
            }
        }

        private void mnuGroup_Click(object sender, EventArgs e)
        {
            if (frmGroupF == null || frmGroupF.IsDisposed)
            {
                frmGroupF = new frmGroup();
                frmGroupF.MdiParent = this;
                frmGroupF.Show();
            }
            else
            {
                frmGroupF.Activate();
            }
        }

        private void mnuCity_Click(object sender, EventArgs e)
        {
            if (frmCityF == null || frmCityF.IsDisposed)
            {
                frmCityF = new frmCity();
                frmCityF.MdiParent = this;
                frmCityF.Show();
            }
            else
            {
                frmCityF.Activate();
            }
        }

        private void mnuSubject_Click(object sender, EventArgs e)
        {
            if (frmSubjectF == null || frmSubjectF.IsDisposed)
            {
                frmSubjectF = new frmSubject();
                frmSubjectF.MdiParent = this;
                frmSubjectF.Show();
            }
            else
            {
                frmSubjectF.Activate();
            }
        }

        private void mnuJournalGroup_Click(object sender, EventArgs e)
        {
            if (frmJournalF == null || frmJournalF.IsDisposed)
            {
                frmJournalF = new frmJournal();
                frmJournalF.MdiParent = this;
                frmJournalF.Show();
            }
            else
            {
                frmJournalF.Activate();
            }
        }

        private void timerPingDb_Tick(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "victory_app";
            if (dbCon.IsConnect())
            {
                try
                {
                    string query99 = "select DATE_FORMAT(sysdate(),'%d.%m.%Y %H:%i:%s')";
                    var cmd99 = new MySqlCommand(query99, dbCon.Connection);
                    var reader99 = cmd99.ExecuteReader();
                    while (reader99.Read())
                    {
                        lblTimer.Text = (string)reader99.GetString(0);
                    }
                    reader99.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void mnuGroup1_Click(object sender, EventArgs e)
        {
            if (frmRptGroup1F == null || frmRptGroup1F.IsDisposed)
            {
                frmRptGroup1F = new frmRptGroup1();
                frmRptGroup1F.MdiParent = this;
                frmRptGroup1F.Show();
            }
            else
            {
                frmRptGroup1F.Activate();
            }
        }

        private void mnuBuhCardPrepod_Click(object sender, EventArgs e)
        {
            if (frmCardPrepodF == null || frmCardPrepodF.IsDisposed)
            {
                frmCardPrepodF = new frmCardPrepod();
                frmCardPrepodF.MdiParent = this;
                frmCardPrepodF.Show();
            }
            else
            {
                frmCardPrepodF.Activate();
            }
        }

        private void mnuBuhPayment_Click(object sender, EventArgs e)
        {
            if (frmPaymentF == null || frmPaymentF.IsDisposed)
            {
                frmPaymentF = new frmPayment();
                frmPaymentF.MdiParent = this;
                frmPaymentF.Show();
            }
            else
            {
                frmPaymentF.Activate();
            }
        }

        private void mnuSubjHour_Click(object sender, EventArgs e)
        {
            if (frmRptSubjHourF == null || frmRptSubjHourF.IsDisposed)
            {
                frmRptSubjHourF = new frmRptSubjHour();
                frmRptSubjHourF.MdiParent = this;
                frmRptSubjHourF.Show();
            }
            else
            {
                frmRptSubjHourF.Activate();
            }
        }
    }
}
