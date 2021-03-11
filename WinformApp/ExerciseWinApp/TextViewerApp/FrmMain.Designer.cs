
namespace TextViewerApp
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
            this.DlgSelectText = new System.Windows.Forms.OpenFileDialog();
            this.BTNSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DlgSelectText
            // 
            this.DlgSelectText.FileName = "openFileDialog1";
            // 
            // BTNSelectFile
            // 
            this.BTNSelectFile.Location = new System.Drawing.Point(23, 21);
            this.BTNSelectFile.Name = "BTNSelectFile";
            this.BTNSelectFile.Size = new System.Drawing.Size(152, 47);
            this.BTNSelectFile.TabIndex = 0;
            this.BTNSelectFile.Text = "텍스트파일 선택";
            this.BTNSelectFile.UseVisualStyleBackColor = true;
            this.BTNSelectFile.Click += new System.EventHandler(this.BTNSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "선택된 파일은 \'메모장\'에서 열립니다.";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 131);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNSelectFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog DlgSelectText;
        private System.Windows.Forms.Button BTNSelectFile;
        private System.Windows.Forms.Label label1;
    }
}

