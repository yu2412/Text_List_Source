
namespace MyCreate {
    partial class SelectForm1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox00 = new System.Windows.Forms.ListBox();
            this.panel = new System.Windows.Forms.Panel();
            this.CANCEL_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel_inBtn = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel_list = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel_inBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(183, 131);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox00
            // 
            this.listBox00.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox00.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBox00.FormattingEnabled = true;
            this.listBox00.ItemHeight = 20;
            this.listBox00.Location = new System.Drawing.Point(183, 0);
            this.listBox00.Name = "listBox00";
            this.listBox00.Size = new System.Drawing.Size(176, 131);
            this.listBox00.TabIndex = 1;
            this.listBox00.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel.Controls.Add(this.panel_list);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(359, 131);
            this.panel.TabIndex = 2;
            // 
            // CANCEL_btn
            // 
            this.CANCEL_btn.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CANCEL_btn.Location = new System.Drawing.Point(12, 8);
            this.CANCEL_btn.Name = "CANCEL_btn";
            this.CANCEL_btn.Size = new System.Drawing.Size(120, 51);
            this.CANCEL_btn.TabIndex = 3;
            this.CANCEL_btn.Text = "キャンセル";
            this.CANCEL_btn.UseVisualStyleBackColor = true;
            this.CANCEL_btn.Click += new System.EventHandler(this.CANCEL_btn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(226, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 51);
            this.button1.TabIndex = 4;
            this.button1.Text = "決定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer.Panel2.Controls.Add(this.panel_inBtn);
            this.splitContainer.Size = new System.Drawing.Size(359, 212);
            this.splitContainer.SplitterDistance = 131;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 5;
            // 
            // panel_inBtn
            // 
            this.panel_inBtn.BackColor = System.Drawing.Color.Snow;
            this.panel_inBtn.Controls.Add(this.CANCEL_btn);
            this.panel_inBtn.Controls.Add(this.button1);
            this.panel_inBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_inBtn.Location = new System.Drawing.Point(0, 7);
            this.panel_inBtn.Name = "panel_inBtn";
            this.panel_inBtn.Size = new System.Drawing.Size(359, 66);
            this.panel_inBtn.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(359, 7);
            this.dataGridView1.TabIndex = 6;
            // 
            // panel_list
            // 
            this.panel_list.BackColor = System.Drawing.Color.Ivory;
            this.panel_list.Controls.Add(this.listBox1);
            this.panel_list.Controls.Add(this.listBox00);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 0);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(359, 131);
            this.panel_list.TabIndex = 2;
            // 
            // SelectForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 212);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer);
            this.Name = "SelectForm1";
            this.Text = "SelectForm1";
            this.Load += new System.EventHandler(this.SelectForm1_Load);
            this.panel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel_inBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox00;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button CANCEL_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel_inBtn;
        private System.Windows.Forms.Panel panel_list;
    }
}