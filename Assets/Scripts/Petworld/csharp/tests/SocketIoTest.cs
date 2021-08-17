using System;
using UnityEngine;
using KyleDulce.SocketIo;

namespace jlg.petworld.csharp.tests
{
    public class SocketIoTest : MonoBehaviour
    {
        private Socket socket;
        [SerializeField] private int port = 3000;
        public bool emitEvent = false;
        public bool didTest = false;
        // Start is called before the first frame update
        void Start()
        {
            //get host
#if UNITY_WEBGL
            string address = "ws://" + (new Uri(Application.absoluteURL).Host) + ':' + port;
#else
            string address = "ws://localhost:3000";
#endif
            Debug.Log("Starting connection");
            socket = SocketIo.establishSocketConnection(address);
            socket.connect();
            Debug.Log("Connection made");

            socket.on("testEvent", (string data) =>
            {
                Debug.Log("yay");
            });
        }

        // Update is called once per frame
        void Update()
        {
            if(emitEvent)
			{
                emitEvent = false;
                socket.emit("testEvent", "hello");
			} 
            if(!didTest && socket.connected)
			{
                emitEvent = true;
                didTest = true;
			}
        }
    }
}
