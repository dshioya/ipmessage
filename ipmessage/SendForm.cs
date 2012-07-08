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
         * アカウントCSVファイル名。
         */
        private string accountCsvFilename = "account.csv";

        /**
         * アカウント情報のキャッシュ一覧。
         */
        private Hashtable accountHash = new Hashtable();
        private Hashtable ipHash = new Hashtable();

        /**
         * コンストラクタ。
         */
        public SendForm(string header = "")
        {
            InitializeComponent();

            // アカウント情報をロードする
            if (!readAccountCsv())
            {
                // ロードに失敗した場合はアプリケーション終了
                Application.Exit();
            }
            else
            {
                // アカウントリストボックスを更新する
                foreach (string name in accountHash.Keys)
                {
                    accountList.Items.Add(name);
                }
            }

            if (header.Length > 0)
            {
                // 受信メッセージをテキストボックスに設定する
                messageText.Text = "> " + header + "\n";
            }

        }

        /**
         * アカウントCSVファイルをロードする。
         */
        private bool readAccountCsv()
        {
            if (!File.Exists(accountCsvFilename))
            {
                // ファイルが存在しない場合
                return false;
            }

            // CSVファイルを読込んでアカウントリストに表示する
            StreamReader sr = new StreamReader(accountCsvFilename, Encoding.GetEncoding("Shift_JIS"));

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                if (data.Length > 1)
                {
                    accountHash.Add(data[0], data[1]);
                    ipHash.Add(data[1], data[0]);
                }
            }

            // ストリームクローズ
            sr.Close();

            return true;
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
