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
    public partial class Form6 : Form
    {
        TcpClient clientSocket;
        NetworkStream stream = default(NetworkStream);
        private byte[] sendbuffer = new byte[1024 * 4];
        private byte[] readbuffer = new byte[1024 * 4];
        string filepath = Environment.CurrentDirectory + "\\UserImage\\";

        Label[] scoreLabel = new Label[4];  //동적으로 생성 될 라벨 수
        int[] rankClient = new int[] { -1, -1, -1, -1 };    //클라이언트 점수 저장 배열
        int clientNum = 0;
        int clientSum = 0;
        private Form5 frm5 = null;

        static String strConn = "Server=testdb.cp7ywnu38fi2.ap-northeast-2.rds.amazonaws.com;Database=catchmind_db;Uid=eunjeong;Pwd=0q3yl9v9";
        MySqlConnection conn = new MySqlConnection(strConn);
        MySqlCommand cmd;
        
        string IP = "";

        public Form6()
        {
            InitializeComponent();
        }

        public Form6(Form5 frm5)
        {
            InitializeComponent();
            this.frm5 = frm5;
            this.clientNum = frm5.client_number;    //클라이언트 넘버 받아오기
            clientSocket = frm5.SetSocket();    //소켓 받아오기
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.BackgroundImage = Properties.Resources.BackgroundImage;
            SetFont();

            stream = clientSocket.GetStream();  //스트림 읽음
            Ranking state = new Ranking();  //랭킹 먼저 서버에 요구

            state.Type = (int)PacketType.랭킹;
            Packet.Serialize(state).CopyTo(this.sendbuffer, 0);
            stream.Write(this.sendbuffer, 0, this.sendbuffer.Length);
            this.stream.Flush();
            resetBuffer(sendbuffer);

            //해당 컴퓨터 ip주소 알아내기!! _ 0613
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = address.ToString();
                }
            }
            //MessageBox.Show(IP);

            Thread t_handler = new Thread(setFianl);  //서버에서 랭킹, 프로필 받기 위해
            t_handler.IsBackground = true;
            t_handler.Start();

        }

        private void cursor_MouseEnter(object sender, EventArgs e) { Cursor = Cursors.Hand; }
        private void cursor_MouseLeave(object sender, EventArgs e) { Cursor = Cursors.Arrow; }
        private void resetBuffer(byte[] buffer) { for (int i = 0; i < 1024 * 4; i++) buffer[i] = 0; }

        /////////////////////////////////////////////////////////////////////////////////////
        private void SetFont()
        {
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Environment.CurrentDirectory + "\\Font\\야놀자 야체 Regular.ttf");
            Font font12 = new Font(privateFonts.Families[0], 12f);
            Font font23 = new Font(privateFonts.Families[0], 23f);
            Font font35 = new Font(privateFonts.Families[0], 35f);

            scoreLabel1.Font = font12;
            scoreLabel2.Font = font12;
            scoreLabel3.Font = font12;
            scoreLabel4.Font = font12;
            username1.Font = font12;
            username2.Font = font12;
            username3.Font = font12;
            username4.Font = font12;
            lbl_ranking.Font = font35;
            lbl_again.Font = font23;
            lbl_exit.Font = font23;
        }
        //////////////////////////////////////////////////////////////////////////////////////

        private void Again_Click(object sender, EventArgs e)
        {
            this.Hide();
            deleteRoom();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            deleteRoom();
            this.Close();
        }

        private void deleteRoom() {
            try
            {
                conn.Open();
                //MessageBox.Show(IP);
                //해당 ip주소값이 이미 저장 되어있는지 확인
                string query0 = "select count(*) from host where ip=@ip";
                MySqlCommand cmd1 = new MySqlCommand(query0, conn);
                cmd1.CommandText = query0;
                cmd1.Parameters.AddWithValue("@ip", IP);
                int checkIP = Convert.ToInt32(cmd1.ExecuteScalar());

                //해당 아이피가 존재하면 delete
                if (checkIP > 0)
                {
                    string query1 = "delete from host where ip=@ip";
                    cmd = conn.CreateCommand();
                    cmd.CommandText = query1;

                    cmd.Parameters.AddWithValue("@ip", IP);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    //this.Close();
                }
                else
                { //아이피가 존재하지 않으면 그냥 close
                    conn.Close();
                   // this.Close();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setFianl()    //랭킹, 이미지 세팅
        {
            while (true)
            {
                stream = clientSocket.GetStream();  //스트림 읽음
                int bytes = stream.Read(this.readbuffer, 0, this.readbuffer.Length);

                Packet packet = (Packet)Packet.Deserialize(this.readbuffer);

                switch ((int)packet.Type)
                {

                    case (int)PacketType.랭킹:
                        {
                            Ranking rank = new Ranking();
                            rank = (Ranking)Packet.Deserialize(this.readbuffer);
                            clientSum = rank.clientSum;

                            turnReceived(rank.clientscore, rank.clientNickname);   //점수 세팅

                            break;
                        }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////
        private void turnReceived(int[] clientscore, string[] clientNickname)    //랭킹 라벨 설정
        {
            int[] Score = new int[4];
            Dictionary<int, int> tmp = new Dictionary<int, int>();  // score, index

            for (int i = 0; i < clientSum; i++)     //배열 복사
            {
                Score[i] = clientscore[i];
                tmp.Add(i, clientscore[i]);
            }

            Array.Sort(Score);  //오름차순 정렬
            Array.Reverse(Score);   //내림차순으로 바꾸기

            for (int i = 0; i < clientSum; i++)
            {
                var _key = tmp.FirstOrDefault(x => x.Value == Score[i]).Key;
                rankClient[i] = _key;      //랭킹에 따른 clientNum 재배치
                tmp.Remove(_key);
            }

            for (int i = 0; i < clientSum; i++)
            {
                switch (i)
                {
                    case 0:
                        this.Invoke(new MethodInvoker(delegate () { scoreLabel1.Text = "Score : " + clientscore[rankClient[i]].ToString(); }));
                        this.Invoke(new MethodInvoker(delegate () { username1.Text = clientNickname[rankClient[i]].ToString(); }));
                        break;
                    case 1:
                        this.Invoke(new MethodInvoker(delegate () { scoreLabel2.Text = "Score : " + clientscore[rankClient[i]].ToString(); }));
                        this.Invoke(new MethodInvoker(delegate () { username2.Text = clientNickname[rankClient[i]].ToString(); }));
                        break;
                    case 2:
                        this.Invoke(new MethodInvoker(delegate () { scoreLabel3.Text = "Score : " + clientscore[rankClient[i]].ToString(); }));
                        this.Invoke(new MethodInvoker(delegate () { username3.Text = clientNickname[rankClient[i]].ToString(); }));
                        break;
                    case 3:
                        this.Invoke(new MethodInvoker(delegate () { scoreLabel4.Text = "Score : " + clientscore[rankClient[i]].ToString(); }));
                        this.Invoke(new MethodInvoker(delegate () { username4.Text = clientNickname[rankClient[i]].ToString(); }));
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < clientSum; i++)
                setProfile(i, clientscore);
        }
        /////////////////////////////////////////////////////////////////////////////////////

        private void setProfile(int clientNum, int[] clientscore)
        {
            switch (clientNum)
            {
                case 0:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB1.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB1.Load(filepath + clientNum.ToString() + "-" + rankClient[0].ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB1.Image = System.Drawing.Image.FromFile(filepath + clientNum.ToString() + "-" + rankClient[0].ToString() + ".jpg");
                        }));
                        break;
                    }
                case 1:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB2.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB2.Load(filepath + clientNum.ToString() + "-" + rankClient[1].ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB2.Image = System.Drawing.Image.FromFile(filepath + clientNum.ToString() + "-" + rankClient[1].ToString() + ".jpg");
                        }));
                        break;
                    }
                case 2:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB3.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB3.Load(filepath + clientNum.ToString() + "-" + rankClient[2].ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB3.Image = System.Drawing.Image.FromFile(filepath + clientNum.ToString() + "-" + rankClient[2].ToString() + ".jpg");
                        }));
                        break;
                    }
                case 3:
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            userPB4.SizeMode = PictureBoxSizeMode.StretchImage;
                            userPB4.Load(filepath + clientNum.ToString() + "-" + rankClient[3].ToString() + ".jpg");  //픽쳐박스에 로딩
                            userPB4.Image = System.Drawing.Image.FromFile(filepath + clientNum.ToString() + "-" + rankClient[3].ToString() + ".jpg");
                        }));
                        break;
                    }

            }

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteRoom();
            //this.Close();
        }
    }
}