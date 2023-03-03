using DevExpress.XtraEditors;

namespace RY_MES.Forms
{
    partial class frm_SPEC_Popup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SPEC_Popup));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.le_PK_ITEM_CODE = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.le_QC_ITEM_CODE = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.le_FT_ITEM_CODE = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucGridControl1 = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.le_PK_ITEM_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_QC_ITEM_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_FT_ITEM_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            this.btn_Conditions.Size = new System.Drawing.Size(826, 10);
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
            this.pnl_Conditions.Size = new System.Drawing.Size(826, 40);
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
            this.panelControl1.Location = new System.Drawing.Point(0, 595);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(826, 42);
            this.panelControl1.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Location = new System.Drawing.Point(686, 2);
            this.btn_Save.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btn_Save.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(138, 38);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucGridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(826, 545);
            this.splitContainerControl1.SplitterPosition = 45;
            this.splitContainerControl1.TabIndex = 9;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.le_PK_ITEM_CODE);
            this.layoutControl1.Controls.Add(this.le_QC_ITEM_CODE);
            this.layoutControl1.Controls.Add(this.le_FT_ITEM_CODE);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(529, 259, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(826, 45);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // le_PK_ITEM_CODE
            // 
            this.le_PK_ITEM_CODE.Location = new System.Drawing.Point(55, 12);
            this.le_PK_ITEM_CODE.Name = "le_PK_ITEM_CODE";
            this.le_PK_ITEM_CODE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_PK_ITEM_CODE.Properties.NullText = "";
            this.le_PK_ITEM_CODE.Properties.PopupView = this.searchLookUpEdit1View;
            this.le_PK_ITEM_CODE.Size = new System.Drawing.Size(221, 20);
            this.le_PK_ITEM_CODE.StyleController = this.layoutControl1;
            this.le_PK_ITEM_CODE.TabIndex = 4;
            this.le_PK_ITEM_CODE.EditValueChanged += new System.EventHandler(this.le_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // le_QC_ITEM_CODE
            // 
            this.le_QC_ITEM_CODE.Location = new System.Drawing.Point(323, 12);
            this.le_QC_ITEM_CODE.Name = "le_QC_ITEM_CODE";
            this.le_QC_ITEM_CODE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_QC_ITEM_CODE.Properties.NullText = "";
            this.le_QC_ITEM_CODE.Properties.PopupView = this.searchLookUpEdit1View1;
            this.le_QC_ITEM_CODE.Size = new System.Drawing.Size(222, 20);
            this.le_QC_ITEM_CODE.StyleController = this.layoutControl1;
            this.le_QC_ITEM_CODE.TabIndex = 4;
            this.le_QC_ITEM_CODE.EditValueChanged += new System.EventHandler(this.le_EditValueChanged);
            // 
            // searchLookUpEdit1View1
            // 
            this.searchLookUpEdit1View1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View1.Name = "searchLookUpEdit1View1";
            this.searchLookUpEdit1View1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View1.OptionsView.ShowGroupPanel = false;
            // 
            // le_FT_ITEM_CODE
            // 
            this.le_FT_ITEM_CODE.Location = new System.Drawing.Point(592, 12);
            this.le_FT_ITEM_CODE.Name = "le_FT_ITEM_CODE";
            this.le_FT_ITEM_CODE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_FT_ITEM_CODE.Properties.NullText = "";
            this.le_FT_ITEM_CODE.Properties.PopupView = this.gridView1;
            this.le_FT_ITEM_CODE.Size = new System.Drawing.Size(222, 20);
            this.le_FT_ITEM_CODE.StyleController = this.layoutControl1;
            this.le_FT_ITEM_CODE.TabIndex = 5;
            this.le_FT_ITEM_CODE.EditValueChanged += new System.EventHandler(this.le_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 33.333333333333336D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 33.333333333333336D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 33.333333333333336D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1});
            this.Root.Size = new System.Drawing.Size(826, 45);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.le_PK_ITEM_CODE;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(268, 25);
            this.layoutControlItem1.Text = "PK 품번";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(40, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.le_QC_ITEM_CODE;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem2.Location = new System.Drawing.Point(268, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(269, 25);
            this.layoutControlItem2.Text = "QC 품번";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(40, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.le_FT_ITEM_CODE;
            this.layoutControlItem3.Location = new System.Drawing.Point(537, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(269, 25);
            this.layoutControlItem3.Text = "FT 품번";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(40, 14);
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
            this.ucGridControl1.Location = new System.Drawing.Point(0, 0);
            this.ucGridControl1.MainView = this.ucGridView1;
            this.ucGridControl1.Name = "ucGridControl1";
            this.ucGridControl1.Size = new System.Drawing.Size(826, 490);
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
            this.ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView1.OptionsView.ColumnAutoWidth = false;
            this.ucGridView1.OptionsView.ShowGroupPanel = false;
            this.ucGridView1.OptionsView.ShowIndicator = false;
            // 
            // frm_SPEC_Popup
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 637);
            this.ControlBox = true;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_SPEC_Popup.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_SPEC_Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPEC 등록";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.le_PK_ITEM_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_QC_ITEM_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_FT_ITEM_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private SearchLookUpEdit le_PK_ITEM_CODE;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private ucGridControl ucGridControl1;
        private ucGridView ucGridView1;
        private SearchLookUpEdit le_QC_ITEM_CODE;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View1;
        private SearchLookUpEdit le_FT_ITEM_CODE;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}