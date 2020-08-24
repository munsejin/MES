using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;

namespace MES.H20_생산관리
{
    public partial class frm원자재이력관리 : Form
    {
        wnDm wnDm = new wnDm();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한
        public string sRetCode = "";
        public string sRetNM = "";
        public frm원자재이력관리()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm원자재이력관리_Load(object sender, EventArgs e)
        {
            addButton(txt_원자재검색,0);
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            if (Common.p_strUserAdmin != "5")
            {
                DataTable dtcheck = wnDm.fn_auth_check(lbl_title.Tag.ToString().Split('$')[0], lbl_title.Tag.ToString().Split('$')[1]);
                p_IsAuth = dtcheck.Rows[0]["auth_yn"].ToString() == "Y" ? true : false;
                p_Isrgstr = dtcheck.Rows[0]["rgstr_yn"].ToString() == "Y" ? true : false;
                p_Isdel = dtcheck.Rows[0]["del_yn"].ToString() == "Y" ? true : false;
                try
                {
                    if (!p_IsAuth)
                    {
                        this.BeginInvoke(new MethodInvoker(Close));
                        /// MessageBox.Show("권한이없습니다.");
                    }

                }
                catch (Exception ex)
                {
                }
            }


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Button[] Txtbtn = new Button[1];

        public void addButton(conTextBox TextBox, int type)
        {
            Txtbtn[type] = new Button();
            TextBox.Controls.Add(Txtbtn[type]);
            Txtbtn[type].FlatStyle = FlatStyle.Flat;
            Txtbtn[type].FlatAppearance.BorderSize = 0;
            Txtbtn[type].FlatAppearance.MouseDownBackColor = Color.Transparent;
            Txtbtn[type].SetBounds(TextBox.Size.Width - 19, 1, 18, TextBox.Size.Height - 2);
            Txtbtn[type].Text = "▼";
            Txtbtn[type].TabStop = false;
            Txtbtn[type].Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 4, FontStyle.Bold);

            switch (type)
            {
                case 0:
                    Txtbtn[type].Click += new EventHandler(btnRowSrch_Click);

                    break;
                

                default:
                    break;
            }
            Txtbtn[type].Show();
        }

        private void btnRowSrch_Click(object sender, EventArgs e)
        {
            Popup.pop원자재검색 pop원자재검색 = new Popup.pop원자재검색();
            pop원자재검색.ShowDialog();
             sRetCode = pop원자재검색.sRetCode;
             sRetNM = pop원자재검색.sRetNM;
             txt_원자재검색.Text = sRetNM;
             txt_원자재검색.Tag = sRetCode;
        }

        private void txt_원자재검색_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Txtbtn[0].PerformClick();
            }
        }

        private void bind원자재이력(string condition)
        {
            itemGrid.Rows.Clear();

            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.화인원자재이력관리_list(condition);

            if (dt != null && dt.Rows.Count > 0)
            {
                itemGrid.RowCount = dt.Rows.Count;

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        itemGrid.Rows[i].Cells["RAW_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                        itemGrid.Rows[i].Cells["RAW_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        itemGrid.Rows[i].Cells["매출처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        itemGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        itemGrid.Rows[i].Cells["ORD_DATE"].Value = dt.Rows[i]["주문일자"].ToString();
                        itemGrid.Rows[i].Cells["ORD_NUM"].Value = dt.Rows[i]["주문번호"].ToString();
                        itemGrid.Rows[i].Cells["ORD_QTY"].Value = dt.Rows[i]["주문수량"].ToString();
                        //itemGrid.Rows[i].Cells["ORD_PRICE"].Value = dt.Rows[i]["주문단가"].ToString();
                        //itemGrid.Rows[i].Cells["ORD_AMT"].Value = dt.Rows[i]["주문금액"].ToString();
                        itemGrid.Rows[i].Cells["DELIVERY_QTY"].Value = dt.Rows[i]["배송수량"].ToString();
                        itemGrid.Rows[i].Cells["SALE_DATE"].Value = dt.Rows[i]["매출일자"].ToString();
                        itemGrid.Rows[i].Cells["SALE_NUM"].Value = dt.Rows[i]["매출번호"].ToString();
                        itemGrid.Rows[i].Cells["SALE_QTY"].Value = dt.Rows[i]["매출수량"].ToString();
                        //itemGrid.Rows[i].Cells["SALE_PRICE"].Value = dt.Rows[i]["매출단가"].ToString();
                        //itemGrid.Rows[i].Cells["SALE_AMT"].Value = dt.Rows[i]["매출금액"].ToString();
                        itemGrid.Rows[i].Cells["RETURN_DATE"].Value = dt.Rows[i]["반품일자"].ToString();
                        itemGrid.Rows[i].Cells["RETURN_NUM"].Value = dt.Rows[i]["반품번호"].ToString();
                        itemGrid.Rows[i].Cells["RETURN_QTY"].Value = dt.Rows[i]["반품수량"].ToString();
                        //itemGrid.Rows[i].Cells["RETURN_PRICE"].Value = dt.Rows[i]["반품단가"].ToString();
                        //itemGrid.Rows[i].Cells["RETURN_AMT"].Value = dt.Rows[i]["반품금액"].ToString();
                        itemGrid.Rows[i].Cells["완료일자"].Value = dt.Rows[i]["완료일자"].ToString();
                        itemGrid.Rows[i].Cells["완료사원"].Value = dt.Rows[i]["완료사원"].ToString();
                        itemGrid.Rows[i].Cells["회수일자"].Value = dt.Rows[i]["회수일자"].ToString();
                        itemGrid.Rows[i].Cells["주문사원"].Value = dt.Rows[i]["주문사원"].ToString();
                        itemGrid.Rows[i].Cells["배송사원"].Value = dt.Rows[i]["배송사원"].ToString();
                        itemGrid.Rows[i].Cells["매출담당사원"].Value = dt.Rows[i]["매출사원"].ToString();
                        itemGrid.Rows[i].Cells["반품담당사원"].Value = dt.Rows[i]["반품사원"].ToString();

                    }
                }
            }
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {

            
            String condition = " AND ZZ.RAW_MAT_CD = '" + txt_원자재검색.Tag + "' ";

            if (txt_원자재검색.Tag=="")
            {
                condition = "";
            }
            if (txt_원자재검색.Text == "")
            {
                condition = "";
            }
            condition += "and A.ORD_DATE>='" + dtp스타트.Value.ToString().Substring(0, 10) + "' and A.ORD_DATE<='" + dtp엔드.Value.ToString().Substring(0, 10) + "'";
            bind원자재이력(condition);

               
        }

    }
}
