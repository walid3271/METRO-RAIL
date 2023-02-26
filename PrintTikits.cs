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
    public partial class PrintTikits : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        string idd;
        public PrintTikits()
        {
            InitializeComponent();
        }

        private void PrintTikits_Load(object sender, EventArgs e)
        {

            if(AllTikits.ck == "true")
            {
                label12.Text = AllTikits.T_ID;
                label11.Text = AllTikits.T_Name;
                label10.Text = AllTikits.Bogie;
                label9.Text = AllTikits.Seats;
                label16.Text = AllTikits.C_ID;
                label15.Text = AllTikits.Time;
                label14.Text = AllTikits.TripStart;
                label13.Text = AllTikits.Destination;
            }


            else
            {
                label12.Text = Trains.tID;
                label11.Text = Trains.tName;
                label10.Text = TrainsSeats.tBogie;
                label9.Text = TrainsSeats.tSeats;
                label16.Text = Convert.ToString(Form1.customerId);
                label15.Text = Trains.tTime;
                label14.Text = Trains.tDescription;
                label13.Text = Trains.tStopage;

                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select Count(TikitNumber) From tikits", con);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                i++;
                idd = i.ToString();

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO tikits(TikitNumber, T_ID, C_ID, T_Name, Bogie, Seats, Time, TripStart, Destination) VALUES (@ID, @tid, @cid, @tName, @tbogie, @tst, @ttim, @tf, @tto)";
                cmd.Parameters.AddWithValue("@ID", idd);
                cmd.Parameters.AddWithValue("@tid", Trains.tID);
                cmd.Parameters.AddWithValue("@cid", Convert.ToString(Form1.customerId));
                cmd.Parameters.AddWithValue("@tName", Trains.tName);
                cmd.Parameters.AddWithValue("@tbogie", TrainsSeats.tBogie);
                cmd.Parameters.AddWithValue("@tst", TrainsSeats.tSeats);
                cmd.Parameters.AddWithValue("@ttim", Trains.tTime);
                cmd.Parameters.AddWithValue("@tf", Trains.tDescription);
                cmd.Parameters.AddWithValue("@tto", Trains.tStopage);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ho=new Home();
            ho.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
