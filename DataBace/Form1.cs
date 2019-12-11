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
        public string TblName { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Teal;
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightSeaGreen;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            PDBC dBC = new PDBC();
            dBC.Connect();
            TblName = "tblName1";
            DataTable dataTable = dBC.Select("SELECT [ID],[Name],[LastName] FROM [tblName1]");
            dBC.DC();
            label1.Text = "On Table :\ntblName1 ";
            dataGridView1.DataSource = dataTable;
        }

        private void Btn_select(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.frm1Obj = this;
            frm2.ShowDialog();
        }

        private void Btn_insert(object sender, EventArgs e)
        {
            Frm_insert frm_insert = new Frm_insert(TblName);
            frm_insert.ShowDialog();
        }

        private void BtnChang_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int j = e.ColumnIndex;


            FrmChange frmChange;
            
            if (dataGridView1.Columns[j].HeaderText.ToString().ToUpper().Contains("ID"))
            {
                if (dataGridView1.Columns[j].HeaderText.ToString().ToUpper()!="ID")
                {
                    frmChange = new FrmChange(TblName, dataGridView1.Columns[j].HeaderText, dataGridView1.Rows[i].Cells[j].Value.ToString(),
                       $"id ={dataGridView1.Rows[i].Cells[0].Value.ToString()}", true);
                    frmChange.ShowDialog();
                }

            }
            else
            {
                frmChange = new FrmChange(TblName, dataGridView1.Columns[j].HeaderText, dataGridView1.Rows[i].Cells[j].Value.ToString(),
                    $"id ={dataGridView1.Rows[i].Cells[0].Value.ToString()}", false);
                frmChange.ShowDialog();
            }

            PDBC dBC = new PDBC();
            dBC.Connect();
            DataTable dataTable = dBC.Select($"Select * From {TblName}");
            dBC.DC();
            dataGridView1.DataSource = dataTable;

        }
    }
}
