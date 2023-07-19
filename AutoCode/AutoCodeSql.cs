using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;
using ServiceLayer.Interface;
using ParametersLayer;

namespace AutoCode
{
    public partial class AutoCodeSql : Form
    {
        private List<string> TableNameList { get; }
        private string ConnectStr { get; }
        private readonly ISqlService _Service;
        private readonly ISbSqlService _SbSqlService;

        public AutoCodeSql(List<string> TableNameList, string ConnectStr)
        {
            _Service = new SqlService();
            _SbSqlService = new SbSqlService();
            this.TableNameList = TableNameList;
            this.ConnectStr = ConnectStr;
            InitializeComponent();
        }

        private void AutoCodeInsertSql_Load(object sender, EventArgs e)
        {
            TableList_DDL.Items.AddRange(TableNameList.ToArray());
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TableList_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            var col_list = _Service.GetCols(TableList_DDL.SelectedItem.ToString(), ConnectStr);
            Col_CkList.Items.Clear();
            Col_CkList.Items.AddRange(col_list.ToArray());
        }

        private void CodeSql_Btn_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach(string Item in Col_CkList.CheckedItems)
            {
                list.Add(Item);
            }

            CodeSqlResultModel result = new CodeSqlResultModel();
            if(sql_type_cb.Text == "Insert")
            {
                result = _Service.AutoCodeInsert(TableList_DDL.SelectedItem.ToString(), list);
            }
            else if(sql_type_cb.Text == "Update")
            {
                result = _Service.AutoCodeUpdate(TableList_DDL.SelectedItem.ToString(), list);
            }
            Sql_RichTB.Clear();
            Sql_RichTB.Text = result.SqlText;
        }

        private void SelectALL_Btn_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Col_CkList.Items.Count; i++)
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

        private void SbSql_Btn_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (string Item in Col_CkList.CheckedItems)
            {
                list.Add(Item);
            }
            CodeSqlResultModel result = new CodeSqlResultModel();
            if (sql_type_cb.Text == "Insert")
            {
                result = _Service.AutoCodeInsert(TableList_DDL.SelectedItem.ToString(), list);
            }
            else if (sql_type_cb.Text == "Update")
            {
                result = _Service.AutoCodeUpdate(TableList_DDL.SelectedItem.ToString(), list);
            }
            string sbsql = _SbSqlService.Output(result.SqlText.Replace('\r', ' ').Split('\n'));
            Sql_RichTB.Clear();
            Sql_RichTB.Text = sbsql + result.Params;
        }
    }
}
