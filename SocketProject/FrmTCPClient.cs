using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SocketProject.FrmTCPServer;

namespace SocketProject
{
    public partial class FrmTCPClient : Form
    {
        // 服务器套接字
        private Socket socketService;
        // 创建字典集合，键是Clientlp,值是SocketClient
        private Dictionary<string, Socket> CurrentClientlist = new Dictionary<string, Socket>();
        public FrmTCPClient()
        {
            InitializeComponent();
            this.Load += FrmTCPClient_Load;
        }
        /*
         * 客户端程序编写步骤：
         *  第一步：调用socket函数创建一个用于通信的套接字
         *  第二步：通过设置套接字地址结构，说明客户端与之通信的服务器的IP地址和端口号。
         *  第三步：调用connectO函数来建立与服务器的连接。
         *  第四步：调用读写函数发送或者接收数据。
         *  第五步：终止连接。
         * */
        private Socket socketClient;
        private void FrmTCPClient_Load(object sender, EventArgs e)
        {
            this.lis_Rcv.Columns[1].Width = this.lis_Rcv.ClientSize.Width-this.lis_Rcv.Columns[0].Width;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            AddLog(0, "与服务器连接中");
            // 第一步：调用socketO函数创建一个用于通信的套接字
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 第二步：通过设置套接字地址结构，说明客户端与之通信的服务器的IP地址和端口号。
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(this.txt_IP.Text.Trim()), int.Parse(this.txt_Prot.Text.Trim()));
            // 第三步：调用connectO函数来建立与服务器的连接。
            try
            {
                socketClient.Connect(ipe);
            }
            catch (Exception ex)
            {
                AddLog(2, "连接服务器失败:"+ ex.Message);
                return;
            }
            Task.Run(new Action(() =>
            {
                CheckReceiveMsg();
            }));
            AddLog(0, "成功连接至服务器");
            this.btn_Connect.Enabled = false;
        }

        private void CheckReceiveMsg()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 10];
                int length = -1;
                // 第四步：调用读写函数发送或者接收数据。
                try
                {
                    length = socketClient.Receive(buffer);
                }
                catch (Exception)
                {
                    AddLog(2, "服务器断开连接");
                    break;
                }
                if (length > 0)
                {
                    string msg = Encoding.Default.GetString(buffer, 0, length);
                    AddLog(0, "服务器：" + msg);
                }
                else
                {
                    AddLog(2, "服务器断开连接");
                    break;
                }
            }
        }

        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm-ss"); }
        }
        #region 接收信息的方法体
        private void AddLog(int index, string info)
        {
            if (!this.lis_Rcv.InvokeRequired)
            {
                ListViewItem lst = new ListViewItem(" " + CurrentTime, index);
                lst.SubItems.Add(info);
                // 最新消息置顶
                lis_Rcv.Items.Insert(lis_Rcv.Items.Count, lst);
            }
            else
            {
                Invoke(new Action(() =>
                {
                    ListViewItem lst = new ListViewItem(" " + CurrentTime, index);
                    lst.SubItems.Add(info);
                    // 最新消息置顶
                    lis_Rcv.Items.Insert(lis_Rcv.Items.Count, lst);
                }));
            }
        }
        #endregion

        #region 关闭窗体
        private void FrmTCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            socketClient?.Close();
        }
        #endregion

        #region 服务器断开
        private void dis_server_Click(object sender, EventArgs e)
        {
            socketClient?.Close();
        }
        #endregion

        #region 客户端发送ASCLL消息
        private void btn_SendASCLL_Click(object sender, EventArgs e)
        {
            AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());

            byte[] send = Encoding.Default.GetBytes(this.txt_Send.Text.Trim());
            byte[] sendMsg = new byte[send.Length + 1];
            // 整体拷贝数组
            Array.Copy(send, 0, sendMsg, 1, send.Length);
            // 首字节赋值
            sendMsg[0] = (byte)MessageType.ASCLL;
            if (socketClient != null)
            {
                socketClient?.Send(sendMsg);
            }
            this.txt_Send.Clear();
        }
        #endregion


        #region 客户端发送UTF8
        private void btn_SendUTF8_Click(object sender, EventArgs e)
        {
            AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());

            byte[] send = Encoding.UTF8.GetBytes(this.txt_Send.Text.Trim());
            byte[] sendMsg = new byte[send.Length + 1];
            // 整体拷贝数组
            Array.Copy(send, 0, sendMsg, 1, send.Length);
            // 首字节赋值
            sendMsg[0] = (byte)MessageType.UTF8;
            if (socketClient != null)
            {
                socketClient?.Send(sendMsg);
            }
            this.txt_Send.Clear();
        }
        #endregion

        #region 客户端发送Hex
        private void btn_SendHex_Click(object sender, EventArgs e)
        {
            AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());

            byte[] send = Encoding.Default.GetBytes(this.txt_Send.Text.Trim());
            byte[] sendMsg = new byte[send.Length + 1];
            // 整体拷贝数组
            Array.Copy(send, 0, sendMsg, 1, send.Length);
            // 首字节赋值
            sendMsg[0] = (byte)MessageType.Hex;
            if (socketClient != null)
            {
                socketClient?.Send(sendMsg);
            }
            this.txt_Send.Clear();
        }
        #endregion

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //设置默认路径
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txt_File.Text = ofd.FileName;
            }
        }

        private void btn_SendFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_File.Text))
            {
                MessageBox.Show("请先选择您要发送的文件", "发送文件");
            }
            else
            {
                #region 客户端文件发送
                //文件发送为两次，第一次为告知文件名称，第二次为发送文件内容
                // 发送名称
                using (FileStream fs = new FileStream(this.txt_File.Text, FileMode.Open))
                {
                    //获取文件名称
                    //获取文件后缀
                    string filename = Path.GetFileName(this.txt_File.Text);
                    string fileExtension = Path.GetExtension(this.txt_File.Text);
                    string strMsg = "发送" + filename + "." + fileExtension;
                    byte[] send1 = Encoding.Default.GetBytes(strMsg);
                    byte[] send1Msg = new byte[send1.Length + 1];
                    Array.Copy(send1, 0, send1Msg, 1, send1.Length);
                    send1Msg[0] = (byte)MessageType.UTF8;
                    socketClient?.Send(send1Msg);

                    //发送文件内容
                    byte[] send2 = new byte[1024 * 1024 * 10];
                    int lenght = fs.Read(send2, 0, send2.Length);
                    byte[] send2Msg = new byte[lenght + 1];
                    Array.Copy(send2, 0, send2Msg, 1, lenght);
                    send2Msg[0] = (byte)MessageType.File;
                    socketClient?.Send(send2Msg);
                    #endregion
                }
        }
        }
    }
}
