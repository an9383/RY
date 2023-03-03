using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class OQC_CMOS_MAPLE_1314 : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet _ds;
        private frm_Base frm_Approval_Popup;

        public OQC_CMOS_MAPLE_1314(params object[] paramArray)
        {
            InitializeComponent();


            _ds = paramArray[0] as DataSet;
            frm_Approval_Popup = paramArray[1] as frm_Base;
            
            DataRow dr1 = _ds.Tables[0].Rows[0];

            lbl_CONFIRM_SIGNATURE.Text = dr1["CONFIRM_SIGNATURE"].ToString();
            lbl_APPLY_SIGNATURE.Text = dr1["APPLY_SIGNATURE"].ToString();

            if (_ds.Tables[1].Rows.Count > 0)
            {
                DataRow dr2 = _ds.Tables[1].Rows[0];
                lbl_CREATE_DATE.Text = dr2["CREATE_DATE"].ToString();
                lbl_CREATE_USER.Text = dr2["CREATE_SIGNATURE"].ToString();
                lbl_CREATE_SIGNATURE.Text = dr2["CREATE_SIGNATURE"].ToString();
            }

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

            DataSource = _ds.Tables[2];
            DataMember = _ds.Tables[2].TableName;

            lbl_NUM1.DataBindings.Add("Text", DataSource, "NUM1");
            lbl_NUM2.DataBindings.Add("Text", DataSource, "NUM2");
            lbl_NUM3.DataBindings.Add("Text", DataSource, "NUM3");
            lbl_NUM4.DataBindings.Add("Text", DataSource, "NUM4");

            lbl_PRODUCT_SN1.DataBindings.Add("Text", DataSource, "PRODUCT_SN1");
            lbl_PRODUCT_SN2.DataBindings.Add("Text", DataSource, "PRODUCT_SN2");

            lbl_CARD_SN1.DataBindings.Add("Text", DataSource, "CARD_SN1");
            lbl_CARD_SN2.DataBindings.Add("Text", DataSource, "CARD_SN2");
        }
    }
}