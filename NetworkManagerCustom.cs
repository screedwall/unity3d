// To use this example, attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetShipsInfo : MessageBase
{
    public int[] ids = new int[100];
    //public int[,] ships = new int[10, 4];
}
public class NetMessage : MessageBase
{
    public string x;
}

public class NetworkManagerCustom : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public InputField m_field;
    public Text m_txt;
    public Text log;
    NetworkConnection MyConn;
    NetworkServer m_Server;
    NetworkClient m_Client;
    const short k_MyMessage = 42;


    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        NetworkServer.RegisterHandler(MsgType.Connect, OnClientConnected);
    }
    // When using a server instance like this it must be pumped manually
    void Update()
    {
        if (m_Server != null)
        {
            //m_Server.Update();
        }
    }
    public void StartServer()
    {
        NetworkServer.RegisterHandler(k_MyMessage, OnMyMessage);
        if (NetworkServer.Listen(5555))
            Debug.Log("Started listening on 5555");
    }

    public void StartClient()
    {
        string ip = "127.0.0.1";//GameObject.Find("InputFieldIP").GetComponent<Text>().text;
        m_Client = new NetworkClient();
        m_Client.Connect(ip, 5555);
        m_Client.RegisterHandler(MsgType.Connect, OnConnect);
        m_Client.RegisterHandler(k_MyMessage, OnMyMessage);
    }

    void OnClientConnected(NetworkMessage msg)
    {
        Debug.Log("Client connected to server: "+msg.conn);
        MyConn = msg.conn;
    }
    public void SendMyMessage(NetMessage msg)
    {
        if (m_Client != null)
        {
            m_Client.Send(k_MyMessage, msg);
        }
        else
        {
            NetworkServer.SendToClient(MyConn.connectionId, k_MyMessage, msg);
        }
    }
    void OnMyMessage(NetworkMessage netmsg)
    {
        Debug.Log("Got message, size=" + netmsg.reader);
        /*var someValue = netmsg.reader.ReadInt32();
        var someString = netmsg.reader.ReadString();*/
        log.text = netmsg.reader.ReadString();
        //Debug.Log("Message value=" + someValue + " Message string=‘" + someString + "’");
    }
    void OnConnect(NetworkMessage netmsg)
    {
        GameObject.Find("StateConn").GetComponent<Text>().text = "Connected";
    }
}