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
    public partial class AddTrains : Form
    {
        
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());

        public static String ttID;
        public AddTrains()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTrains_Load(object sender, EventArgs e)
        {
            train();
        }

        private void train()
        {
            con.Open();

            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM train";

            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            addtrain.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From train Where T_ID='" + textBox1.Text +"'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() != "1" && textBox1.Text !="" && textBox2.Text !="" && textBox3.Text !="" && textBox4.Text !="" && textBox5.Text !="" && textBox6.Text !="")
            {
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO train (T_ID, T_Name, T_Type, T_Ttopage, T_Destination, T_Time) VALUES (@tID,@tName,@tType,@tTop,@tDest,@tTime)";
                cmd.Parameters.AddWithValue("@tID", textBox1.Text);
                cmd.Parameters.AddWithValue("@tName", textBox2.Text);
                cmd.Parameters.AddWithValue("@tType", textBox3.Text);
                cmd.Parameters.AddWithValue("@tTop", textBox4.Text);
                cmd.Parameters.AddWithValue("@tDest", textBox5.Text);
                cmd.Parameters.AddWithValue("@tTime", textBox6.Text);
                cmd.ExecuteNonQuery();
                con.Close();



                /*
                con.Open();
                MySqlCommand cmd = new MySqlCommand ("INSERT INTO train (T_ID, T_Name, T_Type, T_Ttopage, T_Destination, T_Time,) VALUES (@tID,@tName,@tType,@tTop,@tDest,@tTime)",con);
                cmd.Parameters.AddWithValue("@tID", textBox1.Text);
                cmd.Parameters.AddWithValue("@tName", textBox2.Text);
                cmd.Parameters.AddWithValue("@tType", textBox3.Text);
                cmd.Parameters.AddWithValue("@tTop", textBox4.Text);
                cmd.Parameters.AddWithValue("@tDest", textBox5.Text);
                cmd.Parameters.AddWithValue("@tTime", textBox6.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                */

                ttID = textBox1.Text;
                MessageBox.Show("Train add successfully.");

                
                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
                
            }

            else if( !(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""))
            {
                MessageBox.Show("Fill all the boxes.");
            }

            else
            {
                MessageBox.Show("Train alrady added.");
                /*
                ttID = textBox1.Text;
                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
                */
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From train Where T_ID='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM train WHERE T_Id=@tId";
                cmd.Parameters.AddWithValue("@tId", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM inside_train WHERE T_Id=@tId";
                cmd.Parameters.AddWithValue("@tId", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Train Delete Successfully.");

                this.Hide();
                AddTrains at = new AddTrains();
                at.Show();
            }

            else
            {
                MessageBox.Show("Please Select Train.");
            }

        }

        private void addtrain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = addtrain.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = addtrain.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = addtrain.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = addtrain.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = addtrain.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = addtrain.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From train Where T_ID='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {
                ttID = textBox1.Text;
                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
            }
            
            else
            {
                MessageBox.Show("Please Select Train.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From train Where T_ID='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {
                ttID = textBox1.Text;
                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
            }
            
            else
            {
                MessageBox.Show("Please Select Train.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ttID ="";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From train Where T_ID='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE train SET T_ID=@tId,T_Name=@tNm,T_Type=@tTy,T_Ttopage=@tSt,T_Destination=@tDst,T_Time=@tTi WHERE T_ID=@tId";
                cmd.Parameters.AddWithValue("@tId", textBox1.Text);
                cmd.Parameters.AddWithValue("@tNm", textBox2.Text);
                cmd.Parameters.AddWithValue("@tTy", textBox3.Text);
                cmd.Parameters.AddWithValue("@tSt", textBox4.Text);
                cmd.Parameters.AddWithValue("@tDst", textBox5.Text);
                cmd.Parameters.AddWithValue("@tTi", textBox6.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update successfully.");

                this.Hide();
                AddTrains at = new AddTrains();
                at.Show();
            }

            else
            {
                MessageBox.Show("Please Select Train.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select Count(*) From train Where T_ID='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {
                ttID = textBox1.Text;
                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
            }

            else
            {
                MessageBox.Show("Please Select Train.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Home ho=new Home();
            ho.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
