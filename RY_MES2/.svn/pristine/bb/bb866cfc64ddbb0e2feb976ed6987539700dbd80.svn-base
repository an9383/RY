using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RY_MES.Forms
{
    public partial class UC_OP_STAUS : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_OP_STAUS()
        {
            InitializeComponent();
        }

        public UC_OP_STAUS(DataRow dr)
        {
            InitializeComponent();
            SET_DATA(dr);
        }

        public void SET_DATA(DataRow dr)
        {
            OP_ID.Text = chk_val(dr["OP_ID"]);
            textEdit1.Text = chk_val(dr["PLAN_QTY"]);
            textEdit2.Text = chk_val(dr["IN_QTY"]);
            textEdit3.Text = chk_val(dr["OUT_QTY"]);
            CELL_CODE_1.Text = chk_val(dr["CELL_CODE_1"]);
            USER_NAME_1.Text = chk_val(dr["USER_NAME_1"]);
            MODEL_1.Text = chk_val(dr["MODEL_1"]);
            CELL_CODE_2.Text = chk_val(dr["CELL_CODE_2"]);
            USER_NAME_2.Text = chk_val(dr["USER_NAME_2"]);
            MODEL_2.Text = chk_val(dr["MODEL_2"]);
            CELL_CODE_3.Text = chk_val(dr["CELL_CODE_3"]);
            USER_NAME_3.Text = chk_val(dr["USER_NAME_3"]);
            MODEL_3.Text = chk_val(dr["MODEL_3"]);
            CELL_CODE_4.Text = chk_val(dr["CELL_CODE_4"]);
            USER_NAME_4.Text = chk_val(dr["USER_NAME_4"]);
            MODEL_4.Text = chk_val(dr["MODEL_4"]);
            CELL_CODE_5.Text = chk_val(dr["CELL_CODE_5"]);
            USER_NAME_5.Text = chk_val(dr["USER_NAME_5"]);
            MODEL_5.Text = chk_val(dr["MODEL_5"]);
            CELL_CODE_6.Text = chk_val(dr["CELL_CODE_6"]);
            USER_NAME_6.Text = chk_val(dr["USER_NAME_6"]);
            MODEL_6.Text = chk_val(dr["MODEL_6"]);

            Color color = new Color();
            switch (dr["CELL_STATE_1"].ToString())
            {
                case "0001":
                    color = Color.Lime;
                    break;

                case "0002":
                    color = Color.Gold;
                    break;

                case "0003":
                    color = Color.Gray;
                    break;
            }

            CELL_CODE_1.AppearanceItemCaption.BackColor = Get_BackColor(dr["CELL_STATE_1"].ToString());
            CELL_CODE_2.AppearanceItemCaption.BackColor = Get_BackColor(dr["CELL_STATE_2"].ToString());
            CELL_CODE_3.AppearanceItemCaption.BackColor = Get_BackColor(dr["CELL_STATE_3"].ToString());
            CELL_CODE_4.AppearanceItemCaption.BackColor = Get_BackColor(dr["CELL_STATE_4"].ToString());
            CELL_CODE_5.AppearanceItemCaption.BackColor = Get_BackColor(dr["CELL_STATE_5"].ToString());
            CELL_CODE_6.AppearanceItemCaption.BackColor = Get_BackColor(dr["CELL_STATE_6"].ToString());
        }

        private Color Get_BackColor(string CELL_STATE)
        {
            Color color = new Color();
            switch (CELL_STATE)
            {
                case "0001":
                    color = Color.Lime;
                    break;

                case "0002":
                    color = Color.Gold;
                    break;

                case "0003":
                    color = Color.Gray;
                    break;
            }
            return color;
        }

        private string chk_val(object v)
        {
            return (v is DBNull) ? " " : (v ?? " ").ToString();
        }
    }
}