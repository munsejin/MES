using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES.CLS;

namespace MES.P85_BAS
{
    class itemControl
    {

        private void item_logic()
        {
            try
            {
                if (cmb_type.SelectedValue == null) cmb_type.SelectedValue = "";
                if (cmb_line.SelectedValue == null) cmb_line.SelectedValue = "";
                if (cmb_unit.SelectedValue == null) cmb_unit.SelectedValue = "";
                if (cmb_line.SelectedValue == null) cmb_line.SelectedValue = "";
                if (cmb_cust.SelectedValue == null) cmb_cust.SelectedValue = "";
                if (cmb_used.SelectedValue == null) cmb_used.SelectedValue = "";
                if (cmb_item_gbn.SelectedValue == null) cmb_item_gbn.SelectedValue = "";

                if (txt_item_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("제품코드를 입력하시기 바랍니다.");
                    return;
                }
                if (txt_item_nm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("제품명을 입력하시기 바랍니다.");
                    return;
                }
                if (cmb_unit.SelectedIndex == 0 || cmb_unit == null)
                {
                    MessageBox.Show("단위코드를 선택하시기 바랍니다.");
                    return;
                }
                if (cmb_cust.SelectedIndex == 0 || cmb_cust == null)
                {
                    MessageBox.Show("거래처명을 선택하시기 바랍니다.");
                    return;
                }
                if (cmb_item_gbn.SelectedIndex == 0 || cmb_item_gbn == null)
                {
                    MessageBox.Show("제품구분을 선택하시기 바랍니다.");
                    return;
                }
                if (cmb_vat_cd.SelectedIndex == -1 || cmb_vat_cd == null)
                {
                    MessageBox.Show("과세구분을 선택하시기 바랍니다.");
                    return;
                }

                if (itemRawGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemRawGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_raw_mat_cd = (string)itemRawGrid.Rows[i - cnt].Cells["RAW_MAT_CD"].Value;

                        if (txt_raw_mat_cd == "" || txt_raw_mat_cd == null)  //마지막 행에 원부재료코드가 없을 경우 제거
                        {
                            itemRawGrid.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }
                }

                if (itemFlowGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemFlowGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_flow_cd = (string)itemFlowGrid.Rows[i - cnt].Cells["FLOW_CD"].Value;

                        if (txt_flow_cd == "" || txt_flow_cd == null)  //마지막 행에 원부재료코드가 없을 경우 제거
                        {
                            itemFlowGrid.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }
                }

                if (itemHalfGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemHalfGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_half_item_cd = (string)itemHalfGrid.Rows[i - cnt].Cells["HALF_ITEM_CD"].Value;

                        if (txt_half_item_cd == "" || txt_half_item_cd == null)  //마지막 행에 원부재료코드가 없을 경우 제거
                        {
                            itemHalfGrid.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }

                }

                if (itemFlowGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    for (int i = 0; i < itemFlowGrid.Rows.Count; i++)
                    {

                        if (itemFlowGrid.Rows[i].Cells["식별표"].Value != null && (bool)itemFlowGrid.Rows[i].Cells["식별표"].Value)
                        {
                            cnt++;
                        }

                    }
                    if (cnt == 0)
                    {
                        MessageBox.Show(" 완제품식별표가 나오는 공정을 체크해주세요. ");
                        return;
                    }


                }


                /*
               if (도면등록.dgv_picture.Rows.Count > 0) //등록된 도면이 있을때
               {
                   for (int i = 0; i < 도면등록.dgv_picture.Rows.Count; i++)
                   {
                       if (도면등록.dgv_picture.Rows[i].Cells["PICTURE"].Value == null)
                       {
                           도면등록.dgv_picture.Rows.Remove(도면등록.dgv_picture.Rows[i]);
                       }
                   }
               }
               */

                string print_yn = comInfo.resultYn(chk_print_yn);
                if (lbl_item_gbn.Text != "1")
                {

                    wnDm wDm = new wnDm();

                    int rsNum = wDm.insertItem(
                                    txt_item_cd.Text.ToString()
                                    , txt_item_nm.Text.ToString()
                                    , cmb_item_gbn.SelectedValue.ToString()
                                    , txt_spec.Text.ToString()
                                    , cmb_type.SelectedValue.ToString()
                                    , cmb_line.SelectedValue.ToString()
                                    , cmb_unit.SelectedValue.ToString()
                                    , ""
                                    , double.Parse(txt_prop_stock.Text.ToString())
                                    , double.Parse(txt_item_weight.Text.ToString())
                                    , double.Parse(txt_input_price.Text.ToString())
                                    , double.Parse(txt_output_price.Text.ToString())
                                    , double.Parse(txt_char_amt.Text.ToString())
                                    , double.Parse(txt_pack_amt.Text.ToString())
                                    , cmb_cust.SelectedValue.ToString()
                                    , print_yn
                                    , cmb_used.SelectedValue.ToString()
                                    , input_date.Text.ToString()
                                    , txt_box_bar_cd.Text.ToString()
                                    , txt_box_amt.Text.ToString()
                                    , txt_unit_bar_cd.Text.ToString()
                                    , txt_unit_amt.Text.ToString()
                                    , txt_comment.Text.ToString()
                                    , (txt_link_input.Text != null ? txt_link_input.Text.ToString() : "")
                                    , (string)cmb_vat_cd.SelectedValue ?? ""  //0115
                                    , itemRawGrid
                                    , itemFlowGrid
                                    , itemHalfGrid
                                    , 도면등록.dgv_picture
                                    );

                    if (rsNum == 0)
                    {
                        resetSetting();
                        item_list();
                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                    else if (rsNum == 4)
                        MessageBox.Show("장터지기 등록에러.");
                    else
                        MessageBox.Show("Exception 에러");
                }
                else
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.updateItem(
                                    txt_item_cd.Text.ToString()
                                    , txt_item_nm.Text.ToString()
                                    , cmb_item_gbn.SelectedValue.ToString()
                                    , txt_spec.Text.ToString()
                                    , cmb_type.SelectedValue.ToString()
                                    , cmb_line.SelectedValue.ToString()
                                    , cmb_unit.SelectedValue.ToString()
                                    , ""
                                    , double.Parse(txt_prop_stock.Text.ToString())
                                    , double.Parse(txt_item_weight.Text.ToString())
                                    , double.Parse(txt_input_price.Text.ToString())
                                    , double.Parse(txt_output_price.Text.ToString())
                                    , double.Parse(txt_char_amt.Text.ToString())
                                    , double.Parse(txt_pack_amt.Text.ToString())
                                    , cmb_cust.SelectedValue.ToString()
                                    , print_yn
                                    , cmb_used.SelectedValue.ToString()
                                    , input_date.Text.ToString()
                                    , txt_box_bar_cd.Text.ToString()
                                    , txt_box_amt.Text.ToString()
                                    , txt_unit_bar_cd.Text.ToString()
                                    , txt_unit_amt.Text.ToString()
                                    , txt_comment.Text.ToString()
                                    , (txt_link_input.Text != null ? txt_link_input.Text.ToString() : "")
                                   , (string)cmb_vat_cd.SelectedValue ?? ""//0115
                                    , itemRawGrid
                                    , itemFlowGrid
                                    , itemHalfGrid
                                    , del_compGrid
                                    , del_flowGrid
                                    , del_halfGrid
                                    , 도면등록.dgv_picture
                                    , 도면등록.del_dgv_picture);

                    if (rsNum == 0)
                    {
                        del_compGrid.Rows.Clear(); //기존 삭제 데이터할 제품구성 리스트 초기화
                        del_flowGrid.Rows.Clear();
                        del_halfGrid.Rows.Clear();
                        item_list();
                        gridDetail("where A.item_cd = '" + txt_item_cd.Text.ToString() + "'");
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else
                        MessageBox.Show("Exception 에러");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러: " + e.Message.ToString());
            }
        }

    }
}
