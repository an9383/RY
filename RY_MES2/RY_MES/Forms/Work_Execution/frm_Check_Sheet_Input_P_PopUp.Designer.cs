namespace RY_MES.Forms
{
    partial class frm_Check_Sheet_Input_P_PopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Check_Sheet_Input_P_PopUp));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(780, 513);
            this.panelControl1.TabIndex = 5;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(2, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowScrollBars = true;
            this.pictureEdit1.Size = new System.Drawing.Size(776, 473);
            this.pictureEdit1.TabIndex = 7;
            this.pictureEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pictureEdit1_KeyPress);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btn_Save);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 475);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(776, 36);
            this.panelControl3.TabIndex = 6;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Location = new System.Drawing.Point(624, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(150, 32);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "적용";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frm_Check_Sheet_Input_P_PopUp
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 513);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frm_Check_Sheet_Input_P_PopUp";
            this.Text = "Check Sheet";
            this.Load += new System.EventHandler(this.frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}