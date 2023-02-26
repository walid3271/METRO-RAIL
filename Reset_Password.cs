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
    public partial class Reset_Password : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        string username = Recovery_password.to;
        public Reset_Password()
        {
            InitializeComponent();
        }

        private void Reset_Password_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                //MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE customers SET C_Pass = '" + textBox1.Text + "'WHERE C_Mail ='" + username + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password reset successfully.");

                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }

            else
            {
                MessageBox.Show("The password was not same.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
