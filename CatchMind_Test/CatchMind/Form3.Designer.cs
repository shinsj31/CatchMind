namespace CatchMind
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.CatchMind = new System.Windows.Forms.Panel();
            this.backPanel = new System.Windows.Forms.Panel();
            this.backLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_max3 = new System.Windows.Forms.Label();
            this.count3 = new System.Windows.Forms.Label();
            this.roomList3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_max2 = new System.Windows.Forms.Label();
            this.count2 = new System.Windows.Forms.Label();
            this.roomList2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_max1 = new System.Windows.Forms.Label();
            this.count1 = new System.Windows.Forms.Label();
            this.roomList1 = new System.Windows.Forms.Label();
            this.backPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CatchMind
            // 
            this.CatchMind.BackColor = System.Drawing.Color.Transparent;
            this.CatchMind.BackgroundImage = global::CatchMind.Properties.Resources.CatchMind;
            this.CatchMind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CatchMind.Location = new System.Drawing.Point(626, 104);
            this.CatchMind.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.CatchMind.Name = "CatchMind";
            this.CatchMind.Size = new System.Drawing.Size(468, 236);
            this.CatchMind.TabIndex = 5;
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.Transparent;
            this.backPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backPanel.BackgroundImage")));
            this.backPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backPanel.Controls.Add(this.backLabel);
            this.backPanel.Location = new System.Drawing.Point(767, 906);
            this.backPanel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(234, 90);
            this.backPanel.TabIndex = 16;
            this.backPanel.Click += new System.EventHandler(this.Back_Click);
            this.backPanel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.backPanel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // backLabel
            // 
            this.backLabel.AutoSize = true;
            this.backLabel.BackColor = System.Drawing.Color.Transparent;
            this.backLabel.Font = new System.Drawing.Font("굴림", 23F);
            this.backLabel.ForeColor = System.Drawing.Color.White;
            this.backLabel.Location = new System.Drawing.Point(50, 14);
            this.backLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(193, 62);
            this.backLabel.TabIndex = 13;
            this.backLabel.Text = "BACK";
            this.backLabel.Click += new System.EventHandler(this.Back_Click);
            this.backLabel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.backLabel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lbl_max3);
            this.panel3.Controls.Add(this.count3);
            this.panel3.Controls.Add(this.roomList3);
            this.panel3.Location = new System.Drawing.Point(466, 764);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 110);
            this.panel3.TabIndex = 19;
            this.panel3.Click += new System.EventHandler(this.Room_Click);
            this.panel3.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel3.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "/";
            this.label3.Click += new System.EventHandler(this.Room_Click);
            // 
            // lbl_max3
            // 
            this.lbl_max3.AutoSize = true;
            this.lbl_max3.Location = new System.Drawing.Point(687, 32);
            this.lbl_max3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_max3.Name = "lbl_max3";
            this.lbl_max3.Size = new System.Drawing.Size(0, 24);
            this.lbl_max3.TabIndex = 3;
            this.lbl_max3.Click += new System.EventHandler(this.Room_Click);
            this.lbl_max3.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.lbl_max3.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // count3
            // 
            this.count3.AutoSize = true;
            this.count3.BackColor = System.Drawing.Color.Transparent;
            this.count3.ForeColor = System.Drawing.Color.Black;
            this.count3.Location = new System.Drawing.Point(623, 32);
            this.count3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.count3.Name = "count3";
            this.count3.Size = new System.Drawing.Size(0, 24);
            this.count3.TabIndex = 3;
            this.count3.Click += new System.EventHandler(this.Room_Click);
            this.count3.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.count3.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // roomList3
            // 
            this.roomList3.AutoSize = true;
            this.roomList3.BackColor = System.Drawing.Color.Transparent;
            this.roomList3.ForeColor = System.Drawing.Color.Black;
            this.roomList3.Location = new System.Drawing.Point(143, 32);
            this.roomList3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.roomList3.Name = "roomList3";
            this.roomList3.Size = new System.Drawing.Size(170, 24);
            this.roomList3.TabIndex = 2;
            this.roomList3.Text = "방이 없습니다.";
            this.roomList3.Click += new System.EventHandler(this.Room_Click);
            this.roomList3.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.roomList3.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbl_max2);
            this.panel2.Controls.Add(this.count2);
            this.panel2.Controls.Add(this.roomList2);
            this.panel2.Location = new System.Drawing.Point(466, 606);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 110);
            this.panel2.TabIndex = 18;
            this.panel2.Click += new System.EventHandler(this.Room_Click);
            this.panel2.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "/";
            this.label2.Click += new System.EventHandler(this.Room_Click);
            // 
            // lbl_max2
            // 
            this.lbl_max2.AutoSize = true;
            this.lbl_max2.Location = new System.Drawing.Point(687, 34);
            this.lbl_max2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_max2.Name = "lbl_max2";
            this.lbl_max2.Size = new System.Drawing.Size(0, 24);
            this.lbl_max2.TabIndex = 3;
            this.lbl_max2.Click += new System.EventHandler(this.Room_Click);
            this.lbl_max2.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.lbl_max2.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // count2
            // 
            this.count2.AutoSize = true;
            this.count2.BackColor = System.Drawing.Color.Transparent;
            this.count2.ForeColor = System.Drawing.Color.Black;
            this.count2.Location = new System.Drawing.Point(623, 34);
            this.count2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.count2.Name = "count2";
            this.count2.Size = new System.Drawing.Size(0, 24);
            this.count2.TabIndex = 2;
            this.count2.Click += new System.EventHandler(this.Room_Click);
            this.count2.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.count2.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // roomList2
            // 
            this.roomList2.AutoSize = true;
            this.roomList2.BackColor = System.Drawing.Color.Transparent;
            this.roomList2.ForeColor = System.Drawing.Color.Black;
            this.roomList2.Location = new System.Drawing.Point(143, 34);
            this.roomList2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.roomList2.Name = "roomList2";
            this.roomList2.Size = new System.Drawing.Size(170, 24);
            this.roomList2.TabIndex = 1;
            this.roomList2.Text = "방이 없습니다.";
            this.roomList2.Click += new System.EventHandler(this.Room_Click);
            this.roomList2.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.roomList2.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_max1);
            this.panel1.Controls.Add(this.count1);
            this.panel1.Controls.Add(this.roomList1);
            this.panel1.Location = new System.Drawing.Point(466, 450);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 110);
            this.panel1.TabIndex = 17;
            this.panel1.Click += new System.EventHandler(this.Room_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "/";
            this.label1.Click += new System.EventHandler(this.Room_Click);
            // 
            // lbl_max1
            // 
            this.lbl_max1.AutoSize = true;
            this.lbl_max1.Location = new System.Drawing.Point(687, 34);
            this.lbl_max1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_max1.Name = "lbl_max1";
            this.lbl_max1.Size = new System.Drawing.Size(0, 24);
            this.lbl_max1.TabIndex = 2;
            this.lbl_max1.Click += new System.EventHandler(this.Room_Click);
            this.lbl_max1.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.lbl_max1.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // count1
            // 
            this.count1.AutoSize = true;
            this.count1.BackColor = System.Drawing.Color.Transparent;
            this.count1.ForeColor = System.Drawing.Color.Black;
            this.count1.Location = new System.Drawing.Point(623, 34);
            this.count1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.count1.Name = "count1";
            this.count1.Size = new System.Drawing.Size(0, 24);
            this.count1.TabIndex = 1;
            this.count1.Click += new System.EventHandler(this.Room_Click);
            this.count1.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.count1.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // roomList1
            // 
            this.roomList1.AutoSize = true;
            this.roomList1.BackColor = System.Drawing.Color.Transparent;
            this.roomList1.ForeColor = System.Drawing.Color.Black;
            this.roomList1.Location = new System.Drawing.Point(143, 34);
            this.roomList1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.roomList1.Name = "roomList1";
            this.roomList1.Size = new System.Drawing.Size(170, 24);
            this.roomList1.TabIndex = 0;
            this.roomList1.Text = "방이 없습니다.";
            this.roomList1.Click += new System.EventHandler(this.Room_Click);
            this.roomList1.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.roomList1.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1649, 1134);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.CatchMind);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(50, 50);
            this.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Catch Mind";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel CatchMind;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_max3;
        private System.Windows.Forms.Label count3;
        private System.Windows.Forms.Label roomList3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_max2;
        private System.Windows.Forms.Label count2;
        private System.Windows.Forms.Label roomList2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_max1;
        private System.Windows.Forms.Label count1;
        private System.Windows.Forms.Label roomList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}