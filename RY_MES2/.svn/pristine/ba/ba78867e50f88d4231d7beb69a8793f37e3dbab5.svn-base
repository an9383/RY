using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class OQC_1417_Medical : DevExpress.XtraReports.UI.XtraReport
    {
        private frm_Base frm_Approval_Popup;

        public OQC_1417_Medical(params object[] paramArray)
        {
            InitializeComponent();

            DataSet _ds = paramArray[0] as DataSet;
            frm_Approval_Popup = paramArray[1] as frm_Base;

            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_OQC_TFT1.DataTable1.Rows.Add(item.ItemArray);
            }


            DataRow[] resolutions = _ds.Tables[2].Select("CHK_ID IN (2588, 2589)");

            foreach (DataRow resolution in resolutions)
            {
                if (resolution["CHK_ID"].ToString() == "2588" && resolution["VALUE_RESULT_NAME"].ToString() == "OK")
                {
                    lbl_Resolution.Text = "3268 × 2756의 픽셀해상도를 가져야 한다. (■ 127㎛)"
                                        + "(Must have pixel resolution of 3268 x 2756)\n"
                                        + "2440 × 2992의 픽셀해상도를 가져야 한다. (□ 140㎛)"
                                        + "(Must have pixel resolution of 2440 x 2992)";
                    lbl_Resolution_Value.Text = resolutions[0]["INSPECTION_RESULT"].ToString();
                }
                else if (resolution["CHK_ID"].ToString() == "2589" && resolution["VALUE_RESULT_NAME"].ToString() == "OK")
                {
                    lbl_Resolution.Text = "3268 × 2756의 픽셀해상도를 가져야 한다. (□ 127㎛)"
                                        + "(Must have pixel resolution of 3268 x 2756)\n"
                                        + "2440 × 2992의 픽셀해상도를 가져야 한다. (■ 140㎛)"
                                        + "(Must have pixel resolution of 2440 x 2992)";
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