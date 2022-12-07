using ServiceLayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCode.Extend;

namespace AutoCode
{
    public partial class AutoCodeSbSql : ExtendForm
    {
        private readonly ISbSqlService _Service;
        public AutoCodeSbSql()
        {
            _Service = new SbSqlService();
            InitializeComponent();
        }

        private void OutputBtn_Click(object sender, EventArgs e)
        {
            string[] lines = TB_input.Text.Replace('\r',' ').Split('\n');
            TB_output.Text = _Service.Output(lines);
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            ReturnIndex();
        }

        private void RecoverBtn_Click(object sender, EventArgs e)
        {
            string[] lines = TB_output.Text.Replace('\r', ' ').Split('\n');
            TB_input.Text = _Service.Recover(lines);
        }
    }
}
