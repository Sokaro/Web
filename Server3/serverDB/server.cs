using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace serverDB
{
    class server
    {
        TcpListener listener;

        public server()
        {
            listener = new TcpListener(IPAddress.Any, 880);
            listener.Start();

            while(true)
            {
                
                TcpClient Client = listener.AcceptTcpClient();
                
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
              
                Thread.Start(Client);
            }
        }

        ~server()
        {
            if (listener != null)
                listener.Stop();
        }

        static void ClientThread(Object StateInfo)
        {
            new Client((TcpClient)StateInfo);
            
        }
    }
}
