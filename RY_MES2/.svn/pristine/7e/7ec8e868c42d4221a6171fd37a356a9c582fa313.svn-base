using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_DashBoard : RY_MES.frm_Base
    {      
        public frm_DashBoard()
        {
            InitializeComponent();
        }

        public frm_DashBoard(object[] paramArray)
        {
            InitializeComponent();
            _Main._User_Info["FA_ID"].ToString();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            _RYMES_DB = _Main._RYMES_DB;

            if (_Main._User_Info["FA_ID"].ToString() == "CMOS")
            {
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                init_form();
            }
            else if (_Main._User_Info["FA_ID"].ToString() == "TFT")
            {
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                xtraTabControl1.SelectedTabPageIndex = 1;

                Get_Data_TFT();
            }
            else if(_Main._User_Info["FA_ID"].ToString() == "CSI")
            {
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                xtraTabControl1.SelectedTabPageIndex = 2;
            }
            else
            {
              
                init_form();
            }
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            ucGridView view = sender as ucGridView;
            ucGridControl grid = view.GridControl as ucGridControl;

            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(view);
            }

            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                btn_Refresh_Click(null, null);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                grid.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
        }
        private void Get_Data_TOP(DataSet ds)
        {
            int plan = 0;
            int input = 0;
            int output = 0;

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                plan += item["PLAN_QTY"] is DBNull ? 0 : Convert.ToInt32(item["PLAN_QTY"]);
                input += item["IN_QTY"] is DBNull ? 0 : Convert.ToInt32(item["IN_QTY"]);
                output += item["OUT_QTY"] is DBNull ? 0 : Convert.ToInt32(item["OUT_QTY"]);
            }
            dGauge1.Text = plan.ToString();
            dGauge2.Text = input.ToString();
            dGauge3.Text = output.ToString();
            dGauge4.Text = ds.Tables[1].Rows[0]["RUN_TIME"].ToString();
            dGauge5.Text = ds.Tables[1].Rows[0]["DOWN_TIME"].ToString();

            progressBarControl1.Properties.Maximum = plan;
            progressBarControl2.Properties.Maximum = plan;
            if (ds.Tables[1].Rows[0]["RUN_TIME"].ToString() != "")
            {
                progressBarControl3.Properties.Maximum = Convert.ToInt32(ds.Tables[1].Rows[0]["RUN_TIME"]) + Convert.ToInt32(ds.Tables[1].Rows[0]["DOWN_TIME"]);
                progressBarControl1.EditValue = input;
                progressBarControl2.EditValue = output;
                progressBarControl3.EditValue = Convert.ToInt32(ds.Tables[1].Rows[0]["RUN_TIME"]);
            }
        }
        private void Get_Data_COMS()
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataSet ds = new DataSet();
                string sMsg = _RYMES_DB.GET_DATA("RP_DASHBOARD_LOAD", ref ds);

                if (string.IsNullOrEmpty(sMsg))
                {
                    Get_Data_TOP(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        int index = ds.Tables[0].Rows.IndexOf(item);
                        ((UC_OP_STAUS)layoutControl1.Controls["uC_OP_STAUS" + index.ToString()]).SET_DATA(item);
                    }

                }
                DataTable dt = new DataTable();
                sMsg = _RYMES_DB.GET_DATA("RP_UNUSED_INVENTORY_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    int focus = ucGridView1.FocusedRowHandle;
                    int topRowIndex = ucGridView1.TopRowIndex;

                    ucGridControl1.DataSource = dt;

                    if (focus < ucGridView1.RowCount - 1)
                    {
                        ucGridView1.FocusedRowHandle = focus;
                    }
                    else
                    {
                        ucGridView1.FocusedRowHandle = focus;
                    }
                    ucGridView1.TopRowIndex = topRowIndex;
                }
                else
                {
                    ucGridControl1.DataSource = null;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                simpleLabelItem6.Text = DateTime.Now.ToString();
            }
        }

        private void Get_Data_TFT()
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataSet ds = new DataSet();
                string sMsg = _RYMES_DB.GET_DATA("RP_DASHBOARD_TFT_LOAD", ref ds);

                if (string.IsNullOrEmpty(sMsg))
                {
                    gridControl1.DataSource = ds.Tables[0];
                    gridControl2.DataSource = ds.Tables[0];
                    gridControl3.DataSource = ds.Tables[2];
                    Get_Data_TOP(ds);
                }


            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                simpleLabelItem6.Text = DateTime.Now.ToString();
                ucGridView1.Focus();
            }
        }
        private void init_form()
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataSet ds = new DataSet();
                string sMsg = _RYMES_DB.GET_DATA("RP_DASHBOARD_LOAD", ref ds);

                if (string.IsNullOrEmpty(sMsg))
                {
                    Get_Data_TOP(ds);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        int index = ds.Tables[0].Rows.IndexOf(item);

                        UC_OP_STAUS uC_OP_STAUS = new RY_MES.Forms.UC_OP_STAUS(item)
                        {
                            Location = new System.Drawing.Point(12, 12),
                            Name = "uC_OP_STAUS" + index.ToString(),
                            Size = new System.Drawing.Size(100, 100),
                            Dock = System.Windows.Forms.DockStyle.Fill
                        };

                        LayoutControlItem layoutControlItem = new LayoutControlItem
                        {
                            Control = uC_OP_STAUS,
                            Location = new System.Drawing.Point(487, 0),
                            Name = "layoutControlItem" + index.ToString()
                        };

                        layoutControlItem.OptionsTableLayoutItem.ColumnIndex = index % 3;
                        layoutControlItem.OptionsTableLayoutItem.RowIndex = index / 3;

                        layoutControlItem.Size = new System.Drawing.Size(100, 100);
                        layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
                        layoutControlItem.TextVisible = false;

                        layoutControl1.Controls.Add(uC_OP_STAUS);
                        Root.Items.AddRange(new BaseLayoutItem[] { layoutControlItem });
                    }                  
                }
                DataTable dt = new DataTable();
                sMsg = _RYMES_DB.GET_DATA("RP_UNUSED_INVENTORY_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    ucGridControl1.DataSource = dt;

                    ucGridView1.Link_Column("WAFER_NO", "frm_Wafer_His");
                }
                else
                {
                    ucGridControl1.DataSource = null;
                }

                ucGridView1.BestFitColumns();
                ucGridView1.OptionsFind.AlwaysVisible = false;
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                simpleLabelItem6.Text = DateTime.Now.ToString();
                ucGridView1.Focus();
            }
        }

        private void ucGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "방치기간")
            {
                int interval = Convert.ToInt32((ucGridView1.GetRowCellValue(e.RowHandle, "방치기간")));
                if (interval < 14)
                {
                    e.Appearance.BackColor = Color.Orange;
                }
                else if (interval < 21)
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }
                else if (interval < 30)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    Get_Data_COMS();
                }
                if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    Get_Data_TFT();
                }
                if (xtraTabControl1.SelectedTabPageIndex == 2)
                {
                    
                }
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                Get_Data_COMS();
            }
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                Get_Data_TFT();
            }
            if (xtraTabControl1.SelectedTabPageIndex == 2)
            {

            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "PIR" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle && !(e.Value is DBNull))
            {
                decimal PIR = Convert.ToDecimal(e.Value);
                e.DisplayText = string.Format("{0:N2} %", PIR); 
            }
        }

        private void tileView1_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            if (e.Column.FieldName == "OP_NAME")
            {
                e.Handled = true;
            }
        }

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item.Elements[1].Text == "0001")
            {
                e.Item.Elements[1].Image = Properties.Resources.play_16x16;
            }
            else
            {
                if(e.Item.Elements[0].Text == "")
                {
                    e.Item.Elements[1].Image = Properties.Resources.error_16x16;
                }
                else
                {
                    e.Item.Elements[1].Image = Properties.Resources.warning_16x16;
                }
                   
            }
        }
    }
}