using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.Controls;
using MES.Popup;

namespace MES.CLS
{
    public class wnGConstant
    {
        public const bool debug = true;
        private string strQuery;
        private SqlConnection adoConnection = new SqlConnection();
        private SqlCommand adoCommand = new SqlCommand();
        private SqlDataAdapter adoAdapter = new SqlDataAdapter();
        private DataTable adoTable = new DataTable();
        private DataRow adoRow;
        wnDm wnDm = new wnDm();
        private bool rightSave = true;
        private bool rightDel = true;
        private bool[] arr = new bool[2];

        public void setCombo_공용코드(conComboBox cmb, string sTable, string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string str = string.Concat("select M_CODE AS 코드, M_NAME AS 명칭 from ", sTable, " where 1=1 ");
            string str1 = sGubun;
            if (str1 != null)
            {
                if (str1 == "ALL")
                {
                    this.ComboBox_Read_ALL(cmb, str);
                    return;
                }
                else
                {
                    if (str1 != "NoBLANK")
                    {
                        this.ComboBox_Read_Blank(cmb, str);
                        return;
                    }
                    this.ComboBox_Read_NoBlank(cmb, str);
                    return;
                }
            }
            this.ComboBox_Read_Blank(cmb, str);
        }
        public string NumbDisplay(decimal nVal, string sFormat)
        {
            string sRet = "";

            if (nVal != 0)
            {
                sRet = nVal.ToString(sFormat);
            }

            return sRet;
        }

        public bool isNum(string sValue)
        {
            bool bRet = false;

            try
            {
                decimal num = decimal.Parse(sValue);
                bRet = true;
            }
            catch
            {
                bRet = false;
            }
            return bRet;
        }

        public bool check_NumText(Form frm, string sName, string sMsg)
        {
            bool bRet = true;

            try
            {
                var txtBox = frm.Controls.Find("txt" + sName, true);

                if (txtBox[0].Text == "")
                {
                    MessageBox.Show("[ " + sMsg + " ] 을 입력하세요.");
                    bRet = false;
                }
                else
                {
                    if (isNum(txtBox[0].Text) == false)
                    {
                        MessageBox.Show("[ " + sMsg + " ] 에 숫자만 입력하세요.");
                        bRet = false;
                    }
                    //else
                    //{
                    //    txtBox[0].Text = txtBox[0].Text.Replace(",", "");
                    //}
                }
            }
            catch
            {
                MessageBox.Show("[ " + sMsg + " ] 에 알수 없는 문제가 있습니다.");
                bRet = false;
            }

            return bRet;
        }

        public bool check_NumText(UserControl uc, string sName, string sMsg)
        {
            bool bRet = true;

            try
            {
                var txtBox = uc.Controls.Find("txt" + sName, true);

                if (txtBox[0].Text == "")
                {
                    MessageBox.Show("[ " + sMsg + " ] 을 입력하세요.");
                    bRet = false;
                }
                else
                {
                    if (isNum(txtBox[0].Text) == false)
                    {
                        MessageBox.Show("[ " + sMsg + " ] 에 숫자만 입력하세요.");
                        bRet = false;
                    }
                    //else
                    //{
                    //    txtBox[0].Text = txtBox[0].Text.Replace(",", "");
                    //}
                }
            }
            catch
            {
                MessageBox.Show("[ " + sMsg + " ] 에 알수 없는 문제가 있습니다.");
                bRet = false;
            }

            return bRet;
        }

