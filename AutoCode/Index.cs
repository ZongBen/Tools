using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace AutoCode
{
    public partial class Index : Form
    {
        public Index()
        {
            ConfigurationManager.AppSettings["SettingsPath"] = Application.StartupPath + "\\Settings";
            ConfigurationManager.AppSettings["OutputPath"] = Application.StartupPath + "\\Output";
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void DB_Btn_Click(object sender, EventArgs e)
        {
            DisplayDialog<AutoCodeDB>();
        }

        private void SbSql_Btn_Click(object sender, EventArgs e)
        {
            DisplayDialog<AutoCodeSbSql>();
        }

        private void Schema_Btn_Click(object sender, EventArgs e)
        {
            DisplayDialog<AutoCodeSchema>();
        }

        private void DisplayDialog<T>() where T : Form, new()
        {
            Hide();
            T DisplayForm = new T()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            try
            {
                var result = DisplayForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    Show();
                }
                else if (result == DialogResult.Abort)
                {
                    Close();
                }
            }
            catch(Exception ex)
            {
                Show();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
