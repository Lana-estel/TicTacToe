using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nolik8
{
    public partial class Form1 : Form
    {
        
        public Form2 form2; 
        public Form1()
        {
            form2=new Form2(this);
            
            InitializeComponent();
            this.SetDesktopLocation(10,10);
            label1.Text = "Я хочу сыграть с тобой в одну игру...";
   

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Dop.Role = 0;
            form2.Close();
            form2 = new Form2(this);
            
            form2.Show();
            form2.SetDesktopLocation(10, 10);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            Dop.Role=1;
            form2.Close();
            form2 = new Form2(this);
           
            form2.Show();
            form2.SetDesktopLocation(10, 10);
            this.Hide();
        }
    }
}
