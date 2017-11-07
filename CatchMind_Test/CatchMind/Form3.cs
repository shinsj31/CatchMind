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
using MySql.Data.MySqlClient;

namespace CatchMind
{
    public partial class Form3 : Form
    {
        TcpClient clientSocket = new TcpClient();
        string IP = "";
        static String strConn = "Server=testdb.cp7ywnu38fi2.ap-northeast-2.rds.amazonaws.com;Database=catchmind_db;Uid=eunjeong;Pwd=0q3yl9v9";
        MySqlConnection conn = new MySqlConnection(strConn);
        MySqlCommand cmd;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.BackgroundImage = Properties.Resources.BackgroundImage;
            conn = new MySqlConnection();
            conn.ConnectionString = strConn;

            SetFont();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            GetIpList();
        }

        private void cursor_MouseEnter(object sender, EventArgs e) { Cursor = Cursors.Hand; }
        private void cursor_MouseLeave(object sender, EventArgs e) { Cursor = Cursors.Arrow; }
        private void Connect() { clientSocket.Connect(IP, 9999); }
        public TcpClient SetSocket() { return clientSocket; }

        private void SetFont()
        {
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Environment.CurrentDirectory + "\\Font\\야놀자 야체 Regular.ttf");
            Font font20 = new Font(privateFonts.Families[0], 20f);
            Font font23 = new Font(privateFonts.Families[0], 23f);
            roomList1.Font = font20;
            roomList2.Font = font20;
            roomList3.Font = font20;
            lbl_max1.Font = font20;
            lbl_max2.Font = font20;
            lbl_max3.Font = font20;
            label1.Font = font20;
            label2.Font = font20;
            label3.Font = font20;
            count1.Font = font20;
            count2.Font = font20;
            count3.Font = font20;
            backLabel.Font = font23;
        }

        // ip.txt파일에서 서버 목록 얻어옴. 추후에 DB로 수정해야함
        private void GetIpList()
        {
            int i = 0;
            string limitPlayer = "";
            string ipAddress = "";
            string curPlayer = "";

            try
            {
                string query = "select * from host";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;

                conn.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();

                //디비에 있는 값 읽어서 라벨에 할당_0613
                while (myReader.Read())
                {
                    limitPlayer = myReader["room_num"].ToString();
                    ipAddress = myReader["ip"].ToString();
                    curPlayer = myReader["curr_num"].ToString();

                    switch (i)
                    {
                        //max라벨 추가!!
                        case 0: roomList1.Text = ipAddress; count1.Text = curPlayer; lbl_max1.Text = limitPlayer; label1.Show(); break;
                        case 1: roomList2.Text = ipAddress; count2.Text = curPlayer; lbl_max2.Text = limitPlayer; label2.Show(); break;
                        case 2: roomList3.Text = ipAddress; count3.Text = curPlayer; lbl_max3.Text = limitPlayer; label3.Show(); break;
                        default: break;
                    }
                    i++;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void Room_Click(object sender, EventArgs e)
        {
            string roomName = "";
            switch (sender.GetType().ToString())        // 클릭한 컨트롤의 Name을 얻어 roomName에 저장
            {
                case "System.Windows.Forms.Panel": roomName = ((Panel)sender).Name; break;
                case "System.Windows.Forms.Label": roomName = ((Label)sender).Name; break;
                default: break;
            }

            string peopleCount = "";
            string maxPeople = "";

            if (roomName == "panel1" || roomName == "roomList1" || roomName == "count1")     // 클릭한 방의 현재 인원과 limit 인원을 가져온다.
            { maxPeople = lbl_max1.Text; peopleCount = count1.Text; IP = roomList1.Text; }
            else if (roomName == "panel2" || roomName == "roomList2" || roomName == "count2")
            { maxPeople = lbl_max2.Text; peopleCount = count2.Text; IP = roomList2.Text; }
            else if (roomName == "panel3" || roomName == "roomList3" || roomName == "count3")
            { maxPeople = lbl_max3.Text; peopleCount = count3.Text; IP = roomList3.Text; }

            int curPeople = 0;
            int fulPeople = 0;
            if (peopleCount != "")
            {
                curPeople = Convert.ToInt32(peopleCount.Substring(0, 1));
                fulPeople = Convert.ToInt32(maxPeople.Substring(0, 1));
            }

            if (curPeople >= fulPeople)
            {         // 현재 인원과 limit 인원을 비교하여 방을 입장한다.

                MessageBox.Show("방에 입장할 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try { Connect(); }
                catch
                {
                    MessageBox.Show("서버와 연결할 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Client가 방에 입장했으니 방 인원수를 변경하는 작업.IP 이용 위해 여기다 집어넣음. _ 0613
                curPeople++;

                conn = new MySqlConnection();
                conn.ConnectionString = strConn;

                string query = "update host set curr_num=@curr_num where ip=@ip";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;

                conn.Open();

                cmd.Parameters.AddWithValue("@curr_num", curPeople);
                cmd.Parameters.AddWithValue("@ip", IP);

                cmd.ExecuteNonQuery();

                conn.Close();


                this.Hide();
                Form4 form4 = new Form4(this);
                form4.ShowDialog();
                this.Close();
            }
        }
    }
}
