using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace testWS
{
    public class UniversalStream
    {
        /// <summary>
        /// Creates an object of UniversalStream class.
        /// </summary>
        /// <param name="client">TcpClient to work with his network stream.</param>
        public UniversalStream(TcpClient client)
        {
            this.client = client;
            this.stream = client.GetStream();
        }

        private TcpClient client;
        private NetworkStream stream;
        private byte[] message;

        /// <summary>
        /// Reads all available data.
        /// </summary>
        /// <returns>Data from stream.</returns>
        public string Read()
        {
            byte[] bytes = new byte[client.Available];
            stream.Read(bytes, 0, bytes.Length);
            message = (byte[])bytes.Clone();
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Use this method after Read() only in case of WebSocket connection.
        /// </summary>
        /// <returns>Returns decrypted string.</returns>
        public string Decode()
        {
            return DecodeMessage(message);
        }

        /// <summary>
        /// Writes message to TcpClient's stream.
        /// </summary>
        /// <param name="message">Message to send.</param>
        /// <param name="useWebSocketHeader">In case of WebSocket connection must be true, alias false.</param>
        public void Write(string message, bool useWebSocketHeader = true)
        {
            byte[] response;

            if (useWebSocketHeader)
            {
                response = Encoding.UTF8.GetBytes("  " + message);
                response[0] = 0x81; // denotes this is the final message and it is in text
                response[1] = Convert.ToByte(response.Length - 2); // payload size = message - header size
            }
            else
            {
                response = Encoding.UTF8.GetBytes(message);
            }

            stream.Write(response, 0, response.Length);
        }

        /// <summary>
        /// Formation of handshake message for response.
        /// </summary>
        /// <param name="data">Data from client's initial message</param>
        public void WriteHandshake(string data)
        {
            string message = "HTTP/1.1 101 Switching Protocols" + Environment.NewLine
                + "Connection: Upgrade" + Environment.NewLine
                + "Upgrade: websocket" + Environment.NewLine
                + "Sec-WebSocket-Accept: "
                + Convert.ToBase64String(
                    SHA1.Create().ComputeHash(
                        Encoding.UTF8.GetBytes(
                            new Regex("Sec-WebSocket-Key: (.*)").Match(data).Groups[1].Value.Trim()
                                + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                        )
                    )
                ) + Environment.NewLine
                + Environment.NewLine;

            byte[] response = Encoding.UTF8.GetBytes(message);
            stream.Write(response, 0, response.Length);
        }

        private string DecodeMessage(byte[] bytes)
        {
            string incomingData = string.Empty;
            byte secondbyte = bytes[1];
            int dataLength = secondbyte & 127;
            int indexFirstMask = 2;
            if (dataLength == 126)
                indexFirstMask = 4;
            else if (dataLength == 127)
                indexFirstMask = 10;

            IEnumerable<byte> keys = bytes.Skip(indexFirstMask).Take(4);
            int indexFirstDatabyte = indexFirstMask + 4;

            byte[] decoded = new byte[bytes.Length - indexFirstDatabyte];
            for (int i = indexFirstDatabyte, j = 0; i < bytes.Length; i++, j++)
            {
                decoded[j] = (byte)(bytes[i] ^ keys.ElementAt(j % 4));
            }

            return incomingData = Encoding.UTF8.GetString(decoded, 0, decoded.Length);
        }

        private byte[] EncodeMessageToSend(string message)
        {
            byte[] response;
            byte[] bytesRaw = Encoding.UTF8.GetBytes(message);
            byte[] frame = new byte[10];

            int indexStartRawData = -1;
            int length = bytesRaw.Length;

            frame[0] = (byte)129;
            if (length <= 125)
            {
                frame[1] = (byte)length;
                indexStartRawData = 2;
            }
            else if (length >= 126 && length <= 65535)
            {
                frame[1] = (byte)126;
                frame[2] = (byte)((length >> 8) & 255);
                frame[3] = (byte)(length & 255);
                indexStartRawData = 4;
            }
            else
            {
                frame[1] = (byte)127;
                frame[2] = (byte)((length >> 56) & 255);
                frame[3] = (byte)((length >> 48) & 255);
                frame[4] = (byte)((length >> 40) & 255);
                frame[5] = (byte)((length >> 32) & 255);
                frame[6] = (byte)((length >> 24) & 255);
                frame[7] = (byte)((length >> 16) & 255);
                frame[8] = (byte)((length >> 8) & 255);
                frame[9] = (byte)(length & 255);

                indexStartRawData = 10;
            }

            response = new byte[indexStartRawData + length];

            int i, reponseIdx = 0;

            //Add the frame bytes to the reponse
            for (i = 0; i < indexStartRawData; i++)
            {
                response[reponseIdx] = frame[i];
                reponseIdx++;
            }

            //Add the data bytes to the response
            for (i = 0; i < length; i++)
            {
                response[reponseIdx] = bytesRaw[i];
                reponseIdx++;
            }

            return response;
        }
    }
}
