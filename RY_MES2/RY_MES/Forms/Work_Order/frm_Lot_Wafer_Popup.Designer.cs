namespace RY_MES.Forms
{
    partial class frm_Lot_Wafer_Popup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Lot_Wafer_Popup));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_LOT_NO = new DevExpress.XtraEditors.LabelControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.ucGridControl2 = new RY_MES.ucGridControl();
            this.ucGridView2 = new RY_MES.ucGridView();
            this.ucGridControl1 = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Insert = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            this.btn_Conditions.Location = new System.Drawing.Point(0, 92);
            this.btn_Conditions.Size = new System.Drawing.Size(832, 10);
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
            this.pnl_Conditions.Location = new System.Drawing.Point(0, 52);
            this.pnl_Conditions.Size = new System.Drawing.Size(832, 40);
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
            this.panelControl1.Controls.Add(this.btn_Save);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 650);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(832, 48);
            this.panelControl1.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Location = new System.Drawing.Point(692, 2);
            this.btn_Save.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btn_Save.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(138, 44);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbl_LOT_NO);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(832, 52);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // lbl_LOT_NO
            // 
            this.lbl_LOT_NO.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lbl_LOT_NO.Appearance.Options.UseFont = true;
            this.lbl_LOT_NO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LOT_NO.Location = new System.Drawing.Point(20, 10);
            this.lbl_LOT_NO.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.lbl_LOT_NO.Name = "lbl_LOT_NO";
            this.lbl_LOT_NO.Size = new System.Drawing.Size(182, 33);
            this.lbl_LOT_NO.TabIndex = 0;
            this.lbl_LOT_NO.Text = "labelControl1";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.ucGridControl2);
            this.tablePanel1.Controls.Add(this.ucGridControl1);
            this.tablePanel1.Controls.Add(this.panelControl2);
            this.tablePanel1.Controls.Add(this.labelControl2);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 102);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(832, 548);
            this.tablePanel1.TabIndex = 10;
            // 
            // ucGridControl2
            // 
            this.tablePanel1.SetColumn(this.ucGridControl2, 2);
            this.ucGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridControl2.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.First.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.ucGridControl2.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.ucGridControl2.Location = new System.Drawing.Point(444, 29);
            this.ucGridControl2.MainView = this.ucGridView2;
            this.ucGridControl2.Name = "ucGridControl2";
            this.tablePanel1.SetRow(this.ucGridControl2, 1);
            this.ucGridControl2.Size = new System.Drawing.Size(385, 516);
            this.ucGridControl2.TabIndex = 1;
            this.ucGridControl2.UseEmbeddedNavigator = true;
            this.ucGridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView2});
            // 
            // ucGridView2
            // 
            this.ucGridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView2.GridControl = this.ucGridControl2;
            this.ucGridView2.Name = "ucGridView2";
            this.ucGridView2.OptionsBehavior.AutoExpandAllGroups = true;
            this.ucGridView2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.ucGridView2.OptionsFind.AlwaysVisible = true;
            this.ucGridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView2.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView2.OptionsView.ColumnAutoWidth = false;
            this.ucGridView2.OptionsView.ShowIndicator = false;
            // 
            // ucGridControl1
            // 
            this.tablePanel1.SetColumn(this.ucGridControl1, 0);
            this.ucGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.ucGridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.ucGridControl1.Location = new System.Drawing.Point(3, 29);
            this.ucGridControl1.MainView = this.ucGridView1;
            this.ucGridControl1.Name = "ucGridControl1";
            this.tablePanel1.SetRow(this.ucGridControl1, 1);
            this.ucGridControl1.Size = new System.Drawing.Size(385, 516);
            this.ucGridControl1.TabIndex = 1;
            this.ucGridControl1.UseEmbeddedNavigator = true;
            this.ucGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView1});
            // 
            // ucGridView1
            // 
            this.ucGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView1.GridControl = this.ucGridControl1;
            this.ucGridView1.Name = "ucGridView1";
            this.ucGridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.ucGridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.ucGridView1.OptionsFind.AlwaysVisible = true;
            this.ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView1.OptionsView.ColumnAutoWidth = false;
            this.ucGridView1.OptionsView.ShowIndicator = false;
            // 
            // panelControl2
            // 
            this.tablePanel1.SetColumn(this.panelControl2, 1);
            this.panelControl2.Controls.Add(this.btn_Insert);
            this.panelControl2.Controls.Add(this.btn_Delete);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(394, 29);
            this.panelControl2.Name = "panelControl2";
            this.tablePanel1.SetRow(this.panelControl2, 1);
            this.panelControl2.Size = new System.Drawing.Size(44, 516);
            this.panelControl2.TabIndex = 4;
            // 
            // btn_Insert
            // 
            this.btn_Insert.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Insert.Appearance.Options.UseForeColor = true;
            this.btn_Insert.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Insert.ImageOptions.SvgImage")));
            this.btn_Insert.Location = new System.Drawing.Point(0, 173);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Insert.Size = new System.Drawing.Size(44, 23);
            this.btn_Insert.TabIndex = 5;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Delete.Appearance.Options.UseForeColor = true;
            this.btn_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Delete.ImageOptions.SvgImage")));
            this.btn_Delete.Location = new System.Drawing.Point(0, 234);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Delete.Size = new System.Drawing.Size(44, 23);
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.labelControl2, 2);
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(444, 3);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.labelControl2.Name = "labelControl2";
            this.tablePanel1.SetRow(this.labelControl2, 0);
            this.labelControl2.Size = new System.Drawing.Size(368, 20);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "등록 가능 Wafer";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(20, 3);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(368, 20);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "mapping Wafer";
            // 
            // frm_Lot_Wafer_Popup
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 698);
            this.ControlBox = true;
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_Lot_Wafer_Popup.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Lot_Wafer_Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lot 생성 및 수정";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.pnl_Conditions, 0);
            this.Controls.SetChildIndex(this.btn_Conditions, 0);
            this.Controls.SetChildIndex(this.tablePanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).EndInit();
            this.pnl_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).EndInit();
            this.lc_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lbl_LOT_NO;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Insert;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private ucGridControl ucGridControl2;
        private ucGridView ucGridView2;
        private ucGridControl ucGridControl1;
        private ucGridView ucGridView1;
    }
}