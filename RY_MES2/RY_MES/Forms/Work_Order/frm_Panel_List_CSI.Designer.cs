namespace RY_MES.Forms
{
    partial class frm_Panel_List_CSI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Panel_List_CSI));
            this.gridControl = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.btn_Out = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Reuse = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            this.btn_Conditions.Size = new System.Drawing.Size(800, 10);
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
            this.pnl_Conditions.Controls.Add(this.btn_Out);
            this.pnl_Conditions.Controls.Add(this.btn_Reuse);
            this.pnl_Conditions.Size = new System.Drawing.Size(800, 40);
            this.pnl_Conditions.Controls.SetChildIndex(this.btn_Reuse, 0);
            this.pnl_Conditions.Controls.SetChildIndex(this.lc_Conditions, 0);
            this.pnl_Conditions.Controls.SetChildIndex(this.btn_Out, 0);
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
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.gridControl.Location = new System.Drawing.Point(0, 50);
            this.gridControl.MainView = this.ucGridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 400);
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
            this.ucGridView1.OptionsFind.AlwaysVisible = true;
            this.ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView1.OptionsSelection.MultiSelect = true;
            this.ucGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView1.OptionsView.ColumnAutoWidth = false;
            this.ucGridView1.OptionsView.ShowIndicator = false;
            // 
            // btn_Out
            // 
            this.btn_Out.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Out.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Out.ImageOptions.SvgImage")));
            this.btn_Out.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Out.Location = new System.Drawing.Point(630, 0);
            this.btn_Out.Name = "btn_Out";
            this.btn_Out.Size = new System.Drawing.Size(80, 40);
            this.btn_Out.TabIndex = 5;
            this.btn_Out.Text = "Panel 마감";
            this.btn_Out.Click += new System.EventHandler(this.btn_Out_Click);
            // 
            // btn_Reuse
            // 
            this.btn_Reuse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Reuse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Reuse.ImageOptions.SvgImage")));
            this.btn_Reuse.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Reuse.Location = new System.Drawing.Point(710, 0);
            this.btn_Reuse.Name = "btn_Reuse";
            this.btn_Reuse.Size = new System.Drawing.Size(90, 40);
            this.btn_Reuse.TabIndex = 6;
            this.btn_Reuse.Text = "Panel 재투입";
            this.btn_Reuse.Click += new System.EventHandler(this.btn_Reuse_Click);
            // 
            // frm_Panel_List_CSI
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Panel_List_CSI";
            this.Text = "frm_WO_List";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.pnl_Conditions, 0);
            this.Controls.SetChildIndex(this.btn_Conditions, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).EndInit();
            this.pnl_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).EndInit();
            this.lc_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucGridControl gridControl;
        private ucGridView ucGridView1;
        private DevExpress.XtraEditors.SimpleButton btn_Out;
        private DevExpress.XtraEditors.SimpleButton btn_Reuse;
    }
}