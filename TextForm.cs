using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using MyCreate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Temporarily_Save_Text_List {
    public partial class TextForm : Form {


        public TextForm() {
            InitializeComponent();
            //ホイールイベントの追加  
            this.richTextBox.MouseWheel
                += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseWheel);
        }


        #region -------------【 　　フォントサイズ変更   】---------------------------------------//
        // マウスホイールイベント  
        private void textBox1_MouseWheel(object sender, MouseEventArgs e) {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                Console.WriteLine("Ctrlキーが押されています。");

                System.Windows.Forms.RichTextBox textBox = (System.Windows.Forms.RichTextBox)sender;
                // スクロール量（方向）の表示
                int num = (e.Delta * SystemInformation.MouseWheelScrollLines / 120);

                num += (int)textBox.Font.Size;

                if (num < 8) {
                    num = 8;
                }

                System.Drawing.Font font = new System.Drawing.Font("MS UI Gothic", num, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
                textBox.Font = font;
                label_font.Text = ((int)font.Size).ToString();

            } else {

                //どの修飾子キー(Shift、Ctrl、およびAlt)が押されているか
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
                    //   Console.WriteLine("Shiftキーが押されています。");
                }

                if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt) {
                    // Console.WriteLine("Altキーが押されています。");
                }
            }

        }
        //------------    【   末尾  】     ----------------//
        #endregion


        string FolderPath;
        int nowSelect = 0;
        string nowName="";
        Dictionary<string, string> Encode_moji;

        #region -------------【  ロードイベント  】---------------------------------------//
        private void Form1_Load(object sender, EventArgs e) {
            FolderPath = Exe_Path.exe_Path() + @"List\";

            checkedListBox1.AllowDrop = true;

            Encode_moji = new Dictionary<string, string>();

            string[] PathList = Exe_Path.Get_FileList(FolderPath,"*.txt");


            for(int i = 0; i < PathList.Length; i++) {
                string f = System.IO.Path.GetFileName(PathList[i]);
                checkedListBox1.Items.Add(f);
            }



            if (checkedListBox1.Items.Count > 0) {
                nowSelect = 0;
                checkedListBox1.SelectedIndex = 0;
                nowName = checkedListBox1.Text;

            }

            richTextBox.AcceptsTab = true;

            label_font.Text = ((int) richTextBox.Font.Size).ToString();
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        private void List_Reset() {
            checkedListBox1.Items.Clear();

            string[] PathList = Exe_Path.Get_FileList(FolderPath, "*.txt");


            for (int i = 0; i < PathList.Length; i++) {
                string f = System.IO.Path.GetFileName(PathList[i]);
                checkedListBox1.Items.Add(f);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (nowName != ""&& checkedListBox1.SelectedIndex!=-1) {
                Text_IO.TextFileReWrite(FolderPath + nowName, richTextBox.Text);
            }
        }

        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e) {

            string newtext = Microsoft.VisualBasic.Interaction.InputBox("新規テキスト");//インプットボックス使用

            if (newtext=="") {
                return;
            }


            for(int i = 0; i < checkedListBox1.Items.Count; i++) {
                if (System.IO.File.Exists(FolderPath + i + ".txt")) {
                    return;
                } 
            }


           if(Text_IO.TextFileReWrite(FolderPath + newtext + ".txt","")) {
                checkedListBox1.Items.Add(newtext + ".txt");
           }
        }


        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            MyCreate.Dialogs dialogs = new MyCreate.Dialogs();

            string saveName = dialogs.SaveFile_Dialog(Exe_Path.DownLoad_path(), checkedListBox1.Text,"*.txt");

            if (saveName=="") {
                return;
            }
            if (Text_IO.TextFileReWrite(saveName, richTextBox.Text)) {
                MessageBox.Show("処理完了");
            }
        }

        private void 追加ToolStripMenuItem1_Click(object sender, EventArgs e) {
            MyCreate.Dialogs dialogs = new MyCreate.Dialogs();
            string insertFile = dialogs.OpenFile_Dialog(Exe_Path.DownLoad_path(), "取得したいテキスト", "*.txt");

            if (insertFile == "") { return; }
            string f = System.IO.Path.GetFileName(insertFile);
            System.IO.File.Copy(insertFile,FolderPath+f);
            checkedListBox1.Items.Add(f);
        }

        #region -------------【  リストボックスがインデックス変更  】---------------------------------------//
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (checkedListBox1.SelectedIndex < 0) {
                nowName = "";
                nowSelect = -1;
                return;
            }

            // MessageBox.Show("Selectイベント１");
            if (nowSelect != checkedListBox1.SelectedIndex && nowSelect != -1) {

                Text_IO.TextFileReWrite(FolderPath + nowName, richTextBox.Text);
                nowSelect = checkedListBox1.SelectedIndex;
                nowName = checkedListBox1.Text;
                //MessageBox.Show("Selectイベント2");
            } else {
                if (nowName != "") {
                    // MessageBox.Show("ファイル名"+nowName);
                    Text_IO.TextFileReWrite(FolderPath + nowName, richTextBox.Text);
                    // MessageBox.Show("Selectイベント3");
                } else {
                    // MessageBox.Show("Selectイベント4");
                }
            }


            if (System.IO.File.Exists(FolderPath + checkedListBox1.Text)) {
                richTextBox.Text = Text_IO.TextRead(FolderPath + checkedListBox1.Text);
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        private void 選択範囲をURLで開くToolStripMenuItem_Click(object sender, EventArgs e) {
            string selec = richTextBox.SelectedText;
            Google_URL_Open.URL_Open(selec);
        }

        private void 選択範囲をGoogle検索ToolStripMenuItem_Click(object sender, EventArgs e) {
            string selec = richTextBox.SelectedText;
            Google_URL_Open.Google_Search_Open(selec);
        }

        private void 選択範囲を英語翻訳ToolStripMenuItem_Click(object sender, EventArgs e) {
            string selec = richTextBox.SelectedText;
            Google_URL_Open.Google_TRANSLATION(selec);
        }

        private void コピーToolStripMenuItem_Click(object sender, EventArgs e) {

            string selec = richTextBox.SelectedText;
            //クリップボードに文字列をコピーする
            Clipboard.SetText(selec);
        }

        private void buttonCpy_Click(object sender, EventArgs e) {
            string Txt = richTextBox.Text;
            //クリップボードに文字列をコピーする
            Clipboard.SetText(Txt);
            MessageBox.Show("コピー完了");
        }

        private void button1_Click(object sender, EventArgs e) {
            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null) {

                string txt = richTextBox.Text;

                if (data.GetDataPresent(typeof(string))) {
                    richTextBox.Text = txt + System.Environment.NewLine +Clipboard.GetText();//クリップボードゲット
                }
            }
        }

        private void チェック項目を削除ToolStripMenuItem_Click(object sender, EventArgs e) {


            for (int i = checkedListBox1.Items.Count-1; i >=0 ; i--) //チェックされた行だけを抜粋してカウントできる
            {
                if (checkedListBox1.GetItemChecked(i)) {
                    string DelName = checkedListBox1.Items[i].ToString();
                    Text_IO.txtDelete(FolderPath + DelName);
                    if(!System.IO.File.Exists(FolderPath + DelName)) {
                        checkedListBox1.Items.RemoveAt(i);
                    }
                }
            }

            richTextBox.Text = "";
            List_Reset();
        }

        private void Select_Delete_StripMenuItem1_Click(object sender, EventArgs e) {
            

            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--) //チェックされた行だけを抜粋してカウントできる
            {
                if (checkedListBox1.GetItemChecked(i)) {
                    string DelName = checkedListBox1.Items[i].ToString();
                    Text_IO.txtDelete(FolderPath + DelName);
                    if (!System.IO.File.Exists(FolderPath + DelName)) {
                        checkedListBox1.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void All_DeleteMenuItem2_Click(object sender, EventArgs e) {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--) //チェックされた行だけを抜粋してカウントできる
{
                if (checkedListBox1.GetItemChecked(i)) {
                    string DelName = checkedListBox1.Items[i].ToString();
                    Text_IO.txtDelete(FolderPath + DelName);
               
                        checkedListBox1.Items.RemoveAt(i);
                    
                }
            }
        }

        private void SelectSaveitem1_Click(object sender, EventArgs e) {

            int fn = 1;
            while (System.IO.Directory.Exists(Exe_Path.DownLoad_path() + "保存" + fn)) {
                fn++;
            }

           if( Folder_Exis_Create(Exe_Path.DownLoad_path() + "保存" + fn)) {

                for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--) { //チェックされた行だけを抜粋してカウントできる                   
                    MessageBox.Show(Exe_Path.DownLoad_path() + "保存" + fn);

                    if (checkedListBox1.GetItemChecked(i)) {

                        string SaveName = checkedListBox1.Items[i].ToString();

                        if (!System.IO.File.Exists(Exe_Path.DownLoad_path() + "保存" + fn)) {

                            string f = System.IO.Path.GetFileName(SaveName);
                            System.IO.File.Copy( FolderPath+SaveName, Exe_Path.DownLoad_path() + "保存" + fn + @"\" + f);

                        }
                    }
                }
           }

            MessageBox.Show("処理完了");
        }


        public bool Folder_Exis_Create(string Path) {//フォルダがない場合は作成する
            bool Flg = false;
            if (System.IO.Directory.Exists(Path) == false) {

                string CreatePath = Path;
                try {
                    System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(CreatePath);
                    Flg = true;
                } catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
            return Flg;
        }

        private void dBListに保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dr1 = DialogResult.Retry;

            while (!(dr1 == DialogResult.Cancel)) {

                dr1 = MessageBox.Show("SQLiteファイルを選択します。このまま続けますか？", "確認", MessageBoxButtons.OKCancel);
                if (dr1 == System.Windows.Forms.DialogResult.OK) {

                    string folderPath1 = Path.GetDirectoryName(Exe_Path.exe_Path());

                    MyCreate.Dialogs dialogs = new MyCreate.Dialogs();
                    string dbName = dialogs.OpenFile_Dialog_List(folderPath1, "", "*.db");

                    if (dbName == "") {
                        continue;
                    }

                    MessageBox.Show("デバッグ1");

                    List<Dictionary<string, string>> keyValues = new List<Dictionary<string, string>>();

                    for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--) { //チェックされた行だけを抜粋してカウントできる                   


                        if (checkedListBox1.GetItemChecked(i)) {

                            Dictionary<string, string> item = new Dictionary<string, string>();

                            string SaveName = checkedListBox1.Items[i].ToString();
                            MessageBox.Show("1.5"+SaveName);

                            string moji = Text_IO.TextRead(FolderPath+ SaveName);
                            string key = System.IO.Path.GetFileNameWithoutExtension(SaveName);

                            item.Add("lang", "テキスト");
                            item.Add("name", key);
                            item.Add("samplecode", moji);
                            keyValues.Add(item);
                        }
                    }
                    MessageBox.Show("デバッグ2");

                    SelectForm1 selfm = new SelectForm1(dbName, keyValues);

                    DialogResult result = selfm.ShowDialog();

                    if (result == DialogResult.OK) {
                        MessageBox.Show("処理完了");
                        dr1 = DialogResult.Cancel;
                    } else {
                        return;
                    }

                } else//OK以外の動作
                { dr1 = DialogResult.Cancel; return; }

            }
        }

        private void DBListMenuItem1_Click(object sender, EventArgs e) {
            DialogResult dr1 = DialogResult.Retry;

            while (!(dr1 == DialogResult.Cancel)) {

                dr1 = MessageBox.Show("SQLiteファイルを選択します。このまま続けますか？", "確認", MessageBoxButtons.OKCancel);
                if (dr1 == System.Windows.Forms.DialogResult.OK) {

                    string folderPath1 = Path.GetDirectoryName(Exe_Path.exe_Path());
                    string folderPath2 = Path.GetDirectoryName(folderPath1);

                    MyCreate.Dialogs dialogs = new MyCreate.Dialogs();
                    string dbpath = dialogs.OpenFile_Dialog_List(folderPath2, "", "*.db");

                    if (dbpath == "") {
                        continue;
                    }
                    string limit = "*.db";
                    string DBfolder = Path.GetDirectoryName(dbpath);
                    DBfolder+= @"\";
                    IEnumerable<string> files = System.IO.Directory.EnumerateFiles(DBfolder, limit, System.IO.SearchOption.TopDirectoryOnly);//実行するのは検索したい場所の親フォルダから

                    if (files.Count() > 0) {
                       
                    } else {
                        return;
                    }

                    List<Dictionary<string, string>> keyValues = new List<Dictionary<string, string>>();

                    for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--) { //チェックされた行だけを抜粋してカウントできる                   


                        if (checkedListBox1.GetItemChecked(i)) {

                            Dictionary<string, string> item = new Dictionary<string, string>();

                            string SaveName = checkedListBox1.Items[i].ToString();
                            MessageBox.Show(SaveName);
                            string moji = Text_IO.TextRead(FolderPath+SaveName);
                            string key = System.IO.Path.GetFileNameWithoutExtension(SaveName);

                            item.Add("lang", "テキスト");
                            item.Add("name", key);
                            item.Add("samplecode", moji);
                            keyValues.Add(item);
                        }
                    }

                    

                    SelectForm1 selfm = new SelectForm1(dbpath, keyValues);

                    DialogResult result = selfm.ShowDialog();

                    if (result == DialogResult.OK) {
                        MessageBox.Show("処理完了");
                    } else {
                        return;
                    }

                } else//OK以外の動作
                { dr1 = DialogResult.Cancel; return; }

            }
        }

        #region -------------【  ドラッグ＆ドロップ  】---------------------------------------//
        private void checkedListBox1_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private void checkedListBox1_DragDrop(object sender, DragEventArgs e) {

            Dictionary<string, string> DragList = new Dictionary<string, string>();

            //ドロップされたファイルの一覧を取得
            string[] sFileName = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);

            string limit_Path = Exe_Path.exe_Path()+ @"Limit\limit.txt";

            List<string> limitText = Text_IO.TextRead_To_List(limit_Path);
            List<string> limitList = new List<string>();

            char[] cutC = { ',' };

            if (limitText.Count > 0) {

                foreach (string s in limitText) {

                    string[] OneLine = s.Split(cutC);
                    Encode_moji.Add(OneLine[0],OneLine[1]);
                    limitList.Add(OneLine[0]);
                }
  
            }

            if (sFileName.Length <= 0) {
                return;
            }

            //---------------------------------------------------------------------//


            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop)) {


                // 配列分ループ
                foreach (string sTemp in sFileName) {
                    if (System.IO.Directory.Exists(sTemp) || File.Exists(sTemp))//フォルダのパスか判定
                    {
                        if (Drag_Drop.listCount_2(sTemp, limitList,Encode_moji, ref DragList)) {

                        }

                    } else {
                        continue;
                    }
                }

                if (DragList.Count > 0) {
                    foreach (var keyValuePair in DragList) {
                        string key = keyValuePair.Key;
                        string Value = keyValuePair.Value;

                        string NewFileName = FolderPath + key;

                        while (System.IO.File.Exists(NewFileName + ".txt")) {
                            NewFileName = Microsoft.VisualBasic.Interaction.InputBox("同じファイル名があるので変更してください", "入力画面", NewFileName);
                        }

                        Text_IO.TextFileReWrite(NewFileName + ".txt", Value);
                        List_Reset();
                       // Text_IO.TextFileReWrite(FolderPath + key, Value);
                       // checkedListBox1.Items.Add(key);
                    }
                }
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion



        private void 外部からインポートToolStripMenuItem_Click(object sender, EventArgs e) {

            string limit_Path= Exe_Path.exe_Path() + @"Limit\limit.txt";
            Dictionary<string, string> Encode_moji = new Dictionary<string, string>();
            List<string> LimitList = new List<string>();

            string[] mojiList = Text_IO.TextRead_To_List(limit_Path).ToArray();
            char[] cutC = { ',' };

            if (mojiList.Length > 0) {

                foreach (string s in mojiList) {

                    string[] OneLine = s.Split(cutC);
                    LimitList.Add(OneLine[0]);

                    Encode_moji.Add(OneLine[0], OneLine[1]);
                }
            }


            MyCreate.Dialogs dialogs1 = new MyCreate.Dialogs();
            string FileName = dialogs1.OpenFile_Dialog(Exe_Path.DownLoad_path(), "", LimitList.ToArray());
            int HitNum = -1;
            string moji="";

            if (IS_Exists(FileName,LimitList,ref HitNum)) {

                if (FileName != "") {

                    moji = Text_IO.TextRead(FileName,Encode_moji[ LimitList[HitNum]]);

                } else//OK以外の動作
                { return; }

                string NewFileName = FolderPath + System.IO.Path.GetFileNameWithoutExtension(FileName);

                while (System.IO.File.Exists( NewFileName+ ".txt")) {
                    NewFileName = Microsoft.VisualBasic.Interaction.InputBox("同じファイル名があるので変更してください","入力画面",NewFileName);
                }

                Text_IO.TextFileReWrite(NewFileName + ".txt",moji);
                List_Reset();
                //var obj = System.IO.Path.GetFileNameWithoutExtension(FileName) + ".txt";
                //checkedListBox1.Items.Add(obj);
            }else
            {
                MessageBox.Show("テキストファイルに登録されているファイルではありません");
            }
        }



        #region --------------【指定文字が含まれているか判定】------------------------------------------------------
        public static bool IS_Exists(string checkpath, List<string> limitList) {

            foreach (string d in limitList) {
                if (checkpath.EndsWith(d)) {
                    return true;
                }
            }

            return false;
        }

        public static bool IS_Exists(string checkpath, List<string> limitList, ref int HitNum) {

            for (int i = 0; i < limitList.Count; i++) {
                if (checkpath.EndsWith(limitList[i])) {
                    HitNum = i;
                    return true;
                }
            }

            return false;
        }

        //------------    【   末尾  】     ----------------//
        #endregion

        private void テキスト判定変更ToolStripMenuItem_Click(object sender, EventArgs e) {
            LimitForm Lmform = new LimitForm(Exe_Path.exe_Path() + @"Limit\limit.txt");
            Lmform.Show();
        }
    }
}
