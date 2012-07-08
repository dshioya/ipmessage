using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ipmessage
{
    /**
     * 受信フォームクラス
     */
    public partial class ReceiveForm : Form
    {

        private string targetName;
        private DateTime rcvTime ;
        private string ipAdrs;
        private string message ;

        public ReceiveForm()
        {
            // 表示文字列の設定
            rcvTime = DateTime.Now; // 相手から受け取る？日時（仮にNow）
            ipAdrs = "192.168.1.2";   // IPアドレス（仮にまつこ）
            message = "塩屋さんから受信したメッセージです。ちょっとぐらいの長文も表示できるか試してみます。";

            // 相手のIPアドレスから名前を取得。
            // 見つからなければIPアドレスを表示名にし、2種類のハッシュにIPアドレスを登録する。
            if (G.ipHash.Contains(ipAdrs))
            {
                targetName = (string)G.ipHash[ipAdrs];
            }
            else
            {
                targetName = ipAdrs;
                G.accountHash.Add(ipAdrs, ipAdrs);
                G.ipHash.Add(ipAdrs, ipAdrs);
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
            // SendFormインスタンスの生成と表示
            SendForm sForm = new SendForm(messageBox.Text);
            sForm.Show();
        }

    }
}
