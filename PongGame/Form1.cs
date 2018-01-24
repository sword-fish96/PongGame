using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongGame
{
    public partial class Form1 : Form
    {
        bool right;
        bool left;
        public int ball_left = 2;         //labda sebessége
        public int ball_top = 2;
        public int point = 0;           //pont szémlálok 0-zása
        int best = 0;
        

        public Form1()
        {
            InitializeComponent();
            
            
        }
        
        


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)                         //billentyû lenyomások kezelése
            {
                right = true;                                  
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                                                                            //itt zajlik a játéktér,

            if (right && plane.Left <= panel1.Width - plane.Width - 5)
            {
                plane.Left += 8;
            }
            if (left && plane.Left > panel2.Width)
            {
                plane.Left -= 8;
            }

            ball.Left += ball_left;
            ball.Top += ball_top;

            if (ball.Location.X>plane.Location.X && ball.Location.X+ball.Width<plane.Location.X+plane.Width && ball.Location.Y+ball.Height>plane.Location.Y)
            {                                                       //amikor a labda érintkezik a PLAINnel
                if (ball_left<8 && ball_top<8)
                {
                    ball_top += 1;
                    ball_left += 1;
                }
                ball_top = -ball_top;
                point += 1;
                label2.Text = point.ToString();

                Random r = new Random();                            //oldalso panel szinváltozása mikor pattan a labda a PLAINen
                panel2.BackColor = Color.FromArgb(r.Next(5,22), r.Next(150, 225), r.Next( 150, 225));
                plane.BackColor= Color.FromArgb(r.Next(5, 22), r.Next(150, 225), r.Next(150, 225));
            }
            if (ball.Left <= panel1.Left+panel2.Width)
            {
                ball_left = -ball_left;
            }
            if (ball.Right >= panel1.Right)                         //labda pattanása a kereten
            {
                ball_left = -ball_left;
            }
            if (ball.Top <= panel1.Top)
            {
                ball_top = -ball_top;
            }
            if (ball.Bottom >= panel1.Bottom)
            {
                timer1.Enabled = false;                         //ha nem találjuk el a babdát vége a játéknak
                label3.Visible = true;
               
                if (point > best)
                {
                    best = point;
                    label5.Text = best.ToString();

                }   
               
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {                                                           //a billentyû felnegedése modositja mozgáshoz szükséges igaz-hamist
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;                                      // Új játék fül, beállítja az induló poziciót
            point = 0;
            if (label3.Visible == true)
            {
                label3.Visible = false;
            }
            if (label6.Visible == true)
            {
                label6.Visible = false;
            }
            ball_left = 4;
            ball_top = 4;
            ball.Left = 444;
            ball.Top = 209; 
            point = 0;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();                                           //Kilépés fül
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;                                      //KÉSZÍTÕFÜL behoz egy uj panelt, a szine azonos az elõzõével
            panel3.BackColor = panel2.BackColor;
        }

        private void label10_Click(object sender, EventArgs e)
        {                                                               //Vissza lehetõség 
            panel3.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.danielbicskei.com");           //Aktiv linkekek a webcimen
        }

        private void label15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.danielbicskei.com");
        }

        
    }
}
