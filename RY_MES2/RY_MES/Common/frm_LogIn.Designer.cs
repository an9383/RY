using DevExpress.XtraEditors;

namespace nsCommon
{
    partial class frm_LogIn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LogIn));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.chk_Remember = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Error = new DevExpress.XtraEditors.LabelControl();
            this.txt_UID = new DevExpress.XtraEditors.TextEdit();
            this.txt_PWD = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Remember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(618, 292);
            this.panelControl1.TabIndex = 5;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.progressBarControl1);
            this.panelControl2.Controls.Add(this.chk_Remember);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.btn_Login);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.lbl_Error);
            this.panelControl2.Controls.Add(this.txt_UID);
            this.panelControl2.Controls.Add(this.txt_PWD);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 108);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(614, 150);
            this.panelControl2.TabIndex = 10;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(10, 94);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Size = new System.Drawing.Size(594, 18);
            this.progressBarControl1.TabIndex = 8;
            // 
            // chk_Remember
            // 
            this.chk_Remember.Location = new System.Drawing.Point(239, 92);
            this.chk_Remember.Name = "chk_Remember";
            this.chk_Remember.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk_Remember.Properties.Appearance.Options.UseFont = true;
            this.chk_Remember.Properties.Appearance.Options.UseTextOptions = true;
            this.chk_Remember.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chk_Remember.Properties.Caption = "Remember Me";
            this.chk_Remember.Size = new System.Drawing.Size(120, 19);
            this.chk_Remember.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(34, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 31);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "User ID";
            // 
            // btn_Login
            // 
            this.btn_Login.Appearance.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Login.Appearance.Options.UseFont = true;
            this.btn_Login.Location = new System.Drawing.Point(411, 13);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(174, 73);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "Log In";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(34, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(108, 31);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Password";
            // 
            // lbl_Error
            // 
            this.lbl_Error.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Appearance.Options.UseFont = true;
            this.lbl_Error.Appearance.Options.UseForeColor = true;
            this.lbl_Error.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_Error.Location = new System.Drawing.Point(10, 119);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(594, 21);
            this.lbl_Error.TabIndex = 7;
            // 
            // txt_UID
            // 
            this.txt_UID.EditValue = "";
            this.txt_UID.Location = new System.Drawing.Point(149, 12);
            this.txt_UID.Name = "txt_UID";
            this.txt_UID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txt_UID.Properties.Appearance.Options.UseFont = true;
            this.txt_UID.Size = new System.Drawing.Size(230, 32);
            this.txt_UID.TabIndex = 0;
            this.txt_UID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_UID_KeyPress);
            // 
            // txt_PWD
            // 
            this.txt_PWD.EditValue = "";
            this.txt_PWD.Location = new System.Drawing.Point(149, 52);
            this.txt_PWD.Name = "txt_PWD";
            this.txt_PWD.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txt_PWD.Properties.Appearance.Options.UseFont = true;
            this.txt_PWD.Properties.PasswordChar = '*';
            this.txt_PWD.Size = new System.Drawing.Size(230, 32);
            this.txt_PWD.TabIndex = 1;
            this.txt_PWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PWD_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 106);
            this.panel1.TabIndex = 6;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 258);
            this.panelControl3.LookAndFeel.SkinName = "Darkroom";
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(614, 32);
            this.panelControl3.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.Location = new System.Drawing.Point(2, 2);
            this.labelControl3.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.labelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(610, 28);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Copyright ⓒ 2020 VATECH IT TEAM. All rights reserved.";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_LogIn
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 292);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_LogIn.IconOptions.Icon")));
            this.Name = "frm_LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LogIn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_LogIn_FormClosed);
            this.Load += new System.EventHandler(this.frm_LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Remember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btn_Login;
        private DevExpress.XtraEditors.TextEdit txt_PWD;
        private DevExpress.XtraEditors.TextEdit txt_UID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_Error;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.CheckEdit chk_Remember;
        public ProgressBarControl progressBarControl1;
        private System.Windows.Forms.Timer timer1;
    }
}