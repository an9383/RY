using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Approval_Popup : RY_MES.frm_Base
    {
        public DataSet ds;
        private string _ticket_id;
        private string _fa_id;
        private string _template_type;
        private string _wafer_no;
        private string _oqc_types;

        public frm_Approval_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            _ticket_id = paramArray[0].ToString();
            _fa_id = paramArray[1].ToString();
            _template_type = paramArray[2].ToString();
            _wafer_no = paramArray[3].ToString();

            btn_Update.Visible = false;

            if (_template_type == "0001")
            {
                this.Text = "런시트 조회";
            }
            else if (_template_type == "0002")
            {
                this.Text = "성적서 조회";
            }
                        
            if (paramArray.Length == 5)
            {
                _oqc_types = paramArray[4].ToString();
            }
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                XtraReport report = null;
                
                ds = new DataSet();

                _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _ticket_id);
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _template_type);
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _wafer_no);

                string sMsg = _RYMES_DB.GET_DATA("QM_CA_QC_PRODUCT_REPORT" + "_" + _fa_id, ref ds);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("DB Error", sMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow dr = ds.Tables[0].Rows[0];

                if (_template_type == "0001")
                {
                    if (_fa_id == "CMOS")
                    {
                        report = new QC_CMOS_REPORT(ds);
                    }
                    else if (_fa_id == "TFT")
                    {
                        if (dr["ITEM_TYPE"].ToString() == "SW")
                        {
                            report = new QC_TFT_SW_REPORT(ds);
                        }
                        else
                        {
                            report = new QC_TFT_REPORT(ds);
                        }
                    }
                    else if (_fa_id == "CSI")
                    {
                        if (dr["ITEM_TYPE"].ToString() == "TFT")
                        {
                            report = new QC_CSI_REPORT_TFT(ds);
                        }
                        else
                        {
                            report = new QC_CSI_REPORT(ds);
                        }
                    }

                    if (report != null)
                    {
                        report.CreateDocument();
                        documentViewer1.DocumentSource = report;
                    }
                }
                else if (_template_type == "0002" && _fa_id == "CMOS")
                {
                    Type type = Type.GetType(GetType().Namespace + "." + dr["TEMPLATE_FORM"].ToString() + "," + Assembly.GetExecutingAssembly().GetName().Name);
                    if (!(type is null))
                    {
                        report = (XtraReport)Activator.CreateInstance(type, ds, this);
                    }

                    if (report != null)
                    {
                        report.CreateDocument();
                        documentViewer1.DocumentSource = report;
                    }
                }
                else if (_template_type == "0002" && _fa_id == "TFT")
                {
                    report = new XtraReport();

                    string[] oqc_types = _oqc_types.Split(',');

                    foreach (string oqc_type in oqc_types)
                    {
                        XtraReport report_temp = null;

                        if (oqc_type == "CERTIFICATION")
                        {
                            Type type = Type.GetType(GetType().Namespace + "." + dr["TEMPLATE_FORM"].ToString() + "," + Assembly.GetExecutingAssembly().GetName().Name);
                            if (!(type is null))
                            {
                                report_temp = (XtraReport)Activator.CreateInstance(type, ds, this);
                            }
                        }
                        else if (oqc_type == "PERFORMANCE")
                        {
                            if (dr["DELPHI_YN"].ToString() == "Y")
                            {
                                // GE향 performance 성적서
                                report_temp = new Performance_GE(ds, this);
                            }
                            else if (dr["PANEL_ID_IS_SN"].ToString() == "Y")
                            {
                                // OSKO performance 성적서
                                report_temp = new Performance_OSKO(ds, this);
                            }
                            else
                            {
                                // 일반용 performance 성적서
                                report_temp = new Performance_Normal(ds, this);
                            }
                        }
                        else if (oqc_type == "SUPPLY")
                        {
                            if (dr["DELPHI_YN"].ToString() == "Y")
                            {
                                // GE향 Supply part list
                                report_temp = new SupplyPartList_GE(ds);
                            }
                            else
                            {
                                // 일반용 Supply part list
                                report_temp = new SupplyPartList_Normal(ds);
                            }
                        }

                        if (report_temp != null)
                        {
                            report_temp.CreateDocument();

                            report.ModifyDocument(x =>
                            {
                                x.AddPages(report_temp.Pages);
                            });
                        }
                    }

                    if (report.Pages.Count > 0)
                    {
                        documentViewer1.DocumentSource = report;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            try
            {
                if (_Main._User_Info["AUTH_CODE"].ToString() == "1002")
                {
                    _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _ticket_id);
                    _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _template_type);
                    _RYMES_DB._DB_Parameters.Add("@p_APPLY_USER", _Main._User_Info["USER_CODE"].ToString());
                }
                else
                {
                    MessageBox.Show("승인 권한이 없습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sMsg = _RYMES_DB.SET_DATA("QM_CA_QC_DOC_HIS_UPDATE");

                SplashScreenManager.CloseForm(false);

                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Frm_Load(null, null);
        }
    }
}