
namespace AutoCode
{
    partial class AutoCodeClass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Table_CkList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Confirm_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.FilePathBtn = new System.Windows.Forms.Button();
            this.Tb_FilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Table_CkList
            // 
            this.Table_CkList.CheckOnClick = true;
            this.Table_CkList.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Table_CkList.FormattingEnabled = true;
            this.Table_CkList.Location = new System.Drawing.Point(12, 36);
            this.Table_CkList.Name = "Table_CkList";
            this.Table_CkList.Size = new System.Drawing.Size(389, 379);
            this.Table_CkList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "選擇資料表：";
            // 
            // Confirm_Btn
            // 
            this.Confirm_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Confirm_Btn.Location = new System.Drawing.Point(229, 504);
            this.Confirm_Btn.Name = "Confirm_Btn";
            this.Confirm_Btn.Size = new System.Drawing.Size(172, 43);
            this.Confirm_Btn.TabIndex = 2;
            this.Confirm_Btn.Text = "確認";
            this.Confirm_Btn.UseVisualStyleBackColor = true;
            this.Confirm_Btn.Click += new System.EventHandler(this.Confirm_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cancel_Btn.Location = new System.Drawing.Point(12, 504);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(182, 43);
            this.Cancel_Btn.TabIndex = 3;
            this.Cancel_Btn.Text = "取消";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // FilePathBtn
            // 
            this.FilePathBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FilePathBtn.Location = new System.Drawing.Point(154, 434);
            this.FilePathBtn.Name = "FilePathBtn";
            this.FilePathBtn.Size = new System.Drawing.Size(97, 25);
            this.FilePathBtn.TabIndex = 17;
            this.FilePathBtn.Text = "選擇";
            this.FilePathBtn.UseVisualStyleBackColor = true;
            this.FilePathBtn.Click += new System.EventHandler(this.FilePathBtn_Click);
            // 
            // Tb_FilePath
            // 
            this.Tb_FilePath.Location = new System.Drawing.Point(16, 468);
            this.Tb_FilePath.Name = "Tb_FilePath";
            this.Tb_FilePath.ReadOnly = true;
            this.Tb_FilePath.Size = new System.Drawing.Size(385, 22);
            this.Tb_FilePath.TabIndex = 16;
            this.Tb_FilePath.Text = "D:\\AutoCodeClass";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(12, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "檔案輸出路徑";
            // 
            // AutoCodeClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 559);
            this.Controls.Add(this.FilePathBtn);
            this.Controls.Add(this.Tb_FilePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Confirm_Btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Table_CkList);
            this.Name = "AutoCodeClass";
            this.Text = "資料表清單";
            this.Load += new System.EventHandler(this.ColListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox Table_CkList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Confirm_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button FilePathBtn;
        private System.Windows.Forms.TextBox Tb_FilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}