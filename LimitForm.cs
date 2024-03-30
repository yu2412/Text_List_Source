using MyCreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Excel;

namespace MyCreate {
    public partial class LimitForm : Form {


        #region -------------【  プロパティ  】---------------------------------------//
    
        string limit_Path;// = Exe_Path.exe_Path() + @"Limit\limit.txt";
        Dictionary<string, string> Encode_moji;

        //------------    【   末尾  】     ----------------//
        #endregion



        public LimitForm(string txtPath) {
            InitializeComponent();

           limit_Path = txtPath;
        }

        private void SelectForm1_Load(object sender, EventArgs e) {
            Encode_moji = new Dictionary<string, string>();
            ListBox_Reset();
        }

        private void button1_Click(object sender, EventArgs e) {

            if (textBox_insert.Text == "") { return; }

            if (IS_Exists(textBox_insert.Text, listBox1)) { MessageBox.Show("既に登録されています");return; }


            string moji = $"{textBox_insert.Text},UTF-8" + System.Environment.NewLine;
            int i = 0;

            foreach (var keyValuePair in Encode_moji) {
                string key = keyValuePair.Key;
                string value = keyValuePair.Value;

                if (Encode_moji.Count-1 > i) {
                    moji += $"{key},{value}" + System.Environment.NewLine;
                } else {
                    moji += $"{key},{value}";
                }

                i++;
            }

            MyCreate.Text_IO.TextFileReWrite(limit_Path, moji);

            ListBox_Reset();
            textBox_insert.Text = "";
        }

        private void ListBox_Reset() {
            listBox1.Items.Clear();
            Encode_moji.Clear();

            string[] mojiList = Text_IO.TextRead_To_List(limit_Path).ToArray();
            char[] cutC = { ',' };

            if (mojiList.Length > 0 ) {

                foreach (string s in mojiList) {

                    string[] OneLine = s.Split(cutC);
                    listBox1.Items.Add(OneLine[0]);

                    Encode_moji.Add(OneLine[0],OneLine[1]);
                }
                listBox1.SelectedIndex = 0;
            }       
        }


        private void CANCEL_btn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox1.Text == "") { return; }

            comboBox.Text = Encode_moji[listBox1.Text];

        }


        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (listBox1.Text == "" || listBox1.SelectedIndex<0) { return; }


            string moji = "";
            int i = 0;
            bool DeleteFlg = false;

            foreach (var keyValuePair in Encode_moji) {
                string key = keyValuePair.Key;
                string value = keyValuePair.Value;

                if (Encode_moji.Count - 2 > i) {
                    if (key == listBox1.Text) {
                        DeleteFlg = true;
                        continue;
                    } else {
                        moji += $"{key},{value}" + System.Environment.NewLine;
                    }
                } else if(Encode_moji.Count - 1 > i) {
                    if (key == listBox1.Text) {
                        DeleteFlg = true;
                        continue;
                    } else {
                        if (DeleteFlg) {
                            moji += $"{key},{value}" + System.Environment.NewLine;
                        } else {
                            moji += $"{key},{value}";
                        }
                    }
                }
                else {
                    if (DeleteFlg) {
                        moji += $"{key},{value}";
                    } else {
                        continue;
                    }
                }

                i++;
            }

            MyCreate.Text_IO.TextFileReWrite(limit_Path, moji);

            ListBox_Reset();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (comboBox.Text == ""&& listBox1.Text=="") { return; }

            string moji="";
            int i = 0;

            foreach (var keyValuePair in Encode_moji) {
                string key = keyValuePair.Key;
                string value = keyValuePair.Value;

                if (Encode_moji.Count - 1 > i) {
                    if (key == listBox1.Text) {
                        moji += $"{listBox1.Text},{comboBox.Text}" + System.Environment.NewLine;
                    } else {
                        moji += $"{key},{value}" + System.Environment.NewLine;
                    }
                } else {
                    if (key == listBox1.Text) {
                        moji += $"{listBox1.Text},{comboBox.Text}";
                    } else {
                        moji += $"{key},{value}";
                    }
                }

                i++;
            }

            MyCreate.Text_IO.TextFileReWrite(limit_Path, moji);

            ListBox_Reset();
        }

        #region --------------【指定文字が含まれていないか判定】------------------------------------------------------
        private static bool IS_Exists(string moji, System.Windows.Forms.ListBox list) {

            for (int i =0;i<list.Items.Count;i++ ) {
                if (moji == list.Items[i].ToString()) {
                    return true;
                }
            }

            return false;
        }
        //------------    【   末尾  】     ----------------//
        #endregion
    }
}
