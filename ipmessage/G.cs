﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace ipmessage
{
    class G
    {
        // ポート番号
        public static int port = 2001;

        public static RecieveServer server;

        /**
         * アカウントCSVファイル名。
         */
        private static string accountCsvFilename = "account.csv";

        /**
         * アカウント情報のキャッシュ一覧。
         */
        public static Hashtable accountHash = new Hashtable();
        public static Hashtable ipHash = new Hashtable();

        /**
         * アカウントCSVファイルをロードする。
         */
        public static bool readAccountCsv()
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
    }

}
