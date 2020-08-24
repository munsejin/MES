using MES.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MES.CLS
{
    class ComInfo
    {
        public static void onlyNum(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        public static void onlyNum2(object sender, KeyPressEventArgs e) //실수 포함
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))    //숫자와 백스페이스, 소수점을 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #region combo select query

        public string queryStaff()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" STAFF_CD as 코드, STAFF_NM as 명칭");
            sb.AppendLine(" from N_STAFF_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryTax()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" S_CODE as 코드, S_CODE_NM as 명칭");
            sb.AppendLine(" from T_S_CODE  ");
            sb.AppendLine(" where L_CODE = '910' ");

            return sb.ToString();
        }

        public string queryFac()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" FAC_CD as 코드, FAC_NM as 명칭");
            sb.AppendLine(" from N_FAC_CODE ");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryUnitType(string unitType_cd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" TYPE_CD as 코드, TYPE_NM as 명칭");
            sb.AppendLine(" from N_TYPE_CODE");
            sb.AppendLine(" where 1=1 and POOR_TYPE_YN = '" + unitType_cd + "'");

            return sb.ToString();

        }

        public string queryMold()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" MOLD_NO as 코드, MOLD_NM as 명칭");
            sb.AppendLine(" from N_MOLD_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryStorage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" STORAGE_CD as 코드, STORAGE_NM as 명칭");
            sb.AppendLine(" from N_STORAGE_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryCdSrch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" TYPE_CD as 코드, TYPE_NM as 명칭");
            sb.AppendLine(" from N_TYPE_CODE");
            sb.AppendLine(" where 1=1 and POOR_TYPE_YN = 'Y'");

            return sb.ToString();

        }

        public string queryUnit()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" UNIT_CD as 코드, UNIT_NM as 명칭");
            sb.AppendLine(" from N_UNIT_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();

        }

        public string queryDept()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" DEPT_CD as 코드, DEPT_NM as 명칭");
            sb.AppendLine(" from N_DEPT_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryType(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" UNIT_TYPE_CD as 코드, UNIT_TYPE_NM as 명칭");
            sb.AppendLine(" from N_UNIT_TYPE_CODE ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(condition);

            return sb.ToString();
        }

        public string queryCode(string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" B.s_code as '코드' ,B.s_code_nm as '명칭'");
            sb.AppendLine(" from [SM_FACTORY_COM].[dbo].[T_L_CODE] A ");
            sb.AppendLine(" inner join [SM_FACTORY_COM].[dbo].[T_S_CODE] B ");
            sb.AppendLine(" on A.L_CODE = B.L_CODE ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(" and A.L_CODE = '" + code + "' ");

            return sb.ToString();
        }

        public string queryLCode(string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" A.s_code as '코드' ,A.s_code_nm as '명칭'");
            sb.AppendLine(" from T_S_CODE A ");

            sb.AppendLine(" where A.L_CODE = '" + code + "' ");

            return sb.ToString();
        }

        public string queryLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" LINE_CD as 코드, LINE_NM as 명칭");
            sb.AppendLine(" from N_LINE_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryChk()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" CHK_CD as 코드, CHK_NM as 명칭");
            sb.AppendLine(" from N_CHK_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryCust(string cust_gbn)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" CUST_CD as 코드, CUST_NM as 명칭");
            sb.AppendLine(" from N_CUST_CODE");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(" and CUST_GUBUN = '" + cust_gbn + "' ");

            Console.WriteLine(sb.ToString());


            return sb.ToString();
        }

        public string queryCustUsed(string cust_gbn)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" CUST_CD as 코드, CUST_NM as 명칭");
            sb.AppendLine(" from N_CUST_CODE");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(" and CUST_GUBUN = '" + cust_gbn + "' AND USED_CD = 1 ");
            sb.AppendLine(" order by CUST_NM ");

            Console.WriteLine(sb.ToString());


            return sb.ToString();
        }

        public string queryRawList()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from T_S_CODE ");
            sb.AppendLine(" where L_CODE = '300' ");

            return sb.ToString();
        }



        public string queryMeatKind()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select DISTINCT A.RAW_MAT_CD as '코드' ,  A.RAW_MAT_NM as '명칭'   ");
            sb.AppendLine("  from N_RAW_MEAT_SOURCE B  ");
            sb.AppendLine("  left join N_RAW_CODE A  ");
            sb.AppendLine(" ON A.RAW_MAT_CD = B.RAW_SOURCE_CD ");

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public string queryGradeGubun()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select GRADE_CD as '코드', GRADE_NM as '명칭' ");
            sb.AppendLine(" from N_GRADE_CODE ");


            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public string queryFrozenGubun()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select FROZEN_CD as '코드', FROZEN_NM as '명칭' ");
            sb.AppendLine(" from N_FROZEN_CODE ");




            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public string queryOriginGubun()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select COUNTRY_CD as '코드', COUNTRY_NM as '명칭' ");
            sb.AppendLine(" from N_RAW_COUNTRY_CODE ");


            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public string querypoor()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select POOR_CD as '코드', POOR_NM as '명칭' ");
            sb.AppendLine(" from N_POOR_CODE ");

            return sb.ToString();
        }


        public string queryUsedYn()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from [SM_FACTORY_COM].[dbo].T_S_CODE ");
            sb.AppendLine(" where L_CODE = '500' ");


            return sb.ToString();
        }

        public string querySooGubun()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from T_S_CODE ");
            sb.AppendLine(" where L_CODE = '1200' ");


            return sb.ToString();
        }


        public string query매출구분()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from [SM_FACTORY_COM].[dbo].T_S_CODE ");
            sb.AppendLine(" where L_CODE = '630' ");


            return sb.ToString();
        }
        public string queryCustUsedYn()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from [SM_FACTORY_COM].[dbo].T_S_CODE ");
            sb.AppendLine(" where L_CODE = '500' ");

            return sb.ToString();
        }

        public string queryCustUsedYnAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select '0' as 코드,'전체' as 명칭 ");
            sb.AppendLine(" union all ");
            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from [SM_FACTORY_COM].[dbo].T_S_CODE ");
            sb.AppendLine(" where L_CODE = '500' ");

            return sb.ToString();
        }


        public string queryCompYnAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select '0' as 코드,'전체' as 명칭 ");
            sb.AppendLine(" union all ");
            sb.AppendLine("select 'Y' as 코드,'완료' as 명칭 ");
            sb.AppendLine(" union all ");
            sb.AppendLine("select 'N' as 코드,'입고대기' as 명칭 ");

            return sb.ToString();
        }

        public string queryVatAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from T_S_CODE ");
            sb.AppendLine(" where L_CODE = '900' ");

            return sb.ToString();
        }


        public string queryItemGbnAll()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select '0' as 코드,'전체' as 명칭 ");
            sb.AppendLine(" union all ");
            sb.AppendLine("select '1' as 코드,'제품' as 명칭 ");
            sb.AppendLine(" union all ");
            sb.AppendLine(" select '2' as 코드,'반제품' as 명칭 ");

            return sb.ToString();
        }


        public string queryChkPass()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select 'Y' as 코드,'합격' as 명칭 ");
            sb.AppendLine(" union all ");
            sb.AppendLine(" select 'N' as 코드,'불합격' as 명칭 ");

            return sb.ToString();
        }

        public string queryFlow() //공정코드
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" FLOW_CD as 코드, FLOW_NM as 명칭");
            sb.AppendLine(" from N_FLOW_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryItemFlow(string item_cd)  // 특정 제품 검사하는 공정  리스트 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select ");
            sb.AppendLine(" A.FLOW_CD as 코드, B.FLOW_NM as 명칭");
            sb.AppendLine(" from N_ITEM_FLOW A ");
            sb.AppendLine(" inner join N_FLOW_CODE B ");
            sb.AppendLine(" on A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine(" where A.ITEM_CD = '" + item_cd + "' ");
            sb.AppendLine(" and B.FLOW_CHK_YN = 'Y' ");
            Debug.WriteLine(sb);
            return sb.ToString();
        }

        public string queryItem2Flow(string item_cd)  // 특정 제품공정 리스트
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select ");
            sb.AppendLine(" A.FLOW_CD as 코드, B.FLOW_NM as 명칭");
            sb.AppendLine(" from N_ITEM_FLOW A ");
            sb.AppendLine(" inner join N_FLOW_CODE B ");
            sb.AppendLine(" on A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine(" where A.ITEM_CD = '" + item_cd + "' ");

            Debug.WriteLine(sb);
            return sb.ToString();
        }

        public string queryItem() //제품코드
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" ITEM_CD as 코드, ITEM_NM as 명칭");
            sb.AppendLine(" from N_ITEM_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryItemSpec() //제품코드
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" ITEM_CD as 코드, ITEM_NM + '  ' + SPEC AS 명칭");
            sb.AppendLine(" from N_ITEM_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryRaw() //원자재
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" RAW_MAT_CD as 코드, RAW_MAT_NM + '_' + SPEC AS 명칭");
            sb.AppendLine(" from N_RAW_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();

        }
        public string resultYn(CheckBox chk)
        {
            if (chk.Checked == true)
            {
                return "Y";
            }
            else
            {
                return "N";
            }
        }


        public DialogResult deleteConfrim(string str1, string str2)
        {
            DialogResult msgOk = MessageBox.Show(str1 + "의 " + str2 + "자료를 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return msgOk;
        }

        public DialogResult warningMessage(string str)
        {
            DialogResult msgOk = MessageBox.Show(str, "경고메세지", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return msgOk;
        }
        public void grdCellSetting(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].ReadOnly = true;
            }
        }

        public void grdCellSetting2(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].ReadOnly = true;
            }
        }

        public static bool grdHeaderNoAction(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return false;
            }
            else return true;
        }
        #endregion combo select query

        public static Image pic_resize_logic(PictureBox pic, Image image)
        {
            Image cus_img = new Bitmap(pic.Width, pic.Width, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(cus_img))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(image,
                    new RectangleF(0, 0, pic.Width, pic.Height),
                    new RectangleF(new PointF(0, 0), image.Size), GraphicsUnit.Pixel);
            }
            return cus_img;
        }

        public static byte[] GetImage(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] image = reader.ReadBytes((int)stream.Length);
            reader.Close();
            stream.Close();

            return image;
        }

        public string queryExprt()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select S_CODE as '코드', S_CODE_NM as '명칭' ");
            sb.AppendLine(" from [SM_FACTORY_COM].[dbo].T_S_CODE ");
            sb.AppendLine(" where L_CODE = '700' ");


            return sb.ToString();
        }
        //2019-11-05 HACCP 문서관리를 위한 구분 등록 
        public string queryHACCP_GUBUN()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" S_CODE as 코드, S_CODE_NM as 명칭");
            sb.AppendLine(" from T_S_CODE");
            sb.AppendLine(" where L_CODE = '1500' ");

            return sb.ToString();
        }

        public static void gridHeaderSet(conDataGridView dgv)
        {
            
        }

        public static void gridHeaderSet(DataGridView dgv)
        {
            
        }

        static void dgv_SizeChanged(object sender, EventArgs e)
        {
            
        }

        public string queryRawStorage()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select STORAGE_CD as 코드, STORAGE_NM as 명칭,@@ROWCOUNT ");
            sb.AppendLine(" from N_STORAGE_CODE ");
         

            return sb.ToString();
        }

        public static string TextBoxMessage(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 185,
                Height = 90,
                FormBorderStyle = FormBorderStyle.None,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };
            Label textLabel = new Label() { Left = 45, Top = 10, Text = text };
            TextBox textBox = new TextBox() { Left = 45, Top = 30, Width = 100 };
            Button confirmation = new Button() { Text = "입력", Left = 45, Width = 100, Top = 55, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public string query_Bill_Input_Gubun() // 부가세
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" S_CODE as 코드, S_CODE_NM as 명칭");
            sb.AppendLine(" from T_S_CODE");
            sb.AppendLine(" where L_CODE = '950' ");

            return sb.ToString();
        }

        public string query_Bill_Cal_Gubun() // 부가세
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" S_CODE as 코드, S_CODE_NM as 명칭");
            sb.AppendLine(" from T_S_CODE");
            sb.AppendLine(" where L_CODE = '960' ");
            sb.AppendLine(" order by ORD ");

            return sb.ToString();
        }

        public string queryAccu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" ACCU_CD as 코드, ACCU_NM as 명칭");
            sb.AppendLine(" from N_ACCOUNT_CODE");
            sb.AppendLine(" where 1=1 ");

            return sb.ToString();
        }

        public string queryRawPoor()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   select A.POOR_CD AS 코드 ");
            sb.AppendLine("   ,A.POOR_NM AS 명칭 ");
            sb.AppendLine("  FROM N_POOR_CODE A  ");
            sb.AppendLine("WHERE POOR_GUBUN = '1' ");
            sb.AppendLine("   order by A.POOR_CD  ");
            return sb.ToString();
        }

        public string queryCustSell()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" CUST_CD as 코드, CUST_NM as 명칭");
            sb.AppendLine(" from  N_CUST_CODE");
            //sb.AppendLine(" where  CUST_GUBUN = '1'");

            return sb.ToString();

        }

        public string querySensorLoc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" S_LOC_CD as 코드, S_LOC_NM as 명칭");
            sb.AppendLine(" from  N_SENSOR_LOC ");
            return sb.ToString();
        }

        public string querySensorType()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" '1' as 코드, '온도' as 명칭");
            sb.AppendLine(" UNION ALL ");
            sb.AppendLine("select ");
            sb.AppendLine(" '2' as 코드, '습도' as 명칭");
            return sb.ToString();
        }

        public string queryErrorGubun()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine(" ERROR_CD as 코드, ERROR_NM as 명칭");
            sb.AppendLine(" from  [SM_FACTORY_REPORT].dbo.N_ERROR_GUBUN ");
            sb.AppendLine(" order by ERROR_NM desc ");
            return sb.ToString();
        }
    }
}
