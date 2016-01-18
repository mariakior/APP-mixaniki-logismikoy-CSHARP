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
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public int selllen = -1;
        public string[,] selltable = new string[100, 5];
        public Classlistvi dedomena = new Classlistvi();
        public string MyConnect = "SERVER=83.212.120.81;port=3306;DATABASE=ML;UID=Nikos;PASSWORD=test123";

        public Form3()
        {
            InitializeComponent();
            dedomena.scan();
        }

        private void tableintialazi()
        {
            dedomena.data();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Visible == true | listView1.Enabled == true)
            {
                listView1.Visible = false;
                listView1.Enabled = false;
                listBox1.Visible = false;
                listBox1.Enabled = false;
                button2.Visible = false;
                button2.Enabled = false;
                listView1.CheckBoxes = false;
                listView1.Size = new System.Drawing.Size(50, 50);
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.Enabled = false;
                button3.Visible = false;
                button3.Enabled = false;
            }
            else
            {
                listView1.Visible = true;
                listView1.Enabled = true;
                listBox1.Visible = false;
                listBox1.Enabled = false;
                button2.Visible = false;
                button2.Enabled = false;
                listView1.CheckBoxes = false;
                listView1.Size = new System.Drawing.Size(380, 422);
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel1.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
                comboBox1.Items.Clear();
                button3.Text = "ADD";
                label3.Text = "ADD ITEMS";
                comboBox1.Text = ". . .";
                comboBox1.Items.Add(". . .");
                comboBox1.Items.Add("1");
                comboBox1.Items.Add("5");
                comboBox1.Items.Add("10");
                comboBox1.Items.Add("15");
                label5.Text = ". . .";
                label6.Text = ". . .";
                label4.Text = ". . .";
                label8.Text = ". . .";
                label10.Text = "AVALIABLE";
                label8.Visible = true;



                listView1.Clear();
                listView1.Columns.Add("Id", +50, HorizontalAlignment.Left);
                listView1.Columns.Add("Name", +100, HorizontalAlignment.Left);
                listView1.Columns.Add("AVALIABLE", +100, HorizontalAlignment.Left);
                // listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
                listView1.Columns.Add("CODE", +100, HorizontalAlignment.Left);
                listView1.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
                listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
                //listView1.Columns.Add("AVALIABLE", +100, HorizontalAlignment.Left);


                int i = 0;
                label1.Text = "";
                do
                {
                    ListViewItem lvl = new ListViewItem(dedomena.table[i, 0]);
                    lvl.SubItems.Add(dedomena.table[i, 1]);
                    lvl.SubItems.Add(dedomena.table[i, 6]);
                    lvl.SubItems.Add(dedomena.table[i, 3]);
                    //lvl.SubItems.Add(dedomena.table[i, 4]);
                    lvl.SubItems.Add(dedomena.table[i, 5]);
                    lvl.SubItems.Add(dedomena.table[i, 2]);

                    listView1.Items.Add(lvl);
                    i++;
                } while (i < dedomena.len);
            }

        }

        private void sHELLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Columns.Add("Id", +50, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("AVALIABLE", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("CODE", +100, HorizontalAlignment.Left);
            
            listView1.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
            //listView1.Columns.Add("AVALIABLE", +100, HorizontalAlignment.Left);
            
            listBox1.MultiColumn = true;
            listBox1.Items.Clear();
            
            if (button2.Visible == true | listBox1.Visible == true)
            {
                button2.Visible = false;
                button2.Enabled = false;
                listBox1.Visible = false;
                listBox1.Enabled = false;
                listView1.Visible = false;
                listView1.Enabled = false;
                listView1.CheckBoxes = false;
                listView1.Size = new System.Drawing.Size(50, 50);
                listBox1.Size = new System.Drawing.Size(50, 50);
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.Enabled = false;
                button3.Visible = false;
                button3.Enabled = false;
            }
            else {
                button2.Visible = true;
                button2.Enabled = true;
                listBox1.Visible = true;
                listBox1.Enabled = true;
                listView1.Visible = true;
                listView1.Enabled = true;
              
                listView1.Size = new System.Drawing.Size(344, 422);
                listBox1.Size = new System.Drawing.Size(167, 381);
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel1.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
                button3.Text = "MOVE =>";
                label3.Text = "AVALIABLE";
                label10.Text = "SELL";
                comboBox1.Items.Clear();
                comboBox1.Items.Add(". . .");
                comboBox1.Items.Add("1");
                comboBox1.Items.Add("50");
                comboBox1.Items.Add("100");
                comboBox1.Items.Add("150");
                label5.Text = ". . .";
                label6.Text = ". . .";
                label4.Text = ". . .";
                comboBox1.Text = ". . .";
                label8.Text = ". . .";
                label8.Visible = true;

                int i = 0;
                do
                {
                    ListViewItem lvl = new ListViewItem(dedomena.table[i, 0]);
                    lvl.SubItems.Add(dedomena.table[i, 1]);
                    lvl.SubItems.Add(dedomena.table[i, 6]);
                    lvl.SubItems.Add(dedomena.table[i, 2]);
                    lvl.SubItems.Add(dedomena.table[i, 3]);
                    //lvl.SubItems.Add(dedomena.table[i, 4]);
                    lvl.SubItems.Add(dedomena.table[i, 5]);

                    listView1.Items.Add(lvl);
                    i++;
                } while (i < dedomena.len);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(selllen!=-1)
            {
                for(int i=0;i<=selllen;i++)
                {
                    int j = (int.Parse(selltable[i, 4]) - int.Parse(selltable[i, 3]));
                    if(j > 0)
                    {
                        dedomena.addobj(int.Parse(selltable[i, 2]),j);
                        MessageBox.Show("you sell "+ selltable[i, 3] + " items");
                        selltable[i, 0] = "";
                        selltable[i, 1] = "";
                        selltable[i, 2] = "";
                        selltable[i, 3] = "";
                        selltable[i, 4] = "";
                    }
                    else
                    {
                        MessageBox.Show("You cannot sell so match items");
                        selltable[i, 0] = "";
                        selltable[i, 1] = "";
                        selltable[i, 2] = "";
                        selltable[i, 3] = "";
                        selltable[i, 4] = "";
                     }
                }
                selllen = -1;
                listBox1.Items.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tableintialazi();
        }

        private void mOVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Columns.Add("Id", +50, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
            // listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("CODE", +100, HorizontalAlignment.Left);
            
            listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
            //listView1.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("AVALIABLE", +100, HorizontalAlignment.Left);

            if (listView1.Visible == true)
            {
                button2.Visible = false;
                button2.Enabled = false;
                listBox1.Visible = false;
                listBox1.Enabled = false;
                listView1.Visible = false;
                listView1.Enabled = false;
                listView1.CheckBoxes = false;
                listView1.Size = new System.Drawing.Size(50, 50);
                listBox1.Size = new System.Drawing.Size(50, 50);
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.Enabled = false;
                button3.Visible = false;
                button3.Enabled = false;
            }
            else {
                button2.Visible = false;
                button2.Enabled = false;
                listBox1.Visible = false;
                listBox1.Enabled = false;
                listView1.Visible = true;
                listView1.Enabled = true;
                listView1.CheckBoxes = false;
                listView1.Size = new System.Drawing.Size(380, 422);
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel1.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
                comboBox1.Items.Clear();
                button3.Text = "MOVE";
                label3.Text = "NEW POSITION";
                label10.Text = "OLD POSITION";
                comboBox1.Items.Add(". . .");
                comboBox1.Items.Add("A1");
                comboBox1.Items.Add("A2");
                comboBox1.Items.Add("B1");
                comboBox1.Items.Add("B2");
                label5.Text = ". . .";
                label6.Text = ". . .";
                label4.Text = ". . .";
                comboBox1.Text = ". . .";
                label8.Text = ". . .";
                label8.Visible = true;



                int i = 0;
                do
                {
                    ListViewItem lvl = new ListViewItem(dedomena.table[i, 0]);
                    lvl.SubItems.Add(dedomena.table[i, 1]);
                    lvl.SubItems.Add(dedomena.table[i, 5]);
                    lvl.SubItems.Add(dedomena.table[i, 3]);
                    //lvl.SubItems.Add(dedomena.table[i, 4]);
                    lvl.SubItems.Add(dedomena.table[i, 2]);
                    lvl.SubItems.Add(dedomena.table[i, 6]);

                    listView1.Items.Add(lvl);
                    i++;
                } while (i < dedomena.len);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label4.Text != ". . ." & comboBox1.Text != ". . ." & button3.Text.Equals( "MOVE"))
            {

                dedomena.objmov(int.Parse(label4.Text), comboBox1.Text);
                label5.Text = ". . .";
                label6.Text = "name";
                label4.Text = ". . .";
                comboBox1.Text = ". . .";
                label8.Text = ". . .";
            } else if (label4.Text != ". . ." & comboBox1.Text != ". . ." & button3.Text.Equals("CHANGE"))
            {
                dedomena.objpri(int.Parse(label4.Text), int.Parse(comboBox1.Text));
                label5.Text = ". . .";
                label6.Text = "name";
                label4.Text = ". . .";
                comboBox1.Text = ". . .";
                label8.Text = ". . .";
            }
            else  if (label4.Text != ". . ." & comboBox1.Text != ". . ." & button3.Text.Equals("ADD"))
            {
                int g = 0;
                g = int.Parse(comboBox1.Text) + int.Parse(label8.Text);
                dedomena.addobj(int.Parse(label4.Text), g);
                label5.Text = ". . .";
                label6.Text = "name";
                label4.Text = ". . .";
                comboBox1.Text = ". . .";
                label8.Text = ". . .";

            }
            else  if (label4.Text != ". . ." & comboBox1.Text != ". . ." & button3.Text.Equals("MOVE =>"))
            {
                
                //move to lisbox
                listBox1.Items.Add(label6.Text + "  " + comboBox1.Text);
                selllen++;
                selltable[selllen, 0] = label5.Text;
                selltable[selllen, 1] = label6.Text;
                selltable[selllen, 2] = label4.Text;
                selltable[selllen, 3] = comboBox1.Text;
                selltable[selllen, 4] = label8.Text;
                label5.Text = ". . .";
                label6.Text = ". . .";
                label4.Text = ". . .";
                comboBox1.Text = ". . .";
                label8.Text = ". . .";
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Selected == true)
                    {
                        label5.Text = dedomena.table[i, 0];
                        label6.Text = dedomena.table[i, 1];
                        label4.Text = dedomena.table[i, 3];

                        if (listBox1.Visible == true)
                        {
                            label8.Visible = true;
                            comboBox1.Text = dedomena.table[i, 6];
                            label8.Text = dedomena.table[i, 6];
                        }else if (button3.Text == "MOVE")
                        {
                            label8.Visible = true;
                            comboBox1.Text = dedomena.table[i, 5];
                            label8.Text = dedomena.table[i, 5];
                        }else if (button3.Text == "CHANGE")
                        {
                            label8.Visible = true;
                            comboBox1.Text = dedomena.table[i, 2];
                            label8.Text = dedomena.table[i, 2];
                        }else if (button3.Text == "ADD")
                        {
                            label8.Visible = true;
                            comboBox1.Text = dedomena.table[i, 6];
                            label8.Text = dedomena.table[i, 6];
                        }else 
                        {
                            
                        }

                    }
                    i++;
                }
            
            //label5.Text= listView1.SelectedItems.Contains();
        }

        private void pRICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Columns.Add("Id", +50, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("CODE", +100, HorizontalAlignment.Left);
            
            listView1.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("AVALIABLE", +100, HorizontalAlignment.Left);

            if (listView1.Visible == true)
            {
                button2.Visible = false;
                button2.Enabled = false;
                listBox1.Visible = false;
                listBox1.Enabled = false;
                listView1.Visible = false;
                listView1.Enabled = false;
                listView1.CheckBoxes = false;
                listView1.Size = new System.Drawing.Size(50, 50);
                listBox1.Size = new System.Drawing.Size(50, 50);
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.Enabled = false;
                button3.Visible = false;
                button3.Enabled = false;
            }
            else {
                button2.Visible = false;
                button2.Enabled = false;
                listBox1.Visible = false;
                listBox1.Enabled = false;
                listView1.Visible = true;
                listView1.Enabled = true;
                listView1.CheckBoxes = false;
                listView1.Size = new System.Drawing.Size(380, 422);
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel1.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
                label8.Visible = true;
                comboBox1.Items.Clear();
                button3.Text = "CHANGE";
                label3.Text = "NEW PRICE";
                label10.Text = "OLD PRICE";
                comboBox1.Text = ". . .";
                comboBox1.Items.Add(". . .");
                comboBox1.Items.Add("1");
                comboBox1.Items.Add("5");
                comboBox1.Items.Add("10");
                comboBox1.Items.Add("15");
                label5.Text = ". . .";
                label6.Text = ". . .";
                label4.Text = ". . .";
                comboBox1.Text = ". . .";
                label8.Text = ". . .";
                int i = 0;
                do
                {
                    ListViewItem lvl = new ListViewItem(dedomena.table[i, 0]);
                    lvl.SubItems.Add(dedomena.table[i, 1]);
                    lvl.SubItems.Add(dedomena.table[i, 2]);
                    lvl.SubItems.Add(dedomena.table[i, 3]);
                    //lvl.SubItems.Add(dedomena.table[i, 4]);
                    lvl.SubItems.Add(dedomena.table[i, 5]);
                    lvl.SubItems.Add(dedomena.table[i, 6]);

                    listView1.Items.Add(lvl);
                    i++;
                } while (i < dedomena.len);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            int j = -1;
            if (textBox1.Text != "")
            {
                for (i = 0; i < dedomena.len; i++)
                {
                    if (dedomena.table[i, 1] == textBox1.Text || dedomena.table[i, 3] == textBox1.Text)
                    {
                        j = i;
                        textBox1.Text = "FIND!!!";
                        break;
                    }
                }
                if (j != -1)
                {
                    panel1.Visible = true;
                    panel1.Enabled = true;
                    panel1.Size = new System.Drawing.Size(799, 411);
                    panel1.BringToFront();
                    label30.Text = dedomena.table[j, 1];
                    label31.Text = dedomena.table[j, 2];
                    label32.Text = dedomena.table[j, 3];
                    label33.Text = dedomena.table[j, 6];
                    label35.Text = dedomena.table[j, 5];
                    MySqlConnection conn = new MySqlConnection(MyConnect);
                    MySqlCommand cmd;
                    MySqlDataAdapter da;
                    string qery = "SELECT Foto FROM `storage` where ElectronicID ='" + dedomena.table[i, 0] + "'";
                    cmd = new MySqlCommand(qery, conn);
                    da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    byte[] img = (byte[])dt.Rows[0][0];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox4.Image = Image.FromStream(ms);
                    da.Dispose();
                    

                }
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Enabled = false;
            textBox1.Text = "";
            panel1.SendToBack();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
//Nikolas Papazian A.M.:41785