
namespace AutoCode
{
    partial class AutoCodeSchema
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenExcel_Btn = new System.Windows.Forms.Button();
            this.ExcelFileName_LB = new System.Windows.Forms.Label();
            this.TableName_CB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SQL_RichTB = new System.Windows.Forms.RichTextBox();
            this.CreateTable_Btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadTemplate_Btn = new System.Windows.Forms.Button();
            this.AddCol_Btn = new System.Windows.Forms.Button();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.AlterCol_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenExcel_Btn
            // 
            this.OpenExcel_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OpenExcel_Btn.Location = new System.Drawing.Point(12, 60);
            this.OpenExcel_Btn.Name = "OpenExcel_Btn";
            this.OpenExcel_Btn.Size = new System.Drawing.Size(183, 43);
            this.OpenExcel_Btn.TabIndex = 0;
            this.OpenExcel_Btn.Text = "開啟Excel";
            this.OpenExcel_Btn.UseVisualStyleBackColor = true;
            this.OpenExcel_Btn.Click += new System.EventHandler(this.OpenExcel_Btn_Click);
            // 
            // ExcelFileName_LB
            // 
            this.ExcelFileName_LB.AutoSize = true;
            this.ExcelFileName_LB.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExcelFileName_LB.Location = new System.Drawing.Point(211, 73);
            this.ExcelFileName_LB.Name = "ExcelFileName_LB";
            this.ExcelFileName_LB.Size = new System.Drawing.Size(72, 16);
            this.ExcelFileName_LB.TabIndex = 1;
            this.ExcelFileName_LB.Text = "檔案名稱";
            // 
            // TableName_CB
            // 
            this.TableName_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableName_CB.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TableName_CB.FormattingEnabled = true;
            this.TableName_CB.Location = new System.Drawing.Point(119, 122);
            this.TableName_CB.Name = "TableName_CB";
            this.TableName_CB.Size = new System.Drawing.Size(203, 24);
            this.TableName_CB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "資料表名稱：";
            // 
            // SQL_RichTB
            // 
            this.SQL_RichTB.Location = new System.Drawing.Point(12, 259);
            this.SQL_RichTB.Name = "SQL_RichTB";
            this.SQL_RichTB.Size = new System.Drawing.Size(770, 315);
            this.SQL_RichTB.TabIndex = 4;
            this.SQL_RichTB.Text = "";
            // 
            // CreateTable_Btn
            // 
            this.CreateTable_Btn.Enabled = false;
            this.CreateTable_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CreateTable_Btn.Location = new System.Drawing.Point(15, 199);
            this.CreateTable_Btn.Name = "CreateTable_Btn";
            this.CreateTable_Btn.Size = new System.Drawing.Size(171, 54);
            this.CreateTable_Btn.TabIndex = 5;
            this.CreateTable_Btn.Text = "建立資料表";
            this.CreateTable_Btn.UseVisualStyleBackColor = true;
            this.CreateTable_Btn.Click += new System.EventHandler(this.CreateTable_Btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "SQL語法產生器：";
            // 
            // DownloadTemplate_Btn
            // 
            this.DownloadTemplate_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DownloadTemplate_Btn.Location = new System.Drawing.Point(664, 12);
            this.DownloadTemplate_Btn.Name = "DownloadTemplate_Btn";
            this.DownloadTemplate_Btn.Size = new System.Drawing.Size(118, 43);
            this.DownloadTemplate_Btn.TabIndex = 7;
            this.DownloadTemplate_Btn.Text = "下載範例";
            this.DownloadTemplate_Btn.UseVisualStyleBackColor = true;
            this.DownloadTemplate_Btn.Click += new System.EventHandler(this.DownloadTemplate_Btn_Click);
            // 
            // AddCol_Btn
            // 
            this.AddCol_Btn.Enabled = false;
            this.AddCol_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AddCol_Btn.Location = new System.Drawing.Point(203, 199);
            this.AddCol_Btn.Name = "AddCol_Btn";
            this.AddCol_Btn.Size = new System.Drawing.Size(171, 54);
            this.AddCol_Btn.TabIndex = 8;
            this.AddCol_Btn.Text = "新增欄位";
            this.AddCol_Btn.UseVisualStyleBackColor = true;
            this.AddCol_Btn.Click += new System.EventHandler(this.AddCol_Btn_Click);
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReturnBtn.Location = new System.Drawing.Point(12, 12);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(87, 32);
            this.ReturnBtn.TabIndex = 17;
            this.ReturnBtn.Text = "返回主頁";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // AlterCol_Btn
            // 
            this.AlterCol_Btn.Enabled = false;
            this.AlterCol_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AlterCol_Btn.Location = new System.Drawing.Point(394, 199);
            this.AlterCol_Btn.Name = "AlterCol_Btn";
            this.AlterCol_Btn.Size = new System.Drawing.Size(171, 54);
            this.AlterCol_Btn.TabIndex = 18;
            this.AlterCol_Btn.Text = "更新欄位";
            this.AlterCol_Btn.UseVisualStyleBackColor = true;
            this.AlterCol_Btn.Click += new System.EventHandler(this.AlterCol_Btn_Click);
            // 
            // AutoCodeSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 586);
            this.Controls.Add(this.AlterCol_Btn);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.AddCol_Btn);
            this.Controls.Add(this.DownloadTemplate_Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CreateTable_Btn);
            this.Controls.Add(this.SQL_RichTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TableName_CB);
            this.Controls.Add(this.ExcelFileName_LB);
            this.Controls.Add(this.OpenExcel_Btn);
            this.Name = "AutoCodeSchema";
            this.Text = "AutoCodeSchema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenExcel_Btn;
        private System.Windows.Forms.Label ExcelFileName_LB;
        private System.Windows.Forms.ComboBox TableName_CB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox SQL_RichTB;
        private System.Windows.Forms.Button CreateTable_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DownloadTemplate_Btn;
        private System.Windows.Forms.Button AddCol_Btn;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Button AlterCol_Btn;
    }
}

