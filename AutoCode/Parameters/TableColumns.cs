using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersLayer
{
    public class TableColumns
    {
        public string Column_Name { get; set; }
        public string Data_Type { get; set; }
        public int Max_Length { get; set; }
        public string Is_Nullable { get; set; }
        public string Is_PrimaryKey { get; set; }
        public string Column_Description { get; set; }
    }
}
