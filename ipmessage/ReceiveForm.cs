using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ipmessage
{
    /**
     * 受信フォームクラス
     */
    public partial class ReceiveForm : Form
    {

        private string targetName;
        private DateTime rcvTime ;
        private string ip;

        public ReceiveForm(string ip,string message)
        {
            // 表示文字列の設定
            rcvTime = DateTime.Now; // 相手から受け取る？日時（仮にNow）
            this.ip = ip;

            // 相手のIPアドレスから名前を取得。
            // 見つからなければIPアドレスを表示名にし、2種類のハッシュにIPアドレスを登録する。
            if (G.ipHash.Contains(ip))
            {
                targetName = (string)G.ipHash[ip];
            }
            else
            {
                targetName = ip;
                G.accountHash.Add(ip, ip);
                G.ipHash.Add(ip, ip);
            }

            InitializeComponent();

            // 受け取った日時と名称をinfoLabelに反映
            infoLabel.Text = rcvTime.Year + "年" + 
                             rcvTime.Month + "月" + 
                             rcvTime.Day + "日 " + 
                             rcvTime.Hour + "時" + 
                             rcvTime.Minute + "分 " + 
                             targetName + "さんから";
            // 受け取ったメッセージをmessageBoxに反映
            messageBox.Text = message;
            
        }

        /** 
         * 返信ボタンクリックのイベント処理（SendFormの表示） 
         */
        private void ReplyButton_Click(object sender, EventArgs e)
        {
            string message = messageBox.Text;

            ThreadStart tStart = () =>
            {
                // SendFormインスタンスの生成と表示
                SendForm sForm = new SendForm(message, this.ip);
                sForm.ShowDialog();
            };
            // スレッドを生成する
            Thread t = new Thread(tStart);
            t.IsBackground = true;
            t.Start();

            // 自分フォームをクローズ
            this.Close();

        }

    }
}
