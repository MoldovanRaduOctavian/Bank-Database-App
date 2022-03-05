using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ProiectBRC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Doriti sa iesiti din cont?", "Mesaj", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Form1 frm = new Form1();
                    frm.Show();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                MySqlConnection sqc = new MySqlConnection();
                sqc.ConnectionString = "server=localhost;user=root;database=bancarproject;port=3306;password=root";

                sqc.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM client", sqc);
                MySqlDataReader read = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Columns.Add("Id Client");
                dt.Columns.Add("CNP");
                dt.Columns.Add("Data nasterii");
                dt.Columns.Add("Sursa venit");
                dt.Columns.Add("Tranzactii online");
                dt.Columns.Add("Numar conturi");

                while (read.Read())
                {
                    dt.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5]);
                }
                read.Close();
                sqc.Close();

                dataGridView2.DataSource = dt;
            }
        }
    }
}
