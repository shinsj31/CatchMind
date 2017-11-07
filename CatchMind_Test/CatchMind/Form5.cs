using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using socketProtocol_Library;
using System.IO;
using MySql.Data.MySqlClient;

namespace CatchMind
{
    public partial class Form5 : Form
    {
        // 통신   
        TcpClient clientSocket;
        NetworkStream stream = default(NetworkStream);
        FileStream fileStrm = null;
        string filepath = Environment.CurrentDirectory + "\\UserImage\\";
        int countRead = 0;

        private byte[] sendbuffer = new byte[1024 * 4];
        private byte[] readbuffer = new byte[1024 * 4];

        private Form4 frm4 = null;

        // 그리기
        bool isDrag = false;
        Point previousPoint;
        int setTool = 0;
        int setColor = 0;
        int prevTool = 0;
        int prevColor = 0;
        bool eraser = false;
        Pen currentPen;
        Bitmap bitmap;
        Graphics g;

        // 게임
        const int PlayTime = 15;    // 주어진 시간 60초
        public int client_number = 0;      // 자신의 클라이언트 번호 저장
        ArrayList nickNameList = new ArrayList();
        int turnClientNum = 0;      // 현재 turn인 client의 번호
        int turnCount = 2;          // 남은 Turn 수(form에 표시되는 turn)
        bool lockDrawing = true;    // true : lock, false : unlock
        int timeSec = PlayTime;
        string answer = "";
        bool gameStart = false;
        
        public Form5(Form4 frm4)
        {
            InitializeComponent();
            this.frm4 = frm4;
            clientSocket = frm4.SetSocket();
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.BackgroundImage = Properties.Resources.BackgroundImage;
            SetFont();

            bitmap = new Bitmap(this.gamePanel.Width, this.gamePanel.Height);
            g = Graphics.FromImage(bitmap);

            settingTurnChange(-1);
            timer.Interval = 1000;      // 1초마다 handler 실행

            DisplayText("< Connected to Chat Server >", Color.Black);
            Thread t_handler = new Thread(GetRequest);  //서버에서 모든 클라이언트들 메세지 얻으려고 쓰레드 돌림
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        private void cursor_MouseEnter(object sender, EventArgs e) { Cursor = Cursors.Hand; }
        private void cursor_MouseLeave(object sender, EventArgs e) { Cursor = Cursors.Arrow; }
        public TcpClient SetSocket() { return clientSocket; }
        private void resetBuffer(byte[] buffer) { for (int i = 0; i < 1024 * 4; i++) buffer[i] = 0; }

        private void SetFont()
        {
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Environment.CurrentDirectory + "\\Font\\야놀자 야체 Regular.ttf");
            Font font12 = new Font(privateFonts.Families[0], 12f);
            Font font23 = new Font(privateFonts.Families[0], 23f);
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    if (c.Tag.ToString() == "12")
                        c.Font = font12;
                    else if (c.Tag.ToString() == "23")
                        c.Font = font23;
                }
                else if (c is RadioButton)
                    c.Font = font12;
            }
            richTextBox1.Font = font12;
            txtBox_user.Font = font12;
            answerLabel.Font = font12;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (nickNameList.Count < 1)
            {
                DisplayText("2명 이상일 때 플레이할 수 있습니다.", Color.Red);
                return;
            }

            GameState state = new GameState();
            state.Type = (int)PacketType.게임상태;

            state.gameStart = true;
            Packet.Serialize(state).CopyTo(this.sendbuffer, 0);
            stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
            this.stream.Flush();
            resetBuffer(sendbuffer);

