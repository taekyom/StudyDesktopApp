using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelTestApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LblAutoSize.Text = LblManualSize.Text = string.Empty;
        }

        private void BtnPushText_Click(object sender, EventArgs e)
        {
            string sample1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit Phasellus sem torotr, volutpat vitae euismod eget";
            string sample2 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit Phasellus sem torotr, volutpat vitae euismod eget";
            
            LblAutoSize.Text = sample1;
            LblManualSize.Text = sample2;

        }
    }
}
