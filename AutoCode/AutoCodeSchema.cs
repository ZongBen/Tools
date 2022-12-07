using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer.Interface;
using ServiceLayer;
using Spire.Xls;
using ParametersLayer;
using AutoCode.Extend;
using System.Configuration;

namespace AutoCode
{
    public partial class AutoCodeSchema : ExtendForm
    {
        private readonly ISchemaService _Service;
        private Workbook Book { get; set; }
        public IList<Schema> SelectedSchemaList { get; set; }
        public AutoCodeSchema()
        {
            StartPosition = FormStartPosition.CenterScreen;
            _Service = new SchemaService();
            InitializeComponent();
        }

        private void OpenExcel_Btn_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog1.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                TableName_CB.Items.Clear();
                SQL_RichTB.Clear();
                ExcelFileName_LB.Text = openFileDialog1.FileName;
                Book = _Service.LoadExcel(openFileDialog1.FileName);
                if(Book.Worksheets.Count > 0)
                {
                    foreach (var sheet in Book.Worksheets)
                    {
                        TableName_CB.Items.Add(sheet.Name);
                    }
                    TableName_CB.SelectedIndex = 0;
                }
                CreateTable_Btn.Enabled = true;
                AddCol_Btn.Enabled = true;
            }
        }

        private void CreateTable_Btn_Click(object sender, EventArgs e)
        {
            var result = _Service.CreateTable(Book.Worksheets[TableName_CB.SelectedItem.ToString()]);
            SQL_RichTB.Clear();
            SQL_RichTB.Text = result;
        }

        private void DownloadTemplate_Btn_Click(object sender, EventArgs e)
        {
            string Path = ConfigurationManager.AppSettings["OutputPath"];
            string Message = _Service.ExportExcelTemplate(Path);
            if (string.IsNullOrEmpty(Message))
            {
                MessageBox.Show($"已輸出文件至{Path}");
            }
            else
            {
                MessageBox.Show(Message);
            }
        }

        private void AddCol_Btn_Click(object sender, EventArgs e)
        {
            string TableName = TableName_CB.SelectedItem.ToString();
            var SchemaList = _Service.GetSchemaList(Book.Worksheets[TableName]);
            ColListForm col_list_form = new ColListForm(SchemaList)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            var dialog = col_list_form.ShowDialog(this);
            if(dialog == DialogResult.OK)
            {
                string result = _Service.AddCol(TableName, SelectedSchemaList);
                SQL_RichTB.Clear();
                SQL_RichTB.Text = result;
            }
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            ReturnIndex();
        }

        private void AlterCol_Btn_Click(object sender, EventArgs e)
        {
            string TableName = TableName_CB.SelectedItem.ToString();
            var SchemaList = _Service.GetSchemaList(Book.Worksheets[TableName]);
            ColListForm col_list_form = new ColListForm(SchemaList)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            var dialog = col_list_form.ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
                string result = _Service.AddCol(TableName, SelectedSchemaList);
                SQL_RichTB.Clear();
                SQL_RichTB.Text = result;
            }
        }
    }
}
