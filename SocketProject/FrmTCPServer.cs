using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketProject
{
    public partial class FrmTCPServer : Form
    {
        public enum MessageType
        {
            ASCLL,
            UTF8,
            Hex,
            File,
            JSON
        }
        // 服务器套接字
        private Socket socketService;
        // 创建字典集合，键是Clientlp,值是SocketClient
        private Dictionary<string, Socket> CurrentClientlist = new Dictionary<string, Socket>();
        public FrmTCPServer()
        {
            InitializeComponent();
            this.Load += FrmTCPServer_Load;
        }

        private void FrmTCPServer_Load(object sender, EventArgs e)
        {
            this.lis_Rcv.Columns[1].Width = this.lis_Rcv.ClientSize.Width-this.lis_Rcv.Columns[0].Width;
        }

        /*
        服务器端程序的编写步骤：
        第一步：调用socket(）函数创建一个用于通信的套接字。
        第二步：给已经创建的套接字绑定一个端口号，这一般通过设置网络套接口地址和调用bind（）函数来实现
        第三步：调用Listen()函数使套接字成为一个监听套接字。
        第四步：调用accept()函数来接受客户端的连接，这是就可以和客户端通信了。
        第五步：处理客户端的连接请求。
        第六步：终止连接
        */
        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartService_Click(object sender, EventArgs e)
        {
            // 第一步：调用socket(）函数创建一个用于通信的套接字
            socketService = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(this.txt_IP.Text), int.Parse(this.txt_Prot.Text));
            try
            {
                // 第二步：给已经创建的套接字绑定一个端口号，这一般通过设置网络套接口地址和调用bind()函数来实现
                socketService.Bind(ipe);
            }
            catch (Exception ex)
            {
                // 写入日志
                AddLog(2, "服务器开启失败"+ex.Message);
            }
            // 第三步：调用Listen()函数使套接字成为一个监听套接字
            // 10为缓存池大小
            socketService.Listen(10);

            //监听线程创建
            Task.Run(new Action(() =>
            {
                CheckListening();
            }));
            AddLog(0, "服务器开启成功");
            this.btn_StartService.Enabled = false;
        }
        /// <summary>
        /// 检查监听线程的方法体
        /// </summary>
        private void CheckListening()
        {
            while (true)
            {
                // 阻塞式（连接时启动）
                Socket socketClient = socketService.Accept();
                string client = socketClient.RemoteEndPoint.ToString();
                AddLog(0, client + "上线了");
                CurrentClientlist.Add(client, socketClient);
                UpdateOnline(client, true);


                Task.Run(new Action(() =>
                {
                    ReceiveMessage(socketClient);
                }));
            }
        }
        #region 多线程接收数据
        /// <summary>
        /// 接收客户端消息的方法体
        /// </summary>
        /// <param name="socketClient"></param>
        private void ReceiveMessage(Socket socketClient)
        {
            while (true)
            {
                //创建缓冲区
                byte[] buffer = new byte[1024 * 1024 * 10];
                int length = -1;
                // 获取客户端IP地址
                string client = socketClient.RemoteEndPoint.ToString();
                // 第五步：处理客户端的连接请求。
                try
                {
                    length = socketClient.Receive(buffer);
                }
                catch (Exception)
                {
                    UpdateOnline(client, false);
                    AddLog(0, client + "下线了");
                    CurrentClientlist.Remove(client);
                    break;
                }
                if (length > 0)
                {
                    string msg = string.Empty;
                    MessageType type = (MessageType)buffer[0];
                    switch (type)
                    {
                        case MessageType.ASCLL:
                            msg = Encoding.ASCII.GetString(buffer, 1, length-1);
                            AddLog(0, client + "：" + msg);
                            break;
                        case MessageType.UTF8:
                            msg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                            AddLog(0, client + "：" + msg);
                            break;
                        case MessageType.Hex:
                            msg = HexString(buffer, 1, length - 1);
                            AddLog(0, client + "：" + msg);
                            break;
                        case MessageType.File:
                            break;
                        case MessageType.JSON:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    UpdateOnline(client, false);
                    AddLog(0, client + "下线了");
                    CurrentClientlist.Remove(client);
                    break;
                }
            }
        }
        #endregion
        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm-ss"); }
        }
        #region 接收信息的方法体
        private void AddLog(int index,string info)
        {
            if (!this.lis_Rcv.InvokeRequired)
            {
                ListViewItem lst = new ListViewItem(" "+ CurrentTime, index);
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

        #region 在线列表更新
        private void UpdateOnline(string client,bool operate)
        {
            if (!this.lis_Online.InvokeRequired)
            {
                if (operate)
                {
                    this.lis_Online.Items.Add(client);
                }
                else
                {
                    foreach (string item in this.lis_Online.Items)
                    {
                        if (item==client)
                        {
                            this.lis_Online.Items.Remove(item);
                            break;
                        }
                    }
                }
            }
            else
            {
                Invoke(new Action(() =>
                {
                    if (operate)
                    {
                        this.lis_Online.Items.Add(client);
                    }
                    else
                    {
                        foreach (string item in this.lis_Online.Items)
                        {
                            if (item == client)
                            {
                                this.lis_Online.Items.Remove(item);
                                break;
                            }
                        }
                    }
                }));
            }
        }
        #endregion

        #region 16进制字符串处理
        private string HexString(byte[] buffer,int start,int lenght)
        {
            string Result = string.Empty;
            if (buffer != null && buffer.Length >= start + lenght)
            {
                // 截取字节数组
                byte[] res = new byte[lenght];
                Array.Copy(buffer, start, res, 0, lenght);
                string Hex = Encoding.Default.GetString(res, 0, res.Length);
                if (Hex.Contains(" "))
                {
                    string[] str = Regex.Split(Hex, "\\s+", RegexOptions.IgnoreCase);
                    foreach (var item in str)
                    {
                        Result += "0x" + item + " ";
                    }
                }
                else
                {
                    Result += "0x" + Hex;
                }
            }
            else
            {
                Result = "Error";
            }
            return Result;
        }
        #endregion

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            if (this.lis_Online.SelectedIndex != null)
            {
                AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());
                string client = default;
                if (this.lis_Online.Items.Count == 0)
                {
                    MessageBox.Show("客户端未连接服务器,请重试","错误");
                    return;
                }
                else
                {
                    if (this.lis_Online.Items.Count <= 1)
                    {
                        client = this.lis_Online.Items[0].ToString();
                        CurrentClientlist[client].Send(Encoding.Default.GetBytes(this.txt_Send.Text.Trim()));
                    }
                    else
                    {
                        foreach (var item in this.lis_Online.Items)
                        {
                            client = item.ToString();
                            CurrentClientlist[client].Send(Encoding.Default.GetBytes(this.txt_Send.Text.Trim()));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择你要发送的客户对象！", "发送消息");
            }
        }

        private void btn_SendAll_Click(object sender, EventArgs e)
        {
            if (this.lis_Online.Items.Count > 0)
            {
                foreach (string item in this.lis_Online.Items)
                {
                    CurrentClientlist[item].Send(Encoding.Default.GetBytes(this.txt_Send.Text.Trim()));
                }
            }
            else
            {
                MessageBox.Show("当前连接的客户端对象数量为0！", "发送消息");
            }
        }

        private void btn_clitent_Click(object sender, EventArgs e)
        {
            new FrmTCPClient().Show();
        }
    }
}