            startButton.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)        // 남은 시간 표시
        {
            if (timeSec > 0)
            {
                timeSec--;
                int minute = timeSec / 60;
                int second = timeSec % 60;
                time.Text = string.Format("{0:0#} : {1:0#}", minute, second);
                return;
            }
            if (timeSec <= 0 && client_number == turnClientNum)          // 제한 시간 초과시 턴 변경 요청
            {
                TurnChange turnPacket = new TurnChange();
                turnPacket.Type = (int)PacketType.정답;

                turnPacket.turn = turnClientNum;
                turnPacket.clientNum = client_number;
                turnPacket.Correct = false;
                turnPacket.message = "***   제한 시간이 초과되었습니다.   ***";
                turnPacket.score = 0;
                turnPacket.turnCount = turnCount;
                Packet.Serialize(turnPacket).CopyTo(this.sendbuffer, 0);

                stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
                this.stream.Flush();
                resetBuffer(sendbuffer);
            }
        }
        ////////////////////////////////////////////////////   서버와의 통신   ////////////////////////////////////////////////////
        private void GetRequest()       //서버로부터 받은 요청을 처리하는 쓰레드 메소드
        {
            while (true)
            {
                stream = clientSocket.GetStream();  //스트림 읽음
                int bytes = stream.Read(this.readbuffer, 0, this.readbuffer.Length);

                Packet packet = (Packet)Packet.Deserialize(this.readbuffer);

                switch ((int)packet.Type)
                {
                    case (int)PacketType.메세지:
                        {
                            ClientMessage clientMessage = new ClientMessage();
                            clientMessage = (ClientMessage)Packet.Deserialize(this.readbuffer);
                            DisplayText(clientMessage.Message, Color.Black);   //텍스트창에 띄움
                            break;
                        }
                    case (int)PacketType.그림정보:
                        {
                            ClientDrawingInfo drawInfo = new ClientDrawingInfo();
                            drawInfo = (ClientDrawingInfo)Packet.Deserialize(this.readbuffer);
                            //로컬에서 테스트할때 이름 안 겹치게하려고..

                            fileStrm = new FileStream(filepath + "turnPic_" + client_number + ".jpg", FileMode.Create, FileAccess.Write);

                            break;
                        }
                    case (int)PacketType.그림:
                        {
                            ClientDrawing draw = new ClientDrawing();
                            draw = (ClientDrawing)Packet.Deserialize(this.readbuffer);
                            string fileName = null;
                            //클라이언트로부터 받은 파일을 쓴다.
                            if (fileStrm != null)
                            {
                                fileStrm.Write(draw.buffer, 0, draw.buffer.Length);
                                countRead++;
                                if (countRead == draw.count)
                                {
                                    fileName = fileStrm.Name;
                                    fileStrm.Close();
                                    fileStrm = null;
                                    countRead = 0;
                                    //picture박스에 그림표시해야함.
                                    FileStream fs = new FileStream(filepath + "turnPic_" + client_number + ".jpg", FileMode.Open, FileAccess.Read);
                                    gamePicture.Image = System.Drawing.Image.FromStream(fs);
                                    fs.Close();
                                }
                            }
                            break;
                        }
                    case (int)PacketType.프로필정보:
                        {
                            ClientProfileInfo profileInfo = new ClientProfileInfo();
                            profileInfo = (ClientProfileInfo)Packet.Deserialize(this.readbuffer);
                            fileStrm = new FileStream(filepath + client_number.ToString() + "-" + profileInfo.clientNum.ToString() + ".jpg", FileMode.Create, FileAccess.Write);
                            break;
                        }
                    case (int)PacketType.게임상태:
                        {
                            GameState statePacket = new GameState();
                            statePacket = (GameState)Packet.Deserialize(this.readbuffer);
                            DisplayText(statePacket.message, Color.Red);
                            gameStart = statePacket.gameStart;
                            if (!gameStart)
                            {
                                settingTurnChange(-1);
                                System.Threading.Thread.Sleep(2000);
                                Next_Form();
                            }
                            break;
                        }
                    case (int)PacketType.턴:
                        {
                            TurnChange turnPacket = new TurnChange();
                            turnPacket.turnCount = turnCount;
                            turnPacket = (TurnChange)Packet.Deserialize(this.readbuffer);
                            turnReceived(turnPacket.turn, turnPacket.Word, turnPacket.message, turnPacket.clientscore);
                            break;
                        }
                    case (int)PacketType.프로필:
                        {
                            ClientProfile profile = new ClientProfile();
                            profile = (ClientProfile)Packet.Deserialize(this.readbuffer);
                            string fileName = null;
                            //클라이언트로부터 받은 파일을 쓴다.
                            if (fileStrm != null)
                            {
                                fileStrm.Write(profile.buffer, 0, profile.buffer.Length);
                                countRead++;
                                if (countRead == profile.count)
                                {
                                    fileName = fileStrm.Name;
                                    fileStrm.Close();
                                    fileStrm = null;
                                    countRead = 0;
                                    if (profile.clientNum > client_number)
                                    {
                                        switch (profile.clientNum)
                                        {
                                            case 1: this.Invoke(new MethodInvoker(delegate () { nickNameList.Add(profile.nickName); })); break;
                                            case 2: this.Invoke(new MethodInvoker(delegate () { nickNameList.Add(profile.nickName); })); break;
                                            case 3: this.Invoke(new MethodInvoker(delegate () { nickNameList.Add(profile.nickName); })); break;
                                        }
                                    }
                                    setProfile(profile.clientNum);
                                }
                            }
                            break;
                        }
                    case (int)PacketType.초기화:
                        {
                            Init init = new Init();
                            init = (Init)Packet.Deserialize(this.readbuffer);
                            client_number = init.clinetNumber;   //자신의 클라이언트 넘버 초기화
                            break;
                        }
                    case (int)PacketType.닉네임:   //6.13 초기화랑 닉네임 바꿈 -> initReceive함수 옮김
                        {
                            NickName nick_name = new NickName();
                            nick_name = (NickName)Packet.Deserialize(this.readbuffer);
                            initReceived(nick_name.nickNameList, nick_name.client_sum);
                            break;
                        }
                }
            }
        }

        private void turnReceived(int turnNum, string word, string message, int[] clientscore)
        {
            this.Invoke(new MethodInvoker(delegate () { timer.Stop(); }));      // 타이머 끄고
            //MessageBox.Show(word);
            turnClientNum = turnNum;        // 차례 변경
            answer = word;             // 정답 변경

            if (turnClientNum == 0)         // Host가 차례가 되면 turn Label 감소
                turnCount--;

            this.Invoke(new MethodInvoker(delegate () { lbl_score1.Text = "Score : " + clientscore[0].ToString(); }));
            this.Invoke(new MethodInvoker(delegate () { lbl_score2.Text = "Score : " + clientscore[1].ToString(); }));
            this.Invoke(new MethodInvoker(delegate () { lbl_score3.Text = "Score : " + clientscore[2].ToString(); }));
            this.Invoke(new MethodInvoker(delegate () { lbl_score4.Text = "Score : " + clientscore[3].ToString(); }));

            //DisplayText("턴 변경", Color.Blue);

            settingTurnChange(turnClientNum);

            if (turnCount == -1)            // 게임이 종료되었으면
            {
                GameState state = new GameState();
                state.Type = (int)PacketType.게임상태;

                state.gameStart = false;
                Packet.Serialize(state).CopyTo(this.sendbuffer, 0);
                stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
                this.stream.Flush();
                resetBuffer(sendbuffer);
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate () { timer.Start(); }));
                DisplayText(message, Color.Red);
            }
        }

        private void settingTurnChange(int turnNum)
        {
            timeSec = PlayTime;                         // 남은 시간 셋팅
            int minute = timeSec / 60;
            int second = timeSec % 60;
            this.Invoke(new MethodInvoker(delegate () { time.Text = string.Format("{0:0#} : {1:0#}", minute, second); }));      // 남은 시간 표시

            if (turnCount == -1)                         // 남은 턴 표시
                this.Invoke(new MethodInvoker(delegate () { turn.Text = "0"; }));
            else
                this.Invoke(new MethodInvoker(delegate () { turn.Text = turnCount.ToString(); }));

            this.Invoke(new MethodInvoker(delegate () { answerLabel.Text = answer; }));         // 정답 셋팅

            //gamePanel.Invalidate();                 // 그림판 reset
            g.Clear(Color.White);
            gamePicture.Image = bitmap;

            if (turnNum == client_number)     // 그림판, 정답라벨 비활성화,활성화
            {
                lockDrawing = false;
                this.Invoke(new MethodInvoker(delegate () { answerPic.Show(); }));
                this.Invoke(new MethodInvoker(delegate () { answerLabel.Show(); }));
            }
            else
            {
                lockDrawing = true;
                this.Invoke(new MethodInvoker(delegate () { answerPic.Hide(); }));
                this.Invoke(new MethodInvoker(delegate () { answerLabel.Hide(); }));
            }

            this.Invoke(new MethodInvoker(delegate () { drawing1.Hide(); }));          // 그림 그리는 사람 표시
            this.Invoke(new MethodInvoker(delegate () { drawing2.Hide(); }));
            this.Invoke(new MethodInvoker(delegate () { drawing3.Hide(); }));
            this.Invoke(new MethodInvoker(delegate () { drawing4.Hide(); }));
            switch (turnNum)
            {
                case 0: this.Invoke(new MethodInvoker(delegate () { drawing1.Show(); })); break;
                case 1: this.Invoke(new MethodInvoker(delegate () { drawing2.Show(); })); break;
                case 2: this.Invoke(new MethodInvoker(delegate () { drawing3.Show(); })); break;
                case 3: this.Invoke(new MethodInvoker(delegate () { drawing4.Show(); })); break;
                default: break;
            }

            if (!gameStart)               // 게임 종료시
                this.Invoke(new MethodInvoker(delegate () { timer.Stop(); }));
        }

        private void initReceived(string[] namelist, int counter)
        {
            for (int i = 0; i < counter; i++)
                 this.Invoke(new MethodInvoker(delegate () { nickNameList.Add(namelist[i]); }));

            if (counter == 1)
                this.Invoke(new MethodInvoker(delegate () { lbl_user1.Text = namelist[0].ToString(); }));

            else if (counter == 2)
            {
                this.Invoke(new MethodInvoker(delegate () { lbl_user1.Text = namelist[0].ToString(); }));
                this.Invoke(new MethodInvoker(delegate () { lbl_user2.Text = namelist[1].ToString(); }));
            }
            else if (counter == 3)
            {
                this.Invoke(new MethodInvoker(delegate () { lbl_user1.Text = namelist[0].ToString(); }));
                this.Invoke(new MethodInvoker(delegate () { lbl_user2.Text = namelist[1].ToString(); }));
                this.Invoke(new MethodInvoker(delegate () { lbl_user3.Text = namelist[2].ToString(); }));
            }
            else if (counter == 4)
            {
                this.Invoke(new MethodInvoker(delegate () { lbl_user1.Text = namelist[0].ToString(); }));
                this.Invoke(new MethodInvoker(delegate () { lbl_user2.Text = namelist[1].ToString(); }));
                this.Invoke(new MethodInvoker(delegate () { lbl_user3.Text = namelist[2].ToString(); }));
                this.Invoke(new MethodInvoker(delegate () { lbl_user4.Text = namelist[3].ToString(); }));
            }
        }

        private void setProfile(int clientNum)
        {
            switch (clientNum)
            {
                case 0:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB1.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB1.Load(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB1.Image = System.Drawing.Image.FromFile(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");
                        }));
                        break;
                    }
                case 1:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB2.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB2.Load(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB2.Image = System.Drawing.Image.FromFile(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");
                        }));
                        break;
                    }
                case 2:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB3.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB3.Load(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB3.Image = System.Drawing.Image.FromFile(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");
                        }));
                        break;
                    }
                case 3:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB4.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB4.Load(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB4.Image = System.Drawing.Image.FromFile(filepath + client_number.ToString() + "-" + clientNum.ToString() + ".jpg");
                        }));
                        break;
                    }

            }
            if (client_number != 0)             // Host인 경우에만 Start Button이 나타남.
                this.Invoke(new MethodInvoker(delegate () { startButton.Hide(); }));
        }

        private void DisplayText(string text, Color color)   //텍스트창에 메세지 띄움
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                richTextBox1.SelectionColor = color;
                richTextBox1.AppendText(text + "\r\n");
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.Focus();
                richTextBox1.ScrollToCaret();
                txtBox_user.Focus();
            }));
        }

        private void txtBox_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBox_user.Text != "")
            {
                ClientMessage clientMessage = new ClientMessage();
                clientMessage.Type = (int)PacketType.메세지;

                clientMessage.Message = this.txtBox_user.Text;
                //MessageBox.Show(nickNameList.Count.ToString());
                clientMessage.nickName = nickNameList[client_number].ToString();
                Packet.Serialize(clientMessage).CopyTo(this.sendbuffer, 0);

                stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
                stream.Flush();
                resetBuffer(sendbuffer);
                
                if (txtBox_user.Text == answer && turnClientNum != client_number && gameStart)             // 만약 정답이면
                {
                    TurnChange turnPacket = new TurnChange();
                    turnPacket.Type = (int)PacketType.정답;

                    turnPacket.turn = turnClientNum;
                    turnPacket.Correct = true;
                    turnPacket.message = "***   정답입니다.   ***";
                    turnPacket.score = timeSec;
                    turnPacket.clientNum = client_number;
                    turnPacket.turnCount = turnCount;
                    Packet.Serialize(turnPacket).CopyTo(this.sendbuffer, 0);

                    stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
                    stream.Flush();
                    resetBuffer(sendbuffer);
                }

                this.txtBox_user.Text = "";
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////   그림판   ////////////////////////////////////////////////////////
        private void rBtn_10pt_CheckedChanged(object sender, EventArgs e)
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

        private void panel_black_Click(object sender, EventArgs e)
        {
            Panel selectedColor = (Panel)sender;
            if (eraser == true)
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

        private void panel_pic_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            previousPoint = new Point(e.X, e.Y);
        }

        private void panel_pic_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            if (!lockDrawing)
            {
                //한 획을 그을 때마다 그림을 저장한다. 0Turn, 1Turn이런 식의 이름으로!
                gamePicture.DrawToBitmap(bitmap, new Rectangle(0, 0, gamePicture.Width, gamePicture.Height));
                bitmap.Save(Environment.CurrentDirectory + "\\UserImage\\" + client_number + "Turn.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                sendPictuer();
            }
        }

        /*2017-06-09추가
         *한 획을 그을 때마다 저장한 그림을 서버에 전송해준다.*/
        private void sendPictuer()
        {
            byte[] sendBuffer = new byte[1024 * 4];
            //////////////////////////////   그림 파일 정보 전송   //////////////////////////////
            ClientDrawingInfo drawInfo = new ClientDrawingInfo();
            drawInfo.Type = (int)PacketType.그림정보;
            drawInfo.clientNum = client_number;
            Packet.Serialize(drawInfo).CopyTo(sendBuffer, 0);
            stream.Write(sendBuffer, 0, sendBuffer.Length);
            stream.Flush();
            //////////////////////////////   그림 파일 전송   //////////////////////////////
            ClientDrawing draw = new ClientDrawing();
            FileInfo file = new FileInfo(Environment.CurrentDirectory + "\\UserImage\\" + client_number + "Turn.jpg");
            FileStream fileStrm = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fileStrm);


            int count = (int)(file.Length) / (1024) + 1;

            for (int i = 0; i < count; i++)
            {
                draw.buffer = reader.ReadBytes(1024);
                draw.count = count;
                draw.Type = (int)PacketType.그림;
                draw.clientNum = client_number;
                Packet.Serialize(draw).CopyTo(sendBuffer, 0);
                stream.Write(sendBuffer, 0, sendBuffer.Length);
                this.stream.Flush();
                resetBuffer(sendBuffer);
            }
            fileStrm.Close();
            //////////////////////////////////////////////////////////////////////////////////
        }

        private void panel_pic_MouseMove(object sender, MouseEventArgs e)
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

                if (!lockDrawing)
                {
                    g.DrawLine(currentPen, previousPoint, currentPoint);
                    previousPoint = currentPoint;
                    gamePicture.Image = bitmap;
                }
            }
        }

        private void lbl_reset_Click(object sender, EventArgs e)
        {
            gamePanel.Invalidate();
            g.Clear(Color.White);
            gamePicture.Image = bitmap;
        }

        private void Eraser_Click(object sender, EventArgs e)
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Next_Form()
        {
            this.Invoke(new MethodInvoker(delegate () {
                this.Hide();
                Form6 form6 = new Form6(this);
                form6.ShowDialog();
                this.Close();
            }));
        }
    }
}
