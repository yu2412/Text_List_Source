
namespace Temporarily_Save_Text_List {
    partial class TextForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextForm));
            this.panel_sub = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.チェック項目を削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBListに保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.テキストファイル判定変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Btn = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCpy = new System.Windows.Forms.Button();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.All_DeleteMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Select_Delete_StripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.追加ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectSaveitem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DBListMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label_font = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.RichTextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.選択範囲をURLで開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.選択範囲をGoogle検索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.選択範囲を英語翻訳ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外部からインポートToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel_sub.SuspendLayout();
            this.ListMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Btn.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.RichTextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_sub
            // 
            this.panel_sub.BackColor = System.Drawing.Color.White;
            this.panel_sub.Controls.Add(this.checkedListBox1);
            this.panel_sub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sub.Location = new System.Drawing.Point(0, 0);
            this.panel_sub.Name = "panel_sub";
            this.panel_sub.Size = new System.Drawing.Size(209, 438);
            this.panel_sub.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ContextMenuStrip = this.ListMenuStrip;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(209, 438);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.checkedListBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.checkedListBox1_DragDrop);
            this.checkedListBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.checkedListBox1_DragEnter);
            // 
            // ListMenuStrip
            // 
            this.ListMenuStrip.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ListMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem,
            this.チェック項目を削除ToolStripMenuItem,
            this.dBListに保存ToolStripMenuItem,
            this.テキストファイル判定変更ToolStripMenuItem,
            this.外部からインポートToolStripMenuItem});
            this.ListMenuStrip.Name = "ListMenuStrip";
            this.ListMenuStrip.Size = new System.Drawing.Size(326, 212);
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            this.追加ToolStripMenuItem.Size = new System.Drawing.Size(325, 36);
            this.追加ToolStripMenuItem.Text = "新規テキスト追加";
            this.追加ToolStripMenuItem.Click += new System.EventHandler(this.追加ToolStripMenuItem_Click);
            // 
            // チェック項目を削除ToolStripMenuItem
            // 
            this.チェック項目を削除ToolStripMenuItem.Name = "チェック項目を削除ToolStripMenuItem";
            this.チェック項目を削除ToolStripMenuItem.Size = new System.Drawing.Size(325, 36);
            this.チェック項目を削除ToolStripMenuItem.Text = "チェック項目を削除";
            this.チェック項目を削除ToolStripMenuItem.Click += new System.EventHandler(this.チェック項目を削除ToolStripMenuItem_Click);
            // 
            // dBListに保存ToolStripMenuItem
            // 
            this.dBListに保存ToolStripMenuItem.Name = "dBListに保存ToolStripMenuItem";
            this.dBListに保存ToolStripMenuItem.Size = new System.Drawing.Size(325, 36);
            this.dBListに保存ToolStripMenuItem.Text = "DBListに保存";
            this.dBListに保存ToolStripMenuItem.Click += new System.EventHandler(this.dBListに保存ToolStripMenuItem_Click);
            // 
            // テキストファイル判定変更ToolStripMenuItem
            // 
            this.テキストファイル判定変更ToolStripMenuItem.Name = "テキストファイル判定変更ToolStripMenuItem";
            this.テキストファイル判定変更ToolStripMenuItem.Size = new System.Drawing.Size(325, 36);
            this.テキストファイル判定変更ToolStripMenuItem.Text = "テキストファイル判定変更";
            this.テキストファイル判定変更ToolStripMenuItem.Click += new System.EventHandler(this.テキスト判定変更ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.panel_sub);
            this.panel1.Controls.Add(this.panel_Btn);
            this.panel1.Controls.Add(this.panel_Buttom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 552);
            this.panel1.TabIndex = 1;
            // 
            // panel_Btn
            // 
            this.panel_Btn.BackColor = System.Drawing.Color.MistyRose;
            this.panel_Btn.Controls.Add(this.button1);
            this.panel_Btn.Controls.Add(this.buttonCpy);
            this.panel_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Btn.Location = new System.Drawing.Point(0, 438);
            this.panel_Btn.Name = "panel_Btn";
            this.panel_Btn.Size = new System.Drawing.Size(209, 49);
            this.panel_Btn.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(79, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "クリップボード";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCpy
            // 
            this.buttonCpy.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCpy.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCpy.Location = new System.Drawing.Point(0, 0);
            this.buttonCpy.Name = "buttonCpy";
            this.buttonCpy.Size = new System.Drawing.Size(79, 49);
            this.buttonCpy.TabIndex = 0;
            this.buttonCpy.Text = "Copy";
            this.buttonCpy.UseVisualStyleBackColor = true;
            this.buttonCpy.Click += new System.EventHandler(this.buttonCpy_Click);
            // 
            // panel_Buttom
            // 
            this.panel_Buttom.Controls.Add(this.menuStrip);
            this.panel_Buttom.Controls.Add(this.label_font);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Buttom.Location = new System.Drawing.Point(0, 487);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(209, 65);
            this.panel_Buttom.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(151, 65);
            this.menuStrip.TabIndex = 1;
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.All_DeleteMenuItem2,
            this.Select_Delete_StripMenuItem1,
            this.追加ToolStripMenuItem1,
            this.保存ToolStripMenuItem,
            this.SelectSaveitem1,
            this.DBListMenuItem1});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(95, 61);
            this.メニューToolStripMenuItem.Text = "メニュー";
            // 
            // All_DeleteMenuItem2
            // 
            this.All_DeleteMenuItem2.Name = "All_DeleteMenuItem2";
            this.All_DeleteMenuItem2.Size = new System.Drawing.Size(331, 36);
            this.All_DeleteMenuItem2.Text = "全て削除";
            this.All_DeleteMenuItem2.Click += new System.EventHandler(this.All_DeleteMenuItem2_Click);
            // 
            // Select_Delete_StripMenuItem1
            // 
            this.Select_Delete_StripMenuItem1.Name = "Select_Delete_StripMenuItem1";
            this.Select_Delete_StripMenuItem1.Size = new System.Drawing.Size(331, 36);
            this.Select_Delete_StripMenuItem1.Text = "チェック項目を削除";
            this.Select_Delete_StripMenuItem1.Click += new System.EventHandler(this.Select_Delete_StripMenuItem1_Click);
            // 
            // 追加ToolStripMenuItem1
            // 
            this.追加ToolStripMenuItem1.Name = "追加ToolStripMenuItem1";
            this.追加ToolStripMenuItem1.Size = new System.Drawing.Size(331, 36);
            this.追加ToolStripMenuItem1.Text = "新規テキスト追加";
            this.追加ToolStripMenuItem1.Click += new System.EventHandler(this.追加ToolStripMenuItem1_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.保存ToolStripMenuItem.Text = "選択項目を保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // SelectSaveitem1
            // 
            this.SelectSaveitem1.Name = "SelectSaveitem1";
            this.SelectSaveitem1.Size = new System.Drawing.Size(331, 36);
            this.SelectSaveitem1.Text = "チェック項目を一斉保存";
            this.SelectSaveitem1.Click += new System.EventHandler(this.SelectSaveitem1_Click);
            // 
            // DBListMenuItem1
            // 
            this.DBListMenuItem1.Name = "DBListMenuItem1";
            this.DBListMenuItem1.Size = new System.Drawing.Size(331, 36);
            this.DBListMenuItem1.Text = "DBListに保存";
            this.DBListMenuItem1.Click += new System.EventHandler(this.DBListMenuItem1_Click);
            // 
            // label_font
            // 
            this.label_font.BackColor = System.Drawing.Color.SeaShell;
            this.label_font.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_font.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_font.Location = new System.Drawing.Point(151, 0);
            this.label_font.Name = "label_font";
            this.label_font.Size = new System.Drawing.Size(58, 65);
            this.label_font.TabIndex = 3;
            this.label_font.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox
            // 
            this.richTextBox.ContextMenuStrip = this.RichTextMenuStrip;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(636, 552);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // RichTextMenuStrip
            // 
            this.RichTextMenuStrip.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RichTextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RichTextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.選択範囲をURLで開くToolStripMenuItem,
            this.選択範囲をGoogle検索ToolStripMenuItem,
            this.選択範囲を英語翻訳ToolStripMenuItem,
            this.コピーToolStripMenuItem});
            this.RichTextMenuStrip.Name = "RichTextMenuStrip";
            this.RichTextMenuStrip.Size = new System.Drawing.Size(330, 148);
            // 
            // 選択範囲をURLで開くToolStripMenuItem
            // 
            this.選択範囲をURLで開くToolStripMenuItem.Name = "選択範囲をURLで開くToolStripMenuItem";
            this.選択範囲をURLで開くToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.選択範囲をURLで開くToolStripMenuItem.Text = "選択範囲をURLで開く";
            this.選択範囲をURLで開くToolStripMenuItem.Click += new System.EventHandler(this.選択範囲をURLで開くToolStripMenuItem_Click);
            // 
            // 選択範囲をGoogle検索ToolStripMenuItem
            // 
            this.選択範囲をGoogle検索ToolStripMenuItem.Name = "選択範囲をGoogle検索ToolStripMenuItem";
            this.選択範囲をGoogle検索ToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.選択範囲をGoogle検索ToolStripMenuItem.Text = "選択範囲をGoogle検索";
            this.選択範囲をGoogle検索ToolStripMenuItem.Click += new System.EventHandler(this.選択範囲をGoogle検索ToolStripMenuItem_Click);
            // 
            // 選択範囲を英語翻訳ToolStripMenuItem
            // 
            this.選択範囲を英語翻訳ToolStripMenuItem.Name = "選択範囲を英語翻訳ToolStripMenuItem";
            this.選択範囲を英語翻訳ToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.選択範囲を英語翻訳ToolStripMenuItem.Text = "選択範囲を英語翻訳";
            this.選択範囲を英語翻訳ToolStripMenuItem.Click += new System.EventHandler(this.選択範囲を英語翻訳ToolStripMenuItem_Click);
            // 
            // コピーToolStripMenuItem
            // 
            this.コピーToolStripMenuItem.Name = "コピーToolStripMenuItem";
            this.コピーToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.コピーToolStripMenuItem.Text = "コピー";
            this.コピーToolStripMenuItem.Click += new System.EventHandler(this.コピーToolStripMenuItem_Click);
            // 
            // 外部からインポートToolStripMenuItem
            // 
            this.外部からインポートToolStripMenuItem.Name = "外部からインポートToolStripMenuItem";
            this.外部からインポートToolStripMenuItem.Size = new System.Drawing.Size(325, 36);
            this.外部からインポートToolStripMenuItem.Text = "外部からインポート";
            this.外部からインポートToolStripMenuItem.Click += new System.EventHandler(this.外部からインポートToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.richTextBox);
            this.splitContainer.Size = new System.Drawing.Size(855, 552);
            this.splitContainer.SplitterDistance = 209;
            this.splitContainer.SplitterWidth = 10;
            this.splitContainer.TabIndex = 2;
            // 
            // TextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 552);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TextForm";
            this.Text = "一時保存メモ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_sub.ResumeLayout(false);
            this.ListMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Btn.ResumeLayout(false);
            this.panel_Buttom.ResumeLayout(false);
            this.panel_Buttom.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.RichTextMenuStrip.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_sub;
        private System.Windows.Forms.ContextMenuStrip ListMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ContextMenuStrip RichTextMenuStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem All_DeleteMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Select_Delete_StripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ToolStripMenuItem チェック項目を削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 選択範囲をURLで開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 選択範囲をGoogle検索ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 選択範囲を英語翻訳ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コピーToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCpy;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Label label_font;
        private System.Windows.Forms.ToolStripMenuItem SelectSaveitem1;
        private System.Windows.Forms.ToolStripMenuItem dBListに保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DBListMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem テキストファイル判定変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外部からインポートToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

