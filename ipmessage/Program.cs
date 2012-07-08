using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ipmessage
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // アカウント情報をロードする
            if (!G.readAccountCsv())
            {
                // ロードに失敗した場合はアプリケーション終了
                Application.Exit();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SendForm());
        }
    }
}
