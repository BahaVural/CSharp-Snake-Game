using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snakegame
{
    public partial class Form1 : Form
    {
        List<Button> yilan = new List<Button>();
        public int hareket = 10;
        public string yon = "Sag";
        Random x = new Random();
        Button yem = new Button();
        int sayac = 0;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += kontrol;
            

        }
        private void kontrol(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    if (yon != "Asagi") 
                        yon = "Yukari";
                    break;

                case Keys.S:
                    if (yon != "Yukari")
                        yon = "Asagi";
                    break;

                case Keys.A:
                    if (yon != "Sag")
                        yon = "Sol";
                    break;

                case Keys.D:
                    if (yon != "Sol")
                        yon = "Sag";
                    break;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button yilanBasi = yilanolustur(50, 50);
            yilanBasi.FlatStyle = FlatStyle.Flat;
            yilanBasi.Text = "";
            yilan.Add(yilanBasi);
            yemolustur();
            timer2.Start();
        }
        private Button yilanolustur(int x ,int y)
        {
            Button parca = new Button(); 
            parca.Size = new Size(50, 50);
            parca.FlatStyle = FlatStyle.Flat;
            parca.FlatAppearance.BorderSize = 0;
            parca.Location = new Point(x, y);
            parca.BackColor = Color.DarkGreen;
            this.Controls.Add(parca);
            return parca;
        }

        private void yilanbuyut()
        {
            Point sonParcaKonum = yilan[yilan.Count - 1].Location;
            Button yeniParca = yilanolustur(sonParcaKonum.X, sonParcaKonum.Y);
            yilan.Add(yeniParca); 
        }
        private void yilanhareketi()
        {
            Point eskiKonum = yilan[0].Location;
            switch (yon)
            {
                case "Yukari":
                    yilan[0].Top -= hareket;
                    break;
                case "Asagi":
                    yilan[0].Top += hareket;
                    break;
                case "Sol":
                    yilan[0].Left -= hareket;
                    break;
                case "Sag":
                    yilan[0].Left += hareket;
                    break;
            }
            for (int i = 1; i < yilan.Count; i++)
            {
                Point tempKonum = yilan[i].Location;
                yilan[i].Location = eskiKonum;
                eskiKonum = tempKonum;
            }
            if (yilan[0].Left > this.Width)
            {
                yilan[0].Left = -yilan[0].Width;
            }
            if (yilan[0].Top > this.Height)
            {
                yilan[0].Top = -yilan[0].Height;
            }
            if (yilan[0].Left < -yilan[0].Width)
            {
                yilan[0].Left = this.Width;
            }
            if (yilan[0].Top < -yilan[0].Height)
            {
                yilan[0].Top = this.Height;
            }


        }
        private void yilanyem()
        {
            if (yilan[0].Bounds.IntersectsWith(yem.Bounds))
            {
                sayac++;
                label1.Text = "Skor:" + sayac;
                yilanbuyut();
                yemolustur();
            }
        }

        private void yemolustur()
        {
            int a = x.Next(0, this.ClientSize.Width - 50); 
            int b = x.Next(0, this.ClientSize.Height - 50);
            yem.Location = new Point(a,b);
            yem.Size = new Size(50,50);
            yem.BackColor = Color.Red;
            yem.FlatStyle = FlatStyle.Flat;
            yem.BackColor = Color.Transparent;
            yem.Text = "";
            yem.BackgroundImageLayout = ImageLayout.Stretch;
            yem.BackgroundImage = Properties.Resources.yem;

            yem.FlatAppearance.BorderSize = 0;  
            this.Controls.Add(yem);
        }
        private void carpisma()
        {
            for (int i = 2; i < yilan.Count; i++)
            {
                if (yilan[0].Location == yilan[i].Location)
                {
                    MessageBox.Show("Kaybettiniz Skor:"+sayac);
                    Form3 menu = new Form3();
                    menu.Show();
                    this.Hide();
                    
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            yilanhareketi();
            yilanyem();
            carpisma();
        }
    }
}

