using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Check_Sheet_Input_B_PopUp : frm_Base
    {
        private DataTable table;
        private DataRow _Cell_Info;
        private DataRow _Check_Ieem;
        private int col_cnt = 3;

        public frm_Check_Sheet_Input_B_PopUp(frm_Main frm_Main, DataRow Cell_Info, DataRow Check_Ieem)
        {
            InitializeComponent();

            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
            _Check_Ieem = Check_Ieem;

            Text = Check_Ieem["CHK_NAME"].ToString();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            Get_Data_Code();

            foreach (Control control in layoutControl1.Controls)
            {
                if (control.GetType() == typeof(CheckButton))
                {
                    if (_Check_Ieem["VALUE_RESULT"].ToString().IndexOf(control.Name) > -1 && _Check_Ieem["VALUE_RESULT_NAME"].ToString().IndexOf(control.Name) > -1)
                    {
                        (control as CheckButton).Checked = true;
                    }
                }
            }
        }

        private void Get_Data_Code()
        {
            string INSPECTION_TYPE = _Check_Ieem["INSPECTION_TYPE"].ToString();
            table = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_GROUP_CODE", _Check_Ieem["INSPECTION_TYPE_RESULT"].ToString());
            string sMsg = _RYMES_DB.GET_DATA("SYS_CODE_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                int row_cnt = (int)(Math.Round(Convert.ToDouble((table.Rows.Count) / col_cnt) + ((table.Rows.Count) % col_cnt == 0 ? 0 : 1)));

                col_cnt = table.Rows.Count < col_cnt ? table.Rows.Count : col_cnt;

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

                Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(columns);

                for (int i = 0; i < row_cnt; i++)
                {
                    RowDefinition rowDefinition = new RowDefinition
                    {
                        Height = 100 / row_cnt,
                        SizeType = SizeType.Percent
                    };

                    rows[i] = rowDefinition;
                }

                Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(rows);

                BaseLayoutItem[] layoutItems = new BaseLayoutItem[table.Rows.Count];
                int idx = 0;
                for (int row = 0; row < row_cnt && idx < table.Rows.Count; row++)
                {
                    for (int col = 0; col < col_cnt && idx < table.Rows.Count; col++)
                    {
                        CheckButton checkButton = new CheckButton
                        {
                            Location = new System.Drawing.Point(22, 22),
                            Name = table.Rows[idx]["코드"].ToString(),
                            Size = new System.Drawing.Size(176, 103),
                            Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold),
                            StyleController = layoutControl1,
                            GroupIndex = INSPECTION_TYPE == "RADIO" ? 1 : -1,
                            Text = table.Rows[idx]["코드명"].ToString(),
                            Checked = table.Rows[idx]["코드"].ToString() == "OK" ? true : false
                        };
                        if (checkButton.GroupIndex == 1)
                        {
                            checkButton.Click += btn_Save_Click;
                        }
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
                        layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
                        layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
                        layoutControlItem.TextVisible = false;

                        layoutItems[idx] = layoutControlItem;
                        idx++;
                    }
                }
                Root.Items.AddRange(layoutItems);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string CODE = "";
            string CODE_NAME = "";

            if (sender.GetType() == typeof(CheckButton))
            {
                CODE = (sender as CheckButton).Name;
                CODE_NAME = (sender as CheckButton).Text;
            }
            else
            {
                foreach (Control control in layoutControl1.Controls)
                {
                    if (control.GetType() == typeof(CheckButton))
                    {
                        if ((control as CheckButton).Checked)
                        {
                            CODE += control.Name + ",";
                            CODE_NAME += control.Text + ",";
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(CODE))
                {
                    CODE = CODE.Substring(0, CODE.Length - 1);
                    CODE_NAME = CODE_NAME.Substring(0, CODE_NAME.Length - 1);
                }
            }

            _RYMES_DB._DB_Parameters.Add("@p_VALUE_ID", _Check_Ieem["VALUE_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT", CODE);
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT_NAME", CODE_NAME);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("WE_CHECK_SHEET_MERGE");
            if (string.IsNullOrEmpty(sMsg))
            {
                //MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}