using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ipmessage
{
    class RecieveServer
    {

        private bool looping;

        public void start()
        {
            looping = true;

            Thread t = new Thread(new ThreadStart(this.task));
            t.IsBackground = true;
            t.Start();
        }

        public void stop()
        {
            looping = false;
        }

        private void task()
        {
            //Gクラスに設定したホスト名でListenを開始する
            IPAddress ipAdd = Dns.GetHostEntry(G.host).AddressList[0];
            TcpListener listener = new TcpListener(ipAdd, G.port);
            listener.Start();

            while (looping)
            {
                //接続要求があったら受け入れる
                TcpClient tcp = listener.AcceptTcpClient();
                //NetworkStreamを取得
                NetworkStream ns = tcp.GetStream();

                //クライアントから送られたデータを受信する
                MemoryStream ms = new MemoryStream();
                byte[] resBytes = new byte[256];
                int resSize;
                do
                {
                    //データの一部を受信する
                    resSize = ns.Read(resBytes, 0, resBytes.Length);
                    //Readが0を返した時はクライアントが切断したと判断
                    if (resSize == 0)
                    {
                        break;
                    }
                    //受信したデータを蓄積する
                    ms.Write(resBytes, 0, resSize);
                } while (ns.DataAvailable);
                //受信したデータを文字列に変換
                string resMsg = G.enc.GetString(ms.ToArray());
                ms.Close();

                //resMsgの長さが0で無ければ、受信文字列を編集しRecieveFormを呼び出す。
                if(resMsg.Length != 0){
                
                    //IPアドレス取得
                    string remoteIp = ((IPEndPoint)tcp.Client.RemoteEndPoint).Address.ToString();
                    MessageBox.Show("IPは" + remoteIp + "です。文字列は" + resMsg + "です。");

                }

            }
        }
    }


}
