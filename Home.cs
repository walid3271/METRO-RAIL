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
    public partial class Home : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            Trains.tID = "";
            Trains.tName = "";
            Trains.tType = "";
            Trains.tStopage = "";
            Trains.tDescription = "";
            Trains.tTime = "";
            TrainsSeats.tBogie = "";
            TrainsSeats.tSeats = "";

            if (Form1.hid == "true")//for users.
            {
                button1.Hide();//admine button.
                button10.Hide();
                button5.Hide();
                button3.Hide();
                button11.Hide();

            }

            else
            {
                button2.Hide();
                button6.Hide();
                button4.Hide();
                button7.Hide();
                button8.Hide();
                button9.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trains tr=new Trains();
            tr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            Form1.hid = "true";
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            RechargeRapidPass rrp = new RechargeRapidPass();
            rrp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTrains at=new AddTrains();
            at.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new aboutDesign().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1=new Form1();
            F1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllTikits at=new AllTikits();
            at.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllTikits at=new AllTikits();
            at.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllCustomers ac = new AllCustomers();
            ac.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
