
namespace AutoCode
{
    partial class ColListForm
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
            this.Col_CkList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Confirm_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Col_CkList
            // 
            this.Col_CkList.CheckOnClick = true;
            this.Col_CkList.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Col_CkList.FormattingEnabled = true;
            this.Col_CkList.Location = new System.Drawing.Point(12, 36);
            this.Col_CkList.Name = "Col_CkList";
            this.Col_CkList.Size = new System.Drawing.Size(298, 400);
            this.Col_CkList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "選擇欄位：";
            // 
            // Confirm_Btn
            // 
            this.Confirm_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Confirm_Btn.Location = new System.Drawing.Point(173, 442);
            this.Confirm_Btn.Name = "Confirm_Btn";
            this.Confirm_Btn.Size = new System.Drawing.Size(137, 43);
            this.Confirm_Btn.TabIndex = 2;
            this.Confirm_Btn.Text = "確認";
            this.Confirm_Btn.UseVisualStyleBackColor = true;
            this.Confirm_Btn.Click += new System.EventHandler(this.Confirm_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cancel_Btn.Location = new System.Drawing.Point(12, 442);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(143, 43);
            this.Cancel_Btn.TabIndex = 3;
            this.Cancel_Btn.Text = "取消";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // ColListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 492);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Confirm_Btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Col_CkList);
            this.Name = "ColListForm";
            this.Text = "欄位清單";
            this.Load += new System.EventHandler(this.ColListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox Col_CkList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Confirm_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
    }
}