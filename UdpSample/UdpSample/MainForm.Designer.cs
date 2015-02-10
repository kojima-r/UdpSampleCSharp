namespace UdpSample
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSendData = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxPortDest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelReceiverStatus = new System.Windows.Forms.Label();
            this.buttonRecvStop = new System.Windows.Forms.Button();
            this.buttonRecvStart = new System.Windows.Forms.Button();
            this.textBoxListenPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.timerStatusCheck = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxCRLF = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "ホスト名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCRLF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxSendData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxHost);
            this.groupBox1.Controls.Add(this.buttonSend);
            this.groupBox1.Controls.Add(this.textBoxPortDest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 139);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "送信";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "送信テキスト";
            // 
            // textBoxSendData
            // 
            this.textBoxSendData.Location = new System.Drawing.Point(20, 82);
            this.textBoxSendData.Name = "textBoxSendData";
            this.textBoxSendData.Size = new System.Drawing.Size(188, 19);
            this.textBoxSendData.TabIndex = 27;
            this.textBoxSendData.Text = "abcあいう";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(109, 14);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(100, 19);
            this.textBoxHost.TabIndex = 25;
            this.textBoxHost.Text = "127.0.0.1";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(6, 105);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "送信";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxPortDest
            // 
            this.textBoxPortDest.Location = new System.Drawing.Point(108, 39);
            this.textBoxPortDest.Name = "textBoxPortDest";
            this.textBoxPortDest.Size = new System.Drawing.Size(100, 19);
            this.textBoxPortDest.TabIndex = 7;
            this.textBoxPortDest.Text = "2002";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "送信ポート";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelReceiverStatus);
            this.groupBox2.Controls.Add(this.buttonRecvStop);
            this.groupBox2.Controls.Add(this.buttonRecvStart);
            this.groupBox2.Controls.Add(this.textBoxListenPort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(262, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 139);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "受信";
            // 
            // labelReceiverStatus
            // 
            this.labelReceiverStatus.AutoSize = true;
            this.labelReceiverStatus.Location = new System.Drawing.Point(107, 51);
            this.labelReceiverStatus.Name = "labelReceiverStatus";
            this.labelReceiverStatus.Size = new System.Drawing.Size(62, 12);
            this.labelReceiverStatus.TabIndex = 12;
            this.labelReceiverStatus.Text = "状態：close";
            // 
            // buttonRecvStop
            // 
            this.buttonRecvStop.Location = new System.Drawing.Point(6, 76);
            this.buttonRecvStop.Name = "buttonRecvStop";
            this.buttonRecvStop.Size = new System.Drawing.Size(75, 23);
            this.buttonRecvStop.TabIndex = 11;
            this.buttonRecvStop.Text = "停止";
            this.buttonRecvStop.UseVisualStyleBackColor = true;
            this.buttonRecvStop.Click += new System.EventHandler(this.buttonRecvStop_Click);
            // 
            // buttonRecvStart
            // 
            this.buttonRecvStart.Location = new System.Drawing.Point(6, 47);
            this.buttonRecvStart.Name = "buttonRecvStart";
            this.buttonRecvStart.Size = new System.Drawing.Size(75, 23);
            this.buttonRecvStart.TabIndex = 3;
            this.buttonRecvStart.Text = "開始";
            this.buttonRecvStart.UseVisualStyleBackColor = true;
            this.buttonRecvStart.Click += new System.EventHandler(this.buttonRecvStart_Click);
            // 
            // textBoxListenPort
            // 
            this.textBoxListenPort.Location = new System.Drawing.Point(109, 21);
            this.textBoxListenPort.Name = "textBoxListenPort";
            this.textBoxListenPort.Size = new System.Drawing.Size(100, 19);
            this.textBoxListenPort.TabIndex = 7;
            this.textBoxListenPort.Text = "2002";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "待ち受けポート";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(12, 177);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(466, 126);
            this.textBoxStatus.TabIndex = 29;
            // 
            // timerStatusCheck
            // 
            this.timerStatusCheck.Enabled = true;
            this.timerStatusCheck.Tick += new System.EventHandler(this.timerStatusCheck_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "受信データ";
            // 
            // checkBoxCRLF
            // 
            this.checkBoxCRLF.AutoSize = true;
            this.checkBoxCRLF.Location = new System.Drawing.Point(149, 109);
            this.checkBoxCRLF.Name = "checkBoxCRLF";
            this.checkBoxCRLF.Size = new System.Drawing.Size(59, 16);
            this.checkBoxCRLF.TabIndex = 29;
            this.checkBoxCRLF.Text = "CR/LF";
            this.checkBoxCRLF.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 315);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "UdpSample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxPortDest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.TextBox textBoxSendData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRecvStart;
        private System.Windows.Forms.TextBox textBoxListenPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonRecvStop;
        private System.Windows.Forms.Timer timerStatusCheck;
        private System.Windows.Forms.Label labelReceiverStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxCRLF;
    }
}

