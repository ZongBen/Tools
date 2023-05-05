
namespace AutoCode
{
    partial class AutoCodeDB
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
            this.Tb_ServerName = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Tb_UserID = new System.Windows.Forms.TextBox();
            this.Tb_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tb_DataBaseName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.CBB_ServerValid = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CBB_Settings = new System.Windows.Forms.ComboBox();
            this.SaveSettingBtn = new System.Windows.Forms.Button();
            this.DelSettingBtn = new System.Windows.Forms.Button();
            this.Class_Btn = new System.Windows.Forms.Button();
            this.InsertSql_Btn = new System.Windows.Forms.Button();
            this.Model_Btn = new System.Windows.Forms.Button();
            this.Constr_Lb = new System.Windows.Forms.Label();
            this.Constr_Tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Tb_ServerName
            // 
            this.Tb_ServerName.Location = new System.Drawing.Point(12, 152);
            this.Tb_ServerName.Name = "Tb_ServerName";
            this.Tb_ServerName.Size = new System.Drawing.Size(204, 22);
            this.Tb_ServerName.TabIndex = 0;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ConnectBtn.Location = new System.Drawing.Point(78, 324);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(319, 32);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "連線";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(8, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "伺服器名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(8, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "帳號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(264, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "密碼";
            // 
            // Tb_UserID
            // 
            this.Tb_UserID.Location = new System.Drawing.Point(12, 212);
            this.Tb_UserID.Name = "Tb_UserID";
            this.Tb_UserID.Size = new System.Drawing.Size(204, 22);
            this.Tb_UserID.TabIndex = 7;
            // 
            // Tb_Password
            // 
            this.Tb_Password.Location = new System.Drawing.Point(268, 212);
            this.Tb_Password.Name = "Tb_Password";
            this.Tb_Password.Size = new System.Drawing.Size(204, 22);
            this.Tb_Password.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(264, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "資料庫名稱";
            // 
            // Tb_DataBaseName
            // 
            this.Tb_DataBaseName.Location = new System.Drawing.Point(268, 152);
            this.Tb_DataBaseName.Name = "Tb_DataBaseName";
            this.Tb_DataBaseName.Size = new System.Drawing.Size(204, 22);
            this.Tb_DataBaseName.TabIndex = 10;
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReturnBtn.Location = new System.Drawing.Point(12, 12);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(87, 32);
            this.ReturnBtn.TabIndex = 15;
            this.ReturnBtn.Text = "返回主頁";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // CBB_ServerValid
            // 
            this.CBB_ServerValid.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CBB_ServerValid.FormattingEnabled = true;
            this.CBB_ServerValid.Location = new System.Drawing.Point(268, 84);
            this.CBB_ServerValid.Name = "CBB_ServerValid";
            this.CBB_ServerValid.Size = new System.Drawing.Size(204, 24);
            this.CBB_ServerValid.TabIndex = 16;
            this.CBB_ServerValid.SelectedIndexChanged += new System.EventHandler(this.ServerValidComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(264, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "驗證方式";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(8, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "選取設定";
            // 
            // CBB_Settings
            // 
            this.CBB_Settings.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CBB_Settings.FormattingEnabled = true;
            this.CBB_Settings.Location = new System.Drawing.Point(12, 84);
            this.CBB_Settings.Name = "CBB_Settings";
            this.CBB_Settings.Size = new System.Drawing.Size(204, 24);
            this.CBB_Settings.TabIndex = 19;
            this.CBB_Settings.SelectedIndexChanged += new System.EventHandler(this.CBB_Settings_SelectedIndexChanged);
            // 
            // SaveSettingBtn
            // 
            this.SaveSettingBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SaveSettingBtn.Location = new System.Drawing.Point(292, 12);
            this.SaveSettingBtn.Name = "SaveSettingBtn";
            this.SaveSettingBtn.Size = new System.Drawing.Size(87, 32);
            this.SaveSettingBtn.TabIndex = 20;
            this.SaveSettingBtn.Text = "儲存設定";
            this.SaveSettingBtn.UseVisualStyleBackColor = true;
            this.SaveSettingBtn.Click += new System.EventHandler(this.SaveSettingBtn_Click);
            // 
            // DelSettingBtn
            // 
            this.DelSettingBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DelSettingBtn.Location = new System.Drawing.Point(385, 12);
            this.DelSettingBtn.Name = "DelSettingBtn";
            this.DelSettingBtn.Size = new System.Drawing.Size(87, 32);
            this.DelSettingBtn.TabIndex = 21;
            this.DelSettingBtn.Text = "刪除設定";
            this.DelSettingBtn.UseVisualStyleBackColor = true;
            this.DelSettingBtn.Click += new System.EventHandler(this.DelSettingBtn_Click);
            // 
            // Class_Btn
            // 
            this.Class_Btn.Enabled = false;
            this.Class_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Class_Btn.Location = new System.Drawing.Point(10, 362);
            this.Class_Btn.Name = "Class_Btn";
            this.Class_Btn.Size = new System.Drawing.Size(132, 50);
            this.Class_Btn.TabIndex = 22;
            this.Class_Btn.Text = "產生類別";
            this.Class_Btn.UseVisualStyleBackColor = true;
            this.Class_Btn.Click += new System.EventHandler(this.Class_Btn_Click);
            // 
            // InsertSql_Btn
            // 
            this.InsertSql_Btn.Enabled = false;
            this.InsertSql_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.InsertSql_Btn.Location = new System.Drawing.Point(338, 362);
            this.InsertSql_Btn.Name = "InsertSql_Btn";
            this.InsertSql_Btn.Size = new System.Drawing.Size(132, 50);
            this.InsertSql_Btn.TabIndex = 23;
            this.InsertSql_Btn.Text = "產生InsertSql";
            this.InsertSql_Btn.UseVisualStyleBackColor = true;
            this.InsertSql_Btn.Click += new System.EventHandler(this.InsertSql_Btn_Click);
            // 
            // Model_Btn
            // 
            this.Model_Btn.Enabled = false;
            this.Model_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Model_Btn.Location = new System.Drawing.Point(169, 362);
            this.Model_Btn.Name = "Model_Btn";
            this.Model_Btn.Size = new System.Drawing.Size(132, 50);
            this.Model_Btn.TabIndex = 24;
            this.Model_Btn.Text = "產生Model";
            this.Model_Btn.UseVisualStyleBackColor = true;
            this.Model_Btn.Click += new System.EventHandler(this.Model_Btn_Click);
            // 
            // Constr_Lb
            // 
            this.Constr_Lb.AutoSize = true;
            this.Constr_Lb.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Constr_Lb.Location = new System.Drawing.Point(12, 247);
            this.Constr_Lb.Name = "Constr_Lb";
            this.Constr_Lb.Size = new System.Drawing.Size(94, 21);
            this.Constr_Lb.TabIndex = 25;
            this.Constr_Lb.Text = "連接字串";
            // 
            // Constr_Tb
            // 
            this.Constr_Tb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Constr_Tb.Location = new System.Drawing.Point(16, 271);
            this.Constr_Tb.Name = "Constr_Tb";
            this.Constr_Tb.Size = new System.Drawing.Size(456, 27);
            this.Constr_Tb.TabIndex = 26;
            // 
            // AutoCodeDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 421);
            this.Controls.Add(this.Constr_Tb);
            this.Controls.Add(this.Constr_Lb);
            this.Controls.Add(this.Model_Btn);
            this.Controls.Add(this.InsertSql_Btn);
            this.Controls.Add(this.Class_Btn);
            this.Controls.Add(this.DelSettingBtn);
            this.Controls.Add(this.SaveSettingBtn);
            this.Controls.Add(this.CBB_Settings);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CBB_ServerValid);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.Tb_DataBaseName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tb_Password);
            this.Controls.Add(this.Tb_UserID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.Tb_ServerName);
            this.Name = "AutoCodeDB";
            this.Text = "AutoCodeDB";
            this.Load += new System.EventHandler(this.AutoCodeClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tb_ServerName;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tb_UserID;
        private System.Windows.Forms.TextBox Tb_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tb_DataBaseName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.ComboBox CBB_ServerValid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBB_Settings;
        private System.Windows.Forms.Button SaveSettingBtn;
        private System.Windows.Forms.Button DelSettingBtn;
        private System.Windows.Forms.Button Class_Btn;
        private System.Windows.Forms.Button InsertSql_Btn;
        private System.Windows.Forms.Button Model_Btn;
        private System.Windows.Forms.Label Constr_Lb;
        private System.Windows.Forms.TextBox Constr_Tb;
    }
}

