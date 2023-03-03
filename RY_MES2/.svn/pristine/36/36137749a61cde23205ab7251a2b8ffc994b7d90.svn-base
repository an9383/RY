using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class OQC_1012_Medical : DevExpress.XtraReports.UI.XtraReport
    {
        private frm_Base frm_Approval_Popup;

        public OQC_1012_Medical(params object[] paramArray)
        {
            InitializeComponent();

            DataSet _ds = paramArray[0] as DataSet;
            frm_Approval_Popup = paramArray[1] as frm_Base;

            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_OQC_TFT1.DataTable1.Rows.Add(item.ItemArray);
            }


            DataRow[] resolutions = _ds.Tables[2].Select("CHK_ID IN (2592, 2593)");

            foreach (DataRow resolution in resolutions)
            {
                if (resolution["CHK_ID"].ToString() == "2592" && resolution["VALUE_RESULT_NAME"].ToString() == "OK")
                {
                    lbl_Resolution.Text = "2520 × 2008의 픽셀해상도를 가져야 한다. (■) "
                                        + "(Must have pixel resolution of 2520 x 2008)\n"
                                        + "2264 × 1752의 픽셀해상도를 가져야 한다. (□) "
                                        + "(Must have pixel resolution of 2264 x 1752)";
                    lbl_Resolution_Value.Text = resolutions[0]["INSPECTION_RESULT"].ToString();
                }
                else if (resolution["CHK_ID"].ToString() == "2593" && resolution["VALUE_RESULT_NAME"].ToString() == "OK")
                {
                    lbl_Resolution.Text = "2520 × 2008의 픽셀해상도를 가져야 한다. (□) "
                                        + "(Must have pixel resolution of 2520 x 2008)\n"
                                        + "2264 × 1752의 픽셀해상도를 가져야 한다. (■) "
                                        + "(Must have pixel resolution of 2264 x 1752)";
                    lbl_Resolution_Value.Text = resolutions[0]["INSPECTION_RESULT"].ToString();
                }
            }
            

            XRControl control = null;

            foreach (DataRow row in _ds.Tables[2].Rows)
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