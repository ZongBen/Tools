using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametersLayer;
using ServiceLayer;
using ServiceLayer.Interface;

namespace AutoCode
{
    public partial class AutoCodeClass : Form
    {
        private List<string> TableNameList { get; }
        private string ConnectStr { get; }
        private readonly IClassService _Service;
        private readonly ICommonService _commonService;
        public AutoCodeClass(List<string> TableNameList, string ConnectStr)
        {
            this.TableNameList = TableNameList;
            this.ConnectStr = ConnectStr;
            _Service = new ClassService();
            _commonService = new CommonService();
            InitializeComponent();
        }

        private void ColListForm_Load(object sender, EventArgs e)
        {
            Table_CkList.Items.AddRange(TableNameList.ToArray());
        }

        private void Confirm_Btn_Click(object sender, EventArgs e)
        {
            string result;
            try
            {
                foreach (string item in Table_CkList.CheckedItems)
                {
                    _Service.AutoCode(item, Tb_FilePath.Text, ConnectStr);
                }
                _commonService.OpenFoder(Tb_FilePath.Text);
                result = "輸出完成";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            MessageBox.Show(result);
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FilePathBtn_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                Tb_FilePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
