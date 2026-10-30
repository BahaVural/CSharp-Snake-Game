using snakegame.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace snakegame
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          Form4 kolay = new Form4();
          kolay.Show();
          this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
         Form5 orta = new Form5();
         orta.Show();
         this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         Form1 zor = new Form1();
         zor.Show();
         this.Hide();
        }

     
    }
}
