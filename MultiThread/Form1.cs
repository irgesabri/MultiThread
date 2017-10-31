using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread
{
    public partial class Form1 : Form
    {
        Thread tr1;
        Thread tr2;
        Thread tr3;
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart trs1 = new ThreadStart(Insan1);//paremetre neyi başlatacağını ister.void tipinde bir method ister.
            //ThreadStart bir delegate temsilcidir. bir metod temsil eder.o temsil ettiği metodu da biz threadin içine gondeririz.
            //neden void tipinde?metodun geriye deger dondurmesine gerek yok amacı sadece çalışmaktır.
            tr1 = new Thread(trs1);//paremtreden ThreadStart paremetresi ister.
            tr1.Start();

            ThreadStart trs2 = new ThreadStart(Insan2);
            tr2 = new Thread(trs2);
            tr2.Start();

            ThreadStart trs3 = new ThreadStart(Insan3);
            tr3 = new Thread(trs3);
            tr3.Start();
        }

        void Insan1()
        {
            int konum = pictureBox1.Location.X;
            for (int i = 0; i < panel1.Location.X-pictureBox1.Size.Width; i++)
            {
                Thread.Sleep(new Random().Next(100, 200));
                pictureBox1.Location = new Point(konum++, pictureBox1.Location.Y);
                label1.Text = "Insan1 :" + pictureBox1.Location.X;
            }
            tr1.Abort();
            tr2.Abort();
            tr3.Abort();
        }
        void Insan2()
        {
            int konum = pictureBox2.Location.X;
            for (int i = 0; i < panel1.Location.X - pictureBox2.Size.Width; i++)
            {
                Thread.Sleep(new Random().Next(50, 100));
                pictureBox2.Location = new Point(konum++, pictureBox2.Location.Y);
                label2.Text = "Insan2 :" + pictureBox2.Location.X;
            }
            tr1.Abort();
            tr2.Abort();
            tr3.Abort();
        }
        void Insan3()
        {
            int konum = pictureBox3.Location.X;
            for (int i = 0; i < panel1.Location.X - pictureBox3.Size.Width; i++)
            {
                Thread.Sleep(new Random().Next(10, 20));
                pictureBox3.Location = new Point(konum++, pictureBox3.Location.Y);
                label3.Text = "Insan3 :" + pictureBox3.Location.X;
            }
            tr1.Abort();
            tr2.Abort();
            tr3.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
