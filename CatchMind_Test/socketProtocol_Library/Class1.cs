using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace socketProtocol_Library
{
    //하위 버전과의 호환성을 위해서 직렬화되어 온 스트렘이 관계없이 원래 버전으로 만들어줌
    sealed class AllowAllAssemblyVersionDewerializationBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;
            String currentAssembly = System.Reflection.Assembly.GetExecutingAssembly().FullName;
            assemblyName = currentAssembly;
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
            return typeToDeserialize;

            //  throw new NotImplementedException();
        }
    }

    public enum PacketType
    {
        메세지 = 0,    //닉네임, 메세지 같이 -> 채팅패킷
        닉네임,
        프로필,       //프로필 그림 -> 프로필패킷
        프로필정보,
        그림,        //닉네임, 그림 -> 그림패킷
        그림정보,
        턴,
        정답,        //문제 해당 단어, 정답 유무 확인-> 정답패킷
        초기화,         //클라이언트넘버 초기화 -> 초기화패킷
        게임상태,
        랭킹,
        랭킹프로필
    }
    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }
        public static byte[] Serialize(Object o)    //개체를 byte로
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            byte[] bytes = ms.ToArray();
            ms.Flush();
            return bytes;    //읽어서 배열로 배열로 반환
        }

        public static Object Deserialize(byte[] bt) //byte를 개체로
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);    //전달 된 byte를 메모리에 쓴다
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);    //binary formatter로 객체를 만든다.
            ms.Close();
            return obj; // 그 객체 반환
        }

    }

    [Serializable]
    public class ClientMessage : Packet //클라이언트 메세지 전송 패킷 -> 패킷타입 : 메세지
    {
        public string nickName; //닉네임
        public string Message;  //메세지
        public ClientMessage()
        {
            nickName = null;
            Message = null;
        }
    }

    [Serializable]
    public class ClientProfile : Packet //클라이언트 메세지 전송 패킷 -> 패킷타입 : 프로필
    {
        public string nickName; //닉네임
        public byte[] buffer;
        public int count;
        public int clientNum;

        public ClientProfile()
        {
            nickName = null;
            count = 0;
            buffer = new byte[1024];
            clientNum = 0;
        }
    }

    [Serializable]
    public class ClientProfileInfo : Packet //클라이언트 메세지 전송 패킷 -> 패킷타입 : 프로필
    {
        public int clientNum;

        public ClientProfileInfo()
        {
            clientNum = 0;
        }
    }

    [Serializable]
    public class ClientDrawingInfo : Packet //클라이언트 그림 전송 패킷 -> 패킷타입 : 그림
    {
        public int clientNum;

        public ClientDrawingInfo()
        {
            clientNum = 0;
        }
    }

    [Serializable]
    public class Answer : Packet //클라이언트 그림 전송 패킷 -> 패킷타입 : 그림
    {
        public string answer;

        public Answer()
        {
            answer = null;
        }
    }

    [Serializable]
    public class ClientDrawing : Packet //클라이언트 그림 전송 패킷 -> 패킷타입 : 그림
    {
        public byte[] buffer;
        public int count;
        public int clientNum;

        public ClientDrawing()
        {
            count = 0;
            buffer = new byte[1024];
            clientNum = 0;
        }
    }

    [Serializable]
    public class Init : Packet //클라이언트 번호와 이전 클라이언트의 리스트 전송 패킷 -> 패킷타입 : 초기화
    {
        public int clinetNumber;
        public string[] nickNameList;
        public int client_sum;  //클라이언트 수
        public Init()
        {
            client_sum = 0;
            clinetNumber = 0;
            nickNameList = new string[4];
        }
    }

    [Serializable]  //6.13c=추가
    public class NickName : Packet //클라이언트 번호와 이전 클라이언트의 리스트 전송 패킷 -> 패킷타입 : 초기화
    {
        public string[] nickNameList;
        public int client_sum;  //클라이언트 수
        public NickName()
        {
            client_sum = 0;
            nickNameList = new string[4];
        }
    }

    [Serializable]
    public class TurnChange : Packet //정답,오답 구분과 함께 턴 전송 패킷 -> 패킷타입 : 정답, 턴
    {
        public int turn;
        public string message;
        public string Word;     //문제 그림 단어
        public bool Correct;    //정답 확인
        public int score;       //증가할 점수
        public int[] clientscore;
        public int turnCount;
        public int clientNum;

        public TurnChange()
        {
            turn = 0;
            message = null;
            Word = null;
            Correct = false;
            score = 0;
            clientNum = 0;
            clientscore = new int[] { 0, 0, 0, 0 };
            turnCount = 3;
        }
    }

    [Serializable]
    public class GameState : Packet //게임 시작과 끝을 알리는 패킷 -> 패킷타입 : 게임상태
    {
        public bool gameStart;
        public string message;

        public GameState()
        {
            gameStart = false;
            message = null;
        }
    }

    [Serializable]
    public class Ranking : Packet //랭킹 표시 하기 위한  라벨
    {
        public int[] clientscore;
        public string[] clientNickname;
        public int clientSum;

        public Ranking()
        {
            clientscore = new int[] { 0, 0, 0, 0 };
            clientNickname = new string[] { "", "", "", "" };
            clientSum = 0;
        }
    }
}
