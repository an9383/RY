using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class OQC_IOS_HDI_DCA : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet _ds;
        private frm_Base frm_Approval_Popup;

        public OQC_IOS_HDI_DCA(params object[] paramArray)
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

            string qcDocID = dr1["OQC_DOC_ID"].ToString();

            if (qcDocID.Equals("222"))
            {
                lbl_ProductName.Text = "□Medical  □Veterinary" + lbl_ProductName.Text;
                lbl_ModelName.Text = "■ HDI-10DCA  □ HDI-20DCA";
                lbl_Version.Text = "■ 1.0    □ 2.0";
            }
            else if (qcDocID.Equals("223"))
            {
                lbl_ProductName.Text = "□Medical  □Veterinary" + lbl_ProductName.Text;
                lbl_ModelName.Text = "□ HDI-10DCA  ■ HDI-20DCA";
                lbl_Version.Text = "□ 1.0    ■ 2.0";
            }

            DataRow[] resolutions = _ds.Tables[1].Select("CHK_ID IN (2640, 2641)");
            if (resolutions.Length > 0)
            {
                lbl_Resolution.Text = resolutions[0]["CRITERIA"].ToString();
                lbl_Resolution_Value.Text = resolutions[0]["INSPECTION_RESULT"].ToString();
            }

            DataRow[] sws = _ds.Tables[1].Select("CHK_ID IN (1523)");
            if (sws.Length > 0)
            {
                lbl_SW_Value.Text = sws[0]["INSPECTION_VALUE"].ToString();
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
        }
    }
}