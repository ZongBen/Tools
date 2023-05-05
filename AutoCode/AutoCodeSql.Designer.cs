
namespace AutoCode
{
    partial class AutoCodeSql
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
            this.Sql_RichTB = new System.Windows.Forms.RichTextBox();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TableList_DDL = new System.Windows.Forms.ComboBox();
            this.Col_CkList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CodeSql_Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectALL_Btn = new System.Windows.Forms.Button();
            this.CancelALL_Btn = new System.Windows.Forms.Button();
            this.SbSql_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sql_RichTB
            // 
            this.Sql_RichTB.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Sql_RichTB.Location = new System.Drawing.Point(331, 132);
            this.Sql_RichTB.Name = "Sql_RichTB";
            this.Sql_RichTB.Size = new System.Drawing.Size(250, 400);
            this.Sql_RichTB.TabIndex = 0;
            this.Sql_RichTB.Text = "";
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReturnBtn.Location = new System.Drawing.Point(12, 12);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(87, 32);
            this.ReturnBtn.TabIndex = 18;
            this.ReturnBtn.Text = "返回主頁";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "選擇資料表：";
            // 
            // TableList_DDL
            // 
            this.TableList_DDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableList_DDL.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TableList_DDL.FormattingEnabled = true;
            this.TableList_DDL.Location = new System.Drawing.Point(113, 56);
            this.TableList_DDL.Name = "TableList_DDL";
            this.TableList_DDL.Size = new System.Drawing.Size(197, 24);
            this.TableList_DDL.TabIndex = 20;
            this.TableList_DDL.SelectedIndexChanged += new System.EventHandler(this.TableList_DDL_SelectedIndexChanged);
            // 
            // Col_CkList
            // 
            this.Col_CkList.CheckOnClick = true;
            this.Col_CkList.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Col_CkList.FormattingEnabled = true;
            this.Col_CkList.Location = new System.Drawing.Point(12, 132);
            this.Col_CkList.Name = "Col_CkList";
            this.Col_CkList.Size = new System.Drawing.Size(242, 400);
            this.Col_CkList.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "選取欄位:";
            // 
            // CodeSql_Btn
            // 
            this.CodeSql_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CodeSql_Btn.Location = new System.Drawing.Point(260, 247);
            this.CodeSql_Btn.Name = "CodeSql_Btn";
            this.CodeSql_Btn.Size = new System.Drawing.Size(65, 28);
            this.CodeSql_Btn.TabIndex = 23;
            this.CodeSql_Btn.Text = "Sql->";
            this.CodeSql_Btn.UseVisualStyleBackColor = true;
            this.CodeSql_Btn.Click += new System.EventHandler(this.CodeSql_Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(328, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "結果:";
            // 
            // SelectALL_Btn
            // 
            this.SelectALL_Btn.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SelectALL_Btn.Location = new System.Drawing.Point(201, 101);
            this.SelectALL_Btn.Name = "SelectALL_Btn";
            this.SelectALL_Btn.Size = new System.Drawing.Size(53, 25);
            this.SelectALL_Btn.TabIndex = 25;
            this.SelectALL_Btn.Text = "全選";
            this.SelectALL_Btn.UseVisualStyleBackColor = true;
            this.SelectALL_Btn.Click += new System.EventHandler(this.SelectALL_Btn_Click);
            // 
            // CancelALL_Btn
            // 
            this.CancelALL_Btn.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CancelALL_Btn.Location = new System.Drawing.Point(142, 101);
            this.CancelALL_Btn.Name = "CancelALL_Btn";
            this.CancelALL_Btn.Size = new System.Drawing.Size(53, 25);
            this.CancelALL_Btn.TabIndex = 26;
            this.CancelALL_Btn.Text = "取消";
            this.CancelALL_Btn.UseVisualStyleBackColor = true;
            this.CancelALL_Btn.Click += new System.EventHandler(this.CancelALL_Btn_Click);
            // 
            // SbSql_Btn
            // 
            this.SbSql_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SbSql_Btn.Location = new System.Drawing.Point(260, 344);
            this.SbSql_Btn.Name = "SbSql_Btn";
            this.SbSql_Btn.Size = new System.Drawing.Size(65, 28);
            this.SbSql_Btn.TabIndex = 27;
            this.SbSql_Btn.Text = "SbSql->";
            this.SbSql_Btn.UseVisualStyleBackColor = true;
            this.SbSql_Btn.Click += new System.EventHandler(this.SbSql_Btn_Click);
            // 
            // AutoCodeSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 547);
            this.Controls.Add(this.SbSql_Btn);
            this.Controls.Add(this.CancelALL_Btn);
            this.Controls.Add(this.SelectALL_Btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CodeSql_Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Col_CkList);
            this.Controls.Add(this.TableList_DDL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.Sql_RichTB);
            this.Name = "AutoCodeSql";
            this.Text = "AutoCodeInsertSql";
            this.Load += new System.EventHandler(this.AutoCodeInsertSql_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Sql_RichTB;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TableList_DDL;
        private System.Windows.Forms.CheckedListBox Col_CkList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CodeSql_Btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelectALL_Btn;
        private System.Windows.Forms.Button CancelALL_Btn;
        private System.Windows.Forms.Button SbSql_Btn;
    }
}