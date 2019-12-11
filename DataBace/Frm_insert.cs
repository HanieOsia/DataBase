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
    public partial class Frm_insert : MetroFramework.Forms.MetroForm
    {

        public string _TableName { get; set; }

        public Frm_insert(string tableName)
        {
            _TableName = tableName;
            InitializeComponent();
        }
        PDBC _db;
        private void Frm_insert_Load(object sender, EventArgs e)
        {
            txt_insert.Text = _TableName;
            DataTable dataTable_addData = new DataTable();
            _db = new PDBC();
            _db.Connect();
            using (DataTable dataTable = _db.Select("SELECT  [ID]'آیدی',[Name]'نام',[LastName]'نام خانوادگی' FROM [Honarjuyan].[dbo].[tblName1]"))
            {
                dgv_name.DataSource = dataTable;
            }
            using (DataTable dataTable = _db.Select($"SELECT * From [{_TableName}]"))
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (dataTable.Columns[i].ColumnName != "ID")
                        dataTable_addData.Columns.Add(dataTable.Columns[i].ColumnName, typeof(System.String));
                }
                dgv_jop.DataSource = dataTable_addData;

            }
            _db.DC();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<string> Query = new List<string>();
            for (int i = 0; i < dgv_jop.Rows.Count-1; i++)
            {
                string QueryStructure = "INSERT INTO[TableName]([ValsHeader]) VALUES([Values])";
                string Headers = "";
                string vals = "";
                for (int j = 0; j < dgv_jop.Columns.Count; j++)
                {
                    Headers += dgv_jop.Columns[j].Name + ",";
                    if (dgv_jop.Columns[j].HeaderText.ToString().ToUpper().Contains("ID"))
                    {
                        vals += dgv_jop.Rows[i].Cells[j].Value.ToString() + ",";
                    }
                    else
                    {
                        vals += "N'" + dgv_jop.Rows[i].Cells[j].Value.ToString() + "',";
                    }
                }
                vals = vals.TrimEnd(',');
                Headers = Headers.TrimEnd(',');
                Query.Add(QueryStructure.Replace("TableName", _TableName).Replace("[ValsHeader]", Headers).Replace("[Values]", vals));
            }
            _db.Connect();
            string result = "";
            for (int i = 0; i < Query.Count; i++)
            {
                result += "," + _db.Script(Query[i]);
            }
            _db.DC();
            MessageBox.Show(result);

        }
    }
}
