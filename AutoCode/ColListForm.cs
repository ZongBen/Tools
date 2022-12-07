using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametersLayer;

namespace AutoCode
{
    public partial class ColListForm : Form
    {
        private IList<Schema> SchemaList { get; }
        public ColListForm(IList<Schema> SchemaList)
        {
            this.SchemaList = SchemaList;
            InitializeComponent();
        }

        private void ColListForm_Load(object sender, EventArgs e)
        {
            foreach(var item in SchemaList)
            {
                Col_CkList.Items.Add(item.ColumnEName);
            }
        }

        private void Confirm_Btn_Click(object sender, EventArgs e)
        {
            IList<Schema> SelectedSchemaList = new List<Schema>();
            foreach (var item in Col_CkList.CheckedItems)
            {
                SelectedSchemaList.Add(SchemaList.Where(x => x.ColumnEName == item.ToString()).FirstOrDefault());
            }
            var SchemaForm = (AutoCodeSchema)Owner;
            SchemaForm.SelectedSchemaList = SelectedSchemaList;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
