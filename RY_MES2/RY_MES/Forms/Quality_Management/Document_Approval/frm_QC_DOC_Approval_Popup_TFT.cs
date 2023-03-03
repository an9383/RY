﻿using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_QC_DOC_Approval_Popup_TFT : RY_MES.frm_Base
    {
        public DataSet ds;
        private string _ticket_id;
        private string _template_type;
        private string _wafer_no;

        public frm_QC_DOC_Approval_Popup_TFT(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            _ticket_id = paramArray[0].ToString();
            _template_type = paramArray[1].ToString();
            _wafer_no = paramArray[2].ToString();
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

                string sMsg = _RYMES_DB.GET_DATA("QM_CA_QC_PRODUCT_REPORT_TFT", ref ds);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("DB Error", sMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow dr = ds.Tables[0].Rows[0];

                if (dr["ITEM_TYPE"].ToString() == "SW")
                {
                    report = new QC_TFT_SW_REPORT(ds);
                }
                else
                {
                    report = new QC_TFT_REPORT(ds);
                }

                DataRow dr1 = ds.Tables[1].Rows[0];

                if (string.IsNullOrEmpty(dr1["CONFIRM_DATE"].ToString()) || string.IsNullOrEmpty(dr1["APPLY_DATE"].ToString()))
                {
                    btn_Update.Visible = true;
                }
                else
                {
                    btn_Update.Visible = false;
                }

                if (report != null)
                {
                    report.CreateDocument();
                    documentViewer1.DocumentSource = report;
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