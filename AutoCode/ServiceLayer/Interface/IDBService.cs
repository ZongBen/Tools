using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametersLayer;

namespace ServiceLayer.Interface
{
    public interface IDBService
    {
        void SettingsComboBoxInit(ComboBox Item);
        void ServerValidComboBoxInit(ComboBox Item);
        List<string> GetSqlTablesNameList(string Constr);
        void SaveSettings(DBSetting item);
        DBSetting LoadSetting(ComboBox CBB_Settings);
        void DelSetting(ComboBox CBB_Settings);
    }
}
