using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersLayer
{
    public class DBSetting
    {
        public string Title { get; set; }
        public ComboBoxItem IntegratedSecurity { get; set; }
        public string DataSource { get; set; }
        public string InitCatalog { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
