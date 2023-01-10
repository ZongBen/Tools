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
using ParametersLayer;


namespace AutoCode
{
    public partial class AutoCodeModel : Form
    {
        private List<string> TableNameList { get; }
        private List<TableColumns> Col_List { get; set; }
        private List<TableColumns> ModelCol_List { get; set; } = new List<TableColumns>();
        private string ConnectStr { get; }
        private readonly IModelService _Service;

        public AutoCodeModel(List<string> TableNameList, string ConnectStr)
        {
            this.TableNameList = TableNameList;
            this.ConnectStr = ConnectStr;
            _Service = new ModelService();
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AutoCodeModel_Load(object sender, EventArgs e)
        {
            TableList_DDL.Items.AddRange(TableNameList.ToArray());
        }

        private void TableList_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Col_List = _Service.GetCols(TableList_DDL.SelectedItem.ToString(), ConnectStr);
            Col_CkList.Items.Clear();
            Col_CkList.Items.AddRange(Col_List.Select(x => x.Column_Name).ToArray());
            for(int i = 0; i < Col_CkList.Items.Count; i++)
            {
                if (ModelCol_CkList.Items.Contains(Col_CkList.Items[i]))
                {
                    Col_CkList.SetItemChecked(i, true);
                }
            }
        }

        private void AddCol_Btn_Click(object sender, EventArgs e)
        {
            foreach(var item in Col_CkList.CheckedItems)
            {
                if (ModelCol_CkList.Items.Contains(item))
                {
                    continue;
                }
                ModelCol_CkList.Items.Add(item);
                ModelCol_List.Add(Col_List.Where(x => x.Column_Name == item.ToString()).First());
            }
        }

        private void FilePathBtn_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FilePath_Tb.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void CodeModel_Btn_Click(object sender, EventArgs e)
        {
            _Service.AutoCode(ModelCol_List, ModelName_Tb.Text, FilePath_Tb.Text);
            MessageBox.Show("輸出完成");
        }

        private void Remove_Btn_Click(object sender, EventArgs e)
        {
            List<string> col = new List<string>();
            foreach(var item in ModelCol_CkList.CheckedItems)
            {
                col.Add(item.ToString());
            }

            foreach(var item in col)
            {
                ModelCol_CkList.Items.Remove(item);
                ModelCol_List.RemoveAll(x => x.Column_Name == item.ToString());
            }
        }

        private void SelectALL_Btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Col_CkList.Items.Count; i++)
            {
                Col_CkList.SetItemChecked(i, true);
            }
        }

        private void CancelALL_Btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Col_CkList.Items.Count; i++)
            {
                Col_CkList.SetItemChecked(i, false);
            }
        }
    }
}
