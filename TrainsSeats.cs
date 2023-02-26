using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metro_rail_management_system
{
    public partial class TrainsSeats : Form
    {

        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());

        public static String tBogie, tSeats;
        public TrainsSeats()
        {
            InitializeComponent();
        }

        private void trainBogie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = Trains.tName;
            label5.Text = Trains.tStopage;
            label6.Text = Trains.tDescription;
            label4.Text = Trains.tTime;


            tBogie=label2.Text = trainBogie.SelectedRows[0].Cells[0].Value.ToString();
            tSeats=label3.Text = trainBogie.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void TrainsSeats_Load(object sender, EventArgs e)
        {
            trainBogieGrid();
        }

        private void trainBogieGrid()
        {
            con.Open();

            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Bogie,Seats,Status FROM inside_train WHERE T_ID=@tid";
            cmd.Parameters.AddWithValue("@tid", Trains.tID);

            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            trainBogie.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select Status From inside_train Where Bogie=@bi AND Seats=@st AND T_ID=@tid", con);
            cmd.Parameters.AddWithValue("@bi", tBogie);
            cmd.Parameters.AddWithValue("@st", tSeats);
            cmd.Parameters.AddWithValue("@tid", Trains.tID);
            string ck = Convert.ToString(cmd.ExecuteScalar());
            //MessageBox.Show(""+ ck);
            con.Close();

            if (ck== "Available")
            {
                //con.Close();
                this.Hide();
                AllTikits.ck = "false";
                RapidPass rp = new RapidPass();
                rp.Show();
            }

            else if(ck == "Booked")
            {
                MessageBox.Show("Seat already booked.");
            }
            else
            {
                MessageBox.Show("Please select one.");
            }
            
        }
    }
}
