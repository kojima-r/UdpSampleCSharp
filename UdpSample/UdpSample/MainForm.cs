using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private UdpSender udpSender = new UdpSender();
        private UdpReceiver udpReceiver = new UdpReceiver();
        private void Form1_Load(object sender, EventArgs e)
        {
            //終了時のイベント
            this.FormClosed += new FormClosedEventHandler(this.MainForm_Closed);
        }
        private void MainForm_Closed(object sender, EventArgs e)
        {
            //終了時に受信を終了する
            udpReceiver.End();
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                //ホスト名・ポート番号を取得して、テキストを送信する
                string host = textBoxHost.Text;
                int port = int.Parse(textBoxPortDest.Text);
                udpSender.Init(host, port);
                if (checkBoxCRLF.Checked)
                {
                    udpSender.Send(textBoxSendData.Text+"\r\n");
                }
                else
                {
                    udpSender.Send(textBoxSendData.Text);
                }
                
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("不明なホスト・ポートです");
            }
            catch (FormatException)
            {
                MessageBox.Show("ポート番号が不正な値です");
            }
        }

        /// <summary>
        /// コールバック関数をメインスレッドから呼び出しなおすためのデリゲート
        /// </summary>
        private delegate void delegateReceived(UdpReceivedData data);
        /// <summary>
        /// 受信時にコールバックされる関数
        /// </summary>
        /// <param name="data">受信データ（送信元情報含む）</param>
        private void received(UdpReceivedData data)
        {
            if (textBoxStatus.InvokeRequired)
            {
                //メインスレッド以外から呼び出されたので、メインスレッドで呼びなおす
                this.Invoke(new delegateReceived(received),new object[]{data});
            }
            else
            {
                //通信内容をテキストボックスに表示
                textBoxStatus.Text += data.sender.Address.ToString();
                textBoxStatus.Text += ":";
                textBoxStatus.Text += data.GetText();
                textBoxStatus.Text += "\r\n";
                //末尾までスクロール
                textBoxStatus.SelectionStart = textBoxStatus.Text.Length;
                textBoxStatus.Focus();
                textBoxStatus.ScrollToCaret();
            }
        }
        private void buttonRecvStart_Click(object sender, EventArgs e)
        {
            try
            {
                //指定されたポート番号で受信開始
                int port = int.Parse(textBoxListenPort.Text);
                udpReceiver.Init(port);
                //コールバックモードで受信
                udpReceiver.StartWithCalllback(received);

                //
                //バッファモードで受信
                //バッファに溜まり続けるので注意
                //udpReceiver.Start(received);
                //
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("ソケットエラーです。不正なポート番号を指定した可能性があります。");
            }
            catch (FormatException)
            {
                MessageBox.Show("ポート番号が不正な値です");
            }
        }

        private void buttonRecvStop_Click(object sender, EventArgs e)
        {
            udpReceiver.End();
        }

        private void timerStatusCheck_Tick(object sender, EventArgs e)
        {
            //受信の状態を確認する。
            if (udpReceiver.IsOpen())
            {
                labelReceiverStatus.Text = "状態：Open";
            }
            else
            {
                labelReceiverStatus.Text = "状態：Close";
            }
        }
    }
}
