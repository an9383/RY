using DevExpress.Office.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Drawing;

namespace RY_MES.Forms
{
    public partial class QC_CSI_REPORT_TFT : DevExpress.XtraReports.UI.XtraReport
    {

        public QC_CSI_REPORT_TFT(DataSet ds)
        {
            InitializeComponent();

            DataSet _ds = ds;
            
            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_QC_CSI1.DataTable1.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[2].Rows)
            {
                ds_QC_CSI1.DataTable2.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[3].Rows)
            {
                ds_QC_CSI1.DataTable3.Rows.Add(item.ItemArray);
            }

            DataSource = ds_QC_CSI1;


            ExpressionBinding expressionBinding1 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME]");
            ExpressionBinding expressionBinding2 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME] + [EQUIP_NAME]");
            ExpressionBinding expressionBinding3 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME] + [UPDATE_USER]");
            ExpressionBinding expressionBinding4 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME] + [WO_START_DATE] + [WO_END_DATE]");


            lbl_OP_NAME.ExpressionBindings.Add(expressionBinding1);
            lbl_EQUIP_NAME.ExpressionBindings.Add(expressionBinding2);
            lbl_UPDATE_USER.ExpressionBindings.Add(expressionBinding3);
            lbl_DATE.ExpressionBindings.Add(expressionBinding4);


            float startX = xrPictureBox1.LocationF.X;
            float startY = xrPictureBox1.LocationF.Y;
             
            foreach (DataRow item in _ds.Tables[4].Rows)
            {
                string[] points = item["HIS_DESC"].ToString().Split(',');

                if (points.Length == 2)
                {
                    float pointX = Convert.ToInt32(points[0])*2 + 12;
                    float pointY = Convert.ToInt32(points[1])*2 - 10;
                    //float pointY = (Convert.ToInt32(points[1])) * 2 + 10;

                    XRLabel label = new XRLabel
                    {
                        Dpi = 254F,
                        LocationFloat = new DevExpress.Utils.PointFloat(startX + pointX, startY + pointY),
                        //LocationFloat = new DevExpress.Utils.PointFloat(330.7292F, 336.5833F),
                        Multiline = true,
                        Name = "lbl_location_" + item["NO"].ToString(),
                        SizeF = new System.Drawing.SizeF(24F, 56F),
                        Text = item["NO"].ToString(),
                        Font = new System.Drawing.Font("Tahoma", 10F),
                        TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    };


                    Detail3.Controls.Add(label);
                }
            }

            xrPictureBox1.SendToBack();
            xrPictureBox1.Visible = true;


        }

    }
}