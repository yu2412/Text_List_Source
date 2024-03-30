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

namespace MyCreate {
    public partial class SelectForm1 : Form {

       // string[] TBList;
       string SqlitePath;
       List< Dictionary<string, string>> ValueSetList = new List< Dictionary<string, string>>();
       int CheckCount;


        #region -------------【  プロパティ  】---------------------------------------//
        List<string> Value_List;
     
//        const string List_src = @"DBList\";

        public static SqliteList sqliteList;



//------------    【   末尾  】     ----------------//
#endregion



        public SelectForm1(string SqlitePath, List< Dictionary<string, string>> ValueSetList){//,string[] TBList, ) {
            InitializeComponent();

           // this.TBList = TBList;
            this.SqlitePath = SqlitePath;
            this.ValueSetList = ValueSetList;
            this.CheckCount = ValueSetList.Count;
        }

        private void SelectForm1_Load(object sender, EventArgs e) {

            
            sqliteList = new SqliteList(this.SqlitePath);

            if (sqliteList.Get_DBnameList.Length > 0) {
                listBox00.Items.AddRange(sqliteList.Get_DBnameList);
                listBox00.SelectedIndex = 0;
            }

           // listBox1.Items.AddRange(TBList);
           // listBox00.Items.AddRange(SqliteList);
        }

        private void button1_Click(object sender, EventArgs e) {
            int CopyCount = 0;

            for (int i = 0; i < ValueSetList.Count; i++) {
                string sql = "";
                if (sqliteList.INSERT_SQL(ValueSetList[i], listBox00.SelectedItem.ToString(), listBox1.SelectedItem.ToString(), ref sql)) {
                    CopyCount++;
                }
}
            if (CopyCount >= CheckCount) {
                this.DialogResult = DialogResult.OK;
            } else {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void CANCEL_btn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {

            listBox1.Items.Clear();
            dataGridView1.DataSource = null;

            if (sqliteList.Get_TableList(listBox00.Text).Length > 0) {
                listBox1.Items.AddRange(sqliteList.Get_TableList(listBox00.Text));

                if (listBox1.Items.Count > 0) {
                    listBox1.SelectedIndex = 0;
                } else {
                    dataGridView1.DataSource = null;
                }

            } else {
                dataGridView1.DataSource = null;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            //if (sqliteList.Get_SELECTALL(listBox00.Text, listBox1.Text)) {
            DataGrid_RESET();
        }

        private void DataGrid_RESET() {
            if (listBox00.Text == "" || listBox1.Text == "") { return; }
            if (sqliteList.Get_SELECTALL(listBox00.SelectedItem.ToString(), listBox1.SelectedItem.ToString())) {
                dataGridView1.DataSource = sqliteList.dataSrc;
                TableColumWide(ref dataGridView1);
            }
        }

        private static void TableColumWide(ref DataGridView data1) {
            data1.RowTemplate.Height = 20;
            data1.Columns[0].Width = 50;
            data1.Columns[1].Width = 70;
            data1.Columns[2].Width = 70;
            data1.Columns[3].Width = 10;
            //data1.Columns[4].Width = 600;
        }
    }
}
