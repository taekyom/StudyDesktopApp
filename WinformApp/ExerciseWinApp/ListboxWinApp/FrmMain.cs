using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListboxWinApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //살기 좋은 도시 초기화, 가장 기본적인 리스트박스 추가
            LsbGoodCity.Items.Add("오스트리아, 빈");
            LsbGoodCity.Items.Add("호주, 맬버른");
            LsbGoodCity.Items.Add("일본, 오사카");
            LsbGoodCity.Items.Add("캐나다, 캘거리");
            LsbGoodCity.Items.Add("호주, 시드니");
            LsbGoodCity.Items.Add("캐나다, 벤쿠버");
            LsbGoodCity.Items.Add("일본, 도쿄");
            LsbGoodCity.Items.Add("캐나다, 토론토");
            LsbGoodCity.Items.Add("덴마크, 코펜하겐");
            LsbGoodCity.Items.Add("호주, 애들레이드");

            //데이터 바인딩 방식 중 하나
            List<string> lstCountry = new List<string>() 
            {"미국", "러시아", "중국", "영국", "독일", "프랑스", "일본", "이스라엘", "사우디아라비아", "UAE", "필리핀", "대한민국" };
            LsbHappyCountry.DataSource = lstCountry;
        }

        private void LsbGDPCountryRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //선택된 값 확인
            //MessageBox.Show(sender.ToString()); 
            var selItem = sender as ListBox;
            MessageBox.Show($"{selItem.SelectedIndex} / {selItem.SelectedItem}");
            TxtGdpIndex.Text = selItem.SelectedIndex.ToString();
            TxtGdpItem.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();
        }

        private void LsbGoodCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = sender as ListBox;
            TxtGoodIndex.Text = selItem.SelectedIndex.ToString();
            TxtGoodItem.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();
        }

        private void LsbHappyCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = sender as ListBox;
            TxtHappyIndex.Text = selItem.SelectedIndex.ToString();
            TxtHappyItem.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();
        }

        private void BtnInitiate_Click(object sender, EventArgs e)
        {
            LsbGDPCountryRank.SelectedIndex = LsbGoodCity.SelectedIndex = LsbHappyCountry.SelectedIndex = -1; //-1은 초기화
        }
    }
}
