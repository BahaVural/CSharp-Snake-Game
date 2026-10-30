using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snakegame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int ileri = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ileri == 0)
            {
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value++;
                    this.Opacity += 0.01;
                    
                }
            }
            else
            {
                if (progressBar1.Value > 0)
                {
                    progressBar1.Value--;
                    this.Opacity -= 0.01;
                   
                }
            }
            if (ileri == 1 && progressBar1.Value == 0)
            {
                timer1.Enabled = false;
                Form3 menu = new Form3();
                menu.Show();
                this.Hide();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ileri = 1;

            
        }
    }
}
