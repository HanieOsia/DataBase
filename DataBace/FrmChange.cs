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
    public partial class FrmChange : Form
    {
        private string _TblName { get; set; }
        private string _TblCell { set; get; }
        private string _TblColVar { set; get; }
        private string _TblWhere { set; get; }
        private bool _TblIsInt { set; get; }
        private string _TblCellEmpty = "-";
        public FrmChange(string tblName, string tblCell, string tblColVar, string tblWhere, bool tblIsInt)
        {
            _TblName = tblName;
            _TblCell = tblCell;
            _TblColVar = tblColVar;
            _TblWhere = tblWhere;
            _TblIsInt = tblIsInt;
            
            InitializeComponent();
        }

        private void FrmChange_Load(object sender, EventArgs e)
        {
            label1.Text = " مقدار قبلی در " + _TblName + ":'\n'" + _TblColVar;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PDBC db = new PDBC();
            db.Connect();
            string result = "امکان پذیر نیست";
            
            if (_TblIsInt)
            {
                int flag = 0;
                if (Int32.TryParse(textBox1.Text, out flag))
                {
                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        result = db.Script($"UPDATE [{_TblName}] SET [{_TblCell}] = {_TblCellEmpty} WHERE {_TblWhere}");
                    }
                    else
                    {
                        result = db.Script($"UPDATE [{_TblName}] SET [{_TblCell}] = {flag} WHERE {_TblWhere}");
                    }

                }

            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    result = db.Script($"UPDATE [{_TblName}] SET [{_TblCell}] = N'{_TblCellEmpty}' WHERE {_TblWhere}");
                }
                else
                {
                    result = db.Script($"UPDATE [{_TblName}] SET [{_TblCell}] = N'{textBox1.Text}' WHERE {_TblWhere}");
                }
            }
        
            db.DC();
            MessageBox.Show(result);
            this.Close();
        }
    }
}
