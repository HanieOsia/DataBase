using DataBaseConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBace
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        public Form1 frm1Obj { get; set; }

        private void frmSelectLoad(object sender, EventArgs e)
        {
            ComboBoxObject cbo = new ComboBoxObject();
            cbo.Text = "جایگاه های کاری";
            cbo.Value = "tblJob";
            ComboBoxObject cbo2 = new ComboBoxObject();
            cbo2.Text = "کاربر ها";
            cbo2.Value = "tbl-name";
            comboBox1.Items.Add(cbo);
            comboBox1.Items.Add(cbo2);
            comboBox1.SelectedIndex = 0;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PDBC dBC = new PDBC();
            dBC.Connect();
            DataTable dataTable = dBC.Select($"SELECT * FROM{((ComboBoxObject)(comboBox1.SelectedItem)).Value}");
            dBC.DC();
            frm1Obj.dataGridView1.DataSource = dataTable;
            this.Hide();
        }
    }
}
