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
using System.Net;
using System.IO;
namespace MES.P85_BAS
{
    public partial class frmHACCP파일관리 : Form
    {
        string fName;
        private Popup.frmPrint readyPrt = new Popup.frmPrint();
        private Popup.frmPrint frmPrt;
        private DataTable adoPrt = new DataTable();
        private DataTable adoPrt2 = new DataTable();

        public frmHACCP파일관리()
        {
            InitializeComponent();        
        }   

        private void frmHACCP등록_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; 
               lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
        
        }


        private string OpenFile()
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "jpg";  //openFile.DefaultExt = "기본확장자";
            //ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *pdf)|*.jpg;*.jpeg;*.gif;*.bmp;*.png; *pdf"; //"항목이름정의1|확장자1;확장자2;  … 확장자n;|   … 항목이름정의n|확장자1;확장자2;  … 확장자n;";
            ofd.Filter = "HWP File|*.hwp";
            DialogResult dr = ofd.ShowDialog();
            if (ofd.FileNames.Length > 0)
            {
                foreach (string filename in ofd.FileNames)
                {
                    this.txt_file.Text = filename;
                }
            }

            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                string fileName = ofd.SafeFileName;
                fName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                string fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                string filePath = fileFullName.Replace(fileName, "");

                //출력 예제용 로직
                //label1.Text = "File Name  : " + fileName;
                //label2.Text = "Full Name  : " + fileFullName;
                //label3.Text = "File Path  : " + filePath;
                //File경로 + 파일명 리턴
                return fileFullName;
            }
            //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
            else if (dr == DialogResult.Cancel)
            {
                return "";
            }

            return "";
        }
   

     

     


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string bucketName = "bucketName";
        //        string sharedkeyFilePath = GetFilePath("privateKey.json");
        //        GoogleCredential credential = null;
        //        using (var jsonStream = new FileStream(sharedkeyFilePath, FileMode.Open,
        //            FileAccess.Read, FileShare.Read))
        //        {
        //            credential = GoogleCredential.FromStream(jsonStream);
        //        }
        //        var storageClient = StorageClient.Create(credential);
        //        string filetoUpload = GetFilePath("demo.txt");
        //        using (var fileStream = new FileStream(filetoUpload, FileMode.Open,
        //            FileAccess.Read, FileShare.Read))
        //        {
        //            storageClient.UploadObject(bucketName, "demo.txt", "text/plain", fileStream);
        //        }
        //        Console.WriteLine("uploaded the file successfully");
        //        Console.ReadLine();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static string GetFilePath(string filename)
        //{
        //    return GetFilePath(Assembly.GetCallingAssembly().Location, filename);
        //}
        //public static string GetFilePath(string path, string filename)
        //{
        //    return path.Substring(0, path.LastIndexOf("\\")) + @"\" + filename;
        //}
        

    }
}
