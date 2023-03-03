namespace RY_MES.Forms
{
    partial class frm_OPRT_Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_OPRT_Master));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lc_edit = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Back = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_RT_STEP = new DevExpress.XtraEditors.TextEdit();
            this.le_FA_ID = new DevExpress.XtraEditors.LookUpEdit();
            this.le_OP_ID = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_SN_YN = new DevExpress.XtraEditors.RadioGroup();
            this.txt_SEND_RESULT_YN = new DevExpress.XtraEditors.RadioGroup();
            this.txt_CO_WORK_YN = new DevExpress.XtraEditors.RadioGroup();
            this.txt_NOTES = new DevExpress.XtraEditors.TextEdit();
            this.le_RT_ID = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucGridControl1 = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Conditions)).BeginInit();
            this.pnl_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_Conditions)).BeginInit();
            this.lc_Conditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.de_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc_edit)).BeginInit();
            this.lc_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_RT_STEP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_FA_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_OP_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SN_YN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SEND_RESULT_YN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CO_WORK_YN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NOTES.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_RT_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.ucGridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.lc_edit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(800, 400);
            this.splitContainerControl1.SplitterPosition = 543;
            this.splitContainerControl1.TabIndex = 7;
            // 
            // lc_edit
            // 
            this.lc_edit.Controls.Add(this.btn_Delete);
            this.lc_edit.Controls.Add(this.btn_Back);
            this.lc_edit.Controls.Add(this.btn_Save);
            this.lc_edit.Controls.Add(this.txt_RT_STEP);
            this.lc_edit.Controls.Add(this.le_FA_ID);
            this.lc_edit.Controls.Add(this.le_OP_ID);
            this.lc_edit.Controls.Add(this.txt_SN_YN);
            this.lc_edit.Controls.Add(this.txt_SEND_RESULT_YN);
            this.lc_edit.Controls.Add(this.txt_CO_WORK_YN);
            this.lc_edit.Controls.Add(this.txt_NOTES);
            this.lc_edit.Controls.Add(this.le_RT_ID);
            this.lc_edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lc_edit.Location = new System.Drawing.Point(0, 0);
            this.lc_edit.Name = "lc_edit";
            this.lc_edit.Root = this.Root;
            this.lc_edit.Size = new System.Drawing.Size(247, 400);
            this.lc_edit.TabIndex = 0;
            this.lc_edit.Text = "layoutControl1";
            // 
            // btn_Delete
            // 
            this.btn_Delete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Delete.ImageOptions.SvgImage")));
            this.btn_Delete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Delete.Location = new System.Drawing.Point(12, 413);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(206, 22);
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
            this.btn_Back.Location = new System.Drawing.Point(12, 439);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(101, 22);
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
            this.btn_Save.Location = new System.Drawing.Point(117, 439);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(101, 22);
            this.btn_Save.StyleController = this.lc_edit;
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_RT_STEP
            // 
            this.txt_RT_STEP.Location = new System.Drawing.Point(12, 173);
            this.txt_RT_STEP.Name = "txt_RT_STEP";
            this.txt_RT_STEP.Properties.Mask.EditMask = "d";
            this.txt_RT_STEP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_RT_STEP.Size = new System.Drawing.Size(206, 20);
            this.txt_RT_STEP.StyleController = this.lc_edit;
            this.txt_RT_STEP.TabIndex = 5;
            // 
            // le_FA_ID
            // 
            this.le_FA_ID.Enabled = false;
            this.le_FA_ID.Location = new System.Drawing.Point(12, 91);
            this.le_FA_ID.Name = "le_FA_ID";
            this.le_FA_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_FA_ID.Properties.NullText = "";
            this.le_FA_ID.Size = new System.Drawing.Size(206, 20);
            this.le_FA_ID.StyleController = this.lc_edit;
            this.le_FA_ID.TabIndex = 4;
            // 
            // le_OP_ID
            // 
            this.le_OP_ID.Enabled = false;
            this.le_OP_ID.Location = new System.Drawing.Point(12, 132);
            this.le_OP_ID.Name = "le_OP_ID";
            this.le_OP_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_OP_ID.Properties.NullText = "";
            this.le_OP_ID.Size = new System.Drawing.Size(206, 20);
            this.le_OP_ID.StyleController = this.lc_edit;
            this.le_OP_ID.TabIndex = 5;
            // 
            // txt_SN_YN
            // 
            this.txt_SN_YN.Location = new System.Drawing.Point(12, 214);
            this.txt_SN_YN.Name = "txt_SN_YN";
            this.txt_SN_YN.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Y"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "N")});
            this.txt_SN_YN.Size = new System.Drawing.Size(206, 34);
            this.txt_SN_YN.StyleController = this.lc_edit;
            this.txt_SN_YN.TabIndex = 6;
            // 
            // txt_SEND_RESULT_YN
            // 
            this.txt_SEND_RESULT_YN.Location = new System.Drawing.Point(12, 269);
            this.txt_SEND_RESULT_YN.Name = "txt_SEND_RESULT_YN";
            this.txt_SEND_RESULT_YN.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Y"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "N")});
            this.txt_SEND_RESULT_YN.Size = new System.Drawing.Size(206, 34);
            this.txt_SEND_RESULT_YN.StyleController = this.lc_edit;
            this.txt_SEND_RESULT_YN.TabIndex = 6;
            // 
            // txt_CO_WORK_YN
            // 
            this.txt_CO_WORK_YN.Location = new System.Drawing.Point(12, 324);
            this.txt_CO_WORK_YN.Name = "txt_CO_WORK_YN";
            this.txt_CO_WORK_YN.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Y"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "N")});
            this.txt_CO_WORK_YN.Size = new System.Drawing.Size(206, 34);
            this.txt_CO_WORK_YN.StyleController = this.lc_edit;
            this.txt_CO_WORK_YN.TabIndex = 6;
            // 
            // txt_NOTES
            // 
            this.txt_NOTES.Location = new System.Drawing.Point(12, 379);
            this.txt_NOTES.Name = "txt_NOTES";
            this.txt_NOTES.Properties.Mask.EditMask = "n";
            this.txt_NOTES.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_NOTES.Size = new System.Drawing.Size(206, 20);
            this.txt_NOTES.StyleController = this.lc_edit;
            this.txt_NOTES.TabIndex = 6;
            // 
            // le_RT_ID
            // 
            this.le_RT_ID.Location = new System.Drawing.Point(12, 50);
            this.le_RT_ID.Name = "le_RT_ID";
            this.le_RT_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_RT_ID.Properties.NullText = "";
            this.le_RT_ID.Size = new System.Drawing.Size(206, 20);
            this.le_RT_ID.StyleController = this.lc_edit;
            this.le_RT_ID.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem14});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(230, 473);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.le_RT_ID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(210, 41);
            this.layoutControlItem1.Text = "RT_ID";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(103, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.le_OP_ID;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(210, 41);
            this.layoutControlItem2.Text = "OP_ID";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(103, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_Delete;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 380);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(210, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_Back;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 406);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(105, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btn_Save;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem7.Location = new System.Drawing.Point(105, 406);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(105, 26);
            this.layoutControlItem7.Text = "layoutControlItem5";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 370);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(210, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.le_FA_ID;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem8.CustomizationFormText = "FA_ID";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 41);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(210, 41);
            this.layoutControlItem8.Text = "FA_ID";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(103, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txt_RT_STEP;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem9.CustomizationFormText = "RT_STEP";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(210, 41);
            this.layoutControlItem9.Text = "RT_STEP";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(103, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txt_SN_YN;
            this.layoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem11.CustomizationFormText = "SN_YN";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 164);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(210, 55);
            this.layoutControlItem11.Text = "SN_YN";
            this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(103, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txt_SEND_RESULT_YN;
            this.layoutControlItem12.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem12.CustomizationFormText = "SEND_RESULT_YN";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 219);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(210, 55);
            this.layoutControlItem12.Text = "SEND_RESULT_YN";
            this.layoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(103, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txt_CO_WORK_YN;
            this.layoutControlItem13.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem13.CustomizationFormText = "CO_WORK_YN";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 274);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(210, 55);
            this.layoutControlItem13.Text = "CO_WORK_YN";
            this.layoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(103, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txt_NOTES;
            this.layoutControlItem14.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem14.CustomizationFormText = "NOTES";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 329);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(210, 41);
            this.layoutControlItem14.Text = "NOTES";
            this.layoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(103, 14);
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
            this.ucGridControl1.Size = new System.Drawing.Size(543, 400);
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
            // frm_OPRT_Master
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_OPRT_Master";
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
            ((System.ComponentModel.ISupportInitialize)(this.lc_edit)).EndInit();
            this.lc_edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_RT_STEP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_FA_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_OP_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SN_YN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SEND_RESULT_YN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CO_WORK_YN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NOTES.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.le_RT_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl lc_edit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Back;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit txt_RT_STEP;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.LookUpEdit le_FA_ID;
        private DevExpress.XtraEditors.LookUpEdit le_OP_ID;
        private DevExpress.XtraEditors.RadioGroup txt_SN_YN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.RadioGroup txt_SEND_RESULT_YN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.RadioGroup txt_CO_WORK_YN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraEditors.TextEdit txt_NOTES;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.LookUpEdit le_RT_ID;
        private ucGridControl ucGridControl1;
        private ucGridView ucGridView1;
    }
}