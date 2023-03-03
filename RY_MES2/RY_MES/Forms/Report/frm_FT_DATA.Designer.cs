namespace RY_MES.Forms
{
    partial class frm_FT_DATA
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.ucGridControl3 = new RY_MES.ucGridControl();
            this.ucGridView3 = new RY_MES.ucGridView();
            this.ucGridControl2 = new RY_MES.ucGridControl();
            this.ucGridView2 = new RY_MES.ucGridView();
            this.ucGridControl1 = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            this.btn_Conditions.Size = new System.Drawing.Size(1066, 10);
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
            this.pnl_Conditions.Size = new System.Drawing.Size(1066, 40);
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
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chartControl1);
            this.layoutControl1.Controls.Add(this.ucGridControl3);
            this.layoutControl1.Controls.Add(this.ucGridControl2);
            this.layoutControl1.Controls.Add(this.ucGridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 50);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(3143, 629, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1066, 576);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chartControl1
            // 
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(462, 12);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(592, 385);
            this.chartControl1.TabIndex = 4;
            // 
            // ucGridControl3
            // 
            this.ucGridControl3.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.First.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.ucGridControl3.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.ucGridControl3.Location = new System.Drawing.Point(462, 401);
            this.ucGridControl3.MainView = this.ucGridView3;
            this.ucGridControl3.Name = "ucGridControl3";
            this.ucGridControl3.Size = new System.Drawing.Size(592, 163);
            this.ucGridControl3.TabIndex = 1;
            this.ucGridControl3.UseEmbeddedNavigator = true;
            this.ucGridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView3});
            // 
            // ucGridView3
            // 
            this.ucGridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView3.GridControl = this.ucGridControl3;
            this.ucGridView3.Name = "ucGridView3";
            this.ucGridView3.OptionsBehavior.AutoExpandAllGroups = true;
            this.ucGridView3.OptionsBehavior.AutoSelectAllInEditor = false;
            this.ucGridView3.OptionsFind.AlwaysVisible = true;
            this.ucGridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView3.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView3.OptionsView.ColumnAutoWidth = false;
            this.ucGridView3.OptionsView.ShowIndicator = false;
            // 
            // ucGridControl2
            // 
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
            this.ucGridControl2.Location = new System.Drawing.Point(162, 12);
            this.ucGridControl2.MainView = this.ucGridView2;
            this.ucGridControl2.Name = "ucGridControl2";
            this.ucGridControl2.Size = new System.Drawing.Size(296, 552);
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
            this.ucGridView2.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.ucGridView2_SelectionChanged);
            // 
            // ucGridControl1
            // 
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
            this.ucGridControl1.Location = new System.Drawing.Point(12, 12);
            this.ucGridControl1.MainView = this.ucGridView1;
            this.ucGridControl1.Name = "ucGridControl1";
            this.ucGridControl1.Size = new System.Drawing.Size(146, 552);
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
            this.ucGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.ucGridView1_FocusedRowChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 150D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition2.Width = 300D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
            rowDefinition1.Height = 70D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 30D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2});
            this.Root.Size = new System.Drawing.Size(1066, 576);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.RowSpan = 2;
            this.layoutControlItem1.Size = new System.Drawing.Size(150, 556);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ucGridControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(150, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.OptionsTableLayoutItem.RowSpan = 2;
            this.layoutControlItem2.Size = new System.Drawing.Size(300, 556);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ucGridControl3;
            this.layoutControlItem3.Location = new System.Drawing.Point(450, 389);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem3.Size = new System.Drawing.Size(596, 167);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chartControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(450, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem4.Size = new System.Drawing.Size(596, 389);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frm_FT_DATA
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 626);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_FT_DATA";
            this.Text = "Frm_Code_Master";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.pnl_Conditions, 0);
            this.Controls.SetChildIndex(this.btn_Conditions, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).EndInit();
            this.pnl_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).EndInit();
            this.lc_Conditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private ucGridControl ucGridControl3;
        private ucGridView ucGridView3;
        private ucGridControl ucGridControl2;
        private ucGridView ucGridView2;
        private ucGridControl ucGridControl1;
        private ucGridView ucGridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}