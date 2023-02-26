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
    public partial class AllTikits : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());

        public static string ck, TikitNumber, T_ID, C_ID, T_Name, Bogie, Seats, Time, TripStart, Destination;

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ho=new Home();
            ho.Show();
        }

        public AllTikits()
        {
            InitializeComponent();
        }

        private void AllTikits_Load(object sender, EventArgs e)
        {

            if(Form1.hid== "false")//all tikits
            {
                button1.Hide();
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM tikits";

                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();
                tikitsview.DataSource = dt;
            }

            else//user tikits
            {
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM tikits WHERE C_ID=@id";
                cmd.Parameters.AddWithValue("@id", Form1.customerId);
                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();
                tikitsview.DataSource = dt;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ck = "true";
            PrintTikits pt = new PrintTikits();
            pt.Show();

        }

        private void tikitsview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TikitNumber = tikitsview.SelectedRows[0].Cells[0].Value.ToString();
            T_ID = tikitsview.SelectedRows[0].Cells[1].Value.ToString();
            C_ID = tikitsview.SelectedRows[0].Cells[2].Value.ToString();
            T_Name = tikitsview.SelectedRows[0].Cells[3].Value.ToString();
            Bogie = tikitsview.SelectedRows[0].Cells[4].Value.ToString();
            Seats = tikitsview.SelectedRows[0].Cells[5].Value.ToString();
            Time = tikitsview.SelectedRows[0].Cells[6].Value.ToString();
            TripStart = tikitsview.SelectedRows[0].Cells[7].Value.ToString();
            Destination = tikitsview.SelectedRows[0].Cells[8].Value.ToString();
        }
    }
}