        public void set_공용일자(conDateTimePicker dtp)
        {
            try
            {
                string sqlQuery = "select getdate() ";

                adoTable = RunTable(sqlQuery);

                if (adoTable != null)
                {
                    dtp.Text = DateTime.Parse(adoTable.Rows[0][0].ToString()).ToString("yyyy-MM-dd");
                }
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void set_공용시각(conDateTimePicker dtp)
        {
            try
            {
                string sqlQuery = "select getdate() ";

                adoTable = RunTable(sqlQuery);

                if (adoTable != null)
                {
                    dtp.Text = DateTime.Parse(adoTable.Rows[0][0].ToString()).ToString("HH:mm:ss");
                }
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }

        public void set_공용일자(Label dtp)
        {
            try
            {
                string sqlQuery = "select getdate() ";

                adoTable = RunTable(sqlQuery);

                if (adoTable != null)
                {
                    dtp.Text = DateTime.Parse(adoTable.Rows[0][0].ToString()).ToString("yyyy-MM-dd");
                }
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void set_공용시각(Label dtp)
        {
            try
            {
                string sqlQuery = "select getdate() ";

                adoTable = RunTable(sqlQuery);

                if (adoTable != null)
                {
                    dtp.Text = DateTime.Parse(adoTable.Rows[0][0].ToString()).ToString("HH:mm:ss");
                }
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }

        public bool DB_Open(string sConn)
        {
            if (adoConnection.State == ConnectionState.Open)
            {
                return true;
            }
            if (string.IsNullOrEmpty(sConn))
            {
                return false;
            }

            adoConnection.ConnectionString = sConn;
            try
            {
                adoConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "에러발생", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable RunTable(string query)
        {
            string sConnDB = Common.p_sConn; //Common.p_strConn;

            if (!DB_Open(sConnDB))
            {
                return null;
            };
            DataTable adoDT = new DataTable();
            adoCommand = adoConnection.CreateCommand();
            try
            {
                adoCommand.CommandType = CommandType.Text;
                adoCommand.CommandText = query;
                adoAdapter.SelectCommand = adoCommand;
                adoAdapter.Fill(adoDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "에러발생", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                adoConnection.Close();
            }

            return adoDT;
        }
        public void ComboBox_Read_Blank(DataGridViewComboBoxColumn sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);
            adoRow = adoTable.NewRow();
            adoRow[0] = "";
            adoRow[1] = "";
            adoTable.Rows.InsertAt(adoRow, 0);

            sCombo.DataSource = adoTable;
        }
        public void ComboBox_Read_NoBlank(DataGridViewComboBoxColumn sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);

            sCombo.DataSource = adoTable;
        }
        public void ComboBox_Read_Blank(conComboBox sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);
            adoRow = adoTable.NewRow();
            adoRow[0] = "";
            adoRow[1] = "";
            adoTable.Rows.InsertAt(adoRow, 0);

            sCombo.DataSource = adoTable;
        }

        public void ComboBox_Read_Blank(ComboBox sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);
            adoRow = adoTable.NewRow();
            adoRow[0] = "";
            adoRow[1] = "";
            adoTable.Rows.InsertAt(adoRow, 0);

            sCombo.DataSource = adoTable;
        }

        public void ComboBox_Read_NoBlank(conComboBox sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);

            sCombo.DataSource = adoTable;
        }

        public void ComboBox_Read_ALL(conComboBox sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);
            adoRow = adoTable.NewRow();
            adoRow[0] = "";
            adoRow[1] = "(전체)";
            adoTable.Rows.InsertAt(adoRow, 0);

            sCombo.DataSource = adoTable;
        }


        public void Form_Clear(Control.ControlCollection sCtrols)
        {
            foreach (Control cCtrl in sCtrols)
            {
                if (cCtrl is TextBox)
                {
                    TextBox sControl = (TextBox)cCtrl;
                    if (sControl.Text.Trim().Length > 0)
                    {
                        sControl.Text = "";
                    }
                    if (sControl.GetType().Name == "conTextNumber")
                    {
                        conTextNumber cont = (conTextNumber)cCtrl;
                        cont._FormatString = "#0";
                        if (cont._ValueType == "수량")
                        {
                            cont._FormatString = Common.p_strFormatAmount;
                        }
                        if (cont._ValueType == "단가")
                        {
                            cont._FormatString = Common.p_strFormatUnit;
                        }
                        sControl.Text = (0).ToString(cont._FormatString);
                    }
                }
                else if (cCtrl is CheckBox)
                {
                    CheckBox myCheck = (CheckBox)cCtrl;
                    myCheck.Checked = false;
                }
                else if (cCtrl is RadioButton)
                {
                    RadioButton myCheck = (RadioButton)cCtrl;
                    myCheck.Checked = false;
                }
                else if (cCtrl is MaskedTextBox)
                {
                    cCtrl.Text = "";
                }
                else if (cCtrl is conLabel)
                {
                    cCtrl.Text = "";
                }
                else if (cCtrl is RichTextBox)
                {
                    cCtrl.Text = "";
                }
                else if (cCtrl is NumericUpDown)
                {
                    cCtrl.Text = "";
                }
                else if (cCtrl is DateTimePicker)
                {
                    cCtrl.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

        /// BYTE[]를 이미지로 변환
        public Image ConvertByteToImage(byte[] pByte)
        {
            MemoryStream ms = new MemoryStream();
            Image theImage = null;
            try
            {
                ms.Position = 0;
                ms.Write(pByte, 0, (int)pByte.Length);
                theImage = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            return theImage;
        }

        /// 이미지를 BYTE[]로 변환..
        public byte[] ConvertImageToByte(Bitmap img, string sFileExt)
        {
            // 받은 이미지를 다시 설정해서, 저장해야 함.
            Bitmap theImage = new Bitmap(img);

            byte[] pByte = new byte[0];
            MemoryStream ms = new MemoryStream();
            try
            {
                switch (sFileExt.ToLower())
                {
                    case "jpeg":
                        theImage.Save(ms, ImageFormat.Jpeg);
                        break;
                    case "bmp":
                        theImage.Save(ms, ImageFormat.Bmp);
                        break;
                    case "emf":
                        theImage.Save(ms, ImageFormat.Emf);
                        break;
                    case "exif":
                        theImage.Save(ms, ImageFormat.Exif);
                        break;
                    case "gif":
                        theImage.Save(ms, ImageFormat.Gif);
                        break;
                    case "icon":
                        theImage.Save(ms, ImageFormat.Icon);
                        break;
                    case "memorybmp":
                        theImage.Save(ms, ImageFormat.MemoryBmp);
                        break;
                    case "png":
                        theImage.Save(ms, ImageFormat.Png);
                        break;
                    case "tiff":
                        theImage.Save(ms, ImageFormat.Tiff);
                        break;
                    case "wmf":
                        theImage.Save(ms, ImageFormat.Wmf);
                        break;
                }
                pByte = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(pByte, 0, (int)ms.Length);
                ms.Close();
                ms = null;
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
            return pByte;
        }

        public string maxValue_Check(string sqlQuery)
        {
            string sRet = "";

            try
            {
                adoTable = RunTable(sqlQuery);

                if (adoTable != null)
                {
                    if (adoTable.Rows.Count > 0)
                    {
                        sRet = adoTable.Rows[0][0].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
                sRet = "";
            }

            return sRet;
        }

        public void select_Check(DataGridView grd, int nCol, bool bCheck)
        {
            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                if (bCheck == true)
                {
                    if (grd.Rows[kk].Cells[nCol].ReadOnly == false)
                    {
                        grd.Rows[kk].Cells[nCol].Value = true;
                    }
                }
                else
                {
                    grd.Rows[kk].Cells[nCol].Value = false;
                }
            }
        }

        public void init_RowText(conDataGridView dgv, int nRow)
        {
            dgv.Rows[nRow].Cells[0].Value = false;
            //dgv.Rows[nRow].Cells[1].Value = "";
            dgv.Rows[nRow].Cells[2].Value = "";
            dgv.Rows[nRow].Cells[3].Value = "";
            dgv.Rows[nRow].Cells[4].Value = "";
            dgv.Rows[nRow].Cells[5].Value = "";
            dgv.Rows[nRow].Cells[6].Value = "";
            dgv.Rows[nRow].Cells[7].Value = "0";
            dgv.Rows[nRow].Cells[8].Value = "0";
            dgv.Rows[nRow].Cells[9].Value = "0";
            dgv.Rows[nRow].Cells[10].Value = "0";
            dgv.Rows[nRow].Cells[11].Value = "0";
            dgv.Rows[nRow].Cells[12].Value = "0";
            dgv.Rows[nRow].Cells[13].Value = "0";
            dgv.Rows[nRow].Cells[14].Value = "";    //endCol
        }

        public void call_popRef_Man(string sTxt, TextBox txt_Code, TextBox txt_Name, string sUsedYN)
        {
            Popup.pop담당자검색 frm = new Popup.pop담당자검색();

            //frm.sUsedYN = sUsedYN;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                txt_Code.Text = frm.sRetCode.Trim();
                txt_Name.Text = frm.sRetName.Trim();
            }

            frm.Dispose();
            frm = null;
        }

        public void call_popRef_Cust(string sTxt, TextBox txt_Code, TextBox txt_Name, string sUsedYN,String title)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색(title);

            //frm.sUsedYN = sUsedYN;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_Code.Text = frm.sCode.Trim();
                txt_Name.Text = frm.sName.Trim();
            }
            frm.Dispose();
            frm = null;
        }
        public void call_popRef_Cust(string sTxt, TextBox txt_Code, TextBox txt_Name, string sUsedYN)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            //frm.sUsedYN = sUsedYN;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_Code.Text = frm.sCode.Trim();
                txt_Name.Text = frm.sName.Trim();
            }
            frm.Dispose();
            frm = null;
        }

        public void call_pop_Prod(conDataGridView dgv, int nRow, string sTxt, string sCust, int nColCode, int nColName, string sUsedYN)
        {
            Popup.pop제품검색 frm = new Popup.pop제품검색();

            //frm.sUsedYN = sUsedYN;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                dgv.Rows[nRow].Cells[nColCode].Value = frm.sRetCode.Trim();
                dgv.Rows[nRow].Cells[nColName].Value = frm.sRetName.Trim();
            }

            frm.Dispose();
            frm = null;
        }

        public void Calc_Price(conDataGridView dgv, int nRow)
        {
            dgv.Rows[nRow].Cells[9].Value = "0";   // 금액

            string s수량 = ("" + (string)dgv.Rows[nRow].Cells[7].Value).Replace(",", "");
            string s단가 = ("" + (string)dgv.Rows[nRow].Cells[8].Value).Replace(",", "");
            if (s수량 != "" && s단가 != "")
            {
                string s금액 = (decimal.Parse(s수량) * decimal.Parse(s단가)).ToString();

                dgv.Rows[nRow].Cells[9].Value = (decimal.Parse(s금액)).ToString("#,0");

                double nINprice = 0;
                double nNet = 0;
                double nGlos = 0;
                double nVat = 0;

                if (s금액 != "")
                {
                    nINprice = double.Parse(s금액);

                    nVat = Math.Round(nINprice * 0.1, 0, MidpointRounding.AwayFromZero);
                    nNet = nINprice;
                    nGlos = nVat + nNet;
                    nNet = 0;
                }

                dgv.Rows[nRow].Cells[10].Value = nVat.ToString();
            }
        }


        public void f_Calc_Price(conDataGridView dgv, int nRow ,string total_amt, string price)
        {
            try
            {
                dgv.Rows[nRow].Cells["TOTAL_MONEY"].Value = "0";   // 금액
                string s수량 = ("" + (string)dgv.Rows[nRow].Cells[total_amt].Value).Replace(",", "");
                string s단가 = ("" + (string)dgv.Rows[nRow].Cells[price].Value).Replace(",", "");

                if (s수량 != "" && s단가 != "")
                {
                    string s금액 = (decimal.Parse(s수량) * decimal.Parse(s단가)).ToString();

                    dgv.Rows[nRow].Cells[total_amt].Value = (decimal.Parse(s수량)).ToString("#,0.######");
                    dgv.Rows[nRow].Cells[price].Value = (decimal.Parse(s단가)).ToString("#,0.######");
                    dgv.Rows[nRow].Cells["TOTAL_MONEY"].Value = (decimal.Parse(s금액)).ToString("#,0.######");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("숫자 허용 범위를 초과했습니다.");
                return;
            }
        }

        public void f_Calc_Price(DataGridView dgv, int nRow, string total_amt, string price)
        {
            try
            {
                dgv.Rows[nRow].Cells["TOTAL_MONEY"].Value = "0";   // 금액
                string s수량 = ("" + (string)dgv.Rows[nRow].Cells[total_amt].Value.ToString()).Replace(",", "");
                string s단가 = ("" + (string)dgv.Rows[nRow].Cells[price].Value.ToString()).Replace(",", "");

                if (s수량 != "" && s단가 != "")
                {
                    string s금액 = (decimal.Parse(s수량) * decimal.Parse(s단가)).ToString();

                    dgv.Rows[nRow].Cells[total_amt].Value = (decimal.Parse(s수량)).ToString("#,0.######");
                    dgv.Rows[nRow].Cells[price].Value = (decimal.Parse(s단가)).ToString("#,0.######");
                    dgv.Rows[nRow].Cells["TOTAL_MONEY"].Value = (decimal.Parse(s금액)).ToString("#,0.######");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("숫자 허용 범위를 초과했습니다.");
                return;
            }
        }

        public void mergeCells(DataGridView grd, int nColCnt)
        {
            int i;
            DataGridViewTextBoxCellEx item;
            string[] value = new string[nColCnt];
            int[] numArray = new int[nColCnt];
            int[] numArray1 = new int[nColCnt];
            for (i = 0; i < nColCnt; i++)
            {
                value[i] = "---";
                numArray[i] = 0;
                numArray1[i] = 0;
            }
            for (int j = 0; j < grd.Rows.Count; j++)
            {
                for (i = 0; i < nColCnt; i++)
                {
                    if (!(value[i] == ((string)grd.Rows[j].Cells[i].Value ?? "")))
                    {
                        if (numArray1[i] > 0)
                        {
                            item = (DataGridViewTextBoxCellEx)grd[i, numArray[i]];
                            item.RowSpan = numArray1[i] + 1;
                        }
                        numArray[i] = j;
                        numArray1[i] = 0;
                        value[i] = (string)grd.Rows[j].Cells[i].Value ?? "";
                    }
                    else if (i == 0)
                    {
                        numArray1[i]++;
                    }
                    else if (numArray1[i - 1] <= 0)
                    {
                        if (numArray1[i] > 0)
                        {
                            item = (DataGridViewTextBoxCellEx)grd[i, numArray[i]];
                            item.RowSpan = numArray1[i] + 1;
                        }
                        numArray[i] = j;
                        numArray1[i] = 0;
                        value[i] = (string)grd.Rows[j].Cells[i].Value ?? "";
                    }
                    else
                    {
                        numArray1[i]++;
                    }
                }
            }
            for (i = 0; i < nColCnt; i++)
            {
                if (numArray1[i] > 0)
                {
                    item = (DataGridViewTextBoxCellEx)grd[i, numArray[i]];
                    item.RowSpan = numArray1[i] + 1;
                }
            }
        }

        public void get_Prod_Info(conDataGridView dgv, int nRow, string sCode, string sCust, string s특매처, string s거래형태, string s주사제퍼센트, string s도매퍼센트)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_PRODUCT_Detail_Cust(sCode, sCust);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.Rows[nRow].Cells[6].Value = dt.Rows[0]["PRODUCT_SPEC"].ToString().Trim();

                    // null 처리
                    if (dt.Rows[0]["SELLING_PRICE1"].ToString().Trim() == "") dt.Rows[0]["SELLING_PRICE1"] = 0;
                    if (dt.Rows[0]["SELLING_PRICE2"].ToString().Trim() == "") dt.Rows[0]["SELLING_PRICE2"] = 0;
                    if (dt.Rows[0]["SELLING_PRICE3"].ToString().Trim() == "") dt.Rows[0]["SELLING_PRICE3"] = 0;
                    if (dt.Rows[0]["SELLING_PRICE4"].ToString().Trim() == "") dt.Rows[0]["SELLING_PRICE4"] = 0;
                    if (dt.Rows[0]["SELLING_PRICE5"].ToString().Trim() == "") dt.Rows[0]["SELLING_PRICE5"] = 0;
                    if (dt.Rows[0]["PRODUCT_PRICE2"].ToString().Trim() == "") dt.Rows[0]["PRODUCT_PRICE2"] = 0;
                    if (dt.Rows[0]["MIN_QTY"].ToString().Trim() == "") dt.Rows[0]["MIN_QTY"] = 0;

                    dgv.Rows[nRow].Cells[8].Value = decimal.Parse(dt.Rows[0]["SELLING_PRICE2"].ToString().Trim()).ToString(Common.p_strFormatUnit);    // 단가
                    dgv.Rows[nRow].Cells[11].Value = decimal.Parse(dt.Rows[0]["할인율"].ToString().Trim()).ToString("#,0");    // 할인율
                    dgv.Rows[nRow].Cells[12].Value = decimal.Parse(dt.Rows[0]["계약율"].ToString().Trim()).ToString("#,0");    // 계약율
                    dgv.Rows[nRow].Cells[13].Value = decimal.Parse(dt.Rows[0]["SELLING_PRICE6"].ToString().Trim()).ToString("#,0");    // 표준단가
                    if (s특매처 == "1")
                    {
                        dgv.Rows[nRow].Cells[11].Value = "0";    // 할인율
                        dgv.Rows[nRow].Cells[12].Value = "0";    // 계약율
                    }

                    //가. 거래처 거래형태(dealtype)가 “2.도매” 이면 도매단가(selling_price1) 적용
                    //나. 거래처 거래형태(dealtype)가 “1.약국” 이면 약국단가(selling_price2) 적용
                    //다. 거래처 거래형태(dealtype)가 “3.의원” 이면 의원단가(selling_price3) 적용
                    //라. 거래처 거래형태(dealtype)가 “5.병원”, “6.종합병원” 이면 병원단가(selling_price4) 적용
                    //마. 거래처 거래형태(dealtype)가 “9.기타” ... 

                    switch (s거래형태)
                    {
                        case "1":
                            dgv.Rows[nRow].Cells[8].Value = decimal.Parse(dt.Rows[0]["SELLING_PRICE2"].ToString().Trim()).ToString(Common.p_strFormatUnit);
                            break;
                        case "2":
                            dgv.Rows[nRow].Cells[8].Value = decimal.Parse(dt.Rows[0]["SELLING_PRICE1"].ToString().Trim()).ToString(Common.p_strFormatUnit);
                            break;
                        case "3":
                            dgv.Rows[nRow].Cells[8].Value = decimal.Parse(dt.Rows[0]["SELLING_PRICE3"].ToString().Trim()).ToString(Common.p_strFormatUnit);
                            break;
                        case "5":
                            dgv.Rows[nRow].Cells[8].Value = decimal.Parse(dt.Rows[0]["SELLING_PRICE4"].ToString().Trim()).ToString(Common.p_strFormatUnit);
                            break;
                        case "6":
                            dgv.Rows[nRow].Cells[8].Value = decimal.Parse(dt.Rows[0]["SELLING_PRICE4"].ToString().Trim()).ToString(Common.p_strFormatUnit);
                            break;
                        case "9":
                            string s기타단가 = decimal.Parse(dt.Rows[0]["SELLING_PRICE5"].ToString().Trim()).ToString(Common.p_strFormatUnit);

                            if (dt.Rows[0]["PRODUCT_TYPE"].ToString() == "12")
                            {
                                // 비급여 경우
                                dgv.Rows[nRow].Cells[8].Value = s기타단가;
                            }
                            else
                            {
                                // 급여 경우
                                if (int.Parse(s주사제퍼센트) != 0 && "" + dt.Rows[0]["PRODUCT_KIND"].ToString().Trim() == "08")
                                {
                                    //약가 * 환산량 (여기서 수숫점 버리지 말고 그냥 가져간다 ss_단가 - double 필드)
                                    double nDanGa = 0;
                                    nDanGa = double.Parse(dt.Rows[0]["PRODUCT_PRICE2"].ToString().Trim()) * double.Parse(dt.Rows[0]["MIN_QTY"].ToString().Trim());
                                    nDanGa = nDanGa / 1.1;

                                    //세바의약푸(519-001) 마이알주(399056) 단가가 33370이 나와야하는데 33380이 나와 소숫점 버림함)2013/12/30)
                                    //제품 스포라틴정(219166) 86%의 경우 단단위가 26520이 나와야 하는데 26510이나옴 그래서 fIX 제거함(2014-01-27)
                                    // FIX 제거하면 다른 제품이안 맞음...ㅠㅠ..VB6.0의 오류 FIX 앞에 VAL 을 해주면 된다
                                    nDanGa = nDanGa * ((100 - int.Parse(s주사제퍼센트)) / 100f);
                                    nDanGa = Math.Truncate(nDanGa);
                                    nDanGa = Math.Truncate(nDanGa / 10f);
                                    nDanGa = nDanGa * 10;

                                    dgv.Rows[nRow].Cells[8].Value = nDanGa.ToString(Common.p_strFormatUnit);
                                }
                                else
                                {
                                    if (int.Parse(s도매퍼센트) == 0 || "" + dt.Rows[0]["PRODUCT_TYPE"].ToString().Trim() == "12")
                                    {
                                        dgv.Rows[nRow].Cells[8].Value = s기타단가;
                                    }
                                    else
                                    {
                                        //약가 * 환산량 (여기서 수숫점 버리지 말고 그냥 가져간다 ss_단가 - double 필드)
                                        double nDanGa = 0;
                                        nDanGa = double.Parse(dt.Rows[0]["PRODUCT_PRICE2"].ToString().Trim()) * double.Parse(dt.Rows[0]["MIN_QTY"].ToString().Trim());
                                        nDanGa = nDanGa / 1.1;

                                        //세바의약푸(519-001) 마이알주(399056) 단가가 33370이 나와야하는데 33380이 나와 소숫점 버림함)2013/12/30)
                                        //제품 스포라틴정(219166) 85%의 경우 단단위가 26520이 나와야 하는데 26510이나옴 그래서 fIX 제거함(2014-01-27)
                                        //FIX 제거하면 다른 제품이안 맞음...ㅠㅠ..VB6.0의 오류 FIX 앞에 VAL 을 해주면 된다
                                        nDanGa = nDanGa * ((100 - int.Parse(s주사제퍼센트)) / 100f);
                                        nDanGa = Math.Truncate(nDanGa);
                                        nDanGa = Math.Truncate(nDanGa / 10f);
                                        nDanGa = nDanGa * 10;

                                        dgv.Rows[nRow].Cells[8].Value = nDanGa.ToString(Common.p_strFormatUnit);
                                    }
                                }
                            }
                            break;
                    }

                    //    //Calc_Price(dgv, nRow, s거래처부가세코드);
                }

            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        public decimal get_거래처별_잔고(string sCust, string sDay)
        {
            decimal nRet = 0;

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_거래처잔고_Summary(sCust, sDay);

                if (dt != null && dt.Rows.Count > 0)
                {
                    nRet = decimal.Parse(dt.Rows[0]["현잔고"].ToString());
                }
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
            return nRet;
        }

        public void set_Combo판매구분(bool bAll, conComboBox cmb, bool bNew)
        {
            string sqlQuery = "";

            cmb.ValueMember = "코드";
            cmb.DisplayMember = "명칭";

            if (bNew == true)
            {
                // 판매만 입력

                sqlQuery = " select '11' as 코드, '판매' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '22' as 코드, '반품' as 명칭 ";
            }
            else
            {
                // 옛날 데이터 표시용으로 활용

                sqlQuery = " select '11' as 코드, '판매' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '12' as 코드, '가조' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '13' as 코드, '기증' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '14' as 코드, '샘플' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '15' as 코드, '교환출고' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '16' as 코드, '수금찬조' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '17' as 코드, '할인찬조' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '18' as 코드, '신규판조' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '21' as 코드, '취소' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '22' as 코드, '반품' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '23' as 코드, '할증취소' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '25' as 코드, '교환입고' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '31' as 코드, '판매' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '32' as 코드, '반품' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '41' as 코드, '특판' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '42' as 코드, '특반' as 명칭 ";
                sqlQuery += " union all ";
                sqlQuery += " select '43' as 코드, '수출' as 명칭 ";
            }

            if (bAll == true)
            {
                ComboBox_Read_ALL(cmb, sqlQuery);
            }
            else
            {
                ComboBox_Read_NoBlank(cmb, sqlQuery);
            }
        }

        public void set_Combo수금구분(bool bAll, conComboBox cmb)
        {
            string sqlQuery = "";

            cmb.ValueMember = "코드";
            cmb.DisplayMember = "명칭";

            sqlQuery = " select '51' as 코드, '현금' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '52' as 코드, '카드' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '53' as 코드, '취소' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '61' as 코드, '은행도' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '62' as 코드, '신협' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '63' as 코드, '자가' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '64' as 코드, '당좌' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '65' as 코드, '가계' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '71' as 코드, '매출할인' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '72' as 코드, '대손' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '73' as 코드, '신고할인' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '90' as 코드, '잔고이월' as 명칭 ";

            if (bAll == true)
            {
                ComboBox_Read_ALL(cmb, sqlQuery);
            }
            else
            {
                ComboBox_Read_NoBlank(cmb, sqlQuery);
            }
        }

        public void set_Combo수금구분_영업소(bool bAll, conComboBox cmb)
        {
            string sqlQuery = "";

            cmb.ValueMember = "코드";
            cmb.DisplayMember = "명칭";

            sqlQuery = " select '51' as 코드, '현금' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '52' as 코드, '카드' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '53' as 코드, '취소' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '61' as 코드, '은행도' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '62' as 코드, '신협' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '63' as 코드, '자가' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '64' as 코드, '당좌' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '65' as 코드, '가계' as 명칭 ";
            //sqlQuery += " union all ";
            //sqlQuery += " select '71' as 코드, '매출할인' as 명칭 ";
            //sqlQuery += " union all ";
            //sqlQuery += " select '72' as 코드, '대손' as 명칭 ";
            //sqlQuery += " union all ";
            //sqlQuery += " select '73' as 코드, '신고할인' as 명칭 ";
            //sqlQuery += " union all ";
            //sqlQuery += " select '90' as 코드, '잔고이월' as 명칭 ";

            if (bAll == true)
            {
                ComboBox_Read_ALL(cmb, sqlQuery);
            }
            else
            {
                ComboBox_Read_NoBlank(cmb, sqlQuery);
            }
        }

        public void set_Combo어음처리형태(bool bAll, conComboBox cmb)
        {
            string sqlQuery = "";

            cmb.ValueMember = "코드";
            cmb.DisplayMember = "명칭";

            sqlQuery = " select '0' as 코드, '미결재' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '1' as 코드, '만기결제' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '2' as 코드, '예금입금' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '3' as 코드, '대체결제' as 명칭 ";
            sqlQuery += " union all ";
            sqlQuery += " select '4' as 코드, '할인' as 명칭 ";

            if (bAll == true)
            {
                ComboBox_Read_ALL(cmb, sqlQuery);
            }
            else
            {
                ComboBox_Read_NoBlank(cmb, sqlQuery);
            }
        }

        public string get_판매구분_명칭(string sCode)
        {
            string sRet = "";

            switch (sCode.Trim())
            {
                case "11":
                    sRet = "판매";
                    break;
                case "12":
                    sRet = "가조";
                    break;
                case "13":
                    sRet = "기증";
                    break;
                case "14":
                    sRet = "샘플";
                    break;
                case "15":
                    sRet = "교환출고";
                    break;
                case "16":
                    sRet = "수금찬조";
                    break;
                case "17":
                    sRet = "할인찬조";
                    break;
                case "18":
                    sRet = "신규판조";
                    break;
                case "21":
                    sRet = "취소";
                    break;
                case "22":
                    sRet = "반품";
                    break;
                case "23":
                    sRet = "할증취소";
                    break;
                case "25":
                    sRet = "교환입고";
                    break;
                case "31":
                    sRet = "판매";
                    break;
                case "32":
                    sRet = "반품";
                    break;
                case "41":
                    sRet = "특판";
                    break;
                case "42":
                    sRet = "특반";
                    break;
                case "43":
                    sRet = "수출";
                    break;
                default:
                    sRet = "?";
                    break;
            }
            return sRet;
        }

        public string get_수금구분_명칭(string sCode)
        {
            string sRet = "";

            switch (sCode.Trim())
            {
                case "51":
                    sRet = "현금";
                    break;
                case "52":
                    sRet = "카드";
                    break;
                case "53":
                    sRet = "취소";
                    break;
                case "61":
                    sRet = "은행도";
                    break;
                case "62":
                    sRet = "신협";
                    break;
                case "63":
                    sRet = "자가";
                    break;
                case "64":
                    sRet = "당좌";
                    break;
                case "65":
                    sRet = "가계";
                    break;
                case "71":
                    sRet = "매출할인";
                    break;
                case "72":
                    sRet = "대손";
                    break;
                case "73":
                    sRet = "신고할인";
                    break;
                case "90":
                    sRet = "잔고이월";
                    break;
                default:
                    sRet = "?";
                    break;
            }
            return sRet;
        }

        public void call_pop_raw_mat(conDataGridView dgv, DataTable dt, int nRow, string sTxt, int gbn,String CUST_CD)
        {
            Popup.pop원자재검색 frm = new Popup.pop원자재검색(CUST_CD);
            Console.WriteLine("in the call_pop_raw_mat");
            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                
                if (gbn == 1)
                {
                    dgv.Rows[nRow].Cells["RAW_MAT_CD"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_CD"].Value;
                    dgv.Rows[nRow].Cells["RAW_MAT_NM"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value;
                    dgv.Rows[nRow].Cells["OLD_RAW_MAT_NM"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value;
                    dgv.Rows[nRow].Cells["SPEC"].Value = frm.dgv.Rows[0].Cells["SPEC"].Value;

                    dgv.Rows[nRow].Cells["IN_UNIT"].Value = frm.dgv.Rows[0].Cells["INPUT_UNIT"].Value;
                    dgv.Rows[nRow].Cells["OUT_UNIT"].Value = frm.dgv.Rows[0].Cells["OUTPUT_UNIT"].Value;
                    dgv.Rows[nRow].Cells["IN_UNIT_NM"].Value = frm.dgv.Rows[0].Cells["INPUT_UNIT_NM"].Value;
                    dgv.Rows[nRow].Cells["OUT_UNIT_NM"].Value = frm.dgv.Rows[0].Cells["OUTPUT_UNIT_NM"].Value;
                    dgv.Rows[nRow].Cells["TOTAL_AMT"].Value = "0";
                    dgv.Rows.Add();
                    dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
                }
                else if (gbn == 2)
                {
                    dgv.Rows[nRow].Cells["RAW_MAT_CD"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_CD"].Value;
                    dgv.Rows[nRow].Cells["RAW_MAT_NM"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value;
                    dgv.Rows[nRow].Cells["OLD_RAW_MAT_NM"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value;
                    dgv.Rows[nRow].Cells["SPEC"].Value = frm.dgv.Rows[0].Cells["SPEC"].Value;
                    dgv.Rows[nRow].Cells["UNIT_CD"].Value = frm.dgv.Rows[0].Cells["INPUT_UNIT"].Value;
                    dgv.Rows[nRow].Cells["UNIT_NM"].Value = frm.dgv.Rows[0].Cells["INPUT_UNIT_NM"].Value;
                    dgv.Rows[nRow].Cells["PRICE"].Value = frm.dgv.Rows[0].Cells["INPUT_PRICE"].Value;

                    dgv.Rows.Add();
                    dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
                    dgv.Rows[dgv.Rows.Count - 1].Cells["PRICE"].Value = "0";
                    dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
                }
                else //gbn == 3
                {
                    dgv.Rows[nRow].Cells["RAW_MAT_CD"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_CD"].Value;
                    dgv.Rows[nRow].Cells["RAW_MAT_NM"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value;
                    //dgv.Rows[nRow].Cells["OLD_RAW_MAT_NM"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value;
                    dgv.Rows[nRow].Cells["SPEC"].Value = frm.dgv.Rows[0].Cells["SPEC"].Value;
                    dgv.Rows[nRow].Cells["INPUT_UNIT"].Value = frm.dgv.Rows[0].Cells["INPUT_UNIT"].Value;
                    dgv.Rows[nRow].Cells["OUTPUT_UNIT"].Value = frm.dgv.Rows[0].Cells["OUTPUT_UNIT"].Value;
                    dgv.Rows[nRow].Cells["INPUT_UNIT_NM"].Value = frm.dgv.Rows[0].Cells["INPUT_UNIT_NM"].Value;
                    dgv.Rows[nRow].Cells["OUTPUT_UNIT_NM"].Value = frm.dgv.Rows[0].Cells["OUTPUT_UNIT_NM"].Value;
                    dgv.Rows[nRow].Cells["BAL_STOCK"].Value = frm.dgv.Rows[0].Cells["BAL_STOCK"].Value;
                    dgv.Rows[nRow].Cells["CUST_CD"].Value = frm.dgv.Rows[0].Cells["CUST_CD"].Value;
                    dgv.Rows[nRow].Cells["CUST_NM"].Value = frm.dgv.Rows[0].Cells["CUST_NM"].Value;

                    dgv.Rows[nRow].Cells["CVR_RATIO"].Value = frm.dgv.Rows[0].Cells["CVR_RATIO"].Value;
                    if (frm.dgv.Rows[0].Cells["CUST_CD"].Value.ToString() == "dregs")
                    {
                        dgv.Rows[nRow].Cells["INPUT_DATE"].Value = frm.dgv.Rows[0].Cells["INPUT_DATE"].Value;
                        dgv.Rows[nRow].Cells["INPUT_CD"].Value = frm.dgv.Rows[0].Cells["INPUT_CD"].Value;
                        dgv.Rows[nRow].Cells["INPUT_SEQ"].Value = frm.dgv.Rows[0].Cells["SEQ"].Value;
                    }
                }
                
               

            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    if (gbn == 1)
                    {
                        for (int i = 0; i < frm.list.Count; i++)
                        {
                            dgv.Rows[nRow].Cells["RAW_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value;
                            dgv.Rows[nRow].Cells["RAW_MAT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_NM"].Value;
                            dgv.Rows[nRow].Cells["SPEC"].Value = frm.dgv.Rows[frm.list[i]].Cells["SPEC"].Value;
                            dgv.Rows[nRow].Cells["IN_UNIT"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_UNIT"].Value;
                            dgv.Rows[nRow].Cells["OUT_UNIT"].Value = frm.dgv.Rows[frm.list[i]].Cells["OUTPUT_UNIT"].Value;
                            dgv.Rows[nRow].Cells["IN_UNIT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_UNIT_NM"].Value;
                            dgv.Rows[nRow].Cells["OUT_UNIT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["OUTPUT_UNIT_NM"].Value;
                            dgv.Rows[nRow].Cells["TOTAL_AMT"].Value = "0";
                            if (i == frm.list.Count - 1)
                            {
                                break;
                            }
                            nRow++;
                            dgv.Rows.Add();
                        }
                    }
                    else if (gbn == 2)
                    {
                        for (int i = 0; i < frm.list.Count; i++)
                        {
                            dgv.Rows[nRow].Cells["RAW_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value;
                            dgv.Rows[nRow].Cells["RAW_MAT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_NM"].Value;
                            dgv.Rows[nRow].Cells["OLD_RAW_MAT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_NM"].Value;
                            dgv.Rows[nRow].Cells["SPEC"].Value = frm.dgv.Rows[frm.list[i]].Cells["SPEC"].Value;
                            dgv.Rows[nRow].Cells["UNIT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_UNIT"].Value;
                            dgv.Rows[nRow].Cells["UNIT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_UNIT_NM"].Value;
                            dgv.Rows[nRow].Cells["PRICE"].Value = "0";
                            dgv.Rows[nRow].Cells["TOTAL_AMT"].Value = "0";
                            dgv.Rows[nRow].Cells["TOTAL_MONEY"].Value = "0";
                            if (i == frm.list.Count - 1)
                            {
                                break;
                            }
                            nRow++;
                            dgv.Rows.Add();
                        }
                    }
                    else //gbn == 3
                    {
                        //dgv.Rows[nRow].Cells["OLD_RAW_MAT_NM"].Value = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value;


                        for (int i = 0; i < frm.list.Count; i++)
                        {
                            dgv.Rows[nRow].Cells["SPEC"].Value = frm.dgv.Rows[frm.list[i]].Cells["SPEC"].Value;
                            dgv.Rows[nRow].Cells["INPUT_UNIT"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_UNIT"].Value;
                            dgv.Rows[nRow].Cells["OUTPUT_UNIT"].Value = frm.dgv.Rows[frm.list[i]].Cells["OUTPUT_UNIT"].Value;
                            dgv.Rows[nRow].Cells["INPUT_UNIT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_UNIT_NM"].Value;
                            dgv.Rows[nRow].Cells["OUTPUT_UNIT_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["OUTPUT_UNIT_NM"].Value;
                            dgv.Rows[nRow].Cells["BAL_STOCK"].Value = frm.dgv.Rows[frm.list[i]].Cells["BAL_STOCK"].Value;
                            dgv.Rows[nRow].Cells["CUST_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["CUST_CD"].Value;
                            dgv.Rows[nRow].Cells["CUST_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["CUST_NM"].Value;

                            dgv.Rows[nRow].Cells["CVR_RATIO"].Value = frm.dgv.Rows[frm.list[i]].Cells["CVR_RATIO"].Value;
                            if (frm.dgv.Rows[frm.list[i]].Cells["CUST_CD"].Value.ToString() == "dregs")
                            {
                                dgv.Rows[nRow].Cells["INPUT_DATE"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_DATE"].Value;
                                dgv.Rows[nRow].Cells["INPUT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["INPUT_CD"].Value;
                                dgv.Rows[nRow].Cells["INPUT_SEQ"].Value = frm.dgv.Rows[frm.list[i]].Cells["SEQ"].Value;
                            }
                            if (i == frm.list.Count - 1)
                            {
                                break;
                            }
                            nRow++;
                            dgv.Rows.Add();
                        }

                    }
                }
                //dgv.Rows[nRow].Cells["RAW_MAT_NM"].Value = (string)dgv.Rows[nRow].Cells["OLD_RAW_MAT_NM"].Value;
            }
            

            frm.Dispose();
            frm = null;
        }

        public void call_pop_flow(conDataGridView dgv, DataTable dt, int nRow, string sTxt)
        {
            Popup.pop공정검색 frm = new Popup.pop공정검색();

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                try
                {
                    dgv.Rows[nRow].Cells["FLOW_CD"].Value = frm.sRetCode.Trim();
                    dgv.Rows[nRow].Cells["FLOW_NM"].Value = frm.sRetName.Trim();
                    dgv.Rows[nRow].Cells["OLD_FLOW_NM"].Value = frm.sRetName.Trim();
                    dgv.Rows[nRow].Cells["식별표"].Value = frm.sRetIDENYN.Trim();

                    if (frm.sRetFlowYN.Trim().ToString().Equals("Y"))
                    {
                        dgv.Rows[nRow].Cells["FLOW_YN"].Value = true;
                    }
                    else
                    {
                        dgv.Rows[nRow].Cells["FLOW_YN"].Value = false;
                    }
                    if (frm.sRetIDENYN.Trim().ToString().Equals("Y"))
                    {
                        dgv.Rows[nRow].Cells["식별표"].Value = true;
                    }
                    else
                    {
                        dgv.Rows[nRow].Cells["식별표"].Value = false;
                    }
                    dgv.Rows.Add();
                }
                catch (Exception ex)
                {
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    try
                    {
                        for (int i = 0; i < frm.list.Count; i++)
                        {
                            dgv.Rows[nRow].Cells["FLOW_CD"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_CD"].Value;
                            dgv.Rows[nRow].Cells["FLOW_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_NM"].Value;
                            dgv.Rows[nRow].Cells["OLD_FLOW_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_NM"].Value;
                            //dgv.Rows[nRow].Cells["식별표"].Value = frm.dgv.Rows[frm.list[i]].Cells["제품식별표"].Value;


                            if (frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_YN"].Value != null && frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_YN"].Value.Equals("Y"))
                            {
                                dgv.Rows[nRow].Cells["FLOW_YN"].Value = true;
                            }
                            else
                            {
                                dgv.Rows[nRow].Cells["FLOW_YN"].Value = false;
                            }

                            if (i == frm.list.Count - 1)
                            {
                                break;
                            }

                            nRow++;
                            dgv.Rows.Add();

                        }
                    }
                    catch (Exception ex)
                    {
                        Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                        msg.ShowDialog();
                    }
                }
            }

            frm.Dispose();
            frm = null;
        }

        public string call_pop_item(conDataGridView dgv, DataTable dt, int nRow, string sTxt)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();
            string sCode = frm.sCode;

            if (frm.sCode != "")
            {

                if ((string)dgv.Rows[nRow].Cells["OLD_ITEM_CD"].Value != frm.sCode.Trim())
                {
                    dgv.Rows[nRow].Cells["ITEM_CD"].Value = frm.sCode.Trim();
                    dgv.Rows[nRow].Cells["SPEC"].Value = frm.sSpec.Trim();
                    dgv.Rows[nRow].Cells["ITEM_NM"].Value = frm.sName.Trim();

                    dgv.Rows[nRow].Cells["OLD_ITEM_CD"].Value = frm.sCode.Trim();
                    dgv.Rows[nRow].Cells["OLD_ITEM_NM"].Value = frm.sName.Trim();
                    dgv.Rows[nRow].Cells["UNIT_CD"].Value = frm.sUnitCd.Trim();
                    dgv.Rows[nRow].Cells["UNIT_NM"].Value = frm.sUnitNm.Trim();
                    dgv.Rows[nRow].Cells["PRICE"].Value = frm.sOutputPrice.Trim();

                    //dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
                    dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "1";
                    dgv.Rows[dgv.Rows.Count - 1].Cells["UNIT_AMT"].Value = "1";

                    dgv.Rows.Add();
                    dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
                    dgv.Rows[dgv.Rows.Count - 1].Cells["PRICE"].Value = "0";
                    dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
                }
                else 
                {
                    dgv.Rows[nRow].Cells["ITEM_NM"].Value = (string)dgv.Rows[nRow].Cells["OLD_ITEM_NM"].Value;
                }
            }
            else
            {
                dgv.Rows[nRow].Cells["ITEM_NM"].Value = (string)dgv.Rows[nRow].Cells["OLD_ITEM_NM"].Value;
            }

            frm.Dispose();
            frm = null;

            return sCode;
        }

        public string call_pop_item2(conDataGridView dgv, DataTable dt, int nRow, string sTxt,string strcust_cd)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색(strcust_cd);

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();
            string sCode = frm.sCode;

            if (frm.sCode != "")
            {

                if ((string)dgv.Rows[nRow].Cells["OLD_ITEM_CD"].Value != frm.sCode.Trim())
                {
                    dgv.Rows[nRow].Cells["ITEM_CD"].Value = frm.sCode.Trim();
                    dgv.Rows[nRow].Cells["SPEC"].Value = frm.sSpec.Trim();
                    dgv.Rows[nRow].Cells["ITEM_NM"].Value = frm.sName.Trim();

                    dgv.Rows[nRow].Cells["OLD_ITEM_CD"].Value = frm.sCode.Trim();
                    dgv.Rows[nRow].Cells["OLD_ITEM_NM"].Value = frm.sName.Trim();
                    dgv.Rows[nRow].Cells["UNIT_CD"].Value = frm.sUnitCd.Trim();
                    dgv.Rows[nRow].Cells["UNIT_NM"].Value = frm.sUnitNm.Trim();
                    dgv.Rows[nRow].Cells["PRICE"].Value = frm.sOutputPrice.Trim();

                    //dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
                    dgv.Rows[nRow].Cells["TOTAL_AMT"].Value = "1";
                    dgv.Rows[nRow].Cells["UNIT_AMT"].Value = "1";

                    
                   // dgv.Rows[nRow].Cells["TOTAL_AMT"].Value = "0";
                    dgv.Rows[nRow].Cells["TOTAL_MONEY"].Value = "0";
                    dgv.Rows.Add();
                }
                else
                {
                    dgv.Rows[nRow].Cells["ITEM_NM"].Value = (string)dgv.Rows[nRow].Cells["OLD_ITEM_NM"].Value;
                }
            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        dgv.Rows[nRow].Cells["ITEM_CD"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_CD"].Value;
                        dgv.Rows[nRow].Cells["SPEC"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["SPEC"].Value;
                        dgv.Rows[nRow].Cells["ITEM_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_NM"].Value;

                        dgv.Rows[nRow].Cells["OLD_ITEM_CD"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_CD"].Value;
                        dgv.Rows[nRow].Cells["OLD_ITEM_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_NM"].Value;
                        dgv.Rows[nRow].Cells["UNIT_CD"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["UNIT_CD"].Value;
                        dgv.Rows[nRow].Cells["UNIT_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["UNIT_NM"].Value;
                        dgv.Rows[nRow].Cells["PRICE"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["OUTPUT_PRICE"].Value.ToString();

                        //dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
                        dgv.Rows[nRow].Cells["TOTAL_AMT"].Value = "1";
                        dgv.Rows[nRow].Cells["UNIT_AMT"].Value = "1";
                        dgv.Rows[nRow].Cells["TOTAL_MONEY"].Value = "0";

                      
                        // dgv.Rows[nRow].Cells["BAL_STOCK"].Value = frm.dgv.Rows[frm.list[i]].Cells["BAL_STOCK"].Value;
                        // dgv.Rows[nRow].Cells["CUST_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["CUST_CD"].Value;
                        // dgv.Rows[nRow].Cells["CUST_NM"].Value = frm.dgv.Rows[frm.list[i]].Cells["CUST_NM"].Value;
                        // dgv.Rows[nRow].Cells["CVR_RATIO"].Value = frm.dgv.Rows[frm.list[i]].Cells["CVR_RATIO"].Value;

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }

                        nRow++;
                        dgv.Rows.Add();

                    }
                }
                dgv.Rows[nRow].Cells["ITEM_NM"].Value = (string)dgv.Rows[nRow].Cells["OLD_ITEM_NM"].Value;
            }

            frm.Dispose();
            frm = null;

            return sCode;
        }

        public void call_pop_item_half(conDataGridView dgv, DataTable dt, int nRow, string sTxt)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();


            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.HalfItemSearch = "0";
            frm.txtSrch.Text = sTxt;
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                dgv.Rows[nRow].Cells["HALF_ITEM_CD"].Value = frm.sCode.Trim();
                dgv.Rows[nRow].Cells["HALF_ITEM_NM"].Value = frm.sName.Trim();
                dgv.Rows[nRow].Cells["OLD_HALF_ITEM_NM"].Value = frm.sName.Trim();
                dgv.Rows[nRow].Cells["H_UNIT_CD"].Value = frm.sUnitCd.Trim();
                dgv.Rows[nRow].Cells["H_UNIT_NM"].Value = frm.sUnitNm.Trim();
                dgv.Rows[nRow].Cells["H_TOTAL_AMT"].Value = "0";

                dgv.Rows.Add();
                dgv.Rows[dgv.Rows.Count - 1].Cells["H_TOTAL_AMT"].Value = "0";
            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        dgv.Rows[nRow].Cells["HALF_ITEM_CD"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_CD"].Value;
                        dgv.Rows[nRow].Cells["HALF_ITEM_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_NM"].Value;
                        dgv.Rows[nRow].Cells["OLD_HALF_ITEM_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_NM"].Value;
                        dgv.Rows[nRow].Cells["H_UNIT_CD"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["UNIT_CD"].Value;
                        dgv.Rows[nRow].Cells["H_UNIT_NM"].Value = frm.GridRecord.Rows[frm.list[i]].Cells["UNIT_NM"].Value;
                        dgv.Rows[nRow].Cells["H_TOTAL_AMT"].Value = "0";

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }

                        nRow++;
                        dgv.Rows.Add();
                    }
                }
            }

            frm.Dispose();
            frm = null;
        }

        public string call_pop_chk(conDataGridView dgv, DataTable dt, int nRow, string sTxt, int chk_gbn)
        {
            Popup.pop검사기준검색 frm = new Popup.pop검사기준검색();

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = sTxt;
            frm.chk_gbn = chk_gbn;
            frm.ShowDialog();
            string sCode = frm.sCode;

            if (frm.sCode != "")
            {

                bool chk = true;
                string msg = "";
                if ((string)dgv.Rows[nRow].Cells["OLD_CHK_CD"].Value != frm.sCode.Trim())
                {
                    for (int i = 0; i < dgv.Rows.Count; i++) 
                    {
                        if ((string)dgv.Rows[i].Cells["CHK_CD"].Value == frm.sCode.Trim()) 
                        {
                             msg = "검사기준 코드: " + frm.sName.Trim() + "(이)가 존재합니다. ";
                            chk = false;

                            break;
                        }
                    }

                    if (chk)
                    {
                        dgv.Rows[nRow].Cells["NO"].Value = (nRow + 1).ToString();
                        dgv.Rows[nRow].Cells["CHK_CD"].Value = frm.sCode.Trim();
                        dgv.Rows[nRow].Cells["CHK_NM"].Value = frm.sName.Trim();
                        dgv.Rows[nRow].Cells["CHK_ORD"].Value = frm.sOrd.Trim();

                        dgv.Rows[nRow].Cells["OLD_CHK_CD"].Value = frm.sCode.Trim();
                        dgv.Rows[nRow].Cells["OLD_CHK_NM"].Value = frm.sName.Trim();

                    }
                    else 
                    {
                        MessageBox.Show(msg);
                    }
                    
                }
                else
                {
                    dgv.Rows[nRow].Cells["CHK_NM"].Value = (string)dgv.Rows[nRow].Cells["OLD_CHK_NM"].Value;
                }
            }
            else
            {
                dgv.Rows[nRow].Cells["CHK_NM"].Value = (string)dgv.Rows[nRow].Cells["OLD_CHK_NM"].Value;
            }

            frm.Dispose();
            frm = null;

            return sCode;
        }

        public bool[] btnRight(string lbl_title_tag)
        {

            if (Common.p_strUserAdmin != "5")
            {
                DataTable dtcheck = wnDm.fn_auth_check(lbl_title_tag.Split('$')[0], lbl_title_tag.Split('$')[1]);
                rightSave = dtcheck.Rows[0]["rgstr_yn"].ToString() == "Y" ? true : false; //이제 등록,삭제는 하나로 가기로 가정했을때
                rightDel = dtcheck.Rows[0]["del_yn"].ToString() == "Y" ? true : false;

                arr[0] = rightSave;
                arr[1] = rightDel;

            }
            else
            {
                arr[0] = true;
                arr[1] = true;
            }

            return arr;
        }

        public void f_Calc_Price(conDataGridView dgv, int nRow, string col_total_amt, string col_price, string col_total_money, string col_supply, string col_tax, string col_all_total_money, string 부가세구분, string 과세구분)
        {
            try
            {
                dgv.Rows[nRow].Cells[col_total_money].Value = "0";   // 금액
                string s수량 = ("" + (string)dgv.Rows[nRow].Cells[col_total_amt].Value).Replace(",", "");
                string s단가 = ("" + (string)dgv.Rows[nRow].Cells[col_price].Value).Replace(",", "");

                if (s수량 != "" && s단가 != "")
                {
                    string s금액 = (decimal.Parse(s수량) * decimal.Parse(s단가)).ToString();

                    dgv.Rows[nRow].Cells[col_total_amt].Value = (decimal.Parse(s수량)).ToString("#,0.######");
                    dgv.Rows[nRow].Cells[col_price].Value = (decimal.Parse(s단가)).ToString("#,0.######");
                    dgv.Rows[nRow].Cells[col_total_money].Value = (decimal.Parse(s금액)).ToString("#,0.######");

                    decimal supply_money = 0;
                    decimal tax_money = 0;
                    decimal all_money = 0;

                    if (과세구분.Equals("2")) //면세
                    {
                        supply_money = decimal.Parse(s단가) * decimal.Parse(s수량);
                        tax_money = 0;
                        all_money = supply_money + tax_money;

                        dgv.Rows[nRow].Cells[col_supply].Value = supply_money.ToString("#,0.######");
                        dgv.Rows[nRow].Cells[col_tax].Value = tax_money.ToString("#,0.######");
                        dgv.Rows[nRow].Cells[col_all_total_money].Value = all_money.ToString("#,0.######");
                    }
                    else //과세일 경우 
                    {
                        if (부가세구분.Equals("0")) // 부가세 별도
                        {
                            supply_money = decimal.Parse(s수량) * decimal.Parse(s단가);
                            tax_money = supply_money * decimal.Parse("0.1");
                            all_money = supply_money + tax_money;

                            dgv.Rows[nRow].Cells[col_supply].Value = supply_money.ToString("#,0.######");
                            dgv.Rows[nRow].Cells[col_tax].Value = tax_money.ToString("#,0.######");
                            dgv.Rows[nRow].Cells[col_all_total_money].Value = all_money.ToString("#,0.######");
                        }
                        else if (부가세구분.Equals("1")) // 부가세 포함
                        {
                            all_money = decimal.Parse(s단가) * decimal.Parse(s수량);
                            supply_money = all_money / decimal.Parse("1.1");
                            supply_money = decimal.Round(supply_money, 0);
                            tax_money = all_money - supply_money;

                            dgv.Rows[nRow].Cells[col_supply].Value = supply_money.ToString("#,0.######");
                            dgv.Rows[nRow].Cells[col_tax].Value = tax_money.ToString("#,0.######");
                            dgv.Rows[nRow].Cells[col_all_total_money].Value = all_money.ToString("#,0.######");
                        }
                        else
                        { //영세율
                            supply_money = decimal.Parse(s단가) * decimal.Parse(s수량);
                            tax_money = 0;
                            all_money = supply_money + tax_money;

                            dgv.Rows[nRow].Cells[col_supply].Value = supply_money.ToString("#,0.######");
                            dgv.Rows[nRow].Cells[col_tax].Value = tax_money.ToString("#,0.######");
                            dgv.Rows[nRow].Cells[col_all_total_money].Value = all_money.ToString("#,0.######");
                        }
                    }
                }
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("합계액 계산시 오류 발생\n숫자 허용범위가 초과되었을 수 있습니다.");
            }
        }


        public void f_Calc_SalesPrice(
            conTextBox txt_supply_money
            , conTextBox txt_tax_money
            , conTextBox txt_total_money
            , string vat_cd
            , Label no_tax_money
            , Label yes_tax_money
            , Label yesno_tax_money
            , conDataGridView targetGrid
            , string col_Supply
            , string col_Tax
            , string col_Total
            , string col_TaxCd
            , bool nullChk_Gubun
            , string col_Chk
            )
        {
            try
            {
                decimal supply_Sum = 0;
                decimal tax_Sum = 0;
                decimal total_Sum = 0;
                decimal total_Sum_Tax = 0;

                if (nullChk_Gubun) // true : chek  false : not check
                {
                    for (int i = 0; i < targetGrid.Rows.Count; i++)
                    {
                        if (targetGrid.Rows[i].Cells[col_Chk].Value != null && !targetGrid.Rows[i].Cells[col_Chk].Value.ToString().Equals(""))
                        {
                            decimal thisToTal = 0;
                            string thisTax_gubun = "";

                            if (targetGrid.Rows[i].Cells[col_Total].Value != null && !targetGrid.Rows[i].Cells[col_Total].Value.ToString().Equals(""))
                                thisToTal = decimal.Parse(targetGrid.Rows[i].Cells[col_Total].Value.ToString().Replace(",", ""));

                            thisTax_gubun = targetGrid.Rows[i].Cells[col_TaxCd].Value.ToString(); //1 과세 2 면세

                            if (!vat_cd.Equals("2") && thisTax_gubun.Equals("1")) //과세
                            {
                                total_Sum_Tax += decimal.Parse(targetGrid.Rows[i].Cells[col_Total].Value.ToString().Replace(",", ""));
                            }
                            else //면세
                            {
                                total_Sum += decimal.Parse(targetGrid.Rows[i].Cells[col_Total].Value.ToString().Replace(",", ""));
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < targetGrid.Rows.Count; i++)
                    {
                        decimal thisToTal = 0;
                        string thisTax_gubun = "";

                        if (targetGrid.Rows[i].Cells[col_Total].Value != null && !targetGrid.Rows[i].Cells[col_Total].Value.ToString().Equals(""))
                            thisToTal = decimal.Parse(targetGrid.Rows[i].Cells[col_Total].Value.ToString().Replace(",", ""));

                        thisTax_gubun = targetGrid.Rows[i].Cells[col_TaxCd].Value.ToString(); //1 과세 2 면세

                        if (!vat_cd.Equals("2") && thisTax_gubun.Equals("1")) //과세
                        {
                            total_Sum_Tax += decimal.Parse(targetGrid.Rows[i].Cells[col_Total].Value.ToString().Replace(",", ""));
                        }
                        else //면세
                        {
                            total_Sum += decimal.Parse(targetGrid.Rows[i].Cells[col_Total].Value.ToString().Replace(",", ""));
                        }
                    }
                }
                decimal oneDotOne = decimal.Parse("1.1");
                supply_Sum += Math.Round(total_Sum_Tax / oneDotOne);
                tax_Sum += total_Sum_Tax - Math.Round(total_Sum_Tax / oneDotOne);
                supply_Sum += total_Sum;

                no_tax_money.Text = total_Sum.ToString("#,0.######");
                yes_tax_money.Text = total_Sum_Tax.ToString("#,0.######");
                txt_total_money.Text = (total_Sum + total_Sum_Tax).ToString("#,0.######");
                yesno_tax_money.Text = txt_total_money.Text;
                txt_supply_money.Text = (supply_Sum).ToString("#,0.######");
                txt_tax_money.Text = (tax_Sum).ToString("#,0.######");


            }
            catch (Exception ex)
            {
                MessageBox.Show("총 합계액 계산 시 오류발생\n숫자 허용 범위가 초과되었을 수 있습니다.");
            }
        }



        public static void cal_soo_money(TextBox soo, TextBox dc, TextBox total)
        {
            try
            {
                if (soo.Text == null || soo.Text.ToString().Equals("")) soo.Text = "0";
                if (dc.Text == null || dc.Text.ToString().Equals("")) dc.Text = "0";
                if (total.Text == null || total.Text.ToString().Equals("")) total.Text = "0";

                soo.Text = decimal.Parse(soo.Text.ToString().Replace(",", "")).ToString("#,0.######");
                dc.Text = decimal.Parse(dc.Text.ToString().Replace(",", "")).ToString("#,0.######");
                total.Text = (decimal.Parse(soo.Text.ToString()) + decimal.Parse(dc.Text.ToString())).ToString("#,0.######");
            }
            catch (Exception ex)
            {
                MessageBox.Show("총 합계액 계산 시 오류발생\n숫자 허용 범위가 초과되었을 수 있습니다.");
            }
        }

        public static void dataGridView_ExportToExcel_Day(string fileName, DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            workSheet.Name = "C#";

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("출력할 데이터가 없습니다");
                return;
            }

            // 헤더 출력
            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                workSheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }


            //내용 출력
            Color backColorTemp = Color.White;
            Color foreColorTemp = Color.Black;
            Microsoft.Office.Interop.Excel.Range range = null;
            string[] ABC = new string[25];
            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                ABC[i] = ((char)(i + 65)).ToString();
                Console.WriteLine(ABC[i]);
            }


            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                backColorTemp = Color.White;
                foreColorTemp = Color.Black;


                if (dgv.Rows[r].Cells["SALES_DATE"].Value.ToString().Equals("=== 소계 ==="))
                {
                    backColorTemp = dgv.Rows[r].Cells[10].Style.BackColor;
                    //backColorTemp = Color.FromArgb(0, 192, 192);
                    range = workSheet.Range[ABC[4] + (r + 2) + ":" + ABC[dgv.Columns.Count - 2] + (r + 2)];
                }
                else if (dgv.Rows[r].Cells["SALES_DATE"].Value.ToString().Equals("=== 합계 ==="))
                {
                    backColorTemp = dgv.Rows[r].Cells[10].Style.BackColor;
                    foreColorTemp = dgv.Rows[r].Cells[10].Style.ForeColor;

                    range = workSheet.Range[ABC[0] + (r + 2) + ":" + ABC[dgv.Columns.Count - 2] + (r + 2)];
                }
                else
                {
                    range = workSheet.Range[ABC[0] + (r + 2) + ":" + ABC[dgv.Columns.Count - 2] + (r + 2)];
                }

                //range.Interior.Color = Color.FromArgb(0, 192, 192);
                range.Interior.Color = backColorTemp;
                range.Borders.Color = Color.FromArgb(224, 224, 224);
                range.Font.Color = foreColorTemp;


                for (int i = 0; i < dgv.Columns.Count - 1; i++)
                {
                    string valueTemp = dgv.Rows[r].Cells[i].Value.ToString().Replace("=", "-");
                    workSheet.Cells[r + 2, i + 1] = valueTemp;

                }

            }

            workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절


            wb.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);

            
        }

        public void ComboBox_Read_NoBlank(ComboBox sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);

            sCombo.DataSource = adoTable;
        }

        public bool checkBisNo(string bisNo)
        {
            // 넘어온 값의 정수만 추츨하여 문자열의 배열로 만들고 10자리 숫자인지 확인합니다.
            bisNo = bisNo.Replace("-", "");
            if (bisNo == null || bisNo.Length != 10) return false;

            int[] bisIntArray = new int[10];

            for (int i = 0; i < bisNo.Length; i++)
            {
                bisIntArray[i] = int.Parse(bisNo[i].ToString());
            }

            // 합 / 체크키
            int sum = 0;
            int[] key = { 1, 3, 7, 1, 3, 7, 1, 3, 5 };

            // 0 ~ 8 까지 9개의 숫자를 체크키와 곱하여 합에더합니다.
            for (int i = 0; i < 9; i++)
            {
                sum += (key[i] * bisIntArray[i]);
            }

            // 각 8번배열의 값을 곱한 후 10으로 나누고 내림하여 기존 합에 더합니다.
            // 다시 10의 나머지를 구한후 그 값을 10에서 빼면 이것이 검증번호 이며 기존 검증번호와 비교하면됩니다.
            return (10 - ((sum + Math.Floor((double)(key[8] * bisIntArray[8] / 10))) % 10) == bisIntArray[9]);
        }


        public static void dataGridView_ExportToExcel_Excel(string fileName, DataGridView dgv, string vat_cd)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            workSheet.Name = "C#";

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("출력할 데이터가 없습니다");
                return;
            }

            // 맨위 안내글 출력
            if (vat_cd.Equals("1"))
            {
                workSheet.Cells[1, 1] = "엑셀 업로드 양식(전자세금계산서-일반(영세율))";
            }
            else
            {
                workSheet.Cells[1, 1] = "엑셀 업로드 양식(전자세금계산서-면세)";
            }
            workSheet.Cells[2, 1] = "★주황색으로 표시된 부분은 필수입력항목으로 반드시 입력하셔야 합니다. ★아래 '항목설명' 시트를 참고하여 작성하시기 바랍니다.";
            workSheet.Cells[3, 1] = "★실제 업로드할 DATA는 7행부터 입력하여야 합니다. 최대 100건까지 입력이 가능하나, 발급은 최대 10건씩 처리가 됩니다.(100건 초과 자료는 처리 안됨) ★임의로 행을 추가하거나 삭제하는 경우 파일을 제대로 읽지 못하는 경우가 있으므로, 주어진 양식안에 반드시 작성을 하시기 바랍니다.";
            workSheet.Cells[4, 1] = "★전자(세금)계산서 종류는 엑셀 업로드 양식에 따라 해당 전자(세금)계산서 종류코드를 반드시 입력하셔야 합니다. ★품목은 1건이상 입력해야 합니다. ★공급받는자 등록번호는 사업자등록번호, 주민등록번호를 입력할 수 있습니다. 외국인인 경우 '9999999999999'를 입력하시고, 비고란에  외국인등록번호 또는 여권번호를 입력하시기 바랍니다.";

            //디자인
            Microsoft.Office.Interop.Excel.Range range = null; //범위지정 6행부터 106행까지 
            if (vat_cd.Equals("2"))
            {
                range = workSheet.Range[workSheet.Cells[6, 1], workSheet.Cells[106, dgv.ColumnCount - 18]];
            }
            else
            {
                range = workSheet.Range[workSheet.Cells[6, 1], workSheet.Cells[106, dgv.ColumnCount - 13]];
            }
            range.Borders.Color = Color.Black; //Border 색상
            range.Font.Size = 9; //폰트 크기 

            workSheet.Columns[1].ColumnWidth = 8.38; //각 컬럼 Width
            workSheet.Columns[2].ColumnWidth = 7.88;
            workSheet.Columns[3].ColumnWidth = 12.13;
            workSheet.Columns[4].ColumnWidth = 15.50;
            workSheet.Columns[5].ColumnWidth = 8.88;
            workSheet.Columns[6].ColumnWidth = 8.88;
            workSheet.Columns[7].ColumnWidth = 47.50;
            workSheet.Columns[8].ColumnWidth = 8.88;
            workSheet.Columns[9].ColumnWidth = 8.88;
            workSheet.Columns[10].ColumnWidth = 10.50;
            workSheet.Columns[11].ColumnWidth = 15.50;
            workSheet.Columns[12].ColumnWidth = 18.75;
            workSheet.Columns[13].ColumnWidth = 21.13;
            workSheet.Columns[14].ColumnWidth = 12.13;
            workSheet.Columns[15].ColumnWidth = 23.88;
            workSheet.Columns[16].ColumnWidth = 12.13;
            workSheet.Columns[17].ColumnWidth = 12.13;
            workSheet.Columns[18].ColumnWidth = 14.75;
            workSheet.Columns[19].ColumnWidth = 14.75;
            workSheet.Columns[20].ColumnWidth = 8;
            workSheet.Columns[21].ColumnWidth = 8;
            workSheet.Columns[22].ColumnWidth = 3.88;
            workSheet.Columns[23].ColumnWidth = 4.75;
            workSheet.Columns[24].ColumnWidth = 6.13;
            workSheet.Columns[25].ColumnWidth = 4.75;
            workSheet.Columns[26].ColumnWidth = 4.75;
            workSheet.Columns[27].ColumnWidth = 8;
            workSheet.Columns[28].ColumnWidth = 8;
            workSheet.Columns[29].ColumnWidth = 8;
            workSheet.Columns[30].ColumnWidth = 7.75;

            workSheet.Columns[31].ColumnWidth = 4.75;
            workSheet.Columns[32].ColumnWidth = 4.75;
            workSheet.Columns[33].ColumnWidth = 4.75;
            workSheet.Columns[34].ColumnWidth = 4.75;
            workSheet.Columns[35].ColumnWidth = 4.75;
            workSheet.Columns[36].ColumnWidth = 7.75;
            workSheet.Columns[37].ColumnWidth = 4.75;
            workSheet.Columns[38].ColumnWidth = 7.75;

            workSheet.Columns[39].ColumnWidth = 4.75;
            workSheet.Columns[40].ColumnWidth = 4.75;
            workSheet.Columns[41].ColumnWidth = 4.75;
            workSheet.Columns[42].ColumnWidth = 4.75;
            workSheet.Columns[43].ColumnWidth = 4.75;
            workSheet.Columns[44].ColumnWidth = 7.75;
            workSheet.Columns[45].ColumnWidth = 4.75;
            workSheet.Columns[46].ColumnWidth = 7.75;

            workSheet.Columns[47].ColumnWidth = 4.75;
            workSheet.Columns[48].ColumnWidth = 4.75;
            workSheet.Columns[49].ColumnWidth = 4.75;
            workSheet.Columns[50].ColumnWidth = 4.75;
            workSheet.Columns[51].ColumnWidth = 4.75;
            workSheet.Columns[52].ColumnWidth = 7.75;
            workSheet.Columns[53].ColumnWidth = 4.75;
            workSheet.Columns[54].ColumnWidth = 7.75;
            workSheet.Columns[55].ColumnWidth = 3.88;
            workSheet.Columns[56].ColumnWidth = 3.88;
            workSheet.Columns[57].ColumnWidth = 3.88;
            workSheet.Columns[58].ColumnWidth = 8.88;
            workSheet.Columns[59].ColumnWidth = 13.13;

            workSheet.Rows[6].RowHeight = 48; //헤더열 Height 설정



            //헤더찍기 for

            int minusCount = 12;
            for (int i = 13; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].HeaderText.Contains("계산서 종류"))
                {
                    if (vat_cd.Equals("1"))
                    {
                        workSheet.Cells[6, i - minusCount] = dgv.Columns[i].HeaderText + Environment.NewLine + "(01:일반,02:영세율)";
                    }
                    else
                    {
                        workSheet.Cells[6, i - minusCount] = dgv.Columns[i].HeaderText + Environment.NewLine + "(05:면세)";
                    }
                }
                else
                {
                    if (vat_cd.Equals("2") && dgv.Columns[i].HeaderText.Contains("세액"))
                    {
                        minusCount++;
                    }
                    else
                    {
                        workSheet.Cells[6, i - minusCount] = dgv.Columns[i].HeaderText;
                    }
                }
            }

            //내용 출력
            minusCount = 12;
            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                for (int i = 13; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Name.ToString().Equals("계산서종류") || dgv.Columns[i].Name.ToString().Equals("영수청구"))
                    {
                        string valueTemp = "=\"" + dgv.Rows[r].Cells[i].Value.ToString() + "\"";
                        workSheet.Cells[r + 7, i - minusCount] = valueTemp;
                    }
                    else if (dgv.Columns[i].Name.ToString().Equals("일자1"))
                    {
                        string valueTemp = "=\"" + dgv.Rows[r].Cells[i].Value.ToString() + "\"";
                        workSheet.Cells[r + 7, i - minusCount] = valueTemp;
                    }
                    else
                    {
                        if (vat_cd.Equals("2") && dgv.Columns[i].Name.ToString().Contains("세액"))
                        {
                            minusCount++;
                        }
                        else
                        {
                            string valueTemp = dgv.Rows[r].Cells[i].Value.ToString().Replace("=", "-");
                            workSheet.Cells[r + 7, i - minusCount] = valueTemp;
                        }
                    }

                }
            }





            //workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절

            wb.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
            System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false,
            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, false, false, System.Reflection.Missing.Value,
            System.Reflection.Missing.Value, System.Reflection.Missing.Value);



            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);


        }


        #region 메모리해제
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        public void GridComboBox_Read_Blank(DataGridViewComboBoxColumn sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);
            adoRow = adoTable.NewRow();
            adoRow[0] = "";
            adoRow[1] = "";
            adoTable.Rows.InsertAt(adoRow, 0);

            sCombo.DataSource = adoTable;
        }

        public void ComboBox_Read_ALL(ComboBox sCombo, string sQuery)
        {
            if (sQuery.Trim().Length > 10)
            {
                strQuery = sQuery.Trim();
            }
            adoTable = RunTable(strQuery);
            adoRow = adoTable.NewRow();
            adoRow[0] = "";
            adoRow[1] = "(전체)";
            adoTable.Rows.InsertAt(adoRow, 0);

            sCombo.DataSource = adoTable;
        }

        public static void dataGridView_ExportToExcel_Pay(string fileName, DataGridView grd_pay)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            workSheet.Name = "C#";

            if (grd_pay.Rows.Count == 0)
            {
                MessageBox.Show("출력할 데이터가 없습니다");
                return;
            }

            // 헤더 출력
            for (int i = 0; i < grd_pay.Columns.Count; i++)
            {
                workSheet.Cells[1, i + 1] = grd_pay.Columns[i].HeaderText;
            }

            for (int r = 0; r < grd_pay.Rows.Count; r++)
            {
                for (int i = 0; i < grd_pay.Columns.Count; i++)
                {
                    if (grd_pay.Rows[r].Cells[i].Value == null) grd_pay.Rows[r].Cells[i].Value = "";
                    string valueTemp = grd_pay.Rows[r].Cells[i].Value.ToString().Replace("=", "-");
                    workSheet.Cells[r + 2, i + 1] = valueTemp;
                }
            }

            workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절


            wb.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);

        }

        public static void dataGridView_ExportToExcel_Poor_Anal(
            string fileName
            , string start_date
            , string end_date
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_raw
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_raw_date
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_flow
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_flow_date
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_item
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_item_date
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_raw_detail
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_flow_detail
            , System.Windows.Forms.DataVisualization.Charting.Chart chart_item_detail
            , DataGridView raw_grid
            , DataGridView flow_grid
            , DataGridView item_grid
            , FlowLayoutPanel rawWhite
            , FlowLayoutPanel rawBlack
            , FlowLayoutPanel flowWhite
            , FlowLayoutPanel flowBlack
            , FlowLayoutPanel itemWhite
            , FlowLayoutPanel itemBlack
            )
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel._Worksheet workSheet4 = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            wb.Worksheets.Add();
            Microsoft.Office.Interop.Excel._Worksheet workSheet3 = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            wb.Worksheets.Add();
            Microsoft.Office.Interop.Excel._Worksheet workSheet2 = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            wb.Worksheets.Add();
            Microsoft.Office.Interop.Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            workSheet4.Name = "제품";
            workSheet3.Name = "공정";
            workSheet2.Name = "자재";
            workSheet.Name = "전체";


            workSheet4.Cells[1, 1] = start_date +" ~ "+end_date+ "제품 품질분석 현황";
            workSheet3.Cells[1, 1] = start_date + " ~ " + end_date + "공정 품질분석 현황";
            workSheet2.Cells[1, 1] = start_date + " ~ " + end_date + "자재 품질분석 현황";
            workSheet.Cells[1, 1] = start_date + " ~ " + end_date + "품질분석 현황";

            int startRow = 5;
            int startCol = 1;
            int MaxPorintCount = 0;

            workSheet.Cells[3, 1] = "<원자재> 자재별 품질분석";
            workSheet.Cells[4, 1] = "자재명";
            workSheet.Cells[4, 2] = "입고량";
            workSheet.Cells[4, 3] = "불량건수";

            System.Windows.Forms.DataVisualization.Charting.Series SeriesTemp = null;
            System.Windows.Forms.DataVisualization.Charting.Series SeriesTemp2 = null;
            
            if (chart_raw.Series[0].Points.Count > 0)
            {
                if (chart_raw.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_raw.Series[1];
                    SeriesTemp2 = chart_raw.Series[0];
                }
                else
                {
                    SeriesTemp = chart_raw.Series[0];
                    SeriesTemp2 = chart_raw.Series[1];
                }
                for (int i = 0; i < chart_raw.Series[0].Points.Count; i++)
                {
                    workSheet.Cells[startRow + i, startCol] = SeriesTemp.Points[i].AxisLabel;
                    workSheet.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }

            }

            if (chart_raw.Series[0].Points.Count > MaxPorintCount)
            {
                MaxPorintCount = chart_raw.Series[0].Points.Count;
            }

            workSheet.Cells[3, 5] = "<공정> 공정별 품질분석";
            workSheet.Cells[4, 5] = "공정명";
            workSheet.Cells[4, 6] = "진행량";
            workSheet.Cells[4, 7] = "불량건수";
            startCol = 5;

            if (chart_flow.Series[0].Points.Count > 0)
            {
                if (chart_flow.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_flow.Series[1];
                    SeriesTemp2 = chart_flow.Series[0];
                }
                else
                {
                    SeriesTemp = chart_flow.Series[0];
                    SeriesTemp2 = chart_flow.Series[1];
                }

                for (int i = 0; i < chart_flow.Series[0].Points.Count; i++)
                {
                    workSheet.Cells[startRow + i, startCol] = SeriesTemp.Points[i].AxisLabel;
                    workSheet.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }

            if (chart_flow.Series[0].Points.Count > MaxPorintCount)
            {
                MaxPorintCount = chart_flow.Series[0].Points.Count;
            }
            workSheet.Cells[3, 9] = "<제품> 제품별 품질분석";
            workSheet.Cells[4, 9] = "제품명";
            workSheet.Cells[4, 10] = "생산량";
            workSheet.Cells[4, 11] = "불량건수";
            startCol = 9;


            if (chart_item.Series[0].Points.Count > 0)
            {
                if (chart_item.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_item.Series[1];
                    SeriesTemp2 = chart_item.Series[0];
                }
                else
                {
                    SeriesTemp = chart_item.Series[0];
                    SeriesTemp2 = chart_item.Series[1];
                }

                for (int i = 0; i < chart_item.Series[0].Points.Count; i++)
                {
                    workSheet.Cells[startRow + i, startCol] = SeriesTemp.Points[i].AxisLabel;
                    workSheet.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }
            if (chart_item.Series[0].Points.Count > MaxPorintCount)
            {
                MaxPorintCount = chart_item.Series[0].Points.Count;
            }


            startRow = MaxPorintCount + 8;
            startCol = 1;

            workSheet.Cells[MaxPorintCount+6, 1] = "<원자재> 기간별 품질분석";
            workSheet.Cells[MaxPorintCount + 7, 1] = "기간";
            workSheet.Cells[MaxPorintCount + 7, 2] = "입고량";
            workSheet.Cells[MaxPorintCount + 7, 3] = "불량건수";

            if (chart_raw_date.Series[0].Points.Count > 0)
            {
                if (chart_raw_date.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_raw_date.Series[1];
                    SeriesTemp2 = chart_raw_date.Series[0];
                }
                else
                {
                    SeriesTemp = chart_raw_date.Series[0];
                    SeriesTemp2 = chart_raw_date.Series[1];
                }

                for (int i = 0; i < chart_raw_date.Series[0].Points.Count; i++)
                {
                    workSheet.Cells[startRow + i, startCol] = "'" + SeriesTemp.Points[i].AxisLabel;
                    workSheet.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }

            startCol = 5;

            workSheet.Cells[MaxPorintCount + 6, 5] = "<공정> 기간별 품질분석";
            workSheet.Cells[MaxPorintCount + 7, 5] = "기간";
            workSheet.Cells[MaxPorintCount + 7, 6] = "진행량";
            workSheet.Cells[MaxPorintCount + 7, 7] = "불량건수";

            if (chart_flow_date.Series[0].Points.Count > 0)
            {
                if (chart_flow_date.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_flow_date.Series[1];
                    SeriesTemp2 = chart_flow_date.Series[0];
                }
                else
                {
                    SeriesTemp = chart_flow_date.Series[0];
                    SeriesTemp2 = chart_flow_date.Series[1];
                }

                for (int i = 0; i < chart_flow_date.Series[0].Points.Count; i++)
                {
                    workSheet.Cells[startRow + i, startCol] = "'" + SeriesTemp.Points[i].AxisLabel;
                    workSheet.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }
            startCol = 9;

            workSheet.Cells[MaxPorintCount + 6, 9] = "<제품> 기간별 품질분석";
            workSheet.Cells[MaxPorintCount + 7, 9] = "기간";
            workSheet.Cells[MaxPorintCount + 7, 10] = "생산량";
            workSheet.Cells[MaxPorintCount + 7, 11] = "불량건수";
            if (chart_item_date.Series[0].Points.Count > 0)
            {
                if (chart_item_date.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_item_date.Series[1];
                    SeriesTemp2 = chart_item_date.Series[0];
                }
                else
                {
                    SeriesTemp = chart_item_date.Series[0];
                    SeriesTemp2 = chart_item_date.Series[1];
                }
                for (int i = 0; i < chart_item_date.Series[0].Points.Count; i++)
                {
                    workSheet.Cells[startRow + i, startCol] = "'" + SeriesTemp.Points[i].AxisLabel;
                    workSheet.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }


            if(rawWhite.Controls.Count > 1)
            {
                workSheet2.Cells[3, 1] = "<자재 포함>";
                for (int i = 0; i < rawWhite.Controls.Count; i++)
                {
                    workSheet2.Cells[4, i + 1] = rawWhite.Controls[i].Controls[0].Text;
                }
            }
            else if(rawBlack.Controls.Count > 1)
            {
                workSheet2.Cells[3, 1] = "<자재 제외>";
                for (int i = 0; i < rawBlack.Controls.Count; i++)
                {
                    workSheet2.Cells[4, i + 1] = rawBlack.Controls[i].Controls[0].Text;
                }
            }

            workSheet2.Cells[6, 1] = "<원자재> 기간별 품질분석";
            workSheet2.Cells[7, 1] = "기간";
            workSheet2.Cells[7, 2] = "입고량";
            workSheet2.Cells[7, 3] = "불량건수";

            startRow = 8;
            startCol = 1;

            if (chart_raw_detail.Series[0].Points.Count > 0)
            {
                if (chart_raw_detail.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_raw_detail.Series[1];
                    SeriesTemp2 = chart_raw_detail.Series[0];
                }
                else
                {
                    SeriesTemp = chart_raw_detail.Series[0];
                    SeriesTemp2 = chart_raw_detail.Series[1];
                }
                for (int i = 0; i < chart_raw_detail.Series[0].Points.Count; i++)
                {
                    workSheet2.Cells[startRow + i, startCol] = "'" + SeriesTemp.Points[i].AxisLabel;
                    workSheet2.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet2.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }

            workSheet2.Cells[6, 5] = "<원자재> 기간별 상세내역";
            for (int i = 0; i < raw_grid.ColumnCount; i++)
            {
                workSheet2.Cells[7, 5 + i] = raw_grid.Columns[i].HeaderText; 
            }
            
            startRow = 8;
            startCol = 5;

            
            for (int i = 0; i < raw_grid.ColumnCount; i++)
            {
                for (int j = 0; j < raw_grid.RowCount; j++)
                {
                    workSheet2.Cells[startRow + j, startCol + i] = raw_grid.Rows[j].Cells[i].Value;
                }
            }


            //공정

            if (flowWhite.Controls.Count > 1)
            {
                workSheet3.Cells[3, 1] = "<공정 포함>";
                for (int i = 0; i < flowWhite.Controls.Count; i++)
                {
                    workSheet3.Cells[4, i + 1] = flowWhite.Controls[i].Controls[0].Text;
                }
            }
            else if (flowBlack.Controls.Count > 1)
            {
                workSheet3.Cells[3, 1] = "<공정 제외>";
                for (int i = 0; i < flowBlack.Controls.Count; i++)
                {
                    workSheet3.Cells[4, i + 1] = flowBlack.Controls[i].Controls[0].Text;
                }
            }

            workSheet3.Cells[6, 1] = "<공정> 기간별 품질분석";
            workSheet3.Cells[7, 1] = "기간";
            workSheet3.Cells[7, 2] = "진행량";
            workSheet3.Cells[7, 3] = "불량건수";

            startRow = 8;
            startCol = 1;

            if (chart_flow_detail.Series[0].Points.Count > 0)
            {
                if (chart_flow_detail.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_flow_detail.Series[1];
                    SeriesTemp2 = chart_flow_detail.Series[0];
                }
                else
                {
                    SeriesTemp = chart_flow_detail.Series[0];
                    SeriesTemp2 = chart_flow_detail.Series[1];
                }
                for (int i = 0; i < chart_flow_detail.Series[0].Points.Count; i++)
                {
                    workSheet3.Cells[startRow + i, startCol] = "'" + SeriesTemp.Points[i].AxisLabel;
                    workSheet3.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet3.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }

            workSheet3.Cells[6, 5] = "<공정> 기간별 상세내역";
            for (int i = 0; i < flow_grid.ColumnCount; i++)
            {
                workSheet3.Cells[7, 5 + i] = flow_grid.Columns[i].HeaderText;
            }

            startRow = 8;
            startCol = 5;


            for (int i = 0; i < flow_grid.ColumnCount; i++)
            {
                for (int j = 0; j < flow_grid.RowCount; j++)
                {
                    workSheet3.Cells[startRow + j, startCol + i] = flow_grid.Rows[j].Cells[i].Value;
                }
            }


            //제품

            if (itemWhite.Controls.Count > 1)
            {
                workSheet4.Cells[3, 1] = "<제품 포함>";
                for (int i = 0; i < itemWhite.Controls.Count; i++)
                {
                    workSheet4.Cells[4, i + 1] = itemWhite.Controls[i].Controls[0].Text;
                }
            }
            else if (itemBlack.Controls.Count > 1)
            {
                workSheet4.Cells[3, 1] = "<제품 제외>";
                for (int i = 0; i < itemBlack.Controls.Count; i++)
                {
                    workSheet4.Cells[4, i + 1] = itemBlack.Controls[i].Controls[0].Text;
                }
            }

            workSheet4.Cells[6, 1] = "<제품> 기간별 품질분석";
            workSheet4.Cells[7, 1] = "기간";
            workSheet4.Cells[7, 2] = "생산량";
            workSheet4.Cells[7, 3] = "불량건수";

            startRow = 8;
            startCol = 1;

            if (chart_item_detail.Series[0].Points.Count > 0)
            {
                if (chart_item_detail.Series[0].Points[0].AxisLabel.ToString().Equals(""))
                {
                    SeriesTemp = chart_item_detail.Series[1];
                    SeriesTemp2 = chart_item_detail.Series[0];
                }
                else
                {
                    SeriesTemp = chart_item_detail.Series[0];
                    SeriesTemp2 = chart_item_detail.Series[1];
                }
                for (int i = 0; i < chart_item_detail.Series[0].Points.Count; i++)
                {
                    workSheet4.Cells[startRow + i, startCol] = "'" + SeriesTemp.Points[i].AxisLabel;
                    workSheet4.Cells[startRow + i, startCol + 1] = SeriesTemp.Points[i].Label;
                    workSheet4.Cells[startRow + i, startCol + 2] = SeriesTemp2.Points[i].Label;
                }
            }

            workSheet4.Cells[6, 5] = "<제품> 기간별 상세내역";
            for (int i = 0; i < item_grid.ColumnCount; i++)
            {
                workSheet4.Cells[7, 5 + i] = item_grid.Columns[i].HeaderText;
            }

            startRow = 8;
            startCol = 5;


            for (int i = 0; i < item_grid.ColumnCount; i++)
            {
                for (int j = 0; j < item_grid.RowCount; j++)
                {
                    workSheet4.Cells[startRow + j, startCol + i] = item_grid.Rows[j].Cells[i].Value;
                }
            }



            workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절
            workSheet2.Columns.AutoFit();
            workSheet3.Columns.AutoFit();
            workSheet4.Columns.AutoFit();
            //workSheet.Cells.Borders.Color = Color.Black;

            wb.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);
        }

        public static string Request_Json(string url)
        {
            string result = null;
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);  
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                 //URF8인코딩을 한 상태로 Json을 읽어온다.
                result = reader.ReadToEnd();
                stream.Close();
                response.Close();
                result = @result.Replace("\r\n", "").Replace("\\", "").Replace(" ", ""); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLC 데이터 다운로드 중 오류발생");
            }
            return result; 
        }

        public static void dataGridView_ExportToExcel_Temp(string fileName, DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            workSheet.Name = "C#";

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("출력할 데이터가 없습니다");
                return;
            }

            // 헤더 출력
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                workSheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }


            //내용 출력
            Color backColorTemp = Color.White;
            Color foreColorTemp = Color.Black;
            Microsoft.Office.Interop.Excel.Range range = null;
            string[] ABC = new string[25];
            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                ABC[i] = ((char)(i + 65)).ToString();
                Console.WriteLine(ABC[i]);
            }


            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    string valueTemp = dgv.Rows[r].Cells[i].Value.ToString().Replace("=", "-");
                    workSheet.Cells[r + 2, i + 1] = valueTemp;
                }
            }

            workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절


            wb.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);
        }

        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }

        public static void insert_banner_with_WaterMark(Image image)
        {
            string fileName = "banner.jpg";
            string waterMarkName = "WaterMark.png";
            string targetPath = AppDomain.CurrentDomain.BaseDirectory + "SaupLogos\\";
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            Image bmpTemp = ChangeOpacity(image, float.Parse("0.05"));

            if (System.IO.Directory.Exists(targetPath))
            {
                if (System.IO.File.Exists(targetPath + "/" + fileName))
                {
                    System.IO.File.Delete(destFile);
                    System.IO.File.Delete(targetPath + "/" + waterMarkName);
                    insert_banner_with_WaterMark(image);
                }
                else
                {
                    try
                    {
                        image.Save(targetPath + "/" + fileName);
                        if (System.IO.File.Exists(targetPath + "/" + fileName))
                        {
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("입출력 오류 디렉터리 권한을 확인해주세요.");
                        return;
                    }
                }

                if (System.IO.File.Exists(targetPath + "/" + waterMarkName))
                {
                    System.IO.File.Delete(destFile);
                    System.IO.File.Delete(targetPath + "/" + waterMarkName);
                    insert_banner_with_WaterMark(image);
                }
                else
                {
                    try
                    {
                        bmpTemp.Save(targetPath + "/" + waterMarkName, ImageFormat.Png);
                        if (System.IO.File.Exists(targetPath + "/" + fileName))
                        {
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("입출력 오류 디렉터리 권한을 확인해주세요.");
                        return;
                    }
                }
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(targetPath);
                di.Create();
                insert_banner_with_WaterMark(image);
            }
        }

        public static void insert_Logos(Image image, string fileName)
        {
            string targetPath = AppDomain.CurrentDomain.BaseDirectory + "SaupLogos\\";
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (System.IO.Directory.Exists(targetPath))
            {
                if (System.IO.File.Exists(targetPath + "/" + fileName))
                {
                    System.IO.File.Delete(destFile);
                    insert_Logos(image, fileName);
                }
                else
                {
                    try
                    {
                        image.Save(targetPath + "/" + fileName);
                        if (System.IO.File.Exists(targetPath + "/" + fileName))
                        {
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("입출력 오류 디렉터리 권한을 확인해주세요.");
                        return;
                    }
                }
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(targetPath);
                di.Create();
                insert_Logos(image, fileName);
            }
        }

    }
}
