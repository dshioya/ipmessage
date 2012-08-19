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
        private string host;
        private TcpListener listener;

        public void start()
        {
            host = G.readHost();
            if (host == null)
            {
                // ホスト名が取得できない場合は処理中断
                return;
            }

            looping = true;

            //Gクラスに設定したホスト名でListenを開始する
            IPEndPoint ipAdd = new IPEndPoint(IPAddress.Parse(host), G.port);
            listener = new TcpListener(ipAdd);
            listener.Start();

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
                    
                    //recieveFormを生成する
                    showRecieve(remoteIp, resMsg);
                }
                //リスナクローズ処理
                tcp.Close();
                tcp = null;
            }
        }

        /*
         * 受信フォームを生成する
         */
        private void showRecieve(string ip,string message) { 

            ThreadStart tStart = () =>
            {
                //RecieveFormを生成する
                ReceiveForm rForm = new ReceiveForm(ip, message);
                rForm.ShowDialog();
            };
            // スレッドを生成する
            Thread t = new Thread(tStart);
            t.IsBackground = true;
            t.Start();        
        }
    }


}
