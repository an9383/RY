using System;

namespace RY_MES.Forms
{
    public partial class frm_PowerBI_TFT : RY_MES.frm_Base
    {
        public frm_PowerBI_TFT()
        {
            InitializeComponent();
        }

        public frm_PowerBI_TFT(object[] paramArray)
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            btn_Conditions_Click(null, null);
        }
    }
}