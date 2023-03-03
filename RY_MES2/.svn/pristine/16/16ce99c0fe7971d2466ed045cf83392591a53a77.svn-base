using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Defect_PopUp : frm_Base
    {
        private DataTable table;
        private DataTable table2;
        private DataRow _Cell_Info;
        private int col_cnt = 5;
        private string _Wafer_no;

        public frm_Defect_PopUp(frm_Main frm_Main, DataRow Cell_Info)
        {
            InitializeComponent();

            init_PopUp();

            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;          

            Set_Description(layoutControl2);
        }

        public frm_Defect_PopUp(frm_Main frm_Main, DataRow Cell_Info, string Wafer_no)
        {
            InitializeComponent();

            init_PopUp();

            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;

            Set_Description(layoutControl2);
            _Wafer_no = Wafer_no;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                SET_LookUpEdit_Data(sle_Wafer, "WAFER_LIST_WO", _Cell_Info["WO_ID"].ToString());

                if((sle_Wafer.Properties.DataSource as DataTable).Rows.Count == 1)
                {
                    sle_Wafer.EditValue = (sle_Wafer.Properties.DataSource as DataTable).Rows[0][0];
                    sle_Wafer.Enabled = false;
                }
                else if (!string.IsNullOrEmpty(_Wafer_no))
                {
                    sle_Wafer.EditValue = _Wafer_no;
                    sle_Wafer.Enabled = false;
                }

                DataTable dt_WT = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _Cell_Info["TICKET_ID"].ToString());
                string sMsg_WT = _RYMES_DB.GET_DATA("WE_TICKET_INFO_LOAD", ref dt_WT);
                if (string.IsNullOrEmpty(sMsg_WT))
                {
                    if(dt_WT.Rows[0]["ITEM_TYPE"].ToString() != "TFT" && _Cell_Info["FA_ID"].ToString() == "CSI")
                    {
                        layoutControlItem4.ContentVisible = false;
                    }
                    else
                    {
                        layoutControlItem4.ContentVisible = false;
                    }
                }
                else
                {
                    MessageBox.Show(sMsg_WT, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Get_Data_Defect_Code();
                Get_Data_Cause_Code();
                Get_Data_Result_Code();

                layoutControl5.Visible = false;
                layoutControl6.Visible = false;
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }
        }

        private void Get_Data_Defect_Code()
        {
            table = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_DEFECT_CODE_LOAD", ref table);
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

                ColumnDefinition[] columns = new ColumnDefinition[dt_top.Rows.Count > 10 ? 8 : dt_top.Rows.Count];

                for (int i = 0; i < (dt_top.Rows.Count > 10 ? 8 : dt_top.Rows.Count); i++)
                {
                    ColumnDefinition columnDefinition = new ColumnDefinition
                    {
                        SizeType = SizeType.Percent,
                        Width = 100 / dt_top.Rows.Count
                    };

                    columns[i] = columnDefinition;
                }
                Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

                RowDefinition[] rows = new RowDefinition[dt_top.Rows.Count > 10 ? 2 : 1];

                for (int i = 0; i < (dt_top.Rows.Count > 10 ? 2 : 1); i++)
                {
                    RowDefinition rowDefinition = new RowDefinition
                    {
                        Height = 100,
                        SizeType = SizeType.Percent
                    };

                    rows[i] = rowDefinition;
                }
                Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(rows);

               

                BaseLayoutItem[] layoutItems = new BaseLayoutItem[dt_top.Rows.Count];
                int idx = 0;

                for (int col = 0; col < Root.OptionsTableLayoutGroup.ColumnDefinitions.Count && idx < dt_top.Rows.Count; col++)
                {
                    for (int row = 0; row < Root.OptionsTableLayoutGroup.RowDefinitions.Count && idx < dt_top.Rows.Count; row++)
                    {
                        CheckButton checkButton = new DevExpress.XtraEditors.CheckButton
                        {
                            Location = new System.Drawing.Point(22, 22),
                            Name = dt_top.Rows[idx]["REASON_CODE"].ToString(),
                            Size = new System.Drawing.Size(176, 103),
                            Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold),
                            StyleController = layoutControl1,
                            GroupIndex = 1,
                            TabIndex = 4,
                            Text = dt_top.Rows[idx]["REASON_NAME"].ToString()
                        };
                        checkButton.Click += checkButton_Click;
                        checkButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        layoutControl4.Controls.Add(checkButton);

                        LayoutControlItem layoutControlItem = new LayoutControlItem
                        {
                            Control = checkButton,
                            Location = new System.Drawing.Point(0, 0),
                            MinSize = new System.Drawing.Size(88, 26),
                            Name = "layoutControlItem4"
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

                Root.Items.AddRange(layoutItems);
            }
            //int row_cnt = (int)(Math.Round(Convert.ToDouble((table.Rows.Count) / col_cnt) + ((table.Rows.Count) % col_cnt == 0 ? 0 : 1)));

            //    ColumnDefinition[] columns = new ColumnDefinition[col_cnt];
            //    RowDefinition[] rows = new RowDefinition[row_cnt];

            //    for (int i = 0; i < col_cnt; i++)
            //    {
            //        ColumnDefinition columnDefinition = new ColumnDefinition
            //        {
            //            SizeType = SizeType.Percent,
            //            Width = 100 / col_cnt
            //        };

            //        columns[i] = columnDefinition;
            //    }
            //    Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

            //    for (int i = 0; i < row_cnt; i++)
            //    {
            //        RowDefinition rowDefinition = new RowDefinition
            //        {
            //            Height = 100 / row_cnt,
            //            SizeType = SizeType.Percent
            //        };

            //        rows[i] = rowDefinition;
            //    }
            //    Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(rows);

            //    BaseLayoutItem[] layoutItems = new BaseLayoutItem[table.Rows.Count];
            //    int idx = 0;
            //    for (int row = 0; row < row_cnt && idx < table.Rows.Count; row++)
            //    {
            //        for (int col = 0; col < col_cnt && idx < table.Rows.Count; col++)
            //        {
            //            CheckButton checkButton = new DevExpress.XtraEditors.CheckButton
            //            {
            //                Location = new System.Drawing.Point(22, 22),
            //                Name = table.Rows[idx]["REASON_CODE"].ToString(),
            //                Size = new System.Drawing.Size(176, 103),
            //                Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold),
            //                StyleController = layoutControl1,
            //                GroupIndex = 1,
            //                TabIndex = 4,
            //                Text = table.Rows[idx]["REASON_NAME"].ToString()
            //            };

            //            layoutControl1.Controls.Add(checkButton);

            //            LayoutControlItem layoutControlItem = new LayoutControlItem
            //            {
            //                Control = checkButton,
            //                Location = new System.Drawing.Point(0, 0),
            //                MinSize = new System.Drawing.Size(88, 26),
            //                Name = "layoutControlItem1"
            //            };
            //            layoutControlItem.OptionsTableLayoutItem.ColumnIndex = col;
            //            layoutControlItem.OptionsTableLayoutItem.RowIndex = row;
            //            layoutControlItem.Size = new System.Drawing.Size(180, 107);
            //            layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            //            layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            //            layoutControlItem.TextVisible = false;

            //            layoutItems[idx] = layoutControlItem;
            //            idx++;
            //        }
            //    }
            //    Root.Items.AddRange(layoutItems);
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Get_Data_Cause_Code()
        {
            table2 = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_DEFECT_CAUSE_CODE_LOAD", ref table2);
            if (string.IsNullOrEmpty(sMsg))
            {
                DataTable dt_top = table2.Clone();
                DataRow[] drs = table2.Select("SUPER_REASON_CODE is null");
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
                layoutControlGroup2.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

                RowDefinition rowDefinition = new RowDefinition
                {
                    Height = 100,
                    SizeType = SizeType.Percent
                };

                layoutControlGroup2.OptionsTableLayoutGroup.RowDefinitions.Add(rowDefinition);

                BaseLayoutItem[] layoutItems = new BaseLayoutItem[dt_top.Rows.Count];
                int idx = 0;

                for (int col = 0; col < dt_top.Rows.Count && idx < dt_top.Rows.Count; col++)
                {
                    CheckButton checkButton = new DevExpress.XtraEditors.CheckButton
                    {
                        Location = new System.Drawing.Point(22, 22),
                        Name = dt_top.Rows[idx]["REASON_CODE"].ToString(),
                        Size = new System.Drawing.Size(176, 103),
                        Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold),
                        StyleController = layoutControl1,
                        GroupIndex = 1,
                        TabIndex = 4,
                        Text = dt_top.Rows[idx]["REASON_NAME"].ToString()
                    };
                    checkButton.Click += checkButton_Click3;
                    checkButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    layoutControl5.Controls.Add(checkButton);

                    LayoutControlItem layoutControlItem = new LayoutControlItem
                    {
                        Control = checkButton,
                        Location = new System.Drawing.Point(0, 0),
                        MinSize = new System.Drawing.Size(88, 26),
                        Name = "layoutControlItem5"
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

                layoutControlGroup2.Items.AddRange(layoutItems);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkButton_Click2(object sender, EventArgs e)
        {
            CheckButton checkButton = (CheckButton)sender;

            if (checkButton.Name == "0001")
            {
                layoutControl5.Visible = true;
                layoutControl6.Visible = true;
            }
            else
            {
                layoutControl5.Visible = false;
                layoutControl6.Visible = false;
            }
        }

        private void checkButton_Click3(object sender, EventArgs e)
        {
            CheckButton cb = (CheckButton)sender;

            layoutControlGroup3.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
            layoutControlGroup3.OptionsTableLayoutGroup.RowDefinitions.Clear();
            layoutControlGroup3.Items.Clear();
            layoutControl6.Controls.Clear();

            DataTable dt_down = table2.Clone();
            DataRow[] drs = table2.Select("SUPER_REASON_CODE = '" + cb.Name + "'");
            foreach (DataRow dr in drs)
            {
                DataRow dr_New = dt_down.NewRow();
                dr_New.ItemArray = dr.ItemArray;
                dt_down.Rows.Add(dr_New);
            }

            int row_cnt = 4;//(int)(Math.Round(Convert.ToDouble((dt_down.Rows.Count) / col_cnt) + ((dt_down.Rows.Count) % col_cnt == 0 ? 0 : 1)));

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
            layoutControlGroup3.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

            for (int i = 0; i < row_cnt; i++)
            {
                RowDefinition rowDefinition = new RowDefinition
                {
                    Height = 100 / row_cnt,
                    SizeType = SizeType.Percent
                };

                rows[i] = rowDefinition;
            }
            layoutControlGroup3.OptionsTableLayoutGroup.RowDefinitions.AddRange(rows);

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
                        Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold),
                        StyleController = layoutControl6,
                        GroupIndex = 2,
                        TabIndex = 4,
                        Text = dt_down.Rows[idx]["REASON_NAME"].ToString()
                    };
                    checkButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    layoutControl6.Controls.Add(checkButton);

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
            layoutControlGroup3.Items.AddRange(layoutItems);
            layoutControl6.Refresh();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            CheckButton cb = (CheckButton)sender;

            Root_D.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
            Root_D.OptionsTableLayoutGroup.RowDefinitions.Clear();
            Root_D.Items.Clear();
            layoutControl1.Controls.Clear();

            DataTable dt_down = table.Clone();
            DataRow[] drs = table.Select("SUPER_REASON_CODE = '" + cb.Name + "'");
            foreach (DataRow dr in drs)
            {
                DataRow dr_New = dt_down.NewRow();
                dr_New.ItemArray = dr.ItemArray;
                dt_down.Rows.Add(dr_New);
            }

            int row_cnt = 4;//(int)(Math.Round(Convert.ToDouble((dt_down.Rows.Count) / col_cnt) + ((dt_down.Rows.Count) % col_cnt == 0 ? 0 : 1)));

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
                        Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold),
                        StyleController = layoutControl1,
                        GroupIndex = 2,
                        TabIndex = 4,
                        Text = dt_down.Rows[idx]["REASON_NAME"].ToString()
                    };
                    checkButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    layoutControl1.Controls.Add(checkButton);

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
            layoutControl1.Refresh();
        }

        private void Get_Data_Result_Code()
        {
            DataTable table_R = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_RESULT_CODE_LOAD", ref table_R);
            if (string.IsNullOrEmpty(sMsg) || sMsg == "Result FirstTable Rows Count is Zero")
            {
                ColumnDefinition[] columns = new ColumnDefinition[table_R.Rows.Count - 1];

                for (int i = 0; i < table_R.Rows.Count - 1; i++)
                {
                    ColumnDefinition columnDefinition = new ColumnDefinition
                    {
                        SizeType = SizeType.Percent,
                        Width = 100
                    };

                    columns[i] = columnDefinition;
                }
                Root_R.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

                BaseLayoutItem[] layoutItems = new BaseLayoutItem[table_R.Rows.Count];

                for (int col = 0; col < table_R.Rows.Count; col++)
                {
                    CheckButton checkButton = new DevExpress.XtraEditors.CheckButton
                    {
                        Location = new System.Drawing.Point(22, 22),
                        Name = table_R.Rows[col]["REASON_CODE"].ToString(),
                        Size = new System.Drawing.Size(176, 103),
                        Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold),
                        StyleController = layoutControl2,
                        GroupIndex = 2,
                        TabIndex = 4,
                        Text = table_R.Rows[col]["REASON_NAME"].ToString()
                    };
                    checkButton.Click += checkButton_Click2;

                    layoutControl2.Controls.Add(checkButton);

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
                    layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
                    layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
                    layoutControlItem.TextVisible = false;

                    layoutItems[col] = layoutControlItem;
                }
                Root_R.Items.AddRange(layoutItems);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            string DEFECT_CODE = "";
            string DEFECT_RESULT = "";
            string DEFECT_CAUSE = "";

            foreach (Control control in layoutControl1.Controls)
            {
                if (control.GetType() == typeof(CheckButton))
                {
                    if ((control as CheckButton).Checked)
                    {
                        DEFECT_CODE = control.Name;
                        break;
                    }
                }
            }
            if (DEFECT_CODE == "")
            {
                MessageBox.Show("부적합 코드가 선택되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sle_Wafer.EditValue is null)
            {
                MessageBox.Show("Wafer가 선택되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Control control in layoutControl3.Controls)
            {
                if (control.GetType() == typeof(CheckButton))
                {
                    if ((control as CheckButton).Checked)
                    {
                        DEFECT_RESULT = control.Name;
                        break;
                    }
                }
            }
            if (DEFECT_RESULT == "")
            {
                MessageBox.Show("부적합 처리 코드가 선택되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Control control in layoutControl6.Controls)
            {
                if (control.GetType() == typeof(CheckButton))
                {
                    if ((control as CheckButton).Checked)
                    {
                        DEFECT_CAUSE = control.Name;
                        break;
                    }
                }
            }

            if (DEFECT_RESULT == "0001" && DEFECT_CAUSE == "")
            {
                MessageBox.Show("부적합 원인 코드가 선택되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DEFECT_RESULT != "0001" && _Cell_Info["OP_TYPE"].ToString() != "0001" &&  (_Cell_Info["FA_ID"].ToString() != "CSI" ))
            {
                if (DialogResult.Yes != MessageBox.Show("해당 작업지시를 취소 합니까?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    return;
                }
            }

            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_WO_ID", _Cell_Info["WO_ID"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _Cell_Info["TICKET_ID"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_DEFECT_CODE", DEFECT_CODE);
            _RYMES_DB._DB_Parameters.Add("@p_DEFECT_CAUSE", DEFECT_CAUSE);
            _RYMES_DB._DB_Parameters.Add("@p_DEFECT_SN", sle_Wafer.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_DEFECT_RESULT", DEFECT_RESULT);
            _RYMES_DB._DB_Parameters.Add("@p_DEFECT_NOTES", txt_DEFECT_NOTES.Text);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            string sMsg = _RYMES_DB.SET_DATA(button.Tag.ToString() == "LOT" ? "WE_DEFECT_INSERT_WO" :  "WE_DEFECT_INSERT");
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