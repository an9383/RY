namespace RY_MES.Forms
{
    partial class frm_EQUIP_Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EQUIP_Master));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.lc_edit = new DevExpress.XtraLayout.LayoutControl();
            this.txt_EQUIP_ID = new DevExpress.XtraEditors.TextEdit();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Back = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_DESC1 = new DevExpress.XtraEditors.TextEdit();
            this.txt_EQUIP_NAME = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.le_FA_ID = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.le_TEMPLATE_ID = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.de_OPEN_TIME = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_edit)).BeginInit();
            this.lc_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EQUIP_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESC1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EQUIP_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_FA_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_TEMPLATE_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_OPEN_TIME.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_OPEN_TIME.Properties)).BeginInit();
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
            this.pnl_Conditions.Size = new System.Drawing.Size(800, 40);
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.lc_edit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(800, 400);
            this.splitContainerControl1.SplitterPosition = 543;
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
            this.gridControl.Size = new System.Drawing.Size(543, 400);
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
            this.ucGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView1.OptionsView.ColumnAutoWidth = false;
            this.ucGridView1.OptionsView.ShowIndicator = false;
            // 
            // lc_edit
            // 
            this.lc_edit.Controls.Add(this.txt_EQUIP_ID);
            this.lc_edit.Controls.Add(this.btn_Delete);
            this.lc_edit.Controls.Add(this.btn_Back);
            this.lc_edit.Controls.Add(this.btn_Save);
            this.lc_edit.Controls.Add(this.txt_DESC1);
            this.lc_edit.Controls.Add(this.txt_EQUIP_NAME);
            this.lc_edit.Controls.Add(this.le_FA_ID);
            this.lc_edit.Controls.Add(this.le_TEMPLATE_ID);
            this.lc_edit.Controls.Add(this.de_OPEN_TIME);
            this.lc_edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lc_edit.Location = new System.Drawing.Point(0, 0);
            this.lc_edit.Name = "lc_edit";
            this.lc_edit.Root = this.Root;
            this.lc_edit.Size = new System.Drawing.Size(247, 400);
            this.lc_edit.TabIndex = 0;
            this.lc_edit.Text = "layoutControl1";
            // 
            // txt_EQUIP_ID
            // 
            this.txt_EQUIP_ID.Location = new System.Drawing.Point(12, 50);
            this.txt_EQUIP_ID.Name = "txt_EQUIP_ID";
            this.txt_EQUIP_ID.Size = new System.Drawing.Size(223, 20);
            this.txt_EQUIP_ID.StyleController = this.lc_edit;
            this.txt_EQUIP_ID.TabIndex = 5;
            // 
            // btn_Delete
            // 
            this.btn_Delete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Delete.ImageOptions.SvgImage")));
            this.btn_Delete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Delete.Location = new System.Drawing.Point(12, 340);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(223, 22);
            this.btn_Delete.StyleController = this.lc_edit;
            this.btn_Delete.TabIndex = 8;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Back.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Back.ImageOptions.SvgImage")));
            this.btn_Back.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Back.Location = new System.Drawing.Point(12, 366);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(109, 22);
            this.btn_Back.StyleController = this.lc_edit;
            this.btn_Back.TabIndex = 9;
            this.btn_Back.Text = "Back";
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Save.ImageOptions.SvgImage")));
            this.btn_Save.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Save.Location = new System.Drawing.Point(125, 366);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(110, 22);
            this.btn_Save.StyleController = this.lc_edit;
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_DESC1
            // 
            this.txt_DESC1.Location = new System.Drawing.Point(12, 255);
            this.txt_DESC1.Name = "txt_DESC1";
            this.txt_DESC1.Size = new System.Drawing.Size(223, 20);
            this.txt_DESC1.StyleController = this.lc_edit;
            this.txt_DESC1.TabIndex = 6;
            // 
            // txt_EQUIP_NAME
            // 
            this.txt_EQUIP_NAME.Location = new System.Drawing.Point(12, 91);
            this.txt_EQUIP_NAME.Name = "txt_EQUIP_NAME";
            this.txt_EQUIP_NAME.Size = new System.Drawing.Size(223, 20);
            this.txt_EQUIP_NAME.StyleController = this.lc_edit;
            this.txt_EQUIP_NAME.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem9,
            this.layoutControlItem1,
            this.layoutControlItem8,
            this.layoutControlItem10});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(247, 400);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_EQUIP_ID;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(227, 41);
            this.layoutControlItem2.Text = "EQUIP_ID";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(79, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_DESC1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 205);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(227, 41);
            this.layoutControlItem3.Text = "DESC1";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_Delete;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 307);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(227, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_Back;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 333);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(113, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btn_Save;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem7.Location = new System.Drawing.Point(113, 333);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(114, 26);
            this.layoutControlItem7.Text = "layoutControlItem5";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 246);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(227, 61);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txt_EQUIP_NAME;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem9.CustomizationFormText = "CELL_CODE";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 41);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(227, 41);
            this.layoutControlItem9.Text = "EQUIP_NAME";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(79, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.le_FA_ID;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem1.CustomizationFormText = "FA_ID";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(227, 41);
            this.layoutControlItem1.Text = "FA_ID";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(79, 14);
            // 
            // le_FA_ID
            // 
            this.le_FA_ID.Location = new System.Drawing.Point(12, 132);
            this.le_FA_ID.Name = "le_FA_ID";
            this.le_FA_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_FA_ID.Properties.NullText = "";
            this.le_FA_ID.Size = new System.Drawing.Size(223, 20);
            this.le_FA_ID.StyleController = this.lc_edit;
            this.le_FA_ID.TabIndex = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.le_TEMPLATE_ID;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem8.CustomizationFormText = "TEMPLATE_ID";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(227, 41);
            this.layoutControlItem8.Text = "TEMPLATE_ID";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(79, 14);
            // 
            // le_TEMPLATE_ID
            // 
            this.le_TEMPLATE_ID.Location = new System.Drawing.Point(12, 173);
            this.le_TEMPLATE_ID.Name = "le_TEMPLATE_ID";
            this.le_TEMPLATE_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_TEMPLATE_ID.Properties.NullText = "";
            this.le_TEMPLATE_ID.Properties.PopupView = this.searchLookUpEdit1View;
            this.le_TEMPLATE_ID.Size = new System.Drawing.Size(223, 20);
            this.le_TEMPLATE_ID.StyleController = this.lc_edit;
            this.le_TEMPLATE_ID.TabIndex = 5;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.de_OPEN_TIME;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem10.CustomizationFormText = "OPEN_TIME";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 164);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(227, 41);
            this.layoutControlItem10.Text = "OPEN_TIME";
            this.layoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(79, 14);
            // 
            // de_OPEN_TIME
            // 
            this.de_OPEN_TIME.EditValue = null;
            this.de_OPEN_TIME.Location = new System.Drawing.Point(12, 214);
            this.de_OPEN_TIME.Name = "de_OPEN_TIME";
            this.de_OPEN_TIME.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_OPEN_TIME.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_OPEN_TIME.Properties.DisplayFormat.FormatString = "";
            this.de_OPEN_TIME.Properties.EditFormat.FormatString = "";
            this.de_OPEN_TIME.Properties.Mask.EditMask = "";
            this.de_OPEN_TIME.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.de_OPEN_TIME.Size = new System.Drawing.Size(223, 20);
            this.de_OPEN_TIME.StyleController = this.lc_edit;
            this.de_OPEN_TIME.TabIndex = 6;
            // 
            // frm_EQUIP_Master
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_EQUIP_Master";
            this.Text = "Frm_Code_Master";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_edit)).EndInit();
            this.lc_edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_EQUIP_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESC1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EQUIP_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_FA_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_TEMPLATE_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_OPEN_TIME.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_OPEN_TIME.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl lc_edit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Back;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txt_DESC1;
        private DevExpress.XtraEditors.TextEdit txt_EQUIP_NAME;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit txt_EQUIP_ID;
        private ucGridControl gridControl;
        private ucGridView ucGridView1;
        private DevExpress.XtraEditors.LookUpEdit le_FA_ID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SearchLookUpEdit le_TEMPLATE_ID;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.DateEdit de_OPEN_TIME;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}