using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_COMP_QTY_PopUp : frm_Base
    {
        private DataRow _Cell_Info;
        public  delegate void SnedString(string comp_qty);
        public event SnedString Get_Comp_qtry;

        public frm_COMP_QTY_PopUp(frm_Main frm_Main, DataRow Cell_Info)
        {
            InitializeComponent();

            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;

            //_comp_qty = textEdit7.Text;
            
        }

        private void frm_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_WO_ID", _Cell_Info["WO_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _Cell_Info["TICKET_ID"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_CSI_FT_COMP_QTY_LOAD", ref table);

            if (string.IsNullOrEmpty(sMsg))
            {

                textEdit1.Text = table.Rows[0]["PLAN_QTY"].ToString();
                textEdit2.Text = table.Rows[0]["COMP_QTY"].ToString();
                textEdit3.Text = table.Rows[0]["T_DEFECT_QTY"].ToString();
                textEdit4.Text = table.Rows[0]["LOT_QTY"].ToString();
                textEdit5.Text = table.Rows[0]["DEFECT_QTY"].ToString();
                textEdit6.Text = (Convert.ToInt32(table.Rows[0]["LOT_QTY"]) - Convert.ToInt32(table.Rows[0]["COMP_QTY"])).ToString();
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textEdit7.Text ))
            {
                MessageBox.Show("양품수량이 입력되지 않았습니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(textEdit7.Text) > Convert.ToInt32(textEdit6.Text))
            {
                MessageBox.Show("양품수량이 잔여수량을 초과 할수 없습니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Get_Comp_qtry(textEdit7.Text);
            DialogResult = DialogResult.Yes;
            Close();
        }

    
    }
}