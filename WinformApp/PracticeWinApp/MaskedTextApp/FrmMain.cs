using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskedTextApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            //입사일, 주민번호는 유효한 값인지 체크 필요
            string result = string.Empty;
            result = $"입사일 : {TxtHiredDate.Text}\n";
            result += $"우편번호 : {TxtZipCode.Text}\n";
            result += $"연락처 : {TxtPhoneNumber.Text}\n";
            result += $"주소 : {TxtAddress.Text}\n";
            result += $"주민등록번호 : {TxtRegisterNumber.Text}\n";
            result += $"이메일 : {TxtEmail.Text}\n";

            MessageBox.Show(result, "개인정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
