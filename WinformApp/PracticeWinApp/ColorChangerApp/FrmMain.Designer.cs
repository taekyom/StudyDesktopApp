
namespace ColorChangerApp
{
    partial class FrmMain
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
            this.PnlResult = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtRed = new System.Windows.Forms.TextBox();
            this.TxtGreen = new System.Windows.Forms.TextBox();
            this.TxtBlue = new System.Windows.Forms.TextBox();
            this.BtnColor = new System.Windows.Forms.Button();
            this.TBRRed = new System.Windows.Forms.TrackBar();
            this.TBRGreen = new System.Windows.Forms.TrackBar();
            this.TBRBlue = new System.Windows.Forms.TrackBar();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.TBRRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBRGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBRBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlResult
            // 
            this.PnlResult.BackColor = System.Drawing.Color.AliceBlue;
            this.PnlResult.Location = new System.Drawing.Point(35, 26);
            this.PnlResult.Name = "PnlResult";
            this.PnlResult.Size = new System.Drawing.Size(439, 159);
            this.PnlResult.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "RED";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "GREEN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "BLUE";
            // 
            // TxtRed
            // 
            this.TxtRed.Location = new System.Drawing.Point(374, 209);
            this.TxtRed.Name = "TxtRed";
            this.TxtRed.ReadOnly = true;
            this.TxtRed.Size = new System.Drawing.Size(100, 21);
            this.TxtRed.TabIndex = 7;
            this.TxtRed.Text = "0";
            this.TxtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtGreen
            // 
            this.TxtGreen.Location = new System.Drawing.Point(374, 262);
            this.TxtGreen.Name = "TxtGreen";
            this.TxtGreen.ReadOnly = true;
            this.TxtGreen.Size = new System.Drawing.Size(100, 21);
            this.TxtGreen.TabIndex = 8;
            this.TxtGreen.Text = "0";
            this.TxtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtBlue
            // 
            this.TxtBlue.Location = new System.Drawing.Point(374, 315);
            this.TxtBlue.Name = "TxtBlue";
            this.TxtBlue.ReadOnly = true;
            this.TxtBlue.Size = new System.Drawing.Size(100, 21);
            this.TxtBlue.TabIndex = 9;
            this.TxtBlue.Text = "0";
            this.TxtBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnColor
            // 
            this.BtnColor.Location = new System.Drawing.Point(504, 26);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(33, 25);
            this.BtnColor.TabIndex = 10;
            this.BtnColor.Text = "...";
            this.BtnColor.UseVisualStyleBackColor = true;
            this.BtnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // TBRRed
            // 
            this.TBRRed.Location = new System.Drawing.Point(97, 202);
            this.TBRRed.Maximum = 255;
            this.TBRRed.Name = "TBRRed";
            this.TBRRed.Size = new System.Drawing.Size(266, 45);
            this.TBRRed.TabIndex = 11;
            this.TBRRed.TickFrequency = 15;
            this.TBRRed.Scroll += new System.EventHandler(this.Trackbar_Scroll);
            // 
            // TBRGreen
            // 
            this.TBRGreen.Location = new System.Drawing.Point(97, 252);
            this.TBRGreen.Maximum = 255;
            this.TBRGreen.Name = "TBRGreen";
            this.TBRGreen.Size = new System.Drawing.Size(266, 45);
            this.TBRGreen.TabIndex = 11;
            this.TBRGreen.TickFrequency = 15;
            this.TBRGreen.Scroll += new System.EventHandler(this.Trackbar_Scroll);
            // 
            // TBRBlue
            // 
            this.TBRBlue.Location = new System.Drawing.Point(97, 304);
            this.TBRBlue.Maximum = 255;
            this.TBRBlue.Name = "TBRBlue";
            this.TBRBlue.Size = new System.Drawing.Size(266, 45);
            this.TBRBlue.TabIndex = 11;
            this.TBRBlue.TickFrequency = 15;
            this.TBRBlue.Scroll += new System.EventHandler(this.Trackbar_Scroll);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(504, 57);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(33, 25);
            this.BtnOpen.TabIndex = 10;
            this.BtnOpen.Text = "...";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(504, 88);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(33, 25);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "...";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(549, 359);
            this.Controls.Add(this.TBRBlue);
            this.Controls.Add(this.TBRGreen);
            this.Controls.Add(this.TBRRed);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.BtnColor);
            this.Controls.Add(this.TxtBlue);
            this.Controls.Add(this.TxtGreen);
            this.Controls.Add(this.TxtRed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PnlResult);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RGB Color Scroller";
            ((System.ComponentModel.ISupportInitialize)(this.TBRRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBRGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBRBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtRed;
        private System.Windows.Forms.TextBox TxtGreen;
        private System.Windows.Forms.TextBox TxtBlue;
        private System.Windows.Forms.Button BtnColor;
        private System.Windows.Forms.TrackBar TBRRed;
        private System.Windows.Forms.TrackBar TBRGreen;
        private System.Windows.Forms.TrackBar TBRBlue;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

