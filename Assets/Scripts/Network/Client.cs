using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public struct POSITION
{
    public float x;
    public float y;
    public float z;
}

public struct ROTATION
{
    public float x;
    public float y;
    public float z;
}

public class ClientToserver
{
    public string name;
    public POSITION position;
    public ROTATION rotation;
}

public class Client : MonoBehaviour
{
    private ClientToserver playerClient = new ClientToserver();
    public string ID;
    public GameObject playerObject;
    public static Socket clientSocket;

    private void Awake()
    {
        ID = "864420";
        //客户端创建一个socket后，连接服务端.
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress iPAddress = IPAddress.Parse("10.18.100.24");
        IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 88);
        clientSocket.Connect(iPEndPoint);
        //接受服务端的消息
        byte[] bytes = new byte[1024];
        int count = clientSocket.Receive(bytes);
        string recData = System.Text.Encoding.UTF8.GetString(bytes, 0, count);
        Debug.Log(recData);
        //给客户端发送消息
        //string msg = ID;
        //byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
        //clientSocket.Send(data);

        //playerClient.name = "我是客户端864420玩家";
    }

    private void Update()
    {
        //timeTmp += Time.deltaTime;
        //if(timeTmp > timelimite)
        //{
        //    playerClient.position.x= playerObject.transform.position.x;
        //    playerClient.position.y= playerObject.transform.position.y;
        //    playerClient.position.z= playerObject.transform.position.z;
        //    playerClient.rotation.x= playerObject.transform.rotation.x;
        //    playerClient.rotation.y= playerObject.transform.rotation.y;
        //    playerClient.rotation.z= playerObject.transform.rotation.z;

        //    string jsonClient = Newtonsoft.Json.JsonConvert.SerializeObject(playerClient);
        //    byte[] date = System.Text.Encoding.UTF8.GetBytes(jsonClient);
        //    clientSocket.Send(date);
        //    timeTmp = 0;
        //}
    }

    public static void SendMsgToServer(string msg)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(msg);
        clientSocket.Send(bytes);
    }

    public static string GetMesaage(string Action, Vector3 position, Vector3 Angle)
    {
        string msg = clientSocket.RemoteEndPoint.ToString();
        string x = position.x.ToString();
        string y = position.y.ToString();
        string z = position.z.ToString();
        string ax = Angle.x.ToString();
        string ay = Angle.y.ToString();
        string az = Angle.z.ToString();
        msg = msg + "|" + Action;
        msg = msg + ',' + x + '.' + y + '.' + z;
        msg = msg + ',' + ax + '.' + ay + '.' + az;
        return msg;
    }
}