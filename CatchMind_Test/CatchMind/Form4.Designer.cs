namespace CatchMind
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.rBtn_3pt = new System.Windows.Forms.RadioButton();
            this.rBtn_10pt = new System.Windows.Forms.RadioButton();
            this.rBtn_5pt = new System.Windows.Forms.RadioButton();
            this.rBtn_1pt = new System.Windows.Forms.RadioButton();
            this.label_eraser = new System.Windows.Forms.Label();
            this.panel_pic = new System.Windows.Forms.Panel();
            this.drawPicture = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.txtBox_id = new System.Windows.Forms.TextBox();
            this.panel_eraser = new System.Windows.Forms.Panel();
            this.panel_start = new System.Windows.Forms.Panel();
            this.lbl_start = new System.Windows.Forms.Label();
            this.panel_save = new System.Windows.Forms.Panel();
            this.lbl_save = new System.Windows.Forms.Label();
            this.panel_reset = new System.Windows.Forms.Panel();
            this.lbl_reset = new System.Windows.Forms.Label();
            this.panel_purple = new System.Windows.Forms.Panel();
            this.panel_navy = new System.Windows.Forms.Panel();
            this.panel_blue = new System.Windows.Forms.Panel();
            this.panel_black = new System.Windows.Forms.Panel();
            this.panel_green = new System.Windows.Forms.Panel();
            this.panel_red = new System.Windows.Forms.Panel();
            this.panel_yellow = new System.Windows.Forms.Panel();
            this.panel_orange = new System.Windows.Forms.Panel();
            this.panel_pic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawPicture)).BeginInit();
            this.panel_start.SuspendLayout();
            this.panel_save.SuspendLayout();
            this.panel_reset.SuspendLayout();
            this.SuspendLayout();
            // 
            // rBtn_3pt
            // 
            this.rBtn_3pt.AutoSize = true;
            this.rBtn_3pt.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_3pt.Font = new System.Drawing.Font("굴림", 12F);
            this.rBtn_3pt.ForeColor = System.Drawing.Color.White;
            this.rBtn_3pt.Location = new System.Drawing.Point(1885, 438);
            this.rBtn_3pt.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.rBtn_3pt.Name = "rBtn_3pt";
            this.rBtn_3pt.Size = new System.Drawing.Size(127, 44);
            this.rBtn_3pt.TabIndex = 14;
            this.rBtn_3pt.TabStop = true;
            this.rBtn_3pt.Text = "3 pt";
            this.rBtn_3pt.UseVisualStyleBackColor = false;
            this.rBtn_3pt.CheckedChanged += new System.EventHandler(this.rBtn_10pt_CheckedChanged);
            this.rBtn_3pt.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.rBtn_3pt.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // rBtn_10pt
            // 
            this.rBtn_10pt.AutoSize = true;
            this.rBtn_10pt.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_10pt.Font = new System.Drawing.Font("굴림", 12F);
            this.rBtn_10pt.ForeColor = System.Drawing.Color.White;
            this.rBtn_10pt.Location = new System.Drawing.Point(1885, 488);
            this.rBtn_10pt.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.rBtn_10pt.Name = "rBtn_10pt";
            this.rBtn_10pt.Size = new System.Drawing.Size(150, 44);
            this.rBtn_10pt.TabIndex = 13;
            this.rBtn_10pt.TabStop = true;
            this.rBtn_10pt.Text = "10 pt";
            this.rBtn_10pt.UseVisualStyleBackColor = false;
            this.rBtn_10pt.CheckedChanged += new System.EventHandler(this.rBtn_10pt_CheckedChanged);
            this.rBtn_10pt.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.rBtn_10pt.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // rBtn_5pt
            // 
            this.rBtn_5pt.AutoSize = true;
            this.rBtn_5pt.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_5pt.Font = new System.Drawing.Font("굴림", 12F);
            this.rBtn_5pt.ForeColor = System.Drawing.Color.White;
            this.rBtn_5pt.Location = new System.Drawing.Point(1707, 488);
            this.rBtn_5pt.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.rBtn_5pt.Name = "rBtn_5pt";
            this.rBtn_5pt.Size = new System.Drawing.Size(127, 44);
            this.rBtn_5pt.TabIndex = 12;
            this.rBtn_5pt.TabStop = true;
            this.rBtn_5pt.Text = "5 pt";
            this.rBtn_5pt.UseVisualStyleBackColor = false;
            this.rBtn_5pt.CheckedChanged += new System.EventHandler(this.rBtn_10pt_CheckedChanged);
            this.rBtn_5pt.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.rBtn_5pt.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // rBtn_1pt
            // 
            this.rBtn_1pt.AutoSize = true;
            this.rBtn_1pt.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_1pt.Font = new System.Drawing.Font("굴림", 12F);
            this.rBtn_1pt.ForeColor = System.Drawing.Color.White;
            this.rBtn_1pt.Location = new System.Drawing.Point(1707, 438);
            this.rBtn_1pt.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.rBtn_1pt.Name = "rBtn_1pt";
            this.rBtn_1pt.Size = new System.Drawing.Size(127, 44);
            this.rBtn_1pt.TabIndex = 11;
            this.rBtn_1pt.TabStop = true;
            this.rBtn_1pt.Text = "1 pt";
            this.rBtn_1pt.UseVisualStyleBackColor = false;
            this.rBtn_1pt.CheckedChanged += new System.EventHandler(this.rBtn_10pt_CheckedChanged);
            this.rBtn_1pt.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.rBtn_1pt.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // label_eraser
            // 
            this.label_eraser.AutoSize = true;
            this.label_eraser.BackColor = System.Drawing.Color.Transparent;
            this.label_eraser.Font = new System.Drawing.Font("굴림", 12F);
            this.label_eraser.ForeColor = System.Drawing.Color.White;
            this.label_eraser.Location = new System.Drawing.Point(1846, 818);
            this.label_eraser.Name = "label_eraser";
            this.label_eraser.Size = new System.Drawing.Size(137, 40);
            this.label_eraser.TabIndex = 54;
            this.label_eraser.Text = "지우개";
            this.label_eraser.Click += new System.EventHandler(this.Eraser_Click);
            this.label_eraser.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.label_eraser.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_pic
            // 
            this.panel_pic.BackColor = System.Drawing.Color.Transparent;
            this.panel_pic.Controls.Add(this.drawPicture);
            this.panel_pic.Location = new System.Drawing.Point(360, 90);
            this.panel_pic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_pic.Name = "panel_pic";
            this.panel_pic.Size = new System.Drawing.Size(1178, 938);
            this.panel_pic.TabIndex = 56;
            this.panel_pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_pic_MouseDown);
            this.panel_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_pic_MouseMove);
            this.panel_pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_pic_MouseUp);
            // 
            // drawPicture
            // 
            this.drawPicture.BackColor = System.Drawing.Color.White;
            this.drawPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPicture.Location = new System.Drawing.Point(0, 0);
            this.drawPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawPicture.Name = "drawPicture";
            this.drawPicture.Size = new System.Drawing.Size(1178, 938);
            this.drawPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.drawPicture.TabIndex = 55;
            this.drawPicture.TabStop = false;
            this.drawPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_pic_MouseDown);
            this.drawPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_pic_MouseMove);
            this.drawPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_pic_MouseUp);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("굴림", 15F);
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(1602, 210);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(172, 50);
            this.nameLabel.TabIndex = 57;
            this.nameLabel.Text = "닉네임";
            // 
            // txtBox_id
            // 
            this.txtBox_id.Font = new System.Drawing.Font("굴림", 12F);
            this.txtBox_id.Location = new System.Drawing.Point(1803, 228);
            this.txtBox_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_id.Name = "txtBox_id";
            this.txtBox_id.Size = new System.Drawing.Size(302, 53);
            this.txtBox_id.TabIndex = 58;
            // 
            // panel_eraser
            // 
            this.panel_eraser.BackColor = System.Drawing.Color.Transparent;
            this.panel_eraser.BackgroundImage = global::CatchMind.Properties.Resources.Eraser;
            this.panel_eraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_eraser.Location = new System.Drawing.Point(1746, 802);
            this.panel_eraser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_eraser.Name = "panel_eraser";
            this.panel_eraser.Size = new System.Drawing.Size(75, 68);
            this.panel_eraser.TabIndex = 51;
            this.panel_eraser.Click += new System.EventHandler(this.Eraser_Click);
            this.panel_eraser.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_eraser.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_start
            // 
            this.panel_start.BackColor = System.Drawing.Color.Transparent;
            this.panel_start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_start.BackgroundImage")));
            this.panel_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_start.Controls.Add(this.lbl_start);
            this.panel_start.Location = new System.Drawing.Point(1571, 1108);
            this.panel_start.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_start.Name = "panel_start";
            this.panel_start.Size = new System.Drawing.Size(332, 128);
            this.panel_start.TabIndex = 10;
            this.panel_start.Click += new System.EventHandler(this.Start_Click);
            this.panel_start.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_start.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // lbl_start
            // 
            this.lbl_start.AutoSize = true;
            this.lbl_start.BackColor = System.Drawing.Color.Transparent;
            this.lbl_start.Font = new System.Drawing.Font("굴림", 23F);
            this.lbl_start.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_start.Location = new System.Drawing.Point(72, 28);
            this.lbl_start.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(199, 77);
            this.lbl_start.TabIndex = 2;
            this.lbl_start.Text = "Start";
            this.lbl_start.Click += new System.EventHandler(this.Start_Click);
            this.lbl_start.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.lbl_start.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_save
            // 
            this.panel_save.BackColor = System.Drawing.Color.Transparent;
            this.panel_save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_save.BackgroundImage")));
            this.panel_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_save.Controls.Add(this.lbl_save);
            this.panel_save.Location = new System.Drawing.Point(1062, 1108);
            this.panel_save.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_save.Name = "panel_save";
            this.panel_save.Size = new System.Drawing.Size(301, 128);
            this.panel_save.TabIndex = 9;
            this.panel_save.Click += new System.EventHandler(this.Save_Click);
            this.panel_save.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_save.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // lbl_save
            // 
            this.lbl_save.AutoSize = true;
            this.lbl_save.BackColor = System.Drawing.Color.Transparent;
            this.lbl_save.Font = new System.Drawing.Font("굴림", 23F);
            this.lbl_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_save.Location = new System.Drawing.Point(62, 28);
            this.lbl_save.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbl_save.Name = "lbl_save";
            this.lbl_save.Size = new System.Drawing.Size(208, 77);
            this.lbl_save.TabIndex = 1;
            this.lbl_save.Text = "Save";
            this.lbl_save.Click += new System.EventHandler(this.Save_Click);
            this.lbl_save.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.lbl_save.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_reset
            // 
            this.panel_reset.BackColor = System.Drawing.Color.Transparent;
            this.panel_reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_reset.BackgroundImage")));
            this.panel_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_reset.Controls.Add(this.lbl_reset);
            this.panel_reset.Location = new System.Drawing.Point(555, 1108);
            this.panel_reset.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_reset.Name = "panel_reset";
            this.panel_reset.Size = new System.Drawing.Size(301, 128);
            this.panel_reset.TabIndex = 8;
            this.panel_reset.Click += new System.EventHandler(this.lbl_reset_Click);
            this.panel_reset.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_reset.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // lbl_reset
            // 
            this.lbl_reset.AutoSize = true;
            this.lbl_reset.BackColor = System.Drawing.Color.Transparent;
            this.lbl_reset.Font = new System.Drawing.Font("굴림", 23F);
            this.lbl_reset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_reset.Location = new System.Drawing.Point(54, 28);
            this.lbl_reset.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbl_reset.Name = "lbl_reset";
            this.lbl_reset.Size = new System.Drawing.Size(236, 77);
            this.lbl_reset.TabIndex = 0;
            this.lbl_reset.Text = "Reset";
            this.lbl_reset.Click += new System.EventHandler(this.lbl_reset_Click);
            this.lbl_reset.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.lbl_reset.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_purple
            // 
            this.panel_purple.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_purple.BackgroundImage")));
            this.panel_purple.Location = new System.Drawing.Point(1962, 695);
            this.panel_purple.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_purple.Name = "panel_purple";
            this.panel_purple.Size = new System.Drawing.Size(100, 72);
            this.panel_purple.TabIndex = 12;
            this.panel_purple.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_purple.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_purple.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_navy
            // 
            this.panel_navy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_navy.BackgroundImage")));
            this.panel_navy.Location = new System.Drawing.Point(1846, 695);
            this.panel_navy.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_navy.Name = "panel_navy";
            this.panel_navy.Size = new System.Drawing.Size(100, 72);
            this.panel_navy.TabIndex = 13;
            this.panel_navy.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_navy.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_navy.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_blue
            // 
            this.panel_blue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_blue.BackgroundImage")));
            this.panel_blue.Location = new System.Drawing.Point(1733, 695);
            this.panel_blue.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_blue.Name = "panel_blue";
            this.panel_blue.Size = new System.Drawing.Size(100, 72);
            this.panel_blue.TabIndex = 14;
            this.panel_blue.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_blue.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_blue.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_black
            // 
            this.panel_black.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_black.BackgroundImage")));
            this.panel_black.Location = new System.Drawing.Point(1617, 610);
            this.panel_black.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_black.Name = "panel_black";
            this.panel_black.Size = new System.Drawing.Size(100, 72);
            this.panel_black.TabIndex = 11;
            this.panel_black.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_black.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_black.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_green
            // 
            this.panel_green.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_green.BackgroundImage")));
            this.panel_green.Location = new System.Drawing.Point(1617, 695);
            this.panel_green.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_green.Name = "panel_green";
            this.panel_green.Size = new System.Drawing.Size(100, 72);
            this.panel_green.TabIndex = 15;
            this.panel_green.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_green.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_green.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_red
            // 
            this.panel_red.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_red.BackgroundImage")));
            this.panel_red.Location = new System.Drawing.Point(1733, 610);
            this.panel_red.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_red.Name = "panel_red";
            this.panel_red.Size = new System.Drawing.Size(100, 72);
            this.panel_red.TabIndex = 18;
            this.panel_red.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_red.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_red.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_yellow
            // 
            this.panel_yellow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_yellow.BackgroundImage")));
            this.panel_yellow.Location = new System.Drawing.Point(1962, 610);
            this.panel_yellow.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_yellow.Name = "panel_yellow";
            this.panel_yellow.Size = new System.Drawing.Size(100, 72);
            this.panel_yellow.TabIndex = 16;
            this.panel_yellow.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_yellow.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_yellow.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // panel_orange
            // 
            this.panel_orange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_orange.BackgroundImage")));
            this.panel_orange.Location = new System.Drawing.Point(1846, 610);
            this.panel_orange.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panel_orange.Name = "panel_orange";
            this.panel_orange.Size = new System.Drawing.Size(100, 72);
            this.panel_orange.TabIndex = 17;
            this.panel_orange.Click += new System.EventHandler(this.panel_black_Click);
            this.panel_orange.MouseEnter += new System.EventHandler(this.cursor_MouseEnter);
            this.panel_orange.MouseLeave += new System.EventHandler(this.cursor_MouseLeave);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2329, 1280);
            this.Controls.Add(this.txtBox_id);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.panel_pic);
            this.Controls.Add(this.label_eraser);
            this.Controls.Add(this.panel_eraser);
            this.Controls.Add(this.panel_start);
            this.Controls.Add(this.rBtn_3pt);
            this.Controls.Add(this.panel_save);
            this.Controls.Add(this.rBtn_10pt);
            this.Controls.Add(this.rBtn_5pt);
            this.Controls.Add(this.panel_reset);
            this.Controls.Add(this.rBtn_1pt);
            this.Controls.Add(this.panel_purple);
            this.Controls.Add(this.panel_navy);
            this.Controls.Add(this.panel_blue);
            this.Controls.Add(this.panel_black);
            this.Controls.Add(this.panel_green);
            this.Controls.Add(this.panel_red);
            this.Controls.Add(this.panel_yellow);
            this.Controls.Add(this.panel_orange);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(50, 50);
            this.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Catch Mind";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel_pic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawPicture)).EndInit();
            this.panel_start.ResumeLayout(false);
            this.panel_start.PerformLayout();
            this.panel_save.ResumeLayout(false);
            this.panel_save.PerformLayout();
            this.panel_reset.ResumeLayout(false);
            this.panel_reset.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_black;
        private System.Windows.Forms.Panel panel_red;
        private System.Windows.Forms.Panel panel_orange;
        private System.Windows.Forms.Panel panel_yellow;
        private System.Windows.Forms.Panel panel_green;
        private System.Windows.Forms.Panel panel_blue;
        private System.Windows.Forms.Panel panel_navy;
        private System.Windows.Forms.Panel panel_purple;
        private System.Windows.Forms.Panel panel_save;
        private System.Windows.Forms.Label lbl_save;
        private System.Windows.Forms.Panel panel_reset;
        private System.Windows.Forms.Label lbl_reset;
        private System.Windows.Forms.Panel panel_start;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.RadioButton rBtn_3pt;
        private System.Windows.Forms.RadioButton rBtn_10pt;
        private System.Windows.Forms.RadioButton rBtn_5pt;
        private System.Windows.Forms.RadioButton rBtn_1pt;
        private System.Windows.Forms.Label label_eraser;
        private System.Windows.Forms.Panel panel_eraser;
        private System.Windows.Forms.PictureBox drawPicture;
        private System.Windows.Forms.Panel panel_pic;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox txtBox_id;
    }
}