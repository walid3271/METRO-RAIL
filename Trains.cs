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
    public partial class Trains : Form
    {
        

        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());


        public static String tID, tName, tType, tStopage, tDescription, tTime;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From inside_train Where T_ID='" + tID + "'and Status='" + "Available" + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            int myNum = int.Parse(dt.Rows[0][0].ToString());

            //MessageBox.Show("count: " + dt.Rows[0][0].ToString());

            if (myNum > 0 && tID != "" && tName != "" && tType != "" && tStopage != "" && tDescription != "" && tTime!="")
            {
                //MessageBox.Show("I am in: " + tName);
                this.Hide();
                TrainsSeats ts = new TrainsSeats();
                ts.Show();
            }

            else if(myNum == 0)
            {
                MessageBox.Show("All seats are already booked.");
            }

            else
            {
                MessageBox.Show("Please select one.");
            }
           
        }

        public Trains()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tID = "";
            tName = "";
            tType = "";
            tStopage = "";
            tDescription = "";
            tTime = "";

            this.Hide();
            Home ho=new Home();
            ho.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Trains_Load(object sender, EventArgs e)
        {
            tID = "";
            tName = "";
            tType = "";
            tStopage = "";
            tDescription = "";
            tTime = "";

            trainScheduleGrid();

        }

        

        private void trainScheduleGrid()
        {
            con.Open();

            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM train";

            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            trainSchedule.DataSource = dt;
        }

        private void trainSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //id = Convert.ToInt32(trainSchedule.SelectedRows[0].Cells[0].Value);
            tID = trainSchedule.SelectedRows[0].Cells[0].Value.ToString();
            tName = trainSchedule.SelectedRows[0].Cells[1].Value.ToString();
            tType = trainSchedule.SelectedRows[0].Cells[2].Value.ToString();
            tStopage = trainSchedule.SelectedRows[0].Cells[3].Value.ToString();
            tDescription = trainSchedule.SelectedRows[0].Cells[4].Value.ToString();
            tTime = trainSchedule.SelectedRows[0].Cells[5].Value.ToString();

            

            /*
            label1.Text = trainSchedule.SelectedRows[0].Cells[1].Value.ToString();
            label5.Text = trainSchedule.SelectedRows[0].Cells[3].Value.ToString();
            label6.Text = trainSchedule.SelectedRows[0].Cells[4].Value.ToString();
            label4.Text = trainSchedule.SelectedRows[0].Cells[5].Value.ToString();
            */
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
