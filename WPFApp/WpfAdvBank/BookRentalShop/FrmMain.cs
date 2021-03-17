using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShop
{
    public partial class FrmMain : MetroForm
    {
        public FrmMain()
        {
            InitializeComponent();  
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        private void MnuMember_Click(object sender, EventArgs e)
        {
            FrmMember frm = new FrmMember();
            frm.Dock = DockStyle.Fill;
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Width = this.ClientSize.Width - 1000;
            frm.Height = this.Height - menuStrip1.Height;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }
    }
}
