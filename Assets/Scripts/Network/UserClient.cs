using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using Newtonsoft.Json;
//客户端

public class PlayerInfo
{
    public string name;
    public float x, y, z;
    public PlayerInfo(string n, Vector3 v)
    {
        name = n; x = v.x; y = v.y; z = v.z;
    }
}
public class Message
{
    public string type;//发送的类型信息
    public string info;
    public Message(string t, string i)
    {
        type = t;
        info = i;
    }
}
public class UserClient : MonoBehaviour
{

    static Socket socket;
    private void Start()
    {

        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect("10.18.100.24", 55555);
        Listener.startListen(socket);
        // PlayerInfo p = new PlayerInfo("xiaoming", 2, 1, 3);
    }
    public static void SendMessage(Message msg)
    {
        string str = JsonConvert.SerializeObject(msg);
        byte[] bytes = System.Text.Encoding.Default.GetBytes(str + "&");
        if (socket != null && socket.Connected) socket.Send(bytes);
    }
}
