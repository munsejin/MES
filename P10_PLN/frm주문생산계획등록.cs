using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MES.CLS;

namespace MES.P10_PLN
{
    public partial class frm주문생산계획등록 : Form
    {

        interfaceJumunPlan ifjp;
        JumunPlanDTO jpDTO;
        BindingSource bs1;
        BindingSource bs2;

        public StringBuilder sbTemp = new StringBuilder();

        public frm주문생산계획등록()
        {
            InitializeComponent();
            
            ifjp = new JumunPlanDAO();
            bs1 = new BindingSource();
            bs2 = new BindingSource();
            this.grd_plan_list.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            

        }

        private void jumunDataList()
        {
            
        }

        private void frm주문생산계획등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            jpDTO = ifjp.formLoad();
            jumunBinding();
        }

        private void jumunBinding()
        {

            bs1.DataSource = jpDTO.Jumundt;
            grd_jumun.DataSource = bs1;


        }
        private void planBinding()
        {
            bs2.DataSource = jpDTO.Plandt;
            grd_plan_list.DataSource = bs2;
        }



        private DataTable setDataTable(DataGridView dgv)
        {

            DataTable dt = new DataTable(); // 담을 객체

            for (int i = 0; i < dgv.Columns.Count; i++)
            {

                dt.Columns.Add(dgv.Columns[i].Name);

            }//컬럼 생성


            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                DataRow dr = dt.NewRow();

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = dgv.Rows[i].Cells[j].Value;
                }
                dt.Rows.Add(dr);

            } //데이터 삽입

            return dt;
        }


        private void btn_rs_srch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = setDataTable(grd_jumun);
                jpDTO.Jumundt = dt;

                string cust_cd_temp = "";
                int planF = 0;
                for (int i = 0; i < grd_jumun.Rows.Count; i++)
                {
                    if (grd_jumun.Rows[i].Cells["CHK"].Value.ToString().Equals("true"))
                    {
                        if (cust_cd_temp.Equals(""))
                        {
                            cust_cd_temp = grd_jumun.Rows[i].Cells["CUST_CD"].Value.ToString();
                        }
                        else if (!grd_jumun.Rows[i].Cells["CUST_CD"].Value.ToString().Equals(cust_cd_temp))
                        {
                            planF = 1;
                            break;
                        }
                    }
                }
                wnDm wDm = new wnDm();
                StringBuilder sb1 = new StringBuilder();
                DataTable dt2 = null;

                int cnt = 0;
                for (int i = 0; i < grd_jumun.Rows.Count; i++)
                {
                    if (grd_jumun.Rows[i].Cells["CHK"].Value.ToString() == "true")
                    {
                        if (cnt < 1)
                        {
                            cnt++;
                            sbTemp.AppendLine("(JUMUN_DATE = '" + grd_jumun.Rows[i].Cells["JUMUN_DATE"].Value.ToString() + "' and  JUMUN_CD = '" + grd_jumun.Rows[i].Cells["JUMUN_CD"].Value.ToString() + "')");
                        }
                        else
                            sbTemp.AppendLine("or(JUMUN_DATE = '" + grd_jumun.Rows[i].Cells["JUMUN_DATE"].Value.ToString() + "' and  JUMUN_CD = '" + grd_jumun.Rows[i].Cells["JUMUN_CD"].Value.ToString() + "')");
                    }
                }
                sbTemp.AppendLine(")");



                if(planF == 1)
                {
                    cnt = 0;
                    for (int i = 0; i < grd_jumun.Rows.Count; i++)
                    {
                        if (grd_jumun.Rows[i].Cells["CHK"].Value.ToString() == "true")
                        {
                            if (cnt < 1)
                            {
                                cnt++;
                                sb1.AppendLine("(JUMUN_DATE = '" + grd_jumun.Rows[i].Cells["JUMUN_DATE"].Value.ToString() + "' and  JUMUN_CD = '" + grd_jumun.Rows[i].Cells["JUMUN_CD"].Value.ToString() + "')");
                            }
                            else
                                sb1.AppendLine("or(JUMUN_DATE = '" + grd_jumun.Rows[i].Cells["JUMUN_DATE"].Value.ToString() + "' and  JUMUN_CD = '" + grd_jumun.Rows[i].Cells["JUMUN_CD"].Value.ToString() + "')");
                        }
                    }
                    sb1.AppendLine(")");
                    dt2 = wDm.select_jumun_groupby_item(sb1.ToString());
                }else{
                    cnt = 0;
                    for (int i = 0; i < grd_jumun.Rows.Count; i++)
                    {
                        if (grd_jumun.Rows[i].Cells["CHK"].Value.ToString() == "true")
                        {
                            if (cnt < 1)
                            {
                                cnt++;
                                sb1.AppendLine("(A.JUMUN_DATE = '" + grd_jumun.Rows[i].Cells["JUMUN_DATE"].Value.ToString() + "' and  A.JUMUN_CD = '" + grd_jumun.Rows[i].Cells["JUMUN_CD"].Value.ToString() + "')");
                            }
                            else
                                sb1.AppendLine("or(A.JUMUN_DATE = '" + grd_jumun.Rows[i].Cells["JUMUN_DATE"].Value.ToString() + "' and  A.JUMUN_CD = '" + grd_jumun.Rows[i].Cells["JUMUN_CD"].Value.ToString() + "')");
                        }
                    }
                    sb1.AppendLine(")");
                    dt2 = wDm.select_jumun_groupby_cust(sb1.ToString());
                }

                grd_plan_list.Rows.Clear();
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    grd_plan_list.RowCount = dt2.Rows.Count;
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        grd_plan_list.Rows[i].Cells["col_chk"].Value = false;
                        grd_plan_list.Rows[i].Cells["P_NUMBER"].Value = i+1;
                        grd_plan_list.Rows[i].Cells["PLAN_ITEM_NM"].Value = dt2.Rows[i]["ITEM_NM"].ToString();
                        grd_plan_list.Rows[i].Cells["PLAN_ITEM_CD"].Value = dt2.Rows[i]["ITEM_CD"].ToString();
                        grd_plan_list.Rows[i].Cells["SPEC"].Value = dt2.Rows[i]["SPEC"].ToString();
                        grd_plan_list.Rows[i].Cells["UNIT_CD"].Value = dt2.Rows[i]["UNIT_CD"].ToString();
                        grd_plan_list.Rows[i].Cells["UNIT_NM"].Value = dt2.Rows[i]["UNIT_NM"].ToString();
                        grd_plan_list.Rows[i].Cells["UNIT_NM"].Value = dt2.Rows[i]["UNIT_NM"].ToString();
                        grd_plan_list.Rows[i].Cells["TOTAL_AMT"].Value = dt2.Rows[i]["RS_AMT"].ToString();
                        grd_plan_list.Rows[i].Cells["BAL_STOCK"].Value = dt2.Rows[i]["BAL_STOCK"].ToString();
                        grd_plan_list.Rows[i].Cells["RS_AMT"].Value = dt2.Rows[i]["RS_AMT"].ToString();
                        grd_plan_list.Rows[i].Cells["PRICE"].Value = dt2.Rows[i]["PRICE"].ToString();
                        grd_plan_list.Rows[i].Cells["TOTAL_MONEY"].Value = dt2.Rows[i]["TOTAL_MONEY"].ToString();
                        grd_plan_list.Rows[i].Cells["PUR_CUST_CD"].Value = dt2.Rows[i]["CUST_CD"].ToString();
                    }
                }

                
                
                
            }
            catch (Exception ex)    
            {
                MessageBox.Show(ex.Message);
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            jpDTO = null;
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = setDataTable(grd_plan_list);
                jpDTO.Plandt = dt;
                jpDTO = ifjp.save(jpDTO, sbTemp);
                if (jpDTO.Succer == 0)
                {
                    MessageBox.Show("성공적으로 등록하였습니다.");
                    jumunBinding();
                    planBinding();

                }
                else
                    MessageBox.Show("저장에 실패하였습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }





        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                

                DataGridView grd = (DataGridView)sender;
                DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];
                cell.Style.BackColor = Color.White;
                if (e.ColumnIndex > 11)
                {
                    decimal total_amt = decimal.Parse(grd.Rows[e.RowIndex].Cells["RS_AMT"].Value.ToString().Replace(",", ""));
                    decimal price = decimal.Parse(grd.Rows[e.RowIndex].Cells["PRICE"].Value.ToString().Replace(",", ""));
                    decimal total_money = decimal.Parse(grd.Rows[e.RowIndex].Cells["TOTAL_MONEY"].Value.ToString().Replace(",", ""));
                    int cnt = e.ColumnIndex;


                    if (11 < e.ColumnIndex && e.ColumnIndex > 14)
                    {

                        grd.Rows[e.RowIndex].Cells["TOTAL_MONEY"].Value = ifjp.totalMoney(total_amt, price);
                    }
                    else if ( e.ColumnIndex == 14)
                    {
                        grd.Rows[e.RowIndex].Cells["PRICE"].Value = ifjp.price(total_amt, total_money);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }

        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            jpDTO = ifjp.formLoad();
            jumunBinding();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.W:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        this.Close();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        btnSave.PerformClick();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    jumunBinding();
                    planBinding();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void grd_plan_list_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);
        }

        private void grd_jumun_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);
        }

    }
}
 