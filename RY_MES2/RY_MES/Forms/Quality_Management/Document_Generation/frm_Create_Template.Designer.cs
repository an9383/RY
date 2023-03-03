namespace RY_MES.Forms
{
    partial class frm_Create_Template
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Create_Template));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl = new RY_MES.ucGridControl();
            this.ucGridView1 = new RY_MES.ucGridView();
            this.gridControl1 = new RY_MES.ucGridControl();
            this.ucGridView2 = new RY_MES.ucGridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.le_TEMPLATE_ID = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Item_Update = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.dragDropEvents2 = new DevExpress.Utils.DragDrop.DragDropEvents(this.components);
            this.dragDropEvents1 = new DevExpress.Utils.DragDrop.DragDropEvents(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.le_TEMPLATE_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
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
            this.pnl_Conditions.Controls.Add(this.layoutControl1);
            this.pnl_Conditions.Size = new System.Drawing.Size(800, 40);
            this.pnl_Conditions.Controls.SetChildIndex(this.lc_Conditions, 0);
            this.pnl_Conditions.Controls.SetChildIndex(this.layoutControl1, 0);
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(800, 668);
            this.splitContainerControl1.SplitterPosition = 292;
            this.splitContainerControl1.TabIndex = 7;
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
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.ucGridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 292);
            this.gridControl.TabIndex = 1;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView1});
            // 
            // ucGridView1
            // 
            this.behaviorManager1.SetBehaviors(this.ucGridView1, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, this.dragDropEvents1)))});       
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
            this.gridControl1.Size = new System.Drawing.Size(800, 366);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ucGridView2});
            // 
            // ucGridView2
            // 
            this.behaviorManager1.SetBehaviors(this.ucGridView2, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, false, this.dragDropEvents2)))});
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
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.le_TEMPLATE_ID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl1.Location = new System.Drawing.Point(300, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(270, 40);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // le_TEMPLATE_ID
            // 
            this.le_TEMPLATE_ID.Location = new System.Drawing.Point(57, 10);
            this.le_TEMPLATE_ID.Name = "le_TEMPLATE_ID";
            this.le_TEMPLATE_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.le_TEMPLATE_ID.Properties.NullText = "";
            this.le_TEMPLATE_ID.Properties.PopupView = this.searchLookUpEdit1View;
            this.le_TEMPLATE_ID.Size = new System.Drawing.Size(211, 20);
            this.le_TEMPLATE_ID.StyleController = this.layoutControl1;
            this.le_TEMPLATE_ID.TabIndex = 4;
            this.le_TEMPLATE_ID.EditValueChanged += new System.EventHandler(this.le_TEMPLATE_ID_EditValueChanged);
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
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(270, 40);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem1.Control = this.le_TEMPLATE_ID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(270, 40);
            this.layoutControlItem1.Text = "Template";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btn_Item_Update);
            this.panelControl1.Controls.Add(this.btn_Save);
            this.panelControl1.Location = new System.Drawing.Point(595, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 33);
            this.panelControl1.TabIndex = 3;
            // 
            // btn_Item_Update
            // 
            this.btn_Item_Update.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Item_Update.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Item_Update.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Item_Update.ImageOptions.SvgImage")));
            this.btn_Item_Update.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Item_Update.Location = new System.Drawing.Point(5, 2);
            this.btn_Item_Update.Name = "btn_Item_Update";
            this.btn_Item_Update.Size = new System.Drawing.Size(120, 29);
            this.btn_Item_Update.TabIndex = 1;
            this.btn_Item_Update.Text = "연결품목 일괄 변경";
            this.btn_Item_Update.Click += new System.EventHandler(this.btn_Item_Update_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Save.ImageOptions.SvgImage")));
            this.btn_Save.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn_Save.Location = new System.Drawing.Point(125, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(73, 29);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // dragDropEvents1
            // 
            this.dragDropEvents1.DragOver += new DevExpress.Utils.DragDrop.DragOverEventHandler(this.dragDropEvents1_DragOver);
            this.dragDropEvents1.DragDrop += new DevExpress.Utils.DragDrop.DragDropEventHandler(this.dragDropEvents1_DragDrop);
            // 
            // frm_Create_Template
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 718);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frm_Create_Template";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.le_TEMPLATE_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ucGridControl gridControl;
        private ucGridControl gridControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit le_TEMPLATE_ID;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Item_Update;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents2;
        private ucGridView ucGridView1;
        private ucGridView ucGridView2;
    }
}