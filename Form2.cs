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
    public partial class Form2 : Form
    {
        public string gender ="";
        public int ckPhone = 0,ckAge=0;

        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public object ID { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            generateAutoId();
            
        }

        private void generateAutoId()
        {
            
            //MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select Count(C_ID) From customers",con);
            int i= Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            id.Text=i.ToString();

            name.Focus();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
       public string EmailDomainVerifierClassical(string s)
        {
            string ss;
            ss=s.Substring(s.IndexOf("@"));
            switch(ss)
            {
                case "@gmail.com":
                    return "1";
                default:
                    return "0";

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            int numLen = (pho.Text).Length;
            int ageLen = (age.Text).Length;
            ckPhone=1;
            ckAge=1;

            string phone = pho.Text.ToString();
            string agee = age.Text.ToString();

            for (int i = 0; i < numLen; i++)
            {
                if (!Char.IsDigit(phone[i]))
                {
                    ckPhone = 0;
                    //MessageBox.Show(""+ck);
                    break;
                }
            }

            for (int j = 0; j < ageLen; j++)
            {
                if (!Char.IsDigit(agee[j]))
                {
                    ckAge = 0;
                    break;
                }
            }


            if (!(name.Text=="" || gender == "" || age.Text.ToString()=="" || pho.Text.ToString()=="" || mail.Text=="" || pass.Text==""))
            {

                //MessageBox.Show("Age: "+ ageLen);
                //MessageBox.Show("Num: "+ numLen);


                string s1, s2;
                int s3;
                s1 = mail.Text.ToString();
                s2 = "@gmail.com";
                s3 = s1.IndexOf(s2);

                //MessageBox.Show(""+s3);

                if ((ckPhone == 1 && ckAge == 1) &&  s3 >= 0 && (numLen < 12 && numLen > 8) && ageLen < 3)
                {
                    string ck = EmailDomainVerifierClassical(mail.Text);
                    if (ck == "1")
                    {
                        this.Hide();

                        //MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting()); 
                        con.Open();

                        MySqlCommand cmd;
                        cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT INTO customers(C_ID, Name, Gender, Age, Phone, C_Mail, C_Pass) VALUES (@ID, @Name, @Gender, @Age, @Phone, @Mail, @Pass)";
                        cmd.Parameters.AddWithValue("@ID", id.Text);
                        cmd.Parameters.AddWithValue("@Name", name.Text);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Age", age.Text);
                        cmd.Parameters.AddWithValue("@Phone", pho.Text);
                        cmd.Parameters.AddWithValue("@Mail", mail.Text);
                        cmd.Parameters.AddWithValue("@Pass", pass.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Registration complete.");
                        ResetFormData();

                        Form1 f1 = new Form1();
                        f1.Show();
                    }

                    else
                    {
                        MessageBox.Show("Invalid Mail.");
                    }

                }

                else if (ckAge == 0)
                {
                    MessageBox.Show("Invalid Age.");
                }

                else if (ckPhone == 0)
                {
                    MessageBox.Show("Invalid Number.");
                }

                else if (ageLen >= 3)
                {
                    MessageBox.Show("Age must be 14 to 99.");
                }

                else if(numLen >= 12 || numLen <= 8)
                {
                    MessageBox.Show("Numbers must be 9 to 11.");
                }

                else
                {
                    MessageBox.Show("Invalid Mail.");
                }
            }

            else
            {
                MessageBox.Show("Fill all the box.");
            }


            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetFormData();
        }

        private void ResetFormData()
        {
            name.Clear();
            //gen.Clear();
            meal.Checked=false;
            femeal.Checked=false;
            gender = "";
            age.Clear();
            pho.Clear();
            mail.Clear();
            pass.Clear();

            name.Focus();

            //MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select Count(C_ID) From customers", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            id.Text = i.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void pho_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
