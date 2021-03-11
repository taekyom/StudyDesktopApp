
namespace DigitalAlarmClockApp
{
    partial class FrmAlarm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabClock = new System.Windows.Forms.TabControl();
            this.TapSetAlarm = new System.Windows.Forms.TabPage();
            this.BtnRelease = new System.Windows.Forms.Button();
            this.BtnSet = new System.Windows.Forms.Button();
            this.DTPAlarmTime = new System.Windows.Forms.DateTimePicker();
            this.DTPAlarmDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TapDigitalClock = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LBLTime = new System.Windows.Forms.Label();
            this.LBLDate = new System.Windows.Forms.Label();
            this.LBLAlarm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.TabClock.SuspendLayout();
            this.TapSetAlarm.SuspendLayout();
            this.TapDigitalClock.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabClock
            // 
            this.TabClock.Controls.Add(this.TapSetAlarm);
            this.TabClock.Controls.Add(this.TapDigitalClock);
            this.TabClock.Location = new System.Drawing.Point(12, 12);
            this.TabClock.Name = "TabClock";
            this.TabClock.SelectedIndex = 0;
            this.TabClock.Size = new System.Drawing.Size(401, 260);
            this.TabClock.TabIndex = 0;
            // 
            // TapSetAlarm
            // 
            this.TapSetAlarm.Controls.Add(this.BtnRelease);
            this.TapSetAlarm.Controls.Add(this.BtnSet);
            this.TapSetAlarm.Controls.Add(this.DTPAlarmTime);
            this.TapSetAlarm.Controls.Add(this.DTPAlarmDate);
            this.TapSetAlarm.Controls.Add(this.label2);
            this.TapSetAlarm.Controls.Add(this.label1);
            this.TapSetAlarm.Location = new System.Drawing.Point(4, 22);
            this.TapSetAlarm.Name = "TapSetAlarm";
            this.TapSetAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.TapSetAlarm.Size = new System.Drawing.Size(393, 234);
            this.TapSetAlarm.TabIndex = 0;
            this.TapSetAlarm.Text = "알람설정";
            this.TapSetAlarm.UseVisualStyleBackColor = true;
            // 
            // BtnRelease
            // 
            this.BtnRelease.Location = new System.Drawing.Point(288, 183);
            this.BtnRelease.Name = "BtnRelease";
            this.BtnRelease.Size = new System.Drawing.Size(83, 37);
            this.BtnRelease.TabIndex = 2;
            this.BtnRelease.Text = "해제";
            this.BtnRelease.UseVisualStyleBackColor = true;
            this.BtnRelease.Click += new System.EventHandler(this.BtnRelease_Click);
            // 
            // BtnSet
            // 
            this.BtnSet.Location = new System.Drawing.Point(199, 183);
            this.BtnSet.Name = "BtnSet";
            this.BtnSet.Size = new System.Drawing.Size(83, 37);
            this.BtnSet.TabIndex = 2;
            this.BtnSet.Text = "설정";
            this.BtnSet.UseVisualStyleBackColor = true;
            this.BtnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // DTPAlarmTime
            // 
            this.DTPAlarmTime.CustomFormat = "hh:mm:ss";
            this.DTPAlarmTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPAlarmTime.Location = new System.Drawing.Point(33, 118);
            this.DTPAlarmTime.Name = "DTPAlarmTime";
            this.DTPAlarmTime.Size = new System.Drawing.Size(200, 21);
            this.DTPAlarmTime.TabIndex = 1;
            // 
            // DTPAlarmDate
            // 
            this.DTPAlarmDate.Location = new System.Drawing.Point(33, 41);
            this.DTPAlarmDate.Name = "DTPAlarmDate";
            this.DTPAlarmDate.Size = new System.Drawing.Size(200, 21);
            this.DTPAlarmDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "시간 설정";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "날짜 설정";
            // 
            // TapDigitalClock
            // 
            this.TapDigitalClock.Controls.Add(this.groupBox1);
            this.TapDigitalClock.Controls.Add(this.LBLAlarm);
            this.TapDigitalClock.Controls.Add(this.label3);
            this.TapDigitalClock.Location = new System.Drawing.Point(4, 22);
            this.TapDigitalClock.Name = "TapDigitalClock";
            this.TapDigitalClock.Padding = new System.Windows.Forms.Padding(3);
            this.TapDigitalClock.Size = new System.Drawing.Size(393, 234);
            this.TapDigitalClock.TabIndex = 1;
            this.TapDigitalClock.Text = "디지털 시계";
            this.TapDigitalClock.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBLTime);
            this.groupBox1.Controls.Add(this.LBLDate);
            this.groupBox1.Location = new System.Drawing.Point(28, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 126);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "현재시간";
            // 
            // LBLTime
            // 
            this.LBLTime.AutoSize = true;
            this.LBLTime.Font = new System.Drawing.Font("Yu Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLTime.Location = new System.Drawing.Point(19, 59);
            this.LBLTime.Name = "LBLTime";
            this.LBLTime.Size = new System.Drawing.Size(96, 42);
            this.LBLTime.TabIndex = 1;
            this.LBLTime.Text = "Time";
            // 
            // LBLDate
            // 
            this.LBLDate.AutoSize = true;
            this.LBLDate.Location = new System.Drawing.Point(24, 35);
            this.LBLDate.Name = "LBLDate";
            this.LBLDate.Size = new System.Drawing.Size(30, 12);
            this.LBLDate.TabIndex = 1;
            this.LBLDate.Text = "Date";
            // 
            // LBLAlarm
            // 
            this.LBLAlarm.AutoSize = true;
            this.LBLAlarm.Location = new System.Drawing.Point(26, 52);
            this.LBLAlarm.Name = "LBLAlarm";
            this.LBLAlarm.Size = new System.Drawing.Size(50, 12);
            this.LBLAlarm.TabIndex = 0;
            this.LBLAlarm.Text = "Alarm : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "알람 설정";
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 286);
            this.Controls.Add(this.TabClock);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "알람시계";
            this.Load += new System.EventHandler(this.FrmAlarm_Load);
            this.TabClock.ResumeLayout(false);
            this.TapSetAlarm.ResumeLayout(false);
            this.TapSetAlarm.PerformLayout();
            this.TapDigitalClock.ResumeLayout(false);
            this.TapDigitalClock.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabClock;
        private System.Windows.Forms.TabPage TapSetAlarm;
        private System.Windows.Forms.Button BtnRelease;
        private System.Windows.Forms.Button BtnSet;
        private System.Windows.Forms.DateTimePicker DTPAlarmTime;
        private System.Windows.Forms.DateTimePicker DTPAlarmDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TapDigitalClock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LBLTime;
        private System.Windows.Forms.Label LBLDate;
        private System.Windows.Forms.Label LBLAlarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer MyTimer;
    }
}

