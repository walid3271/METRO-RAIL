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
    public partial class Admin : Form
    {
        public static int a;
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = 1;
            con.Open();

            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From admin Where A_Mail='" + mail.Text + "'and A_Pass='" + pass.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            con.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {
                a = 1;
                this.Hide();

                //con.Close();

                Home home = new Home();
                home.Show();
            }

            else
            {
                MessageBox.Show("Wrong Mail or password");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
