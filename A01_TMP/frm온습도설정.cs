using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using Newtonsoft.Json.Linq;

namespace MES.A01_TMP
{
    public partial class frm온습도설정 : Form
    {

        wnGConstant wConst = new wnGConstant();
        string LocInsertUpdate = "";

        public frm온습도설정()
        {
            InitializeComponent();
        }

        private void frm온습도설정_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            init_ComboBox();
            sensor_list();

            
        }

        #region button logic 

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            update_logic();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion button logic


        #region logic 

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();

            string sqlQuery = "";

            cmb_tmp_loc.ValueMember = "코드";
            cmb_tmp_loc.DisplayMember = "명칭";
            sqlQuery = comInfo.querySensorLoc();
            wConst.ComboBox_Read_Blank(cmb_tmp_loc, sqlQuery);

        }

        private void update_logic() 
        {
            try
            {
                if (txt_device_id.Text.ToString().Equals(""))
                {
                    MessageBox.Show("검색된 온습도 센서 중 하나를 선택하여 주십시오.");
                    return;
                }
                if (txt_sensor_nm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("항목명칭을 입력하시기 바랍니다.");
                    return;
                }

                if (txt_tmp_loc.Visible == false && cmb_tmp_loc.SelectedIndex == 0)
                {
                    MessageBox.Show("설치 위치를 설정하거나 신규 등록하여주십시오.");
                    return;
                }

                try
                {
                    if (tmp_allow_low.Text.ToString().Equals("")
                        || tmp_allow_high.Text.ToString().Equals("")
                        || humi_allow_low.Text.ToString().Equals("")
                        || humi_allow_high.Text.ToString().Equals(""))
                    {
                        MessageBox.Show("온도 및 습도 허용범위를 입력하여주십시오.");
                        return;
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("온도 및 습도 허용범위를 올바르게 입력하여주십시오. ");
                    return;
                }


                wnDm wDm = new wnDm();
                int rsNum = wDm.insert_SensorCode(
                    txt_device_id.Text.ToString()
                    , txt_h_key.Text.ToString()
                    , txt_n_key.Text.ToString()
                    , txt_c_key.Text.ToString()
                    , txt_sensor_nm.Text.ToString()
                    , cmb_tmp_loc
                    , LocInsertUpdate
                    , btn_loc_new.Text.ToString()
                    , txt_tmp_loc.Text.ToString()
                    , tmp_allow_low.Text.ToString()
                    , tmp_allow_high.Text.ToString()
                    , humi_allow_low.Text.ToString()
                    , humi_allow_high.Text.ToString()
                                );

                if (rsNum == 0)
                {
                    resetSetting();
                    sensor_list();
                    init_ComboBox();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else if (rsNum == 3)
                    MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                else if (rsNum == 4)
                    MessageBox.Show("기존 검사순서가 있으니 \n 다른 검사순서로 입력 바랍니다.");
                else
                    MessageBox.Show("Exception 에러1");
                
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류: " + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void resetSetting()
        {
            txt_device_id.Text = "";
            txt_h_key.Text = "";
            txt_n_key.Text = "";
            txt_c_key.Text = "";
            txt_sensor_nm.Text = "";
            tmp_allow_low.Text = "";
            tmp_allow_high.Text = "";
            txt_sensor_gubun.Text = "";
            humi_allow_low.Text = "";
            humi_allow_high.Text = "";
            cmb_tmp_loc.SelectedIndex = 0;
            cmb_tmp_loc.Visible = true;
            txt_tmp_loc.Visible = false;
            btn_loc_new.Text = "신규등록";
            txt_tmp_loc.Text = "";
        }

        private void sensor_list()
        {
            try
            {
                if (Common.p_strPLC_URL.Equals(""))
                {
                    MessageBox.Show("온습도기 데이터 접근정보가 없습니다.");
                    return;
                }
                string result = wnGConstant.Request_Json(Common.p_strPLC_URL);


                System.Net.WebClient wcClient = new System.Net.WebClient();
                JObject data = JObject.Parse(result);

                JArray arr = JArray.Parse(data["datas"].ToString());

                string deviceId = arr[0]["device_id"].ToString();
                JArray sensorArr = JArray.Parse(arr[0]["sensors"].ToString());

                dataSensorGrid.Rows.Clear();
                for(int i = 0; i < sensorArr.Count ; i++)
                {
                    JObject itemObj = (JObject)sensorArr[i];
                    bool isOnAlready = false;
                    for (int j = 0; j < dataSensorGrid.Rows.Count; j++)
                    {
                        if ((dataSensorGrid.Rows[j].Cells["컨트롤러ID"].Value != null && dataSensorGrid.Rows[j].Cells["컨트롤러ID"].Value.ToString().Equals(deviceId))
                            && (dataSensorGrid.Rows[j].Cells["하우스"].Value != null && dataSensorGrid.Rows[j].Cells["하우스"].Value.ToString().Equals(itemObj["h_idx"].ToString()))
                            && (dataSensorGrid.Rows[j].Cells["노드"].Value != null && dataSensorGrid.Rows[j].Cells["노드"].Value.ToString().Equals(itemObj["n_idx"].ToString()))
                            && (dataSensorGrid.Rows[j].Cells["채널"].Value != null && dataSensorGrid.Rows[j].Cells["채널"].Value.ToString().Equals(itemObj["channel"].ToString()))
                            )
                        {
                            isOnAlready = true;
                            break;
                        }
                    }

                    if (isOnAlready) continue;

                    dataSensorGrid.Rows.Add();
                    dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["센서구분"].Value = "온습도센서";
                    dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["컨트롤러ID"].Value = deviceId;
                    dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["하우스"].Value = itemObj["h_idx"].ToString();
                    dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["노드"].Value = itemObj["n_idx"].ToString();
                    dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["채널"].Value = itemObj["channel"].ToString();


                    wnDm wDm = new wnDm();
                    DataTable dt = wDm.fn_select_Sensor_code(deviceId, itemObj["h_idx"].ToString(), itemObj["n_idx"].ToString(), itemObj["channel"].ToString());

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["명칭"].Value = dt.Rows[0]["S_NM"].ToString();
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["설치위치"].Value = dt.Rows[0]["S_LOC_NM"].ToString();
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["설치위치코드"].Value = dt.Rows[0]["S_LOC_CD"].ToString();
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["온도허용범위"].Value = decimal.Parse(dt.Rows[0]["TMP_LOW"].ToString()).ToString("#,0.######") + " ~ " + decimal.Parse(dt.Rows[0]["TMP_HIGH"].ToString()).ToString("#,0.######");
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["습도허용범위"].Value = decimal.Parse(dt.Rows[0]["HUMI_LOW"].ToString()).ToString("#,0.######") + " ~ " + decimal.Parse(dt.Rows[0]["HUMI_HIGH"].ToString()).ToString("#,0.######");
                    }
                    else
                    {
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["명칭"].Value = "(미지정)";
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["설치위치"].Value = "";
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["설치위치코드"].Value = "";
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["온도허용범위"].Value = "";
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["습도허용범위"].Value = "";
                    }
                    
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류: " + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }
        #endregion logic

        private void dataSensorGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridView dgvTemp = (DataGridView)sender;
                txt_device_id.Text = dgvTemp.Rows[e.RowIndex].Cells["컨트롤러ID"].Value.ToString();
                txt_h_key.Text = dgvTemp.Rows[e.RowIndex].Cells["하우스"].Value.ToString();
                txt_n_key.Text = dgvTemp.Rows[e.RowIndex].Cells["노드"].Value.ToString();
                txt_c_key.Text = dgvTemp.Rows[e.RowIndex].Cells["채널"].Value.ToString();
                txt_sensor_nm.Text = dgvTemp.Rows[e.RowIndex].Cells["명칭"].Value.ToString();
                txt_sensor_gubun.Text = dgvTemp.Rows[e.RowIndex].Cells["센서구분"].Value.ToString();
                if (dgvTemp.Rows[e.RowIndex].Cells["설치위치코드"].Value != null || !dgvTemp.Rows[e.RowIndex].Cells["설치위치코드"].Value.ToString().Equals(""))
                {
                    cmb_tmp_loc.SelectedValue = dgvTemp.Rows[e.RowIndex].Cells["설치위치코드"].Value.ToString();
                }
                if (dgvTemp.Rows[e.RowIndex].Cells["온도허용범위"].Value != null && !dgvTemp.Rows[e.RowIndex].Cells["온도허용범위"].Value.ToString().Equals(""))
                {
                    tmp_allow_low.Text = dgvTemp.Rows[e.RowIndex].Cells["온도허용범위"].Value.ToString().Split('~')[0].Trim();
                    tmp_allow_high.Text = dgvTemp.Rows[e.RowIndex].Cells["온도허용범위"].Value.ToString().Split('~')[1].Trim();
                    humi_allow_low.Text = dgvTemp.Rows[e.RowIndex].Cells["습도허용범위"].Value.ToString().Split('~')[0].Trim();
                    humi_allow_high.Text = dgvTemp.Rows[e.RowIndex].Cells["습도허용범위"].Value.ToString().Split('~')[1].Trim();
                }

            }
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sensor_list();
        }

        private void txt_chk_ord_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void btn_loc_new_Click(object sender, EventArgs e)
        {
            if (btn_loc_new.Text != null && btn_loc_new.Text.ToString().Equals("신규등록"))
            {
                cmb_tmp_loc.Visible = false;
                txt_tmp_loc.Visible = true;
                btn_loc_new.Text = "취소";
                LocInsertUpdate = "insert";
            }
            else if (btn_loc_new.Text != null && btn_loc_new.Text.ToString().Equals("명칭수정"))
            {
                cmb_tmp_loc.Visible = false;
                txt_tmp_loc.Visible = true;
                btn_loc_new.Text = "취소";
                LocInsertUpdate = "update#" + cmb_tmp_loc.SelectedValue;
            }
            else if (btn_loc_new.Text != null && btn_loc_new.Text.ToString().Equals("취소"))
            {
                cmb_tmp_loc.Visible = true;
                txt_tmp_loc.Visible = false;
                btn_loc_new.Text = "신규등록";
                cmb_tmp_loc.SelectedIndex = 0;
                LocInsertUpdate = "";
            }

        }

        private void cmb_tmp_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tmp_loc.SelectedIndex == 0)
            {
                btn_loc_new.Text = "신규등록";
            }
            else
            {
                btn_loc_new.Text = "명칭수정";
            }
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
                    btnNew.PerformClick();
                    sensor_list();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
}
