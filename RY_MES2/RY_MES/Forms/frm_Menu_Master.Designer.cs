namespace RY_MES.Forms
{
    partial class frm_Menu_Master
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.lc_edit = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Back = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_MENU_CODE = new DevExpress.XtraEditors.TextEdit();
            this.txt_MENU_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_MENU_DESC = new DevExpress.XtraEditors.TextEdit();
            this.txt_MENU_URL = new DevExpress.XtraEditors.TextEdit();
            this.txt_ORDERBY = new DevExpress.XtraEditors.TextEdit();
            this.txt_DESC1 = new DevExpress.XtraEditors.TextEdit();
            this.txt_DESC2 = new DevExpress.XtraEditors.TextEdit();
            this.lg_SUPER_MENU_CODE = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.item2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.item3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.item4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.item5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.item6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.item7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_edit)).BeginInit();
            this.lc_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_DESC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_URL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ORDERBY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESC1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESC2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lg_SUPER_MENU_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item7)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
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
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.lc_edit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(820, 692);
            this.splitContainerControl1.SplitterPosition = 451;
            this.splitContainerControl1.TabIndex = 7;
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsDragAndDrop.CanCloneNodesOnDrop = true;
            this.treeList1.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Multiple;
            this.treeList1.OptionsFind.AlwaysVisible = true;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.treeList1.OptionsView.RootCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.None;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.Size = new System.Drawing.Size(451, 688);
            this.treeList1.TabIndex = 0;
            this.treeList1.AfterDropNode += new DevExpress.XtraTreeList.AfterDropNodeEventHandler(this.treeList1_AfterDropNode);
            this.treeList1.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList_CustomDrawNodeCell);
            this.treeList1.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeList_PopupMenuShowing);
            this.treeList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeList1_DragDrop);
            // 
            // lc_edit
            // 
            this.lc_edit.Controls.Add(this.btn_Delete);
            this.lc_edit.Controls.Add(this.btn_Back);
            this.lc_edit.Controls.Add(this.btn_Save);
            this.lc_edit.Controls.Add(this.txt_MENU_CODE);
            this.lc_edit.Controls.Add(this.txt_MENU_NAME);
            this.lc_edit.Controls.Add(this.txt_MENU_DESC);
            this.lc_edit.Controls.Add(this.txt_MENU_URL);
            this.lc_edit.Controls.Add(this.txt_ORDERBY);
            this.lc_edit.Controls.Add(this.txt_DESC1);
            this.lc_edit.Controls.Add(this.txt_DESC2);
            this.lc_edit.Controls.Add(this.lg_SUPER_MENU_CODE);
            this.lc_edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lc_edit.Location = new System.Drawing.Point(0, 0);
            this.lc_edit.Name = "lc_edit";
            this.lc_edit.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(128, 165, 650, 400);
            this.lc_edit.Root = this.Root;
            this.lc_edit.Size = new System.Drawing.Size(355, 688);
            this.lc_edit.TabIndex = 2;
            this.lc_edit.Text = "layoutControl1";
            // 
            // btn_Delete
            // 
            this.btn_Delete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Delete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Delete.Location = new System.Drawing.Point(12, 628);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(331, 22);
            this.btn_Delete.StyleController = this.lc_edit;
            this.btn_Delete.TabIndex = 9;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Back.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Back.Location = new System.Drawing.Point(12, 654);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(163, 22);
            this.btn_Back.StyleController = this.lc_edit;
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Text = "Back";
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Save.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Save.Location = new System.Drawing.Point(179, 654);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(164, 22);
            this.btn_Save.StyleController = this.lc_edit;
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_MENU_CODE
            // 
            this.txt_MENU_CODE.Enabled = false;
            this.txt_MENU_CODE.Location = new System.Drawing.Point(12, 47);
            this.txt_MENU_CODE.Name = "txt_MENU_CODE";
            this.txt_MENU_CODE.Size = new System.Drawing.Size(331, 20);
            this.txt_MENU_CODE.StyleController = this.lc_edit;
            this.txt_MENU_CODE.TabIndex = 6;
            // 
            // txt_MENU_NAME
            // 
            this.txt_MENU_NAME.Location = new System.Drawing.Point(12, 123);
            this.txt_MENU_NAME.Name = "txt_MENU_NAME";
            this.txt_MENU_NAME.Size = new System.Drawing.Size(331, 20);
            this.txt_MENU_NAME.StyleController = this.lc_edit;
            this.txt_MENU_NAME.TabIndex = 7;
            // 
            // txt_MENU_DESC
            // 
            this.txt_MENU_DESC.Location = new System.Drawing.Point(12, 161);
            this.txt_MENU_DESC.Name = "txt_MENU_DESC";
            this.txt_MENU_DESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_MENU_DESC.Size = new System.Drawing.Size(331, 20);
            this.txt_MENU_DESC.StyleController = this.lc_edit;
            this.txt_MENU_DESC.TabIndex = 7;
            // 
            // txt_MENU_URL
            // 
            this.txt_MENU_URL.Location = new System.Drawing.Point(12, 199);
            this.txt_MENU_URL.Name = "txt_MENU_URL";
            this.txt_MENU_URL.Size = new System.Drawing.Size(331, 20);
            this.txt_MENU_URL.StyleController = this.lc_edit;
            this.txt_MENU_URL.TabIndex = 7;
            // 
            // txt_ORDERBY
            // 
            this.txt_ORDERBY.Location = new System.Drawing.Point(12, 237);
            this.txt_ORDERBY.Name = "txt_ORDERBY";
            this.txt_ORDERBY.Properties.Mask.EditMask = "d";
            this.txt_ORDERBY.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_ORDERBY.Size = new System.Drawing.Size(331, 20);
            this.txt_ORDERBY.StyleController = this.lc_edit;
            this.txt_ORDERBY.TabIndex = 7;
            // 
            // txt_DESC1
            // 
            this.txt_DESC1.Location = new System.Drawing.Point(12, 275);
            this.txt_DESC1.Name = "txt_DESC1";
            this.txt_DESC1.Size = new System.Drawing.Size(331, 20);
            this.txt_DESC1.StyleController = this.lc_edit;
            this.txt_DESC1.TabIndex = 7;
            // 
            // txt_DESC2
            // 
            this.txt_DESC2.Location = new System.Drawing.Point(12, 313);
            this.txt_DESC2.Name = "txt_DESC2";
            this.txt_DESC2.Size = new System.Drawing.Size(331, 20);
            this.txt_DESC2.StyleController = this.lc_edit;
            this.txt_DESC2.TabIndex = 7;
            // 
            // lg_SUPER_MENU_CODE
            // 
            this.lg_SUPER_MENU_CODE.Location = new System.Drawing.Point(12, 85);
            this.lg_SUPER_MENU_CODE.Name = "lg_SUPER_MENU_CODE";
            this.lg_SUPER_MENU_CODE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lg_SUPER_MENU_CODE.Properties.NullText = "";
            this.lg_SUPER_MENU_CODE.Properties.PopupView = this.searchLookUpEdit1View;
            this.lg_SUPER_MENU_CODE.Size = new System.Drawing.Size(331, 20);
            this.lg_SUPER_MENU_CODE.StyleController = this.lc_edit;
            this.lg_SUPER_MENU_CODE.TabIndex = 7;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem3,
            this.item2,
            this.item3,
            this.item4,
            this.item5,
            this.item6,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.item7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(355, 688);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.btn_Back;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 621);
            this.layoutControlItem14.Name = "layoutControlItem1";
            this.layoutControlItem14.Size = new System.Drawing.Size(167, 26);
            this.layoutControlItem14.Text = "Back";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btn_Save;
            this.layoutControlItem15.Location = new System.Drawing.Point(167, 621);
            this.layoutControlItem15.Name = "layoutControlItem3";
            this.layoutControlItem15.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem15.Text = "Save";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txt_MENU_CODE;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem16.Name = "layoutControlItem4";
            this.layoutControlItem16.Size = new System.Drawing.Size(335, 38);
            this.layoutControlItem16.Text = "MENU_CODE";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem16.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(70, 14);
            this.layoutControlItem16.TextToControlDistance = 0;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_MENU_NAME;
            this.layoutControlItem3.CustomizationFormText = "MENU_NAME";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem3.Name = "item1";
            this.layoutControlItem3.Size = new System.Drawing.Size(335, 38);
            this.layoutControlItem3.Text = "MENU_NAME";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(71, 14);
            this.layoutControlItem3.TextToControlDistance = 0;
            // 
            // item2
            // 
            this.item2.Control = this.txt_MENU_DESC;
            this.item2.CustomizationFormText = "MENU_DESC";
            this.item2.Location = new System.Drawing.Point(0, 114);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(335, 38);
            this.item2.Text = "MENU_DESC";
            this.item2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.item2.TextLocation = DevExpress.Utils.Locations.Top;
            this.item2.TextSize = new System.Drawing.Size(68, 14);
            this.item2.TextToControlDistance = 0;
            // 
            // item3
            // 
            this.item3.Control = this.txt_MENU_URL;
            this.item3.CustomizationFormText = "MENU_URL";
            this.item3.Location = new System.Drawing.Point(0, 152);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(335, 38);
            this.item3.Text = "MENU_URL";
            this.item3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.item3.TextLocation = DevExpress.Utils.Locations.Top;
            this.item3.TextSize = new System.Drawing.Size(60, 14);
            this.item3.TextToControlDistance = 0;
            // 
            // item4
            // 
            this.item4.Control = this.txt_ORDERBY;
            this.item4.CustomizationFormText = "ORDERBY";
            this.item4.Location = new System.Drawing.Point(0, 190);
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(335, 38);
            this.item4.Text = "ORDERBY";
            this.item4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.item4.TextLocation = DevExpress.Utils.Locations.Top;
            this.item4.TextSize = new System.Drawing.Size(53, 14);
            this.item4.TextToControlDistance = 0;
            // 
            // item5
            // 
            this.item5.Control = this.txt_DESC1;
            this.item5.CustomizationFormText = "DESC1";
            this.item5.Location = new System.Drawing.Point(0, 228);
            this.item5.Name = "item5";
            this.item5.Size = new System.Drawing.Size(335, 38);
            this.item5.Text = "DESC1";
            this.item5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.item5.TextLocation = DevExpress.Utils.Locations.Top;
            this.item5.TextSize = new System.Drawing.Size(36, 14);
            this.item5.TextToControlDistance = 0;
            // 
            // item6
            // 
            this.item6.Control = this.txt_DESC2;
            this.item6.CustomizationFormText = "DESC2";
            this.item6.Location = new System.Drawing.Point(0, 266);
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(335, 38);
            this.item6.Text = "DESC2";
            this.item6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.item6.TextLocation = DevExpress.Utils.Locations.Top;
            this.item6.TextSize = new System.Drawing.Size(36, 14);
            this.item6.TextToControlDistance = 0;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 304);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(335, 291);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_Delete;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 595);
            this.layoutControlItem1.Name = "item0";
            this.layoutControlItem1.Size = new System.Drawing.Size(335, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // item7
            // 
            this.item7.Control = this.lg_SUPER_MENU_CODE;
            this.item7.CustomizationFormText = "SUPER_MENU_CODE";
            this.item7.Location = new System.Drawing.Point(0, 38);
            this.item7.Name = "item7";
            this.item7.Size = new System.Drawing.Size(335, 38);
            this.item7.Text = "SUPER_MENU_CODE";
            this.item7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.item7.TextLocation = DevExpress.Utils.Locations.Top;
            this.item7.TextSize = new System.Drawing.Size(113, 14);
            this.item7.TextToControlDistance = 0;
            // 
            // frm_Menu_Master
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 742);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Menu_Master";
            this.Text = "frm_USER_Master";
            this.Load += new System.EventHandler(this.frm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_edit)).EndInit();
            this.lc_edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_DESC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MENU_URL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ORDERBY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESC1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESC2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lg_SUPER_MENU_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraLayout.LayoutControl lc_edit;
        private DevExpress.XtraEditors.SimpleButton btn_Back;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.TextEdit txt_MENU_CODE;
        private DevExpress.XtraEditors.TextEdit txt_MENU_NAME;
        private DevExpress.XtraEditors.TextEdit txt_MENU_DESC;
        private DevExpress.XtraEditors.TextEdit txt_MENU_URL;
        private DevExpress.XtraEditors.TextEdit txt_ORDERBY;
        private DevExpress.XtraEditors.TextEdit txt_DESC1;
        private DevExpress.XtraEditors.TextEdit txt_DESC2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem item2;
        private DevExpress.XtraLayout.LayoutControlItem item3;
        private DevExpress.XtraLayout.LayoutControlItem item4;
        private DevExpress.XtraLayout.LayoutControlItem item5;
        private DevExpress.XtraLayout.LayoutControlItem item6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem item7;
        private DevExpress.XtraEditors.SearchLookUpEdit lg_SUPER_MENU_CODE;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}