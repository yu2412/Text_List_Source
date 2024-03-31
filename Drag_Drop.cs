using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCreate {
    public class Drag_Drop {
        #region -------------【    】---------------------------------------//
        public static void listCount(List<string> Drlist,  ListBox list_0, ListBox list_00,string limit) {
            list_0.Items.Clear();
            list_00.Items.Clear();


            int num = Drlist.Count;

            MessageBox.Show(num + "個");

            while (num > 0) {


                if (Directory.Exists(Drlist[num - 1])) {

                    MessageBox.Show("ふぉるだです");
                } else if (File.Exists(Drlist[num - 1])) {
                    MessageBox.Show("ファイルです");

                    //ファイル名をパスから取得するには、「GetFileNameメソッド」を使います
                    string Search = Path.GetFileName(Drlist[num - 1]);
                    list_0.Items.Add(Drlist[num - 1]);
                    list_00.Items.Add(Search);

                    Drlist.RemoveAt(num - 1);

                    num = Drlist.Count;
                    continue;

                }


                string strp = Drlist[num - 1];
                string Fipth = Drlist[num - 1];

                //----------------------------------------------//

                Object a;

                a = System.IO.Directory.EnumerateFiles(strp, limit, System.IO.SearchOption.AllDirectories);//TopDirectoryOnly

                
                IEnumerable<string> files = (IEnumerable<string>)a;

                MessageBox.Show("File数：" + files.Count());


                //ファイルを列挙する
                foreach (string f in files) {

                    //ファイル名をパスから取得するには、「GetFileNameメソッド」を使います
                    string Search = Path.GetFileName(f);
                        list_0.Items.Add(f);
                        list_00.Items.Add(Search);
                   
                }//-----foreach

                Drlist.RemoveAt(num - 1);
                MessageBox.Show("処理終了後：" + Drlist.Count + " 個");
                num = Drlist.Count;


            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【    】---------------------------------------//
        public static bool listCount_2(string DirectoryName, List<string> limitList,Dictionary<string,string>EncodeList,ref Dictionary<string, string> ResultList) {

                if (Directory.Exists(DirectoryName)) {

        
                } else if (File.Exists(DirectoryName)) {

                    int HitNum = -1;
                        if (IS_Exists(DirectoryName,limitList,ref HitNum)) {
                            string fn = System.IO.Path.GetFileNameWithoutExtension(DirectoryName);

                            string moji = Text_IO.TextRead(DirectoryName, EncodeList[limitList[HitNum]]);
                            //Text_IO.TextFileReWrite(fn + ".txt", moji);
                            ResultList.Add(fn+".txt",moji);
                        }
                    return true;
                }
                //----------------------------------------------//

                Object a;

            for (int i=0;i<limitList.Count;i++) {

                a = System.IO.Directory.EnumerateFiles(DirectoryName, limitList[i], System.IO.SearchOption.AllDirectories);//TopDirectoryOnly


                IEnumerable<string> files = (IEnumerable<string>)a;

                MessageBox.Show("File数：" + files.Count());


                //ファイルを列挙する
                foreach (string f in files) {
                    if (IS_Exists(f, limitList)) {
                        //ファイル名をパスから取得するには、「GetFileNameメソッド」を使います
                        string Search = Path.GetFileNameWithoutExtension(f);
                        ResultList.Add(Search+".txt",f);
                    }
                }//-----foreach

            }

            if (ResultList.Count > 0) {
                return true;
            } else {
                return false;
            }
         
        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region --------------【指定文字が含まれていないか判定】------------------------------------------------------
        private static bool IS_notExists(string checkpath,List<string> dumpList) {

            foreach (string d in dumpList) {
                if (checkpath.EndsWith(d)) {
                    return false;
                }
            }

            return true;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region --------------【指定文字が含まれているか判定】------------------------------------------------------
        public static bool IS_Exists(string checkpath, List<string> limitList) {

            foreach (string d in limitList) {
                if (checkpath.EndsWith(d)) {
                    return true;
                }
            }

            return false;
        }

        public static bool IS_Exists(string checkpath, List<string> limitList,ref int HitNum) {

            for(int i=0;i< limitList.Count;i++) {
                if (checkpath.EndsWith(limitList[i])) {
                    HitNum = i;
                    return true;
                }
            }

            return false;
        }
        //------------    【   末尾  】     ----------------//
        #endregion
    }
}
