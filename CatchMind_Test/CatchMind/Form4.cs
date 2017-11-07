using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using socketProtocol_Library;
using System.IO;

namespace CatchMind
{
    public partial class Form4 : Form
    {
        // 통신
        TcpClient clientSocket;
        NetworkStream stream = default(NetworkStream);
        private byte[] sendbuffer = new byte[1024 * 4];
        private byte[] readbuffer = new byte[1024 * 4];

        // 그리기
        bool isDrag = false;        // 마우스 움직임 여부
        Point previousPoint;        // 마우스 이동 전 x, y 좌표
        int setTool = 0;            // 팬 굵기
        int setColor = 0;           // 팬 색깔
        int prevTool = 0;           // 지우개 선택 전 팬 굵기
        int prevColor = 0;          // 지우개 선택 전 팬 색깔
        bool eraser = false;        // 지우개 선택 여부
        Pen currentPen;             // 현재 팬 설정(굵기, 색깔)
        Bitmap bitmap;              // 그림 그리고 저장할 비트맵
        Graphics g;                 // 그림 그려주는 개체

        private Form2 frm2 = null;
        private Form3 frm3 = null;

        public Form4(Form2 frm2)
        {
            InitializeComponent();
            this.frm2 = frm2;
            clientSocket = frm2.SetSocket();
        }

        public Form4(Form3 frm3)
        {
            InitializeComponent();
            this.frm3 = frm3;
            clientSocket = frm3.SetSocket();
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.BackgroundImage = Properties.Resources.BackgroundImage;
            SetFont();

            bitmap = new Bitmap(this.panel_pic.Width, this.panel_pic.Height);   // panel 크기 만큼의 비트맵 생성
            g = Graphics.FromImage(bitmap);                 // bit맵 위에 그림을 그림
        }

        private void cursor_MouseEnter(object sender, EventArgs e) { Cursor = Cursors.Hand; }
        private void cursor_MouseLeave(object sender, EventArgs e) { Cursor = Cursors.Arrow; }
        void bufferReset(byte[] buffer) { for (int i = 0; i < 1024 * 4; i++) buffer[i] = 0; }
        public TcpClient SetSocket() { return clientSocket; }
        //public string setNicname() { return txtBox_id.Text; }
        private void resetBuffer(byte[] buffer) { for (int i = 0; i < 1024 * 4; i++) buffer[i] = 0; }

        private void SetFont()
        {
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Environment.CurrentDirectory + "\\Font\\야놀자 야체 Regular.ttf");
            Font font12 = new Font(privateFonts.Families[0], 12f);
            Font font23 = new Font(privateFonts.Families[0], 23f);
            txtBox_id.Font = font12;
            rBtn_1pt.Font = font12;
            rBtn_3pt.Font = font12;
            rBtn_5pt.Font = font12;
            rBtn_10pt.Font = font12;
            label_eraser.Font = font12;
            nameLabel.Font = font23;
            lbl_reset.Font = font23;
            lbl_save.Font = font23;
            lbl_start.Font = font23;
        }

        private void rBtn_10pt_CheckedChanged(object sender, EventArgs e)       // 팬 굵기 설정
        {
            RadioButton selectedRadioButton = (RadioButton)sender;
            switch (selectedRadioButton.Name)
            {
                case "rBtn_1pt":
                    setTool = 1;
                    break;
                case "rBtn_3pt":
                    setTool = 2;
                    break;
                case "rBtn_5pt":
                    setTool = 3;
                    break;
                case "rBtn_10pt":
                    setTool = 4;
                    break;
            }
        }

        private void panel_black_Click(object sender, EventArgs e)          // 팬 색깔 설정
        {
            Panel selectedColor = (Panel)sender;
            if (eraser == true)         // 지우개가 선택되었었으면 이전의 설정 유지
            {
                eraser = false;
                rBtn_1pt.Checked = false;
                rBtn_3pt.Checked = false;
                rBtn_5pt.Checked = false;
                rBtn_10pt.Checked = false;
                setTool = prevTool;

                if (setTool == 0)
                    rBtn_1pt.Checked = true;
                else if (setTool == 1)
                    rBtn_1pt.Checked = true;
                else if (setTool == 2)
                    rBtn_3pt.Checked = true;
                else if (setTool == 3)
                    rBtn_5pt.Checked = true;
                else if (setTool == 4)
                    rBtn_10pt.Checked = true;
            }

            switch (selectedColor.Name)
            {
                case "panel_black":
                    setColor = 0;
                    break;
                case "panel_red":
                    setColor = 1;
                    break;
                case "panel_orange":
                    setColor = 2;
                    break;
                case "panel_yellow":
                    setColor = 3;
                    break;
                case "panel_green":
                    setColor = 4;
                    break;
                case "panel_blue":
                    setColor = 5;
                    break;
                case "panel_navy":
                    setColor = 6;
                    break;
                case "panel_purple":
                    setColor = 7;
                    break;
            }
        }

