using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FormRasort
{
    public partial class Form1 : Form
    {
        int enul;
        
        public string CmdText = "SELECT* FROM [bd_rassort]";
        public string CmdText2 = "SELECT* FROM [bd_rassort] WHERE (V51>V52) " ;
        public string ConnText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Bks\\BD_rassort\\BD_Rassort.accdb";
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter dRassort = new OleDbDataAdapter(CmdText, ConnText);
            DataSet ds = new DataSet();
            dRassort.Fill(ds,"[bd_rassort]");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;

            OleDbDataAdapter dRaw = new OleDbDataAdapter(CmdText2, ConnText);
            DataSet ds1 = new DataSet();
            dRaw.Fill(ds1, "[bd_rassort]");
            dataGridView2.DataSource = ds1.Tables[0].DefaultView;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CellNPL;
            string Celltime;
            string CellID;
            List<string> NullCell = new List<string>(); 
            enul = 0;
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount-1; j++)
                {
                    //if (dataGridView1.CurrentCell.Value ==null || dataGridView1.CurrentCell.Value == DBNull.Value 
                    //    || string.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[j].Value.ToString())
                    //    || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[j].Value.ToString()))
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString()==null||
                        dataGridView1.Rows[i].Cells[j].Value==DBNull.Value||
                        String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[j].Value.ToString()))
                    {
                        
                        CellID= dataGridView1.Rows[i].Cells[0].Value.ToString();
                        CellNPL = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        Celltime = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        string celloll = $"{CellID}-----{CellNPL}-----{Celltime}";
                        NullCell.AddRange(new[] {celloll});
                        enul++;
                    }
                     
                }
               
            }
            List<string> NulCellDecime = new List<string>();

            foreach (var item in NullCell.Distinct())
            {
                MessageBox.Show($"Значение  {item}");
            }
            MessageBox.Show("NUll=" + enul);
        }

    }
}
