using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.CLS;
using System.Net.Mail;
using System.IO;

namespace MES.Popup
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }
        public String email = "";
        private void frmPrint_Load(object sender, EventArgs e)
        {
            
        }

        private void frmPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            return;
        }

        private void frmPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                reportViewer1.PrintDialog();
            }
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.Hide();
            }
        }

        public void prt_원장조회(DataTable dt, string sDay1, string sDay2, string sCust, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    ////for (int kk = 0; kk < dt.Rows.Count; kk++)
                    ////{
                    ////    //if (dt매출매출항목.Rows[kk]["규격"].ToString().Length > 10)
                    ////    //{
                    ////    //    dt매출매출항목.Rows[kk]["규격"] = dt매출매출항목.Rows[kk]["규격"].ToString().Substring(0, 9) + "...";
                    ////    //}
                    ////}

                    this.reportViewer1.Reset();
                    this.reportViewer1.LocalReport.DisplayName = "원장조회" + "_" + sDay1 + "_" + sDay2;
                    //this.reportViewer1.LocalReport.ReportPath = "Reports\\rpt원장조회.rdlc";
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt원장조회.rdlc";
                    
                    ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);

                    ReportParameterCollection rptParams = new ReportParameterCollection();
                    rptParams.Add(new ReportParameter("p제목", "원장 조회"));
                    rptParams.Add(new ReportParameter("p검색조건", sCondition));
                    
                    this.reportViewer1.LocalReport.SetParameters(rptParams);

                    ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    pg.PaperSize = rpg.PaperSize;
                    pg.Margins = rpg.Margins;
                    pg.Landscape = false; // false = 세로, true = 가로

                    reportViewer1.SetPageSettings(pg);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                }
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                MessageBox.Show("시스템에 문제가 있습니다.");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }
        public void prt_공정이동표(DataTable dt, string sDate, string sNum, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (sCondition == "공정이동표")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "공정이동표" + "_" + sDate + "_" + sNum;
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt공정이동전표.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "공정이동표"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 견적합니다."));
                        //rptParams.Add(new ReportParameter("p검색조건", "일자 : " + sDate + "     번호 : " + sNum));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                    }
                    else
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "자재요청서" + "_" + sDate + "_" + sNum;
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt원료청구.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "자재요청서"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 납품합니다."));
                        //rptParams.Add(new ReportParameter("p검색조건", "일자 : " + sDate + "     번호 : " + sNum));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);
                    }

                    ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    pg.PaperSize = rpg.PaperSize;
                    pg.Margins = rpg.Margins;
                    pg.Landscape = false; // false = 세로, true = 가로

                    reportViewer1.SetPageSettings(pg);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

                }
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                MessageBox.Show("시스템에 문제가 있습니다.");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }

        public void prt_발주현황표(DataTable dt,DataTable dt2,DataTable dt3,string sDate, string sNum, string sCondition)
        {

            btn구글.Visible = true;
            btn네이버.Visible = true;
            try
            {
                //button1.Visible = true;
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.reportViewer1.Reset();
                    this.reportViewer1.LocalReport.DisplayName = "발주서" + "_" + sDate + "_" + sNum;
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt발주서현황.rdlc";

                    ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);
                    ds = new ReportDataSource("DataSet2", dt2);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);
                    ds = new ReportDataSource("DataSet3", dt3);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);


                    ReportParameterCollection rptParams = new ReportParameterCollection();
                    //rptParams.Add(new ReportParameter("p제목", "발주현황표"));

                    this.reportViewer1.LocalReport.SetParameters(rptParams);
                }

                ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.PaperSize = rpg.PaperSize;
                pg.Margins = rpg.Margins;
                pg.Landscape = false; // false = 세로, true = 가로

                //var setup = reportViewer1.GetPageSettings();
                //setup.PaperSize.Width = 900;
                //setup.PaperSize.Height = 600;
                //setup.Landscape = false;
                //setup.Margins.Left = 27;

                reportViewer1.SetPageSettings(pg);//pg

                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            }
            catch (Exception e) 
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
                MessageBox.Show("시스템에 문제가 있습니다.");
                this.Hide();
            }
        }

        public void prt_식별표(DataTable dt, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (sCondition == "원자재입고식별표")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "원자재입고식별표" ;
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt자재식별표.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "원자재입고식별표"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 견적합니다."));
                        //rptParams.Add(new ReportParameter("p검색조건", "일자 : " + sDate + "     번호 : " + sNum));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                        var setup = reportViewer1.GetPageSettings();
                        setup.PaperSize.Width = 400;
                        setup.PaperSize.Height = 200;
                        setup.Landscape = false;
                        setup.Margins.Top = 5;
                        setup.Margins.Left = 27;

                        reportViewer1.SetPageSettings(setup);

                    }
                    else if (sCondition == "제품입고식별표")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "제품식별표";
                        //this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\rpt제품식별표.rdlc";
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt제품식별표.rdlc";


                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "제품식별표"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 납품합니다."));
                        //rptParams.Add(new ReportParameter("p검색조건", "일자 : " + sDate + "     번호 : " + sNum));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);
                        
                        var setup = reportViewer1.GetPageSettings();
                        setup.PaperSize.Width = 400;
                        setup.PaperSize.Height = 200;
                        setup.Landscape = false;
                        setup.Margins.Top = 5;
                        setup.Margins.Left = 27;

                        reportViewer1.SetPageSettings(setup);
                    }
                    else if (sCondition == "메탈식별표")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "메탈식별표";
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt메탈식별표.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "메탈식별표"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 납품합니다."));
                        //rptParams.Add(new ReportParameter("p검색조건", "일자 : " + sDate + "     번호 : " + sNum));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                        var setup = reportViewer1.GetPageSettings();
                        setup.PaperSize.Width = 400;
                        setup.PaperSize.Height = 200;
                        setup.Landscape = false;
                        setup.Margins.Top = 5;
                        setup.Margins.Left = 27;

                        reportViewer1.SetPageSettings(setup);
                    }
                    else
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "제품식별표2";
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt제품식별표2.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "제품식별표2"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 납품합니다."));
                        //rptParams.Add(new ReportParameter("p검색조건", "일자 : " + sDate + "     번호 : " + sNum));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                        var setup = reportViewer1.GetPageSettings();
                        setup.PaperSize.Width = 400;
                        //setup.PaperSize.Height = 228;
                        setup.PaperSize.Height = 200;
                        setup.Landscape = false;
                        setup.Margins.Top  = 5;
                        setup.Margins.Left = 27;

                        reportViewer1.SetPageSettings(setup);
                    }
                    //--------------------------------------------
                    //ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    //System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    //pg.PaperSize = rpg.PaperSize;

                    //var setup = reportViewer1.GetPageSettings();
                    //setup.PaperSize.Width = 500;
                    //setup.PaperSize.Height = 228;
                    //setup.Landscape = false;
                    //setup.Margins.Left = 27;

                    ////pg.Margins = rpg.Margins;
                    ////pg.Landscape = false; // false = 세로, true = 가로

                    //reportViewer1.SetPageSettings(setup);

                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                    this.reportViewer1.RefreshReport();

                    //--------------------------------------------

                }
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                MessageBox.Show("시스템에 문제가 있습니다.");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }

        public void prt_바코드(DataTable dt, string sCondition,string displayNm)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (sCondition == "제품바코드")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = displayNm;
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt제품박스바코드.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", displayNm));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 견적합니다."));
                        //rptParams.Add(new ReportParameter("p검색조건", "일자 : " + sDate + "     번호 : " + sNum));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                    }
                    
                    //--------------------------------------------
                    //ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    //System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    //pg.PaperSize = rpg.PaperSize;

                    var setup = reportViewer1.GetPageSettings();
                    setup.PaperSize.Width = 400;
                    setup.PaperSize.Height = 200;
                    setup.Landscape = false;
                    setup.Margins.Left = 27;

                    //pg.Margins = rpg.Margins;
                    //pg.Landscape = false; // false = 세로, true = 가로

                    reportViewer1.SetPageSettings(setup);

                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                    this.reportViewer1.RefreshReport();

                    //--------------------------------------------

                }
            }
            catch (Exception ex){
                MessageBox.Show("시스템에 문제가 있습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString()); Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }
        public void prt_원자재재고현황(DataTable dt, string sDay1, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (sCondition == "원자재재고현황")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "원자재재고현황";
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt원자재재고현황.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "원자재재고현황"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 견적합니다."));
                        rptParams.Add(new ReportParameter("p검색조건", "검색일자 : " + sDay1 ));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                    }
                    

                    ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    pg.PaperSize = rpg.PaperSize;
                    pg.Margins = rpg.Margins;
                    pg.Landscape = false; // false = 세로, true = 가로

                    reportViewer1.SetPageSettings(pg);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

                }
            }
            catch (Exception ex){
                MessageBox.Show("시스템에 문제가 있습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString()); Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }
        public void prt_원자재투입현황(DataTable dt, string sDay1, string sDay2, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (sCondition == "원자재투입현황")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "원자재투입현황";
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt원자재투입현황.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "원자재투입현황"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 견적합니다."));
                        rptParams.Add(new ReportParameter("p검색조건", "검색일자 : " + sDay1 + " ~ " + sDay2));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                    }

                    ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    pg.PaperSize = rpg.PaperSize;
                    pg.Margins = rpg.Margins;
                    pg.Landscape = false; // false = 세로, true = 가로

                    reportViewer1.SetPageSettings(pg);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

                }
            }
            catch (Exception ex){
                MessageBox.Show("시스템에 문제가 있습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString()); Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }
        public void prt_원자재원장현황(DataTable dt, string sDay1, string sDay2, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (sCondition == "원자재원장현황")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "원자재원장현황";
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rpt원자재원장현황.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);

                        ReportParameterCollection rptParams = new ReportParameterCollection();
                        rptParams.Add(new ReportParameter("p제목", "원자재원장현황"));
                        //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 견적합니다."));
                        rptParams.Add(new ReportParameter("p검색조건", "검색일자 : " + sDay1 + " ~ " + sDay2));

                        this.reportViewer1.LocalReport.SetParameters(rptParams);

                    }

                    ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    pg.PaperSize = rpg.PaperSize;
                    pg.Margins = rpg.Margins;
                    pg.Landscape = false; // false = 세로, true = 가로

                    reportViewer1.SetPageSettings(pg);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

                }
            }
            catch (Exception ex){
                MessageBox.Show("시스템에 문제가 있습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString()); Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }

        public void prt_HACCP점검표(DataTable dt, DataTable dt2, string sDate, string sNum, string sCondition)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.reportViewer1.Reset();
                    this.reportViewer1.LocalReport.DisplayName = "중요관리점(CCP) 검증 점검표" + "_" + sDate + "_" + sNum;
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "MES.Reports.rptHACCP점검표.rdlc";

                    ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                    //this.reportViewer1.LocalReport.DataSources.Add(ds);
                    ds = new ReportDataSource("DataSet1", dt2);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);


                    ReportParameterCollection rptParams = new ReportParameterCollection();
                    //rptParams.Add(new ReportParameter("p제목", "발주현황표"));

                    this.reportViewer1.LocalReport.SetParameters(rptParams);
                }

                ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.PaperSize = rpg.PaperSize;
                pg.Margins = rpg.Margins;
                pg.Landscape = false; // false = 세로, true = 가로

                //var setup = reportViewer1.GetPageSettings();
                //setup.PaperSize.Width = 900;
                //setup.PaperSize.Height = 600;
                //setup.Landscape = false;
                //setup.Margins.Left = 27;

                reportViewer1.SetPageSettings(pg);//pg

                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
                MessageBox.Show("시스템에 문제가 있습니다.");
                this.Hide();
            }
        }

        public void prt_제품출고현황(DataTable dt, string sDay1, string sDay2, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            //try
            //{
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        if (sCondition == "제품출고현황")
            //        {
            //            this.reportViewer1.Reset();
            //            this.reportViewer1.LocalReport.DisplayName = "제품출고현황";
            //            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\rpt제품출고현황.rdlc";

            //            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //            this.reportViewer1.LocalReport.DataSources.Add(ds);

            //            ReportParameterCollection rptParams = new ReportParameterCollection();
            //            //rptParams.Add(new ReportParameter("p제목", "제품출고현황"));
            //            //rptParams.Add(new ReportParameter("p견적구분", "아래와 같이 견적합니다."));
            //            //rptParams.Add(new ReportParameter("p검색조건", "검색일자 : " + sDay1 + " ~ " + sDay2));

            //            this.reportViewer1.LocalReport.SetParameters(rptParams);

            //        }

            //        ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
            //        System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            //        pg.PaperSize = rpg.PaperSize;
            //        pg.Margins = rpg.Margins;
            //        pg.Landscape = false; // false = 세로, true = 가로

            //        reportViewer1.SetPageSettings(pg);

            //        this.reportViewer1.RefreshReport();
            //        this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //        this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
            //    MessageBox.Show("시스템에 문제가 있습니다.");
            //    this.Hide();
            //}

            lblMsg.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (email == "")
            {
                MessageBox.Show("거래처 이메일이 오류입니다..");
                return;
            }
            pop이메일 pop이메일 = new pop이메일();
            DialogResult result = pop이메일.ShowDialog();
            if (result == DialogResult.OK)                  //확인 버튼
            {

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = reportViewer1.LocalReport.Render
            ("PDF", null, out mimeType, out encoding, out extension, out 
            streamids, out warnings);

                MemoryStream memoryStream = new MemoryStream(bytes);
                memoryStream.Seek(0, SeekOrigin.Begin);

                String emailtype = null;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
                client.EnableSsl = true;  // SSL을 사용한다.
                client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
                client.Credentials = new System.Net.NetworkCredential(Common.p_emailID + "@gmail.com", Common.p_emailPW);
                MailAddress from = new MailAddress(Common.p_emailID + "@gmail.com", Common.p_strCompNm, System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(email);

                MailMessage message = new MailMessage(from, to);

                message.Body = Common.p_strCompNm + DateTime.Now.ToString().Substring(0, 10) + "_발주서.PDF" + "송부하여 드립니다.." + "\n" + "감사합니다.";

                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "[" + Common.p_strCompNm + "]" + DateTime.Now.ToString().Substring(0, 10) + "_발주서.PDF";
                message.SubjectEncoding = System.Text.Encoding.UTF8;




                //       System.Net.Mail.Attachment attachment;//첨부파일 만들기

                // attachment = new System.Net.Mail.Attachment(fileFullName); //첨부파일 붙이기
                Attachment attachment = new Attachment(memoryStream, Common.p_strCompNm + DateTime.Now.ToString().Substring(0, 10) + "_발주서.PDF");
                message.Attachments.Add(attachment);//첨부파일 붙이기


                try
                {
                    // 동기로 메일을 보낸다.
                    client.Send(message);
                    MessageBox.Show("성공");
                    // Clean up.
                    message.Dispose();
                }
                catch (SmtpException smtp)
                {
                    MessageBox.Show("아이디 비밀번호가 틀렸거나 , SMTP 사용을 허가 하셔야합니다.");

                    System.Diagnostics.Process.Start("https://myaccount.google.com/lesssecureapps");





                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
            else if (result == DialogResult.Cancel)         //취소 버튼
            {
                MessageBox.Show("취소하셨습니다.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (email == "")
            {
                MessageBox.Show("거래처 이메일이 오류입니다..");

                return;
            }
            pop이메일 pop이메일 = new pop이메일();
            DialogResult result = pop이메일.ShowDialog();
            if (result == DialogResult.OK)                  //확인 버튼
            {
                MessageBox.Show("자식폼 OK 클릭");

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = reportViewer1.LocalReport.Render
            ("PDF", null, out mimeType, out encoding, out extension, out 
            streamids, out warnings);

                MemoryStream memoryStream = new MemoryStream(bytes);
                memoryStream.Seek(0, SeekOrigin.Begin);

                String emailtype = null;


                SmtpClient client = new SmtpClient("smtp.naver.com", 587);
                client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
                client.EnableSsl = true;  // SSL을 사용한다.
                client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 naver에 인증을 받지 못한다.
                client.Credentials = new System.Net.NetworkCredential(Common.p_emailID + "@naver.com", Common.p_emailPW);
                MailAddress from = new MailAddress(Common.p_emailID + "@naver.com", Common.p_strCompNm, System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(email);

                MailMessage message = new MailMessage(from, to);

                message.Body = Common.p_strCompNm + DateTime.Now.ToString().Substring(0, 10) + "_발주서.PDF" + "송부하여 드립니다.." + "\n" + "감사합니다.";

                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "[" + Common.p_strCompNm + "]" + DateTime.Now.ToString().Substring(0, 10) + "_발주서.PDF";
                message.SubjectEncoding = System.Text.Encoding.UTF8;




                //       System.Net.Mail.Attachment attachment;//첨부파일 만들기

                // attachment = new System.Net.Mail.Attachment(fileFullName); //첨부파일 붙이기
                Attachment attachment = new Attachment(memoryStream, Common.p_strCompNm + DateTime.Now.ToString().Substring(0, 10) + "_발주서.PDF");
                message.Attachments.Add(attachment);//첨부파일 붙이기


                try
                {
                    // 동기로 메일을 보낸다.
                    client.Send(message);
                    MessageBox.Show("성공");
                    // Clean up.
                    message.Dispose();
                }
                catch (SmtpException smtp)
                {

                    MessageBox.Show("아이디 비밀번호가 틀렸거나 , SMTP 사용을 허가 하셔야합니다.");
                    System.Diagnostics.Process.Start("https://mail.naver.com/option/imap");





                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
            else if (result == DialogResult.Cancel)         //취소 버튼
            {
                MessageBox.Show("취소하셨습니다.");
            }

        }

        public void prt_거래명세표(DataTable adoPrt, DataGridView dgv_itemOut, string strCondition)
        {
            try
            {
                if (adoPrt != null && adoPrt.Rows.Count > 0)
                {
                    this.reportViewer1.Reset();
                    this.reportViewer1.LocalReport.DisplayName = "거래명세표";
                    this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\rpt거래명세표.rdlc";


                    ReportDataSource ds = new ReportDataSource("DataSet1", adoPrt);
                    //this.reportViewer1.LocalReport.DataSources.Add(ds);
                    this.reportViewer1.LocalReport.EnableExternalImages = true;
                    this.reportViewer1.LocalReport.DataSources.Add(ds);

                    

                    ReportParameterCollection rptParams = new ReportParameterCollection();
                    rptParams.Add(new ReportParameter("pWaterMark", AppDomain.CurrentDomain.BaseDirectory + "SaupLogos\\WaterMark.png"));
                    rptParams.Add(new ReportParameter("pSeal", AppDomain.CurrentDomain.BaseDirectory + "SaupLogos\\seal.png"));
                    //rptParams.Add(new ReportParameter("p검색기간", strDay1 + " ~ " + strDay2));
                    //rptParams.Add(new ReportParameter("p담당사원", "담당사원 : " + adoPrt2.Rows[0]["CUST_MANAGER"].ToString()));
                    //rptParams.Add(new ReportParameter("p거래처명", adoPrt2.Rows[0]["CUST_NM"].ToString()));
                    //rptParams.Add(new ReportParameter("p거래처코드", adoPrt2.Rows[0]["CUST_CD"].ToString()));
                    //rptParams.Add(new ReportParameter("p거래처사업자번호", adoPrt2.Rows[0]["SAUP_NO"].ToString()));
                    //rptParams.Add(new ReportParameter("p거래처전화번호", adoPrt2.Rows[0]["CUST_COMP_PHONE"].ToString()));
                    //rptParams.Add(new ReportParameter("p거래처주소", adoPrt2.Rows[0]["ADDR"].ToString()));
                    //rptParams.Add(new ReportParameter("p거래처대표자명", adoPrt2.Rows[0]["OWNER"].ToString()));
                    ////rptParams.Add(new ReportParameter("p제목", "발주현황표"));

                    this.reportViewer1.LocalReport.SetParameters(rptParams);
                }

                //ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                //System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                //pg.PaperSize = rpg.PaperSize;
                //pg.Margins = rpg.Margins;
                //pg.Landscape = true; // false = 세로, true = 가로



                //reportViewer1.SetPageSettings(pg);//pg

                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
                MessageBox.Show("시스템에 문제가 있습니다.");
                MessageBox.Show(e.Message + " - " + e.ToString());
                this.Hide();
            }
        }

        public void prt_수입검사성적서(
            DataTable adoPrt
            , string txt_chk_date
            , string txt_staff_nm
            , string txt_raw_mat_nm
            , string lbl_spec_temp
            , string txt_cust_nm
            , string txt_input_date
            , string txt_input_cd
            , string txt_input_seq
            , string txt_input_amt
            , string txt_pass_amt
            , string txt_non_pass_amt
            , string txt_pass_yn
            )
        {
            try
            {
                if (adoPrt != null && adoPrt.Rows.Count > 0)
                {
                    this.reportViewer1.Reset();
                    this.reportViewer1.LocalReport.DisplayName = "수입검사 성적서";
                    this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\rpt수입검사성적표.rdlc";

                    ReportDataSource ds = new ReportDataSource("DataSet1", adoPrt);
                    //this.reportViewer1.LocalReport.DataSources.Add(ds);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);


                    ReportParameterCollection rptParams = new ReportParameterCollection();
                    rptParams.Add(new ReportParameter("CHK_DATE"     , txt_chk_date ));
                    rptParams.Add(new ReportParameter("STAFF_NM"    ,  txt_staff_nm ));
                    rptParams.Add(new ReportParameter("RAW_MAT_NM"   , txt_raw_mat_nm));
                    rptParams.Add(new ReportParameter("SPEC"        ,  lbl_spec_temp ));
                    rptParams.Add(new ReportParameter("CUST_NM"    ,   txt_cust_nm  ));
                    rptParams.Add(new ReportParameter("INPUT_DATE"  ,  txt_input_date ));
                    rptParams.Add(new ReportParameter("INPUT_CD"     , txt_input_cd ));
                    rptParams.Add(new ReportParameter("INPUT_SEQ"    ,  txt_input_seq));
                    rptParams.Add(new ReportParameter("CHK_AMT"      , txt_input_amt ));
                    rptParams.Add(new ReportParameter("PASS_AMT"      ,  txt_pass_amt));
                    rptParams.Add(new ReportParameter("NON_PASS_AMT"      , txt_non_pass_amt ));
                    rptParams.Add(new ReportParameter("PASS_YN"      , txt_pass_yn ));

                    this.reportViewer1.LocalReport.SetParameters(rptParams);
                }

                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
                MessageBox.Show("시스템에 문제가 있습니다.");
                MessageBox.Show(e.Message + " - " + e.ToString());
                this.Hide();
            }
        }

        public void prt_작업일보관리(DataTable dt, DataTable dt2, string sCondition)
        {
            lblMsg.Visible = true;
            Application.DoEvents();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (sCondition == "일일작업결과")
                    {
                        this.reportViewer1.Reset();
                        this.reportViewer1.LocalReport.DisplayName = "일일작업결과";
                        this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\rpt제품생산일지.rdlc";

                        ReportDataSource ds = new ReportDataSource("TOIPDATA", dt);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);
                        ds = new ReportDataSource("MADEDATA", dt2);
                        this.reportViewer1.LocalReport.DataSources.Add(ds);



                        //ReportParameterCollection rptParams = new ReportParameterCollection();
                        //rptParams.Add(new ReportParameter("p제목", "일일작업결과"));

                        //this.reportViewer1.LocalReport.SetParameters(rptParams);
                    }

                    //var setup = reportViewer1.GetPageSettings();
                    //setup.PaperSize.Width = 1000;
                    //setup.PaperSize.Height = 600;
                    //setup.Landscape = false;
                    //setup.Margins.Left = 27;

                    ////ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                    ////System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    ////pg.PaperSize = rpg.PaperSize;
                    ////pg.Margins = rpg.Margins;
                    ////pg.Landscape = false; // false = 세로, true = 가로

                    //reportViewer1.SetPageSettings(setup);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

                }
            }
            catch (Exception ex){
                MessageBox.Show("시스템에 문제가 있습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString()); Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                this.Hide();
            }

            lblMsg.Visible = false;
        }

        public void prt_매입처원장(DataTable adoPrt2, DataGridView dgv, string strDay1, string strDay2, string strCondition)
        {

            DataTable adoPrt = GetDataTableFromDGV(dgv);


            try
            {
                if (adoPrt != null && adoPrt.Rows.Count > 0)
                {
                    this.reportViewer1.Reset();
                    this.reportViewer1.LocalReport.DisplayName = "구매처 원장";
                    this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\rpt매출처원장.rdlc";
                    this.reportViewer1.LocalReport.EnableExternalImages = true;


                    adoPrt.Columns["NO"].ColumnName = "전표분류";
                    adoPrt.Columns["SALES_DATE"].ColumnName = "일자명칭";
                    adoPrt.Columns["SALES_CD"].ColumnName = "전표번호";
                    adoPrt.Columns["INPUT_GUBUN"].ColumnName = "구분명칭";
                    adoPrt.Columns["PRODUCT_NM"].ColumnName = "상품명";
                    adoPrt.Columns["TOTAL_AMT"].ColumnName = "박스수량";
                    adoPrt.Columns["TOTAL_PRICE"].ColumnName = "박스단가";
                    adoPrt.Columns["TOTAL_MONEY"].ColumnName = "금액";
                    adoPrt.Columns["TOTAL_TAX_MONEY"].ColumnName = "부가세액";
                    adoPrt.Columns["SOO_MONEY"].ColumnName = "수금액";
                    adoPrt.Columns["TOTAL_SOO_MONEY"].ColumnName = "지급액";
                    adoPrt.Columns["DC_MONEY"].ColumnName = "할인액";
                    adoPrt.Columns["BALANCE"].ColumnName = "잔고";
                    adoPrt.Columns["SPEC"].ColumnName = "서비스박스";

                    adoPrt.Columns.Add("서비스낱개");
                    adoPrt.Columns.Add("낱개단가");
                    adoPrt.Columns.Add("총수량");
                    adoPrt.Columns.Add("규격");
                    adoPrt.Columns.Add("정렬구분");
                    adoPrt.Columns.Add("일자");


                    for (int i = 0; i < adoPrt.Rows.Count; i++)
                    {
                        adoPrt.Rows[i]["서비스낱개"] = "0";
                        adoPrt.Rows[i]["낱개단가"] = "0";
                        adoPrt.Rows[i]["박스단가"] = "";
                        adoPrt.Rows[i]["총수량"] = "0";
                        adoPrt.Rows[i]["규격"] = "0";
                        adoPrt.Rows[i]["정렬구분"] = "0";
                        adoPrt.Rows[i]["일자"] = "0";
                    }



                    ReportDataSource ds = new ReportDataSource("DataSet1", adoPrt);
                    //this.reportViewer1.LocalReport.DataSources.Add(ds);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);


                    ReportParameterCollection rptParams = new ReportParameterCollection();
                    rptParams.Add(new ReportParameter("p제목", adoPrt2.Rows[0]["CUST_NM"].ToString() + ".구매원장"));
                    rptParams.Add(new ReportParameter("p검색기간", strDay1 + " ~ " + strDay2));
                    rptParams.Add(new ReportParameter("p담당사원", "담당사원 : " + adoPrt2.Rows[0]["CUST_MANAGER"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처명", adoPrt2.Rows[0]["CUST_NM"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처코드", adoPrt2.Rows[0]["CUST_CD"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처사업자번호", adoPrt2.Rows[0]["SAUP_NO"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처전화번호", adoPrt2.Rows[0]["CUST_COMP_PHONE"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처주소", adoPrt2.Rows[0]["ADDR"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처대표자명", adoPrt2.Rows[0]["OWNER"].ToString()));
                    rptParams.Add(new ReportParameter("pWaterMark", AppDomain.CurrentDomain.BaseDirectory + "SaupLogos\\WaterMark.png"));
                    //rptParams.Add(new ReportParameter("p제목", "발주현황표"));

                    this.reportViewer1.LocalReport.SetParameters(rptParams);
                }

                ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.PaperSize = rpg.PaperSize;
                pg.Margins = rpg.Margins;
                pg.Landscape = true; // false = 세로, true = 가로

                var setup = reportViewer1.GetPageSettings();
                setup.PaperSize.Width = 1600;
                setup.PaperSize.Height = 1200;
                setup.Landscape = false;
                setup.Margins.Left = 27;

                reportViewer1.SetPageSettings(pg);//pg

                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
                MessageBox.Show("시스템에 문제가 있습니다.");
                MessageBox.Show(e.Message + " - " + e.ToString());
                this.Hide();
            }
        }
        public void prt_매출처원장(DataTable adoPrt2, DataGridView dgv, string strDay1, string strDay2, string strCondition)
        {

            DataTable adoPrt = GetDataTableFromDGV(dgv);


            try
            {
                if (adoPrt != null && adoPrt.Rows.Count > 0)
                {
                    this.reportViewer1.Reset();
                    this.reportViewer1.LocalReport.DisplayName = "매출처 원장";
                    this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\rpt매출처원장.rdlc";
                    this.reportViewer1.LocalReport.EnableExternalImages = true;


                    adoPrt.Columns["NO"].ColumnName = "전표분류";
                    adoPrt.Columns["SALES_DATE"].ColumnName = "일자명칭";
                    adoPrt.Columns["SALES_CD"].ColumnName = "전표번호";
                    adoPrt.Columns["INPUT_GUBUN"].ColumnName = "구분명칭";
                    adoPrt.Columns["PRODUCT_NM"].ColumnName = "상품명";
                    adoPrt.Columns["TOTAL_AMT"].ColumnName = "박스수량";
                    adoPrt.Columns["TOTAL_PRICE"].ColumnName = "박스단가";
                    adoPrt.Columns["TOTAL_MONEY"].ColumnName = "금액";
                    adoPrt.Columns["TOTAL_TAX_MONEY"].ColumnName = "부가세액";
                    adoPrt.Columns["SOO_MONEY"].ColumnName = "수금액";
                    adoPrt.Columns["TOTAL_SOO_MONEY"].ColumnName = "지급액";
                    adoPrt.Columns["DC_MONEY"].ColumnName = "할인액";
                    adoPrt.Columns["BALANCE"].ColumnName = "잔고";
                    adoPrt.Columns["SPEC"].ColumnName = "서비스박스";

                    adoPrt.Columns.Add("서비스낱개");
                    adoPrt.Columns.Add("낱개단가");
                    adoPrt.Columns.Add("총수량");
                    adoPrt.Columns.Add("규격");
                    adoPrt.Columns.Add("정렬구분");
                    adoPrt.Columns.Add("일자");


                    for (int i = 0; i < adoPrt.Rows.Count; i++)
                    {
                        adoPrt.Rows[i]["서비스낱개"] = "0";
                        adoPrt.Rows[i]["낱개단가"] = "0";
                        adoPrt.Rows[i]["박스단가"] = "";
                        adoPrt.Rows[i]["총수량"] = "0";
                        adoPrt.Rows[i]["규격"] = "0";
                        adoPrt.Rows[i]["정렬구분"] = "0";
                        adoPrt.Rows[i]["일자"] = "0";
                    }



                    ReportDataSource ds = new ReportDataSource("DataSet1", adoPrt);
                    //this.reportViewer1.LocalReport.DataSources.Add(ds);
                    this.reportViewer1.LocalReport.DataSources.Add(ds);


                    ReportParameterCollection rptParams = new ReportParameterCollection();
                    rptParams.Add(new ReportParameter("p제목", adoPrt2.Rows[0]["CUST_NM"].ToString() + ".매출원장"));
                    rptParams.Add(new ReportParameter("p검색기간", strDay1 + " ~ " + strDay2));
                    rptParams.Add(new ReportParameter("p담당사원", "담당사원 : " + adoPrt2.Rows[0]["CUST_MANAGER"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처명", adoPrt2.Rows[0]["CUST_NM"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처코드", adoPrt2.Rows[0]["CUST_CD"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처사업자번호", adoPrt2.Rows[0]["SAUP_NO"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처전화번호", adoPrt2.Rows[0]["CUST_COMP_PHONE"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처주소", adoPrt2.Rows[0]["ADDR"].ToString()));
                    rptParams.Add(new ReportParameter("p거래처대표자명", adoPrt2.Rows[0]["OWNER"].ToString()));
                    rptParams.Add(new ReportParameter("pWaterMark", AppDomain.CurrentDomain.BaseDirectory + "SaupLogos\\WaterMark.png"));

                    //rptParams.Add(new ReportParameter("p제목", "발주현황표"));

                    this.reportViewer1.LocalReport.SetParameters(rptParams);
                }

                ReportPageSettings rpg = reportViewer1.LocalReport.GetDefaultPageSettings();
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.PaperSize = rpg.PaperSize;
                pg.Margins = rpg.Margins;
                pg.Landscape = true; // false = 세로, true = 가로

                var setup = reportViewer1.GetPageSettings();
                setup.PaperSize.Width = 1600;
                setup.PaperSize.Height = 1200;
                setup.Landscape = false;
                setup.Margins.Left = 27;

                reportViewer1.SetPageSettings(pg);//pg

                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
                MessageBox.Show("시스템에 문제가 있습니다.");
                MessageBox.Show(e.Message + " - " + e.ToString());
                this.Hide();
            }
        }

        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.Name);
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
    }
}
