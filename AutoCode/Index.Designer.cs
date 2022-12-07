
namespace AutoCode
{
    partial class Index
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
            this.DB_Btn = new System.Windows.Forms.Button();
            this.SbSql_Btn = new System.Windows.Forms.Button();
            this.Schema_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DB_Btn
            // 
            this.DB_Btn.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DB_Btn.Location = new System.Drawing.Point(112, 45);
            this.DB_Btn.Name = "DB_Btn";
            this.DB_Btn.Size = new System.Drawing.Size(290, 63);
            this.DB_Btn.TabIndex = 0;
            this.DB_Btn.Text = "AutoCodeDB";
            this.DB_Btn.UseVisualStyleBackColor = true;
            this.DB_Btn.Click += new System.EventHandler(this.DB_Btn_Click);
            // 
            // SbSql_Btn
            // 
            this.SbSql_Btn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SbSql_Btn.Location = new System.Drawing.Point(112, 167);
            this.SbSql_Btn.Name = "SbSql_Btn";
            this.SbSql_Btn.Size = new System.Drawing.Size(290, 63);
            this.SbSql_Btn.TabIndex = 1;
            this.SbSql_Btn.Text = "AutoCodeSbSql";
            this.SbSql_Btn.UseVisualStyleBackColor = true;
            this.SbSql_Btn.Click += new System.EventHandler(this.SbSql_Btn_Click);
            // 
            // Schema_Btn
            // 
            this.Schema_Btn.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Schema_Btn.Location = new System.Drawing.Point(112, 298);
            this.Schema_Btn.Name = "Schema_Btn";
            this.Schema_Btn.Size = new System.Drawing.Size(290, 63);
            this.Schema_Btn.TabIndex = 2;
            this.Schema_Btn.Text = "AutoCodeSchema";
            this.Schema_Btn.UseVisualStyleBackColor = true;
            this.Schema_Btn.Click += new System.EventHandler(this.Schema_Btn_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 435);
            this.Controls.Add(this.Schema_Btn);
            this.Controls.Add(this.SbSql_Btn);
            this.Controls.Add(this.DB_Btn);
            this.Name = "Index";
            this.Text = "AutoCode";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DB_Btn;
        private System.Windows.Forms.Button SbSql_Btn;
        private System.Windows.Forms.Button Schema_Btn;
    }
}

