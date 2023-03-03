using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_EQUIP_WORKER : RY_MES.frm_Base
    {

        public frm_EQUIP_WORKER()
        {
            InitializeComponent();

            _RYMES_DB = _Main._RYMES_DB;
            lc_Conditions.Visible = false;
        }

        public frm_EQUIP_WORKER(object[] paramArray)
        {
            InitializeComponent();

            _RYMES_DB = _Main._RYMES_DB;
            lc_Conditions.Visible = false;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            btn_Conditions_Click(null, null);

            SET_LookUpEdit_Data(sle_USER, "USER_MASTER_WORKER");

            DataTable dt = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_GROUP_CODE", "CSI_EQUIP_WORK");
            string sMsg = _RYMES_DB.GET_DATA("SYS_CODE_LOAD", ref dt);
            if (string.IsNullOrEmpty(sMsg))
            {
                DevExpress.XtraLayout.BaseLayoutItem[] items = new DevExpress.XtraLayout.BaseLayoutItem[dt.Rows.Count];

                foreach (DataRow dr in dt.Rows)
                {
                    int idx = dt.Rows.IndexOf(dr);

                    GroupControl groupControl = new GroupControl();
                    groupControl.Name = "gc_" + dr[0];
                    groupControl.Text = dr[1].ToString();
                    groupControl.AllowDrop = true;
                    groupControl.Padding = new System.Windows.Forms.Padding(10);

                    groupControl.DragDrop += layoutControl1_DragDrop;
                    groupControl.DragEnter += layoutControl1_DragEnter;

                    LayoutControlItem layoutControlItem = new LayoutControlItem();
                    layoutControlItem.Control = groupControl;
                    layoutControlItem.Name = "lci_" + dr[0];
                    layoutControlItem.TextVisible = false;

                    string[] xy =  dr[2].ToString().Split(',');

                    layoutControlItem.OptionsTableLayoutItem.ColumnIndex = Convert.ToInt32(xy[0]);
                    layoutControlItem.OptionsTableLayoutItem.RowIndex = Convert.ToInt32(xy[1]);

                    items[idx] = layoutControlItem;
                }



                Root.Items.AddRange(items);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Set_User();
        }

        private void Set_User()
        {
            foreach (LayoutControlItem item in Root.Items)
            {
                item.Control.Controls.Clear();
            }
            None.Controls.Clear();

            DataTable dt = new DataTable();
            string sMsg = _RYMES_DB.GET_DATA("WE_EQUIP_WORKER_LOAD", ref dt);
            if (string.IsNullOrEmpty(sMsg))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SimpleButton simpleButton = new SimpleButton();
                    
                    simpleButton.Name = dr["USER_CODE"].ToString(); 
                    simpleButton.Size = new Size(120, 30);
                    simpleButton.Text = dr["USER_NAME"].ToString();
                    simpleButton.Appearance.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                    simpleButton.MouseDown += simpleButton1_MouseDown;

                    if (layoutControl1.Controls.IndexOfKey("gc_" + dr["CSI_EQUIP_WORK"]) >= 0)
                    {
                        simpleButton.Dock = DockStyle.Top;
                        layoutControl1.Controls["gc_" + dr["CSI_EQUIP_WORK"]].Controls.Add(simpleButton);
                    }
                    else
                    {
                        simpleButton.Dock =  DockStyle.Left ;
                        None.Controls.Add(simpleButton);
                    }

                }                
            }
            else
            {
                if(sMsg == "Result FirstTable Rows Count is Zero")
                {
                    return;
                }

                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void layoutControl1_DragDrop(object sender, DragEventArgs e)
        {
            Control control = (Control)sender;
            


            foreach (Control item in control.Controls)
            {
                item.Dock = control.GetType() == typeof(PanelControl) ? DockStyle.Left : DockStyle.Top;

            }
            e.Effect = DragDropEffects.Move;
            ((SimpleButton)e.Data.GetData(typeof(SimpleButton))).Parent = control;
            ((SimpleButton)e.Data.GetData(typeof(SimpleButton))).Dock = control.GetType() == typeof(PanelControl) ? DockStyle.Left : DockStyle.Top;


            _RYMES_DB._DB_Parameters.Add("@p_USER_CODE", ((SimpleButton)e.Data.GetData(typeof(SimpleButton))).Name);
            _RYMES_DB._DB_Parameters.Add("@p_CSI_EQUIP_WORK", control.Name.Replace("gc_",""));
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());
            string sMsg = _RYMES_DB.SET_DATA("WE_EQUIP_WORKER_MOVE");
            if (string.IsNullOrEmpty(sMsg))
            {
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void layoutControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void simpleButton1_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as SimpleButton).DoDragDrop((sender as SimpleButton), DragDropEffects.Move);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            _RYMES_DB._DB_Parameters.Add("@p_USER_CODE", sle_USER.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());
            string sMsg = _RYMES_DB.SET_DATA("WE_EQUIP_WORKER_INSERT");
            if (string.IsNullOrEmpty(sMsg))
            {
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Set_User();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            _RYMES_DB._DB_Parameters.Add("@p_USER_CODE", sle_USER.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());
            string sMsg = _RYMES_DB.SET_DATA("WE_EQUIP_WORKER_DELETE");
            if (string.IsNullOrEmpty(sMsg))
            {
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Set_User();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Set_User();
        }
    }
}