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
using System.Net;
using System.Net.Mail;

namespace metro_rail_management_system
{
    public partial class Recovery_password : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());

        string randomcode;
        public static string to;
        public Recovery_password()
        {
            InitializeComponent();
        }

        private void Recovery_password_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void re_mail_btn_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            /*




            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From customers Where C_Mail='" +re_mail.Text+ "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();

           

            if(dr.Read())
            {
                string from, pass, messagebody;
                randomcode = (dr.GetValue(6)).ToString();
                MailMessage message = new MailMessage();
                to = (re_mail.Text).ToString();
                from = "testing582406@gmail.com";
                pass = "23112id71";
                messagebody = "Your code is " + randomcode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messagebody;
                message.Subject = "Password Recovery.";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);

                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Check your Mail.");

                    this.Hide();
                    Form1 f1=new Form1();
                    f1.Show();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("ex.message");
                }
               
            }
            else
            {
                MessageBox.Show("Not match.");
            }
            */


            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From customers Where C_Mail='" + re_mail.Text + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();



            if (dr.Read())
            {

                string from, pass, messagebody;
                Random rand = new Random();
                randomcode = (rand.Next(999999)).ToString();
                MailMessage message = new MailMessage();
                to = (re_mail.Text).ToString();
                from = "testing582406@gmail.com";
                pass = "23112id71";
                messagebody = "Your reset code is " + randomcode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messagebody;
                message.Subject = "Password reseting OTP";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Check your Mail.");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("ex.message");
                }
            }

            else
            {
                MessageBox.Show("Mail not match.");
            }

            con.Close();





        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if(randomcode == textBox1.Text)
            {
                this.Hide();
                Reset_Password rp = new Reset_Password();
                rp.Show();
            }

            else
            {
                MessageBox.Show("Wrong OTP.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
