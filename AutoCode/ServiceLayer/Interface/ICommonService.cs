using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametersLayer;

namespace ServiceLayer.Interface
{
    public interface ICommonService
    {
        Point CenterLocation(Form ChildForm, Form ParentForm);
        string CodeClass(string ClassName, List<TableColumns> model);
    }
}
