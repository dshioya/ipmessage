using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net.Sockets;
using System.Text;

namespace ipmessage
{
    /**
     * 送信フォームコンポーネントクラス。
     */
    public partial class SendForm : Form
    {

        /**
         * コンストラクタ。
         */
        public SendForm(string header = "")
        {
            InitializeComponent();

            // アカウントリストボックスを更新する
            foreach (string name in G.accountHash.Keys)
            {
                accountList.Items.Add(name);
            }

            if (header.Length > 0)
            {
                // 受信メッセージをテキストボックスに設定する
                messageText.Text = "> " + header + "\n";
            }

        }

        /**
         * Enterキーのみ押されたかどうかのフラグ。
         */
        private bool isPressedEnterKey;

        /**
         * メッセージボックスのkeydownイベントハンドラ。
         */
        private void MessageText_KeyDown(object sender, KeyEventArgs e)
        {
            isPressedEnterKey = false;

            if (e.KeyData == Keys.Enter && e.Modifiers != Keys.Shift)
            {
                isPressedEnterKey = true;
            }
        }

        /**
         * メッセージボックスのkeypressイベントハンドラ。
         */
        private void MessageText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isPressedEnterKey)
            {
                // キーハンドリングはキャンセルする
                e.Handled = true;

                // メッセージを送信する
                sendMessage();
            }
        }

        private void sendMessage()
        {
            //文字コードを指定する
            Encoding enc = Encoding.UTF8;

            string errorSend = "";

            // メッセージを取得
            string message = messageText.Text;
            if (message.Length == 0)
            {
                // メッセージ未入力時は処理中断
                return;
            }

            for (int i = 0; i < accountList.SelectedItems.Count; i++)
            {
                TcpClient client = null;
                NetworkStream ns = null;
                string account = null;

                try
                {
                    // 送信先のIPアドレスを取得
                    account = accountList.SelectedItems[i].ToString();
                    string ip = (string)G.accountHash[account];

                    // TCPクライアントオブジェクトを生成
                    client = new TcpClient(ip, G.port);
                    ns = client.GetStream();

                    // メッセージを送信する
                    byte[] messageBytes = enc.GetBytes(message);
                    ns.Write(messageBytes, 0, messageBytes.Length);

                }
                catch (SocketException) {
                    errorSend += "「" + account + "」\n";
                }
                finally
                {
                    // ストリームクローズ
                    if (ns != null)
                    {
                        ns.Close();
                    }
                    if (client != null)
                    {
                        client.Close();
                    }
                    ns = null;
                    client = null;
                }

                if (errorSend.Length > 0)
                {
                    MessageBox.Show(errorSend + "への送信に失敗しました。");
                }
            }
        }
    }
}
