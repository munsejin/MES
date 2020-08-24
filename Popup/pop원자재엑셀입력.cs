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
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.IO;

namespace MES.Popup
{
    public partial class pop원자재엑셀입력 : Form
    {
        private wnGConstant wConst = new wnGConstant();

        public pop원자재엑셀입력()
        {
            InitializeComponent();
        }

        private void pop원자재엑셀입력_Load(object sender, EventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            importExcel();
        }
        private void importExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "엑셀 파일 선택하세요";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblMsg.Visible = true;
                Application.DoEvents();
                string sFilePath = openFileDialog.FileName;
                OleDbConnection Connection = null;
                OleDbCommand OleConnection = null;
                OleDbDataAdapter sda = null;
                DataTable data = null;
                try
                {
                    String name = "Sheet1"; //Name of your Sheet in the work book
                    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                    sFilePath +
                                    ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    Connection = new OleDbConnection(constr);
                    OleConnection = new OleDbCommand("SELECT * FROM [" + name + "$]", Connection);
                    Connection.Open();

                    sda = new OleDbDataAdapter(OleConnection);
                    data = new DataTable();
                    sda.Fill(data);
                    excelGrid.DataSource = data;

                    for (int i = 0; i < excelGrid.Columns.Count; i++)
                    {
                        excelGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    bool is_Load_Success = true;
                    for (int i = 0; i < excelGrid.Rows.Count; i++)
                    {
                        if ((excelGrid.Rows[i].Cells[0].Value == null || excelGrid.Rows[i].Cells[0].Value.ToString().Equals("")) &&
                            (excelGrid.Rows[i].Cells[1].Value == null || excelGrid.Rows[i].Cells[1].Value.ToString().Equals("")) &&
                            (excelGrid.Rows[i].Cells[2].Value == null || excelGrid.Rows[i].Cells[2].Value.ToString().Equals("")))
                        {
                            excelGrid.Rows.RemoveAt(i);
                            i--;
                            continue;
                        }

                        if (excelGrid.Rows[i].Cells[10].Value == null || excelGrid.Rows[i].Cells[10].Value.ToString().Equals(""))
                        {
                            excelGrid.Rows[i].Cells[10].Value = "0";
                        }

                        if (excelGrid.Rows[i].Cells[7].Value == null || excelGrid.Rows[i].Cells[7].Value.ToString().Equals(""))
                        {
                            excelGrid.Rows[i].Cells[7].Value = "0";
                        }

                        if (excelGrid.Rows[i].Cells[0].Value == null || excelGrid.Rows[i].Cells[0].Value.ToString().Equals("")
                            || excelGrid.Rows[i].Cells[1].Value == null || excelGrid.Rows[i].Cells[1].Value.ToString().Equals("")
                            || excelGrid.Rows[i].Cells[2].Value == null || excelGrid.Rows[i].Cells[2].Value.ToString().Equals("")
                            || excelGrid.Rows[i].Cells[5].Value == null || excelGrid.Rows[i].Cells[5].Value.ToString().Equals("")
                            || excelGrid.Rows[i].Cells[6].Value == null || excelGrid.Rows[i].Cells[6].Value.ToString().Equals("")
                            || excelGrid.Rows[i].Cells[11].Value == null || excelGrid.Rows[i].Cells[11].Value.ToString().Equals("")
                            || excelGrid.Rows[i].Cells[12].Value == null || excelGrid.Rows[i].Cells[12].Value.ToString().Equals("")
                            || excelGrid.Rows[i].Cells[4].Value == null || excelGrid.Rows[i].Cells[4].Value.ToString().Equals(""))
                        {
                            for (int k = 0; k < excelGrid.Rows.Count; k++)
                            {
                                if ((excelGrid.Rows[k].Cells[0].Value == null || excelGrid.Rows[k].Cells[0].Value.ToString().Equals("")) &&
                                 (excelGrid.Rows[k].Cells[1].Value == null || excelGrid.Rows[k].Cells[1].Value.ToString().Equals("")) &&
                                 (excelGrid.Rows[k].Cells[2].Value == null || excelGrid.Rows[k].Cells[2].Value.ToString().Equals("")))
                                {
                                    excelGrid.Rows.RemoveAt(k);
                                    k--;
                                    continue;
                                }
                            }
                            MessageBox.Show((i + 1) + "행에서 필수 입력란의 데이터가 누락되었습니다.\n엑셀 파일을 다시 확인하여주십시오. ");
                            is_Load_Success = false;

                        }
                    }

                    if (is_Load_Success)
                    {
                        btn_insert.Visible = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
                finally
                {
                    Connection.Close();
                    Connection = null;
                    OleConnection = null;
                    sda = null;
                    data = null;
                    GC.GetTotalMemory(false);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.GetTotalMemory(true);
                }
                lblMsg.Visible = false;
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (excelGrid.Rows.Count > 0)
            {
                lblMsg.Visible = true;
                Application.DoEvents();
                try
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.fn_insert_raw_cd_from_Excel(excelGrid);

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 등록하였습니다!");
                        this.Close();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다. 원자재코드가 중복되지 않았는지 확인하여주십시오");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러 발생");
                    }
                }
                catch (Exception ex)
                {
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }

                lblMsg.Visible = false;
            }
        }

        private void btn_downLoad_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                DialogResult dr = folderBrowser.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    DirectoryInfo di = new DirectoryInfo(folderBrowser.SelectedPath);
                    //DirectoryInfo.Exists로 폴더 존재유무 확인
                    if (di.Exists)
                    {

                    }
                    else
                    {
                        MessageBox.Show("선택한 폴더가 없습니다.");
                    }
                    CopyExcel_Templete(folderBrowser.SelectedPath);
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("파일입출력 오류 !!\n 디렉토리 권한을 확인해주세요.");
            }
        }

        private void CopyExcel_Templete(string targetPath)
        {
            try
            {
                string fileName = "MES_원자재입력양식.xlsx";
                string TargetFile = targetPath + "\\" + fileName;
                string SourceFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"Resources\" + fileName);
                System.IO.File.Copy(SourceFile, TargetFile, true);
                MessageBox.Show("파일 다운로드 성공!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일 다운 실패");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

    }
}
