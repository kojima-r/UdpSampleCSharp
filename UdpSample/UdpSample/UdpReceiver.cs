using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UdpSample
{
    /// バッファ モードとコールバックモードに対応
    /// コールバックモードでは .Net のノンブロッキングモードで受信を行う
    /// バッファモードではスレッド＋ブロッキングモードで受信を行い、
    /// 受信データをバッファに溜め込む（コールバックを指定することも可能）
    class UdpReceiver
    {
        //共用変数
        private int listenPort;
        private UdpClient udp;
        private IPEndPoint ep;
        public delegate void onReceived(UdpReceivedData data);
        public onReceived receivedEvent;
        class UdpState
        {
            public IPEndPoint e;
            public UdpClient u;
        }
        //バッファ モード用変数
        private Thread thread;
        private volatile bool threadRunningFlag = false;
        private LinkedList<UdpReceivedData> buffer;
 
        /// <summary>
        /// 受信ポート指定、初期化
        /// </summary>
        /// <param name="port">受信ポート</param>
        public void Init(int port)
        {
            try{
                if (udp != null)
                {
                    udp.Close();
                }
                this.listenPort = port;
                ep = new IPEndPoint(IPAddress.Any, listenPort);
                udp = new UdpClient(ep);
            }
            catch (SocketException)
            {
                System.Windows.Forms.MessageBox.Show("すでに利用されています");
            }
        }
        /// <summary>
        /// 通信終了
        /// </summary>
        public void End()
        {
            threadRunningFlag = false;
            if (udp != null)
            {
                udp.Close();
                udp = null;
            }
        }
        /// <summary>
        /// 通信終了
        /// バッファモードでスレッドが立ち上がっていれば終了まで待つ
        /// </summary>
        public void EndAndWait()
        {
            threadRunningFlag = false;
            if (thread != null)
            {
                thread.Join();
            }
            if (udp != null)
            {
                udp.Close();
                udp = null;
            }
        }

        /// <summary>
        /// 通信が可能かどうか
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsOpen()
        {
            if(udp!=null){
                return true;
            }
            return false;
        }

        /// <summary>
        /// バッファモードで通信開始
        /// </summary>
        /// <param name="callback">受信時のコールバック関数：任意指定</param>
        public void Start(onReceived callback=null)
        {
            if (!threadRunningFlag)
            {
                receivedEvent = callback;
                buffer = new LinkedList<UdpReceivedData>();
                threadRunningFlag = true;
                thread = new Thread(new ThreadStart(Running));
                thread.Start();
            }
        }

        /// <summary>
        /// コールバックモードで通信開始
        /// </summary>
        /// <param name="callback">受信時のコールバック関数</param>
        public void StartWithCalllback(onReceived callback)
        {
            receivedEvent = callback;
            if (udp != null)
            {

                UdpState s = new UdpState();
                s.e = ep;
                s.u = udp;
                udp.BeginReceive(new AsyncCallback(ReceiveCallback), s);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
                IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;

                Byte[] receiveBytes = u.EndReceive(ar, ref e);
                ReceivedProcess(new UdpReceivedData(e, receiveBytes));
                StartWithCalllback(receivedEvent);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }
        private void ReceivedProcess(UdpReceivedData data){
            //コールバック呼び出し
            if (receivedEvent != null)
            {
                receivedEvent(data);
            }
            if (buffer!=null)
            {
                // ロックしてバッファに追加
                lock (((System.Collections.ICollection)buffer).SyncRoot)
                {
                    buffer.AddLast(data);
                }
            }
        }
        //スレッド関数
        private void Running()
        {
            while (threadRunningFlag)
            {
                try
                {
                    Thread.Sleep(1);//受信確認周期（チューニングが必要かも）
                    if (udp.Available > 0)
                    {
                        // データ受信
                        System.Net.IPEndPoint remote =
                            new System.Net.IPEndPoint(
                            System.Net.IPAddress.Any, 0);
                        Byte[] rdat = udp.Receive(ref remote);
                        ReceivedProcess(new UdpReceivedData(remote, rdat));
                    }
                }
                catch (NullReferenceException)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// バッファからデータを取り出す（バッファモード時のみ）
        /// </summary>
        /// <returns>バッファ中の最も古いデータ</returns>
        public UdpReceivedData PopReceivedData()
        {
            if (buffer == null)
            {
                return null;
            }
            lock (((System.Collections.ICollection)buffer).SyncRoot)
            {
                if (buffer.Count == 0)
                {
                    return null;
                }
                else
                {
                    UdpReceivedData res = buffer.First.Value;
                    buffer.RemoveFirst();
                    return res;
                }
            }
        }
        /// <summary>
        /// バッファをクリア（バッファモード時のみ）
        /// </summary>
        public void ClearReceivedData()
        {
            if (buffer == null)
            {
                return;
            }
            lock (((System.Collections.ICollection)buffer).SyncRoot)
            {
                buffer.Clear();
            }
        }
    }
}
