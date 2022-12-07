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
using AutoCode.Extend;

namespace AutoCode
{
    public partial class AutoCodeDB : ExtendForm
    {
        private readonly IDBService _Service;
        private string ConnectStr { get; set; }
        private List<string> TableNameList { get; set; }

        public AutoCodeDB()
        {
            _Service = new DBService();
            InitializeComponent();
        }

        private void AutoCodeClass_Load(object sender, EventArgs e)
        {
            _Service.ServerValidComboBoxInit(CBB_ServerValid);
            _Service.SettingsComboBoxInit(CBB_Settings);
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            string ConnectStr = string.Empty;
            var Item = CBB_ServerValid.SelectedItem as ComboBoxItem;
            switch (Item.Value)
            {
                case ServerValidComboBoxItemValue.SqlServer驗證:
                    ConnectStr = $"Data Source={Tb_ServerName.Text};Initial Catalog={Tb_DataBaseName.Text};User ID={Tb_UserID.Text};Password={Tb_Password.Text};";
                    break;
                case ServerValidComboBoxItemValue.Windows驗證:
                    ConnectStr = $"Data Source={Tb_ServerName.Text};Initial Catalog={Tb_DataBaseName.Text};Integrated Security=true";
                    break;
            }
            TableNameList = _Service.GetSqlTablesNameList(ConnectStr);
            this.ConnectStr = ConnectStr;
            Class_Btn.Enabled = true;
            InsertSql_Btn.Enabled = true;
            MessageBox.Show("連線成功");
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            ReturnIndex();
        }

        private void ServerValidComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Item = CBB_ServerValid.SelectedItem as ComboBoxItem;
            switch (Item.Value)
            {
                case ServerValidComboBoxItemValue.SqlServer驗證:
                    Tb_UserID.Enabled = true;
                    Tb_Password.Enabled = true;
                    break;
                case ServerValidComboBoxItemValue.Windows驗證:
                    Tb_UserID.Text = string.Empty;
                    Tb_Password.Text = string.Empty;
                    Tb_UserID.Enabled = false;
                    Tb_Password.Enabled = false;
                    break;
            }
        }

        private void SaveSettingBtn_Click(object sender, EventArgs e)
        {
            DBSetting item = new DBSetting
            {
                DataSource = Tb_ServerName.Text,
                InitCatalog = Tb_DataBaseName.Text,
                IntegratedSecurity = (ComboBoxItem)CBB_ServerValid.SelectedItem,
                UserID = Tb_UserID.Text,
                Password = Tb_Password.Text
            };
            _Service.SaveSettings(item);
            _Service.SettingsComboBoxInit(CBB_Settings);
            MessageBox.Show("已儲存設定");
        }

        private void CBB_Settings_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = _Service.LoadSetting(CBB_Settings);
            Tb_ServerName.Text = item.DataSource;
            Tb_DataBaseName.Text = item.InitCatalog;
            CBB_ServerValid.SelectedIndex = CBB_ServerValid.FindStringExact(item.IntegratedSecurity.Text);
            Tb_UserID.Text = item.UserID;
            Tb_Password.Text = item.Password;
        }

        private void DelSettingBtn_Click(object sender, EventArgs e)
        {
            _Service.DelSetting(CBB_Settings);
            _Service.SettingsComboBoxInit(CBB_Settings);
            MessageBox.Show("已刪除設定");
        }

        private void Class_Btn_Click(object sender, EventArgs e)
        {
            AutoCodeClass ClassForm = new AutoCodeClass(TableNameList, ConnectStr)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            ClassForm.ShowDialog(this);
        }

        private void InsertSql_Btn_Click(object sender, EventArgs e)
        {
            AutoCodeSql ClassForm = new AutoCodeSql(TableNameList, ConnectStr, new InsertSqlService())
            {
                StartPosition = FormStartPosition.CenterParent
            };
            ClassForm.ShowDialog(this);
        }
    }
}
