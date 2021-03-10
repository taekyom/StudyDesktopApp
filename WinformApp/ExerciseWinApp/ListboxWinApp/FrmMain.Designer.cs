
namespace ListboxWinApp
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
            this.LsbGDPCountryRank = new System.Windows.Forms.ListBox();
            this.LsbGoodCity = new System.Windows.Forms.ListBox();
            this.LsbHappyCountry = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtGdpIndex = new System.Windows.Forms.TextBox();
            this.TxtGdpItem = new System.Windows.Forms.TextBox();
            this.TxtGoodIndex = new System.Windows.Forms.TextBox();
            this.TxtGoodItem = new System.Windows.Forms.TextBox();
            this.TxtHappyIndex = new System.Windows.Forms.TextBox();
            this.TxtHappyItem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnInitiate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LsbGDPCountryRank
            // 
            this.LsbGDPCountryRank.FormattingEnabled = true;
            this.LsbGDPCountryRank.ItemHeight = 12;
            this.LsbGDPCountryRank.Items.AddRange(new object[] {
            "미국",
            "러시아",
            "중국",
            "독일",
            "프랑스",
            "일본",
            "이스라엘",
            "사우디아라비아",
            "UAE",
            "필리핀",
            "대한민국"});
            this.LsbGDPCountryRank.Location = new System.Drawing.Point(123, 44);
            this.LsbGDPCountryRank.Name = "LsbGDPCountryRank";
            this.LsbGDPCountryRank.Size = new System.Drawing.Size(172, 328);
            this.LsbGDPCountryRank.TabIndex = 2;
            this.LsbGDPCountryRank.SelectedIndexChanged += new System.EventHandler(this.LsbGDPCountryRank_SelectedIndexChanged);
            // 
            // LsbGoodCity
            // 
            this.LsbGoodCity.FormattingEnabled = true;
            this.LsbGoodCity.ItemHeight = 12;
            this.LsbGoodCity.Location = new System.Drawing.Point(327, 44);
            this.LsbGoodCity.Name = "LsbGoodCity";
            this.LsbGoodCity.Size = new System.Drawing.Size(172, 328);
            this.LsbGoodCity.TabIndex = 8;
            this.LsbGoodCity.SelectedIndexChanged += new System.EventHandler(this.LsbGoodCity_SelectedIndexChanged);
            // 
            // LsbHappyCountry
            // 
            this.LsbHappyCountry.FormattingEnabled = true;
            this.LsbHappyCountry.ItemHeight = 12;
            this.LsbHappyCountry.Location = new System.Drawing.Point(531, 44);
            this.LsbHappyCountry.Name = "LsbHappyCountry";
            this.LsbHappyCountry.Size = new System.Drawing.Size(172, 328);
            this.LsbHappyCountry.TabIndex = 12;
            this.LsbHappyCountry.SelectedIndexChanged += new System.EventHandler(this.LsbHappyCountry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "GDP 국가순위";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "살기 좋은 도시";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "행복한 나라";
            // 
            // TxtGdpIndex
            // 
            this.TxtGdpIndex.Location = new System.Drawing.Point(123, 379);
            this.TxtGdpIndex.Name = "TxtGdpIndex";
            this.TxtGdpIndex.Size = new System.Drawing.Size(172, 21);
            this.TxtGdpIndex.TabIndex = 4;
            // 
            // TxtGdpItem
            // 
            this.TxtGdpItem.Location = new System.Drawing.Point(123, 409);
            this.TxtGdpItem.Name = "TxtGdpItem";
            this.TxtGdpItem.Size = new System.Drawing.Size(172, 21);
            this.TxtGdpItem.TabIndex = 6;
            // 
            // TxtGoodIndex
            // 
            this.TxtGoodIndex.Location = new System.Drawing.Point(327, 379);
            this.TxtGoodIndex.Name = "TxtGoodIndex";
            this.TxtGoodIndex.Size = new System.Drawing.Size(172, 21);
            this.TxtGoodIndex.TabIndex = 9;
            // 
            // TxtGoodItem
            // 
            this.TxtGoodItem.Location = new System.Drawing.Point(327, 409);
            this.TxtGoodItem.Name = "TxtGoodItem";
            this.TxtGoodItem.Size = new System.Drawing.Size(172, 21);
            this.TxtGoodItem.TabIndex = 10;
            // 
            // TxtHappyIndex
            // 
            this.TxtHappyIndex.Location = new System.Drawing.Point(531, 379);
            this.TxtHappyIndex.Name = "TxtHappyIndex";
            this.TxtHappyIndex.Size = new System.Drawing.Size(172, 21);
            this.TxtHappyIndex.TabIndex = 13;
            // 
            // TxtHappyItem
            // 
            this.TxtHappyItem.Location = new System.Drawing.Point(531, 409);
            this.TxtHappyItem.Name = "TxtHappyItem";
            this.TxtHappyItem.Size = new System.Drawing.Size(172, 21);
            this.TxtHappyItem.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "SelectedIndex";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "SelectedItem";
            // 
            // BtnInitiate
            // 
            this.BtnInitiate.Location = new System.Drawing.Point(31, 342);
            this.BtnInitiate.Name = "BtnInitiate";
            this.BtnInitiate.Size = new System.Drawing.Size(83, 30);
            this.BtnInitiate.TabIndex = 15;
            this.BtnInitiate.Text = "초기화";
            this.BtnInitiate.UseVisualStyleBackColor = true;
            this.BtnInitiate.Click += new System.EventHandler(this.BtnInitiate_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 463);
            this.Controls.Add(this.BtnInitiate);
            this.Controls.Add(this.TxtHappyItem);
            this.Controls.Add(this.TxtHappyIndex);
            this.Controls.Add(this.TxtGoodItem);
            this.Controls.Add(this.TxtGoodIndex);
            this.Controls.Add(this.TxtGdpItem);
            this.Controls.Add(this.TxtGdpIndex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LsbHappyCountry);
            this.Controls.Add(this.LsbGoodCity);
            this.Controls.Add(this.LsbGDPCountryRank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListBoxTest";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LsbGDPCountryRank;
        private System.Windows.Forms.ListBox LsbGoodCity;
        private System.Windows.Forms.ListBox LsbHappyCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtGdpIndex;
        private System.Windows.Forms.TextBox TxtGdpItem;
        private System.Windows.Forms.TextBox TxtGoodIndex;
        private System.Windows.Forms.TextBox TxtGoodItem;
        private System.Windows.Forms.TextBox TxtHappyIndex;
        private System.Windows.Forms.TextBox TxtHappyItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnInitiate;
    }
}

