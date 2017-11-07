namespace CatchMind
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.catchmind = new System.Windows.Forms.Panel();
            this.hostPanel = new System.Windows.Forms.Panel();
            this.hostLabel = new System.Windows.Forms.Label();
            this.guestPanel = new System.Windows.Forms.Panel();
            this.guestLabel = new System.Windows.Forms.Label();
            this.hostPanel.SuspendLayout();
            this.guestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // catchmind
            // 
            this.catchmind.BackColor = System.Drawing.Color.Transparent;
            this.catchmind.BackgroundImage = global::CatchMind.Properties.Resources.CatchMind;
            this.catchmind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.catchmind.Location = new System.Drawing.Point(866, 305);
            this.catchmind.Name = "catchmind";
            this.catchmind.Size = new System.Drawing.Size(649, 296);
            this.catchmind.TabIndex = 0;
            // 
            // hostPanel
            // 
            this.hostPanel.BackColor = System.Drawing.Color.Transparent;
            this.hostPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hostPanel.BackgroundImage")));
            this.hostPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hostPanel.Controls.Add(this.hostLabel);
            this.hostPanel.Location = new System.Drawing.Point(1025, 786);
            this.hostPanel.Name = "hostPanel";
            this.hostPanel.Size = new System.Drawing.Size(326, 117);
            this.hostPanel.TabIndex = 0;
            this.hostPanel.Click += new System.EventHandler(this.host_Click);
            this.hostPanel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.hostPanel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.BackColor = System.Drawing.Color.Transparent;
            this.hostLabel.Font = new System.Drawing.Font("굴림", 23F);
            this.hostLabel.ForeColor = System.Drawing.Color.White;
            this.hostLabel.Location = new System.Drawing.Point(64, 22);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(200, 77);
            this.hostLabel.TabIndex = 1;
            this.hostLabel.Tag = "";
            this.hostLabel.Text = "Host";
            this.hostLabel.Click += new System.EventHandler(this.host_Click);
            this.hostLabel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.hostLabel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // guestPanel
            // 
            this.guestPanel.BackColor = System.Drawing.Color.Transparent;
            this.guestPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guestPanel.BackgroundImage")));
            this.guestPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guestPanel.Controls.Add(this.guestLabel);
            this.guestPanel.Location = new System.Drawing.Point(1025, 969);
            this.guestPanel.Name = "guestPanel";
            this.guestPanel.Size = new System.Drawing.Size(326, 114);
            this.guestPanel.TabIndex = 0;
            this.guestPanel.Click += new System.EventHandler(this.guest_Click);
            this.guestPanel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.guestPanel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // guestLabel
            // 
            this.guestLabel.AutoSize = true;
            this.guestLabel.BackColor = System.Drawing.Color.Transparent;
            this.guestLabel.Font = new System.Drawing.Font("굴림", 23F);
            this.guestLabel.ForeColor = System.Drawing.Color.Transparent;
            this.guestLabel.Location = new System.Drawing.Point(55, 19);
            this.guestLabel.Name = "guestLabel";
            this.guestLabel.Size = new System.Drawing.Size(244, 77);
            this.guestLabel.TabIndex = 2;
            this.guestLabel.Tag = "";
            this.guestLabel.Text = "Guest";
            this.guestLabel.Click += new System.EventHandler(this.guest_Click);
            this.guestLabel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.guestLabel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2333, 1152);
            this.Controls.Add(this.guestPanel);
            this.Controls.Add(this.hostPanel);
            this.Controls.Add(this.catchmind);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CatchMind";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.hostPanel.ResumeLayout(false);
            this.hostPanel.PerformLayout();
            this.guestPanel.ResumeLayout(false);
            this.guestPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel catchmind;
        private System.Windows.Forms.Panel hostPanel;
        private System.Windows.Forms.Panel guestPanel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label guestLabel;
    }
}

