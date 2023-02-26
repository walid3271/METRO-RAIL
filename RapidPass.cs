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
    public partial class RapidPass : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public RapidPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From rapid_pass Where Rap_ID='" + Card_Number.Text  + "'and Rap_Pass='" + password.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();


            if (dt.Rows[0][0].ToString() == "1")
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select Rap_Account From rapid_pass Where Rap_ID=@Card_Number", con);
                cmd.Parameters.AddWithValue("@Card_Number", Card_Number.Text);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                //MessageBox.Show(""+i);

                if (i>=50)
                {
                    con.Open();
                    ad = new MySqlDataAdapter("UPDATE rapid_pass SET Rap_Account='" + (i - 50) + "' Where Rap_ID='" + Card_Number.Text + "'", con);
                    dt = new DataTable();
                    ad.Fill(dt);
                    con.Close();
                    /*
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE rapid_pass SET Rap_Account=@transition WHERE Rap_ID=@Id";
                    */

                    con.Open();
                    ad = new MySqlDataAdapter("UPDATE inside_train SET Status='" + "Booked" + "' Where Bogie='" + TrainsSeats.tBogie + "'AND Seats='"+ TrainsSeats.tSeats +"'", con);
                    dt = new DataTable();
                    ad.Fill(dt);
                    con.Close();



                    this.Hide();
                    //con.Close();
                    PrintTikits pt = new PrintTikits();
                    pt.Show();
                }

                else
                {
                    con.Close();
                    MessageBox.Show("You don't have sufficient balance.");
                }
                
            }

            else
            {
                MessageBox.Show("Wrong Card Number or password.");
            }
        }

        private void RapidPass_Load(object sender, EventArgs e)
        {

        }
    }
}
