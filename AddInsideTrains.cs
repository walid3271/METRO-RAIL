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
    public partial class AddInsideTrains : Form
    {
        MySqlConnection con = new MySqlConnection(Connect_to_database.Connecting());
        public AddInsideTrains()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO inside_train(Bogie, Seats, T_ID, Status) VALUES (@bog,@st,@tID,@sta)";
                cmd.Parameters.AddWithValue("@bog", textBox1.Text);
                cmd.Parameters.AddWithValue("@st", textBox2.Text);
                cmd.Parameters.AddWithValue("@tID", AddTrains.ttID);
                cmd.Parameters.AddWithValue("@sta", "Available");
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("successful.");

                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
            }
            else
            {
                MessageBox.Show("Please Select Bogie.");
            }

        }

        private void AddInsideTrains_Load(object sender, EventArgs e)
        {
            button2.Hide();
            inside();
        }

        private void inside()
        {
            con.Open();

            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM inside_train WHERE T_ID=@tid";
            cmd.Parameters.AddWithValue("@tid", AddTrains.ttID);

            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            addinside.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM inside_train WHERE T_Id=@tId AND Bogie=@bi";
                cmd.Parameters.AddWithValue("@tId", AddTrains.ttID);
                cmd.Parameters.AddWithValue("@bi", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
            }

            else
            {
                MessageBox.Show("Please Select Bogie.");
            }

        }

        private void addinside_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = addinside.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = addinside.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE inside_train SET Bogie=@bi,Seats=@st WHERE T_ID=@tId";
                cmd.Parameters.AddWithValue("@bi", textBox1.Text);
                cmd.Parameters.AddWithValue("@st", textBox2.Text);
                cmd.Parameters.AddWithValue("@tId", AddTrains.ttID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update successfully.");

                this.Hide();
                AddInsideTrains ait = new AddInsideTrains();
                ait.Show();
            }

            else
            {
                MessageBox.Show("Please Select Bogie.");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTrains at = new AddTrains();
            at.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ho = new Home();
            ho.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
