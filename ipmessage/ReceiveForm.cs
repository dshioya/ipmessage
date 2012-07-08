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

        private String targetName;
        private DateTime rcvTime = DateTime.Now;

        public ReceiveForm()
        {
            
            InitializeComponent();

            // TODO：相手のIPアドレスを取得する

            // TODO：取得したIPアドレスをCSVと突き合わせ、相手の名前を取得
            targetName = "塩屋 大介";

            // TODO：CSVに存在しないIPアドレスの場合、相手の名前を”名無しさん（IPアドレス）”に設定する

            // 受け取った日時と名称をinfoLabelに反映
            infoLabel.Text = rcvTime.Year + "年" + 
                             rcvTime.Month + "月" + 
                             rcvTime.Day + "日 " + 
                             rcvTime.Hour + "時" + 
                             rcvTime.Minute + "分 " + 
                             targetName + "さんから";
            // 受け取ったメッセージをmessageBoxに反映
            messageBox.Text = "塩屋さんから受信したメッセージです。ちょっとぐらいの長文も表示できるか試してみます。";
            
        }

        /** 
         * 返信ボタンクリックのイベント処理（SendFormの表示） 
         */
        private void ReplyButton_Click(object sender, EventArgs e)
        {
            // TODO：CSVに存在しない相手だった場合、予めCSVにIPアドレス,IPアドレスを登録する

            // SendFormインスタンスの生成と表示
            SendForm sForm = new SendForm(messageBox.Text);
            sForm.Show();
        }

    }
}
