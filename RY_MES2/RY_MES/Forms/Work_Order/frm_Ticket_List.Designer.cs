namespace RY_MES.Forms
{
    partial class frm_Ticket_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Ticket_List));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Complete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new RY_MES.ucGridControl();
            this.ucGridView2 = new RY_MES.ucGridView();
            this.gridControl2 = new RY_MES.ucGridControl();
            this.ucGridView4 = new RY_MES.ucGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView4)).BeginInit();
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
            this.pnl_Conditions.Controls.Add(this.panelControl1);
            this.pnl_Conditions.Size = new System.Drawing.Size(800, 40);
            this.pnl_Conditions.Controls.SetChildIndex(this.lc_Conditions, 0);
            this.pnl_Conditions.Controls.SetChildIndex(this.panelControl1, 0);
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
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_Delete);
            this.panelControl1.Controls.Add(this.btn_Complete);
            this.panelControl1.Controls.Add(this.btn_Search);
            this.panelControl1.Location = new System.Drawing.Point(570, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(229, 33);
            this.panelControl1.TabIndex = 2;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Delete.ImageOptions.SvgImage")));
            this.btn_Delete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Delete.Location = new System.Drawing.Point(10, 0);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(73, 33);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "작업취소";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Complete
            // 
            this.btn_Complete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Complete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Complete.ImageOptions.SvgImage")));
            this.btn_Complete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Complete.Location = new System.Drawing.Point(83, 0);
            this.btn_Complete.Name = "btn_Complete";
            this.btn_Complete.Size = new System.Drawing.Size(73, 33);
            this.btn_Complete.TabIndex = 2;
            this.btn_Complete.Text = "작업마감";
            this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Search.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Search.ImageOptions.SvgImage")));
            this.btn_Search.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Search.Location = new System.Drawing.Point(156, 0);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(73, 33);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "Search";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(800, 400);
            this.splitContainerControl1.SplitterPosition = 223;
            this.splitContainerControl1.TabIndex = 7;
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
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.ucGridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 223);
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
            this.ucGridView1.OptionsFind.AlwaysVisible = true;
            this.ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView1.OptionsView.ColumnAutoWidth = false;
            this.ucGridView1.OptionsView.ShowIndicator = false;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gridControl2);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(800, 167);
            this.splitContainerControl2.SplitterPosition = 512;
            this.splitContainerControl2.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.ucGridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(512, 167);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView2});
            // 
            // ucGridView2
            // 
            this.ucGridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView2.GridControl = this.gridControl1;
            this.ucGridView2.Name = "ucGridView2";
            this.ucGridView2.OptionsBehavior.AutoExpandAllGroups = true;
            this.ucGridView2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.ucGridView2.OptionsFind.AlwaysVisible = true;
            this.ucGridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView2.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView2.OptionsView.ColumnAutoWidth = false;
            this.ucGridView2.OptionsView.ShowIndicator = false;
            this.ucGridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.ucGridView2_RowClick);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.ucGridView4;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(278, 167);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.UseEmbeddedNavigator = true;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView4});
            // 
            // ucGridView4
            // 
            this.ucGridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView4.GridControl = this.gridControl2;
            this.ucGridView4.Name = "ucGridView4";
            this.ucGridView4.OptionsBehavior.AutoExpandAllGroups = true;
            this.ucGridView4.OptionsBehavior.AutoSelectAllInEditor = false;
            this.ucGridView4.OptionsFind.AlwaysVisible = true;
            this.ucGridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView4.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView4.OptionsView.ColumnAutoWidth = false;
            this.ucGridView4.OptionsView.ShowIndicator = false;
            // 
            // frm_Ticket_List
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Ticket_List";
            this.Text = "frm_WO_List";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.SizeChanged += new System.EventHandler(this.frm_SizeChanged);
            this.Controls.SetChildIndex(this.pnl_Conditions, 0);
            this.Controls.SetChildIndex(this.btn_Conditions, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).EndInit();
            this.pnl_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).EndInit();
            this.lc_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ucGridControl gridControl;
        private ucGridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Complete;
        private ucGridView ucGridView1;
        private ucGridView ucGridView2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private ucGridControl gridControl2;
        private ucGridView ucGridView4;
    }
}