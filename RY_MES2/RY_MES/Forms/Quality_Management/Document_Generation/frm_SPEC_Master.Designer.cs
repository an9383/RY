namespace RY_MES.Forms
{
    partial class frm_SPEC_Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SPEC_Master));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.lc_edit = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Back = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_FT_ITEM_CODE = new DevExpress.XtraEditors.TextEdit();
            this.txt_ITEM_CODE = new DevExpress.XtraEditors.TextEdit();
            this.txt_SPEC_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_QC_ITEM_CODE = new DevExpress.XtraEditors.TextEdit();
            this.txt_SPEC = new DevExpress.XtraEditors.TextEdit();
            this.txt_SPEC_DESC = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_Delete = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.RegistSpec = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.txt_FT_ITEM_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SPEC_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_QC_ITEM_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SPEC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SPEC_DESC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
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
            this.pnl_Conditions.Controls.Add(this.RegistSpec);
            this.pnl_Conditions.Size = new System.Drawing.Size(800, 40);
            this.pnl_Conditions.Controls.SetChildIndex(this.lc_Conditions, 0);
            this.pnl_Conditions.Controls.SetChildIndex(this.RegistSpec, 0);
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
            this.splitContainerControl1.Size = new System.Drawing.Size(800, 668);
            this.splitContainerControl1.SplitterPosition = 553;
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
            this.gridControl.Size = new System.Drawing.Size(553, 668);
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
            this.lc_edit.Controls.Add(this.btn_Delete);
            this.lc_edit.Controls.Add(this.btn_Back);
            this.lc_edit.Controls.Add(this.btn_Save);
            this.lc_edit.Controls.Add(this.txt_FT_ITEM_CODE);
            this.lc_edit.Controls.Add(this.txt_ITEM_CODE);
            this.lc_edit.Controls.Add(this.txt_SPEC_NAME);
            this.lc_edit.Controls.Add(this.txt_QC_ITEM_CODE);
            this.lc_edit.Controls.Add(this.txt_SPEC);
            this.lc_edit.Controls.Add(this.txt_SPEC_DESC);
            this.lc_edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lc_edit.Location = new System.Drawing.Point(0, 0);
            this.lc_edit.Name = "lc_edit";
            this.lc_edit.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-903, 368, 650, 400);
            this.lc_edit.Root = this.Root;
            this.lc_edit.Size = new System.Drawing.Size(237, 668);
            this.lc_edit.TabIndex = 1;
            this.lc_edit.Text = "layoutControl1";
            // 
            // btn_Delete
            // 
            this.btn_Delete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Delete.ImageOptions.SvgImage")));
            this.btn_Delete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Delete.Location = new System.Drawing.Point(12, 608);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(213, 22);
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
            this.btn_Back.Location = new System.Drawing.Point(12, 634);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(104, 22);
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
            this.btn_Save.Location = new System.Drawing.Point(120, 634);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(105, 22);
            this.btn_Save.StyleController = this.lc_edit;
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_FT_ITEM_CODE
            // 
            this.txt_FT_ITEM_CODE.Location = new System.Drawing.Point(12, 91);
            this.txt_FT_ITEM_CODE.Name = "txt_FT_ITEM_CODE";
            this.txt_FT_ITEM_CODE.Size = new System.Drawing.Size(213, 20);
            this.txt_FT_ITEM_CODE.StyleController = this.lc_edit;
            this.txt_FT_ITEM_CODE.TabIndex = 6;
            // 
            // txt_ITEM_CODE
            // 
            this.txt_ITEM_CODE.Enabled = false;
            this.txt_ITEM_CODE.Location = new System.Drawing.Point(12, 50);
            this.txt_ITEM_CODE.Name = "txt_ITEM_CODE";
            this.txt_ITEM_CODE.Size = new System.Drawing.Size(213, 20);
            this.txt_ITEM_CODE.StyleController = this.lc_edit;
            this.txt_ITEM_CODE.TabIndex = 5;
            // 
            // txt_SPEC_NAME
            // 
            this.txt_SPEC_NAME.Location = new System.Drawing.Point(12, 173);
            this.txt_SPEC_NAME.Name = "txt_SPEC_NAME";
            this.txt_SPEC_NAME.Size = new System.Drawing.Size(213, 20);
            this.txt_SPEC_NAME.StyleController = this.lc_edit;
            this.txt_SPEC_NAME.TabIndex = 6;
            // 
            // txt_QC_ITEM_CODE
            // 
            this.txt_QC_ITEM_CODE.Location = new System.Drawing.Point(12, 132);
            this.txt_QC_ITEM_CODE.Name = "txt_QC_ITEM_CODE";
            this.txt_QC_ITEM_CODE.Size = new System.Drawing.Size(213, 20);
            this.txt_QC_ITEM_CODE.StyleController = this.lc_edit;
            this.txt_QC_ITEM_CODE.TabIndex = 6;
            // 
            // txt_SPEC
            // 
            this.txt_SPEC.Location = new System.Drawing.Point(12, 214);
            this.txt_SPEC.Name = "txt_SPEC";
            this.txt_SPEC.Size = new System.Drawing.Size(213, 20);
            this.txt_SPEC.StyleController = this.lc_edit;
            this.txt_SPEC.TabIndex = 6;
            // 
            // txt_SPEC_DESC
            // 
            this.txt_SPEC_DESC.Location = new System.Drawing.Point(12, 255);
            this.txt_SPEC_DESC.Name = "txt_SPEC_DESC";
            this.txt_SPEC_DESC.Size = new System.Drawing.Size(213, 20);
            this.txt_SPEC_DESC.StyleController = this.lc_edit;
            this.txt_SPEC_DESC.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.lc_Delete,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(237, 668);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_ITEM_CODE;
            this.layoutControlItem2.CustomizationFormText = "ITEM_CODE";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(217, 41);
            this.layoutControlItem2.Text = "ITEM_CODE";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(89, 14);
            // 
            // lc_Delete
            // 
            this.lc_Delete.Control = this.btn_Delete;
            this.lc_Delete.Location = new System.Drawing.Point(0, 575);
            this.lc_Delete.Name = "lc_Delete";
            this.lc_Delete.Size = new System.Drawing.Size(217, 26);
            this.lc_Delete.TextSize = new System.Drawing.Size(0, 0);
            this.lc_Delete.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_Back;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 601);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(108, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btn_Save;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem7.Location = new System.Drawing.Point(108, 601);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(109, 26);
            this.layoutControlItem7.Text = "layoutControlItem5";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 246);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(217, 329);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txt_SPEC_NAME;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem9.CustomizationFormText = "SPEC_NAME";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 41);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(175, 41);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(217, 41);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "SPEC_NAME";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(89, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txt_FT_ITEM_CODE;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem8.CustomizationFormText = "FT_ITEM_CODE";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 41);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 41);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(175, 41);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(217, 41);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "FT_ITEM_CODE";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(89, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_QC_ITEM_CODE;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem1.CustomizationFormText = "QC_ITEM_CODE";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 41);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(175, 41);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(217, 41);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "QC_ITEM_CODE";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(89, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_SPEC;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "SPEC";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 164);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 41);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(175, 41);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(217, 41);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "SPEC";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(89, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_SPEC_DESC;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem4.CustomizationFormText = "SPEC_DESC";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 205);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 41);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(175, 41);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(217, 41);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "SPEC_DESC";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(89, 14);
            // 
            // RegistSpec
            // 
            this.RegistSpec.Dock = System.Windows.Forms.DockStyle.Right;
            this.RegistSpec.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RegistWafer.ImageOptions.SvgImage")));
            this.RegistSpec.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.RegistSpec.Location = new System.Drawing.Point(720, 0);
            this.RegistSpec.Name = "RegistSpec";
            this.RegistSpec.Size = new System.Drawing.Size(80, 40);
            this.RegistSpec.TabIndex = 7;
            this.RegistSpec.Text = "SPEC 등록";
            this.RegistSpec.Click += new System.EventHandler(this.RegistSpec_Click);
            // 
            // frm_SPEC_Master
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 718);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_SPEC_Master";
            this.Text = "frm_DownTimeCode_Master";
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
            ((System.ComponentModel.ISupportInitialize)(this.txt_FT_ITEM_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SPEC_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_QC_ITEM_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SPEC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SPEC_DESC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl lc_edit;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Back;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.TextEdit txt_FT_ITEM_CODE;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem lc_Delete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit txt_ITEM_CODE;
        private ucGridControl gridControl;
        private DevExpress.XtraEditors.TextEdit txt_SPEC_NAME;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit txt_QC_ITEM_CODE;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txt_SPEC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txt_SPEC_DESC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton RegistSpec;
        private ucGridView ucGridView1;
    }
}