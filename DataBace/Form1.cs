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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PDBC dBC = new PDBC();
            dBC.Connect();
            DataTable dataTable = dBC.Select("SELECT [ID] [Name] [Last Name] FROM [tbl-name]");
            label1.Text = "On Table :\ntbl-name ";
            dBC.DC();
            dataGridView1.DataSource = dataTable;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.frm1Obj = this;
            frm2.ShowDialog();
            ///ta
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Teal;
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightSeaGreen;
        }

    }
}
