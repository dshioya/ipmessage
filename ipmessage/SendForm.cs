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

                // TODO:メッセージを送信する
                MessageBox.Show(messageText.Text);
            }
        }

    }

}
