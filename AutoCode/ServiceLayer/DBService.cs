using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ServiceLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer;
using ParametersLayer;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;

namespace ServiceLayer
{
    public class DBService : IDBService
    {
        private string Constr { get; set; }

        private readonly IDBProvider _Provider;
        public DBService()
        {
            _Provider = new DBProvider();
        }

        public void ServerValidComboBoxInit(ComboBox Item)
        {
            Item.Items.Clear();
            Item.Items.AddRange(new ComboBoxItem[] {
                new ComboBoxItem("SQL Server 驗證", ServerValidComboBoxItemValue.SqlServer驗證),
                new ComboBoxItem("Windows 驗證", ServerValidComboBoxItemValue.Windows驗證)
            });
            Item.SelectedIndex = 0;
            Item.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void SettingsComboBoxInit(ComboBox Item)
        {
            Item.Items.Clear();
            Item.DropDownStyle = ComboBoxStyle.DropDownList;
            string SettingsPath = ConfigurationManager.AppSettings["SettingsPath"];
            if (Directory.Exists(SettingsPath))
            {
                var files = Directory.GetFiles(SettingsPath).Select(x => x.Remove(x.LastIndexOf('.')).Substring(x.LastIndexOf('\\') + 1)).ToArray();
                Item.Items.AddRange(files);
            }
        }

        public List<string> GetSqlTablesNameList(string Constr)
        {
            this.Constr = Constr;
            List<string> result = new List<string>();
            using (SqlConnection connect = new SqlConnection(Constr))
            {
                connect.Open();
                DataTable dt = connect.GetSchema("Tables");
                connect.Close();
                foreach (DataRow row in dt.Rows)
                {
                    result.Add((string)row[2]);
                }
            }
            return result.OrderBy(x => x).ToList();
        }

        public void SaveSettings(DBSetting item)
        {
            string SettingsPath = ConfigurationManager.AppSettings["SettingsPath"];
            if (!Directory.Exists(SettingsPath))
            {
                Directory.CreateDirectory(SettingsPath);
            }
            StreamWriter sw = File.CreateText(SettingsPath + $"\\{item.Title}.json");
            sw.Write(JsonConvert.SerializeObject(item, Formatting.Indented));
            sw.Flush();
            sw.Close();
        }

        public DBSetting LoadSetting(ComboBox CBB_Settings)
        {
            string SettingsPath = ConfigurationManager.AppSettings["SettingsPath"];
            string data = File.ReadAllText(SettingsPath + $"\\{CBB_Settings.SelectedItem}.json");
            var result = JsonConvert.DeserializeObject<DBSetting>(data);
            return result;
        }

        public void DelSetting(ComboBox CBB_Settings)
        {
            string SettingsPath = ConfigurationManager.AppSettings["SettingsPath"];
            File.Delete(SettingsPath + $"\\{CBB_Settings.SelectedItem}.json");
        }
    }
}
