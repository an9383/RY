namespace RY_MES.Forms
{
    partial class frm_Cell_DownTime_PopUp
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Cell_DownTime_PopUp));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.Root_D = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_DOWNTIME_NOTES = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root_D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DOWNTIME_NOTES.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            this.btn_Conditions.Location = new System.Drawing.Point(0, 758);
            this.btn_Conditions.Size = new System.Drawing.Size(948, 10);
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
            this.pnl_Conditions.Location = new System.Drawing.Point(0, 718);
            this.pnl_Conditions.Size = new System.Drawing.Size(948, 40);
            // 
            // lc_Conditions
            // 
            this.lc_Conditions.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1178, 0, 650, 400);
            this.lc_Conditions.Controls.SetChildIndex(this.de_To, 0);
            this.lc_Conditions.Controls.SetChildIndex(this.de_From, 0);
            // 
            // de_From
            // 
            this.de_From.Properties.DisplayFormat.FormatString = "d";
            this.de_From.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_From.Properties.EditFormat.FormatString = "d";
            this.de_From.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_From.Properties.Mask.EditMask = "d";
            this.de_From.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            // 
            // de_To
            // 
            this.de_To.Properties.DisplayFormat.FormatString = "d";
            this.de_To.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_To.Properties.EditFormat.FormatString = "d";
            this.de_To.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.de_To.Properties.Mask.EditMask = "d";
            this.de_To.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl3);
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(948, 718);
            this.panelControl1.TabIndex = 5;
            // 
            // layoutControl3
            // 
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(2, 152);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 468, 650, 400);
            this.layoutControl3.Root = this.Root_D;
            this.layoutControl3.Size = new System.Drawing.Size(944, 564);
            this.layoutControl3.TabIndex = 2;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // Root_D
            // 
            this.Root_D.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root_D.GroupBordersVisible = false;
            this.Root_D.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root_D.Name = "Root_D";
            this.Root_D.Size = new System.Drawing.Size(944, 564);
            this.Root_D.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(2, 62);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(944, 90);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(944, 90);
            this.Root.TextVisible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(944, 60);
            this.panelControl2.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.btn_Save);
            this.layoutControl2.Controls.Add(this.txt_DOWNTIME_NOTES);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(615, 249, 650, 400);
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(940, 56);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Location = new System.Drawing.Point(782, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(146, 32);
            this.btn_Save.StyleController = this.layoutControl2;
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "저장";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_DOWNTIME_NOTES
            // 
            this.txt_DOWNTIME_NOTES.Location = new System.Drawing.Point(129, 15);
            this.txt_DOWNTIME_NOTES.Name = "txt_DOWNTIME_NOTES";
            this.txt_DOWNTIME_NOTES.Size = new System.Drawing.Size(646, 20);
            this.txt_DOWNTIME_NOTES.StyleController = this.layoutControl2;
            this.txt_DOWNTIME_NOTES.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutControlGroup1.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 100D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition2.Width = 150D;
            this.layoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
            rowDefinition1.Height = 36D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.AutoSize;
            this.layoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1});
            this.layoutControlGroup1.Size = new System.Drawing.Size(940, 56);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_Save;
            this.layoutControlItem1.Location = new System.Drawing.Point(770, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(89, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem1.Size = new System.Drawing.Size(150, 36);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_DOWNTIME_NOTES;
            this.layoutControlItem3.CustomizationFormText = "DOWNTIME_NOTES";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(770, 36);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "DOWNTIME_NOTES";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(111, 14);
            // 
            // frm_Cell_DownTime_PopUp
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 718);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_Cell_DownTime_PopUp.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Cell_DownTime_PopUp";
            this.Text = "Down Time";
            this.Load += new System.EventHandler(this.frm_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnl_Conditions, 0);
            this.Controls.SetChildIndex(this.btn_Conditions, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).EndInit();
            this.pnl_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).EndInit();
            this.lc_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root_D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_DOWNTIME_NOTES.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.TextEdit txt_DOWNTIME_NOTES;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup Root_D;
    }
}