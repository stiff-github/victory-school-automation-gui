namespace victory
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClick = new DevExpress.XtraEditors.SimpleButton();
            this.lblTest = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(126, 120);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(75, 23);
            this.btnClick.TabIndex = 0;
            this.btnClick.Text = "btnClick";
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTest.Location = new System.Drawing.Point(34, 26);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(74, 23);
            this.lblTest.TabIndex = 1;
            this.lblTest.Text = "...";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnClick);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClick;
        private DevExpress.XtraEditors.LabelControl lblTest;
    }
}