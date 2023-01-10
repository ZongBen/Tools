
namespace AutoCode
{
    partial class AutoCodeModel
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
            this.Remove_Btn = new System.Windows.Forms.Button();
            this.CancelALL_Btn = new System.Windows.Forms.Button();
            this.SelectALL_Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.AddCol_Btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Col_CkList = new System.Windows.Forms.CheckedListBox();
            this.TableList_DDL = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.ModelCol_CkList = new System.Windows.Forms.CheckedListBox();
            this.CodeModel_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ModelName_Tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FilePath_Tb = new System.Windows.Forms.TextBox();
            this.FilePathBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Remove_Btn
            // 
            this.Remove_Btn.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Remove_Btn.Location = new System.Drawing.Point(525, 193);
            this.Remove_Btn.Name = "Remove_Btn";
            this.Remove_Btn.Size = new System.Drawing.Size(53, 25);
            this.Remove_Btn.TabIndex = 38;
            this.Remove_Btn.Text = "移除";
            this.Remove_Btn.UseVisualStyleBackColor = true;
            this.Remove_Btn.Click += new System.EventHandler(this.Remove_Btn_Click);
            // 
            // CancelALL_Btn
            // 
            this.CancelALL_Btn.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CancelALL_Btn.Location = new System.Drawing.Point(139, 193);
            this.CancelALL_Btn.Name = "CancelALL_Btn";
            this.CancelALL_Btn.Size = new System.Drawing.Size(53, 25);
            this.CancelALL_Btn.TabIndex = 37;
            this.CancelALL_Btn.Text = "取消";
            this.CancelALL_Btn.UseVisualStyleBackColor = true;
            this.CancelALL_Btn.Click += new System.EventHandler(this.CancelALL_Btn_Click);
            // 
            // SelectALL_Btn
            // 
            this.SelectALL_Btn.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SelectALL_Btn.Location = new System.Drawing.Point(198, 193);
            this.SelectALL_Btn.Name = "SelectALL_Btn";
            this.SelectALL_Btn.Size = new System.Drawing.Size(53, 25);
            this.SelectALL_Btn.TabIndex = 36;
            this.SelectALL_Btn.Text = "全選";
            this.SelectALL_Btn.UseVisualStyleBackColor = true;
            this.SelectALL_Btn.Click += new System.EventHandler(this.SelectALL_Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(330, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "結果:";
            // 
            // AddCol_Btn
            // 
            this.AddCol_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AddCol_Btn.Location = new System.Drawing.Point(257, 372);
            this.AddCol_Btn.Name = "AddCol_Btn";
            this.AddCol_Btn.Size = new System.Drawing.Size(70, 28);
            this.AddCol_Btn.TabIndex = 34;
            this.AddCol_Btn.Text = "增加->";
            this.AddCol_Btn.UseVisualStyleBackColor = true;
            this.AddCol_Btn.Click += new System.EventHandler(this.AddCol_Btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(9, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "選取欄位:";
            // 
            // Col_CkList
            // 
            this.Col_CkList.CheckOnClick = true;
            this.Col_CkList.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Col_CkList.FormattingEnabled = true;
            this.Col_CkList.Location = new System.Drawing.Point(12, 224);
            this.Col_CkList.Name = "Col_CkList";
            this.Col_CkList.Size = new System.Drawing.Size(242, 334);
            this.Col_CkList.TabIndex = 32;
            // 
            // TableList_DDL
            // 
            this.TableList_DDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableList_DDL.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TableList_DDL.FormattingEnabled = true;
            this.TableList_DDL.Location = new System.Drawing.Point(111, 147);
            this.TableList_DDL.Name = "TableList_DDL";
            this.TableList_DDL.Size = new System.Drawing.Size(432, 24);
            this.TableList_DDL.TabIndex = 31;
            this.TableList_DDL.SelectedIndexChanged += new System.EventHandler(this.TableList_DDL_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "選擇資料表：";
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReturnBtn.Location = new System.Drawing.Point(12, 13);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(87, 32);
            this.ReturnBtn.TabIndex = 29;
            this.ReturnBtn.Text = "返回主頁";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // ModelCol_CkList
            // 
            this.ModelCol_CkList.CheckOnClick = true;
            this.ModelCol_CkList.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ModelCol_CkList.FormattingEnabled = true;
            this.ModelCol_CkList.Location = new System.Drawing.Point(333, 221);
            this.ModelCol_CkList.Name = "ModelCol_CkList";
            this.ModelCol_CkList.Size = new System.Drawing.Size(250, 334);
            this.ModelCol_CkList.TabIndex = 39;
            // 
            // CodeModel_Btn
            // 
            this.CodeModel_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CodeModel_Btn.Location = new System.Drawing.Point(169, 575);
            this.CodeModel_Btn.Name = "CodeModel_Btn";
            this.CodeModel_Btn.Size = new System.Drawing.Size(242, 32);
            this.CodeModel_Btn.TabIndex = 40;
            this.CodeModel_Btn.Text = "產生Model";
            this.CodeModel_Btn.UseVisualStyleBackColor = true;
            this.CodeModel_Btn.Click += new System.EventHandler(this.CodeModel_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(19, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Model名稱：";
            // 
            // ModelName_Tb
            // 
            this.ModelName_Tb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ModelName_Tb.Location = new System.Drawing.Point(111, 62);
            this.ModelName_Tb.Name = "ModelName_Tb";
            this.ModelName_Tb.Size = new System.Drawing.Size(432, 27);
            this.ModelName_Tb.TabIndex = 42;
            this.ModelName_Tb.Text = "Template";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(26, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "輸出路徑：";
            // 
            // FilePath_Tb
            // 
            this.FilePath_Tb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FilePath_Tb.Location = new System.Drawing.Point(111, 105);
            this.FilePath_Tb.Name = "FilePath_Tb";
            this.FilePath_Tb.Size = new System.Drawing.Size(329, 27);
            this.FilePath_Tb.TabIndex = 44;
            this.FilePath_Tb.Text = "D:\\AutoCodeClass";
            // 
            // FilePathBtn
            // 
            this.FilePathBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FilePathBtn.Location = new System.Drawing.Point(446, 105);
            this.FilePathBtn.Name = "FilePathBtn";
            this.FilePathBtn.Size = new System.Drawing.Size(97, 25);
            this.FilePathBtn.TabIndex = 45;
            this.FilePathBtn.Text = "選擇";
            this.FilePathBtn.UseVisualStyleBackColor = true;
            this.FilePathBtn.Click += new System.EventHandler(this.FilePathBtn_Click);
            // 
            // AutoCodeModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 619);
            this.Controls.Add(this.FilePathBtn);
            this.Controls.Add(this.FilePath_Tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ModelName_Tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CodeModel_Btn);
            this.Controls.Add(this.ModelCol_CkList);
            this.Controls.Add(this.Remove_Btn);
            this.Controls.Add(this.CancelALL_Btn);
            this.Controls.Add(this.SelectALL_Btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddCol_Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Col_CkList);
            this.Controls.Add(this.TableList_DDL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReturnBtn);
            this.Name = "AutoCodeModel";
            this.Text = "AutoCodeModel";
            this.Load += new System.EventHandler(this.AutoCodeModel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Remove_Btn;
        private System.Windows.Forms.Button CancelALL_Btn;
        private System.Windows.Forms.Button SelectALL_Btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddCol_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox Col_CkList;
        private System.Windows.Forms.ComboBox TableList_DDL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.CheckedListBox ModelCol_CkList;
        private System.Windows.Forms.Button CodeModel_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ModelName_Tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FilePath_Tb;
        private System.Windows.Forms.Button FilePathBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}