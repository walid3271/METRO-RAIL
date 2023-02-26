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

namespace metro_rail_management_system
{
    public partial class AllCustomers : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public AllCustomers()
        {
            InitializeComponent();
        }

        private void AllCustomers_Load(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT C_ID, Name, Gender, Age, Phone, C_Mail FROM customers";

            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            customersview.DataSource = dt;
        }

        private void tikitsview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ho=new Home();
            ho.Show();
        }
    }
}
