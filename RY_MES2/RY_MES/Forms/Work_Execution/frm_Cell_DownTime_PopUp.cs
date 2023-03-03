using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Cell_DownTime_PopUp : frm_Base
    {
        private DataTable table;
        private DataRow _Cell_Info;
        private int col_cnt = 5;
        bool _isEquip = false;

        public frm_Cell_DownTime_PopUp(frm_Main frm_Main, DataRow Cell_Info)
        {
            InitializeComponent();

            init_PopUp();

            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;

            Set_Description(layoutControl2);
        }

        public frm_Cell_DownTime_PopUp(frm_Main frm_Main, DataRow Cell_Info, bool isEquip)
        {
            InitializeComponent();

            init_PopUp();

            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
            _isEquip = isEquip;

            Set_Description(layoutControl2);
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                Get_Data_DouwnTime_Code();
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }
        }

        private void Get_Data_DouwnTime_Code()
        {
            table = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_DOWNTIME_CODE_LOAD", ref table);

            if (string.IsNullOrEmpty(sMsg))
            {
                DataTable dt_top = table.Clone();
                DataRow[] drs = table.Select("SUPER_REASON_CODE is null");
                foreach (DataRow dr in drs)
                {
                    DataRow dr_New = dt_top.NewRow();
                    dr_New.ItemArray = dr.ItemArray;
                    dt_top.Rows.Add(dr_New);
                }

                ColumnDefinition[] columns = new ColumnDefinition[dt_top.Rows.Count];

                for (int i = 0; i < dt_top.Rows.Count; i++)
                {
                    ColumnDefinition columnDefinition = new ColumnDefinition
                    {
                        SizeType = SizeType.Percent,
                        Width = 100 / dt_top.Rows.Count
                    };

                    columns[i] = columnDefinition;
                }
                Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

                RowDefinition rowDefinition = new RowDefinition
                {
                    Height = 100,
                    SizeType = SizeType.Percent
                };

                Root.OptionsTableLayoutGroup.RowDefinitions.Add(rowDefinition);

                BaseLayoutItem[] layoutItems = new BaseLayoutItem[dt_top.Rows.Count];
                int idx = 0;

                for (int col = 0; col < dt_top.Rows.Count && idx < dt_top.Rows.Count; col++)
                {
                    CheckButton checkButton = new DevExpress.XtraEditors.CheckButton
                    {
                        Location = new System.Drawing.Point(22, 22),
                        Name = dt_top.Rows[idx]["REASON_CODE"].ToString(),
                        Size = new System.Drawing.Size(176, 103),
                        Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold),
                        StyleController = layoutControl1,
                        GroupIndex = 1,
                        TabIndex = 4,
                        Text = dt_top.Rows[idx]["REASON_NAME"].ToString()
                    };
                    checkButton.Click += checkButton_Click;

                    layoutControl1.Controls.Add(checkButton);

                    LayoutControlItem layoutControlItem = new LayoutControlItem
                    {
                        Control = checkButton,
                        Location = new System.Drawing.Point(0, 0),
                        MinSize = new System.Drawing.Size(88, 26),
                        Name = "layoutControlItem1"
                    };
                    layoutControlItem.OptionsTableLayoutItem.ColumnIndex = col;
                    layoutControlItem.OptionsTableLayoutItem.RowIndex = 0;
                    layoutControlItem.Size = new System.Drawing.Size(180, 107);
                    layoutControlItem.SizeConstraintsType = SizeConstraintsType.Custom;
                    layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
                    layoutControlItem.TextVisible = false;

                    layoutItems[idx] = layoutControlItem;
                    idx++;
                }

                Root.Items.AddRange(layoutItems);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            CheckButton cb = (CheckButton)sender;

            Root_D.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
            Root_D.OptionsTableLayoutGroup.RowDefinitions.Clear();
            Root_D.Items.Clear();
            layoutControl3.Controls.Clear();

            DataTable dt_down = table.Clone();
            DataRow[] drs = table.Select("SUPER_REASON_CODE = '" + cb.Name + "'");
            foreach (DataRow dr in drs)
            {
                DataRow dr_New = dt_down.NewRow();
                dr_New.ItemArray = dr.ItemArray;
                dt_down.Rows.Add(dr_New);
            }

            int row_cnt = 3;//(int)(Math.Round(Convert.ToDouble((dt_down.Rows.Count) / col_cnt) + ((dt_down.Rows.Count) % col_cnt == 0 ? 0 : 1)));

            ColumnDefinition[] columns = new ColumnDefinition[col_cnt];
            RowDefinition[] rows = new RowDefinition[row_cnt];

            for (int i = 0; i < col_cnt; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition
                {
                    SizeType = SizeType.Percent,
                    Width = 100 / col_cnt
                };

                columns[i] = columnDefinition;
            }
            Root_D.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

            for (int i = 0; i < row_cnt; i++)
            {
                RowDefinition rowDefinition = new RowDefinition
                {
                    Height = 100 / row_cnt,
                    SizeType = SizeType.Percent
                };

                rows[i] = rowDefinition;
            }
            Root_D.OptionsTableLayoutGroup.RowDefinitions.AddRange(rows);

            BaseLayoutItem[] layoutItems = new BaseLayoutItem[dt_down.Rows.Count];
            int idx = 0;
            for (int row = 0; row < row_cnt && idx < dt_down.Rows.Count; row++)
            {
                for (int col = 0; col < col_cnt && idx < dt_down.Rows.Count; col++)
                {
                    CheckButton checkButton = new DevExpress.XtraEditors.CheckButton
                    {
                        Location = new System.Drawing.Point(22, 22),
                        Name = dt_down.Rows[idx]["REASON_CODE"].ToString(),
                        Size = new System.Drawing.Size(176, 103),
                        Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold),
                        StyleController = layoutControl1,
                        GroupIndex = 2,
                        TabIndex = 4,
                        Text = dt_down.Rows[idx]["REASON_NAME"].ToString()
                    };

                    layoutControl3.Controls.Add(checkButton);

                    LayoutControlItem layoutControlItem = new LayoutControlItem
                    {
                        Control = checkButton,
                        Location = new System.Drawing.Point(0, 0),
                        MinSize = new System.Drawing.Size(88, 26),
                        Name = "layoutControlItem1"
                    };
                    layoutControlItem.OptionsTableLayoutItem.ColumnIndex = col;
                    layoutControlItem.OptionsTableLayoutItem.RowIndex = row;
                    layoutControlItem.Size = new System.Drawing.Size(180, 107);
                    layoutControlItem.SizeConstraintsType = SizeConstraintsType.Custom;
                    layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
                    layoutControlItem.TextVisible = false;

                    layoutItems[idx] = layoutControlItem;
                    idx++;
                }
            }
            Root_D.Items.AddRange(layoutItems);
            layoutControl3.Refresh();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string DOWNTIME_CODE = "";

            foreach (Control control in layoutControl3.Controls)
            {
                if (control.GetType() == typeof(CheckButton))
                {
                    if ((control as CheckButton).Checked)
                    {
                        DOWNTIME_CODE = control.Name;
                        break;
                    }
                }
            }
            if (DOWNTIME_CODE == "")
            {
                MessageBox.Show("비가동 코드가 선택되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_REASON_CODE", DOWNTIME_CODE);
            _RYMES_DB._DB_Parameters.Add("@p_REASON_NOTES", txt_DOWNTIME_NOTES.Text);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());


            string sSQL = "";
            if(_isEquip)
            {
                sSQL = "WE_CELL_DOWNTIME_4CELL_SAVE";
            }
            else
            {
                sSQL = "WE_CELL_DOWNTIME_SAVE";
            }

            string sMsg = _RYMES_DB.SET_DATA(sSQL);
            if (string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}