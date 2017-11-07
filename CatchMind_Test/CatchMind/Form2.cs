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
using System.Diagnostics;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Net;

namespace CatchMind
{
    public partial class Form2 : Form
    {
        TcpClient clientSocket = new TcpClient();
        string IP = "";

        static String strConn = "Server=testdb.cp7ywnu38fi2.ap-northeast-2.rds.amazonaws.com;Database=catchmind_db;Uid=eunjeong;Pwd=0q3yl9v9";
        MySqlConnection conn = new MySqlConnection(strConn);

        public Form2()
        {
            InitializeComponent();
            IP = getIP();
        }

        public string getIP() {
            //해당 컴퓨터 ip주소 알아내기!! _ 0613
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = address.ToString();
                }
            }
            return IP;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.BackgroundImage = Properties.Resources.BackgroundImage;
            SetFont();
        }

        private void cursor_MouseEnter(object sender, EventArgs e) { Cursor = Cursors.Hand; }
        private void cursor_MouseLeave(object sender, EventArgs e) { Cursor = Cursors.Arrow; }
        private void Connect() { clientSocket.Connect(IP, 9999); }
        public TcpClient SetSocket() { return clientSocket; }

        private void SetFont()
        {
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Environment.CurrentDirectory + "\\Font\\야놀자 야체 Regular.ttf");
            Font font9 = new Font(privateFonts.Families[0], 9f);
            Font font23 = new Font(privateFonts.Families[0], 23f);
            numLabel.Font = font23;
            backLabel.Font = font23;
            okLabel.Font = font23;
            comboBox.Font = font9;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex < 0)
                MessageBox.Show("인원수를 선택해주세요.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            else
            {
                //서버 프로그램 시작
                Process.Start(Environment.CurrentDirectory + "\\Server\\bin\\Debug\\Chatting.exe");
                //Thread.Sleep(1000);  //서버 프로그램이 구성될 시간

                // Host가 server와 연결 시도 : 성공시 form4 열기
                try { Connect(); serverIPSave(); }
                catch
                {
                    MessageBox.Show("서버와 연결할 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                    return;
                }
                this.Hide();
                Form4 form4 = new Form4(this);
                form4.ShowDialog();
                this.Close();
            }
        }

        // 서버의 ip를 db에 저장.
        private void serverIPSave()
        {
            //한 ip 당 생기는 방은 하나!!
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = strConn;
                conn.Open();
                
                //해당 ip주소값이 이미 저장 되어있는지 확인
                string query1 = "select count(*) from host where ip=@ip";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                cmd1.CommandText = query1;
                cmd1.Parameters.AddWithValue("@ip", IP);
                int checkIP = Convert.ToInt32(cmd1.ExecuteScalar());

                //이미 저장 되어 있다면 update
                if (checkIP > 0)
                {
                    string query2 = "update host set room_num=@room_num, curr_num=@curr_num where ip=@ip";
                    MySqlCommand newUser1 = new MySqlCommand(query1, conn);
                    newUser1.CommandText = query2;
                    newUser1.Parameters.AddWithValue("@ip", IP);
                    newUser1.Parameters.AddWithValue("@room_num", comboBox.SelectedItem);
                    newUser1.Parameters.AddWithValue("@curr_num", 1);
                    newUser1.ExecuteNonQuery();

                }
                else // 안되어 있다면 insert
                {
                    string query3 = "insert into host values(room_id, @ip, @room_num, @curr_num)";
                    MySqlCommand newUser2 = new MySqlCommand(query1, conn);
                    newUser2.CommandText = query3;
                    newUser2.Parameters.AddWithValue("@ip", IP);
                    newUser2.Parameters.AddWithValue("@room_num", comboBox.SelectedItem);
                    newUser2.Parameters.AddWithValue("@curr_num", 1);
                    newUser2.ExecuteNonQuery();
                }

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
