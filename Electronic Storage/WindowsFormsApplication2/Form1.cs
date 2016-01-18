/*  This aplication was created by the students from A.E.T. TT,
on account of a project for the “Software Engineer”  class in  Department of Computer Systems Engineering,
in piraeus university.
This is  an electronic management system,
which allows you to manage what is in storage,
either you are an administrator or a visitor. */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Thread th;
        string nikolas = "nikolaspapazian@gmail.com";
        string maria = "mariakior@gmail.com";
        string sofia = "sofialoumioti@gmail.com";
        public Classlistvi dedomena = new Classlistvi();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            label25.Size = new System.Drawing.Size(797, 450);
            label25.Visible = true;
            dedomena.log();
            label25.Visible = false;
            label25.Size = new System.Drawing.Size(50, 50);

            int i = 0;
            do {
                if (textBox1.Text == dedomena.pertable[i, 3] && textBox2.Text == dedomena.pertable[i, 4] & dedomena.pertable[i, 5] == "1")
                {
                    th = new Thread(opennewform);
                    MessageBox.Show("WELCOME ADMINISTRATOR");
                    this.Close();
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    break;
                }
                else if (textBox1.Text == dedomena.pertable[i, 3] && textBox2.Text == dedomena.pertable[i, 4] & dedomena.pertable[i, 5] == "0")
                {
                    th = new Thread(opennewform1);
                    MessageBox.Show("WELCOME USER");
                    this.Close();
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    break;
                }
                i++;
            } while (i < dedomena.perlen);
            
                MessageBox.Show("Invalid Username or Password");
            
        }

        private void opennewform()
        {
            Application.Run(new Form2());
        }

        private void opennewform1()
        {
            Application.Run(new Form3());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox2.Text != null)
            {
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                
            }

        }

        private void nikolaspapaziangmailcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nikolas);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void σοφιαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sofia);
        }

        private void μαριαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(maria);
        }

        private void sofialoumiotigmailcomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sofia);
        }

        private void sofialoumiotigmailcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(maria);
        }
    }
}
//Nikolas Papazian A.M.:41785