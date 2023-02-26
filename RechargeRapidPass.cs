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
    public partial class RechargeRapidPass : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public RechargeRapidPass()
        {
            InitializeComponent();
        }

        private void RechargeRapidPass_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From rapid_pass Where Rap_ID='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (textBox2.Text!=""  && textBox3.Text != "" && dt.Rows[0][0].ToString() == "1")
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select Rap_Account From rapid_pass Where Rap_ID=@Card_Number", con);
                cmd.Parameters.AddWithValue("@Card_Number", textBox1.Text);
                int ba = Convert.ToInt32(cmd.ExecuteScalar()),adba;
                con.Close();

                adba = Convert.ToInt32(textBox4.Text);


                con.Open();
                ad = new MySqlDataAdapter("UPDATE rapid_pass SET Rap_Account='" + (ba+adba) + "' Where Rap_ID='" + textBox1.Text + "'", con);
                dt = new DataTable();
                ad.Fill(dt);
                con.Close();

                MessageBox.Show("Account recharge successfully.");

                this.Hide();
                Home ho = new Home();
                ho.Show();
            }

            else if(dt.Rows[0][0].ToString() != "1")
            {
                MessageBox.Show("Invalid Rapid Pass.");
            }

            else 
            {
                MessageBox.Show("Insert your account information.");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From rapid_pass Where Rap_ID='" + textBox6.Text + "'AND Rap_Pass='" + textBox5.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select Rap_Account From rapid_pass Where Rap_ID=@ri AND Rap_Pass=@rp", con);
                cmd.Parameters.AddWithValue("@ri", textBox6.Text);
                cmd.Parameters.AddWithValue("@rp", textBox5.Text);
                string Balance = Convert.ToString(cmd.ExecuteScalar());
                //MessageBox.Show(""+ ck);
                con.Close();

                MessageBox.Show("Balance is "+ Balance+" Taka.");

                this.Hide();
                RechargeRapidPass rrp=new RechargeRapidPass();
                rrp.Show();
            }

            else
            {
                MessageBox.Show("Invalid Rapid ID or Password.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ho = new Home();
            ho.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
