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
    
    public partial class loading : Form
    {
        public static int tt = Form1.g;
        public loading()
        {
            InitializeComponent();
            dj();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        Timer tmr;

        private void unlock_Shown(object sender, EventArgs e)
        {

        }
        void tmr_Tick(object sender, EventArgs e)
        {
            if(tt == 1)
            {
                this.Hide();
                tmr.Stop();
                
                Home ho = new Home();
                ho.Show();
              
                
            }
            else if (tt == 2)
            {
                this.Hide();
                tmr.Stop();
                Admin ad = new Admin();
                ad.Show();
            }
            else if (tt == 3)
            {
                this.Hide();
                tmr.Stop();
                Recovery_password recPass = new Recovery_password();
                recPass.Show();
            }
            else if (tt == 4)
            {
                this.Hide();
                tmr.Stop();
                Form2 si = new Form2();
                si.Show();
            }
        }
        public void dj()
        {
            tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
    }
}
