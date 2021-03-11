
namespace SimpleGraphicEditor
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
            this.TLBMain = new System.Windows.Forms.ToolStrip();
            this.STSMain = new System.Windows.Forms.StatusStrip();
            this.TLMLine = new System.Windows.Forms.ToolStripLabel();
            this.TLMRectangle = new System.Windows.Forms.ToolStripLabel();
            this.TLMCircle = new System.Windows.Forms.ToolStripLabel();
            this.TLMCurvedLine = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TLMColor = new System.Windows.Forms.ToolStripLabel();
            this.STSCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.TLBMain.SuspendLayout();
            this.STSMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLBMain
            // 
            this.TLBMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TLMLine,
            this.TLMRectangle,
            this.TLMCircle,
            this.TLMCurvedLine,
            this.toolStripSeparator1,
            this.TLMColor});
            this.TLBMain.Location = new System.Drawing.Point(0, 0);
            this.TLBMain.Name = "TLBMain";
            this.TLBMain.Size = new System.Drawing.Size(800, 25);
            this.TLBMain.TabIndex = 0;
            this.TLBMain.Text = "toolStrip1";
            // 
            // STSMain
            // 
            this.STSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.STSCurrent});
            this.STSMain.Location = new System.Drawing.Point(0, 428);
            this.STSMain.Name = "STSMain";
            this.STSMain.Size = new System.Drawing.Size(800, 22);
            this.STSMain.SizingGrip = false;
            this.STSMain.TabIndex = 1;
            this.STSMain.Text = "statusStrip1";
            // 
            // TLMLine
            // 
            this.TLMLine.Name = "TLMLine";
            this.TLMLine.Size = new System.Drawing.Size(19, 22);
            this.TLMLine.Text = "선";
            this.TLMLine.Click += new System.EventHandler(this.TLMLine_Click);
            // 
            // TLMRectangle
            // 
            this.TLMRectangle.Name = "TLMRectangle";
            this.TLMRectangle.Size = new System.Drawing.Size(43, 22);
            this.TLMRectangle.Text = "사각형";
            this.TLMRectangle.Click += new System.EventHandler(this.TLMRectangle_Click);
            // 
            // TLMCircle
            // 
            this.TLMCircle.Name = "TLMCircle";
            this.TLMCircle.Size = new System.Drawing.Size(19, 22);
            this.TLMCircle.Text = "원";
            this.TLMCircle.Click += new System.EventHandler(this.TLMCircle_Click);
            // 
            // TLMCurvedLine
            // 
            this.TLMCurvedLine.Name = "TLMCurvedLine";
            this.TLMCurvedLine.Size = new System.Drawing.Size(31, 22);
            this.TLMCurvedLine.Text = "곡선";
            this.TLMCurvedLine.Click += new System.EventHandler(this.TLMCurvedLine_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TLMColor
            // 
            this.TLMColor.Name = "TLMColor";
            this.TLMColor.Size = new System.Drawing.Size(31, 22);
            this.TLMColor.Text = "색깔";
            this.TLMColor.Click += new System.EventHandler(this.TLMColor_Click);
            // 
            // STSCurrent
            // 
            this.STSCurrent.Name = "STSCurrent";
            this.STSCurrent.Size = new System.Drawing.Size(121, 17);
            this.STSCurrent.Text = "toolStripStatusLabel1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.STSMain);
            this.Controls.Add(this.TLBMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "그래픽 에디터";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            this.TLBMain.ResumeLayout(false);
            this.TLBMain.PerformLayout();
            this.STSMain.ResumeLayout(false);
            this.STSMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TLBMain;
        private System.Windows.Forms.StatusStrip STSMain;
        private System.Windows.Forms.ToolStripLabel TLMLine;
        private System.Windows.Forms.ToolStripLabel TLMRectangle;
        private System.Windows.Forms.ToolStripLabel TLMCircle;
        private System.Windows.Forms.ToolStripLabel TLMCurvedLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel TLMColor;
        private System.Windows.Forms.ToolStripStatusLabel STSCurrent;
    }
}

