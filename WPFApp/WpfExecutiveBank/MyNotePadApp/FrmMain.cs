using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotePadApp
{
    public partial class FrmMain : Form
    {
        public bool IsModifiy { get; set; }
        private const string firstFileName = "noname.txt";
        private string currfilename = "noname.txt"; 
        public FrmMain()
        {
            InitializeComponent();
        }

        private void MnuNewFile_Click(object sender, EventArgs e)
        {
            //TODO : 만약에 작업 중인 파일이 있으면 저장처리해주는 부분
            ProcessSaveFileBeforeClose();
            TxtMain.Text = "";
            IsModifiy = false;
            currfilename = "noname.txt";
        }

        private void ProcessSaveFileBeforeClose()
        {
            if (IsModifiy)
            {
                DialogResult answer = MessageBox.Show("변경사항이 있습니다. 저장하시겠습니까?", "저장",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(answer == DialogResult.Yes)
                {
                    if(currfilename == firstFileName)
                    {
                        if(DlgSaveText.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter sw = File.CreateText(DlgSaveText.FileName);
                            sw.WriteLine(TxtMain.Text);
                            sw.Close();
                        }
                        else
                        {
                            StreamWriter sw = File.CreateText(currfilename);
                            sw.WriteLine(TxtMain.Text);
                            sw.Close();
                        }
                    }
                }
            }
        }

        private void MnuOpenFile_Click(object sender, EventArgs e)
        {
            ProcessSaveFileBeforeClose();
            DlgOpenText.ShowDialog();
            currfilename = DlgOpenText.FileName;
            this.Text = $"{currfilename} - 내 메모장";

            try
            {
                StreamReader sr = File.OpenText(currfilename);
                TxtMain.Text = sr.ReadToEnd();

                IsModifiy = false;
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MnuSaveFile_Click(object sender, EventArgs e)
        {
            if(currfilename == firstFileName)
            {
                DlgSaveText.Filter = "Text file(*.txt)|*.txt";
                if (DlgSaveText.ShowDialog() == DialogResult.OK)
                    currfilename = DlgSaveText.FileName;
            }
            StreamWriter sw = File.CreateText(currfilename);
            sw.WriteLine(TxtMain.Text);

            IsModifiy = false;
            sw.Close();

            this.Text = $"{currfilename} - 내 메모장";
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            ProcessSaveFileBeforeClose();
            Environment.Exit(0);
        }

        private void MnuCopy_Click(object sender, EventArgs e)
        {
            var contents = ActiveControl as RichTextBox;
            if(contents != null)
            {
                Clipboard.SetDataObject(contents.SelectedText);
                MessageBox.Show(contents.SelectedText);
            }
        }

        private void MnuPaste_Click(object sender, EventArgs e)
        {
            var contents = ActiveControl as RichTextBox;
            if(contents != null)
            {
                IDataObject data = Clipboard.GetDataObject();
                contents.SelectedText = data.GetData(DataFormats.Text).ToString();
                IsModifiy = true;
            }
        }

        private void MnuAboutInfo_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("메모장 v1.0입니다.");
            var form = new AboutThis();
            form.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DlgSaveText.Filter = DlgOpenText.Filter = "Text file(*.txt)|*.txt";
            this.Text = $"{currfilename} - 내 메모장";
            IsModifiy = false;
        }

        private void TxtMain_TextChanged(object sender, EventArgs e)
        {
            IsModifiy = true;
        }
    }
}
