
namespace AutoCode
{
    partial class AutoCodeSbSql
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
            this.OutputBtn = new System.Windows.Forms.Button();
            this.TB_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_output = new System.Windows.Forms.TextBox();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.RecoverBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutputBtn
            // 
            this.OutputBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OutputBtn.Location = new System.Drawing.Point(428, 595);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(218, 35);
            this.OutputBtn.TabIndex = 0;
            this.OutputBtn.Text = "產生";
            this.OutputBtn.UseVisualStyleBackColor = true;
            this.OutputBtn.Click += new System.EventHandler(this.OutputBtn_Click);
            // 
            // TB_input
            // 
            this.TB_input.Location = new System.Drawing.Point(25, 68);
            this.TB_input.Multiline = true;
            this.TB_input.Name = "TB_input";
            this.TB_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_input.Size = new System.Drawing.Size(693, 243);
            this.TB_input.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "SQL語法";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(22, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "SbSql";
            // 
            // TB_output
            // 
            this.TB_output.Location = new System.Drawing.Point(25, 346);
            this.TB_output.Multiline = true;
            this.TB_output.Name = "TB_output";
            this.TB_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_output.Size = new System.Drawing.Size(693, 243);
            this.TB_output.TabIndex = 4;
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReturnBtn.Location = new System.Drawing.Point(12, 12);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(87, 32);
            this.ReturnBtn.TabIndex = 16;
            this.ReturnBtn.Text = "返回主頁";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // RecoverBtn
            // 
            this.RecoverBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RecoverBtn.Location = new System.Drawing.Point(75, 595);
            this.RecoverBtn.Name = "RecoverBtn";
            this.RecoverBtn.Size = new System.Drawing.Size(218, 35);
            this.RecoverBtn.TabIndex = 17;
            this.RecoverBtn.Text = "還原";
            this.RecoverBtn.UseVisualStyleBackColor = true;
            this.RecoverBtn.Click += new System.EventHandler(this.RecoverBtn_Click);
            // 
            // AutoCodeSbSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 642);
            this.Controls.Add(this.RecoverBtn);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.TB_output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_input);
            this.Controls.Add(this.OutputBtn);
            this.Name = "AutoCodeSbSql";
            this.Text = "AutoCodeSbSql";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.TextBox TB_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_output;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Button RecoverBtn;
    }
}

