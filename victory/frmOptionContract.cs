using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace victory
{
    public partial class frmOptionContract : Form
    {
        public frmOptionContract()
        {
            InitializeComponent();
        }

        private void frmOptionContract_Load(object sender, EventArgs e)
        {
            cmbContract.Items.Clear();
            cmbContract.Items.AddRange(Directory.GetFiles(System.Windows.Forms.Application.StartupPath + @"\\contract\\shablon\\", "*.xlsx").Select(x => Path.GetFileNameWithoutExtension(x)).ToArray());
            cmbContract.Text = "стандарт";
            /*List<string> filesname = Directory.GetFiles(System.Windows.Forms.Application.StartupPath + @"\\contract\\shablon\\", "*.xlsx", SearchOption.AllDirectories).ToList<string>();
            cmbContract.DataSource = filesname;*/

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ((frmScholar)this.Owner).lblNewContract.Text = cmbContract.Text;
        }
    }
}