        private void panel_pic_MouseDown(object sender, MouseEventArgs e)       // 마우스 이동시 발생하는 handler, 마우스 이동 전 좌표를 저장
        {
            isDrag = true;
            previousPoint = new Point(e.X, e.Y);
            Cursor = Cursors.Cross;
        }

        private void panel_pic_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            Cursor = Cursors.Arrow;
        }

        private void panel_pic_MouseMove(object sender, MouseEventArgs e)       // 그리기
        {
            if (isDrag == true)
            {
                Point currentPoint = new Point(e.X, e.Y);
                if (setColor == 0)
                    currentPen = new Pen(Color.Black);
                else if (setColor == 1)
                    currentPen = new Pen(Color.Red);
                else if (setColor == 2)
                    currentPen = new Pen(Color.Orange);
                else if (setColor == 3)
                    currentPen = new Pen(Color.Yellow);
                else if (setColor == 4)
                    currentPen = new Pen(Color.Green);
                else if (setColor == 5)
                    currentPen = new Pen(Color.Blue);
                else if (setColor == 6)
                    currentPen = new Pen(Color.Navy);
                else if (setColor == 7)
                    currentPen = new Pen(Color.Purple);
                else if (setColor == 8)
                    currentPen = new Pen(Color.White);

                if (setTool == 0)
                    currentPen.Width = 1;
                else if (setTool == 1)
                    currentPen.Width = 1;
                else if (setTool == 2)
                    currentPen.Width = 3;
                else if (setTool == 3)
                    currentPen.Width = 5;
                else if (setTool == 4)
                    currentPen.Width = 10;

                /* panel위에 그림을 그린다. panel위에 그림을 그리면 bitmap에는 잘 그려지는데
                 * 그림 그리는 행위? motion?이 panel에 출력이 안되서 panel을 투명하게 설정하고
                 * panel뒤에 picture box를 숨겨놓고 그려진 그래프를 bitmap에 저장해놓고
                 * picture box에 bitmap을 뿌려주면 panel에 그림 그리고 출력까지 되는 것처럼 보인다.
                 * 죄송해요 설명고자라!!!!*/
                g.DrawLine(currentPen, previousPoint, currentPoint);    // 이전 좌표와 현재 좌표를 가지고 그리기
                previousPoint = currentPoint;
                drawPicture.Image = bitmap;     // bitmap에 그려진 걸 picture box에 뿌려준다.
            }
        }

        private void lbl_reset_Click(object sender, EventArgs e)        // 전체 지우기
        {
            panel_pic.Invalidate();
            g.Clear(Color.White);
            drawPicture.Image = bitmap;
        }

        private void Eraser_Click(object sender, EventArgs e)       // 지우개
        {
            prevColor = setColor;
            prevTool = setTool;
            eraser = true;
            setColor = 8;
            setTool = 4;
            rBtn_1pt.Checked = false;
            rBtn_3pt.Checked = false;
            rBtn_5pt.Checked = false;
            rBtn_10pt.Checked = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            panel_pic.DrawToBitmap(bitmap, new Rectangle(0, 0, panel_pic.Width, panel_pic.Height));
            bitmap.Save(Environment.CurrentDirectory + "\\UserImage\\userPic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("저장되었습니다.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            string filepath = Environment.CurrentDirectory + "\\UserImage\\userPic.jpg";
            FileInfo file = new FileInfo(filepath);

            if (txtBox_id.Text == "")
                MessageBox.Show("닉네임을 입력해주세요.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            else if (!file.Exists)
                MessageBox.Show("그림을 저장해주세요.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            else
            {
                sendNickname();
                this.Hide();
                Form5 form5 = new Form5(this);
                form5.ShowDialog();
                this.Close();
            }
        }

        private void sendNickname()       //서버에 닉네임, 사진 전송
        {
            stream = clientSocket.GetStream();

            /////////////////////////////////   닉네임 전송   ////////////////////////////////
            ClientProfile clientProfile = new ClientProfile();
            clientProfile.Type = (int)PacketType.닉네임;
            clientProfile.nickName = txtBox_id.Text;
            Packet.Serialize(clientProfile).CopyTo(this.sendbuffer, 0);
            stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
            this.stream.Flush();
            resetBuffer(sendbuffer);
            //////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////   프로필 사진 전송   //////////////////////////////
            clientProfile = new ClientProfile();
            FileInfo file = new FileInfo(Environment.CurrentDirectory + "\\UserImage\\userPic.jpg");
            FileStream fileStrm = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fileStrm);
            int count = (int)(file.Length) / (1024) + 1;

            for (int i = 0; i < count; i++)
            {
                clientProfile.buffer = reader.ReadBytes(1024);
                clientProfile.count = count;
                clientProfile.nickName = txtBox_id.Text;
                clientProfile.Type = (int)PacketType.프로필;

                Packet.Serialize(clientProfile).CopyTo(this.sendbuffer, 0);
                stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
                this.stream.Flush();
                resetBuffer(sendbuffer);
            }
            fileStrm.Close();
            //////////////////////////////////////////////////////////////////////////////////
        }
    }
}