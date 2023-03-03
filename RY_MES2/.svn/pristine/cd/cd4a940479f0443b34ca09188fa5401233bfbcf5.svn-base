using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using nsCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Menu_Master : RY_MES.frm_Base
    {
        private DataSet ds_TEMP;
        private DataSet ds;
        private DragInsertPosition position;

        public frm_Menu_Master()
        {
            InitializeComponent();
        }

        public frm_Menu_Master(params object[] paramArray)
        {
            InitializeComponent();
            MessageBox.Show(paramArray[0].ToString());
        }

        private void frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;

            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;
            btn_Search_Click(null, null);
            Set_Description(lc_edit);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(treeList1);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            btn_Search_Click(null, null);
        }

        public void Get_Data_Grid(TreeList treeList)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            treeList.Enabled = true;
            ds = new DataSet();

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                string sMsg = _RYMES_DB.GET_DATA("SM_MENU_MASTER_LOAD", ref ds);
                if (string.IsNullOrEmpty(sMsg))
                {
                    treeList1.DataSource = ds.Tables[0];
                    Set_Description(treeList1);

                    treeList1.RootValue = null;
                    treeList1.KeyFieldName = "MENU_CODE";
                    treeList1.ParentFieldName = "SUPER_MENU_CODE";
                    treeList1.ExpandAll();
                    treeList1.BestFitColumns();

                    ds_TEMP = ds.Copy();
                }
                else
                {
                    treeList1.DataSource = null;
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                treeList1.Focus();
            }
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 2;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string sMsg = "";

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                sMsg = _RYMES_DB.SET_DATA("SM_MENU_MASTER_MERGE");

                SplashScreenManager.CloseForm(false);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btn_Search_Click(null, null);

                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            btn_Search_Click(null, null);
        }

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            DXDragEventArgs args = treeList1.GetDXDragEventArgs(e);
            position = args.DragInsertPosition;

            //상위 메뉴AUTH_CODE가 달라질때
            //if (args.Node.ParentNode != args.TargetNode.ParentNode)
            //{
            //    if (MessageBox.Show(args.Node["MENU_NAME"] + "을  " + args.TargetNode["MENU_NAME"] + "의 하위 메뉴로 이동하시겠습니까?", "Yes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        _RYMES_DB._DB_Parameters.Add("@p_MENU_CODE", args.Node["MENU_CODE"].ToString());
            //        _RYMES_DB._DB_Parameters.Add("@p_SUPER_MENU_CODE", args.TargetNode["MENU_CODE"].ToString());
            //        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._drUser_Info["USER_CODE"].ToString());
            //        _RYMES_DB._DB_Parameters.Add("@p_OPTION", "TRUE");

            //        string sMsg = _RYMES_DB.SET_DATA("SM_MENU_MASTER_MERGE");
            //        if (string.IsNullOrEmpty(sMsg))
            //        {
            //            MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        btn_Search_Click(null, null);
            //   }
            //}//같은 상위 메뉴AUTH_CODE지만 순서가 변경될때
            //else
            //{
            //    if (MessageBox.Show(args.Node["MENU_NAME"] + "의 순서를 변경하시겠습니까?", "Yes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        _RYMES_DB._DB_Parameters.Add("@p_MENU_CODE", args.Node["MENU_CODE"].ToString());
            //        _RYMES_DB._DB_Parameters.Add("@p_SUPER_MENU_CODE", args.Node["SUPER_MENU_CODE"].ToString());
            //        _RYMES_DB._DB_Parameters.Add("@p_ORDERBY", args.TargetNode["ORDERBY"].ToString());
            //        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._drUser_Info["USER_CODE"].ToString());
            //        _RYMES_DB._DB_Parameters.Add("@p_OPTION", "TRUE");

            //        string sMsg = _RYMES_DB.SET_DATA("SM_MENU_MASTER_MERGE");
            //        if (string.IsNullOrEmpty(sMsg))
            //        {
            //            MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        btn_Search_Click(null, null);
            //    }
            //}
        }

        private void SHOW_EDIT(TreeList treeList, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 2;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            treeList.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;

            Root.Text = menu.Caption;
            SET_LookUpEdit_Data(lg_SUPER_MENU_CODE, "MENU_MASTER");

            if (menu.Caption == "Add")
            {
                txt_MENU_CODE.Text = "";
                lg_SUPER_MENU_CODE.EditValue = null;
                txt_MENU_NAME.Text = "";
                txt_MENU_DESC.Text = "";
                txt_MENU_URL.Text = "";
                txt_ORDERBY.Text = "";
                txt_DESC1.Text = "";
                txt_DESC2.Text = "";

                btn_Delete.Visible = false;
            }
            else
            {
                DataRow dataRow = ((DataRowView)treeList1.GetFocusedRow()).Row;

                txt_MENU_CODE.Text = dataRow["MENU_CODE"].ToString();
                lg_SUPER_MENU_CODE.EditValue = dataRow["SUPER_MENU_CODE"];
                txt_MENU_NAME.Text = dataRow["MENU_NAME"].ToString();
                txt_MENU_DESC.Text = dataRow["MENU_DESC"].ToString();
                txt_MENU_URL.Text = dataRow["MENU_URL"].ToString();
                txt_ORDERBY.Text = dataRow["ORDERBY"].ToString();
                txt_DESC1.Text = dataRow["DESC1"].ToString();
                txt_DESC2.Text = dataRow["DESC2"].ToString();

                btn_Delete.Visible = true;
                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }
        }

        private void treeList_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            TreeList treeList = (TreeList)sender;
            TreeListHitInfo hitInfo = treeList.CalcHitInfo(e.Point);

            if (hitInfo.HitInfoType == HitInfoType.Row || hitInfo.HitInfoType == HitInfoType.Cell)
            {
                DXMenuItem item;

                item = new DXMenuItem("Add", null);
                item.Click += (o, args) => { SHOW_EDIT(treeList, o); };
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Edit", null);
                item.Click += (o, args) =>
                {
                    if (!(hitInfo.Node["MENU_NAME"] is null))
                    {
                        treeList.FocusedNode = hitInfo.Node;
                        SHOW_EDIT(treeList, o);
                    }
                };
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Refresh", null);
                item.Click += (o, args) => { btn_Search_Click(null, null); };
                item.BeginGroup = true;
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Export", null);
                item.Click += (o, args) => { Tree_Export(treeList1); };
                item.BeginGroup = true;
                e.Menu.Items.Add(item);
            }
            if (hitInfo.HitInfoType == HitInfoType.None)
            {
                if (e.Menu == null)
                {
                    e.Menu = new TreeListMenu(treeList);
                }
                DXMenuItem item;

                item = new DXMenuItem("Add", null);
                item.Click += (o, args) => { SHOW_EDIT(treeList, o); };
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Refresh", null);
                item.Click += (o, args) => { btn_Search_Click(null, null); };
                item.BeginGroup = true;
                e.Menu.Items.Add(item);
            }
        }

        private void treeList1_AfterDropNode(object sender, AfterDropNodeEventArgs e)
        {
            if (position == DragInsertPosition.AsChild)
            {
                if (MessageBox.Show(e.Node["MENU_NAME"] + "을  " + e.Node.ParentNode["MENU_NAME"] + "의 하위 메뉴로 이동하시겠습니까?", "Yes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save_Menu();
                }
            }
            else if (position == DragInsertPosition.Before)
            {
                if (MessageBox.Show(e.Node["MENU_NAME"] + "을  " + e.Node.NextNode["MENU_NAME"] + "의 이전 메뉴로 이동하시겠습니까?", "Yes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save_Menu();
                }
            }
            else if (position == DragInsertPosition.After)
            {
                if (MessageBox.Show(e.Node["MENU_NAME"] + "을  " + e.Node.PrevNode["MENU_NAME"] + "의 이후 메뉴로 이동하시겠습니까?", "Yes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save_Menu();
                }
            }

            btn_Search_Click(null, null);
        }

        private void Save_Menu()
        {
            DataTable dt = (DataTable)treeList1.DataSource;

            List<TreeListNode> nodes = treeList1.GetNodeList();
            foreach (TreeListNode node in nodes)
            {
                node["ORDERBY"] = treeList1.GetNodeIndex(node);
            }

            DbTransaction trans = _RYMES_DB._Connection.BeginTransaction();
            string sMsg = "";
            foreach (DataRow dr in dt.Rows)
            {
                DataRow[] drs = ds_TEMP.Tables[0].Select("MENU_CODE = '" + dr["MENU_CODE"].ToString() + "'");

                if (drs[0]["SUPER_MENU_CODE"].ToString() != dr["SUPER_MENU_CODE"].ToString() || drs[0]["ORDERBY"].ToString() != dr["ORDERBY"].ToString())
                {
                    _RYMES_DB._DB_Parameters.Add("@p_MENU_CODE", dr["MENU_CODE"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_SUPER_MENU_CODE", dr["SUPER_MENU_CODE"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_ORDERBY", dr["ORDERBY"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    sMsg = _RYMES_DB.SET_DATA("SM_MENU_MASTER_MERGE", ref trans);
                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(sMsg))
            {
                trans.Commit();
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DataRow dataRow = ((DataRowView)treeList1.GetFocusedRow()).Row;

            if (DialogResult.OK == MessageBox.Show(((SimpleButton)sender).Text + "  (" + dataRow["MENU_CODE"].ToString() + ") " + dataRow["MENU_NAME"].ToString() + " ?", ((SimpleButton)sender).Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                _RYMES_DB._DB_Parameters.Add("@p_MENU_CODE", dataRow["MENU_CODE"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_SUPER_MENU_CODE", dataRow["SUPER_MENU_CODE"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("SM_MENU_MASTER_DELETE");
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btn_Search_Click(null, null);
            }
        }

        private void treeList_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            TreeList treeList = sender as TreeList;

            if (e.Node["DELETE_USER"].ToString() != "")
            {
                e.Appearance.ForeColor = Color.LightGray;
            }
        }
    }
}