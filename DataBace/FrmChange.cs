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
        private bool _TblType { set; get; }
        public FrmChange(string tblName, string tblCell, string tblColVar, string tblWhere, bool tblType)
        {
            _TblName = tblName;
            _TblCell = tblCell;
            _TblColVar =tblColVar;
            _TblWhere = tblWhere;
            _TblType = tblType;
            InitializeComponent();
        }

        private void FrmChange_Load(object sender, EventArgs e)
        {
            label1.Text = " مقدار قبلی در    " + _TblName + ":" + _TblColVar;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PDBC db = new PDBC();
            db.Connect();
            string result = "امکان پذیر نیست";
            if (_TblType)
            {
                int flag = 0;
                if (Int32.TryParse(textBox1.Text, out flag))
                    result = db.Script($"UPDATE [{_TblName}] SET [{_TblCell}] = {flag} WHERE {_TblWhere}");
            }
            else
            {
                result = db.Script($"UPDATE [{_TblName}] SET [{_TblCell}] = N'{textBox1.Text}' WHERE {_TblWhere}");
            }
            db.DC();
            MessageBox.Show(result);
            this.Close();
        }
    }
}
