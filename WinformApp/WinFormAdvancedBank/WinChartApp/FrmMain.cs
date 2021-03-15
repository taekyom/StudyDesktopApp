using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinChartApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnRegen_Click(object sender, EventArgs e)
        {
            GenNewChart();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "중간고사 성적"; //frmmain의 title
            ChtScore.Titles.Add("중간고사 성적"); //chart의 title
            GenNewChart();
        }

        private void GenNewChart()
        {
            Random rand = new Random();
            ChtScore.Series[0].Points.Clear(); 
            for (int i = 0; i < 10; i++)
            {
                ChtScore.Series[0].Points.Add(rand.Next(10, 100)); //series : data 하나하나를 나타냄, 배열임 ex)series1 : score, series2 : average ...
            }
            ChtScore.Series[0].LegendText = "수학";
            ChtScore.Series[0].ChartType = SeriesChartType.Column;


        }
    }
}
