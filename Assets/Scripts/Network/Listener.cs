using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;
public class Listener : MonoBehaviour
{
    static Queue<Message> toDoList = new Queue<Message>();
    static void listenerServer(object obj)
    {
        Socket sclient = (Socket)obj;
        byte[] readBuff = new byte[1024];
        while (true)
        {

            try
            {
                int len = sclient.Receive(readBuff);
                string str = System.Text.Encoding.Default.GetString(readBuff, 0, len);
                foreach (string s in str.Split('&'))
                {
                    if (s.Length > 0)
                    {
                        Message msg = JsonConvert.DeserializeObject<Message>(str);
                        toDoList.Enqueue(msg);
                    }
                }
            }
            catch (SocketException)
            {
                break;
            }

        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (toDoList.Count > 0)
        {
            Message msg = toDoList.Dequeue();
            switch (msg.type)
            {
                case "AllPlayerInfo":
                    List<PlayerInfo> listinfo = JsonConvert.DeserializeObject<List<PlayerInfo>>(msg.info);
                    PlayerPool.ins.UpdatePlayer(listinfo);
                    break;
            }
        }
    }
    public static void startListen(Socket sc)
    {
        Thread listen = new Thread(new ParameterizedThreadStart(listenerServer));
        listen.Start();
    }
}