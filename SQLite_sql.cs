using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySqlConnector;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
//using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace MyCreate {

    #region -------------【  データベース操作クラス  】---------------------------------------//
    internal class SQLite_sql {

        #region -------------【 プロパティ  】---------------------------------------//
        static string[] Query_value = { "@a", "@b", "@c", "@d", "@e", "@f", "@g", "@h", "@i", "@j", "@k", "@l", "@m", "@n", "@o", "@p", "@q", "@r", "@s", "@t", "@u", "@v", "@w", "@x", "@y", "@z" };

        // static string CONNECT_STRING = "userid=root; password=; database = hanbaidb; Host=127.0.0.1;charset=utf8";

        //DB作成
        private SQLiteConnection DB_CONNECT;
        internal string DatabaseFullPath;
        internal string DBname;
      

        #endregion -------------【　末尾　】---------------------------------------//

        #region -------------【 SQLの OPEN と Close  コンストラクション】---------------------------------------//

        #region -------------【 コンストラクタ 】----------//
        internal SQLite_sql(string DBname, string DBFullPath) {
            DatabaseFullPath = DBFullPath;
            this.DBname = DBname;
            DB_CONNECT = new SQLiteConnection("Data Source = " + DBFullPath);
            DB_CONNECT.Open();
        }
        #endregion -------------【  コンストラクタ末尾  】---//


        internal bool Sqlite_Close() {
            bool flg = false;
            try {

                //MessageBox.Show("Conectを切断");
                DB_CONNECT.Close();
                DB_CONNECT.Dispose();
                flg = true;
                //MessageBox.Show("Conectを切断終了");
            } catch (Exception e) {
                //MessageBox.Show(e.Message + "\n エラー発生");
            }

            return flg;
        }
        #endregion -------------【  末尾  】---------------------------------------//

        //https://detail.chiebukuro.yahoo.co.jp/qa/question_detail/q13269374373
        #region -------------【  テーブル名一覧取得  】---------------------------------------//
        internal bool GetTablesName(string DBname, ref List<string> list) {

            bool result = false;
            //! テーブル一覧取得SQL
            string ListTableSql = $"SELECT name FROM sqlite_master WHERE type = 'table'";

            try {
                // 接続文字列を構築します。
                SQLiteConnectionStringBuilder connectionSb = new SQLiteConnectionStringBuilder() { DataSource = DatabaseFullPath  };

                // コネクションオブジェクトを生成します。
                using (var connection = new SQLiteConnection(connectionSb.ToString())) {
                    // コネクションをオープンします。
                    connection.Open();

                    // コマンドオブジェクトを生成します。
                    using (var command = connection.CreateCommand()) {
                        // テーブル一覧取得SQLを実行します。
                        command.CommandText = ListTableSql;
                        using (var reader = command.ExecuteReader()) {
                            // 取得した結果がある場合
                            if (reader.HasRows) {
                                // 取得した行数分繰り返します。
                                while (reader.Read()) {
                                    // テーブル名を表示します。
                                    var name = reader["name"] as string;
                                    // MessageBox.Show(name);

                                    // "CREATE TABLE sqlite_sequence(name,seq)"
                                    if (name != "sqlite_sequence") {
                                        list.Add(name);
                                    }
                                }
                            }
                        }
                        command.Dispose();
                    }
                }
                connectionSb.Clear();
                result = true;
            }//try

            // 例外が発生した場合
            catch (Exception e) {
                // 例外の内容を表示します。
                MessageBox.Show(e.Message);
                result = false;
            }

            return result;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  SELECT文  】---------------------------------------//
        /// <summary>
        /// データ取得ボタンクリックイベント SELECT文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal bool SELECT_ALL(string TableName, ref DataTable datatb) {

            bool Flg = false;
            if (TableName == "") { return Flg; }

            try {
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //クエリ実行

                //SQLiteDataAdapter adapter = new SQLiteDataAdapter("select * from " + TableName, DB_CONNECT);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT code_id AS '番号',lang AS '言語',name AS '名前',samplecode AS 'サンプル' FROM " + TableName, DB_CONNECT);

                DataSet Ds = new DataSet();      //データセットインスタンス作成
                DataTable dt = new DataTable();  //データテーブルインスタンス作成
                adapter.Fill(dt);                //データテーブルに代入
                Ds.Tables.Add(dt);               //データセットに追加

                datatb = Ds.Tables[0]; //グリッドビューにデータ表示
                adapter.Dispose();

                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();

            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  SELECT文 Where条件  】---------------------------------------//
        //https://www.venture-net.co.jp/engineer/18402/
        /// <summary>
        /// データ取得ボタンクリックイベント SELECT文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal bool SELECT_keyword(string TableName, ref List<List<string>> resultList, string keyword) {

            //private SQLiteConnection conn = new SQLiteConnection(@"Data Source = C:\work\SQLite.db"); // 「●●.db」でデータベースファイルが作成される.  絶対パスで置き場所指定もできる。
            bool Flg = false;
            if (TableName == "") { return Flg; }

            try {

                //DBを開く
                // DB_CONNECT.Open();//開いている状態で.Open()を使うとObjectが不安定になるから注意

                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "SELECT code_id AS '番号',lang AS '言語',name AS '名前',samplecode AS 'サンプル' FROM " + TableName + " WHERE name = @code";

                command.Parameters.Add(new SQLiteParameter("@code", keyword));

                //クエリ実行
                var result = command.ExecuteNonQuery();
                int i = 0;
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Console.WriteLine($"code_id={reader["番号"].ToString()} lang={reader["言語"]} name={reader["名前"]} samplecode={reader["サンプル"]}");
                        MessageBox.Show($"code_id={reader["番号"].ToString()} lang={reader["言語"]} name={reader["名前"]} samplecode={reader["サンプル"]}");
                        resultList.Add(new List<string>());
                        List<string> work = new List<string> { reader["番号"].ToString(), reader["言語"].ToString(), reader["名前"].ToString(), reader["サンプル"].ToString() };
                        resultList[i].AddRange(work);
                        i++;
                    }
                }

                //結果表示
                //  MessageBox.Show("データ取得完了.");
                command.Dispose();
                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show("SQL_Select_where文" + ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  SELECT文 Where条件 曖昧検索  】---------------------------------------//
        //https://www.venture-net.co.jp/engineer/18402/
        /// <summary>
        /// データ取得ボタンクリックイベント SELECT文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal bool SELECT_keyword_Link(string TableName, ref List<List<string>> resultList, string keyword) {

            //private SQLiteConnection conn = new SQLiteConnection(@"Data Source = C:\work\SQLite.db"); // 「●●.db」でデータベースファイルが作成される.  絶対パスで置き場所指定もできる。
            bool Flg = false;
            if (TableName == "") { return Flg; }

            try {

                //DBを開く
                // DB_CONNECT.Open();//開いている状態で.Open()を使うとObjectが不安定になるから注意

                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "SELECT code_id AS '番号',lang AS '言語',name AS '名前',samplecode AS 'サンプル' FROM " + TableName + " WHERE samplecode  LIKE  @code";

                string param = @"%" + keyword + @"%";

                command.Parameters.Add(new SQLiteParameter("@code", param));

                //クエリ実行
                var result = command.ExecuteNonQuery();
                int i = 0;
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Console.WriteLine($"code_id={reader["番号"].ToString()} lang={reader["言語"]} name={reader["名前"]} samplecode={reader["サンプル"]}");
                        MessageBox.Show($"code_id={reader["番号"].ToString()} lang={reader["言語"]} name={reader["名前"]} samplecode={reader["サンプル"]}");
                        resultList.Add(new List<string>());
                        List<string> work = new List<string> { reader["番号"].ToString(), reader["言語"].ToString(), reader["名前"].ToString(), reader["サンプル"].ToString() };
                        resultList[i].AddRange(work);
                        i++;
                    }
                }

                //結果表示
                //  MessageBox.Show("データ取得完了.");
                command.Dispose();
                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show("SQL_Select_where文" + ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region -------------【 DELETE文 削除  】---------------------------------------//
        internal bool Delete_SQL(string TableName, string id) {

            bool Flg = false;


            try {
                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();


                //SQL文作成　テーブル作成
                command.CommandText = "DELETE FROM " + TableName + " WHERE code_id = @code_id";
                int ID = int.Parse(id);
                command.Parameters.Add(new SQLiteParameter("@code_id", ID));

                if (command.ExecuteNonQuery() != 1) {
                    Console.WriteLine("■トランザクション失敗はロールバック");
                    tran.Rollback();
                    return false;
                }
                Console.WriteLine("■コミット");
                tran.Commit();

                MessageBox.Show("データ削除完了.");
                command.Dispose();
                Flg = true;

            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 UPDATE文  更新 】---------------------------------------//
        internal bool UPDATE_SQL(string TableName, string id, Dictionary<string, string> valus, ref string sql) {

            bool Flg = false;
            //DBを開く
            //  DB_CONNECT.Open();

            try {
                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "UPDATE " + TableName + " SET lang = @lang , name = @name , samplecode = @samplecode  WHERE code_id = @code_id";

                int ID = int.Parse(id);
                command.Parameters.Add(new SQLiteParameter("@lang", valus["lang"]));
                command.Parameters.Add(new SQLiteParameter("@name", valus["name"]));
                command.Parameters.Add(new SQLiteParameter("@samplecode", valus["samplecode"]));
                command.Parameters.Add(new SQLiteParameter("@code_id", ID));

                if (command.ExecuteNonQuery() != 1) {
                    Console.WriteLine("■トランザクション失敗はロールバック");
                    tran.Rollback();
                    return false;
                }
                Console.WriteLine("■コミット");
                tran.Commit();

                MessageBox.Show("データ更新完了.");
                command.Dispose();
                Flg = true;

            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 INSERT文   】---------------------------------------//
        internal bool INSERT_SQL(Dictionary<string, string> insertValue, string Tablename, ref string Sql) {

            bool Flg = false;

            //DBを開く
            //  DB_CONNECT.Open();
            try {
                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "INSERT INTO " + Tablename + " ( code_id, lang , name , samplecode ) VALUES(NULL , @lang, @name, @samplecode)";
                command.Parameters.Add(new SQLiteParameter("@lang", insertValue["lang"]));
                command.Parameters.Add(new SQLiteParameter("@name", insertValue["name"]));
                command.Parameters.Add(new SQLiteParameter("@samplecode", insertValue["samplecode"]));


                if (command.ExecuteNonQuery() != 1) {
                    Console.WriteLine("■トランザクション失敗はロールバック");
                    tran.Rollback();
                    return false;
                }
                Console.WriteLine("■コミット");
                tran.Commit();


                //結果表示
               // MessageBox.Show("データ登録完了.");
                command.Dispose();
                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 テーブルの新規作成   】---------------------------------------//
        internal bool CreateTable(string newTablename) {
            bool flg = false;
            try {
                //DBを開く
                //  DB_CONNECT.Open();

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "create table " + newTablename + " (code_id INTEGER PRIMARY KEY AUTOINCREMENT,lang TEXT,name TEXT,samplecode TEXT)";

                //クエリ実行
                command.ExecuteNonQuery();
                command.Dispose();
                //結果表示
                //  MessageBox.Show("データ登録完了.");
                flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                // DB_CONNECT.Close();
            }

            return flg;
        }

        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 テーブル名の変更   】---------------------------------------//
        internal bool ChangeTableName(string nowTableName, string newTablename) {
            bool flg = false;
            try {
                //DBを開く
                //  DB_CONNECT.Open();

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "ALTER TABLE " + nowTableName + " RENAME TO " + newTablename;

                //クエリ実行
                command.ExecuteNonQuery();
                command.Dispose();
                //結果表示
                //  MessageBox.Show("データ登録完了.");
                flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                // DB_CONNECT.Close();
            }

            return flg;
        }

        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 テーブルの削除   】---------------------------------------//
        internal bool Delete_Table(string Tablename) {
            bool flg = false;
            try {
                //DBを開く
                //  DB_CONNECT.Open();

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //! テーブル削除SQL
                string CreateTableSql = $"DROP TABLE IF EXISTS {Tablename}";



                //SQL文作成　テーブル作成
                command.CommandText = CreateTableSql;

                //クエリ実行
                command.ExecuteNonQuery();
                command.Dispose();

                //結果表示
                //  MessageBox.Show("データ登録完了.");
                flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            }

            return flg;
        }

        //------------    【   末尾  】     ----------------//
        #endregion





    }//------------------クラスの末尾
    #endregion


    #region -------------【  SQLiteのDataBaseをリストで管理用クラス  】---------------------------------------//
    public class SqliteList {

        private Dictionary<string, string> DBPathList = new Dictionary<string, string>();
        private Dictionary<string, SQLite_sql> DBList = new Dictionary<string, SQLite_sql>();
        public string FolderPath;
        public static string DBFolder = @"DBList";

        public DataTable dataSrc = new DataTable();




        #region -------------【  テーブル　1個 への　SQL文 】---------------------------------------//

        #region -------------【  SELEC文　取得  】---------------------------------------//
        public bool Get_SELECTALL(string DBname, string TableName) {
            if (DBname == "" || TableName == "") { return false; }
            dataSrc = new DataTable();
            if (DBList[DBname].SELECT_ALL(TableName, ref dataSrc)) {

                return true;
            } else {
                return false;
            }
        }
        #endregion -------------------------------//

        #region -------------【  SELEC文　Where条件　取得  】---------------------------------------//
        public bool Get_SELECT_Where(string DBname, string TableName, ref List<List<string>> resultList, string keyWord) {
            dataSrc = new DataTable();
            if (DBList[DBname].SELECT_keyword(TableName, ref resultList, keyWord)) {

                return true;
            } else {
                return false;
            }
        }
        #endregion -------------------------------//

        #region -------------【  SELEC文　Where条件 曖昧検索　取得  】---------------------------------------//
        public bool Get_SELECT_Where_Like(string DBname, string TableName, ref List<List<string>> resultList, string keyWord) {
            dataSrc = new DataTable();
            if (DBList[DBname].SELECT_keyword_Link(TableName, ref resultList, keyWord)) {

                return true;
            } else {
                return false;
            }
        }
        #endregion -------------------------------//

        #region -------------【 追加 SQL   】---------------------------------------//
        public bool INSERT_SQL(Dictionary<string, string> InsertValue, string DBname, string TBname, ref string sql) {
            if (DBList[DBname].INSERT_SQL(InsertValue, TBname, ref sql)) {
                //  MessageBox.Show("追加　成功!!");
                return true;
            } else {
                MessageBox.Show("追加 失敗");
                return false;
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  項目の削除  】---------------------------------------//
        public bool Delete_Query(string DBname, string TBname, string id) {
            bool Flg = false;

            if (DBList[DBname].Delete_SQL(TBname, id)) {
                MessageBox.Show("削除完了(≧ω≦)");
                return true;
            } else {
                MessageBox.Show("削除失敗(´；ω；`)ｳｩｩ");
                return false;
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  項目の更新  】---------------------------------------//
        public bool UpData_Query(string DBname, string TBname, string id, Dictionary<string, string> valus, ref string sql) {
            bool Flg = false;

            if (DBList[DBname].UPDATE_SQL(TBname, id, valus, ref sql)) {
                MessageBox.Show("更新完了(≧ω≦)");
                return true;
            } else {
                MessageBox.Show("更新失敗(´；ω；`)ｳｩｩ");
                return false;
            }
        }
        //------------    【  UPDATE 末尾  】     ----------------//
        #endregion

        #region -------------【  テーブル名の変更  】---------------------------------------//
        public bool Change_Table_Query(string DBname, string nowTableName, string newTableName, ref string sql) {


            if (DBList[DBname].ChangeTableName(nowTableName, newTableName)) {
                MessageBox.Show("更新完了(≧ω≦)");
                return true;
            } else {
                MessageBox.Show("更新失敗(´；ω；`)ｳｩｩ");
                return false;
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  テーブルの削除  】---------------------------------------//
        public bool Delete_Table_Query(string DBname, string TBname, ref string sql) {


            if (DBList[DBname].Delete_Table(TBname)) {
                MessageBox.Show("テーブルの削除完了(≧ω≦)");
                return true;
            } else {
                MessageBox.Show("テーブル削除失敗(´；ω；`)ｳｩｩ");
                return false;
            }
        }
        //------------    【 テーブル削除  末尾  】     ----------------//
        #endregion
        #endregion ------------  テーブル１つへのSQL　末尾  -----------------------//

        #region -------------【  テーブル名取得  】---------------------------------------//
        public bool Get_TableName(string DBname, ref string tbname) {

            if (Get_TableList(DBname).Length > 0) {
                tbname = Get_TableList(DBname)[0];
                // MessageBox.Show(tbname);
                return true;
            } else {
                return false;
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  テーブル名一覧取得  】---------------------------------------//
        public string[] Get_TableList(string DBname) {

            List<string> list = new List<string>();
            if (DBList[DBname].GetTablesName(DBname, ref list)) {
                //  MessageBox.Show("テーブルListの取得成功");
            } else {
                MessageBox.Show("テーブルListの取得失敗");
            }

            return list.ToArray();

        }

        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  データベースファイル一覧取得  】---------------------------------------//
        public string[] Get_DBnameList {
            get {
                List<string> list = new List<string>();

                //DictionaryのForEach文
                foreach (KeyValuePair<string, SQLite_sql> s in DBList) {
                    string id = s.Key;
                    SQLite_sql sq = s.Value;
                    //MessageBox.Show(id);
                    list.Add(id);
                }

                return list.ToArray();
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  コンストラクタ取得  】---------------------------------------//
        public SqliteList( string DBFileNamePath) {

            string dbFolder = Path.GetDirectoryName(DBFileNamePath);
            this.FolderPath = dbFolder;

            IEnumerable<string> files = System.IO.Directory.EnumerateFiles(FolderPath + @"\", "*.db", System.IO.SearchOption.TopDirectoryOnly);//実行するのは検索したい場所の親フォルダから

            List<string> DBFileNameList = new List<string>();

            //ファイルを列挙する
            foreach (string f in files) {
                //ListBox1に結果を表示する
                // DBpathList.Add(f);

                //拡張子なしのファイル名をパスから取得するには、「GetFileNameWithoutExtensionメソッド」を使います。

                string fileName = Path.GetFileName(f);
               
                //MessageBox.Show(f);
                DBList.Add(fileName, new SQLite_sql(fileName, f));
                DBFileNameList.Add(fileName);

            }

            if (DBList.Count > 0) {
                
                if (Get_TableList(DBFileNameList[0]).Length > 0) {
                    string Tbname = "";

                    if (Get_TableName(DBFileNameList[0], ref Tbname)) {
                        // MessageBox.Show(DBFileNameList[0]);
                        //MessageBox.Show(Tbname);
                        if (Get_SELECTALL(DBFileNameList[0], Tbname)) {
                            // MessageBox.Show("SELECTALL成功");

                        } else {
                            MessageBox.Show("SELECTALL失敗");
                        }
                    }

                }

            }

        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region
        public string Get_FullPath(string DBname) {
            return DBList[DBname].DatabaseFullPath; 
        }
        #endregion
        #region
        public bool Dictionary_KEY_Change(string newName,string oldName,string newFullPath) {
            bool Flg = false;
            string newKey = newName, oldKey = oldName;
            //newKey=新しいキー、oldKey=古いキー
            //DBList[newKey] = DBList[oldKey];
            DBList.Remove(oldKey);
            //DBList[newKey].DatabaseFullPath = newFullPath;

            this.FolderPath = Exe_Path.exe_Path() + DBFolder;
            try {
                SQLite_sql newDB = new SQLite_sql(newKey, newFullPath);
                DBList.Add(newKey, newDB);
                Flg = true;
            } catch (Exception e) { MessageBox.Show(e.Message); }
            return Flg;
        }
        #endregion
        #region -------------【  新規 DataBase データベース作成  】---------------------------------------//
        public bool newDataBase(string newDBFilename) {

            newDBFilename += ".db";

            foreach (KeyValuePair<string, SQLite_sql> s in DBList) {

                string id = s.Key;
                SQLite_sql sq = s.Value;
                if (id == newDBFilename) {
                    MessageBox.Show("同じ名前が既にあります");
                    return false;
                }
            }

            bool Flg = false;
            this.FolderPath = Exe_Path.exe_Path() + DBFolder;
            try {
               // MessageBox.Show(FolderPath + @"\" + newDBFilename);
                SQLite_sql newDB = new SQLite_sql(newDBFilename, FolderPath+@"\" + newDBFilename);
                DBList.Add(newDBFilename, newDB);
                Flg = true;
            } catch (Exception e) { MessageBox.Show(e.Message); }

            return Flg;

        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 新規　Table　テーブル追加  】---------------------------------------//
        public bool newTableCreate(string SelectDBname, string newTableName) {
            if (Name_Check(newTableName, Get_TableList(SelectDBname))) {
                if (DBList[SelectDBname].CreateTable(newTableName)) {
                    // MessageBox.Show("テーブルの新規作成成功");
                    return true;
                } else {
                    MessageBox.Show("テーブルの新規作成が失敗");
                    return false;
                }
            } else {
                //MessageBox.Show("名前に被りがあります");
                return false;
            }

        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  テーブル名、データベース名の一致を確認する  】---------------------------------------//
        private bool Name_Check(string search, string[] NameList) {

            foreach (string s in NameList) {
                if (search == s) {
                    return false;
                }
            }

            //Console.WriteLine("名前にダブり無し！");
            return true;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  データベースの単体接続終了  】---------------------------------------//
        public bool DataBase_One_Closeing_Delete(string DBname) {
            bool flg = false;
           // MessageBox.Show("削除DataBase_One_Closeinge");
            if (DBList[DBname].Sqlite_Close()) {

                //MessageBox.Show(DBList[DBname].DatabaseFullPath);
                try {
                    System.IO.File.Delete(DBList[DBname].DatabaseFullPath);
                    DBList.Remove(DBname);
                    //MessageBox.Show("削除Sqlite_Close");
                    flg = true;
                }catch(Exception ex) {
                    MessageBox.Show(ex.Message+"\n"+ DBList[DBname].DatabaseFullPath);
                }
            }
            return flg;
        }

        public bool DataBase_One_Closeing_UPDate(string DBname) {
            bool flg = false;
            // MessageBox.Show("削除DataBase_One_Closeinge");
            if (DBList[DBname].Sqlite_Close()) {


                //MessageBox.Show("削除Sqlite_Close");
                flg = true;
            }
            return flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  データベースの接続終了  】---------------------------------------//
        public void DataBaseListCloseing() {

            //DictionaryのForEach文
            foreach (KeyValuePair<string, SQLite_sql> s in DBList) {

                string id = s.Key;
                SQLite_sql sq = s.Value;
                sq.Sqlite_Close();
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion


    }
    //------------    【   末尾  】     ----------------//
    #endregion


}
