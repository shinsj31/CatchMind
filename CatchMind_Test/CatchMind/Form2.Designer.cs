namespace CatchMind
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.numLabel = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.okPanel = new System.Windows.Forms.Panel();
            this.okLabel = new System.Windows.Forms.Label();
            this.catchmind2 = new System.Windows.Forms.Panel();
            this.backPanel = new System.Windows.Forms.Panel();
            this.backLabel = new System.Windows.Forms.Label();
            this.okPanel.SuspendLayout();
            this.backPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // numLabel
            // 
            this.numLabel.AutoSize = true;
            this.numLabel.BackColor = System.Drawing.Color.Transparent;
            this.numLabel.Font = new System.Drawing.Font("굴림", 23F);
            this.numLabel.ForeColor = System.Drawing.Color.White;
            this.numLabel.Location = new System.Drawing.Point(958, 763);
            this.numLabel.Name = "numLabel";
            this.numLabel.Size = new System.Drawing.Size(187, 77);
            this.numLabel.TabIndex = 7;
            this.numLabel.Text = "인원";
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("굴림", 9F);
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.comboBox.Location = new System.Drawing.Point(1119, 787);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(274, 38);
            this.comboBox.TabIndex = 6;
            // 
            // okPanel
            // 
            this.okPanel.BackColor = System.Drawing.Color.Transparent;
            this.okPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okPanel.BackgroundImage")));
            this.okPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okPanel.Controls.Add(this.okLabel);
            this.okPanel.Location = new System.Drawing.Point(1291, 947);
            this.okPanel.Name = "okPanel";
            this.okPanel.Size = new System.Drawing.Size(323, 111);
            this.okPanel.TabIndex = 9;
            this.okPanel.Click += new System.EventHandler(this.OK_Click);
            this.okPanel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.okPanel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // okLabel
            // 
            this.okLabel.AutoSize = true;
            this.okLabel.BackColor = System.Drawing.Color.Transparent;
            this.okLabel.Font = new System.Drawing.Font("굴림", 23F);
            this.okLabel.ForeColor = System.Drawing.Color.White;
            this.okLabel.Location = new System.Drawing.Point(96, 16);
            this.okLabel.Name = "okLabel";
            this.okLabel.Size = new System.Drawing.Size(141, 77);
            this.okLabel.TabIndex = 13;
            this.okLabel.Text = "OK";
            this.okLabel.Click += new System.EventHandler(this.OK_Click);
            this.okLabel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.okLabel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // catchmind2
            // 
            this.catchmind2.BackColor = System.Drawing.Color.Transparent;
            this.catchmind2.BackgroundImage = global::CatchMind.Properties.Resources.CatchMind;
            this.catchmind2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.catchmind2.Location = new System.Drawing.Point(866, 305);
            this.catchmind2.Name = "catchmind2";
            this.catchmind2.Size = new System.Drawing.Size(649, 296);
            this.catchmind2.TabIndex = 12;
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.Transparent;
            this.backPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backPanel.BackgroundImage")));
            this.backPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backPanel.Controls.Add(this.backLabel);
            this.backPanel.Location = new System.Drawing.Point(793, 947);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(323, 111);
            this.backPanel.TabIndex = 14;
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
            this.backLabel.Location = new System.Drawing.Point(69, 18);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(239, 77);
            this.backLabel.TabIndex = 13;
            this.backLabel.Text = "BACK";
            this.backLabel.Click += new System.EventHandler(this.Back_Click);
            this.backLabel.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.backLabel.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2333, 1152);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.catchmind2);
            this.Controls.Add(this.okPanel);
            this.Controls.Add(this.numLabel);
            this.Controls.Add(this.comboBox);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Catch Mind";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.okPanel.ResumeLayout(false);
            this.okPanel.PerformLayout();
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label numLabel;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Panel okPanel;
        private System.Windows.Forms.Panel catchmind2;
        private System.Windows.Forms.Label okLabel;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Label backLabel;
    }
}