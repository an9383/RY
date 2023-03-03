using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class OQC_MAMMO_2434CM : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet _ds;
        private frm_Base frm_Approval_Popup;

        public OQC_MAMMO_2434CM(params object[] paramArray)
        {
            InitializeComponent();

            _ds = paramArray[0] as DataSet;
            frm_Approval_Popup = paramArray[1] as frm_Base;

            DataRow dr1 = _ds.Tables[0].Rows[0];
            DataRow dr2 = _ds.Tables[1].Rows[0];

            lbl_ApprovalDate.Text = dr1["APPLY_DATE"].ToString();
            lbl_ApprovalUser.Text = dr1["APPLY_SIGNATURE"].ToString();
            lbl_CreateDate1.Text = dr2["CREATE_DATE"].ToString();
            lbl_CreateDate2.Text = dr2["CREATE_DATE"].ToString();
            lbl_CreateUser1.Text = dr2["CREATE_SIGNATURE"].ToString();
            lbl_CreateUser2.Text = dr2["CREATE_SIGNATURE"].ToString();
            lbl_SN.Text = dr1["PRODUCT_SN"].ToString();
            

            XRControl control = null;

            foreach (DataRow row in _ds.Tables[1].Rows)
            {
                string lbl_name = "lbl_" + row["CHK_ID"].ToString();

                control = frm_Approval_Popup.findControlByName(this, lbl_name);

                if (!(control is null))
                {
                    control.Text = row["INSPECTION_RESULT"].ToString();
                }
            }
        }
    }
}