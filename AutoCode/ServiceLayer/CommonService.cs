using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceLayer
{
    public class CommonService : ICommonService
    {
        public Point CenterLocation(Form ChildForm, Form ParentForm)
        {
            int CenterX = ChildForm.Location.X + ChildForm.Width / 2;
            int CenterY = ChildForm.Location.Y + ChildForm.Height / 2;
            return new Point(CenterX - ParentForm.Width / 2, CenterY - ParentForm.Height / 2);
        }
    }
}
