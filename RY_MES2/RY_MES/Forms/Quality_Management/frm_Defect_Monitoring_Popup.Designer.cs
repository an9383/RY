using DevExpress.XtraEditors;

namespace RY_MES.Forms
{
    partial class frm_Defect_Monitoring_Popup
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
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition7 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition8 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition9 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition10 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition11 = new DevExpress.XtraLayout.RowDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Defect_Monitoring_Popup));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_DEFECT_SN = new DevExpress.XtraEditors.TextEdit();
            this.txt_WO_ID = new DevExpress.XtraEditors.TextEdit();
            this.txt_MODEL_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_ITEM_CODE = new DevExpress.XtraEditors.TextEdit();
            this.txt_ITEM_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_OP_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_DEFECT_DATE = new DevExpress.XtraEditors.TextEdit();
            this.txt_CREATE_USER = new DevExpress.XtraEditors.TextEdit();
            this.me_DEFECT_NOTES = new DevExpress.XtraEditors.MemoEdit();
            this.le_SUPER_REASON_CODE = new DevExpress.XtraEditors.LookUpEdit();
            this.le_REASON_CODE = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_FA_ID = new DevExpress.XtraEditors.TextEdit();
            this.txt_ITEM_TYPE = new DevExpress.XtraEditors.TextEdit();
            this.txt_DEFECT_RESULT = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.me_DEFECT_RESULT_NOTES = new DevExpress.XtraEditors.MemoEdit();
            this.le_SUPER_DEFECT_CAUSE = new DevExpress.XtraEditors.LookUpEdit();
            this.le_DEFECT_CAUSE = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txt_DEFECT_ID = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.txt_DEFECT_SN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WO_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MODEL_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_OP_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DEFECT_DATE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CREATE_USER.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_DEFECT_NOTES.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_SUPER_REASON_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_REASON_CODE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FA_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_TYPE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DEFECT_RESULT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_DEFECT_RESULT_NOTES.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_SUPER_DEFECT_CAUSE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_DEFECT_CAUSE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Conditions
            // 
            this.btn_Conditions.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_Conditions.Appearance.Options.UseFont = true;
            this.btn_Conditions.Size = new System.Drawing.Size(1293, 10);
            // 
            // pnl_Conditions
            // 
            this.pnl_Conditions.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_Conditions.Appearance.Options.UseBackColor = true;
            this.pnl_Conditions.Size = new System.Drawing.Size(1293, 40);
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
            this.panelControl1.Location = new System.Drawing.Point(0, 560);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1293, 42);
            this.panelControl1.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Location = new System.Drawing.Point(1153, 2);
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 84);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.layoutControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1293, 476);
            this.splitContainerControl1.SplitterPosition = 492;
            this.splitContainerControl1.TabIndex = 9;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_DEFECT_SN);
            this.layoutControl1.Controls.Add(this.txt_WO_ID);
            this.layoutControl1.Controls.Add(this.txt_MODEL_NAME);
            this.layoutControl1.Controls.Add(this.txt_ITEM_CODE);
            this.layoutControl1.Controls.Add(this.txt_ITEM_NAME);
            this.layoutControl1.Controls.Add(this.txt_OP_NAME);
            this.layoutControl1.Controls.Add(this.txt_DEFECT_DATE);
            this.layoutControl1.Controls.Add(this.txt_CREATE_USER);
            this.layoutControl1.Controls.Add(this.me_DEFECT_NOTES);
            this.layoutControl1.Controls.Add(this.le_SUPER_REASON_CODE);
            this.layoutControl1.Controls.Add(this.le_REASON_CODE);
            this.layoutControl1.Controls.Add(this.txt_FA_ID);
            this.layoutControl1.Controls.Add(this.txt_ITEM_TYPE);
            this.layoutControl1.Controls.Add(this.txt_DEFECT_RESULT);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-129, 530, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(492, 476);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_DEFECT_SN
            // 
            this.txt_DEFECT_SN.Location = new System.Drawing.Point(321, 12);
            this.txt_DEFECT_SN.Name = "txt_DEFECT_SN";
            this.txt_DEFECT_SN.Properties.ReadOnly = true;
            this.txt_DEFECT_SN.Size = new System.Drawing.Size(159, 20);
            this.txt_DEFECT_SN.StyleController = this.layoutControl1;
            this.txt_DEFECT_SN.TabIndex = 5;
            // 
            // txt_WO_ID
            // 
            this.txt_WO_ID.Location = new System.Drawing.Point(85, 12);
            this.txt_WO_ID.Name = "txt_WO_ID";
            this.txt_WO_ID.Properties.ReadOnly = true;
            this.txt_WO_ID.Size = new System.Drawing.Size(159, 20);
            this.txt_WO_ID.StyleController = this.layoutControl1;
            this.txt_WO_ID.TabIndex = 6;
            // 
            // txt_MODEL_NAME
            // 
            this.txt_MODEL_NAME.Location = new System.Drawing.Point(85, 75);
            this.txt_MODEL_NAME.Name = "txt_MODEL_NAME";
            this.txt_MODEL_NAME.Properties.ReadOnly = true;
            this.txt_MODEL_NAME.Size = new System.Drawing.Size(159, 20);
            this.txt_MODEL_NAME.StyleController = this.layoutControl1;
            this.txt_MODEL_NAME.TabIndex = 7;
            // 
            // txt_ITEM_CODE
            // 
            this.txt_ITEM_CODE.Location = new System.Drawing.Point(321, 75);
            this.txt_ITEM_CODE.Name = "txt_ITEM_CODE";
            this.txt_ITEM_CODE.Properties.ReadOnly = true;
            this.txt_ITEM_CODE.Size = new System.Drawing.Size(159, 20);
            this.txt_ITEM_CODE.StyleController = this.layoutControl1;
            this.txt_ITEM_CODE.TabIndex = 8;
            // 
            // txt_ITEM_NAME
            // 
            this.txt_ITEM_NAME.Location = new System.Drawing.Point(85, 107);
            this.txt_ITEM_NAME.Name = "txt_ITEM_NAME";
            this.txt_ITEM_NAME.Properties.ReadOnly = true;
            this.txt_ITEM_NAME.Size = new System.Drawing.Size(395, 20);
            this.txt_ITEM_NAME.StyleController = this.layoutControl1;
            this.txt_ITEM_NAME.TabIndex = 9;
            // 
            // txt_OP_NAME
            // 
            this.txt_OP_NAME.Location = new System.Drawing.Point(85, 139);
            this.txt_OP_NAME.Name = "txt_OP_NAME";
            this.txt_OP_NAME.Properties.ReadOnly = true;
            this.txt_OP_NAME.Size = new System.Drawing.Size(159, 20);
            this.txt_OP_NAME.StyleController = this.layoutControl1;
            this.txt_OP_NAME.TabIndex = 10;
            // 
            // txt_DEFECT_DATE
            // 
            this.txt_DEFECT_DATE.Location = new System.Drawing.Point(321, 139);
            this.txt_DEFECT_DATE.Name = "txt_DEFECT_DATE";
            this.txt_DEFECT_DATE.Properties.ReadOnly = true;
            this.txt_DEFECT_DATE.Size = new System.Drawing.Size(159, 20);
            this.txt_DEFECT_DATE.StyleController = this.layoutControl1;
            this.txt_DEFECT_DATE.TabIndex = 11;
            // 
            // txt_CREATE_USER
            // 
            this.txt_CREATE_USER.Location = new System.Drawing.Point(85, 171);
            this.txt_CREATE_USER.Name = "txt_CREATE_USER";
            this.txt_CREATE_USER.Properties.ReadOnly = true;
            this.txt_CREATE_USER.Size = new System.Drawing.Size(159, 20);
            this.txt_CREATE_USER.StyleController = this.layoutControl1;
            this.txt_CREATE_USER.TabIndex = 12;
            // 
            // me_DEFECT_NOTES
            // 
            this.me_DEFECT_NOTES.Location = new System.Drawing.Point(85, 235);
            this.me_DEFECT_NOTES.Name = "me_DEFECT_NOTES";
            this.me_DEFECT_NOTES.Properties.ReadOnly = true;
            this.me_DEFECT_NOTES.Size = new System.Drawing.Size(395, 229);
            this.me_DEFECT_NOTES.StyleController = this.layoutControl1;
            this.me_DEFECT_NOTES.TabIndex = 15;
            // 
            // le_SUPER_REASON_CODE
            // 
            this.le_SUPER_REASON_CODE.Location = new System.Drawing.Point(85, 203);
            this.le_SUPER_REASON_CODE.Name = "le_SUPER_REASON_CODE";
            this.le_SUPER_REASON_CODE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_SUPER_REASON_CODE.Properties.NullText = "";
            this.le_SUPER_REASON_CODE.Size = new System.Drawing.Size(159, 20);
            this.le_SUPER_REASON_CODE.StyleController = this.layoutControl1;
            this.le_SUPER_REASON_CODE.TabIndex = 13;
            this.le_SUPER_REASON_CODE.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.le_EditValueChanging);
            // 
            // le_REASON_CODE
            // 
            this.le_REASON_CODE.Location = new System.Drawing.Point(321, 203);
            this.le_REASON_CODE.Name = "le_REASON_CODE";
            this.le_REASON_CODE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_REASON_CODE.Properties.NullText = "";
            this.le_REASON_CODE.Size = new System.Drawing.Size(159, 20);
            this.le_REASON_CODE.StyleController = this.layoutControl1;
            this.le_REASON_CODE.TabIndex = 14;
            // 
            // txt_FA_ID
            // 
            this.txt_FA_ID.Location = new System.Drawing.Point(85, 43);
            this.txt_FA_ID.Name = "txt_FA_ID";
            this.txt_FA_ID.Properties.ReadOnly = true;
            this.txt_FA_ID.Size = new System.Drawing.Size(159, 20);
            this.txt_FA_ID.StyleController = this.layoutControl1;
            this.txt_FA_ID.TabIndex = 7;
            // 
            // txt_ITEM_TYPE
            // 
            this.txt_ITEM_TYPE.Location = new System.Drawing.Point(321, 43);
            this.txt_ITEM_TYPE.Name = "txt_ITEM_TYPE";
            this.txt_ITEM_TYPE.Properties.ReadOnly = true;
            this.txt_ITEM_TYPE.Size = new System.Drawing.Size(159, 20);
            this.txt_ITEM_TYPE.StyleController = this.layoutControl1;
            this.txt_ITEM_TYPE.TabIndex = 7;
            // 
            // txt_DEFECT_RESULT
            // 
            this.txt_DEFECT_RESULT.Location = new System.Drawing.Point(321, 171);
            this.txt_DEFECT_RESULT.Name = "txt_DEFECT_RESULT";
            this.txt_DEFECT_RESULT.Properties.ReadOnly = true;
            this.txt_DEFECT_RESULT.Size = new System.Drawing.Size(159, 20);
            this.txt_DEFECT_RESULT.StyleController = this.layoutControl1;
            this.txt_DEFECT_RESULT.TabIndex = 16;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem1,
            this.layoutControlItem18});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 50D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 50D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
            rowDefinition1.Height = 7D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 7D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition3.Height = 7D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition4.Height = 7D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition5.Height = 7D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition6.Height = 7D;
            rowDefinition6.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition7.Height = 7D;
            rowDefinition7.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition8.Height = 51D;
            rowDefinition8.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4,
            rowDefinition5,
            rowDefinition6,
            rowDefinition7,
            rowDefinition8});
            this.Root.Size = new System.Drawing.Size(492, 476);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_DEFECT_SN;
            this.layoutControlItem2.Location = new System.Drawing.Point(236, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(236, 31);
            this.layoutControlItem2.Text = "부적합 S/N";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_MODEL_NAME;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 63);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem3.Text = "모델";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_ITEM_CODE;
            this.layoutControlItem4.Location = new System.Drawing.Point(236, 63);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem4.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem4.Text = "품목코드";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txt_ITEM_NAME;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 95);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem5.Size = new System.Drawing.Size(472, 32);
            this.layoutControlItem5.Text = "품목명";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txt_OP_NAME;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 127);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsTableLayoutItem.RowIndex = 4;
            this.layoutControlItem6.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem6.Text = "발생공정";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txt_DEFECT_DATE;
            this.layoutControlItem7.Location = new System.Drawing.Point(236, 127);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem7.OptionsTableLayoutItem.RowIndex = 4;
            this.layoutControlItem7.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem7.Text = "발생일시";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txt_CREATE_USER;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 159);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.OptionsTableLayoutItem.RowIndex = 5;
            this.layoutControlItem8.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem8.Text = "부적합보고자";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.le_SUPER_REASON_CODE;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 191);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.OptionsTableLayoutItem.RowIndex = 6;
            this.layoutControlItem9.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem9.Text = "상위부적합코드";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.le_REASON_CODE;
            this.layoutControlItem10.Location = new System.Drawing.Point(236, 191);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem10.OptionsTableLayoutItem.RowIndex = 6;
            this.layoutControlItem10.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem10.Text = "하위부적합코드";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.me_DEFECT_NOTES;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 223);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem11.OptionsTableLayoutItem.RowIndex = 7;
            this.layoutControlItem11.Size = new System.Drawing.Size(472, 233);
            this.layoutControlItem11.Text = "부적합현상설명";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txt_FA_ID;
            this.layoutControlItem16.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem16.CustomizationFormText = "공장";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem16.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem16.Text = "공장";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txt_ITEM_TYPE;
            this.layoutControlItem17.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem17.CustomizationFormText = "품목타입";
            this.layoutControlItem17.Location = new System.Drawing.Point(236, 31);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem17.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem17.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem17.Text = "품목타입";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_WO_ID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(236, 31);
            this.layoutControlItem1.Text = "작업지시아이디";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txt_DEFECT_RESULT;
            this.layoutControlItem18.Location = new System.Drawing.Point(236, 159);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem18.OptionsTableLayoutItem.RowIndex = 5;
            this.layoutControlItem18.Size = new System.Drawing.Size(236, 32);
            this.layoutControlItem18.Text = "부적합결과";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.me_DEFECT_RESULT_NOTES);
            this.layoutControl2.Controls.Add(this.le_SUPER_DEFECT_CAUSE);
            this.layoutControl2.Controls.Add(this.le_DEFECT_CAUSE);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(62, 261, 650, 400);
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(791, 476);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControl1
            // 
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
            this.gridControl1.Location = new System.Drawing.Point(12, 235);
            this.gridControl1.MainView = this.ucGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(767, 229);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView1});
            // 
            // ucGridView1
            // 
            this.ucGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.ucGridView1.GridControl = this.gridControl1;
            this.ucGridView1.Name = "ucGridView1";
            this.ucGridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.ucGridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.ucGridView1.OptionsCustomization.AllowColumnMoving = false;
            this.ucGridView1.OptionsCustomization.AllowColumnResizing = false;
            this.ucGridView1.OptionsCustomization.AllowFilter = false;
            this.ucGridView1.OptionsCustomization.AllowGroup = false;
            this.ucGridView1.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.ucGridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.ucGridView1.OptionsCustomization.AllowSort = false;
            this.ucGridView1.OptionsFind.AllowFindPanel = false;
            this.ucGridView1.OptionsFind.AllowMruItems = false;
            this.ucGridView1.OptionsFind.ShowClearButton = false;
            this.ucGridView1.OptionsFind.ShowCloseButton = false;
            this.ucGridView1.OptionsFind.ShowFindButton = false;
            this.ucGridView1.OptionsFind.ShowSearchNavButtons = false;
            this.ucGridView1.OptionsMenu.EnableColumnMenu = false;
            this.ucGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.ucGridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ucGridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.ucGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.ucGridView1.OptionsView.ColumnAutoWidth = false;
            this.ucGridView1.OptionsView.ShowIndicator = false;
            // 
            // me_DEFECT_RESULT_NOTES
            // 
            this.me_DEFECT_RESULT_NOTES.Location = new System.Drawing.Point(85, 43);
            this.me_DEFECT_RESULT_NOTES.Name = "me_DEFECT_RESULT_NOTES";
            this.me_DEFECT_RESULT_NOTES.Size = new System.Drawing.Size(694, 188);
            this.me_DEFECT_RESULT_NOTES.StyleController = this.layoutControl2;
            this.me_DEFECT_RESULT_NOTES.TabIndex = 5;
            // 
            // le_SUPER_DEFECT_CAUSE
            // 
            this.le_SUPER_DEFECT_CAUSE.Location = new System.Drawing.Point(85, 12);
            this.le_SUPER_DEFECT_CAUSE.Name = "le_SUPER_DEFECT_CAUSE";
            this.le_SUPER_DEFECT_CAUSE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_SUPER_DEFECT_CAUSE.Properties.NullText = "";
            this.le_SUPER_DEFECT_CAUSE.Size = new System.Drawing.Size(308, 20);
            this.le_SUPER_DEFECT_CAUSE.StyleController = this.layoutControl2;
            this.le_SUPER_DEFECT_CAUSE.TabIndex = 4;
            this.le_SUPER_DEFECT_CAUSE.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.le_EditValueChanging);
            // 
            // le_DEFECT_CAUSE
            // 
            this.le_DEFECT_CAUSE.Location = new System.Drawing.Point(470, 12);
            this.le_DEFECT_CAUSE.Name = "le_DEFECT_CAUSE";
            this.le_DEFECT_CAUSE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_DEFECT_CAUSE.Properties.NullText = "";
            this.le_DEFECT_CAUSE.Size = new System.Drawing.Size(309, 20);
            this.le_DEFECT_CAUSE.StyleController = this.layoutControl2;
            this.le_DEFECT_CAUSE.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.layoutControlItem13,
            this.layoutControlItem15});
            this.layoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutControlGroup1.Name = "Root";
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 50D;
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition4.Width = 50D;
            this.layoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition3,
            columnDefinition4});
            rowDefinition9.Height = 7D;
            rowDefinition9.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition10.Height = 42D;
            rowDefinition10.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition11.Height = 51D;
            rowDefinition11.SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition9,
            rowDefinition10,
            rowDefinition11});
            this.layoutControlGroup1.Size = new System.Drawing.Size(791, 476);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.le_DEFECT_CAUSE;
            this.layoutControlItem12.Location = new System.Drawing.Point(385, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem12.Size = new System.Drawing.Size(386, 31);
            this.layoutControlItem12.Text = "하위원인코드";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.me_DEFECT_RESULT_NOTES;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem14.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem14.Size = new System.Drawing.Size(771, 192);
            this.layoutControlItem14.Text = "부적합원인설명";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.le_SUPER_DEFECT_CAUSE;
            this.layoutControlItem13.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(385, 31);
            this.layoutControlItem13.Text = "상위원인코드";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(70, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.gridControl1;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 223);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem15.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem15.Size = new System.Drawing.Size(771, 233);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txt_DEFECT_ID);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 50);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1293, 34);
            this.panelControl2.TabIndex = 10;
            // 
            // txt_DEFECT_ID
            // 
            this.txt_DEFECT_ID.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.txt_DEFECT_ID.Appearance.Options.UseFont = true;
            this.txt_DEFECT_ID.Location = new System.Drawing.Point(174, 0);
            this.txt_DEFECT_ID.Name = "txt_DEFECT_ID";
            this.txt_DEFECT_ID.Size = new System.Drawing.Size(182, 33);
            this.txt_DEFECT_ID.TabIndex = 1;
            this.txt_DEFECT_ID.Text = "labelControl2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(158, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "부적합아이디 : ";
            // 
            // frm_Defect_Monitoring_Popup
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 602);
            this.ControlBox = true;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_Defect_Monitoring_Popup.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Defect_Monitoring_Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "공정부적합 처리";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnl_Conditions, 0);
            this.Controls.SetChildIndex(this.btn_Conditions, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.txt_DEFECT_SN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WO_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MODEL_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_OP_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DEFECT_DATE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CREATE_USER.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_DEFECT_NOTES.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_SUPER_REASON_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_REASON_CODE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FA_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEM_TYPE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DEFECT_RESULT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.me_DEFECT_RESULT_NOTES.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_SUPER_DEFECT_CAUSE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_DEFECT_CAUSE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txt_DEFECT_SN;
        private DevExpress.XtraEditors.TextEdit txt_MODEL_NAME;
        private DevExpress.XtraEditors.TextEdit txt_ITEM_CODE;
        private DevExpress.XtraEditors.TextEdit txt_ITEM_NAME;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txt_OP_NAME;
        private DevExpress.XtraEditors.TextEdit txt_DEFECT_DATE;
        private DevExpress.XtraEditors.TextEdit txt_CREATE_USER;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.MemoEdit me_DEFECT_NOTES;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit me_DEFECT_RESULT_NOTES;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private ucGridControl gridControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private PanelControl panelControl2;
        private LabelControl txt_DEFECT_ID;
        private LabelControl labelControl1;
        private ucGridView ucGridView1;
        private LookUpEdit le_SUPER_REASON_CODE;
        private LookUpEdit le_REASON_CODE;
        private LookUpEdit le_SUPER_DEFECT_CAUSE;
        private LookUpEdit le_DEFECT_CAUSE;
        private TextEdit txt_FA_ID;
        private TextEdit txt_WO_ID;
        private TextEdit txt_ITEM_TYPE;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private TextEdit txt_DEFECT_RESULT;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
    }
}