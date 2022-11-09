namespace SocketProject
{
    partial class FrmTCPServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTCPServer));
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_File = new System.Windows.Forms.TextBox();
            this.txt_Send = new System.Windows.Forms.TextBox();
            this.lis_Rcv = new System.Windows.Forms.ListView();
            this.infoTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_clitent = new System.Windows.Forms.Button();
            this.btn_SendMsg = new System.Windows.Forms.Button();
            this.btn_SendAll = new System.Windows.Forms.Button();
            this.btn_SendFile = new System.Windows.Forms.Button();
            this.btn_StartService = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lis_Online = new System.Windows.Forms.ListBox();
            this.txt_Prot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("黑体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(870, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "TCP传输服务器";
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
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_File);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Send);
            this.splitContainer1.Panel1.Controls.Add(this.lis_Rcv);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.btn_clitent);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendMsg);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendAll);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendFile);
            this.splitContainer1.Panel2.Controls.Add(this.btn_StartService);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lis_Online);
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
            this.label6.Text = "服务器消息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "服务器日志：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "选择文件";
            this.button1.UseVisualStyleBackColor = true;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 529);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 42);
            this.button4.TabIndex = 12;
            this.button4.Text = "发送JSON";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 457);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 42);
            this.button3.TabIndex = 11;
            this.button3.Text = "发送Hex";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 44);
            this.button2.TabIndex = 10;
            this.button2.Text = "发送UTF8";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_clitent
            // 
            this.btn_clitent.Location = new System.Drawing.Point(161, 313);
            this.btn_clitent.Name = "btn_clitent";
            this.btn_clitent.Size = new System.Drawing.Size(118, 44);
            this.btn_clitent.TabIndex = 9;
            this.btn_clitent.Text = "启动客户端";
            this.btn_clitent.UseVisualStyleBackColor = true;
            this.btn_clitent.Click += new System.EventHandler(this.btn_clitent_Click);
            // 
            // btn_SendMsg
            // 
            this.btn_SendMsg.Location = new System.Drawing.Point(7, 385);
            this.btn_SendMsg.Name = "btn_SendMsg";
            this.btn_SendMsg.Size = new System.Drawing.Size(134, 42);
            this.btn_SendMsg.TabIndex = 8;
            this.btn_SendMsg.Text = "发送ASCLL";
            this.btn_SendMsg.UseVisualStyleBackColor = true;
            this.btn_SendMsg.Click += new System.EventHandler(this.btn_SendMsg_Click);
            // 
            // btn_SendAll
            // 
            this.btn_SendAll.Location = new System.Drawing.Point(161, 526);
            this.btn_SendAll.Name = "btn_SendAll";
            this.btn_SendAll.Size = new System.Drawing.Size(118, 44);
            this.btn_SendAll.TabIndex = 7;
            this.btn_SendAll.Text = "群发消息";
            this.btn_SendAll.UseVisualStyleBackColor = true;
            this.btn_SendAll.Click += new System.EventHandler(this.btn_SendAll_Click);
            // 
            // btn_SendFile
            // 
            this.btn_SendFile.Location = new System.Drawing.Point(161, 455);
            this.btn_SendFile.Name = "btn_SendFile";
            this.btn_SendFile.Size = new System.Drawing.Size(118, 44);
            this.btn_SendFile.TabIndex = 6;
            this.btn_SendFile.Text = "发送文件";
            this.btn_SendFile.UseVisualStyleBackColor = true;
            // 
            // btn_StartService
            // 
            this.btn_StartService.Location = new System.Drawing.Point(7, 313);
            this.btn_StartService.Name = "btn_StartService";
            this.btn_StartService.Size = new System.Drawing.Size(134, 42);
            this.btn_StartService.TabIndex = 4;
            this.btn_StartService.Text = "启动服务";
            this.btn_StartService.UseVisualStyleBackColor = true;
            this.btn_StartService.Click += new System.EventHandler(this.btn_StartService_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "在线列表：";
            // 
            // lis_Online
            // 
            this.lis_Online.FormattingEnabled = true;
            this.lis_Online.ItemHeight = 18;
            this.lis_Online.Location = new System.Drawing.Point(7, 130);
            this.lis_Online.Name = "lis_Online";
            this.lis_Online.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lis_Online.Size = new System.Drawing.Size(239, 166);
            this.lis_Online.TabIndex = 4;
            // 
            // txt_Prot
            // 
            this.txt_Prot.Location = new System.Drawing.Point(108, 52);
            this.txt_Prot.Name = "txt_Prot";
            this.txt_Prot.ReadOnly = true;
            this.txt_Prot.Size = new System.Drawing.Size(137, 28);
            this.txt_Prot.TabIndex = 3;
            this.txt_Prot.Text = "8089";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "端    口：";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(107, 7);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(137, 28);
            this.txt_IP.TabIndex = 1;
            this.txt_IP.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器IP：";
            // 
            // FrmTCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 666);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmTCPServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Socket实现TCP服务器";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_File;
        private System.Windows.Forms.TextBox txt_Send;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Prot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lis_Online;
        private System.Windows.Forms.Button btn_StartService;
        private System.Windows.Forms.Button btn_SendMsg;
        private System.Windows.Forms.Button btn_SendAll;
        private System.Windows.Forms.Button btn_SendFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader infoTime;
        private System.Windows.Forms.ColumnHeader info;
        private System.Windows.Forms.Button btn_clitent;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

