using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorChangerApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void Trackbar_Scroll(object sender, EventArgs e)
        {
            TxtRed.Text = TBRRed.Value.ToString();
            TxtGreen.Text = TBRGreen.Value.ToString();
            TxtBlue.Text = TBRBlue.Value.ToString();

            PnlResult.BackColor = Color.FromArgb(TBRRed.Value, TBRBlue.Value, TBRGreen.Value);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
