using System;
using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class SocketioTest : MonoBehaviour
{
    private QSocket socket;
    private int port = 3000;

    void Start()
    {

        string url = Application.absoluteURL;
        if(string.IsNullOrEmpty(url)) {
            url = "localhost:" + port;
        } else {
            url = new Uri(url).Host + ":" + port;
        }

        Debug.Log("Connecting to server via: " + url);

        Debug.Log("start");
        socket = IO.Socket("http://" + url);

        socket.On(QSocket.EVENT_CONNECT, () =>
        {
            Debug.Log("Connected");
        });
    }

    private void OnDestroy()
    {
        socket.Disconnect();
    }
}
