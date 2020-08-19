using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multichat_Client.API
{
    public class ClientAPI
    {
        private const int Port = 5555;
        private TcpClient client;
        private NetworkStream networkStream;
        private Message message;
        private Input input;

        private Thread threadListen;
        private Thread threadSay;
        private Thread threadInput;


        public ClientAPI()
        {
            try
            {
                Init();
                ThreadInit();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private void Init()
        {
            client = new TcpClient("localhost", Port);
            networkStream = client.GetStream();
            message = new Message();
            input = new Input();
        }

        private void ThreadInit()
        {
            threadListen = new Thread(new ThreadStart(Listen));
            threadInput = new Thread(new ParameterizedThreadStart(input.StartInput));
            threadSay = new Thread(new ThreadStart(Say));
            threadListen.Start();
            threadInput.Start(message);
            threadSay.Start();
        }

        public void Say()
        {
            StreamWriter streamWriter = new StreamWriter(networkStream);

            while (true)
            {
                if (message.Available)
                {
                    streamWriter.WriteLine(message.MSG);
                    streamWriter.Flush();
                    message.Available = false;
                }
            }
        }

        public void Listen()
        {
            while (true)
            {
                StreamReader streamReader = new StreamReader(networkStream);
                if (networkStream.DataAvailable)
                {
                    Console.WriteLine(streamReader.ReadLine());
                }
            }
        }
    }
}
