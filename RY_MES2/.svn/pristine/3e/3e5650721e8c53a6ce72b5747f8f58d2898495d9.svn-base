using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_DownTime_Master : RY_MES.frm_Base
    {
        public frm_DownTime_Master()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;

            Get_Data_Tree(treeList1);
            Set_Description(lc_edit);
            treeList1.PopupMenuShowing += treeList_PopupMenuShowing;
        }

        public void Get_Data_Tree(TreeList treeList)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            treeList.Enabled = true;
            DataSet ds = new DataSet();

            string sMsg = _RYMES_DB.GET_DATA("PM_IP_REASON_MASTER_LOAD", ref ds);
            if (string.IsNullOrEmpty(sMsg))
            {
                treeList1.DataSource = ds.Tables[0];
                Set_Description(treeList1);

                treeList1.RootValue = null;
                treeList1.KeyFieldName = "REASON_CODE1";
                treeList1.ParentFieldName = "SUPER_REASON_CODE";
                treeList1.ExpandAll();
                treeList1.BestFitColumns();
            }
            else
            {
                treeList1.DataSource = null;
            }
        }

        private void treeList_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            TreeList treeList = (TreeList)sender;
            TreeListHitInfo hitInfo = treeList.CalcHitInfo(e.Point);

            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new TreeListMenu(treeList);
            }

            item = new DXMenuItem("Add", null, Properties.Resources.add_16x16);
            item.Click += (o, args) =>
            {
                SHOW_EDIT(treeList, o);
            };
            e.Menu.Items.Add(item);

            if (hitInfo.HitInfoType == HitInfoType.Row || hitInfo.HitInfoType == HitInfoType.Cell)
            {
                item = new DXMenuItem("Edit", null, Properties.Resources.edit_16x16);
                item.Click += (o, args) =>
                {
                    treeList.FocusedNode = hitInfo.Node;
                    SHOW_EDIT(treeList, o);
                };
                e.Menu.Items.Add(item);
            }

            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                Get_Data_Tree(treeList);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                Tree_Export(treeList1);
            };
            e.Menu.Items.Add(item);
        }

        private void SHOW_EDIT(TreeList treeList, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;

            treeList.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;
            Root.Text = menu.Caption;

            SET_LookUpEdit_Data(le_SUPER_REASON_CODE, "REASON_MASTER", "0002");
            SET_LookUpEdit_Data(le_FA_ID, "FA_MASTER");

            DataRow dataRow = ((DataRowView)treeList.GetFocusedRow()).Row;

            if (menu.Caption == "Add")
            {
                txt_REASON_CODE.Text = "";
                le_SUPER_REASON_CODE.EditValue = dataRow["SUPER_REASON_CODE"].ToString();
                txt_REASON_NAME.Text = "";
                le_FA_ID.EditValue = dataRow["FA_ID"].ToString();
                txt_ORDERBY.Text = "";
                txt_DESC1.Text = "";
                txt_DESC2.Text = "";

                txt_REASON_CODE.Enabled = true;
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                txt_REASON_CODE.Text = dataRow["REASON_CODE"].ToString();
                le_SUPER_REASON_CODE.EditValue = dataRow["SUPER_REASON_CODE"].ToString();
                txt_REASON_NAME.Text = dataRow["REASON_NAME"].ToString();
                le_FA_ID.EditValue = dataRow["FA_ID"].ToString();
                txt_ORDERBY.Text = dataRow["ORDERBY"].ToString();
                txt_DESC1.Text = dataRow["DESC1"].ToString();
                txt_DESC1.Text = dataRow["DESC2"].ToString();

                txt_REASON_CODE.Enabled = false;
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }

            if (le_SUPER_REASON_CODE.EditValue is null)
            {
                le_FA_ID.Enabled = true;
            }
            else
            {
                le_FA_ID.Enabled = false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("PM_IP_REASON_MASTER_MERGE");
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Get_Data_Tree(treeList1);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            treeList1.Enabled = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            if (DialogResult.OK == MessageBox.Show(btn.Text + "  " + txt_REASON_NAME.Text + " ?", btn.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                DataRow dr = ((DataRowView)treeList1.GetFocusedRow()).Row;

                try
                {
                    _RYMES_DB._DB_Parameters.Add("@p_REASON_CODE", dr["REASON_CODE"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("PM_IP_REASON_MASTER_DELETE");
                    if (string.IsNullOrEmpty(sMsg))
                    {
                        MessageBox.Show("Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    Get_Data_Tree(treeList1);
                }
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

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
        }

        private void le_SUPER_REASON_CODE_EditValueChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sMsg = _RYMES_DB.SET_DATA("SELECT FA_ID FROM REASON_MASTER(NOLOCK) WHERE REASON_TYPE = '0002' AND REASON_CODE = " + le_SUPER_REASON_CODE.EditValue, ref ds);
            if (string.IsNullOrEmpty(sMsg))
            {
                le_FA_ID.EditValue = ds.Tables[0].Rows[0][0];
                le_FA_ID.Enabled = false;
            }
            else
            {
                le_FA_ID.EditValue = null;
                le_FA_ID.Enabled = true;
            }
        }
    }
}