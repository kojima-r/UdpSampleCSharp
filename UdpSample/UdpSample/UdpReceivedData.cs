using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UdpSample
{
    class UdpReceivedData
    {
        public UdpReceivedData(System.Net.IPEndPoint sender, Byte[] data)
        {
            this.sender = sender;
            this.data = data;
        }
        /// <summary>
        /// 送信元情報
        /// </summary>
        public System.Net.IPEndPoint sender;
        /// <summary>
        /// 受信データ（バイト列）
        /// </summary>
        public Byte[] data;
        /// <summary>
        /// 受信データをテキスト化して取得(UTF-8)
        /// </summary>
        /// <returns></returns>
        public String GetText()
        {
            return System.Text.Encoding.GetEncoding("UTF-8").GetString(data);
        }
    }
}
