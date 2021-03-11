using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace DigitalAlarmClockApp
{
    public partial class FrmAlarm : Form
    {
        private DateTime SetDay;
        private DateTime SetTime;
        private bool IsSetAlarm;
        WindowsMediaPlayer mediaPlayer;

        public FrmAlarm()
        {
            InitializeComponent();
        }

        private void FrmAlarm_Load(object sender, EventArgs e)
        {
            mediaPlayer = new WindowsMediaPlayer();                              
            LBLAlarm.ForeColor = Color.Gray; //font색 지정

            LBLDate.Text = LBLTime.Text = " "; //시작 시에 Time이라는 글자 1초간 뜨는 거 사라지게 함
            DTPAlarmTime.Format = DateTimePickerFormat.Custom;
            DTPAlarmTime.CustomFormat = "hh:mm:ss";
            DTPAlarmTime.ShowUpDown = true;

            MyTimer.Interval = 1000; //1sec
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Enabled = true;
            MyTimer.Start();

            TabClock.SelectedTab = TapDigitalClock;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            DateTime curDate = DateTime.Now;
            LBLDate.Text = curDate.ToShortDateString();
            LBLTime.Text = curDate.ToString("hh:mm:ss");

            //flag
            if (IsSetAlarm == true) //알람 설정이 되었다면
            {
                //알람 시간과 현재시간이 일치하면 알람 울림
                if(SetDay == DateTime.Today &&
                   SetTime.Hour == curDate.Hour &&
                   SetTime.Minute == curDate.Minute &&
                   SetTime.Second == curDate.Second)
                {
                    IsSetAlarm = false; //알람 설정 종료
                    BtnRelease_Click(sender, e);
                    mediaPlayer.URL = @".\medias\alarm.mp3";
                    mediaPlayer.controls.play();
                    MessageBox.Show("알람!!", "알람", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            SetDay = DateTime.Parse(DTPAlarmDate.Text);
            SetTime = DateTime.Parse(DTPAlarmTime.Text);
            LBLAlarm.Text = $"Alarm : {SetDay.ToShortDateString()} {SetTime.ToString("hh:mm:ss")}";
            LBLAlarm.ForeColor = Color.Red;

            TabClock.SelectedTab = TapDigitalClock;
            IsSetAlarm = true;
        }

        private void BtnRelease_Click(object sender, EventArgs e)
        {
            IsSetAlarm = false;
            LBLAlarm.Text = "Alarm : ";
            LBLAlarm.ForeColor = Color.Gray;

            TabClock.SelectedTab = TapDigitalClock;
        }
    }
}
