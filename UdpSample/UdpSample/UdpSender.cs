using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace UdpSample
{
    class UdpSender
    {
        private string host;
        private int port;
        private UdpClient udp;
        /// <summary>
        /// 基本送信情報を指定して初期化
        /// </summary>
        /// <param name="host">送信先ホスト名</param>
        /// <param name="port">送信先ポート名</param>
        public void Init(string host, int port)
        {
            this.host = host;
            this.port = port;
            if (udp != null)
            {
                udp.Close();
            }
            udp = new UdpClient();
        }
        /// <summary>
        /// テキスト送信
        /// </summary>
        /// <param name="str"></param>
        public void Send(String str)
        {
            Encoding enc = Encoding.UTF8;
            byte[] SendBytes = enc.GetBytes(str);
            Send(SendBytes);
        }
        /// <summary>
        /// バイト列送信
        /// </summary>
        /// <param name="SendBytes"></param>
        public void Send(byte[] SendBytes)
        {
            udp.Send(SendBytes, SendBytes.Length, host, port);
        }
    }
}
