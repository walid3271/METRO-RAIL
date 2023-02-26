using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//peckage//

namespace metro_rail_management_system
{
    public partial class Form1 : Form
    {
        public static int g=0, customerId;
        public static String hid;
        //public static string customerId;
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.CENTER);
            //Imran
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            g = 4;
            this.Hide();
            loading loadSignup = new loading();
            loadSignup.Show();
            */

            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From customers Where C_Mail='" + mail.Text + "'and C_Pass='" + pass.Text + "'",con);
            DataTable dt=new DataTable();
            ad.Fill(dt);

            con.Close();

            if(dt.Rows[0][0].ToString() == "1")
            {
                

                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select C_ID From customers Where C_Mail=@ml", con);
                cmd.Parameters.AddWithValue("@ml", mail.Text);
                customerId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                hid = "true";

                //g = 1;
                this.Hide();

                //loading load = new loading();
                //load.Show();
                //imran
                Home ho = new Home();
                ho.Show();
            }

            else
            {
                MessageBox.Show("Wrong Mail or password");
            }
            //con.Close();








            /*

            MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
            con.Open();

            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT C_ID,C_Pass  FROM customers";

            
            //cmd.Parameters.AddWithValue("@C_ID", mail_btn.Text);
            //cmd.Parameters.AddWithValue("@C_Pass", pass_btn.Text);
            cmd.ExecuteNonQuery();//ExecuteNonQuery to insert, update, and delete data.
            con.Close();
            MessageBox.Show("Registration complete.");
            //ResetFormData();

            */
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //g = 3;
            this.Hide();
            //loading loadingFogotPass= new loading();
            //loadingFogotPass.Show();
            //imran
            Recovery_password re=new Recovery_password();
            re.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //g = 2;
            this.Hide();
            //loading loadAdmin = new loading();
            hid = "false";
            //loadAdmin.Show();
            //imran
            Admin ad=new Admin();
            ad.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        /* connect to the database button
        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
            try
            {
                con.Open();
                MessageBox.Show("Connection Successful.");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Failed.");
            }
        }
        */
    }
}
