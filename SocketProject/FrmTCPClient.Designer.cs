namespace SocketProject
{
    partial class FrmTCPClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTCPClient));
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.txt_File = new System.Windows.Forms.TextBox();
            this.txt_Send = new System.Windows.Forms.TextBox();
            this.lis_Rcv = new System.Windows.Forms.ListView();
            this.infoTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dis_server = new System.Windows.Forms.Button();
            this.btn_SendJSON = new System.Windows.Forms.Button();
            this.btn_SendHex = new System.Windows.Forms.Button();
            this.btn_SendUTF8 = new System.Windows.Forms.Button();
            this.btn_SendASCLL = new System.Windows.Forms.Button();
            this.btn_SendFile = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Prot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("黑体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(870, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "TCP传输客户端";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(2, 76);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SelectFile);
            this.splitContainer1.Panel1.Controls.Add(this.txt_File);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Send);
            this.splitContainer1.Panel1.Controls.Add(this.lis_Rcv);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dis_server);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendJSON);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendHex);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendUTF8);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendASCLL);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendFile);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Connect);
            this.splitContainer1.Panel2.Controls.Add(this.txt_UserName);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Prot);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txt_IP);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(868, 592);
            this.splitContainer1.SplitterDistance = 573;
            this.splitContainer1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "客户端消息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "客户端日志：";
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(453, 537);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(107, 27);
            this.btn_SelectFile.TabIndex = 3;
            this.btn_SelectFile.Text = "选择文件";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // txt_File
            // 
            this.txt_File.Location = new System.Drawing.Point(10, 538);
            this.txt_File.Name = "txt_File";
            this.txt_File.Size = new System.Drawing.Size(437, 28);
            this.txt_File.TabIndex = 2;
            // 
            // txt_Send
            // 
            this.txt_Send.Location = new System.Drawing.Point(10, 372);
            this.txt_Send.Multiline = true;
            this.txt_Send.Name = "txt_Send";
            this.txt_Send.Size = new System.Drawing.Size(553, 134);
            this.txt_Send.TabIndex = 1;
            // 
            // lis_Rcv
            // 
            this.lis_Rcv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.infoTime,
            this.info});
            this.lis_Rcv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lis_Rcv.HideSelection = false;
            this.lis_Rcv.Location = new System.Drawing.Point(10, 42);
            this.lis_Rcv.Margin = new System.Windows.Forms.Padding(10);
            this.lis_Rcv.Name = "lis_Rcv";
            this.lis_Rcv.Size = new System.Drawing.Size(553, 272);
            this.lis_Rcv.SmallImageList = this.imageList1;
            this.lis_Rcv.TabIndex = 0;
            this.lis_Rcv.UseCompatibleStateImageBehavior = false;
            this.lis_Rcv.View = System.Windows.Forms.View.Details;
            // 
            // infoTime
            // 
            this.infoTime.Text = "日志时间";
            this.infoTime.Width = 200;
            // 
            // info
            // 
            this.info.Text = "日志消息";
            this.info.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "消息,信息.png");
            this.imageList1.Images.SetKeyName(1, "警告.png");
            this.imageList1.Images.SetKeyName(2, "错误.png");
            // 
            // dis_server
            // 
            this.dis_server.Location = new System.Drawing.Point(154, 183);
            this.dis_server.Name = "dis_server";
            this.dis_server.Size = new System.Drawing.Size(125, 40);
            this.dis_server.TabIndex = 18;
            this.dis_server.Text = "断开服务器";
            this.dis_server.UseVisualStyleBackColor = true;
            this.dis_server.Click += new System.EventHandler(this.dis_server_Click);
            // 
            // btn_SendJSON
            // 
            this.btn_SendJSON.Location = new System.Drawing.Point(8, 423);
            this.btn_SendJSON.Name = "btn_SendJSON";
            this.btn_SendJSON.Size = new System.Drawing.Size(125, 40);
            this.btn_SendJSON.TabIndex = 17;
            this.btn_SendJSON.Text = "发送JSON";
            this.btn_SendJSON.UseVisualStyleBackColor = true;
            this.btn_SendJSON.Click += new System.EventHandler(this.btn_SendJSON_Click);
            // 
            // btn_SendHex
            // 
            this.btn_SendHex.Location = new System.Drawing.Point(8, 343);
            this.btn_SendHex.Name = "btn_SendHex";
            this.btn_SendHex.Size = new System.Drawing.Size(125, 40);
            this.btn_SendHex.TabIndex = 16;
            this.btn_SendHex.Text = "发送Hex";
            this.btn_SendHex.UseVisualStyleBackColor = true;
            this.btn_SendHex.Click += new System.EventHandler(this.btn_SendHex_Click);
            // 
            // btn_SendUTF8
            // 
            this.btn_SendUTF8.Location = new System.Drawing.Point(154, 263);
            this.btn_SendUTF8.Name = "btn_SendUTF8";
            this.btn_SendUTF8.Size = new System.Drawing.Size(125, 40);
            this.btn_SendUTF8.TabIndex = 15;
            this.btn_SendUTF8.Text = "发送UTF8";
            this.btn_SendUTF8.UseVisualStyleBackColor = true;
            this.btn_SendUTF8.Click += new System.EventHandler(this.btn_SendUTF8_Click);
            // 
            // btn_SendASCLL
            // 
            this.btn_SendASCLL.Location = new System.Drawing.Point(8, 263);
            this.btn_SendASCLL.Name = "btn_SendASCLL";
            this.btn_SendASCLL.Size = new System.Drawing.Size(125, 40);
            this.btn_SendASCLL.TabIndex = 14;
            this.btn_SendASCLL.Text = "发送ASCLL";
            this.btn_SendASCLL.UseVisualStyleBackColor = true;
            this.btn_SendASCLL.Click += new System.EventHandler(this.btn_SendASCLL_Click);
            // 
            // btn_SendFile
            // 
            this.btn_SendFile.Location = new System.Drawing.Point(154, 343);
            this.btn_SendFile.Name = "btn_SendFile";
            this.btn_SendFile.Size = new System.Drawing.Size(125, 40);
            this.btn_SendFile.TabIndex = 13;
            this.btn_SendFile.Text = "发送文件";
            this.btn_SendFile.UseVisualStyleBackColor = true;
            this.btn_SendFile.Click += new System.EventHandler(this.btn_SendFile_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(8, 183);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(125, 40);
            this.btn_Connect.TabIndex = 6;
            this.btn_Connect.Text = "连接服务器";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(108, 113);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.ReadOnly = true;
            this.txt_UserName.Size = new System.Drawing.Size(137, 28);
            this.txt_UserName.TabIndex = 5;
            this.txt_UserName.Text = "xiaodai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "用户名称：";
            // 
            // txt_Prot
            // 
            this.txt_Prot.Location = new System.Drawing.Point(109, 61);
            this.txt_Prot.Name = "txt_Prot";
            this.txt_Prot.ReadOnly = true;
            this.txt_Prot.Size = new System.Drawing.Size(137, 28);
            this.txt_Prot.TabIndex = 3;
            this.txt_Prot.Text = "8089";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "端    口：";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(108, 16);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(137, 28);
            this.txt_IP.TabIndex = 1;
            this.txt_IP.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "客户端IP：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmTCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 666);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmTCPClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Socket实现TCP客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTCPClient_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lis_Rcv;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.TextBox txt_File;
        private System.Windows.Forms.TextBox txt_Send;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Prot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader infoTime;
        private System.Windows.Forms.ColumnHeader info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button dis_server;
        private System.Windows.Forms.Button btn_SendJSON;
        private System.Windows.Forms.Button btn_SendHex;
        private System.Windows.Forms.Button btn_SendUTF8;
        private System.Windows.Forms.Button btn_SendASCLL;
        private System.Windows.Forms.Button btn_SendFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

