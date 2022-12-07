using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersLayer
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public ServerValidComboBoxItemValue Value { get; set; }

        public ComboBoxItem(string Text, ServerValidComboBoxItemValue Value)
        {
            this.Text = Text;
            this.Value = Value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public enum ServerValidComboBoxItemValue
    {
        SqlServer驗證,
        Windows驗證
    }
}
