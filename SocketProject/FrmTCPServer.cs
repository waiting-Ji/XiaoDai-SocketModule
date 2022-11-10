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
                            Invoke(new Action(() =>
                            {
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Filter = "txt files(*.txt)*.txt|xls files(*.xlsx)|*.xlsx|All files(*.*)|*.*";
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    string fileSavePath = sfd.FileName;
                                    using (FileStream fs = new FileStream(fileSavePath, FileMode.Create))
                                    {
                                        fs.Write(buffer, 1, length);
                                    }
                                    AddLog(0, "文件成功保存至：" + fileSavePath);
                                }
                            }));
                            break;
                        case MessageType.JSON:
                            Invoke(new Action(() =>
                            {
                                string res = Encoding.Default.GetString(buffer,1,length);
                                List<Student> studentList = JSONHelper.JsonToEntity<List<Student>>(res);
                                new FrmJSON(studentList).Show();
                                AddLog(0, "接收JSON数据：" + res);
                            }));
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
                    var s = this.lis_Online.Items.Count;
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


        #region 启动客户端
        private void btn_clitent_Click(object sender, EventArgs e)
        {
            new FrmTCPClient().Show();
        }
        #endregion

        #region 服务端发送ASCLL
        private void btn_SendASCLL_Click(object sender, EventArgs e)
        {
            if (this.lis_Online.SelectedItems.Count > 0)
            {
                AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());
                byte[] send = Encoding.Default.GetBytes(this.txt_Send.Text.Trim());
                byte[] sendMsg = new byte[send.Length + 1];
                // 整体拷贝数组
                Array.Copy(send, 0, sendMsg, 1, send.Length);
                // 首字节赋值
                sendMsg[0] = (byte)MessageType.ASCLL;
                foreach (var item in this.lis_Online.SelectedItems)
                {
                    string client = item.ToString();
                    CurrentClientlist[client]?.Send(sendMsg);
                }
                this.txt_Send.Clear();
            }
            else
            {
                MessageBox.Show("请选择你要发送的客户端对象！", "发送消息");
            }

            AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());
        }
        #endregion

        #region 服务端发送UTF8
        private void btn_SendUTF8_Click(object sender, EventArgs e)
        {
            if (this.lis_Online.SelectedItems.Count > 0)
            {
                AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());
                byte[] send = Encoding.UTF8.GetBytes(this.txt_Send.Text.Trim());
                byte[] sendMsg = new byte[send.Length + 1];
                // 整体拷贝数组
                Array.Copy(send, 0, sendMsg, 1, send.Length);
                // 首字节赋值
                sendMsg[0] = (byte)MessageType.UTF8;
                foreach (var item in this.lis_Online.SelectedItems)
                {

                    string client = item.ToString();
                    CurrentClientlist[client]?.Send(sendMsg);
                }
                this.txt_Send.Clear();
            }
            else
            {
                MessageBox.Show("请选择你要发送的客户端对象！", "发送消息");
            }

            AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());
        }
        #endregion

        #region 服务端发送Hex
        private void btn_SendHex_Click(object sender, EventArgs e)
        {
            if (this.lis_Online.SelectedItems.Count > 0)
            {
                AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());
                byte[] send = Encoding.Default.GetBytes(this.txt_Send.Text.Trim());
                byte[] sendMsg = new byte[send.Length + 1];
                // 整体拷贝数组
                Array.Copy(send, 0, sendMsg, 1, send.Length);
                // 首字节赋值
                sendMsg[0] = (byte)MessageType.Hex;
                foreach (var item in this.lis_Online.SelectedItems)
                {

                    string client = item.ToString();
                    CurrentClientlist[client]?.Send(sendMsg);
                }
                this.txt_Send.Clear();
            }
            else
            {
                MessageBox.Show("请选择你要发送的客户端对象！", "发送消息");
            }

            AddLog(0, "发送内容：" + this.txt_Send.Text.Trim());
        }
        #endregion

        #region 选择文件
        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //设置默认路径
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txt_File.Text = ofd.FileName;
                AddLog(0, "选择文件：" + this.txt_File.Text);
            }
        }
        #endregion

        private void btn_SendFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_File.Text))
            {
                MessageBox.Show("请先选择您要发送的文件", "发送文件");
            }
            else
            {
                #region 客户端文件发送
                if (this.lis_Online.SelectedItems.Count > 0)
                {
                
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

                        foreach (var item in this.lis_Online.SelectedItems)
                        {

                            string client = item.ToString();
                            CurrentClientlist[client]?.Send(send1Msg);
                        }

                        //发送文件内容
                        byte[] send2 = new byte[1024 * 1024 * 10];
                        int lenght = fs.Read(send2, 0, send2.Length);
                        byte[] send2Msg = new byte[lenght + 1];
                        Array.Copy(send2, 0, send2Msg, 1, lenght);
                        send2Msg[0] = (byte)MessageType.File;
                        foreach (var item in this.lis_Online.SelectedItems)
                        {

                            string client = item.ToString();
                            CurrentClientlist[client]?.Send(send2Msg);
                        }
                        this.txt_File.Clear();
                        AddLog(0, strMsg);
                    }
                    
                }
                else
                {
                    MessageBox.Show("请选择你要发送的客户端对象", "发送消息");
                }
                #endregion
            }
        }

        private void btn_SendJSON_Click(object sender, EventArgs e)
        {
            if (this.lis_Online.SelectedItems.Count > 0)
            {
                List<Student> studentList = new List<Student>()
                {
                    new Student(){ StudentID = 10001 , StudentName = "小明",ClassName = "软件一班"},
                    new Student(){ StudentID = 10002 , StudentName = "小红",ClassName = "软件二班"},
                    new Student(){ StudentID = 10003 , StudentName = "小花",ClassName = "软件三班"},
                };

                string str = JSONHelper.EntityToJSON(studentList);
                byte[] send = Encoding.Default.GetBytes(str);
                byte[] sendMsg = new byte[send.Length + 1];
                Array.Copy(send, 0, sendMsg, 1, send.Length);
                sendMsg[0] = (byte)MessageType.JSON;
                foreach (var item in this.lis_Online.SelectedItems)
                {

                    string client = item.ToString();
                    CurrentClientlist[client]?.Send(sendMsg);
                }
                AddLog(0, "已发送：" + sendMsg);
            }
            else
            {
                MessageBox.Show("请选择你要发送的客户端对象", "发送消息");
            }
        }

        #region 全部选择
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            if (CurrentClientlist.Count == 0)
            {
                MessageBox.Show("当前在线列表为空，无法全选!", "全部选择");
            }

            for (int i = 0; i < this.CurrentClientlist.Count; i++)
            {
                this.lis_Online.SetSelected(i, true);
            }
        }
        #endregion
    }
}
