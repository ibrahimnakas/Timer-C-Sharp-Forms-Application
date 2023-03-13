using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace kronometre
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public extern static void LockWorkStation();
        public Form1()
        {
            InitializeComponent();
        }

        int salise = 0 , saniye = 0 , dakika = 0 ;
        int kalansalise = 0, kalansaniye = 0, kalandakika = 0;
        bool islem = true;

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label1.Text = "00:00:00";
            salise = 0;
            saniye = 0;
            dakika = 0;
            textBox1.Text = "00";
            textBox2.Text = "00";
            textBox3.Text = "00";
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (islem == true)
            {
                salise++;
                if (salise > 99)
                {
                    saniye++;
                    salise = 0;
                }
                if (saniye > 59)
                {
                    dakika++;
                    saniye = 0;
                }

                if ((dakika == kalandakika) && (saniye == kalansaniye) && (salise == kalansalise))
                {
                    timer1.Stop();
                    if (checkBox1.Checked == true)
                    {
                        LockWorkStation();
                    }
                }
            }
            else
            {
                salise--;
                if (salise < 0)
                {
                    salise = 99;
                    saniye--;
                }
                if (saniye < 0)
                {
                    saniye = 59;
                    dakika--;
                }

                if ((dakika == kalandakika) && (saniye == kalansaniye) && (salise == kalansalise))
                {
                    timer1.Stop();
                    if (checkBox1.Checked == true)
                    {
                        LockWorkStation();
                    }
                }
            }
            string sdakika, ssaniye, ssalise;
            if (salise < 10)
            {
                ssalise = "0" + salise.ToString();
            }
            else
            {
                ssalise= salise.ToString();
            }

            if (saniye < 10)
            {
                ssaniye = "0" + saniye.ToString();
            }
            else
            {
                ssaniye = saniye.ToString();
            }

            if (dakika < 10)
            {
                sdakika = "0" + dakika.ToString();
            }
            else
            {
                sdakika = dakika.ToString();
            }

            label1.Text = sdakika + ":" + ssaniye+ ":" + ssalise;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                kalandakika = Convert.ToInt32(textBox1.Text);
                kalansaniye = Convert.ToInt32(textBox2.Text);
                kalansalise = Convert.ToInt32(textBox3.Text);
                islem = true;
            }
            else
            {
                dakika = Convert.ToInt32(textBox1.Text);
                saniye = Convert.ToInt32(textBox2.Text);
                salise = Convert.ToInt32(textBox3.Text);
                islem= false;
            }
            timer1.Start();
        }


        
    }
}
