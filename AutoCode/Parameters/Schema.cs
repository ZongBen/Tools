using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersLayer
{
    public class Schema
    {
        public string ColumnEName { get; set; }
        public string ColumnCName { get; set; }
        public string DataType { get; set; }
        public string DataLength { get; set; }
        public string IsNullable { get; set; }
        public string IsPKey { get; set; }
        public string IsIdentity { get; set; }
        public string DefaultValue { get; set; }
    }
}
