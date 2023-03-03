namespace RY_MES.Forms
{
    partial class frm_Work_Ticket_4CELL_PopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Work_Ticket_4CELL_PopUp));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ucGridControl1 = new RY_MES.ucGridControl();
            this.ucGridView2 = new RY_MES.ucGridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            this.btn_Conditions.Size = new System.Drawing.Size(1242, 10);
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
            this.pnl_Conditions.Size = new System.Drawing.Size(1242, 40);
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
            this.panelControl1.Controls.Add(this.gridControl);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 50);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1242, 815);
            this.panelControl1.TabIndex = 5;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl.Location = new System.Drawing.Point(2, 38);
            this.gridControl.MainView = this.ucGridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(988, 775);
            this.gridControl.TabIndex = 1;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView1});
            // 
            // ucGridView1
            // 
            this.ucGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView1.GridControl = this.gridControl;
            this.ucGridView1.Name = "ucGridView1";
            this.ucGridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.ucGridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.ucGridView1.OptionsBehavior.Editable = false;
            this.ucGridView1.OptionsBehavior.ReadOnly = true;
            this.ucGridView1.OptionsFind.AlwaysVisible = true;
            this.ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView1.OptionsView.ColumnAutoWidth = false;
            this.ucGridView1.OptionsView.ShowIndicator = false;
            this.ucGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.ucGridView1_CustomDrawCell);
            this.ucGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.ucGridView1_FocusedRowChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.groupControl2);
            this.panelControl3.Controls.Add(this.groupControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(990, 38);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(250, 775);
            this.panelControl3.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ucGridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Enabled = false;
            this.groupControl2.Location = new System.Drawing.Point(2, 163);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(246, 610);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "TFT";
            // 
            // ucGridControl1
            // 
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
            this.ucGridControl1.Location = new System.Drawing.Point(2, 23);
            this.ucGridControl1.MainView = this.ucGridView2;
            this.ucGridControl1.Name = "ucGridControl1";
            this.ucGridControl1.Size = new System.Drawing.Size(242, 585);
            this.ucGridControl1.TabIndex = 1;
            this.ucGridControl1.UseEmbeddedNavigator = true;
            this.ucGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView2});
            this.ucGridControl1.EditorKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ucGridControl1_EditorKeyPress);
            // 
            // ucGridView2
            // 
            this.ucGridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView2.GridControl = this.ucGridControl1;
            this.ucGridView2.Name = "ucGridView2";
            this.ucGridView2.OptionsFind.AllowFindPanel = false;
            this.ucGridView2.OptionsFind.AllowMruItems = false;
            this.ucGridView2.OptionsView.AllowHtmlDrawGroups = false;
            this.ucGridView2.OptionsView.ColumnAutoWidth = false;
            this.ucGridView2.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.ucGridView2.OptionsView.ShowGroupPanel = false;
            this.ucGridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucGridView2_KeyDown);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.textEdit2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Enabled = false;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(246, 161);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "COMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "LOT 번호";
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "";
            this.textEdit2.Location = new System.Drawing.Point(9, 72);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit2.Size = new System.Drawing.Size(232, 20);
            this.textEdit2.TabIndex = 2;
            this.textEdit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit2_KeyDown);
            this.textEdit2.Leave += new System.EventHandler(this.textEdit2_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "투입수량";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "0";
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(9, 135);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.Mask.EditMask = "d";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Size = new System.Drawing.Size(232, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btn_Save);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1238, 36);
            this.panelControl2.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Location = new System.Drawing.Point(988, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(248, 32);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "작업 등록";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frm_Work_Ticket_4CELL_PopUp
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 865);
            this.ControlBox = true;
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_Work_Ticket_4CELL_PopUp.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Work_Ticket_4CELL_PopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work Ticket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Load);
            this.Controls.SetChildIndex(this.pnl_Conditions, 0);
            this.Controls.SetChildIndex(this.btn_Conditions, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).EndInit();
            this.pnl_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).EndInit();
            this.lc_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private ucGridControl gridControl;
        private ucGridView ucGridView1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private ucGridControl ucGridControl1;
        private ucGridView ucGridView2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit textEdit2;
    }
}