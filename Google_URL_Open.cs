using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCreate {
  public  class Google_URL_Open {

        string path;
       static int select = 1;

        static string[] Google_Path = new string[] { @"C:\Program Files\Google\Chrome\Application\chrome.exe", @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" };



        public static void URL_Open(string url)
        {

            try {

                System.Diagnostics.Process.Start(Google_Path[select], url);


            } catch (Exception ee) {


                    if (select == 0) {
                        try {
                            select = 1;

                            System.Diagnostics.Process.Start(Google_Path[select], url);


                        } catch (Exception ee2) {
                            MessageBox.Show("接続に失敗\nキャンセルします");
                        }
                    } else {

                        try {
                            select = 0;

                            System.Diagnostics.Process.Start(Google_Path[select], url);


                        } catch (Exception ee2) {
                            MessageBox.Show("接続に失敗\nキャンセルします");
                        }

                    }
            }


        }
        public static void Google_Search_Open(string moji)
        {

            string SearchTxt = @"https://www.google.com/search?q=";

            try {

                System.Diagnostics.Process.Start(Google_Path[select], SearchTxt+moji);


            } catch (Exception ee) {


                    if (select == 0) {
                        try {
                            select = 1;

                            System.Diagnostics.Process.Start(Google_Path[select], SearchTxt + moji);


                        } catch (Exception ee2) {
                            MessageBox.Show("接続に失敗\nキャンセルします");
                        }
                    } else {

                        try {
                            select = 0;

                            System.Diagnostics.Process.Start(Google_Path[select], SearchTxt + moji);


                        } catch (Exception ee2) {
                            MessageBox.Show("接続に失敗\nキャンセルします");
                        }

                    }
            }

        }
        public static void Google_TRANSLATION(string moji)
        {

            const string HONYAKU1 = @"https://translate.google.co.jp/?hl=ja&sl=auto&tl=ja&text=";
            const string HONYAKU2 = @"&op=translate";

            //string str1 = "apple, orange, melon, apple";
            string moji2 = moji.Replace(" ", "%20");

            try {

                System.Diagnostics.Process.Start(Google_Path[select], HONYAKU1+moji2+HONYAKU2);


            } catch (Exception ee) {


                    if (select == 0) {
                        try {
                            select = 1;

                            System.Diagnostics.Process.Start(Google_Path[select], HONYAKU1 + moji2 + HONYAKU2);


                        } catch (Exception ee2) {
                            MessageBox.Show("接続に失敗\nキャンセルします");
                        }
                    } else {

                        try {
                            select = 0;

                            System.Diagnostics.Process.Start(Google_Path[select], HONYAKU1 + moji2 + HONYAKU2);


                        } catch (Exception ee2) {
                            MessageBox.Show("接続に失敗\nキャンセルします");
                        }

                    }
            }

        }
    }
}
