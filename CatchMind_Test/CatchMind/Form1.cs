using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CatchMind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(900, 550);        // Form Size 설정
            this.BackgroundImage = Properties.Resources.BackgroundImage;
            SetFont();
            
            // 이전에 그렸던 자기 자신 이미지 삭제
            string filepath = Environment.CurrentDirectory + "\\UserImage\\userPic.jpg";
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
                file.Delete();
        }

        private void cursor_MouseEnter(object sender, EventArgs e) { Cursor = Cursors.Hand; } // button 위에서 마우스 커서 모양 변경
        private void cursor_MouseLeave(object sender, EventArgs e) { Cursor = Cursors.Arrow; } // button 벗어나면 마우스 커서 변경

        private void SetFont()          // 글꼴 설정
        {
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Environment.CurrentDirectory + "\\Font\\야놀자 야체 Regular.ttf");
            Font font23 = new Font(privateFonts.Families[0], 23f);
            hostLabel.Font = font23;
            guestLabel.Font = font23;
        }

        private void host_Click(object sender, EventArgs e)     // Form1 닫고 Form2로 변경
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void guest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }
    }
}
