using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace AutoCode.Extend
{
    public class ExtendForm : Form
    {
        private bool IsClosing { get; set; } = true;

        public void ReturnIndex()
        {
            DialogResult = DialogResult.Cancel;
            IsClosing = false;
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (IsClosing)
            {
                DialogResult = DialogResult.Abort;
            }
        }
    }
}
